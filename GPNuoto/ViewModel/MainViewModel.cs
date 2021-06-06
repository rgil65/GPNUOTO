using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.IO;
using System.IO.Packaging;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;
using System.Windows.Xps.Serialization;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            //LoginView logView = new LoginView();
            //if (!(bool)logView.ShowDialog())
            //Application.Current.Shutdown();
            //SimpleIoc.Default.GetInstance<UtentiViewModel>().Login.Execute("gilberto");
            SimpleIoc.Default.GetInstance<UtentiViewModel>().Login.Execute(null);

        }
        private RelayCommand _chiudiApplicazione;

        /// <summary>
        /// Gets the ChiudiApplicazione.
        /// </summary>
        public RelayCommand ChiudiApplicazione
        {
            get
            {
                return _chiudiApplicazione
                    ?? (_chiudiApplicazione = new RelayCommand(
                    () =>
                    {
                        Application.Current.Shutdown();
                    }));
            }
        }


        public static void DoThePrint(System.Windows.Documents.FlowDocument document)
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
            System.Printing.PrintDocumentImageableArea ia = null;
            System.Windows.Xps.XpsDocumentWriter docWriter = System.Printing.PrintQueue.CreateXpsDocumentWriter(ref ia);

            if (docWriter != null && ia != null)
            {
                DocumentPaginator paginator = ((IDocumentPaginatorSource)copy).DocumentPaginator;

                // Change the PageSize and PagePadding for the document to match the CanvasSize for the printer device.
                paginator.PageSize = new Size(ia.MediaSizeWidth, ia.MediaSizeHeight);
                Thickness t = new Thickness(72);  // copy.PagePadding;
                copy.PagePadding = new Thickness(
                                 Math.Max(ia.OriginWidth, t.Left),
                                   Math.Max(ia.OriginHeight, t.Top),
                                   Math.Max(ia.MediaSizeWidth - (ia.OriginWidth + ia.ExtentWidth), t.Right),
                                   Math.Max(ia.MediaSizeHeight - (ia.OriginHeight + ia.ExtentHeight), t.Bottom));

                copy.ColumnWidth = double.PositiveInfinity;
                //copy.PageWidth = 528; // allow the page to be the natural with of the output device

                // Send content to the printer.
                docWriter.Write(paginator);
            }

        }
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        public static int SaveAsXps(string fileName)

        {

            object doc;



            FileInfo fileInfo = new FileInfo(fileName);



            using (FileStream file = fileInfo.OpenRead())

            {

                System.Windows.Markup.ParserContext context = new System.Windows.Markup.ParserContext();

                context.BaseUri = new Uri(fileInfo.FullName, UriKind.Absolute);

                doc = System.Windows.Markup.XamlReader.Load(file, context);

            }



            if (!(doc is IDocumentPaginatorSource))

            {

                Console.WriteLine("DocumentPaginatorSource expected");

                return -1;

            }



            using (Package container = Package.Open(fileName + ".xps", FileMode.Create))

            {

                using (XpsDocument xpsDoc = new XpsDocument(container, CompressionOption.Maximum))

                {

                    XpsSerializationManager rsm = new XpsSerializationManager(new XpsPackagingPolicy(xpsDoc), false);



                    DocumentPaginator paginator = ((IDocumentPaginatorSource)doc).DocumentPaginator;



                    // 8 inch x 6 inch, with half inch margin

                    paginator = new DocumentPaginatorWrapper(paginator, new Size(768, 676), new Size(48, 48));



                    rsm.SaveAsXaml(paginator);

                }

            }



            Console.WriteLine("{0} generated.", fileName + ".xps");



            return 0;

        }
    }
}