using System;
using System.Windows.Forms;

namespace RxExamples.NotificationPatterns
{
    public delegate void NotificationMessageEventHandler(string message);
  
    public partial class NotificationPattern : UserControl
    {
        protected NotificationPattern()
        {
            InitializeComponent();
        }

        public virtual string PatternName
        {
            get { return GetType().Name; }
        }

        #region Events

        public event NotificationMessageEventHandler RawMessage;

        protected void OnRawMessage(string message)
        {
            if (RawMessage != null)
                RawMessage(message);
        }
        protected void OnRawMessage(Exception ex)
        {
            OnRawMessage(ex.Message);
        }

        public event NotificationMessageEventHandler NotificationMessage;

        protected void OnNotificationMessage(string message)
        {
            if (NotificationMessage != null)
                NotificationMessage(message);
        }
        protected void OnNotificationMessage(Exception ex)
        {
            OnNotificationMessage(ex.Message);
        }

        #endregion

        #region Subscription Management

        protected virtual IDisposable Subscribe()
        {
            return null;
        }

        private IDisposable _subscription;

        private void NotificationPattern_Load(object sender, EventArgs e)
        {
            _subscription = Subscribe();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                Unsubscribe();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Unsubscribe()
        {
            if (_subscription != null)
                _subscription.Dispose();
            _subscription = null;
        }

        #endregion

        #region Event Identifier Sequence

        private int _sequence;

        protected int NextEventID()
        {
            return ++_sequence;
        }

        #endregion

    }

}
