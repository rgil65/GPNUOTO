using System.Windows;
using MahApps.Metro.Controls;
using GPNuoto.ViewModel;
using GPNuoto.Model;
using System;
using GalaSoft.MvvmLight.Ioc;

namespace GPNuoto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        //DateTime StopTime = new DateTime(2021, 1, 1, 0, 0, 0);
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
            //if (DateTime.Now > StopTime)
            //    this.Close();
            //else
            //{

                GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowLoginView>(this, new Action<ShowLoginView>(ShowLoginViewExecute));
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ChangeUserLogin>(this, new Action<ChangeUserLogin>(ChangeUserLoginExecute));

#if (DEBUG == true)
                {

                    SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().user = "gilberto";
                    SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().password = "gilberto";
                    SimpleIoc.Default.GetInstance<UtentiViewModel>().Login.Execute(true);
                }
#else
                                    ShowLoginViewExecute(null);
#endif
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowAccoglienzaView>(this, new Action<ShowAccoglienzaView>(ShowAccoglienzaViewExecute));
            //}
        }

        private void ShowLoginViewExecute(ShowLoginView obj)
        {
            LoginView dlg = new LoginView();
            if ((bool)dlg.ShowDialog())
            {
                SimpleIoc.Default.GetInstance<UtentiViewModel>().Login.Execute(true);
            }
           
        }

        private void ShowAccoglienzaViewExecute(ShowAccoglienzaView obj)
        {
            this.dockMenu.SelectedItem = this.Accoglienza;

        }

        private void ChangeUserLoginExecute(ChangeUserLogin obj)
        {
            SingoloUtenteViewModel suvm = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>();
            this.Accoglienza.Visibility = suvm.IsAttivaAccoglienza ? Visibility.Visible : Visibility.Collapsed;
            this.Contabilita.Visibility = suvm.IsAttivaContabilita ? Visibility.Visible : Visibility.Collapsed;
            this.ProgettazioneCorsi.Visibility = suvm.IsAttivaProgettazioneCorsi ? Visibility.Visible : Visibility.Collapsed;
            this.Configurazione.Visibility = suvm.IsAttivaConfigurazione ? Visibility.Visible : Visibility.Collapsed;
            this.Configurazione.IsEnabled = false;
            this.ProgettazioneCorsi.IsEnabled = false;
        }

        private void ChiudiApplicazione_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Informazioni_Click(object sender, RoutedEventArgs e)
        {
            AboutView av = new AboutView(this);
            av.ShowDialog();
        }
    }
}