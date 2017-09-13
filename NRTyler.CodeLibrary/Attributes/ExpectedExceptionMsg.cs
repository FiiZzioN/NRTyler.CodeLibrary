// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-25-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-01-2017
//
// License          : MIT License
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NRTyler.CodeLibrary.Attributes
{
	/// <inheritdoc />
	/// <summary>
	/// Attribute that specifies to expect an exception of the specified 
	/// type along with the specified error message.
	/// </summary>
	public class ExpectedExceptionMsg : ExpectedExceptionBaseAttribute
	{
		private Type expectedExceptionType;
		private string expectedExceptionMessage;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:NRTyler.CodeLibrary.Attributes.ExpectedExceptionMsg" /> class.
        /// </summary>
        /// <param name="expectedExceptionType">Expected type of the exception.</param>
        public ExpectedExceptionMsg(Type expectedExceptionType)
		{
			this.expectedExceptionType    = expectedExceptionType;
			this.expectedExceptionMessage = string.Empty;
		}

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:NRTyler.CodeLibrary.Attributes.ExpectedExceptionMsg" /> class.
        /// </summary>
        /// <param name="expectedExceptionType">Expected type of the exception.</param>
        /// <param name="expectedExceptionMessage">The expected exception message.</param>
        public ExpectedExceptionMsg(Type expectedExceptionType, string expectedExceptionMessage)
		{
			this.expectedExceptionType    = expectedExceptionType;
			this.expectedExceptionMessage = expectedExceptionMessage;
		}

        /// <inheritdoc />
        /// <summary>
        /// Determines whether the exception is expected. If the method returns, then it is
        /// understood that the exception was expected. If the method throws an exception, then it
        /// is understood that the exception was not expected, and the thrown exception's message
        /// is included in the test result. The <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.Assert" /> class can be used for
        /// convenience. If <see cref="M:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Inconclusive" /> is used and the assertion fails,
        /// then the test outcome is set to Inconclusive.
        /// </summary>
        /// <param name="exception">The exception thrown by the unit test</param>
        protected override void Verify(Exception exception)
		{
			Assert.IsNotNull(exception);

			Assert.IsInstanceOfType(exception, this.expectedExceptionType, "Wrong type of exception was thrown.");

			if (!this.expectedExceptionMessage.Length.Equals(0))
			{
				Assert.AreEqual(this.expectedExceptionMessage, exception.Message, "Wrong exception message was returned.");
			}
		}
	}
}