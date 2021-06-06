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
    public partial class MovimentiEditView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the PagamentiEditView class.
        /// </summary>
        public MovimentiEditView()
        {
            InitializeComponent();
         }

        private void btnConfermaPagamento_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageboxView msgbox = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomQuery, Properties.Resources.MSG_CONFERMAPAGAMENTO);
            if ((bool)msgbox.ShowDialog())
                ((SingoloMovimentoViewModel)(this.DataContext)).SalvaMovimentoContabile.Execute(null);
        }

       

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowAddMovimento>(new ShowAddMovimento(false));
        }

        private void btnDettagli_Click(object sender, RoutedEventArgs e)
        {
            MovimentiEditDetailsView md = new MovimentiEditDetailsView(Application.Current.MainWindow);
            ManagerDettagliMovimentoViewModel vm = new ManagerDettagliMovimentoViewModel((SingoloMovimentoViewModel)(this.DataContext));
            md.DataContext = vm;
            md.ShowDialog();
        }
    }
}
