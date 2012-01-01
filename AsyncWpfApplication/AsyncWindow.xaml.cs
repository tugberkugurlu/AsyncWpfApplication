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
    /// Interaction logic for AsyncWindow.xaml
    /// </summary>
    public partial class AsyncWindow : Window {

        public AsyncWindow() {

            InitializeComponent();
        }

        private void btnGetWindow_Click(object sender, RoutedEventArgs e) {

            var _MainWindow = new MainWindow();
            _MainWindow.Show();

            Close();

        }

        private void btnGetAPMWindow_Click(object sender, RoutedEventArgs e) {

            var _APMWindow = new APMWindow();
            _APMWindow.Show();

            Close();
        }

        private void btnGet_Click(object sender, RoutedEventArgs e) {

            Uri uri;
            var _uri = Uri.TryCreate(txtUri.Text, UriKind.Absolute, out uri);

            if (!_uri) {

                MessageBox.Show("Uri is not in a correct format");
                return;
            }

            DoDownload(uri.ToString());
            textBlock1.Text = "Started Downloading...";
        }

        private async void DoDownload(string uri) {

            WebClient w = new WebClient();

            string txt = await w.DownloadStringTaskAsync(uri);
            
            txtContent.Text = txt;
            textBlock1.Text = "Done!";
        }
    }
}
