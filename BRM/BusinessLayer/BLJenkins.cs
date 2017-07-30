using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLJenkins
    {
        public string Get(string url)
        {
            string responseString = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var httpResponse = (HttpWebResponse)request.GetResponse();
            Stream resStream = httpResponse.GetResponseStream();
            var reader = new StreamReader(resStream);
            responseString = reader.ReadToEnd();
            resStream.Close();
            reader.Close();

            return responseString;
        }

        public string Post(string url, string postData)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
