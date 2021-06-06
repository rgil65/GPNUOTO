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
    public partial class ManagerTipoAttivitaView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerTipoAttivitaView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditTipoAttivitaCorsi>(this,
            new Action<ShowEditTipoAttivitaCorsi>(ShowEditTipoAttivitaCorsi));
        }
        private void ShowEditTipoAttivitaCorsi(ShowEditTipoAttivitaCorsi obj)
        {
            Storyboard sb;
            if (obj.bShow)
                sb = this.FindResource("OpenEditTipoAttivita") as Storyboard;
            else
                sb = this.FindResource("CloseEditTipoAttivita") as Storyboard;
            sb.Begin();
        }
    }
}