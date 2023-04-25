using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VehicleTender.DAL.FileAdd
{
	public class ImageAdd
	{
		public List<> AddImage(List<HttpPostedFileBase> images,int vehicleId)
		{
			List<string> imagePaths = new List<string>();
			foreach (var item in images)
			{
				if (item.ContentLength > 0)
				{
					var image = Path.GetFileName(item.FileName);
					var path = Path.Combine(HttpContext.Current.Server.MapPath("~/TemplateContent/img/"), image);
					item.SaveAs(path);
					imagePaths.Add(path);
				}
			}
			return imagePaths;
		}
	}
}
