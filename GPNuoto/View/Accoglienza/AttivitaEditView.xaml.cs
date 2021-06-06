using GPNuoto.Model;
using GPNuoto.ViewModel;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace GPNuoto
{
    /// <summary>
    /// Description for AttivitaEditView.
    /// </summary>
    public partial class AttivitaEditView :UserControl
    {
        /// <summary>
        /// Initializes a new instance of the AttivitaEditView class.
        /// </summary>
        public AttivitaEditView()
        {
            InitializeComponent();

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowUndoEdit>(this,
             new Action<ShowUndoEdit>(ShowUndoEditClik));
        }

        private void ShowUndoEditClik(ShowUndoEdit obj)
        {
            if (obj.DataContext == this.DataContext)
            {
                MessageboxView sampleMessageDialog = new MessageboxView(this,MessageboxView.TipoMessaggio.UndoEditConferma,string.Empty);
                if ((bool)sampleMessageDialog.ShowDialog())
                    ((SingolaAnagraficaAttivitaViewModel)this.DataContext).ChiudiEditAttivita.Execute(true);
            }
        }

        private  void btnChiudiEditAttivita_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageboxView sampleMessageDialog = new MessageboxView(this,MessageboxView.TipoMessaggio.DeleteConferma,string.Empty);
            

            Nullable<bool> dialogResult = sampleMessageDialog.ShowDialog();
        }

        private void brnPagaAttivita_Click(object sender, RoutedEventArgs e)
        {
            CassaViewModel cvm = ServiceLocator.Current.GetInstance<CassaViewModel>();
            if (cvm.Stato != CassaViewModel.StatoCassa.Aperta)
            {
                
                MessageboxView msgb = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomInfo, Properties.Resources.MSG_APRIRELACASSA);
                msgb.ShowDialog();
            }
            else
            {
                ((SingolaAnagraficaAttivitaViewModel)this.DataContext).PagaAttivita.Execute(null);
            }
        }
    }
}