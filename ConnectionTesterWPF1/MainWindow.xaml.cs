using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConnectionTesterWPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModel();

        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
           

        }



        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(url2submit)));

            //var url = textBox.Text();

            ViewModel.SendRequest();

            //Popup myPopup = new Popup();
            ////(...)
            //TextBlock popupText = new TextBlock();
            //popupText.Text = "Popup Text";
            //popupText.Background = Brushes.LightBlue;
            //popupText.Foreground = Brushes.Blue;
            //myPopup.Child = popupText;
            //myPopup.IsOpen = true;
        }

        private void my_button_Click(object sender, RoutedEventArgs e)
        {
            Connection obj = (Connection)((FrameworkElement)sender).DataContext;

            ViewModel.SendRequest(obj.ID);

            //Datagrid.Items.Refresh();

            ((FrameworkElement)sender).Focus();
        }
    }
}
