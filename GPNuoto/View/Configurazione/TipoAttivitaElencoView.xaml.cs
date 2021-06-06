using GalaSoft.MvvmLight.Ioc;
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
    /// Logica di interazione per CodiciContabiliEditView.xaml
    /// </summary>
    public partial class TipoAttivitaElencoView : UserControl
    {
        public TipoAttivitaElencoView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditProgrammazioneCorso>(this,
           new Action<ShowEditProgrammazioneCorso>(ShowEditProgrammazioneCorso));
        }

        private void TabellaCodici_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SimpleIoc.Default.GetInstance<TableUtentiViewModel>().OpenEdit.Execute(null);
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.GetInstance<TableUtentiViewModel>().RefreshElenco.Execute(null);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {

            SimpleIoc.Default.GetInstance<TableUtentiViewModel>().RefreshElenco.Execute(null);
        }
        private void ShowEditProgrammazioneCorso(ShowEditProgrammazioneCorso obj)
        {
            if (obj.bShow)
                this.lvTipoAttivita.IsEnabled = false;
            else
                this.lvTipoAttivita.IsEnabled = true;
        }

        public void SetManagerReadOnly(bool IsReadOnly)
        {
            if (IsReadOnly)
                this.btnAddRecord.Visibility = Visibility.Hidden;
            else
                this.btnAddRecord.Visibility = Visibility.Visible;
        }
    }
}
