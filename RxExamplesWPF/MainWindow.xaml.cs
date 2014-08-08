using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography.X509Certificates;
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

            SubscribeToAll();
        }

        #region Subscription Management

        private void SubscribeToAll()
        {
            SubscribeToUnexpectedErrorStream();
            SubscribeToConnectionErrorStream();
            SubscribeToBadOrderStream();
        }

        private void chkDelayTimesTen_OnChecked(object sender, RoutedEventArgs e)
        {
            Flush();
        }

        TimeSpan Interval(int valueInSeconds)
        {
            if (chkDelayTimesTen.IsChecked.GetValueOrDefault())
                valueInSeconds = valueInSeconds*10;
            return TimeSpan.FromSeconds(valueInSeconds);
        }

        private void btnFlush_Click(object sender, RoutedEventArgs e)
        {
            Flush();
        }

        private void Flush()
        {
            _unexpectedErrorStream.OnCompleted();
            _connectionErrorStream.OnCompleted();
            _badOrderErrorStream.OnCompleted();

            _unexpectedErrorStream = new Subject<Exception>();
            _connectionErrorStream = new Subject<Exception>();
            _badOrderErrorStream = new Subject<BadOrderException>();

            SubscribeToAll();
        }

        #endregion

        #region Logging

        private long _stamp;

        private void AddToRawLogBox(string source)
        {
            txtRawLogBox.Text += DateTime.Now.ToString("HH:mm:ss.fffffff") + " - " + source + "\r\n";
            txtRawLogBox.ScrollToEnd();
        }

        private void AddToAggLogBox(string source)
        {
            txtAggregatedLogBox.Text += DateTime.Now.ToString("HH:mm:ss.fffffff") + " - " + source + "\r\n";
            txtAggregatedLogBox.ScrollToEnd();
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Flush();
            _stamp = 0;
            txtRawLogBox.Text = string.Empty;
            txtAggregatedLogBox.Text = string.Empty;
        }

        #endregion

        #region Unexpected Error Notification

        private Subject<Exception> _unexpectedErrorStream = new Subject<Exception>();
        private IDisposable _unexpectedErrorSubscription;

        private void GroupOnErrorType_Checked(object sender, RoutedEventArgs e)
        {
            SubscribeToUnexpectedErrorStream();
        }

        private void SubscribeToUnexpectedErrorStream()
        {
            if (_unexpectedErrorSubscription != null) 
                _unexpectedErrorSubscription.Dispose();

            if (chkGroupByType.IsChecked.GetValueOrDefault())
                SubscribeToUnexpectedErrorStreamWithGrouping();
            else
                SubscribeToUnexpectedErrorStreamWithoutGrouping();
        }

        private void SubscribeToUnexpectedErrorStreamWithoutGrouping()
        {
            _unexpectedErrorSubscription = _unexpectedErrorStream
                .Do(ex => AddToRawLogBox(ex.Message))
                .SampleResponsive(Interval(2))
                .ObserveOnDispatcher()
                .Subscribe(ex => AddToAggLogBox(ex.Message));
        }


        private void SubscribeToUnexpectedErrorStreamWithGrouping()
        {
            _unexpectedErrorSubscription = _unexpectedErrorStream
                .Do(ex => AddToRawLogBox(ex.Message))
                .GroupBy(ex => new {Type = ex.GetType(), ex.StackTrace})
                .Subscribe(
                    g =>
                        g.SampleResponsive(Interval(2))
                            .ObserveOnDispatcher()
                            .Subscribe(ex => AddToAggLogBox(ex.Message)));
        }


        private void NullRef_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new NullReferenceException("Variable var" + System.Threading.Interlocked.Increment(ref _stamp) + " cannot be null");
            }
            catch (NullReferenceException ex)
            {
                _unexpectedErrorStream.OnNext(ex);
            }            
        }

        private void DivZero_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new DivideByZeroException("Couldn't divide " +
                                                + System.Threading.Interlocked.Increment(ref _stamp) + " by zero");
            }
            catch (DivideByZeroException ex)
            {
                _unexpectedErrorStream.OnNext(ex);
            }
        }

        #endregion

        #region Connection Error Notifications

        private Subject<Exception> _connectionErrorStream = new Subject<Exception>();

        private void SubscribeToConnectionErrorStream()
        {
            _connectionErrorStream
                .Do(ex => IsConnected = false)
                .Do(ex => AddToRawLogBox(ex.Message))
                .Delay(Interval(3))
                .SampleResponsive(Interval(2))
                .Where(ex => !IsConnected)
                .ObserveOnDispatcher()
                .Subscribe(ex => AddToAggLogBox(ex.Message));
        }

        private bool _isConnected;

        private bool IsConnected
        {
            get { return _isConnected; }
            set
            {
                if (_isConnected == value) 
                    return;

                _isConnected = value;
                AddToRawLogBox("Connection State transitioning to " + (value ? "good" : "disconnected"));
            }
        }

        private void ConnectionError_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new TimeoutException("Couldn't connect to server " + System.Threading.Interlocked.Increment(ref _stamp));
            }
            catch (TimeoutException ex)
            {
                _connectionErrorStream.OnNext(ex);
            }            
        }

        private void ConnectionSuccess_OnClick(object sender, RoutedEventArgs e)
        {
            IsConnected = true;
        }

        #endregion

        #region Bad Order Notifications

        private Subject<BadOrderException> _badOrderErrorStream = new Subject<BadOrderException>();

        private void SubscribeToBadOrderStream()
        {
            _badOrderErrorStream
                .Do(ex => AddToRawLogBox(ex.Message))
                .Buffer(Interval(2))
                .Where(g => g.Any())
                .ObserveOnDispatcher()
                .Subscribe(g => AddToAggLogBox(BadOrdersMessage(g)));
        }

        private string BadOrdersMessage(IList<BadOrderException> exceptions)
        {
            if (exceptions.Count() == 1)
                return exceptions.Single().Message;

            return "Bad Orders: " + string.Join(", ", exceptions.Select(ex => ex.OrderNumber.ToString()).ToArray());
        }

        private void BadOrder_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new BadOrderException(System.Threading.Interlocked.Increment(ref _stamp));
            }
            catch (BadOrderException ex)
            {
                _badOrderErrorStream.OnNext(ex);
            }
        }

        private class BadOrderException : Exception
        {
            public readonly long OrderNumber;

            public BadOrderException(long orderNumber) : base("Bad Order #" + orderNumber)
            {
                OrderNumber = orderNumber;
            }
        }

        #endregion
    }
}
