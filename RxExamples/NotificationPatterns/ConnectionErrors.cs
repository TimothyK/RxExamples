using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Windows.Forms;

namespace RxExamples.NotificationPatterns
{
    public partial class ConnectionErrors : NotificationPattern
    {
        public ConnectionErrors()
        {
            InitializeComponent();
            Height = tlpMain.Height;
        }

        public override string PatternName { get { return "6. Connection Errors (State Aware)"; } }

        private Subject<Exception> _exceptionStream;

        private void btnRaiseConnectionError_Click(object sender, EventArgs e)
        {
            try
            {
                throw new TimeoutException("Couldn't connect to server " + NextEventID());
            }
            catch (TimeoutException ex)
            {
                _exceptionStream.OnNext(ex);
            }     
        }

        private void btnSuccessfulConnection_Click(object sender, EventArgs e)
        {
            IsConnected = true;
        }

        protected override IDisposable Subscribe()
        {
            _exceptionStream = new Subject<Exception>();

            return _exceptionStream
                .Do(OnRawMessage)
                .Do(ex => IsConnected = false)
                .Delay(TimeSpanFactory.FromSeconds(3))
                .SampleResponsive(TimeSpanFactory.FromSeconds(2))
                .Where(ex => !IsConnected)
                .ObserveOn(this)
                .Subscribe(OnNotificationMessage);
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
                OnRawMessage("Connection State transitioning to " + (value ? "good" : "disconnected"));
            }
        }


    }
}
