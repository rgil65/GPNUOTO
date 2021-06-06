using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPNuoto
{
    /// <summary>
    /// Logica di interazione per EditDateAttivitaView.xaml
    /// </summary>
    public partial class EditDateAttivitaView : UserControl
    {
        public EditDateAttivitaView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<AddSingoloIngresso>(this,
                  new Action<AddSingoloIngresso>(AddIngresso));
        }
        private void btnAddDateAttivita_Click(object sender, RoutedEventArgs e)
        {
            AggiungiDataAttivitaView CambiaDataView = new AggiungiDataAttivitaView(this);
            CambiaDataView.ShowDialog();
        }


        private void AddIngresso(AddSingoloIngresso obj)
        {

            ((SingolaAnagraficaAttivitaViewModel)this.DataContext).AddSingoloIngresso.Execute(obj.IntervalloTempo);
        }

        private void btnAssente_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPresente_Click(object sender, RoutedEventArgs e)
        {
            SingolaAnagraficaAttivitaViewModel sa = ((SingolaAnagraficaAttivitaViewModel)this.DataContext);
            if (sa != null)
            {
                
            }
        }
    }
}