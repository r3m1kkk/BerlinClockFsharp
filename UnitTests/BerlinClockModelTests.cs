using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class BerlinClockModelTests
    {

        [TestMethod]
        public void has_berlin_clock_second_light_off_at_23_59_59()
        {
            //arrange
            Time time = new Time(23, 59, 59);

            //act
            var clock = new BerlinClockModel(time);

            //assert
            Assert.IsFalse(clock.OnSecondLight);
        }

        [TestMethod]
        public void has_berlin_clock_second_light_on_at_23_59_58()
        {
            //arrange
            Time time = new Time(23, 59, 59);

            //act
            var clock = new BerlinClockModel(time);

            //assert
            Assert.IsFalse(clock.OnSecondLight);
        }

        [TestMethod]
        public void has_berlin_clock_4_and_3_hour_lights_on_at_23_59_59()
        {
            //arrange
            Time time = new Time(23, 59, 59);

            //act
            var clock = new BerlinClockModel(time);

            //assert
            Assert.AreEqual(4, clock.OnHourFirstRowLights);
            Assert.AreEqual(0, clock.OffHourFirstRowLights);
            Assert.AreEqual(3, clock.OnHourSecondRowLights);
            Assert.AreEqual(1, clock.OffHourSecondRowLights);
        }

        [TestMethod]
        public void has_berlin_clock_2_and_1_hour_lights_on_at_12_31_59()
        {
            //arrange
            Time time = new Time(12, 31, 59);

            //act
            var clock = new BerlinClockModel(time);

            //assert
            Assert.AreEqual(2, clock.OnHourFirstRowLights);
            Assert.AreEqual(2, clock.OffHourFirstRowLights);
            Assert.AreEqual(2, clock.OnHourSecondRowLights);
            Assert.AreEqual(2, clock.OffHourSecondRowLights);
        }

        [TestMethod]
        public void has_berlin_clock_4_and_4_minutes_lights_on_at_10_24_59()
        {
            //arrange
            Time time = new Time(10, 24, 59);

            //act
            var clock = new BerlinClockModel(time);

            //assert
            Assert.AreEqual(4, clock.OnMinutesFirstRowLights);
            Assert.AreEqual(7, clock.OffMinutesFirstRowLights);
            Assert.AreEqual(4, clock.OnMinutesSecondRowLights);
            Assert.AreEqual(0, clock.OffMinutesSecondRowLights);
        }

        [TestMethod]
        public void has_berlin_clock_0_and_0_minutes_lights_on_at_10_00_00()
        {
            //arrange
            Time time = new Time(10, 0, 0);

            //act
            var clock = new BerlinClockModel(time);

            //assert
            Assert.AreEqual(0, clock.OnMinutesFirstRowLights);
            Assert.AreEqual(11, clock.OffMinutesFirstRowLights);
            Assert.AreEqual(0, clock.OnMinutesSecondRowLights);
            Assert.AreEqual(4, clock.OffMinutesSecondRowLights);
        }

    }
}
