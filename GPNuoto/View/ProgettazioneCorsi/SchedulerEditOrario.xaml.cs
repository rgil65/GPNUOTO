using GalaSoft.MvvmLight.Ioc;
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
    /// Logica di interazione per SchedulerEditOrario.xaml
    /// </summary>
    public partial class SchedulerEditOrario : UserControl
    {
        public SchedulerEditOrario()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ElementoProgrammazioneOrariaViewModel epo = (ElementoProgrammazioneOrariaViewModel)((Button)sender).DataContext;
            object idx = ((Button)sender).CommandParameter;
            SimpleIoc.Default.GetInstance<CalendarManagerViewModel>().CorsoEdit.AddRemoveOrario(epo, Convert.ToInt16(idx));

        }

        private void TimePicker_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            MessageBox.Show("MCOMPLETED");
        }
    }
}
