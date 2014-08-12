using System;

namespace RxExamples
{
    internal class NumberedException: Exception
    {
        public NumberedException(int id)
            : base("Exception " + id + " occurred")
        {
            ID = id;
        }

        public int ID { get; private set; }
       
    }
}