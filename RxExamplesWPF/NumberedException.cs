using System;

namespace RxExamplesWPF
{
    /// <summary>
    /// Exception class with an automatically assigned unique ID
    /// </summary>
    class NumberedException : Exception
    {
        public int ID { get; private set; }
        private static int IdSequence;

        public NumberedException() : this(++IdSequence)
        {
        }

        private NumberedException(int id) : base("Exception " + id + " occurred")
        {
            ID = id;
        }
    }
}