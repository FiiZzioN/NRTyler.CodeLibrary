// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 02-13-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 02-13-2018
// 
// License          : MIT License
// ***********************************************************************

using System.Windows.Forms;

namespace NRTyler.CodeLibrary.Interfaces
{
    /// <summary>
    /// Contains items that are associated with an object that will report an error to the user.
    /// </summary>
    public interface IErrorDialogService
    {
        /// <summary>
        /// Gets a value indicating whether the <see cref="MessageBox"/> will appear or not.
        /// </summary>
        bool Display { get; }

        /// <summary>
        /// Displays a <see cref="MessageBox" /> using the specified information.
        /// </summary>
        /// <returns> Returns an OK <see cref="DialogResult"/>.</returns>
        DialogResult Show();

        /// <summary>
        /// Displays a <see cref="MessageBox" /> using the specified information.
        /// </summary>
        /// <param name="message">The message the <see cref="MessageBox" /> will contain.</param>
        /// <param name="caption">The <see cref="MessageBox" />'s caption.</param>
        /// <param name="buttons">The buttons the <see cref="MessageBox" /> will use.</param>
        /// <param name="icon">The icon the <see cref="MessageBox" /> will use.</param>
        /// <returns>Returns a <see cref="DialogResult" /> based on the buttons used.</returns>
        DialogResult Show(string message, string caption = "Error Report",
                          MessageBoxButtons buttons = MessageBoxButtons.OK,
                          MessageBoxIcon icon = MessageBoxIcon.Error);
    }
}