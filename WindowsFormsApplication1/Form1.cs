using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        private string urlHome = "file:///{0}/web1/index.html";

        public Form1()
        {
            InitializeComponent();
        }

        public bool isLoadFinish = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            this.webBrowser1.Url = new Uri(String.Format(urlHome, curDir));
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!isLoadFinish)
            {
                isLoadFinish = true;
                StateManager.state = StateManager.stateList.browser_load_finish;
            }
            

            StateManager.state = StateManager.stateList.waiting_for_request;
        }
    }
}
