using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessObject.Helper
{
    public class Constantes
    {
        public const string Folder = @"D:\Test\";

        public static int TimeSpanToSecond(TimeSpan ts)
        {
            int secondsTotal = ts.Minutes * 60;
            secondsTotal += ts.Seconds;
            return secondsTotal;
        }
    }
}
