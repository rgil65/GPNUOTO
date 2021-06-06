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
using System.Windows.Controls.Primitives;
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
    /// Logica di interazione per ProgettazioneCalendario.xaml
    /// </summary>
    public partial class ProgettazioneCalendario : UserControl
    {
        public ProgettazioneCalendario()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditProgrammazioneCorso>(this,
            new Action<ShowEditProgrammazioneCorso>(ShowEditProgrammazioneCorso));
        }

          private void AttivitaStato_Click(object sender, RoutedEventArgs e)
        {
            CorsoViewModel cvm = (CorsoViewModel)((ToggleButton)sender).DataContext;
            CalendarManagerViewModel cmvm = (CalendarManagerViewModel)this.DataContext;
            cmvm.InvertiStatoAttivazioneCorso.Execute(cvm);
        }

        private void AttivitaStatoProgrammazione_Click(object sender, RoutedEventArgs e)
        {
            SingolaAttivitaViewModel savm = (SingolaAttivitaViewModel) ((ToggleButton) sender).DataContext;
            CalendarManagerViewModel cmvm = (CalendarManagerViewModel) this.DataContext;
            cmvm.InvertiStatoAttivazioneProgrammazione.Execute(savm);
        }


        private void ListBoxItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.GetInstance<CalendarManagerViewModel>().EditAttivita.Execute(null);
        }

        private void ListBoxItemProgrammazione_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            SimpleIoc.Default.GetInstance<CalendarManagerViewModel>().EditProgrammazione.Execute((SingolaAttivitaViewModel)((ListBoxItem) sender).DataContext);
        }
        private void ShowEditProgrammazioneCorso(ShowEditProgrammazioneCorso obj)
        {
            Storyboard sb;
            if (obj.bShow)
                sb = this.FindResource("OpenEditProgrammazioneCorso") as Storyboard;
            else
                sb = this.FindResource("CloseEditProgrammazioneCorso") as Storyboard;
            sb.Begin();
        }

    }
}
