using GPNuoto;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.ServiceLocation;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;

namespace GPNuoto
{
    /// <summary>
    /// Description for AnagraficaView.
    /// </summary>
    public partial class CorsiView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the AnagraficaView class.
        /// </summary>
        public CorsiView()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

      
                AnagraficaViewModel avm = ServiceLocator.Current.GetInstance<AnagraficaViewModel>();
                avm.EditAttivita.Execute(((Grid)(sender)).DataContext);
        }
    }
}