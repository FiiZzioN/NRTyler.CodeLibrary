// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 09-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 05-21-2018
//
// License          : MIT License
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Windows.Forms;
using NRTyler.CodeLibrary.Enums;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// Holds various methods and properties that help with logging an <see cref="Exception"/>.
    /// </summary>
    [Serializable]
    [Obsolete]
    public static class ExceptionMessenger
    {
        /* Needs a lot of work
        
        /// <summary>
        /// Gets or sets the message that will be in the <see cref="MessageBox"/>.
        /// </summary>
        private static string Message { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the caption of the <see cref="MessageBox"/>.
        /// </summary>
        private static string Caption { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the icon of the <see cref="MessageBox"/>.
        /// </summary>
        private static MessageBoxIcon Icon { get; set; } = MessageBoxIcon.Error;

        /// <summary>
        /// Gets or sets the buttons that will be in the <see cref="MessageBox"/>.
        /// </summary>
        private static MessageBoxButtons Buttons { get; set; } = MessageBoxButtons.OK;

        /// <summary>
        /// Gets or sets the result from the <see cref="MessageBox"/>.
        /// </summary>
        private static DialogResult Result { get; set; } = DialogResult.OK;

        /// <summary>
        /// Gets the outer <see cref="Exception"/> error message.
        /// </summary>
        private static string OuterExceptionMessage { get; set; } = String.Empty;

        /// <summary>
        /// Gets the inner <see cref="Exception"/> error message.
        /// </summary>
        private static string InnerExceptionMessage { get; set; } = String.Empty;



        /// <summary>
        /// Shows the exception message box.
        /// </summary>
        /// <param name="exception">The exception that this method gathers its information from.</param>
        /// <param name="messageType">Type of the message.</param>
        /// <exception cref="InvalidEnumArgumentException">An unaccounted <see cref="ExceptionMessageType"/> was entered.</exception>
        public static void ShowExceptionMessageBox(this Exception exception, ExceptionMessageType messageType)
        {
            switch (messageType)
            {
                case ExceptionMessageType.Basic:
                    exception.ShowBasicInfo();
                    break;
                case ExceptionMessageType.Advanced:
                    exception.ShowAdvancedInfo();
                    break;
                case ExceptionMessageType.Complete:
                    exception.ShowCompleteInfo();
                    break;  
                default:
                    ShowSwitchErrorMessage();
                    break;
            }
        }

        /// <summary>
        /// Shows the basic information.
        /// </summary>
        /// <param name="exception">The exception that this method gathers its information from.</param>
        private static void ShowBasicInfo(this Exception exception)
        {
            exception.GetExceptionMessages();
        }

        /// <summary>
        /// Shows the advanced information.
        /// </summary>
        /// <param name="exception">The exception that this method gathers its information from.</param>
        private static void ShowAdvancedInfo(this Exception exception)
        {
            exception.GetExceptionMessages();
        }

        /// <summary>
        /// Shows the complete information.
        /// </summary>
        /// <param name="exception">The exception that this method gathers its information from.</param>
        private static void ShowCompleteInfo(this Exception exception)
        {
            exception.GetExceptionMessages();
        }

        /// <summary>
        /// The <see cref="MessageBox" /> that will appear should the user somehow enter in an unaccounted for <see cref="ExceptionMessageType" />.
        /// </summary>
        /// <exception cref="InvalidEnumArgumentException">An unaccounted <see cref="ExceptionMessageType"/> was entered.</exception>
        private static void ShowSwitchErrorMessage()
        {
            Caption = $"Invalid {nameof(ExceptionMessageType)}";
            Message = $"You entered in an unaccounted {nameof(ExceptionMessageType)}.@I suggest not doing that again.";
            Message = Message.NewLineAfterCharacter();
            Result  = MessageBox.Show(Message, Caption, Buttons, Icon);

            if (Result == DialogResult.OK)
            {
                throw new InvalidEnumArgumentException($"An unaccounted {nameof(ExceptionMessageType)} was entered.");
            }
        }















        private static void GetExceptionMessages(this Exception exception)
        {
            OuterExceptionMessage = exception.Message;

            if (exception.InnerException != null)
            {
                InnerExceptionMessage = exception.InnerException.Message;
            }
        }

        private static void GetAdvancedInfo(this Exception exception)
        {

        }



        /// <summary>
        /// Grabs a specified <see cref="Exception"/>'s crucial information, formats it, and then logs the information.
        /// </summary>
        /// <param name="exception">The exception being analysed.</param>
        /// <param name="nameOfException"> 
        /// If modified, this labels the exception in the log for easier identification in the future.
        /// This can also be used to input a message should the user desire. If ignored, no label gets applied.
        /// </param>
        /// <returns>The exception's error message.</returns>
        /// <remarks>Doesn't automatically reset the Outer and Inner properties. This will need to be taken care of.</remarks>
        private static string GetCompleteInfo(this Exception exception, string nameOfException = null)
        {
            //var exceptionMessage = $"{nameOfException}@{exception.GetBasicInfo()}@{exception.GetAdvancedInfo()}";

            //if (String.IsNullOrWhiteSpace(nameOfException))
            //{
            //    exceptionMessage = $"{exception.GetBasicInfo()}@{exception.GetAdvancedInfo()}";
            //}



            //return exceptionMessage.Replace("@", "\n");

            // Setup the exception message to return.
            var errorMessage = exception.Message;

            // If no custom exception label is specified, use this default one instead.
            if (!String.IsNullOrWhiteSpace(nameOfException))
            {
                //Write($"ID: {exceptionLabel}");
            }

            //Write($"Source: {exception.Source}");
            //Write($"Message: {errorMessage}");
            //Write($"Stack Trace: \n{exception.StackTrace}");

            if (!String.IsNullOrWhiteSpace(exception.HelpLink))
            {
                //Write($"Help-Link: {exception.HelpLink}");
            }

            // Line break to provide better formatting.
            //Write("");

            return errorMessage;
        }
        */



        /*
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
        */
    }
}