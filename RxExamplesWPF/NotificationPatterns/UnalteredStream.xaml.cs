using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows;
using System.Windows.Controls;

namespace RxExamplesWPF.NotificationPatterns
{
    /// <summary>
    /// Interaction logic for UnalteredStream.xaml
    /// </summary>
    public partial class UnalteredStream : UserControl, INotificationPattern
    {
        public UnalteredStream()
        {
            InitializeComponent();
        }

        private void Raise_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new NumberedException();
            }
            catch (NumberedException ex)
            {
                _exceptionStream.OnNext(ex);
            }
        }

        private Subject<NumberedException> _exceptionStream;
        private IDisposable _subscription;

        public void Subscribe()
        {
            if (_subscription != null)
                Unsubscribe();

            _exceptionStream = new Subject<NumberedException>();

            _subscription = _exceptionStream
                .Do(OnRawMessage)

                ////Manipulate event stream 
                //.Where(ex => ex.ID % 2 == 0)
                //.Delay(TimeSpanFactory.FromSeconds(2))
                //.ObserveOnDispatcher()

                .Subscribe(OnNotificationMessage);
        }


        public void Unsubscribe()
        {
            //Flush the exception stream
            if (_exceptionStream != null)
                _exceptionStream.OnCompleted();
            _exceptionStream = null;

            //Unsubscribe
            if (_subscription != null)
                _subscription.Dispose();
            _subscription = null;
        }

        public void Flush()
        {
            Unsubscribe();
            Subscribe();
        }

        public event NotificationMessageEventHandler RawMessage;

        private void OnRawMessage(Exception ex)
        {
            if (RawMessage != null)
                RawMessage(ex.Message);
        }

        public event NotificationMessageEventHandler NotificationMessage;

        private void OnNotificationMessage(Exception ex)
        {
            if (NotificationMessage != null)
                NotificationMessage(ex.Message);
        }
    }
}
