// ***********************************************************************
// Assembly         : NRTyler.CodeLibrary.UnitTests
//
// Author           : Nicholas Tyler
// Created          : 07-28-2017
//
// Last Modified By : Nicholas Tyler
// Last Modified On : 09-13-2017
//
// License          : MIT License
// ***********************************************************************

using NRTyler.CodeLibrary.Attributes;

namespace NRTyler.CodeLibrary.Enums
{
    /// <summary>
    /// <see cref="UnitTestResult"/> holds values that indicate whether a given test passed, failed, or has yet to be run.
    /// </summary>
    public enum UnitTestResult
    {
        [StringLabel("Failed")]
        Failed = 0,

        [StringLabel("Passed")]
        Passed = 1,

        [StringLabel("Yet To Run")]
        YetToRun = 2,
    }
}