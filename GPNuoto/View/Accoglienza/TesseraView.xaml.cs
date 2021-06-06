using GPNuoto.Model;
using GPNuoto.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml;

namespace GPNuoto
{
    /// <summary>
    /// Description for TesseraView.
    /// </summary>
    public partial class TesseraView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the TesseraView class.
        /// </summary>
        public TesseraView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<StampaBadge>(this,
           new Action<StampaBadge>(StampaBadgeEsegui));
        }

        private void StampaBadgeEsegui(StampaBadge obj)
        {
            Print(this.Badge);
        }


        private void Print(Visual v)
        {

            System.Windows.FrameworkElement e = v as System.Windows.FrameworkElement;
            if (e == null)
                return;

            string StampanteDefault = ServiceLocator.Current.GetInstance<ImpostazioniViewModel>().StampanteBadge;
            PrintDialog pd = new PrintDialog();
            if (StampanteDefault != string.Empty)
            {
                LocalPrintServer printServer = new LocalPrintServer();
                pd.PrintQueue = printServer.GetPrintQueue(StampanteDefault);
            } 


            if (pd.PrintQueue != null || pd.ShowDialog() == true)
            {
                // Landscape forzatura
                pd.PrintTicket.PageOrientation = PageOrientation.Landscape;

                //store original scale
                Transform originalScale = e.LayoutTransform;
                //get selected printer capabilities
                System.Printing.PrintCapabilities capabilities = pd.PrintQueue.GetPrintCapabilities(pd.PrintTicket);

                //get scale of the print wrt to screen of WPF visual
                double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / e.ActualWidth, capabilities.PageImageableArea.ExtentHeight /
                               e.ActualHeight);

                //Transform the Visual to scale
                e.LayoutTransform = new ScaleTransform(scale, scale);

                //get the size of the printer page
                System.Windows.Size sz = new System.Windows.Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

                //update the layout of the visual to the printer page size.
                e.Measure(sz);
                e.Arrange(new System.Windows.Rect(new System.Windows.Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));

                //now print the visual to printer to fit on the one page.
                pd.PrintVisual(v, "Tessera");

                //apply the original transform.
                e.LayoutTransform = originalScale;
            }
        }
    }
}