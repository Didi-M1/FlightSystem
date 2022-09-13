using System;
using System.IO;
using System.Net;

namespace DAL
{
    public class FlagByCountrey
    {
        private string url = "https://countryflagsapi.com/png/";

        public string getImageByName(string countryName = "")
        {
            string path = @"C:\flight\PLGUI\images\" + countryName + ".png";
            //if the file is already exist
            if (File.Exists(path))
            {
                return path;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + countryName);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    reader.BaseStream.CopyTo(File.Create(path));
                    return path;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}