using System;

namespace RxExamplesWPF
{
    internal static class TimeSpanFactory
    {
        public static int Multiplier = 1;

        public static TimeSpan FromSeconds(int seconds)
        {
            return TimeSpan.FromSeconds(seconds*Multiplier);
        }
    }
}
