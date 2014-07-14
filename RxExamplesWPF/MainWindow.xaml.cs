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
            AddToLogBox("Click");
        }

        #region Subject

        private Subject<RoutedEventArgs> _subject;

        private void InitializeSubject()
        {
            _subject = new Subject<RoutedEventArgs>();

            _subject
                .Select(e => "Subject Next")
                .Subscribe(AddToLogBox);
        }

        private void SubjectButton_Click(object sender, RoutedEventArgs e)
        {
            _subject.OnNext(e);
        }

        #endregion

        private void AddToLogBox(string source)
        {
            LogBox.Text += DateTime.Now.ToString("HH:mm:ss.fffffff") + " - " + source + "\r\n";
            LogBox.ScrollToEnd();
        }
        

        





    }
}
