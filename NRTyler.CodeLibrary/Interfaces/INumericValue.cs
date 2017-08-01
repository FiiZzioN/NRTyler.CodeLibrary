// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary
//
// Author           : Nicholas Tyler
// Created          : 08-01-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 08-01-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

namespace NRTyler.CodeLibrary.Interfaces
{
	public interface INumericValue<T>
	{
		T Zero();
		T Add(T a, T b);
		bool Compare(T a, T b);
	}

	public struct NumericValues: INumericValue<byte>, INumericValue<int>, INumericValue<double>
	{
		#region Byte

		byte INumericValue<byte>.Zero() { return 0; }
		byte INumericValue<byte>.Add(byte a, byte b) { return (byte)(a + b); }
		bool INumericValue<byte>.Compare(byte a, byte b) { return a == b; }

		#endregion

		#region Integer

		int INumericValue<int>.Zero() { return 0; }
		int INumericValue<int>.Add(int a, int b) { return a + b; }
		bool INumericValue<int>.Compare(int a, int b) { return a == b; }

		#endregion

		#region Double

		double INumericValue<double>.Zero() { return 0; }
		double INumericValue<double>.Add(double a, double b) { return a + b; }
		bool INumericValue<double>.Compare(double a, double b) { return a == b; }

		#endregion
	}
}