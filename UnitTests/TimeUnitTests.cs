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

    }
}
