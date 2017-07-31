// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 07-28-2017
//
// License          : GNU General Public License v3.0
// ***********************************************************************

using NRTyler.CodeLibrary.Attributes;

namespace NRTyler.CodeLibrary.Enums
{
    /// <summary>
    /// <see cref="UnitTestResult"/> holds values that indicate whether a given test passed, failed, or has yet to be run.
    /// </summary>
    public enum UnitTestResult
    {
        [StringValue("Failed")]
        Failed = 0,

        [StringValue("Passed")]
        Passed = 1,

        [StringValue("Yet To Run")]
        YetToRun = 2,
    }
}