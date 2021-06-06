using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for FrontendView.
    /// </summary>
    public partial class RichiestaFattureView : UserControl

    {
        /// <summary>
        /// Initializes a new instance of the FrontendView class.
        /// </summary>
        public RichiestaFattureView()
        {
            InitializeComponent();
        }

        private void ConvalidaFattura_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditFatturaView dlg = new EditFatturaView(this);
            dlg.DataContext = ((Button) sender).DataContext;
            if ((bool) dlg.ShowDialog())
            {
               SimpleIoc.Default.GetInstance<FattureViewModel>().ConvalidaCreazioneFattura.Execute((SingolaFatturaViewModel)((Button) sender).DataContext);
            }
        }
    }
}