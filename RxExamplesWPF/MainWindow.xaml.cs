using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
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

            InitializeSubject();            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            LogBox.Text += DateTime.Now.ToString("HH:mm:ss.fffffff") + " - Click\r\n";
            LogBox.ScrollToEnd();
        }

        #region Subject

        private Subject<RoutedEventArgs> _subject;

        private void InitializeSubject()
        {
            _subject = new Subject<RoutedEventArgs>();

            _subject.Subscribe(Subject_Next);
        }

        private void Subject_Next(RoutedEventArgs e)
        {
            LogBox.Text += DateTime.Now.ToString("HH:mm:ss.fffffff") + " - Next Subject\r\n";
            LogBox.ScrollToEnd();
        }

        private void SubjectButton_Click(object sender, RoutedEventArgs e)
        {
            _subject.OnNext(e);
        }

        #endregion

        

        





    }
}
