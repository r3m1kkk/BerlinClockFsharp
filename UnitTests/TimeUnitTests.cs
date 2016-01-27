using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BerlinClock.UnitTests
{
    [TestClass]
    public class TimeUnitTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_hour_is_negative()
        {
            //arrange
            var time = "-10:00:00";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_hour_is_not_integer()
        {
            //arrange
            var time = "a:0:00";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_hour_is_greater_than_24()
        {
            //arrange
            var time = "26:0:00";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_minute_is_negative()
        {
            //arrange
            var time = "10:-20:00";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_minute_is_not_integer()
        {
            //arrange
            var time = "10:z:00";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_minute_is_greater_than_59()
        {
            //arrange
            var time = "10:71:00";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_second_is_negative()
        {
            //arrange
            var time = "10:20:-20";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_second_is_not_integer()
        {
            //arrange
            var time = "10:20:z";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_second_is_greater_than_59()
        {
            //arrange
            var time = "10:20:71";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void is_exception_thrown_when_total_time_is_greater_than_24_0_0()
        {
            //arrange
            var time = "24:00:01";

            //act
            var parsedTime = Time.Parse(time);
        }

        [TestMethod]
        public void is_0_0_0_properly_parsed()
        {
            //arrange
            var time = "0:0:0";

            //act
            var parsedTime = Time.Parse(time);

            //assert
            Assert.AreEqual(0, parsedTime.Hour);
            Assert.AreEqual(0, parsedTime.Minute);
            Assert.AreEqual(0, parsedTime.Second);
        }

        [TestMethod]
        public void is_0_01_0_properly_parsed()
        {
            //arrange
            var time = "0:01:0";

            //act
            var parsedTime = Time.Parse(time);

            //assert
            Assert.AreEqual(0, parsedTime.Hour);
            Assert.AreEqual(1, parsedTime.Minute);
            Assert.AreEqual(0, parsedTime.Second);
        }

        [TestMethod]
        public void is_14_01_59_properly_parsed()
        {
            //arrange
            var time = "14:01:59";

            //act
            var parsedTime = Time.Parse(time);

            //assert
            Assert.AreEqual(14, parsedTime.Hour);
            Assert.AreEqual(1, parsedTime.Minute);
            Assert.AreEqual(59, parsedTime.Second);
        }

        [TestMethod]
        public void is_23_59_59_properly_parsed()
        {
            //arrange
            var time = "23:59:59";

            //act
            var parsedTime = Time.Parse(time);

            //assert
            Assert.AreEqual(23, parsedTime.Hour);
            Assert.AreEqual(59, parsedTime.Minute);
            Assert.AreEqual(59, parsedTime.Second);
        }


    }
}
