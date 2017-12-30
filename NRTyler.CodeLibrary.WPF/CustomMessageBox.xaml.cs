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
using System.Windows.Shapes;
using NRTyler.CodeLibrary.WPF.Models;
using NRTyler.CodeLibrary.WPF.ViewModels;

namespace NRTyler.CodeLibrary.WPF
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        internal MessageBoxViewModel MessageBoxModel { get; set; }

        public CustomMessageBox()
        {
            InitializeComponent();
            
            MessageBoxModel = (MessageBoxViewModel)this.DataContext;
        }
    }
}
