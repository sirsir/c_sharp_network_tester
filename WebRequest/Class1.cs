using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebRequestLibrary
{
    public class Class1
    {

        public static Dictionary<string, string> SendRequest(string httpMethod, string url, Dictionary<string, string> data)
        {

            Dictionary<string, string> response = new Dictionary<string, string>();

            switch (httpMethod.ToLower())
            {
                case "post":
                    {

                        response = SendPostRequest( url, data);
                        break;
                    }
                case "get":
                    {
                        response = SendGetRequest( url, data);
                        break;
                    }
            }

            return response;

        }

        private static Dictionary<string, string> SendPostRequest( string url, Dictionary<string, string> data)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();

            try
            {
                

                var request = (HttpWebRequest)WebRequest.Create(url);

                var postData = "thing1=hello";
                postData += "&thing2=world";
                var dataOut = Encoding.ASCII.GetBytes(postData);

                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = dataOut.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(dataOut, 0, dataOut.Length);
                }

                var response0 = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response0.GetResponseStream()).ReadToEnd();

                response.Add("result", responseString);

                return response;
            }catch(Exception e)
            {
                response.Add("result", "<error>" + e.ToString());

                response.Add("e.Message", e.Message);
                response.Add("e", e.ToString());



                return response;

            }
            
        }

        private static Dictionary<string, string> SendGetRequest(string url, Dictionary<string, string> data)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();

            try
            {
                

                var request = (HttpWebRequest)WebRequest.Create(url);

                var response0 = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response0.GetResponseStream()).ReadToEnd();

                response.Add("result", responseString);

                return response;
            }
            catch(Exception e)
            {
                response.Add("result", "<error>" + e.ToString());

                response.Add("e.Message", e.Message);
                response.Add("e", e.ToString());



                return response;

            }
   
        }
    }

       
}
