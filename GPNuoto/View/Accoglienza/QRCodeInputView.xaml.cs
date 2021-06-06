using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using Microsoft.Practices.ServiceLocation;
using GPNuoto.ViewModel;
using System;
using System.Windows.Threading;
using GPNuoto.Model;
using System.Windows.Input;
using System.Windows.Media;

namespace GPNuoto
{
    

    /// <summary>
    /// Description for MessageboxView.
    /// </summary>
    public partial class QRCodeInputView : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MessageboxView class.
        /// </summary>
        /// 
        private UserControl WindowPosizionamento;
        public QRCodeViewModel qrvm;
        DispatcherTimer dispatcherTimer;
        IDataService dataservice;
        public bool IsRinnovo = false;
        Brush DefaultBackground;
        LogTornelliViewModel LTV = null;
        public QRCodeInputView(UserControl WForCenter)
        {
            WindowPosizionamento = WForCenter;
            qrvm = new QRCodeViewModel();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            Point relativePoint = WindowPosizionamento.TransformToAncestor(Application.Current.MainWindow)
                          .Transform(new Point(0, 0));


            this.Left = relativePoint.X - (this.ActualWidth - WindowPosizionamento.ActualWidth)/2.0;
            this.Top = relativePoint.Y - (this.ActualHeight - WindowPosizionamento.ActualHeight) / 2.0;
            DefaultBackground = this.QRCodeText.Background;
            LTV = null;
            this.QRCodeText.Focus();

        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            IsRinnovo = false;
            this.QRCodeText.Background = DefaultBackground;
            this.Close();
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.QRCodeText.Background = DefaultBackground;
            this.Close();
        }

        private void QRCodeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            // evita un controllo per ogni input
            dispatcherTimer.Stop();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
                    
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            QRCodeViewModel.QrCodeEntry qe = qrvm.QrCodeToData(this.QRCodeText.Text);
            ImpostazioniViewModel ivm = ServiceLocator.Current.GetInstance<ImpostazioniViewModel>();
            if (qe.Tipo == QRCodeViewModel.TipoQRCode.Tessera)
            {
                this.btnRinnovo.IsEnabled = dataservice.CheckForRinnovo(qe.CodiceFiscale, qe.Attivita);
                DateTime dt = new DateTime(2018, 3, 23, 19, 39, 40);
                LTV = dataservice.CheckIngresso(qe, dt, ivm.AnticipoIngresso, ivm.AnticipoFineCorso);
                this.btnIngresso.IsEnabled = LTV.IsAutorizzato;
                if (LTV.IsAutorizzato)
                    LTV.Note = LTV.Note + "[Ingresso manuale]";
            }
        }

        private void btnrRinnovo_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            IsRinnovo = true;
            this.QRCodeText.Background = DefaultBackground;
            this.Close();
        }

        private void QRCodeText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled) // Checks Capslock is on
            {
                this.QRCodeText.Background = Brushes.Red;
            }else
                this.QRCodeText.Background = DefaultBackground;
        }

        private void btnIngresso_Click(object sender, RoutedEventArgs e)
        {
            
            dataservice.SaveTornelloLog(LTV, false, false);
            dataservice.SalvaPresenza(LTV);
            this.DialogResult = true;
            this.Close();
        }
    }
}