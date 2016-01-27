using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private Time _currentTime = new Time(0,0,0);

        public string convertTime(string aTime)
        {
            ParseDate(aTime);

            string output = DrawClock();

            return output;
        }

        private void ParseDate(string aTime)
        {
            string[] timeValues = aTime.Split(':');

            if(timeValues == null || timeValues.Length != 3)
            {
                throw new ArgumentException("Unrecognized hour. Expected format: H:mm:ss");
            }

            int hours;
            if(!int.TryParse(timeValues[0], out hours))
            {
                throw new ArgumentException("Unrecognized hour. Hours value is incorrect");
            }

            int minutes;
            if (!int.TryParse(timeValues[1], out minutes))
            {
                throw new ArgumentException("Unrecognized hour. Minutes value is incorrect");
            }

            int seconds;
            if (!int.TryParse(timeValues[2], out seconds))
            {
                throw new ArgumentException("Unrecognized hour. Seconds value is incorrect");
            }

            _currentTime = new Time(hours, minutes, seconds);
        }

        private string DrawClock()
        {
            var clockRows = new StringBuilder();

            clockRows.AppendLine(DrawSeconds());
            clockRows.AppendLine(DrawHoursFirstLine());
            clockRows.AppendLine(DrawHoursSecondLine());
            clockRows.AppendLine(DrawMinutesFirstLine());
            clockRows.Append(DrawMinutesSecondLine());

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

        private string DrawHoursRow(int lightenedHours)
        {
            return DrawRow(lightenedHours, 'R');
        }

        private string DrawRow(int lightenedCount, char lightenedColour)
        {
            int notLightenedHours = 4 - lightenedCount;

            return String.Format("{0}{1}", new String(lightenedColour, lightenedCount), new String('O', notLightenedHours));
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

        private string DrawMinutesSecondLine()
        {
            int yellowMinutes = _currentTime.Minute % 5;

            return DrawMinutesRow(yellowMinutes);
        }

        private string DrawMinutesRow(int lightenedMinutes)
        {
            return DrawRow(lightenedMinutes, 'Y');
        }
    }
}
