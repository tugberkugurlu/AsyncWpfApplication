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

namespace AsyncWpfApplication
{
    /// <summary>
    /// Interaction logic for APMWindow.xaml
    /// </summary>
    public partial class APMWindow : Window
    {
        public APMWindow()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, RoutedEventArgs e) {

            var sync = System.Threading.SynchronizationContext.Current;

            #region _get the Uri

            Uri uri;
            var _uri = Uri.TryCreate(txtUri.Text, UriKind.Absolute, out uri);

            if (!_uri) {

                MessageBox.Show("Uri is not in a correct format");
                return;
            }

            #endregion

            var req = (HttpWebRequest)WebRequest.Create(uri.ToString());
            req.Method = "HEAD";

            req.BeginGetResponse(asyncResult => {

                var resp = (HttpWebResponse)req.EndGetResponse(asyncResult);
                string headersText = Utility.FormatHeaders(resp.Headers);
                sync.Post(delegate {

                    txtContent.Text = headersText;

                }, null);

            }, null);
        }

        private void btnGetAPMWindow_Click(object sender, RoutedEventArgs e) {

            var _MainWindow = new MainWindow();
            _MainWindow.Show();

            this.Close();
        }

        private void btnGetAsyncWindow_Click(object sender, RoutedEventArgs e)
        {
            var _AsyncWindow = new AsyncWindow();
            _AsyncWindow.Show();

            Close();
        }
    }
}
