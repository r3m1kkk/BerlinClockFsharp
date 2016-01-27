using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public struct Time
    {
        public int Hour { get; set; }

        public int Minute { get; set; }

        public int Second { get; set; }

        public Time(int hours, int minutes, int seconds)
        {
            Hour = hours;
            Minute = minutes;
            Second = seconds;
        }

        public static Time Parse(string aTime)
        {
            string[] timeValues = aTime.Split(':');

            if (timeValues == null || timeValues.Length != 3)
            {
                throw new ArgumentException("Unrecognized hour. Expected format: H:mm:ss");
            }

            uint hours;
            if (!uint.TryParse(timeValues[0], out hours) || hours > 24)
            {
                throw new ArgumentException("Unrecognized hour. Hours value is incorrect");
            }

            uint minutes;
            if (!uint.TryParse(timeValues[1], out minutes) || minutes > 59)
            {
                throw new ArgumentException("Unrecognized hour. Minutes value is incorrect");
            }

            uint seconds;
            if (!uint.TryParse(timeValues[2], out seconds))
            {
                throw new ArgumentException("Unrecognized hour. Seconds value is incorrect");
            }

            return new Time((int)hours, (int)minutes, (int)seconds);
        }

        private static void ParseTimePart(string valueToParse, out int valueToSet)
        {
            if (!int.TryParse(valueToParse, out valueToSet))
            {
                throw new ArgumentException("Unrecognized hour. Hours value is incorrect");
            }
        }
    }
}
