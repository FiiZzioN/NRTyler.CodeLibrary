// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 12-29-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-29-2017
// 
// License          : MIT License
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NRTyler.CodeLibrary.Utilities;

namespace NRTyler.CodeLibrary.Enums
{
    /// <summary>
    /// Enum ExceptionMessageType
    /// </summary>
    public enum ExceptionMessageType
    {
        /// <summary>
        /// Shows the absolute basic <see cref="Exception"/> information to the user, meaning a relatively trivial error report is produced. 
        /// This can also be used in cases where, if an <see cref="Exception"/> is thrown, it's quite clear as to why it occurred.
        /// </summary>
        Basic = 0,

        /// <summary>
        /// Shows more advanced <see cref="Exception"/> information to the user, meaning a more thorough error report is produced. This can also be 
        /// used in places where you accounted for an <see cref="Exception"/> that shouldn't happen, but want more insight should it actually occur.
        /// </summary>
        Advanced = 1,

        /// <summary>
        /// Shows almost all <see cref="Exception"/> information to the user, meaning a very thorough error report is produced. This can also be 
        /// used in places where you accounted for an <see cref="Exception"/> that should never happen, but it still occurred. This will give you 
        /// the most information that can possibly be produced by analyzing just the <see cref="Exception"/> alone.
        /// </summary>
        Complete = 2,

#if DEBUG
        /// <summary>
        /// This is here so you can test the 'ShowSwitchErrorMessage' method in the <see cref="ExceptionMessenger"/> class.
        /// </summary>
        Debug = 3
#endif
    }
}