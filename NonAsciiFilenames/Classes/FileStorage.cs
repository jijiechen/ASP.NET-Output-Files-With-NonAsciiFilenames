using System;
using System.Collections.Generic;
using System.IO;

using System.Text.RegularExpressions;
using System.Web;

namespace NonAsciiFilenames.Classes
{
	public static class FileStorage
	{
		private const string appDataPath = "~/App_Data";
		private const string storagePath = "Files";
		private const string configExtension = ".config";

		/// <summary>
		/// Store the file entity body and its original name
		/// </summary>
		/// <param name="file"></param>
		public static void StoreUploadedFile(HttpPostedFile file)
		{
			if (HttpContextNull())
			{
				return;
			}

			string fileId = Guid.NewGuid().ToString("N");
			var dataPath = HttpContext.Current.Server.MapPath(appDataPath);

			file.SaveAs(Path.Combine(Path.Combine(dataPath, storagePath),fileId));
			File.WriteAllText(
				Path.Combine(dataPath, fileId + configExtension),
				StripFullName(file.FileName),
				System.Text.Encoding.UTF8);
		}
		/// <summary>
		/// Load all files stored in Storage
		/// </summary>
		/// <returns></returns>
		public static List<UploadedFile> LoadFilesForTesting()
		{
			List<UploadedFile> files = new List<UploadedFile>();
			// In design mode, HttpContext will be null
			if (HttpContextNull())
			{
				return files;
			}

			string[] configFiles = Directory.GetFiles(HttpContext.Current.Server.MapPath(appDataPath), "*" + configExtension);
			foreach (string config in configFiles)
			{
				FileInfo configFile = new FileInfo(config);
				string fileId = configFile.Name.Substring(0, configFile.Name.LastIndexOf("."));
				FileInfo originalFile = new FileInfo(FileId2FullName(fileId));

				if (originalFile.Exists)
				{
					UploadedFile fileItem = new UploadedFile();
					fileItem.Id = fileId;
					fileItem.Filename = File.ReadAllText(config);
					fileItem.Size = originalFile.Length;
					fileItem.LastModified = originalFile.LastWriteTime;

					files.Add(fileItem);
				}
			}
			return files;
		}

		public static string FileId2FullName(string fileId)
		{
			if (fileId == null ||
				string.IsNullOrEmpty(fileId.Trim()) ||
				HttpContextNull())
			{
				return string.Empty;
			}

			return Path.Combine(Path.Combine(HttpContext.Current.Server.MapPath(appDataPath), storagePath), fileId);

		}
		
		public static string GetRealName(string fileId)
		{
			if (HttpContextNull())
			{
				return string.Empty;
			}

			string configFileName = Path.Combine(HttpContext.Current.Server.MapPath(appDataPath),
			                                     fileId + configExtension);
			if(File.Exists(configFileName))
			{
				return File.ReadAllText(configFileName);
			}
			return string.Empty;
		}


		/// <summary>
		/// Some versions of Internet Explorer will provider a full name on client disk
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private static string StripFullName(string name)
		{
			return Regex.Replace(name,
								 @"^[A-Z]\:([^\\]*\\)+",
			                     string.Empty,
			                     RegexOptions.IgnoreCase);
		}

		private static bool HttpContextNull()
		{
			return null == HttpContext.Current;
		}
	}
}