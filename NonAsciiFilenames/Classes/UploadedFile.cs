using System;
using System.Collections.Generic;
using System.Web;

namespace NonAsciiFilenames.Classes
{

	public class UploadedFile
	{
		private string _id;
		private long _size;
		private string _fileName;
		private DateTime _lastModified;

		public string Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Filename
		{
			get { return _fileName; }
			set { _fileName = value; }
		}

		public long Size
		{
			get { return _size; }
			set { _size = value; }
		}

		public DateTime LastModified
		{
			get { return _lastModified; }
			set { _lastModified = value; }
		}

		public string GenerateDownloadLink(DownloadLinkType linkType)
		{
			const string downloadLinkFormat = "Download/{0}.ashx?fileid={1}";
			return string.Format(downloadLinkFormat, linkType, this.Id);
		}
	}

	public enum DownloadLinkType
	{
		Normal,

		ServerUrlEncode,

		ServerUrlPathEncode,

		UriEscapeDataString,

		UriEscapeUriString,

		Quotes,

		FixedCodes
	}
}