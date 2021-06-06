using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.ViewModel;

namespace GPNuoto
{
    /// <summary>
    /// Description for SelezionaDataDaCalendarioView.
    /// </summary>
    public partial class SelezioneDataDaCalendarioView : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the SelezionaDataDaCalendarioView class.
        /// </summary>
        /// 
        private UserControl WindowPosizionamento;

        public SelezioneDataDaCalendarioView(UserControl WForCenter)
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
            SimpleIoc.Default.GetInstance<MovimentiViewModel>().CambioDataMovimenti.Execute(Calendario.SelectedDate);
            this.Close();
        }

        private void btnAnnulla_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void Calendario_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            //this.btnConferma.Focus();
        }

        private void MetroWindow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DialogResult = true;
            SimpleIoc.Default.GetInstance<MovimentiViewModel>().CambioDataMovimenti.Execute(Calendario.SelectedDate);
            this.Close();
        }
    }
}