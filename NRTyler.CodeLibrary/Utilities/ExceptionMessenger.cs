// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-07-2017
//
// License          : MIT License
// ***********************************************************************

using System;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// Holds various methods and properties that help with logging an <see cref="Exception"/>.
    /// </summary>
    [Serializable]
    public static class ExceptionMessenger
    {
        /// <summary>
        /// Gets the outer <see cref="Exception"/> error message.
        /// </summary>
        public static string OuterMessage { get; private set; } = String.Empty;
        
        /// <summary>
        /// Gets the inner <see cref="Exception"/> error message.
        /// </summary>
        public static string InnerMessage { get; private set; } = String.Empty;

        /// <summary>
        /// Logs a user defined message.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void LogMessage(string message)
        {
            ResetMessageProperties();

            OuterMessage = message;
            Console.WriteLine(OuterMessage);
        }

        /// <summary>
        /// Logs nothing else except the outer and inner (if applicable) <see cref="Exception" /> error message(s), should either have one.
        /// Returns a <see cref="Tuple{T1, T2}"/> containing both the outer and inner error message(s), in that order.
        /// </summary>
        /// <param name="exception">The exception being analysed.</param>
        /// <returns>
        /// Returns a <see cref="Tuple{T1, T2}"/> containing both the outer and inner error messages, in that order.
        /// </returns>
        public static Tuple<string, string> LogMessage(this Exception exception)
        {
            ResetMessageProperties();

            // Outer exception.
            OuterMessage = exception.Message;
            Write($"Outer Message: {OuterMessage}");

            // Inner exception (if applicable).
            if (exception.InnerException != null)
            {
                InnerMessage = exception.InnerException.Message;
                Write($"Inner Message: {InnerMessage}");
            }

            return new Tuple<string, string>(OuterMessage, InnerMessage);
        }

        /// <summary>
        /// Logs all crucial outer and inner (if applicable) <see cref="Exception"/> information to the console and then returns the error message(s).
        /// Returns a <see cref="Tuple{T1, T2}"/> containing both the outer and inner error message(s), in that order.
        /// </summary>
        /// <param name="exception">The exception being analysed.</param>
        /// <param name="outerLabel">
        /// If modified, this labels the outer exception in the log for easier identification in the future.
        /// This can also be used to input a message should the user desire. If don't want a label applied, input null.
        /// </param>
        /// <param name="innerLabel">
        /// If modified, this labels the inner exception (if applicable) in the log for easier identification in the future.
        /// This can also be used to input a message should the user desire. If don't want a label applied, input null.</param>
        /// <returns>
        /// Returns a <see cref="Tuple{T1, T2}"/> containing both the outer and inner error messages, in that order.
        /// </returns>
        public static Tuple<string, string> LogExceptionInfo(this Exception exception, string outerLabel = "Outer Exception", string innerLabel = "Inner Exception")
        {
            ResetMessageProperties();

            // Handle the outer exception.
            OuterMessage = exception.FormatExceptionInfo(outerLabel);

            // Handle the Inner exception (if applicable).
            if (exception.InnerException != null)
            {
                InnerMessage = exception.InnerException.FormatExceptionInfo(innerLabel);
            }

            return new Tuple<string, string>(OuterMessage, InnerMessage);
        }

        /// <summary>
        /// Grabs a specified <see cref="Exception"/>'s crucial information, formats it, and then logs the information.
        /// </summary>
        /// <param name="exception">The exception being analysed.</param>
        /// <param name="exceptionLabel"> 
        /// If modified, this labels the exception in the log for easier identification in the future.
        /// This can also be used to input a message should the user desire. If ignored, no label gets applied.
        /// </param>
        /// <returns>The exception's error message.</returns>
        /// <remarks>Doesn't automatically reset the Outer and Inner properties. This will need to be taken care of.</remarks>
        private static string FormatExceptionInfo(this Exception exception, string exceptionLabel = null)
        {
            // Setup the exception message to return.
            var errorMessage = exception.Message;

            // If no custom exception label is specified, use this default one instead.
            if (!String.IsNullOrWhiteSpace(exceptionLabel))
            {
                Write($"ID: {exceptionLabel}");
            }

            Write($"Source: {exception.Source}");
            Write($"Message: {errorMessage}");
            Write($"Stack Trace: \n{exception.StackTrace}");

            if (!String.IsNullOrWhiteSpace(exception.HelpLink))
            {
                Write($"Help-Link: {exception.HelpLink}");
            }

            // Line break to provide better formatting.
            Write("");

            return errorMessage;
        }

        /// <summary>
        /// Writes the specified value to the console.
        /// </summary>
        /// <param name="value">The value to write to the console.</param>
        private static void Write(object value)
        {
            Console.WriteLine(value);
        }

        /// <summary>
        /// Resets the Outer and Inner properties to their default value. Doing this stops potential rage build-up if there's a 
        /// message present from an exception that happened long ago and isn't relevant to the issue you're trying to fix now.
        /// </summary>
        private static void ResetMessageProperties()
        {
            OuterMessage = String.Empty;
            InnerMessage = String.Empty;
        }
    }
}