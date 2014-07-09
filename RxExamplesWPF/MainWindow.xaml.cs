using System;
using System.Windows;

namespace RxExamplesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            LogBox.Text += DateTime.Now.ToString("HH:mm:ss.fffffff") + " - Click\r\n";
            LogBox.ScrollToEnd();
        }
    }
}
