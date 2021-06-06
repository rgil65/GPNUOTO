using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using MahApps.Metro.Controls;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPNuoto
{
    /// <summary>
    /// Logica di interazione per CodiciContabiliEditView.xaml
    /// </summary>
    public partial class ModalitaPagamentoElencoView : UserControl
    {
        public ModalitaPagamentoElencoView()
        {
            InitializeComponent();
           
        }

        private void TabellaCodici_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SimpleIoc.Default.GetInstance<TableModalitaPagamentoViewModel>().OpenEdit.Execute(null);
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.GetInstance<TableModalitaPagamentoViewModel>().RefreshElenco.Execute(null);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {

            SimpleIoc.Default.GetInstance<TableModalitaPagamentoViewModel>().RefreshElenco.Execute(null);
        }
        
    }
}
