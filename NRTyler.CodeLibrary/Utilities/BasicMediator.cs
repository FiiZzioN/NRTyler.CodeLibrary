// ************************************************************************
// Assembly         : NRTyler.CodeLibrary
// 
// Author           : Nicholas Tyler
// Created          : 12-16-2017
// 
// Last Modified By : Nicholas Tyler
// Last Modified On : 12-16-2017
// 
// License          : MIT License
// ***********************************************************************
using System;

namespace NRTyler.CodeLibrary.Utilities
{
    /// <summary>
    /// An example of a basic mediator that's using the "MediatorPattern". This can be used for the simplest 
    /// of projects, but you should really create a custom Mediator for each project you're working on 
    /// for better results, readability and context. I really mean that! This class cannot be inherited.
    /// </summary>
    public sealed class BasicMediator
    {
        private BasicMediator()
        {
            
        }

        private static readonly BasicMediator Instance = new BasicMediator();

        public static BasicMediator GetInstance()
        {
            return Instance;
        }

        public event EventHandler Listener;

        public void OnListener(object sender, System.EventArgs eventArgs)
        {
            var listenerDelegate = Listener;
            listenerDelegate?.Invoke(sender, System.EventArgs.Empty);
        }
    }
}