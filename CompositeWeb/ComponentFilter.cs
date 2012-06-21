using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CompositeWeb
{
	public class ComponentFilter : MemoryStream
	{
		private readonly Dictionary<string, IOutputModifier> _outputModifiers;
		Stream _outputStream;

		public ComponentFilter(Stream outputStream, Dictionary<string, IOutputModifier> outputModifiers)
		{
			_outputModifiers = outputModifiers;
			_outputStream = outputStream;

		}


		//Other overrides here ;

		public override void Write(byte[] buffer, int offset, int count)
		{
			string strBuffer = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);

			strBuffer = WriteExtracted(strBuffer);
			_outputStream.Write(System.Text.UTF8Encoding.UTF8.GetBytes(strBuffer), offset, UTF8Encoding.UTF8.GetByteCount(strBuffer));
		}

		private string WriteExtracted(string strBuffer)
		{
			string pattern = @"{{(?<name>.*):(?<id>\d+)}}|{{(?<name>.*)}}";
			var collection = Regex.Matches(strBuffer, pattern, RegexOptions.Multiline);
			foreach (Match m in collection)
			{
				var name = m.Groups["name"].Value;
				var id = m.Groups["id"].Value;

				IOutputModifier mod = null;
				_outputModifiers.TryGetValue(name, out mod);
				if (mod != null)
				{
					if (mod is INeedInlineId && !string.IsNullOrEmpty(id))
					{
						var tmp = mod as INeedInlineId;
						tmp.Id = id;
					}
					strBuffer = WriteExtracted(strBuffer.Replace(m.Value, m.Result(mod.Contents)));
				}
			}
			return strBuffer;
		}
		
	}

}
