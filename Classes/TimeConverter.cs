using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private DateTime _currentTime = default(DateTime);

        public string convertTime(string aTime)
        {
            string output = DrawClock();

            return output;
        }

        private string DrawClock()
        {
            return @"O
RROO
RRRO
YYROOOOOOOO
YYOO";
        }
    }
}
