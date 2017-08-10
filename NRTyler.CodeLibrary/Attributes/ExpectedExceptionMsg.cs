// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-10-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-10-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NRTyler.CodeLibrary.Attributes
{
	/// <summary>
	/// Attribute that specifies to expect an exception of the specified 
	/// type along with the specified error message.
	/// </summary>
	public class ExpectedExceptionMsg : ExpectedExceptionBaseAttribute
	{
		private Type expectedExceptionType;
		private string expectedExceptionMessage;

		public ExpectedExceptionMsg(Type expectedExceptionType)
		{
			this.expectedExceptionType    = expectedExceptionType;
			this.expectedExceptionMessage = string.Empty;
		}

		public ExpectedExceptionMsg(Type expectedExceptionType, string expectedExceptionMessage)
		{
			this.expectedExceptionType    = expectedExceptionType;
			this.expectedExceptionMessage = expectedExceptionMessage;
		}

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