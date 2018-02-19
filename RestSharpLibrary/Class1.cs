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


                //request.AddParameter("Authorization", "data", ParameterType.HttpHeader);
                //request.RequestFormat = DataFormat.Json;
                //request.AddBody(new Item
                //{
                //    ItemName = someName,
                //    Price = 19.99
                //});

                //foreach( var key in data.Keys)
                //{
                //    request.AddParameter(key, data[key]);
                //}
                //data = new Dictionary<string, string>() {
                //    { "os_version", "Win10 " },
                //    {"watcher_version","2.0.0.110" },
                //    {"computer_name","DESKTOP-M5NIGI0"},
                //    {"login_name","Sirisak"},
                //    {"mac_address","08002770A3BB"},
                //    {"domainname","DESKTOP-M5NIGI0"},
                //    {"ip","10.0.2.15"},
                //    { "event","startup" }
                //};

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
                //request.AddBody(new Item
                //{
                //    ItemName = someName,
                //    Price = 19.99
                //});
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
