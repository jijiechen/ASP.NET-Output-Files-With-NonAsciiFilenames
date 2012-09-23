using System;
using System.Collections.Generic;
using System.IO;

using System.Web;
using NonAsciiFilenames.Classes;

namespace NonAsciiFilenames
{
	/// <summary>
	/// Recieve an uploaded file
	/// </summary>
	public class Upload : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			HttpFileCollection files = context.Request.Files;
			if(files.Count > 0 && files[0].ContentLength > 0)
			{
				FileStorage.StoreUploadedFile(files[0]);
			}

			context.Response.Redirect("Default.aspx");
		}

		public bool IsReusable
		{
			get
			{
				return true;
			}
		}
	}
}