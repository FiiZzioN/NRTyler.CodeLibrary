// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 03-12-2018
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 03-12-2018
// 
// License          : MIT License
// ***********************************************************************

using System.Collections.Generic;

namespace NRTyler.CodeLibrary.EventArgs
{
    /// <summary>
    /// Holds arguments for the ListChanged event.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collections.</typeparam>
    public class ListChangedEventArgs<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListChangedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="itemsChanged">The items in the list that have been changed in some way.</param>
        public ListChangedEventArgs(IEnumerable<T> itemsChanged)
        {
            ItemsChanged = itemsChanged;
        }

        private IEnumerable<T> itemsChanged;

        /// <summary>
        /// Gets or sets the items in the list that have been changed in some way.
        /// </summary>
        public IEnumerable<T> ItemsChanged
        {
            get { return this.itemsChanged ?? (this.itemsChanged = new List<T>()); }
            set { this.itemsChanged = value; }
        }

    }
}