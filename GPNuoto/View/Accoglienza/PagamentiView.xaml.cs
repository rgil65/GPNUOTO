using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for AnagraficaView.
    /// </summary>
    public partial class PagamentiView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the AnagraficaView class.
        /// </summary>
        public PagamentiView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowStampaRicevuta>(this,
             new Action<ShowStampaRicevuta>(ShowStampaRicevuta));
        }


        private void ShowStampaRicevuta(ShowStampaRicevuta obj)
        {

            if (obj.ShowWindow)
            {
                Storyboard sb = this.FindResource("OpenStampaRicevuta") as Storyboard;
                sb.Begin();
            }else
            {
                Storyboard sb = this.FindResource("CloseStampaRicevuta") as Storyboard;
                sb.Begin();
            }

        }

        private void btnAddPagamento_Click(object sender, RoutedEventArgs e)
        {
            CassaViewModel cvm = SimpleIoc.Default.GetInstance<CassaViewModel>();
            if (cvm.Stato != CassaViewModel.StatoCassa.Aperta)
            {

                MessageboxView msgb = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomInfo, Properties.Resources.MSG_APRIRELACASSA);
                msgb.ShowDialog();
            }
            else
            {
                SimpleIoc.Default.GetInstance<AnagraficaViewModel>().PagamentoExtraAttivita.Execute(this);
            }
        }

        private void btnViewRicevuta_Click(object sender, RoutedEventArgs e)
        {


            StampaRicevutaViewModel srvm = SimpleIoc.Default.GetInstance<StampaRicevutaViewModel>();
            srvm.Anagrafica = new AnagraficaROViewModel(SimpleIoc.Default.GetInstance<AnagraficaViewModel>());
            srvm.Pagamento = ((PagamentiViewModel) this.DataContext).MovimentoSelezionato;
            Storyboard sb = this.FindResource("OpenStampaRicevuta") as Storyboard;
                sb.Begin();
            
        }

        private void btnPrintRicevuta_Click(object sender, RoutedEventArgs e)
        {

            this.Ricevuta.PrintRicevuta();
        }


        private void btnEsciPrintRicevutaForm_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.FindResource("CloseStampaRicevuta") as Storyboard;
            sb.Begin();
        }

        private void btnStampaRicevutaFiscale_Click(object sender, RoutedEventArgs e)
        {
            MessageboxView msgb = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomMessage, Properties.Resources.MSG_CONFERMASTAMPAFISCALE);
            if ((bool)msgb.ShowDialog())
                ((PagamentiViewModel)this.DataContext).MovimentoSelezionato.StampaRicevutaFiscale.Execute(null);

        }
    }
}