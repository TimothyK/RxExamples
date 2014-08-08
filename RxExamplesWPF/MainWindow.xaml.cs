using System;
using System.Collections.Generic;
using System.Linq;
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

            SubscribeToUnexpectedErrorStream();
            SubscribeToConnectionErrorStream();
            SubscribeToBadOrderStream();
        }

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
            txtRawLogBox.Text = string.Empty;
            txtAggregatedLogBox.Text = string.Empty;
        }

        #endregion

        #region Unexpected Error Notification

        private readonly Subject<Exception> _unexpectedErrorStream = new Subject<Exception>();
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
                .SampleResponsive(TimeSpan.FromSeconds(2))
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
                        g.SampleResponsive(TimeSpan.FromSeconds(2))
                            .ObserveOnDispatcher()
                            .Subscribe(ex => AddToAggLogBox(ex.Message)));
        }


        private void Timeout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                throw new TimeoutException("Timed out waiting for server " + System.Threading.Interlocked.Increment(ref _stamp));
            }
            catch (TimeoutException ex)
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

        private readonly Subject<Exception> _connectionErrorStream = new Subject<Exception>();

        private void SubscribeToConnectionErrorStream()
        {            
            _connectionErrorStream
                .Do(ex => IsConnected = false)
                .Do(ex => AddToRawLogBox(ex.Message))
                .Delay(TimeSpan.FromSeconds(3))
                .SampleResponsive(TimeSpan.FromSeconds(2))
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

        private readonly Subject<BadOrderException> _badOrderErrorStream = new Subject<BadOrderException>();

        private void SubscribeToBadOrderStream()
        {
            _badOrderErrorStream
                .Do(ex => AddToRawLogBox(ex.Message))
                .Buffer(TimeSpan.FromSeconds(2))
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
