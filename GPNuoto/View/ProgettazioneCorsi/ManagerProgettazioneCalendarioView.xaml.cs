using GPNuoto.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for ManagerTabellaModalitaPagamentoView.
    /// </summary>
    public partial class ManagerProgettazioneCalendarioView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerProgettazioneCalendarioView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditProgettazioneCalendario>(this,
            new Action<ShowEditProgettazioneCalendario>(ShowEditProgettazioneCalendario));
            
        }
        private void ShowEditProgettazioneCalendario(ShowEditProgettazioneCalendario obj)
        {
            Storyboard sb;
            if (obj.bShow)
            {
                //sb = this.FindResource("OpenEditProgettazioneCalendario") as Storyboard;
                this.ElencoViewPC.Visibility = Visibility.Collapsed;
                this.EditViewPC.Visibility = Visibility.Visible;

            }
            else
            {
                //  sb = this.FindResource("CloseEditProgettazioneCalendario") as Storyboard;
                this.ElencoViewPC.Visibility = Visibility.Visible;
                this.EditViewPC.Visibility = Visibility.Collapsed;
            }
            //sb.Begin();
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