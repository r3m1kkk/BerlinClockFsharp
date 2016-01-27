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
            clockRows.AppendLine(DrawMinutesFirstLine());
            clockRows.Append(@"YYOO");

            return clockRows.ToString();
        }

        private string DrawSeconds()
        {
            return _currentTime.Second % 2 == 0 ? "Y" : "O";
        }

        private string DrawHoursFirstLine()
        {
            var lightenedHours = (int)Math.Floor((decimal)(_currentTime.Hour / 5));
            
            return DrawHoursRow(lightenedHours);
        }

        private string DrawHoursSecondLine()
        {
            var lightenedHours = _currentTime.Hour % 5;

            return DrawHoursRow(lightenedHours);
        }

        private string DrawMinutesFirstLine()
        {
            int yellowMinutes = (int)Math.Floor((decimal)(_currentTime.Minute / 5));
            int orangeMinutes = 11 - yellowMinutes;

            var lightenedMinutes = new StringBuilder();
            for (int i = 1; i <= yellowMinutes; i++)
            {
                lightenedMinutes.Append(i % 3 == 0 ? 'R' : 'Y');
            }

            return String.Format("{0}{1}", lightenedMinutes, new String('O', orangeMinutes));
        }

        private string DrawHoursRow(int lightenedHours)
        {
            int notLightenedHours = 4 - lightenedHours;

            return String.Format("{0}{1}", new String('R', lightenedHours), new String('O', notLightenedHours));
        }
    }
}
