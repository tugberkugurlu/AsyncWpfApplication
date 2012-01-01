using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;

namespace AsyncWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, RoutedEventArgs e) {
            
            Uri uri;
            var _uri = Uri.TryCreate(txtUri.Text, UriKind.Absolute, out uri);

            if (!_uri) {

                MessageBox.Show("Uri is not in a correct format");
                return;
            }

            var req = (HttpWebRequest)WebRequest.Create(uri.ToString());
            req.Method = "HEAD";
            var resp = (HttpWebResponse)req.GetResponse();
            string headersText = Utility.FormatHeaders(resp.Headers);
            txtContent.Text = headersText;
        }

        private void btnGetAPMWindow_Click(object sender, RoutedEventArgs e) {

            var _APMWindow = new APMWindow();
            _APMWindow.Show();

            this.Close();
        }

        private void btnGetAsyncWindow_Click(object sender, RoutedEventArgs e)
        {
            var _AsyncWindow = new AsyncWindow();
            _AsyncWindow.Show();

            Close();
        }

        private void btnGetAsyncAPMWindow_Click(object sender, RoutedEventArgs e) {

            var _AsyncAPMWindow = new AsyncAPMWindow();
            _AsyncAPMWindow.Show();

            Close();
        }

    }
}
