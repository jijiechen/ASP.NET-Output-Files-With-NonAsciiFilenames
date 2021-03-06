﻿using System;
using System.Collections.Generic;

using System.Web;

namespace NonAsciiFilenames.Download
{
	/// <summary>
	/// Use Uri.EscapeDataString to encode the filename before outputing
	/// </summary>
	public class UriEscapeDataString : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			Classes.FileWritter.WriteFile(context, this.ProcessResponse);
		}

		private void ProcessResponse(HttpContext context, string realName)
		{
			context.Response.AddHeader("Content-Disposition",
									   String.Format("attachment;filename={0}", Uri.EscapeDataString(realName)));
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