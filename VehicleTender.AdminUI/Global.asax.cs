using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using VehicleTender.AdminUI.Filters;

namespace VehicleTender.AdminUI
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			
		}

		protected void Session_End(object sender, EventArgs e)
		{

			//FormsAuthentication.SignOut();
		}

		protected void Application_Error()
		{
			FormsAuthentication.SignOut();
		}
	}
}
