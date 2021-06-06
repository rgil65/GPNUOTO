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
    public partial class ManagerTabellaUtentiView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerTabellaUtentiView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditUtenti>(this,new Action<ShowEditUtenti>(ShowEditUtenti));
        }
        private void ShowEditUtenti(ShowEditUtenti obj)
        {
            Storyboard sb;
            if (obj.bShow)
                sb = this.FindResource("OpenEditUtenti") as Storyboard;
            else
                sb = this.FindResource("CloseEditUtenti") as Storyboard;
            sb.Begin();
        }
    }
}