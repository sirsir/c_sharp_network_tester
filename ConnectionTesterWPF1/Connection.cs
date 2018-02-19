using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConnectionTesterWPF1
{
    class Connection: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Method { get; set; }

        public Dictionary<string,string> Data { get; set; }

        public int ID { get; set; }

        private static int id_counter = 0;

        private string _response;
        public string Response {
            get { return _response; }
            set
            {
                _response = value;
                //PropertyChanged("Response");
                OnPropertyChanged("Response");
            } }


        public Connection(string name, string strDescription,string method = "GET", Dictionary<string,string> data = null, string response = "")
        {
            this.Name = name;
            this.Description = strDescription;
            this.Method = method;
            this.Data = data;

            this.ID = id_counter++;
        }

       
    }
}
