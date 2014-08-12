using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows.Forms;

namespace RxExamples.NotificationPatterns
{
    public partial class UnalteredStream : NotificationPattern
    {
        public UnalteredStream()
        {
            InitializeComponent();
            Height = tlpMain.Height;
        }

        public override string PatternName { get { return "1. Unaltered Stream (Template)"; } }

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

                ////Manipulate event stream 
                //.Where(ex => ex.ID % 2 == 1)
                //.Delay(TimeSpanFactory.FromSeconds(2))
                //.ObserveOn(this)
                
                .Subscribe(OnNotificationMessage);
        }
        
    }
}
