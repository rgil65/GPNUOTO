using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace GPNuoto
{
    /// <summary>
    /// Description for MessageboxView.
    /// </summary>
    public partial class MessageboxView : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MessageboxView class.
        /// </summary>
        /// 
        public enum TipoMessaggio : int
            {DeleteConferma,UndoEditConferma,CustomMessage,CustomInfo,CustomQuery};


        /// 
        private UserControl WindowPosizionamento;
        private TipoMessaggio TM;
        string Messaggio;
        public MessageboxView(UserControl WForCenter,TipoMessaggio tm,string sMessaggio)
        {
            WindowPosizionamento = WForCenter;
            TM = tm;
            Messaggio = sMessaggio;
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            Point relativePoint = WindowPosizionamento.TransformToAncestor(Application.Current.MainWindow)
                          .Transform(new Point(0, 0));


            this.Left = relativePoint.X - (this.ActualWidth - WindowPosizionamento.ActualWidth)/2.0;
            this.Top = relativePoint.Y - (this.ActualHeight - WindowPosizionamento.ActualHeight) / 2.0;
            if (TM == TipoMessaggio.CustomInfo)
                this.btnAnnulla.Visibility = Visibility.Collapsed;
            else
                this.btnAnnulla.Visibility = Visibility.Visible;

            switch (TM)
            {
                case TipoMessaggio.DeleteConferma:
                    Message.Text = "Confermi l'operazione di cancellazione?";
                    break;
                case TipoMessaggio.UndoEditConferma:
                    Message.Text = "Sono stati modificati dei dati.\nConfermi la chiusura annullando le modifiche?";
                    break;

                case TipoMessaggio.CustomMessage:
                    Message.Text = Messaggio;
                    break;
                case TipoMessaggio.CustomQuery:
                    Message.Text = Messaggio;
                    break;
                case TipoMessaggio.CustomInfo:
                    Message.Text = Messaggio;
                    break;
            }

        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}