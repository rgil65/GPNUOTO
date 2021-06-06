using GalaSoft.MvvmLight.Ioc;
using GPNuoto.ViewModel;
using MahApps.Metro.Controls;
using System.Windows;

namespace GPNuoto
{
    /// <summary>
    /// Description for LoginView.
    /// </summary>
    public partial class LoginView :  MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the LoginView class.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().Logout();
            this.DialogResult = false;
            this.Close();
        
        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {

            SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().user = this.Utente.Text.Trim();
            SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().password = this.Password.Password;
            if (SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().CheckForLogin())
            {
                SimpleIoc.Default.GetInstance<UtentiViewModel>().Login.Execute(true);
                this.DialogResult = true;
                this.Close();
            }
            else
                this.TxtError.Visibility = Visibility.Visible;
        }
    }
}