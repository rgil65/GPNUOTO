using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;

namespace GPNuoto
{
    /// <summary>
    /// Description for MessageboxView.
    /// </summary>
    public partial class StpPreView : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MessageboxView class.
        /// </summary>
        /// 
        private UserControl WindowPosizionamento;
        public StpPreView(UserControl WForCenter)
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
            this.Close();
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}