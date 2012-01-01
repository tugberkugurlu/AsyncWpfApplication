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
using System.Windows.Shapes;
using System.Net;
using System.Threading.Tasks;

namespace AsyncWpfApplication
{
    /// <summary>
    /// Interaction logic for AsyncAPMWindow.xaml
    /// </summary>
    public partial class AsyncAPMWindow : Window
    {
        public AsyncAPMWindow()
        {
            InitializeComponent();
        }

        private void btnGetAPMWindow_Click(object sender, RoutedEventArgs e) {

            var _APMWindow = new APMWindow();
            _APMWindow.Show();

            this.Close();
        }

        private void btnGetAsyncWindow_Click(object sender, RoutedEventArgs e) {

            var _AsyncWindow = new AsyncWindow();
            _AsyncWindow.Show();

            Close();
        }

        private void btnGet_Click(object sender, RoutedEventArgs e) {

            Uri uri;
            var _uri = Uri.TryCreate(txtUri.Text, UriKind.Absolute, out uri);

            if (!_uri) {

                MessageBox.Show("Uri is not in a correct format");
                return;
            }

            DoDownload(uri);

        }

        private async void DoDownload(Uri uri) {

            var req = (HttpWebRequest)WebRequest.Create(uri.ToString());
            req.Method = "HEAD";

            Task<WebResponse> getResponseTask = Task.Factory.FromAsync<WebResponse>(
                req.BeginGetResponse, req.EndGetResponse, null);

            var resp = (HttpWebResponse) await getResponseTask;
            string headersText = Utility.FormatHeaders(resp.Headers);
            txtContent.Text = headersText;
        }
    }
}
