using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace GPNuoto
{
    /// <summary>
    /// Description for CalendarioCorsiView.
    /// </summary>
    public partial class CalendarioCorsiView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CalendarioCorsiView class.
        /// </summary>
        public CalendarioCorsiView()
        {
            InitializeComponent();
        }


        private void InfoCorso_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

             
    }
}