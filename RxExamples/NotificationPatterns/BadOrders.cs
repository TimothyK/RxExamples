using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxExamples.NotificationPatterns
{
    public partial class BadOrders : NotificationPattern
    {
        public BadOrders()
        {
            InitializeComponent();
            Height = tlpMain.Height;
        }

        public override string PatternName { get { return "2. Bad Orders (Buffer)"; } }

        private Subject<BadOrderException> _exceptionStream;

        private void btnRaise_Click(object sender, EventArgs e)
        {
            try
            {
                throw new BadOrderException(NextEventID());
            }
            catch (BadOrderException ex)
            {
                _exceptionStream.OnNext(ex);
            }
        }

        protected override IDisposable Subscribe()
        {
            _exceptionStream = new Subject<BadOrderException>();

            return _exceptionStream
                .Do(OnRawMessage)
                .Buffer(TimeSpanFactory.FromSeconds(2))
                .Where(g => g.Any())
                .ObserveOn(this)
                .Subscribe(g => OnNotificationMessage(BadOrderMessage(g)));
        }

        private static string BadOrderMessage(IList<BadOrderException> exceptions)
        {
            if (exceptions.Count() == 1)
                return exceptions.Single().Message;

            return "Bad Orders: " + string.Join(", ", exceptions.Select(ex => ex.OrderNumber.ToString()).ToArray());

        }
    }
}
