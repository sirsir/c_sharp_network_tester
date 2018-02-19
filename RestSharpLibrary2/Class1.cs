using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestSharpLibrary2
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
                var client = new RestClient(url);
                var request = new RestRequest();
                request.RequestFormat = DataFormat.Json;
                request.Method = Method.POST;


                request.AddParameter("Authorization", "data", ParameterType.HttpHeader);                

                if (data != null)
                {
                    foreach (KeyValuePair<string, string> entry in data)
                    {
                        // do something with entry.Value or entry.Key
                        request.AddParameter(entry.Key, entry.Value);
                    }
                }               

                var response0 = client.Execute(request);

                var responseString = response0.Content;

                response.Add("result", responseString);

                return response;
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
                var client = new RestClient(url);
                var request = new RestRequest();
                request.RequestFormat = DataFormat.Json;
                request.Method = Method.GET;

                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                //request.AddHeader("Authorization", "Bearer " + accessToken);
                request.Parameters.Clear();
                //request.AddParameter("application/json", JsonConvert.SerializeObj;

                request.AddHeader("Accept", "*/*");
                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("Accept-Language", "en-US,en;q=0.8");
                request.AddHeader("Accept-Encoding", "gzip, deflate");

                // Some header not applied above
                request.JsonSerializer.ContentType = "application/json; charset=utf-8";

                client.UserAgent = "Mozilla/5.0 (Windows NT 5.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";                
                
                var response0 = client.Execute(request);

                var responseString = response0.Content;

                response.Add("result", responseString);

                return response;
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
