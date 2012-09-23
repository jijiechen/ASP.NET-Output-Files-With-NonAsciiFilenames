using System;
using System.Collections.Generic;
using System.IO;

using System.Web;

namespace NonAsciiFilenames.Classes
{
	public static class FileWritter
	{
		public static void WriteFile(HttpContext httpContext, PreProcessResponse preProcessor)
		{
			HttpResponse response = httpContext.Response;
			response.Clear();
			response.AddHeader("Content-Type", "Application/Octect-Stream");

			string fileId = httpContext.Request.QueryString["fileId"];
			string storedPath = FileStorage.FileId2FullName(fileId);
			if (File.Exists(storedPath))
			{
				string realName = FileStorage.GetRealName(fileId);
				preProcessor.Invoke(httpContext, realName);

				response.WriteFile(storedPath);
			}
			else
			{
				response.StatusCode = 404;
			}
			response.End();
		}
	}

	public delegate void PreProcessResponse(HttpContext httpContext, string realName);
}