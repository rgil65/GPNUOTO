using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for ManagerTabellaModalitaPagamentoView.
    /// </summary>
    public partial class ManagerImpostazioniView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerImpostazioniView()
        {
            InitializeComponent();
        }

        private void btnSelezionaDirectory_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ((ImpostazioniViewModel)this.DataContext).DirectoryStampanteFiscale = dialog.SelectedPath.ToString();
            }
        }

        private void btnSelezionaStampanteRicevuta_Click(object sender, RoutedEventArgs e)
        {
            
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
                ((ImpostazioniViewModel)this.DataContext).StampanteRicevuta = dialog.PrintQueue.FullName;
            else
                ((ImpostazioniViewModel)this.DataContext).StampanteRicevuta = string.Empty;

        
        }

        private void btnSelezionaStampanteBadge_Click(object sender, RoutedEventArgs e)
        {

            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
                ((ImpostazioniViewModel)this.DataContext).StampanteBadge = dialog.PrintQueue.FullName;
            else
                ((ImpostazioniViewModel)this.DataContext).StampanteBadge = string.Empty;
        }
    }
}