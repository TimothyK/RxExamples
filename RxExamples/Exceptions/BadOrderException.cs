using System;

namespace RxExamples
{
    internal class BadOrderException : Exception
    {
        public BadOrderException(int orderNumber)
            : base("Bad Order #" + orderNumber)
        {
            OrderNumber = orderNumber;
        }

        public int OrderNumber { get; private set; }
    }
}