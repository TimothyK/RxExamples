using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxExamples.NotificationPatterns
{
    public partial class UnexpectedErrorsSimple : NotificationPattern
    {
        public UnexpectedErrorsSimple()
        {
            InitializeComponent();
            Height = tlpMain.Height;
        }

        public override string PatternName { get { return "3. Unexpected Error (Sample)"; } }

        private Subject<NumberedException> _exceptionStream;

        private void btnRaise_Click(object sender, EventArgs e)
        {
            try
            {
                throw new NumberedException(NextEventID());
            }
            catch (NumberedException ex)
            {
                _exceptionStream.OnNext(ex);
            }

        }

        protected override IDisposable Subscribe()
        {
            _exceptionStream = new Subject<NumberedException>();

            return _exceptionStream
                .Do(OnRawMessage)
                .Sample(TimeSpanFactory.FromSeconds(2))
                .ObserveOn(this)
                .Subscribe(OnNotificationMessage);
        }


    }
}
