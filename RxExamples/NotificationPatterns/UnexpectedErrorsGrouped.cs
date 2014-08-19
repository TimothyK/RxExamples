using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxExamples.NotificationPatterns
{
    public partial class UnexpectedErrorsGrouped : NotificationPattern
    {
        public UnexpectedErrorsGrouped()
        {
            InitializeComponent();
            Height = tlpMain.Height;
        }

        public override string PatternName { get { return "5. Unexpected Error (GroupBy)"; } }

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

            var comparer = new ExceptionEqualityComparer();

            return _exceptionStream
                .Do(OnRawMessage)
                .GroupBy(ex => ex, comparer)
                .Subscribe(
                    streamOfGivenType =>
                        streamOfGivenType
                            .SampleResponsive(TimeSpanFactory.FromSeconds(2))
                            .ObserveOn(this)
                            .Subscribe(OnNotificationMessage));

        }

    }

    class ExceptionEqualityComparer : IEqualityComparer<Exception>
    {
        public bool Equals(Exception x, Exception y)
        {
            if ((x == null) && (y == null)) return true;
            if (x == null) return false;
            if (y == null) return false;

            if (x.GetType() != y.GetType())
                return false;

            if (x.StackTrace != y.StackTrace)
                return false;

            return Equals(x.InnerException, y.InnerException);
        }

        public int GetHashCode(Exception obj)
        {
            unchecked
            {
                return (obj.StackTrace.GetHashCode()*397 ^ obj.GetType().GetHashCode());
            }
        }
    }
}
