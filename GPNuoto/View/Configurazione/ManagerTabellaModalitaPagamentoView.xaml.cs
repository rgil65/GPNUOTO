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
    public partial class ManagerTabellaModalitaPagamentoView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the ManagerTabellaModalitaPagamentoView class.
        /// </summary>
        public ManagerTabellaModalitaPagamentoView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditModalitaPagamento>(this,
            new Action<ShowEditModalitaPagamento>(ShowEditModalitaPagamento));
        }
        private void ShowEditModalitaPagamento(ShowEditModalitaPagamento obj)
        {
            Storyboard sb;
            if (obj.bShow)
                sb = this.FindResource("OpenEditModalitaPagamento") as Storyboard;
            else
                sb = this.FindResource("CloseEditModalitaPagamento") as Storyboard;
            sb.Begin();
        }
    }
}