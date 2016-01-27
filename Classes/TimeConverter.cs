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
            var berlinClock = new BerlinClockModel(_currentTime);

            clockRows.AppendLine(DrawSeconds(berlinClock.OnSecondLight));
            clockRows.AppendLine(DrawHoursFirstLine(berlinClock.OnHourFirstRowLights, berlinClock.OffHourFirstRowLights));
            clockRows.AppendLine(DrawHoursSecondLine(berlinClock.OnHourSecondRowLights, berlinClock.OffHourSecondRowLights));
            clockRows.AppendLine(DrawMinutesFirstLine(berlinClock.OnMinutesFirstRowLights, berlinClock.OffMinutesFirstRowLights));
            clockRows.Append(DrawMinutesSecondLine(berlinClock.OnMinutesSecondRowLights, berlinClock.OffMinutesSecondRowLights));

            return clockRows.ToString();
        }

        private string DrawSeconds(bool lightened)
        {
            return lightened ? "Y" : "O";
        }

        private string DrawHoursFirstLine(int lightenedHours, int notLightenedHours)
        {
            return DrawRow(lightenedHours, notLightenedHours, 'R');
        }

        private string DrawHoursSecondLine(int lightenedHours, int notLightenedHours)
        {
            return DrawRow(lightenedHours, notLightenedHours, 'R');
        }

        private string DrawMinutesFirstLine(int lightenedMinutes, int notLightenedMinutes)
        {
            var lightenedMinutesRow = new StringBuilder();
            for (int i = 1; i <= lightenedMinutes; i++)
            {
                lightenedMinutesRow.Append(i % 3 == 0 ? 'R' : 'Y');
            }

            return String.Format("{0}{1}", lightenedMinutesRow, new String('O', notLightenedMinutes));
        }

        private string DrawMinutesSecondLine(int yellowMinutes, int notLightenedMinutes)
        {
            return DrawRow(yellowMinutes, notLightenedMinutes, 'Y');
        }

        private string DrawRow(int lightenedCount, int notLightenedCount, char lightenedColour)
        {
            return String.Format("{0}{1}", new String(lightenedColour, lightenedCount), new String('O', notLightenedCount));
        }
    }
}
