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
		public List<string> AddImage(List<HttpPostedFileBase> images)
		{
			// db ye kaydedilecek olan path
			string savepath = "/TemplateContent/img/DbAddedImg/";
			if (images.Any(x=>x!=null))
			{
				List<string> imagePaths = new List<string>();
				foreach (var item in images)
				{
					if (item.ContentLength > 0)
					{
						var image = Path.GetFileName(item.FileName);
						var path = Path.Combine(HttpContext.Current.Server.MapPath("~/TemplateContent/img/DbAddedImg"), image);
						item.SaveAs(path);
						imagePaths.Add(savepath + image);
					}
				}
				return imagePaths;
			}

			return null;
		}
	}
}
