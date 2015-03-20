using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly int miles = 150;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(new DateTime(2015, 2, 20), new DateTime(2015, 4, 30), miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTheFlightLeavingTheSameDay()
        {
            var target = new Flight(new DateTime(2015, 2, 20), new DateTime(2015, 2, 20), miles);
            Assert.AreEqual(200, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTheFlightLeavingNextDay()
        {
            var target = new Flight(new DateTime(2015, 2, 20), new DateTime(2015, 2, 21), miles);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTheFlightLeavingTenDaysAfter()
        {
            var target = new Flight(new DateTime(2015, 2, 20), new DateTime(2015, 3, 2), miles);
            Assert.AreEqual(400, target.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnEndDateBeforeLeaveDate()
        {
            new Flight(new DateTime(2015, 2, 20), new DateTime(2015, 2, 2), miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnNegativeMiles()
        {
            new Flight(new DateTime(2015, 2, 20), new DateTime(2015, 2, 23), -100);
        }
	}
}
