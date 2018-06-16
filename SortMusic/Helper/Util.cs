using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public class Util
    {
        public static int TimeSpanToSecond(TimeSpan ts)
        {
            int secondsTotal = ts.Minutes * 60;
            secondsTotal += ts.Seconds;
            return secondsTotal;
        }
    }
}
