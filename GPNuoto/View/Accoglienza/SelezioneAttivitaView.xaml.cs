

using GalaSoft.MvvmLight.Ioc;
using GPNuoto.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GPNuoto
{
    /// <summary>
    /// Description for SelezioneAttivitaView.
    /// </summary>
    public partial class SelezioneAttivitaView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the SelezioneAttivitaView class.
        /// </summary>
        public SelezioneAttivitaView()
        {
            InitializeComponent();
        }

        private void SelezionaAttivita_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ROAttivitaViewModel roavm = (ROAttivitaViewModel) ((ListBoxItem) sender).DataContext;
            SimpleIoc.Default.GetInstance<SelezioneAnagraficaAttivitaViewModel>().SelezionaAttivita.Execute(roavm.ID);
        }

      



        //private void CheckBoxDay_Checked(object sender, RoutedEventArgs e)
        //{
        //    ((SelezioneAnagraficaAttivitaViewModel) this.DataContext).RefreshFiltro();
        //}
    }
}