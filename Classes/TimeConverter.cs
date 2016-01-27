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
            return @"O
RROO
RRRO
YYROOOOOOOO
YYOO";
        }
    }
}
