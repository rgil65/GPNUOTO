using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using GPNuoto.Report;
using GPNuoto.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for AnagraficaView.
    /// </summary>
    public partial class MovimentiGiornataView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the AnagraficaView class.
        /// </summary>
        /// D
        /// 

        public MovimentiGiornataView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowAddMovimento>(this,
                new Action<ShowAddMovimento>(ShowViewMovimento));
        }

        private void ShowViewMovimento(ShowAddMovimento obj)
        {
            if (!obj.bShow)
            {
                Storyboard sb = this.FindResource("CloseAddMovimento") as Storyboard;
                sb.Begin();
            }
        }

        private void btnViewRicevuta_Click(object sender, RoutedEventArgs e)
        {

            

            StampaRicevutaViewModel stpvm = ServiceLocator.Current.GetInstance<StampaRicevutaViewModel>();
            SingoloMovimentoViewModel sm = ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato;
            stpvm.Pagamento = sm;
            if (sm.IDAnagrafica > 0)
            {
                stpvm.Anagrafica = sm.AnagraficaCollegata;
                StpRicevuta stp = new StpRicevuta();
                stp.PrintRicevuta();
            }
            else
            {
                stpvm.Anagrafica = null;
                IDataService dataservice = ServiceLocator.Current.GetInstance<IDataService>();
                SingoloCodiceContabileViewModel sccvm = dataservice.GetCodiceContabileFromCodice(sm.CCAvere);
                string[] parametriqrcode = { "", "", "" };
                parametriqrcode[0] = sccvm.Descrizione;
                parametriqrcode[1] = sm.DataPagamento.ToString(QRCodeViewModel.QRCODE_FORMATODATA);
                parametriqrcode[2] = sm.ID.ToString();
                string qcode = QRCodeViewModel.GetQRCodeString(QRCodeViewModel.TipoQRCode.Biglietto, parametriqrcode);
                stpvm.QRCode = QRCodeViewModel.GetQRCodeBitmap(qcode);
                //stp.PrintRicevuta();
                PreviewStampaRicevuta ps = new PreviewStampaRicevuta();
                ps.ShowDialog();

            }







        }

        private void btnStampaRicevutaFiscale_Click(object sender, RoutedEventArgs e)
        {
            MessageboxView msgb = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomMessage, Properties.Resources.MSG_CONFERMASTAMPAFISCALE);
            if ((bool)msgb.ShowDialog())
                ((MovimentiViewModel)this.DataContext).MovimentoSelezionato.StampaRicevutaFiscale.Execute(null);
        }

        private void btnAddMovimento_Click(object sender, RoutedEventArgs e)
        {
            CassaViewModel cvm = ServiceLocator.Current.GetInstance<CassaViewModel>();
            if (cvm.Stato != CassaViewModel.StatoCassa.Aperta)
            {

                MessageboxView msgb = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomInfo, Properties.Resources.MSG_APRIRELACASSA);
                msgb.ShowDialog();
            }
            else
            {
                Storyboard sb = this.FindResource("OpenAddMovimento") as Storyboard;
                sb.Begin();
                ((MovimentiViewModel)this.DataContext).AddMovimento.Execute(null);

            }
        }

        private void btnCancellaMovimento_Click(object sender, RoutedEventArgs e)
        {
            MessageboxView msgb = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomQuery, Properties.Resources.MSG_CONFERMACANCELLAZIONEMOVIMENTO);
            msgb.ShowDialog();
            if (msgb.DialogResult==true)
                ((MovimentiViewModel)this.DataContext).RemoveMovimento.Execute(null);

        }

        private void btnModificaMovimento_Click(object sender, RoutedEventArgs e)
        {
            ChangeMovimentoView cmv = new ChangeMovimentoView(this);
            SingoloMovimentoModificaViewModel sm = new SingoloMovimentoModificaViewModel();
            sm.Descrizione = ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.Descrizione;
            sm.ImportoPagato = ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ImportoPagato;
            sm.ElencoModalitaPagamento = ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ElencoModalitaPagamento;
            sm.ModalitaPagamento = ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ModalitaPagamento.Key;
            cmv.DataContext  = sm;
            cmv.ShowDialog();
            if ((bool)cmv.DialogResult)
            {
                ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ImportoPagato = sm.ImportoPagato;
                ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.Sconto = ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ImportoPagare - ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ImportoPagato;
                ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ModalitaPagamento = ((MovimentiViewModel)(this.DataContext)).MovimentoSelezionato.ElencoModalitaPagamento.Find(p => p.Key.CompareTo(sm.ModalitaPagamento) == 0);
                ((MovimentiViewModel)(this.DataContext)).UpdateMovimento.Execute(null);
                ServiceLocator.Current.GetInstance<AnagraficaViewModel>().ClearOnlyAnagrafica.Execute(null);
            }
        }
    }
}
