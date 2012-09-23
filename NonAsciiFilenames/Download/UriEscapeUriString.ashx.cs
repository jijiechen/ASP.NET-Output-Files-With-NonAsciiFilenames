using System;
using System.Collections.Generic;

using System.Web;

namespace NonAsciiFilenames.Download
{
	/// <summary>
	/// Use Uri.EscapeUriString to encode the filename before outputing
	/// </summary>
	public class UriEscapeUriString : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			Classes.FileWritter.WriteFile(context, this.ProcessResponse);
		}

		private void ProcessResponse(HttpContext context, string realName)
		{
			context.Response.AddHeader("Content-Disposition",
									   String.Format("attachment;filename={0}", Uri.EscapeUriString(realName)));
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