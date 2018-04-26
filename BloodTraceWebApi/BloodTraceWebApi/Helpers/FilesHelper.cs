using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BloodTraceWebApi.Helpers
{
    public class FilesHelper
    {
        public static bool UploadPhoto(MemoryStream memoryStream, string folderName, string fileName)
        {
            try
            {
                memoryStream.Position = 0;
                var path = Path.Combine(HttpContext.Current.Server.MapPath(folderName), fileName);
                File.WriteAllBytes(path, memoryStream.ToArray());
            }
            catch
            {
                return false;
            }
           
            return true;
        }
    }
}