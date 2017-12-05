// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 10-21-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-04-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NRTyler.CodeLibrary.Annotations;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// An object that allows the user to instruct something to wait for a desired amount of time.
    /// </summary>
    public struct CountdownClock
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountdownClock"/> class.
        /// </summary>
        /// <param name="seconds">This determines how long the countdown will be.</param>
        public CountdownClock(int seconds) : this()
        {
            StartingSeconds  = seconds;
            RemainingSeconds = seconds;
            CurrentlyRunning = false;

            // See if the user's input is valid.
            CheckImproperSeconds();
        }

        #region Properties

        /// <summary>
        /// Gets the number of seconds that the countdown clock will run.
        /// </summary>
        public int StartingSeconds { get; }

        /// <summary>
        /// Gets or sets the number of seconds the clock has left until it stops.
        /// </summary>
        public int RemainingSeconds { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the countdown clock is running.
        /// </summary>
        public bool CurrentlyRunning { get; private set; }

        #endregion

        /// <summary>
        /// Starts the countdown clock.
        /// </summary>
        public void StartCountdown()
        {
            CheckImproperSeconds();
            SetCurrentlyRunning(true);

            // The current time, but set one second a head.
            var currentTimePlusOne = UpdateCurrentTimePlusOne();

            while (true)
            {
                // Grab the most recent time.
                var currentTime = UpdateCurrentTime();

                // If the current time is greater than or equal to the current plus one, then 
                // that means a second has passed. Otherwise, this will fall through.
                if (currentTime >= currentTimePlusOne)
                {
                    // Decrement the countdown length.
                    RemainingSeconds--;

                    // Update 'currentTimePlusOne' to the most recent value so the check will continue to work.
                    currentTimePlusOne = UpdateCurrentTimePlusOne();
                }

                // When we reach zero, break the loop (Ends the countdown).
                if (RemainingSeconds <= 0)
                {
                    // Call the 'CountdownCompleted' event.
                    OnCountdownCompleted();

                    // Show the clock isn't running anymore and reset the 'RemainingSeconds' should the
                    // user wish to restart the countdown.
                    SetCurrentlyRunning(false);
                    RemainingSeconds = StartingSeconds;
                    break;
                }
            }
        }

        #region Helper Methods

        /// <summary>
        /// Allows for a cleaner experience when setting the 'CurrentlyRunning' property.
        /// </summary>
        /// <param name="value">The boolean value indicating whether the clock is running or not.</param>
        private void SetCurrentlyRunning(bool value)
        {
            CurrentlyRunning = value;
        }

        /// <summary>
        /// Updates the current time of day.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> with the current time of day.</returns>
        private TimeSpan UpdateCurrentTime()
        {
            return DateTime.Now.TimeOfDay;
        }

        /// <summary>
        /// Updates the current time of day that's one second ahead.
        /// </summary>
        /// <returns>A <see cref="DateTime"/> with the current time of day that's one second ahead.</returns>
        private TimeSpan UpdateCurrentTimePlusOne()
        {
            return UpdateCurrentTime().Add(new TimeSpan(0, 0, 1));
        }

        /// <summary>
        /// Checks to see if the clock has the clock has the correct information for it to work properly.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The amount of seconds must be greater than zero.</exception>
        private void CheckImproperSeconds()
        {
            if (StartingSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(StartingSeconds)}", $"'{nameof(StartingSeconds)}' must be greater than zero for the countdown to work properly");
            }
            if (RemainingSeconds <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(RemainingSeconds)}", $"'{nameof(RemainingSeconds)}' must be greater than zero for the countdown to work properly");
            }
        }

        #endregion


        /// <summary>
        /// Occurs when the countdown is completed.
        /// </summary>
        public event EventHandler CountdownCompleted;

        /// <summary>
        /// Called when the countdown is completed.
        /// </summary>
        private void OnCountdownCompleted()
        {
            CountdownCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}