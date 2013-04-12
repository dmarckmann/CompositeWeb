using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using CompositeWeb.Controls;

namespace CompositeWeb.UI
{
	public class Global : System.Web.HttpApplication
	{

		protected void Application_Start(object sender, EventArgs e)
		{
			CompositeWeb.CompositeUIController.RegisterComponent(new Suggestions());
			CompositeWeb.CompositeUIController.RegisterComponent(new BookDetails());		
			CompositeWeb.CompositeUIController.RegisterComponent(new QuickBook());
		}

	
	}
}