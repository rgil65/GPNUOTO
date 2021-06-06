using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for FrontendView.
    /// </summary>
    public partial class TrasferimentoMovimentiView : UserControl

    {
        /// <summary>
        /// Initializes a new instance of the FrontendView class.
        /// </summary>
        public TrasferimentoMovimentiView()
        {
            InitializeComponent();

            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditAltriMovimenti>(this,
              new Action<ShowEditAltriMovimenti>(ShowEditAltriMovimenti));
        }

    
        private void btnEseguiTrasferimento_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SimpleIoc.Default.GetInstance<TrasferimentoMovimentiViewModel>().EseguiTrasferimento.Execute(((Button) sender).DataContext);
        }

        private void ShowEditAltriMovimenti(ShowEditAltriMovimenti obj)
        {


            if (obj.dataContext != null)
            {
                //this.AltriMovimentiEditView.DataContext = obj.dataContext;
                Storyboard sb = this.FindResource("OpenEditAltriMovimenti") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("CloseEditAltriMovimenti") as Storyboard;
                sb.Begin();
            }
        }
    }
}