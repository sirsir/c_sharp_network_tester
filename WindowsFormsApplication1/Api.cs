using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WindowsFormsApplication1
{
    public class Api
    {
        

        public static Dictionary<string, string> SendRequest(string httpMethod, string url, Dictionary<string, string> data)
        {
            StateManager.initForm();
            Dictionary<string, string> response = new Dictionary<string, string>();

            while (StateManager.state < StateManager.stateList.browser_load_finish)
            {
                System.Windows.Forms.Application.DoEvents();
                //response["result"] = "Browser not ready!";
                //return response;
            }

            //object y = Globals.functions.SendRequest( httpMethod, url , data);
            //object y = Globals.form1.webBrowser1.Document.InvokeScript("SendRequest", new string[] { httpMethod, url });


            ////you can also send xml here
            //string data = "this is test sending by postdata paramer";
            //byte[] bytedata = Encoding.UTF8.GetBytes(data);


            ////when you send data using postdata paramer, post method is used
            //webBrowser1.Navigate("Targeturl", string.Empty, bytedata, string.Empty);

            //if (StateManager.state == StateManager.stateList.busy)
            //{
            //    response["result"] = "Browser is busy!";
            //    return response;
            //}

           

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
                while (StateManager.state == StateManager.stateList.busy)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                StateManager.state = StateManager.stateList.busy;


                string dataStr = "";

                if (data != null)
                {
                    dataStr = data.ToString();
                }

                
                //you can also send xml here
                //string data = "this is test sending by postdata paramer";
                byte[] bytedata = Encoding.UTF8.GetBytes(dataStr);


                //when you send data using postdata paramer, post method is used
                Globals.form1.webBrowser1.Navigate(url, string.Empty, bytedata, string.Empty);


                //while (StateManager.state == StateManager.stateList.busy)
                //{
                //    Thread.Sleep(1000);
                //}

                while (StateManager.state == StateManager.stateList.busy)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                //response["result"] = Globals.form1.webBrowser1.DocumentText;

                //var responseString = Globals.form1.webBrowser1.DocumentText;
                var responseString = "";
                if (Globals.form1.webBrowser1.Document.Body.Children.Count == 1 && Globals.form1.webBrowser1.Document.Body.GetElementsByTagName("pre").Count > 0)
                {
                    responseString = Globals.form1.webBrowser1.Document.Body.GetElementsByTagName("pre")[0].InnerHtml;
                }else
                {
                    responseString = Globals.form1.webBrowser1.DocumentText;
                }
                

                response.Add("result", responseString);

                return response;
            }
            catch (Exception e)
            {
                response.Add("result", "<error>" + e.ToString());

                response.Add("e.Message", e.Message);
                response.Add("e", e.ToString());

                StateManager.state = StateManager.stateList.waiting_for_request;



                return response;

            }

        }

        private static Dictionary<string, string> SendGetRequest(string url, Dictionary<string, string> data)
        {
            Dictionary<string, string> response = new Dictionary<string, string>();

            try
            {
                while (StateManager.state == StateManager.stateList.busy)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                StateManager.state = StateManager.stateList.busy;
                Globals.form1.webBrowser1.Navigate(url);
                //Globals.form1.webBrowser1.Url = new Uri(String.Format(url));


                //while (StateManager.state == StateManager.stateList.busy)
                //{
                //    Thread.Sleep(1000);
                //}

                while (StateManager.state == StateManager.stateList.busy)
                {
                    System.Windows.Forms.Application.DoEvents();
                }

                //response["result"] = Globals.form1.webBrowser1.DocumentText;

                //var responseString = Globals.form1.webBrowser1.DocumentText;
                var responseString = "";
                if (Globals.form1.webBrowser1.Document.Body.Children.Count == 1 && Globals.form1.webBrowser1.Document.Body.GetElementsByTagName("pre").Count > 0)
                {
                    responseString = Globals.form1.webBrowser1.Document.Body.GetElementsByTagName("pre")[0].InnerHtml;
                }
                else
                {
                    responseString = Globals.form1.webBrowser1.DocumentText;
                }


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
