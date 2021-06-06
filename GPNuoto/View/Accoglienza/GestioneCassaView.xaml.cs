using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using System;
using System.Windows.Controls;

namespace GPNuoto
{
    /// <summary>
    /// Description for GestioneCassaView.
    /// </summary>
    public partial class GestioneCassaView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the GestioneCassaView class.
        /// </summary>
        public GestioneCassaView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowMessageBoxView>(this,new Action<ShowMessageBoxView>(ShowMessageViewExecute));
        }

        private void ShowMessageViewExecute(ShowMessageBoxView obj)
        {
            MessageboxView dlg = new MessageboxView(this, MessageboxView.TipoMessaggio.CustomMessage, obj.sMessaggio);
            if ((bool)dlg.ShowDialog())
            {
                
                if (SimpleIoc.Default.GetInstance<CassaViewModel>().IsCassaOpen)
                    SimpleIoc.Default.GetInstance<CassaViewModel>().ChiudiCassa.Execute(null);
                else
                    SimpleIoc.Default.GetInstance<CassaViewModel>().ApriCassa.Execute(null);
            }
        }
    
        private void btnCambiaData_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            SelezioneDataDaCalendarioView CambiaDataView = new SelezioneDataDaCalendarioView(this);
            CambiaDataView.ShowDialog();
        }
    }
}