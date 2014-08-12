using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxExamples.NotificationPatterns
{
    public partial class UnexpectedErrorsResponsive : NotificationPattern
    {
        public UnexpectedErrorsResponsive()
        {
            InitializeComponent();
            Height = tlpMain.Height;
        }

        public override string PatternName { get { return "4. Unexpected Error (SampleResponsive)"; } }

        private Subject<Exception> _exceptionStream;

        private void btnRaiseNullReference_Click(object sender, EventArgs e)
        {
            try
            {
                throw new NullReferenceException("The variable var" + NextEventID() + " cannot be null");
            }
            catch (NullReferenceException ex)
            {
                _exceptionStream.OnNext(ex);
            }
        }

        private void btnRaiseDivByZero_Click(object sender, EventArgs e)
        {
            try
            {
                throw new DivideByZeroException("Could not divide " + NextEventID() + " by zero");
            }
            catch (DivideByZeroException ex)
            {
                _exceptionStream.OnNext(ex);
            }
        }


        protected override IDisposable Subscribe()
        {
            _exceptionStream = new Subject<Exception>();

            return _exceptionStream
                .Do(OnRawMessage)
                .SampleResponsive(TimeSpanFactory.FromSeconds(2))
                .ObserveOn(this)
                .Subscribe(OnNotificationMessage);
        }

    }
}
