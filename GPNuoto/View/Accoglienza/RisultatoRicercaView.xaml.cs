using GPNuoto.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GPNuoto
{
    /// <summary>
    /// Description for RisultatoRicercaView.
    /// </summary>
    public partial class RisultatoRicercaView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the RisultatoRicercaView class.
        /// </summary>
        public RisultatoRicercaView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
            ((AnagraficaViewModel)this.DataContext).GotoAnagrafica.Execute(null);
        }
    }
}