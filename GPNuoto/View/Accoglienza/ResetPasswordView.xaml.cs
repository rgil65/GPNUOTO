using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using GPNuoto.ViewModel;
using GalaSoft.MvvmLight.Ioc;

namespace GPNuoto
{
    /// <summary>
    /// Description for MessageboxView.
    /// </summary>
    public partial class ResetPasswordView : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MessageboxView class.
        /// </summary>
        /// 
        public enum TipoMessaggio : int
            {DeleteConferma,UndoEditConferma,CustomMessage,CustomInfo,CustomQuery};


        /// 
        private UserControl WindowPosizionamento;

        public ResetPasswordView(UserControl WForCenter)
        {
            WindowPosizionamento = WForCenter;
            InitializeComponent();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

            Point relativePoint = WindowPosizionamento.TransformToAncestor(Application.Current.MainWindow)
                          .Transform(new Point(0, 0));


            this.Left = relativePoint.X - (this.ActualWidth - WindowPosizionamento.ActualWidth)/2.0;
            this.Top = relativePoint.Y - (this.ActualHeight - WindowPosizionamento.ActualHeight) / 2.0;
          
           

        }

        private void btnConferma_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            SimpleIoc.Default.GetInstance<TableUtentiViewModel>().SavePassword.Execute(SingoloUtenteViewModel.MD5Hash(this.PasswordBox.Password));
            this.Close();
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.btnConferma.IsEnabled = (this.PasswordBox.Password.CompareTo(this.PasswordBoxReplay.Password) == 0 && this.PasswordBox.SecurePassword.ToString().Length >= 6);
        }
    }
}