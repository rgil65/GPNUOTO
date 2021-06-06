using System.Windows;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.ViewModel;
using GPNuoto.Model;

namespace GPNuoto
{
    /// <summary>
    /// Description for SelezionaDataDaCalendarioView.
    /// </summary>
    public partial class MovimentiEditDetailsView : Window
    {
        /// <summary>
        /// Initializes a new instance of the SelezionaDataDaCalendarioView class.
        /// </summary>
        /// 
        private Window WindowPosizionamento;
        

        public MovimentiEditDetailsView(Window WForCenter)
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

     
       
       

        private void btnChiudi_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }



        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            ManagerDettagliMovimentoViewModel manager = (ManagerDettagliMovimentoViewModel)this.DataContext;
            manager.SalvaDettagli.Execute(manager.Scontrino);
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            ManagerDettagliMovimentoViewModel manager = (ManagerDettagliMovimentoViewModel)this.DataContext;
            manager.RemoveDettaglio.Execute((((SingoloDettaglioCodiceContabileViewModel)((Button)sender).DataContext)));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            ManagerDettagliMovimentoViewModel manager = (ManagerDettagliMovimentoViewModel)this.DataContext;
            manager.AddDettaglio.Execute((((SingoloDettaglioCodiceContabileViewModel)((Button)sender).DataContext)));
        }
    }
}