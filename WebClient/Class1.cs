using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WebClientLibrary
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

                        response = SendPostRequest(url, data);
                        break;
                    }
                case "get":
                    {
                        response = SendGetRequest(url, data);
                        break;
                    }
            }

            return response;

        }

        private static Dictionary<string, string> SendPostRequest(string url, Dictionary<string, string> data)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();

            try
            {
                using (var client = new WebClient())
                {
                    var values = new System.Collections.Specialized.NameValueCollection();
                    values["thing1"] = "hello";
                    values["thing2"] = "world";

                    var response0 = client.UploadValues(url, values);

                    var responseString = Encoding.Default.GetString(response0);


                    response.Add("result", responseString);

                    return response;
                }

                
            }
            catch (Exception e)
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
                using (var client = new WebClient())
                {
                    var responseString = client.DownloadString(url);

                    response.Add("result", responseString);

                    return response;
                }                               
            }
            catch (Exception e)
            {
                response.Add("result", "<error>" + e.ToString());

                response.Add("e.Message", e.Message);
                response.Add("e", e.ToString());



                return response;

            }

        }
    }
}
