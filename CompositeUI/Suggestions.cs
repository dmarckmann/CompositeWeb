using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompositeWeb;
using System.IO;
using System.Web;

namespace CompositeUI
{
	class Suggestions : ComponentBase, IOutputModifier, IRespondToInput
	{
		private HttpContextBase _context;
    public string Contents
		{
			get { return File.ReadAllText(_context.Server.MapPath("/Suggestions/Suggestions.html")); }
		}

		public string Name
		{
			get { return "Suggestions"; }
		}

		public void Init(HttpContextBase context)
		{
			_context = context;
		}
	}
}
