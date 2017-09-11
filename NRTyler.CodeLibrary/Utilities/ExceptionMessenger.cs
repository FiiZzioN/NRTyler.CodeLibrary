// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-01-2017
//
// License          : GNU General Public License v3.0
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
            Console.WriteLine();
            OuterMessage = message;
        }

        /// <summary>
        /// Logs both the outer and inner (if applicable) <see cref="Exception" /> error messages, should either have one.
        /// </summary>
        /// <param name="exception">The exception being analysed.</param>
        /// <returns>
        /// Returns a <see cref="Tuple{T1, T2}"/> containing both the outer and inner error messages, in that order.
        /// </returns>
        public static Tuple<string, string> LogErrorMessage(this Exception exception)
        {
            // Outer exception.
            OuterMessage = exception.Message;
            Console.WriteLine(OuterMessage);

            // Inner exception (if applicable).
            if (exception.InnerException != null)
            {
                InnerMessage = exception.InnerException.Message;
                Console.WriteLine(InnerMessage);
            }

            return new Tuple<string, string>(OuterMessage, InnerMessage);
        }

        /// <summary>
        /// Logs all crucial <see cref="Exception"/> information to the console and returns the error message.
        /// </summary>
        /// <param name="exception">The exception being analysed.</param>
        /// <param name="exceptionLabel"> 
        /// If modified, this labels the exception in the log for easier identification in the future.
        /// This can also be used to input a message should the user desire. If ignored, no label gets applied.
        /// </param>
        /// <returns>The exception's error message.</returns>
        public static string LogExceptionInfo(this Exception exception, string exceptionLabel = null)
        {
            // Log outer info exception message.
            OuterMessage = exception.Message;

            if (!String.IsNullOrWhiteSpace(exceptionLabel))
            {
                Write($"ID: {exceptionLabel}");
            }

            Write($"Source: {exception.Source}");
            Write($"Message: {OuterMessage}");
            Write($"Stack Trace: \n{FormatStackTrace()}");

            if (!String.IsNullOrWhiteSpace(exception.HelpLink))
            {
                Write($"Help-Link: {exception.HelpLink}");
            }

            // Line break to provide better formatting.
            Write("");

            return OuterMessage;

            #region Local Method // Local method to format the StackTrace how I want for this function only.

            string FormatStackTrace()
            {
                var stackTrace = exception.StackTrace;
                var formatedStackTrace = stackTrace.Replace("at", "    at");

                return formatedStackTrace;
            }

            #endregion
        }

        /// <summary>
        /// Logs all crucial outer and inner (if applicable) <see cref="Exception"/> information to the console and returns the error message.
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
        /// Returns a <see cref="Tuple{T1, T2}"/> containing 
        /// both the outer and inner error messages, in that order.
        /// </returns>
        public static Tuple<string, string> LogCompleteExceptionInfo(this Exception exception, string outerLabel = "Outer Exception", string innerLabel = "Inner Exception")
        {
            OuterMessage = exception.LogExceptionInfo(outerLabel);

            // Inner exception (if applicable).
            if (exception.InnerException != null)
            {
                InnerMessage = exception.InnerException.LogExceptionInfo(innerLabel);
            }

            return new Tuple<string, string>(OuterMessage, InnerMessage);
        }

        /// <summary>
        /// Writes the specified value to the console.
        /// </summary>
        /// <param name="value">The value to write to the console.</param>
        private static void Write(object value)
        {
            Console.WriteLine(value);
        }
    }
}