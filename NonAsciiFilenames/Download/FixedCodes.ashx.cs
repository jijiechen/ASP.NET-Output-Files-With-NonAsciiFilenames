using System;
using System.Web;
using System.Text.RegularExpressions;

namespace NonAsciiFilenames.Download
{
	/// <summary>
	/// Use defferent encode methods to encode the filename
	/// </summary>
	public class FixedCodes : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			Classes.FileWritter.WriteFile(context, this.ProcessResponse);
		}

		private void ProcessResponse(HttpContext context, string realName)
		{
			string encodedName = realName;

			string userAgent = context.Request.UserAgent;
			Regex ieRegex = new Regex("msie", RegexOptions.IgnoreCase);
			Regex ffRegex = new Regex("firefox", RegexOptions.IgnoreCase);

			if (ieRegex.IsMatch(userAgent))
			{
				encodedName = Uri.EscapeUriString(realName);
			}
			else if (ffRegex.IsMatch(userAgent))
			{
				encodedName = String.Format("\"{0}\"", realName);
			}

			
			context.Response.AddHeader("Content-Disposition",
									   String.Format("attachment;filename={0}", encodedName));
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