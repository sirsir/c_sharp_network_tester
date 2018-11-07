using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Globals
    {
        public static Form1 form1;

        public static class functions
        {

            public static Dictionary<string, string> SendRequest(string httpMethod, string url, Dictionary<string, string> data)
            {
                object y = Globals.form1.webBrowser1.Document.InvokeScript("SendRequest", new string[] { httpMethod, url });

                Dictionary<string, string> response = new Dictionary<string, string>();

                if (StateManager.state != StateManager.stateList.browser_load_finish)
                {
                    response["response"] = "Browser not ready!";
                }

                return response;
            }
            
        }
    }
}
