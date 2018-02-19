using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace HttpClientLibrary
{
    public class Class1
    {

        #region Net4.5+
        //private static readonly HttpClient client = new HttpClient();

        //public static Dictionary<string, string> SendRequest(string httpMethod, string url, Dictionary<string, string> data)
        //{

        //    Dictionary<string, string> response = new Dictionary<string, string>();

        //    switch (httpMethod.ToLower())
        //    {
        //        case "post":
        //            {

        //                response = SendPostRequest( url, data);
        //                break;
        //            }
        //        case "get":
        //            {
        //                response = SendGetRequest( url, data);
        //                break;
        //            }
        //    }

        //    return response;

        //}

        //private static Dictionary<string, string> SendPostRequest( string url, Dictionary<string, string> data)
        //{
        //    Dictionary<string, string> response = new Dictionary<string, string>();

        //    try
        //    {

        //        var request = (HttpWebRequest)WebRequest.Create(url);

        //        var values = new Dictionary<string, string>{
        //               { "thing1", "hello" },
        //               { "thing2", "world" }
        //            };

        //        var content = new FormUrlEncodedContent(values);

        //        var response0 = await client.PostAsync(url, content);

        //        var responseString = await response0.Content.ReadAsStringAsync();               

        //        response.Add("result", responseString);

        //        return response;
        //    }catch(Exception e)
        //    {
        //        response.Add("result", "<error>" + e.ToString());

        //        response.Add("e.Message", e.Message);
        //        response.Add("e", e.ToString());



        //        return response;

        //    }
            
        //}

        //private static Dictionary<string, string> SendGetRequest(string url, Dictionary<string, string> data)
        //{
        //    Dictionary<string, string> response = new Dictionary<string, string>();

        //    try
        //    {



        //        var responseString = await client.GetStringAsync(url);

        //        response.Add("result", responseString);

        //        return response;
        //    }
        //    catch(Exception e)
        //    {
        //        response.Add("result", "<error>" + e.ToString());

        //        response.Add("e.Message", e.Message);
        //        response.Add("e", e.ToString());



        //        return response;

        //    }
   
        //}

        #endregion
    }
}
