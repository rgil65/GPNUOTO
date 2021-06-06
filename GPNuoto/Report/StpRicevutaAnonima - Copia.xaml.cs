using GPNuoto.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPNuoto.Report
{
    /// <summary>
    /// Logica di interazione per StpRicevuta.xaml
    /// </summary>
    public partial class StpRicevutaAnonima : UserControl
    {
        public StpRicevutaAnonima()
        {
            InitializeComponent();
        }

        public void PrintRicevuta()
        {

            // DoThePrint(this.Flow);
            Print(this.Ricevuta);

        }

        private void DoThePrint(System.Windows.Documents.FlowDocument document)
        {
            // Clone the source document's content into a new FlowDocument.
            // This is because the pagination for the printer needs to be
            // done differently than the pagination for the displayed page.
            // We print the copy, rather that the original FlowDocument.
            System.IO.MemoryStream s = new System.IO.MemoryStream();
            TextRange source = new TextRange(document.ContentStart, document.ContentEnd);
            source.Save(s, DataFormats.Xaml);
            FlowDocument copy = new FlowDocument();
            TextRange dest = new TextRange(copy.ContentStart, copy.ContentEnd);
            dest.Load(s, DataFormats.Xaml);

            // Create a XpsDocumentWriter object, implicitly opening a Windows common print dialog,
            // and allowing the user to select a printer.

            // get information about the dimensions of the seleted printer+media.
            //System.Printing.PrintDocumentImageableArea ia = null;


            string StampanteDefault = ServiceLocator.Current.GetInstance<ImpostazioniViewModel>().StampanteRicevuta;
            PrintDialog pd = new PrintDialog();
            if (StampanteDefault != string.Empty)
            {
                LocalPrintServer printServer = new LocalPrintServer();
                pd.PrintQueue = printServer.GetPrintQueue(StampanteDefault);
            }


            if (pd.PrintQueue != null || pd.ShowDialog() == true)
            {

                pd.PrintTicket.PageOrientation = PageOrientation.Portrait;
                PrintCapabilities pc = pd.PrintQueue.GetPrintCapabilities(pd.PrintTicket);
                System.Windows.Xps.XpsDocumentWriter docWriter = PrintQueue.CreateXpsDocumentWriter(pd.PrintQueue);
                DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;
                double PZW = 0;
                double PZH = 0;
                double OW = 0;
                double OH = 0;
                double EW = 0;
                double EH = 0;
                PZW = (double)pd.PrintQueue.DefaultPrintTicket.PageMediaSize.Width;
                PZH = (double)pd.PrintQueue.DefaultPrintTicket.PageMediaSize.Height;
                OW = pc.PageImageableArea.OriginWidth;
                OW = pc.PageImageableArea.OriginHeight;
                EW = pc.PageImageableArea.ExtentWidth;
                EH = pc.PageImageableArea.ExtentHeight;
                // Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
                paginator.PageSize = new Size(PZW, PZH);


                Thickness t = new Thickness(72);  // copy.PagePadding;
                copy.PagePadding = new Thickness(
                                 Math.Max(OW, t.Left),
                                   Math.Max(OH, t.Top),
                                   Math.Max(PZW - (OW + EW), t.Right),
                                   Math.Max(PZH - (OH + EH), t.Bottom));

                copy.ColumnWidth = double.PositiveInfinity;
                //copy.PageWidth = 528; // allow the page to be the natural with of the output device

                // Send content to the printer.
                docWriter.Write(paginator, pd.PrintTicket);
            }
        }
        private void Print(Visual v)
        {

            System.Windows.FrameworkElement e = v as System.Windows.FrameworkElement;
            if (e == null)
                return;

            string StampanteDefault = ServiceLocator.Current.GetInstance<ImpostazioniViewModel>().StampanteRicevuta;
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
                pd.PrintVisual(v, "Ricevuta");

                //apply the original transform.
                e.LayoutTransform = originalScale;
            }
        }

    }
}
