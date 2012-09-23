using System;
using System.Collections.Generic;

using System.Web;

namespace NonAsciiFilenames.Download
{
	/// <summary>
	/// wrap the file with quotes
	/// </summary>
	public class Quotes : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			Classes.FileWritter.WriteFile(context, this.ProcessResponse);
		}

		private void ProcessResponse(HttpContext context, string realName)
		{
			context.Response.AddHeader("Content-Disposition",
			                           String.Format("attachment;filename=\"{0}\"", realName));
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}