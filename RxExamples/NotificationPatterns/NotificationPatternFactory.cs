using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RxExamples.NotificationPatterns
{
    /// <summary>
    /// Factory for working with UserControls that implement the INotificationPattern interface (i.e. Notification Patterns)
    /// </summary>
    class NotificationPatternFactory
    {
        public string PatternName { get; private set; }
        private readonly Type _type;

        private NotificationPatternFactory(Type type)
        {
            _type = type;
            using (var instance = CreateInstance())
                PatternName = instance.PatternName;
        }

        /// <summary>
        /// Creates the Notificaton Pattern user control.  
        /// Note this object can be safely cast to a INotificationPattern.
        /// </summary>
        /// <returns></returns>
        public NotificationPattern CreateInstance()
        {
            return (NotificationPattern)Activator.CreateInstance(_type);
        }

        public static List<NotificationPatternFactory> All()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.IsSubclassOf(typeof(NotificationPattern)))
                .Select(t => new NotificationPatternFactory(t))
                .ToList();
        }
    }
}
