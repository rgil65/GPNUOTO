using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.ViewModel;
using System;
using System.IO;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Xml.Linq;
using GPNuoto.Model;

namespace GPNuoto
{
    /// <summary>
    /// Description for PagamentiEditView.
    /// </summary>
    public partial class PagamentiEditView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the PagamentiEditView class.
        /// </summary>
        public PagamentiEditView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<StampaRicevuta>(this,
            new Action<StampaRicevuta>(StampaRicevuta));
            
        }

        private void btnConfermaPagamento_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageboxView msgbox = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomQuery, Properties.Resources.MSG_CONFERMAPAGAMENTO);
            if ((bool)msgbox.ShowDialog())
                ((SingoloMovimentoViewModel)(this.DataContext)).SalvaPagamento.Execute(null);
        }

        private void StampaRicevuta(StampaRicevuta obj)
        {

            this.Ricevuta.PrintRicevuta();


        }
        private void btnStampaRicevutaFiscale_Click(object sender, RoutedEventArgs e)
        {
            MessageboxView msgb = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomMessage, Properties.Resources.MSG_CONFERMASTAMPAFISCALE);
            if ((bool)msgb.ShowDialog())
                ((SingoloMovimentoViewModel)this.DataContext).StampaRicevutaFiscale.Execute(null);

        }

    }
}
