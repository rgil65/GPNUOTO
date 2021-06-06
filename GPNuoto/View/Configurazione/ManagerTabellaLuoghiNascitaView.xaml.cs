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
    public partial class ManagerTabellaLuoghiNascitaView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerTabellaLuoghiNascitaView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditLuogoNascita>(this,
            new Action<ShowEditLuogoNascita>(ShowEditLuogoNascita));
        }
        private void ShowEditLuogoNascita(ShowEditLuogoNascita obj)
        {
            Storyboard sb;
            if (obj.bShow)
                sb = this.FindResource("OpenEditLuogoNascita") as Storyboard;
            else
                sb = this.FindResource("CloseEditLuogoNascita") as Storyboard;
            sb.Begin();
        }
    }
}