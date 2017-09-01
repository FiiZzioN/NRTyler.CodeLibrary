// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 08-20-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-20-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRTyler.CodeLibrary.Extensions;

namespace NRTyler.CodeLibrary.UnitTests.ExtensionTests
{
	[TestClass]
	public class StringExtensionTests
	{
		[TestMethod]
		public void ConvertToCultureTitleCase()
		{
			//Arrange
			var title = "thiS tiTle is All MesSed uP";

			var expected = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title);

			//Act
			var actual = title.ToTitleCase();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ConvertToInvariantCultureTitleCase()
		{
			//Arrange
			var title = "thiS tiTle is All MesSed uP";

			var expected = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(title);

			//Act
			var actual = title.ToInvariantTitleCase();

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsureValidTitle()
		{
			//Arrange
			var test = new TitleTest("Billy");

			var expected = "Billy";

			//Act
			var actual = test.Title;

			//Assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InsureAgainstInvalidTitle()
		{
			//Arrange
			var test = new TitleTest(String.Empty);

			var expected = "Invalid Title";

			//Act
			var actual = test.Title;

			//Assert
			Assert.AreEqual(expected, actual);
		}
	}

	internal struct TitleTest
	{
		public TitleTest(string title) : this()
		{
			this.Title = title;
		}

		private string title;

		public string Title
		{
			get { return this.title; }
			set
			{
				value.TitleInsurance(ref this.title);
			}
		}
	}
}