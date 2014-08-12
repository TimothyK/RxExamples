using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RxExamplesWPF.NotificationPatterns
{
    public delegate void NotificationMessageEventHandler(string message);

    interface INotificationPattern
    {
        event NotificationMessageEventHandler RawMessage;

        event NotificationMessageEventHandler NotificationMessage;

        void Subscribe();
        void Unsubscribe();
        void Flush();

        
    }
}
