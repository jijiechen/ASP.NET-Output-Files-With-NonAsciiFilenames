using System;
using System.Web;

namespace NonAsciiFilenames.Download
{
	/// <summary>
	/// Normal way to output a filename
	/// </summary>
	public class Normal : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			Classes.FileWritter.WriteFile(context, this.ProcessResponse);
		}

		private void ProcessResponse(HttpContext context, string realName)
		{
			context.Response.AddHeader("Content-Disposition",
			                           String.Format("attachment;filename={0}", realName));
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