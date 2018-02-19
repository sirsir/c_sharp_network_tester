using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace ConnectionTesterWPF1
{
    class ViewModel
    {
        public static string url2submit { get; set; }
        //public ObservableCollection<Connection> connectionList { get; private set; }

        //private static List<Connection> connectionList;
        //public static List<Connection> ConnectionList { get { return connectionList; } }

        private static ObservableCollection<Connection> connectionList;
        public static ObservableCollection<Connection> ConnectionList { get { return connectionList; } }

        public ViewModel()
        {
            url2submit = "http://192.168.1.88:3002/webapi/client_notify";

            // ... Create.
            connectionList = new ObservableCollection<Connection>();
            connectionList.Add(new Connection("WebRequest", "1"));
            connectionList.Add(new Connection("WebRequest", "1","POST"));
            connectionList.Add(new Connection("WebClient", "2"));
            connectionList.Add(new Connection("WebClient", "1", "POST"));
            connectionList.Add(new Connection("RestSharp", "2"));
            connectionList.Add(new Connection("RestSharp", "1", "POST"));
            connectionList.Add(new Connection("RestSharp2", "2"));
            connectionList.Add(new Connection("RestSharp2", "1", "POST"));

            // ... Assign.
            //var grid = sender as DataGrid;
            //grid.ItemsSource = items;

            //AddButtons(grid);
        }

        private void AddButtons(DataGrid gridIn)
        {
            //DataGridTemplateColumn buttonColumn = new DataGridTemplateColumn();
            //DataTemplate buttonTemplate = new DataTemplate();
            //FrameworkElementFactory buttonFactory = new FrameworkElementFactory(typeof(Button));
            //buttonTemplate.VisualTree = buttonFactory;
            ////add handler or you can add binding to command if you want to handle click
            ////buttonFactory.AddHandler(ButtonBase.ClickEvent, new RoutedEventHandler(HandleClick));
            //buttonFactory.SetValue(ContentProperty, "Send HTTP request");
            //buttonColumn.CellTemplate = buttonTemplate;
            //gridIn.Columns.Add(buttonColumn);
        }

        public static void SendRequest()
        {
            foreach (var c in connectionList)
            {
                SendRequest(c.ID);
            }
        }

        public static void SendRequest(int id)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(connectionList)));

            //connectionList.ElementAt(id).Response = id.ToString();
            var connection = connectionList.ElementAt(id);

            var method = connection.Method;
            var data = connection.Data;

            switch (id)
            {
                case 0:
                case 1:
                    {
                        
                        var response = WebRequestLibrary.Class1.SendRequest(method, url2submit, data);

                        connectionList.ElementAt(id).Response = response["result"];
                        break;
                    }
                case 2:
                case 3:
                    {

                        var response = WebClientLibrary.Class1.SendRequest(method, url2submit, data);

                        connectionList.ElementAt(id).Response = response["result"];
                        break;
                    }
                case 4:
                case 5:
                    {

                        var response = RestSharpLibrary2.Class1.SendRequest(method, url2submit, data);

                        connectionList.ElementAt(id).Response = response["result"];
                        break;
                    }
                case 6:
                case 7:
                    {

                        var response = RestSharpLibrary2.Class1.SendRequest(method, url2submit, data);

                        connectionList.ElementAt(id).Response = response["result"];
                        break;
                    }

            }

        }

    }
}
