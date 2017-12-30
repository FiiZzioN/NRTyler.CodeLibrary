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
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NRTyler.CodeLibrary.WPF.Models
{
    internal class MessageBoxModel : INotifyPropertyChanged
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        internal MessageBoxModel()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        internal MessageBoxModel(string message)
            : this(message, null, null, null, null, null, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        /// <param name="caption">The caption of the message box window.</param>
        internal MessageBoxModel(string message, string caption)
            : this(message, caption, null, null, null, null, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        /// <param name="caption">The caption of the message box window.</param>
        /// <param name="image">The image or icon that the message box will contain.</param>
        internal MessageBoxModel(string message, string caption, string image)
            : this(message, caption, image, null, null, null, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        /// <param name="caption">The caption of the message box window.</param>
        /// <param name="image">The image or icon that the message box will contain.</param>
        /// <param name="okButtonText">The text for the OK button.</param>
        internal MessageBoxModel(string message, string caption, string image, string okButtonText)
            : this(message, caption, image, okButtonText, null, null, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        /// <param name="caption">The caption of the message box window.</param>
        /// <param name="image">The image or icon that the message box will contain.</param>
        /// <param name="okButtonText">The text for the OK button.</param>
        /// <param name="cancelButtonText">The text for the cancel button.</param>
        internal MessageBoxModel(string message, string caption, string image, string okButtonText, string cancelButtonText)
            : this(message, caption, image, okButtonText, cancelButtonText, null, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        /// <param name="caption">The caption of the message box window.</param>
        /// <param name="image">The image or icon that the message box will contain.</param>
        /// <param name="okButtonText">The text for the OK button.</param>
        /// <param name="cancelButtonText">The text for the cancel button.</param>
        /// <param name="yesButtonText">The text for the yes button.</param>
        internal MessageBoxModel(string message, string caption, string image, string okButtonText, string cancelButtonText, string yesButtonText)
            : this(message, caption, image, okButtonText, cancelButtonText, yesButtonText, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageBoxModel"/> class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        /// <param name="caption">The caption of the message box window.</param>
        /// <param name="image">The image or icon that the message box will contain.</param>
        /// <param name="okButtonText">The text for the OK button.</param>
        /// <param name="cancelButtonText">The text for the cancel button.</param>
        /// <param name="yesButtonText">The text for the yes button.</param>
        /// <param name="noButtonText">The text for the no button.</param>
        internal MessageBoxModel(string message, string caption, string image, string okButtonText, string cancelButtonText, string yesButtonText, string noButtonText)
        {
            InitializeClass(message, caption, image, okButtonText, cancelButtonText, yesButtonText, noButtonText);
        }

        #endregion

        #region Fields and Properties

        private string message;
        private string caption;
        private string image;
        private string okButtonText;
        private string cancelButtonText;
        private string yesButtonText;
        private string noButtonText;

        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public string Caption
        {
            get { return this.caption; }
            set
            {
                this.caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public string Image
        {
            get { return this.image; }
            set
            {
                this.image = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public string OkButtonText
        {
            get { return this.okButtonText; }
            set
            {
                this.okButtonText = value;
                OnPropertyChanged(nameof(OkButtonText));
            }
        }

        public string CancelButtonText
        {
            get { return this.cancelButtonText; }
            set
            {
                this.cancelButtonText = value;
                OnPropertyChanged(nameof(CancelButtonText));
            }
        }

        public string YesButtonText
        {
            get { return this.yesButtonText; }
            set
            {
                this.yesButtonText = value;
                OnPropertyChanged(nameof(YesButtonText));
            }
        }

        public string NoButtonText
        {
            get { return this.noButtonText; }
            set
            {
                this.noButtonText = value;
                OnPropertyChanged(nameof(NoButtonText));
            }
        }

        public MessageBoxResult MessageBoxResult { get; set; }

        #endregion

        /// <summary>
        /// Initializes the class.
        /// </summary>
        /// <param name="message">The message that the message box will contain.</param>
        /// <param name="caption">The caption of the message box window.</param>
        /// <param name="image">The image or icon that the message box will contain.</param>
        /// <param name="okButtonText">The text for the OK button.</param>
        /// <param name="cancelButtonText">The text for the cancel button.</param>
        /// <param name="yesButtonText">The text for the yes button.</param>
        /// <param name="noButtonText">The text for the no button.</param>
        [SuppressMessage("ReSharper", "ParameterHidesMember")]
        private void InitializeClass(string message, string caption, string image, string okButtonText,
                                       string cancelButtonText, string yesButtonText, string noButtonText)
        {
            Message          = message;
            Caption          = caption;
            Image            = image;
            OkButtonText     = HandleNullButtonText(okButtonText    , "OK");
            CancelButtonText = HandleNullButtonText(cancelButtonText, "Cancel");
            YesButtonText    = HandleNullButtonText(yesButtonText   , "Yes");
            NoButtonText     = HandleNullButtonText(noButtonText    , "No");
        }

        /// <summary>
        /// Checks to see if the 'textToCheck' is <see langword="null"/>, if it is, then we 
        /// return 'textToUse'. If the 'textToCheck' isn't <see langword="null"/>, then use that.
        /// </summary>
        /// <param name="textToCheck">The text to check.</param>
        /// <param name="textToUse">The text to use if the button text is <see langword="null"/>.</param>
        protected virtual string HandleNullButtonText(string textToCheck, string textToUse)
        {
            if (String.IsNullOrWhiteSpace(textToCheck))
            {
                return textToUse;
            }

            return textToCheck;
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