// ***********************************************************************
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NRTyler.CodeLibrary.WPF.ViewModels;

namespace NRTyler.CodeLibrary.WPF.Views
{
    /// <summary>
    /// Interaction logic for MessageBoxView.xaml
    /// </summary>
    public partial class MessageBoxView : UserControl
    {

        internal MessageBoxViewModel MessageBoxViewModel { get; set; }

        public MessageBoxView()
        {
            InitializeComponent();
            MessageBoxViewModel = (MessageBoxViewModel)this.DataContext;
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
