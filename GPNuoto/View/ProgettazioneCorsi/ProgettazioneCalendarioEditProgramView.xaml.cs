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
    /// Logica di interazione per ProgettazioneCalendarioEditProgramView.xaml
    /// </summary>
    public partial class ProgettazioneCalendarioEditProgramView : UserControl
    {
        private bool bIgnoreCalendarChanges = false;
        public ProgettazioneCalendarioEditProgramView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<RefreshCalendarioDate>(this,
           new Action<RefreshCalendarioDate>(RefreshCalendarioDate));
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<RefreshCalendarioBlackDate>(this,
         new Action<RefreshCalendarioBlackDate>(RefreshCalendarioBlackDate));
        }

        private void Cal_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            if (bIgnoreCalendarChanges) return;
            SingolaAttivitaViewModel savm = (SingolaAttivitaViewModel) this.DataContext;
            savm.UpdateElencoDate(e.AddedItems, e.RemovedItems);
                        
            //if (this.CalendarioProgrammazione.SelectedDates.Count() == 0 &&
            //    savm.ElencoDateCorso != null)
            //{
            //    savm.ElencoDateCorso.Clear();
            //    return;
            //}
            //if (this.CalendarioProgrammazione.SelectedDates.Count() != 0 && (savm.ElencoDateCorso == null || savm.ElencoDateCorso.Count() != this.CalendarioProgrammazione.SelectedDates.Count()))
            //    savm.CalcolaElencoDateFromDates(this.CalendarioProgrammazione.SelectedDates);
        }

        private void RefreshCalendarioDate(RefreshCalendarioDate obj)
        {
            bIgnoreCalendarChanges = true;
            SingolaAttivitaViewModel savm = obj.savm;
            this.CalendarioProgrammazione.SelectedDates.Clear();
            if (savm.ElencoDateCorso != null)
            {
                foreach (SingolaDataAttivitaViewModel oc in savm.ElencoDateCorso)
                    this.CalendarioProgrammazione.SelectedDates.Add(new DateTime(oc.Inizio.Year, oc.Inizio.Month, oc.Inizio.Day));
            }
            bIgnoreCalendarChanges = false;
        }

        private void RefreshCalendarioBlackDate(RefreshCalendarioBlackDate obj)
        {
            SingolaAttivitaViewModel savm = obj.savm;
            this.CalendarioProgrammazione.BlackoutDates.Clear();
            foreach (DateTime oc in savm.CalendarioBlackDates)
                   this.CalendarioProgrammazione.BlackoutDates.Add(new CalendarDateRange(oc,oc));
        }
        private void CalendarioProgrammazione_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            if (this.CalendarioProgrammazione.SelectedDate != null)
            {
                // Programmo le date
                SingolaAttivitaViewModel cvm = (SingolaAttivitaViewModel) this.DataContext;
                cvm.CalcolaElencoDate((DateTime)this.CalendarioProgrammazione.SelectedDate);


            }
        }

        private void CalendarioProgrammazione_DisplayDateChanged(object sender, CalendarDateChangedEventArgs e)
        {

        }

        

        private void RemoveDataAttivita_Click(object sender, RoutedEventArgs e)
        {
            SingolaAttivitaViewModel savm = (SingolaAttivitaViewModel) this.DataContext;
            SingolaDataAttivitaViewModel sdavm = (SingolaDataAttivitaViewModel) ((Button)sender).DataContext;
            savm.RemoveDataAttivita.Execute(sdavm.Inizio);
        }
    }
}
