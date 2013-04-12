using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompositeWeb;
using System.IO;

namespace CompositeWeb.Controls
{


	public class QuickBook : ComponentBase, IOutputModifier, INeedInlineId, IRespondToInput
	{
		private string _contents;
		private System.Web.HttpContextBase _context;
    public string Contents
		{
			get
			{
		
				return _contents;
			}
		}

		public string Name
		{
			get { return "QuickBook"; }
		}

		public string Id
		{
			set
			{
				_contents = File.ReadAllText(_context.Server.MapPath(string.Format("/QuickBook/{0}.html", value)));
			}
		}

		public void Init(System.Web.HttpContextBase context)
		{
			_context = context;
		}
	}

}
