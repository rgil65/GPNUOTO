using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System.Deployment.Application;
using System.Reflection;

namespace GPNuoto
{
    /// <summary>
    /// Description for MessageboxView.
    /// </summary>
    public partial class AboutView : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MessageboxView class.
        /// </summary>
        /// 
        

        /// 
        private Window WindowPosizionamento;
        
        public AboutView(Window WForCenter)
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
            string sVersione = string.Empty;
            try
            {
                sVersione = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }
            catch
            {
                sVersione = "*";
            }
            this.VersioneProgramma.Text = "Versione:" + sVersione+"  DB:" + SimpleIoc.Default.GetInstance<IDataService>().GetVersioneDatabase();

        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}