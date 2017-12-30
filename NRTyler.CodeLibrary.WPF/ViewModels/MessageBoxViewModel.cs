// ************************************************************************
// Assembly         : NRTyler.CodeLibrary.WPF
// 
// Author           : Nicholas Tyler
// Created          : 12-30-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-30-2017
// 
// License          : MIT License
// ***********************************************************************

using NRTyler.CodeLibrary.WPF.Annotations;
using NRTyler.CodeLibrary.WPF.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NRTyler.CodeLibrary.WPF.ViewModels
{
    public class MessageBoxViewModel : INotifyPropertyChanged
    {
        public MessageBoxViewModel()
        {
            this.messageBoxModel = new MessageBoxModel();
        }

        private MessageBoxModel messageBoxModel;

        internal MessageBoxModel MessageBoxModel
        {
            get { return this.messageBoxModel; }
            set
            {
                this.messageBoxModel = value;
                OnPropertyChanged(nameof(MessageBoxModel));
            }
        }

        #region INotifyPropertyChanged Members

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}