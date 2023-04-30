using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleTender.AdminUI.Session
{
	public class SessionData
	{

		public int GetUserId()
		{
			return Convert.ToInt32(HttpContext.Current.Session["UserId"]!=null);
		}
	}
}