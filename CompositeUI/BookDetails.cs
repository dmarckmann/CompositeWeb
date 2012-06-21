using System;
using System.Collections.Generic;
using System.Linq;
using CompositeWeb;
using System.IO;

namespace CompositeUI
{
	public class BookDetails : ComponentBase, IOutputModifier, IRespondToInput
	{
		private string _contents;
		public string Contents
		{
			get
			{

				return _contents;
			}
		}

		public string Name
		{
			get { return "BookDetails"; }
		}

		public void Init(System.Web.HttpContextBase context)
		{
			string boek = context.Request["book"];
			if (string.IsNullOrEmpty(boek))
			{
				_contents = "No book...";
			}
			else
			{
				_contents = File.ReadAllText(context.Server.MapPath(string.Format("/BookDetails/{0}.html", boek)));
			}
		}

		
	}
}
