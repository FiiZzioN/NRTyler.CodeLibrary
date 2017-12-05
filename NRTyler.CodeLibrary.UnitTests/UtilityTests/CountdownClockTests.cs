// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
// 
// Author           : Nicholas Tyler
// Created          : 12-04-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-04-2017
// 
// License          : MIT License
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.UnitTests.UtilityTests
{
    [TestClass]
    public class CountdownClockTests
    {
        [TestMethod]
        public void CountdownClock_MainTest()
        {
            // Instantiate clock.
            var countdownClock = new CountdownClock(10);

            // Get the expected amount of time the countdown will take.
            var expectedTime = ExpectedTime(countdownClock.StartingSeconds);

            // Start the clock.
            countdownClock.StartCountdown();

            // Assert if the total amount of seconds in the current time and the expected time are within a 
            // certain reasonable margin. Nothing like this will be 100% accurate, but we can be at least 99.9%.
            Assert.AreEqual(expectedTime.TotalSeconds, CurrentTime().TotalSeconds, 0.05);
        }


        /// <summary>
        /// Updates the current time of day.
        /// </summary>
        private TimeSpan CurrentTime()
        {
            return DateTime.Now.TimeOfDay;
        }

        /// <summary>
        /// Updates the current time of day that's one second ahead.
        /// </summary>
        /// <param name="seconds">The expected time.</param>
        private TimeSpan ExpectedTime(int seconds)
        {
            return CurrentTime().Add(new TimeSpan(0, 0, seconds));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CountdownClock_BadInput()
        {
            var countdownClock = new CountdownClock(0);
            countdownClock.StartCountdown();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CountdownClock_WrongConstructor()
        {
            var countdownClock = new CountdownClock();
            countdownClock.StartCountdown();
        }
    }
}