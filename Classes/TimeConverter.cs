using BerlinClock.Classes;
using System;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private Time _currentTime = new Time(0,0,0);

        public string convertTime(string aTime)
        {
            _currentTime = Time.Parse(aTime);

            string output = DrawClock();

            return output;
        }

        private string DrawClock()
        {
            var clockRows = new StringBuilder();

            bool evenSecond = _currentTime.Second % 2 == 0;
            clockRows.AppendLine(DrawSeconds(evenSecond));

            int onHour5Lights = (int)Math.Floor((decimal)(_currentTime.Hour / 5));
            int offHour5Lights = 4 - onHour5Lights;
            clockRows.AppendLine(DrawHoursFirstLine(onHour5Lights, offHour5Lights));

            int onHour1Lights = _currentTime.Hour % 5;
            int offHour1Lights = 4 - onHour1Lights;
            clockRows.AppendLine(DrawHoursSecondLine(onHour1Lights, offHour1Lights));

            int onMinutes5Lights = (int)Math.Floor((decimal)(_currentTime.Minute / 5));
            int offMinutes5Lights = 11 - onMinutes5Lights;
            clockRows.AppendLine(DrawMinutesFirstLine(onMinutes5Lights, offMinutes5Lights));

            int onMinutes1Lights = _currentTime.Minute % 5;
            int offMinutes1Lights = 4 - onMinutes1Lights;
            clockRows.Append(DrawMinutesSecondLine(onMinutes1Lights, offMinutes1Lights));

            return clockRows.ToString();
        }

        private string DrawSeconds(bool even)
        {
            return even ? "Y" : "O";
        }

        private string DrawHoursFirstLine(int lightenedHours, int notLightenedHours)
        {
            return DrawHoursRow(lightenedHours, notLightenedHours);
        }

        private string DrawHoursRow(int lightenedHours, int notLightenedHours)
        {
            return DrawRow(lightenedHours, notLightenedHours, 'R');
        }

        private string DrawRow(int lightenedCount, int notLightenedCount, char lightenedColour)
        {
            return String.Format("{0}{1}", new String(lightenedColour, lightenedCount), new String('O', notLightenedCount));
        }

        private string DrawHoursSecondLine(int lightenedHours, int notLightenedHours)
        {
            return DrawHoursRow(lightenedHours, notLightenedHours);
        }

        private string DrawMinutesFirstLine(int yellowMinutes, int orangeMinutes)
        {
            var lightenedMinutes = new StringBuilder();
            for (int i = 1; i <= yellowMinutes; i++)
            {
                lightenedMinutes.Append(i % 3 == 0 ? 'R' : 'Y');
            }

            return String.Format("{0}{1}", lightenedMinutes, new String('O', orangeMinutes));
        }

        private string DrawMinutesSecondLine(int yellowMinutes, int notLightenedMinutes)
        {
            return DrawMinutesRow(yellowMinutes, notLightenedMinutes);
        }

        private string DrawMinutesRow(int lightenedMinutes, int notLightenedMinutes)
        {
            return DrawRow(lightenedMinutes, notLightenedMinutes, 'Y');
        }
    }
}
