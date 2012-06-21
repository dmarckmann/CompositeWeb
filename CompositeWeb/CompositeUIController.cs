using System;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace CompositeWeb
{
	public class CompositeUIController : IHttpModule
	{


		private static List<ComponentBase> _components;
    private HttpApplication _context;

		static CompositeUIController()
		{
			_components = new List<ComponentBase>();
		}

		#region IHttpModule Members

		public void Dispose()
		{
			//clean-up code here.
		}

		public void Init(HttpApplication context)
		{
			_context = context;
      // Below is an example of how you can handle LogRequest event and provide 
			// custom logging implementation for it
			
			_context.BeginRequest +=new EventHandler(RegisterFilter);
		}
		#endregion

		public void RegisterFilter(Object source, EventArgs e)
		{
			foreach (var component in _components.OfType<IRespondToInput>())
			{
				component.Init(new HttpContextWrapper(_context.Context));
			}

			_context.Response.Filter = new ComponentFilter(_context.Response.Filter, _components.OfType<IOutputModifier>().ToDictionary(m => m.Name));
		}





		public static void RegisterComponent(ComponentBase component)
		{
			_components.Add(component);
		}
	}

}
