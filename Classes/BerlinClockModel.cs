using System;

namespace BerlinClock.Classes
{
    public class BerlinClockModel
    {
        private Time _currentTime;

        public bool OnSecondLight { get; set; }

        public int OnHourFirstRowLights { get; private set; }

        public int OffHourFirstRowLights { get; private set; }

        public int OnHourSecondRowLights { get; private set; }

        public int OffHourSecondRowLights { get; private set; }

        public int OnMinutesFirstRowLights { get; private set; }

        public int OffMinutesFirstRowLights { get; private set; }

        public int OnMinutesSecondRowLights { get; private set; }

        public int OffMinutesSecondRowLights { get; private set; }

        public BerlinClockModel(Time time)
        {
            _currentTime = time;

            BuildClock();
        }

        private void BuildClock()
        {
            OnSecondLight = _currentTime.Second % 2 == 0;

            OnHourFirstRowLights = (int)Math.Floor((decimal)(_currentTime.Hour / 5));
            OffHourFirstRowLights = 4 - OnHourFirstRowLights;

            OnHourSecondRowLights = _currentTime.Hour % 5;
            OffHourSecondRowLights = 4 - OnHourSecondRowLights;

            OnMinutesFirstRowLights = (int)Math.Floor((decimal)(_currentTime.Minute / 5));
            OffMinutesFirstRowLights = 11 - OnMinutesFirstRowLights;

            OnMinutesSecondRowLights = _currentTime.Minute % 5;
            OffMinutesSecondRowLights = 4 - OnMinutesSecondRowLights;
        }
    }
}
