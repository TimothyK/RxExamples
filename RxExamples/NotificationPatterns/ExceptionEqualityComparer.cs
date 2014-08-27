using System;
using System.Collections.Generic;

namespace RxExamples.NotificationPatterns
{
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