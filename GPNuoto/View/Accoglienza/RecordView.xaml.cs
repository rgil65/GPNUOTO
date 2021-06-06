using System.Windows.Controls;

namespace GPNuoto
{
    /// <summary>
    /// Description for TesseraView.
    /// </summary>
    public partial class RecordView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the TesseraView class.
        /// </summary>
        public RecordView()
        {
            InitializeComponent();
        }

        private void StackPanel_IsMouseCapturedChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {

        }
    }
}