using GPNuoto.Model;
using GPNuoto.ViewModel;
using Microsoft.Practices.ServiceLocation;
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

namespace GPNuoto.View.Riepiloghi
{
    /// <summary>
    /// Logica di interazione per UCRiepilogoIscrizioni.xaml
    /// </summary>
    public partial class UCRiepilogoIscrizioni : UserControl
    {
        public UCRiepilogoIscrizioni()
        {
            InitializeComponent();

        }

   
        private void btnGotoAnagrafica_Click(object sender, RoutedEventArgs e)
        {
            List<int> idlist = new List<int>();

            foreach (AnagraficaROViewModel rvm in this.lvIscritti.SelectedItems)
                idlist.Add(rvm.IDAnagrafica);

            ServiceLocator.Current.GetInstance<AnagraficaViewModel>().ResultSetFromID(idlist,true);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowAccoglienzaView>(new ShowAccoglienzaView());

        }
    }
}
