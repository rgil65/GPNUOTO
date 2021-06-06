using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for ManagerTabellaModalitaPagamentoView.
    /// </summary>
    public partial class ManagerTabellaCodiciContabiliView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerTabellaCodiciContabiliView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditCodiciContabili>(this,
            new Action<ShowEditCodiciContabili>(ShowEditCodiciContabili));
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowGestioneCodiciContabili>(this,
           new Action<ShowGestioneCodiciContabili>(ShowGestioneCodiciContabili));
        }
        private void ShowEditCodiciContabili(ShowEditCodiciContabili obj)
        {
            Storyboard sb;
            if (obj.bShow)
                sb = this.FindResource("OpenEditCodiciContabili") as Storyboard;
            else
                sb = this.FindResource("CloseEditCodiciContabili") as Storyboard;
            sb.Begin();
        }

        private void ShowGestioneCodiciContabili(ShowGestioneCodiciContabili obj)
        {
            ManagerDettagliCodiciContabiliView cv = new ManagerDettagliCodiciContabiliView(this);
            CodiciContabiliDettagliViewModel cc = new CodiciContabiliDettagliViewModel();
            cc.CodiceContabile = obj.CodiceContabile;
            cv.DataContext = cc;
            cv.ShowDialog();
        }
    }
}