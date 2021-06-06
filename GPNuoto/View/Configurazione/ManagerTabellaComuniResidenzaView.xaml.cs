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
    public partial class ManagerTabellaComuniResidenzaView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerTabellaComuniResidenzaView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditComuneResidenza>(this,
            new Action<ShowEditComuneResidenza>(ShowEditComuneResidenza));
        }
        private void ShowEditComuneResidenza(ShowEditComuneResidenza obj)
        {
            Storyboard sb;
            if (obj.bShow)
                sb = this.FindResource("OpenEditComuneResidenza") as Storyboard;
            else
                sb = this.FindResource("CloseEditComuneResidenza") as Storyboard;
            sb.Begin();
        }
    }
}