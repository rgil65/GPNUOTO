using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using GPNuoto.ViewModel;

namespace GPNuoto
{
    /// <summary>
    /// Description for MessageboxView.
    /// </summary>
    public partial class EditQueryRiepilogo : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MessageboxView class.
        /// </summary>
        /// 
        private UserControl WindowPosizionamento;
        
        public EditQueryRiepilogo(UserControl WForCenter)
        {
            WindowPosizionamento = WForCenter;
            this.Topmost = true;
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
            this.Close();
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnRipristina_Click(object sender, RoutedEventArgs e)
        {
            this.txtQuery.Text = ((ManagerRiepiloghiPersonalizzatiViewModel)this.DataContext).ReportSelezionato.QueryOriginale;
        }
    }
}