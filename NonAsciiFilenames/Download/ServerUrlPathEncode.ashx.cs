using System;
using System.Web;

namespace NonAsciiFilenames.Download
{
	/// <summary>
	/// Use Server.UrlPathEncode to encode the filename before outputing
	/// </summary>
	public class ServerUrlPathEncode : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			Classes.FileWritter.WriteFile(context, this.ProcessResponse);
		}

		private void ProcessResponse(HttpContext context, string realName)
		{
			context.Response.AddHeader("Content-Disposition",
									   String.Format("attachment;filename={0}", context.Server.UrlPathEncode(realName)));
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