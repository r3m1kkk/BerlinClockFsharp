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
            ParseDate(aTime);

            string output = DrawClock();

            return output;
        }

        private void ParseDate(string aTime)
        {
            if (!DateTime.TryParse(aTime, out _currentTime))
            {
                throw new ArgumentException("Unrecognized hour");
            }
        }

        private string DrawClock()
        {
            var clockRows = new StringBuilder();

            clockRows.AppendLine(DrawSeconds());
            clockRows.AppendLine(DrawHoursFirstLine());
            clockRows.AppendLine(DrawHoursSecondLine());
            clockRows.Append(@"YYROOOOOOOO
YYOO");

            return clockRows.ToString();
        }

        private string DrawSeconds()
        {
            return _currentTime.Second % 2 == 0 ? "Y" : "O";
        }

        private string DrawHoursFirstLine()
        {
            var lightenedHours = (int)Math.Floor((decimal)(_currentTime.Hour / 5));
            int notLightenedHours = 4 - lightenedHours;
            
            return String.Format("{0}{1}", new String('R', lightenedHours), new String('O', notLightenedHours));
        }

        private string DrawHoursSecondLine()
        {
            var lightenedHours = _currentTime.Hour % 5;
            int notLightenedHours = 4 - lightenedHours;

            return String.Format("{0}{1}", new String('R', lightenedHours), new String('O', notLightenedHours));
        }
    }
}
