/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:GPNuoto.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GPNuoto.Model;
using GPNuoto.Design;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AnagraficaViewModel>();
            SimpleIoc.Default.Register<ResultSetAnagraficaViewModel>();
            SimpleIoc.Default.Register<AnagraficaAttivitaViewModel>();
            SimpleIoc.Default.Register<PagamentiViewModel>();
            SimpleIoc.Default.Register<SelezioneTipoAttivitaViewModel>();
            SimpleIoc.Default.Register<SelezioneAnagraficaAttivitaViewModel>();
            SimpleIoc.Default.Register<UtentiViewModel>();
            SimpleIoc.Default.Register<StampaRicevutaViewModel>();
            SimpleIoc.Default.Register<MovimentiViewModel>();
            SimpleIoc.Default.Register<CassaViewModel>();
            SimpleIoc.Default.Register<TesseraViewModel>();
            SimpleIoc.Default.Register<CalendarManagerViewModel>();
            SimpleIoc.Default.Register<SingoloUtenteViewModel>();
            SimpleIoc.Default.Register<CodiciContabiliViewModel>();
            SimpleIoc.Default.Register<TableModalitaPagamentoViewModel>();
            SimpleIoc.Default.Register<TableLuoghiNascitaViewModel>();
            SimpleIoc.Default.Register<TableComuniResidenzaViewModel>();
            SimpleIoc.Default.Register<TableUtentiViewModel>();
            SimpleIoc.Default.Register<TableTipoAttivitaViewModel>();
            SimpleIoc.Default.Register<RegistroCassaViewModel>();
            SimpleIoc.Default.Register<FattureViewModel>();
            SimpleIoc.Default.Register<TrasferimentoMovimentiViewModel>();
            SimpleIoc.Default.Register<RiepilogoIscrizioniViewModel>();
            SimpleIoc.Default.Register<ManagerRiepiloghiPersonalizzatiViewModel>();
            SimpleIoc.Default.Register<ImpostazioniViewModel>();


        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public AnagraficaViewModel Anagrafica
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AnagraficaViewModel>();
            }
        }


        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ResultSetAnagraficaViewModel ResultSetVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ResultSetAnagraficaViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
           "CA1822:MarkMembersAsStatic",
           Justification = "This non-static member is needed for data binding purposes.")]
        public AnagraficaAttivitaViewModel Corsi
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AnagraficaAttivitaViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        "CA1822:MarkMembersAsStatic",
        Justification = "This non-static member is needed for data binding purposes.")]
        public PagamentiViewModel Pagamenti
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PagamentiViewModel>();
            }
        }

       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
     "CA1822:MarkMembersAsStatic",
     Justification = "This non-static member is needed for data binding purposes.")]
        public SelezioneTipoAttivitaViewModel SelezioneTipoAttivita
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelezioneTipoAttivitaViewModel>();
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
    "CA1822:MarkMembersAsStatic",
    Justification = "This non-static member is needed for data binding purposes.")]
        public SelezioneAnagraficaAttivitaViewModel SelezioneAttivita
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelezioneAnagraficaAttivitaViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public UtentiViewModel Utente
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UtentiViewModel>();
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public SingoloUtenteViewModel  CurrentUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SingoloUtenteViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public StampaRicevutaViewModel Ricevuta
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StampaRicevutaViewModel>();
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public MovimentiViewModel Movimenti
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MovimentiViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public TesseraViewModel Tessera
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TesseraViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public CassaViewModel Cassa
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CassaViewModel>();
            }
        }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public CalendarManagerViewModel CalendarManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CalendarManagerViewModel>();
            }
        }
       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public CodiciContabiliViewModel CodiciContabili
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CodiciContabiliViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public TableModalitaPagamentoViewModel ModalitaPagamento
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableModalitaPagamentoViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
         "CA1822:MarkMembersAsStatic",
         Justification = "This non-static member is needed for data binding purposes.")]
        public TableLuoghiNascitaViewModel TabellaLuoghiNascita
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableLuoghiNascitaViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
    "CA1822:MarkMembersAsStatic",
    Justification = "This non-static member is needed for data binding purposes.")]
        public TableComuniResidenzaViewModel TabellaComuniResidenza
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableComuniResidenzaViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public TableUtentiViewModel TabellaUtenti
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableUtentiViewModel>();
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public TableTipoAttivitaViewModel TabellaTipoAttivita
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TableTipoAttivitaViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public RegistroCassaViewModel RegistroCassa
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegistroCassaViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public FattureViewModel Fatture
        {
            get
            {
                return ServiceLocator.Current.GetInstance<FattureViewModel>();
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public TrasferimentoMovimentiViewModel TrasferimentoMovimenti
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TrasferimentoMovimentiViewModel>();
            }
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
"CA1822:MarkMembersAsStatic",
Justification = "This non-static member is needed for data binding purposes.")]
        public ImpostazioniViewModel Impostazioni
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ImpostazioniViewModel>();
            }
        }



        /// <summary>

        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }

    }
}