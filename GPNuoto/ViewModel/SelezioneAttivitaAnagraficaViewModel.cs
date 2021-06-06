using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GPNuoto.Model;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SelezioneAnagraficaAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SelezioneAnagraficaAttivitaViewModel class.
        /// </summary>
        /// 
        private IDataService dataservice;

        public SelezioneAnagraficaAttivitaViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                TipoAttivitaViewModel ta = new TipoAttivitaViewModel();
                ta.Titolo = "PROVA";
                ta.BackgroundColor = "Red";
                ta.ForegroundColor = "Black";
                TipoAttivita = ta;
                ElencoCorsiSelezionati = dataservice.GetElencoCorsiAttivi(1);
            }
            IsCheckedDay.CollectionChanged += IsCheckedDay_CollectionChanged;

        }

        private void IsCheckedDay_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (IsFiltraggioAttivo)
                RefreshFiltro();
        }



        /// <summary>
        /// The <see cref="TipoAttivita" /> property's name.
        /// </summary>
        public const string TipoAttivitaPropertyName = "TipoAttivita";

        private TipoAttivitaViewModel _TipoAttivitaViewModel = null;

        /// <summary>
        /// Sets and gets the TipoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TipoAttivitaViewModel TipoAttivita
        {
            get
            {
                return _TipoAttivitaViewModel;
            }

            set
            {
                if (_TipoAttivitaViewModel == value)
                {
                    return;
                }

                _TipoAttivitaViewModel = value;
                if (_TipoAttivitaViewModel != null)
                {
                    /*_elencoCorsiAttivi.Clear();
                    foreach (InfoCorsoViewModel icv in dataservice.GetElencoCorsiAttivi(TipoAttivita.ID))
                        _elencoCorsiAttivi.Add(icv);
                    RaisePropertyChanged(ElencoCorsiAttiviPropertyName);*/
                    ElencoCorsiAttivi = dataservice.GetElencoCorsiAttivi(TipoAttivita.ID);
                }
                RaisePropertyChanged(TipoAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoCorsiAttivi" /> property's name.
        /// </summary>
        public const string ElencoCorsiAttiviPropertyName = "ElencoCorsiAttivi";

        private List<ROAttivitaViewModel> _elencoCorsiAttivi = null;

        /// <summary>
        /// Sets and gets the ElencoCorsiAttivi property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ROAttivitaViewModel> ElencoCorsiAttivi
        {
            get
            {
                return _elencoCorsiAttivi;
            }

            set
            {
                if (_elencoCorsiAttivi == value)
                {
                    return;
                }

                _elencoCorsiAttivi = value;
                ImpostaFiltri();
                RaisePropertyChanged(ElencoCorsiAttiviPropertyName);
            }
        }
        
        /// <summary>
        /// The <see cref="ElencoCorsiSelezionati" /> property's name.
        /// </summary>
        public const string ElencoCorsiSelezionatiPropertyName = "ElencoCorsiSelezionati";

        private List<ROAttivitaViewModel> _elencoCorsiSelezionati = null;

        /// <summary>
        /// Sets and gets the ElencoCorsiSelezionati property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ROAttivitaViewModel> ElencoCorsiSelezionati
        {
            get
            {
                return _elencoCorsiSelezionati;
            }

            set
            {
                if (_elencoCorsiSelezionati == value)
                {
                    return;
                }

                _elencoCorsiSelezionati = value;
                RaisePropertyChanged(ElencoCorsiSelezionatiPropertyName);
            }
        }

        void ImpostaFiltri()
        {
            IsFiltraggioAttivo = false;
            IsTipoFisso = IsTipoAbbonamento = IsTipoSingolo = true;
            for (int i = 0; i < 7; i++) IsEnabledDay[i] = true;

            TimeSpan Max = new TimeSpan(0);
            TimeSpan Min = new TimeSpan(24, 0, 0);
            // Imposto il filtraggio 
            foreach (ROAttivitaViewModel roavm in ElencoCorsiAttivi)
            {
                // Tipo
                if (!IsEnabledSingolo)
                    IsEnabledSingolo = (roavm.Corso.TipoCorso == CorsoViewModel.TipoCorsoValue.Singolo);

                if (!IsEnabledAbbonamento)
                    IsEnabledAbbonamento = (roavm.Corso.TipoCorso == CorsoViewModel.TipoCorsoValue.Abbonamento);

                if (!IsEnabledFisso)
                    IsEnabledFisso = (roavm.Corso.TipoCorso == CorsoViewModel.TipoCorsoValue.Fisso);
                // Giorni     // Orario

                foreach (OrarioCorsoViewModel oc in roavm.Corso.DettaglioOrari)
                {
                    if (!IsEnabledDay[(int) oc.GiornoSettimana])
                        IsEnabledDay[(int) oc.GiornoSettimana] = true;
                    if (oc.OraInizio < Min)
                        Min = oc.OraInizio;
                    if (oc.OraFine > Max)
                        Max = oc.OraFine;
                }
                OraMinimo = Min;
                OraMassimo = Max;
            }

            ElencoCorsiSelezionati = ElencoCorsiAttivi.Where(p => !p.IsFiltrata).OrderBy(o=>o.Titolo).ToList();
            IsFiltraggioAttivo = true;
        }

        public  void RefreshFiltro()
        {
            List<int> GiorniValidi = new List<int>();
            for (int i = 0; i <= 6; i++)
                if (IsCheckedDay[i])
                    GiorniValidi.Add(i);


            if (IsFiltraggioAttivo && ElencoCorsiAttivi != null)
            {

                for (int i = 0; i < ElencoCorsiAttivi.Count(); i++)
                {
                    ElencoCorsiAttivi[i].IsFiltrata = false;
                    // Tipo
                    if (!IsTipoSingolo && ElencoCorsiAttivi[i].Corso.TipoCorso == CorsoViewModel.TipoCorsoValue.Singolo)
                    {
                        ElencoCorsiAttivi[i].IsFiltrata = true;
                        continue;
                    }
                    if (!IsTipoFisso && ElencoCorsiAttivi[i].Corso.TipoCorso == CorsoViewModel.TipoCorsoValue.Fisso)
                    {
                        ElencoCorsiAttivi[i].IsFiltrata = true;
                        continue;
                    }

                    if (!IsTipoAbbonamento && ElencoCorsiAttivi[i].Corso.TipoCorso == CorsoViewModel.TipoCorsoValue.Abbonamento)
                    {
                        ElencoCorsiAttivi[i].IsFiltrata = true;
                        continue;
                    }
                    // FILTRO GIORNALIERO // ORARIO
                    if (ElencoCorsiAttivi[i].Corso.DettaglioOrari.Count() != 0)
                    {
                        List<int> GiorniCorso = new List<int>();
                        List<int> OrariCorso = new List<int>();  
                        foreach (OrarioCorsoViewModel oc in ElencoCorsiAttivi[i].Corso.DettaglioOrari)
                        {
                                GiorniCorso.Add((int) oc.GiornoSettimana);
                                // FILTRO ORARI 
                                if (FiltroOraMinimo <= oc.OraInizio && FiltroOraMassimo >= oc.OraFine)
                                    OrariCorso.Add((int) oc.GiornoSettimana);

                        }
                        ElencoCorsiAttivi[i].IsFiltrata = GiorniCorso.Intersect(GiorniValidi).Count() == 0;
                       if (!ElencoCorsiAttivi[i].IsFiltrata)
                            ElencoCorsiAttivi[i].IsFiltrata = OrariCorso.Intersect(GiorniValidi).Count() == 0; 
                        
                    } else
                        ElencoCorsiAttivi[i].IsFiltrata = true;
                }
                ElencoCorsiSelezionati = null;
                ElencoCorsiSelezionati = ElencoCorsiAttivi.Where(p => !p.IsFiltrata).OrderBy(o=>o.Titolo).ToList();
            }
        }


        /// <summary>
        /// The <see cref="IsFiltraggioAttivo" /> property's name.
        /// </summary>
        public const string IsFiltraggioAttivoPropertyName = "IsFiltraggioAttivo";

        private bool _isFiltraggioAttivo = false;

        /// <summary>
        /// Sets and gets the IsFiltraggioAttivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsFiltraggioAttivo
        {
            get
            {
                return _isFiltraggioAttivo;
            }

            set
            {
                if (_isFiltraggioAttivo == value)
                {
                    return;
                }

                _isFiltraggioAttivo = value;
                RaisePropertyChanged(IsFiltraggioAttivoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsTipoSingolo" /> property's name.
        /// </summary>
        public const string IsTipoSingoloPropertyName = "IsTipoSingolo";

        private bool _isTipoSingolo = true;

        /// <summary>
        /// Sets and gets the IsEnabledSingolo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsTipoSingolo
        {
            get
            {
                return _isTipoSingolo;
            }

            set
            {
                if (_isTipoSingolo == value)
                {
                    return;
                }

                _isTipoSingolo = value;
                if (IsFiltraggioAttivo)
                    RefreshFiltro();
                RaisePropertyChanged(IsTipoSingoloPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsTipoAbbonamento" /> property's name.
        /// </summary>
        public const string IsTipoAbbonamentoPropertyName = "IsTipoAbbonamento";

        private bool _isTipoAbbonamento = true;

        /// <summary>
        /// Sets and gets the IsEnabledAbbonamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsTipoAbbonamento
        {
            get
            {
                return _isTipoAbbonamento;
            }

            set
            {
                if (_isTipoAbbonamento == value)
                {
                    return;
                }

                _isTipoAbbonamento = value;
                if (IsFiltraggioAttivo)
                    RefreshFiltro();
                RaisePropertyChanged(IsTipoAbbonamentoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="IsTipoFisso" /> property's name.
        /// </summary>
        public const string IsTipoFissoPropertyName = "IsTipoFisso";

        private bool _isTipoFisso = true;

        /// <summary>
        /// Sets and gets the IsEnabledFisso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsTipoFisso
        {
            get
            {
                return _isTipoFisso;
            }

            set
            {
                if (_isTipoFisso == value)
                {
                    return;
                }

                _isTipoFisso = value;
                if (IsFiltraggioAttivo)
                    RefreshFiltro();
                RaisePropertyChanged(IsTipoFissoPropertyName);
            }
        }




        /// <summary>
        /// The <see cref="IsEnabledSingolo" /> property's name.
        /// </summary>
        public const string IsEnabledSingoloPropertyName = "IsEnabledSingolo";

        private bool _isEnabledSingolo = false;

        /// <summary>
        /// Sets and gets the IsEnabledSingolo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsEnabledSingolo
        {
            get
            {
                return _isEnabledSingolo;
            }

            set
            {
                if (_isEnabledSingolo == value)
                {
                    return;
                }

                _isEnabledSingolo = value;
           
                RaisePropertyChanged(IsEnabledSingoloPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsEnabledAbbonamento" /> property's name.
        /// </summary>
        public const string IsEnabledAbbonamentoPropertyName = "IsEnabledAbbonamento";

        private bool _isEnabledAbbonamento = false;

        /// <summary>
        /// Sets and gets the IsEnabledAbbonamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsEnabledAbbonamento
        {
            get
            {
                return _isEnabledAbbonamento;
            }

            set
            {
                if (_isEnabledAbbonamento == value)
                {
                    return;
                }

                _isEnabledAbbonamento = value;
     
                RaisePropertyChanged(IsEnabledAbbonamentoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="IsEnabledFisso" /> property's name.
        /// </summary>
        public const string IsEnabledFissoPropertyName = "IsEnabledFisso";

        private bool _isEnabledFisso = false;

        /// <summary>
        /// Sets and gets the IsEnabledFisso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsEnabledFisso
        {
            get
            {
                return _isEnabledFisso;
            }

            set
            {
                if (_isEnabledFisso == value)
                {
                    return;
                }

                _isEnabledFisso = value;
                RaisePropertyChanged(IsEnabledFissoPropertyName);
            }
        }

        


        /// <summary>
        /// The <see cref="IsEnabledDay" /> property's name.
        /// </summary>
        public const string IsEnabledDayPropertyName = "IsEnabledDay";

        private ObservableCollection<bool> _isEnabledDay = new ObservableCollection<bool>(){ false, false, false, false, false, false, false };

        /// <summary>
        /// Sets and gets the IsEnabledDay property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<bool> IsEnabledDay
        {
            get
            {
                return _isEnabledDay;
            }

            set
            {
                if (_isEnabledDay == value)
                {
                    return;
                }

                _isEnabledDay = value;
                RaisePropertyChanged(IsEnabledDayPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsCheckedDay" /> property's name.
        /// </summary>
        public const string IsCheckedDayPropertyName = "IsCheckedDay";

        private ObservableCollection<bool> _isCheckedDay = new ObservableCollection<bool>() { true, true, true, true, true, true, true };

        /// <summary>
        /// Sets and gets the IsEnabledDay property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<bool> IsCheckedDay
        {
            get
            {
                return _isCheckedDay;
            }

            set
            {
                if (_isCheckedDay == value)
                {
                    return;
                }

                _isCheckedDay = value;
                RaisePropertyChanged(IsCheckedDayPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="OraMinimo" /> property's name.
        /// </summary>
        public const string OraMinimoPropertyName = "OraMinimo";

        private TimeSpan _oraMinimo = new TimeSpan(0);

        /// <summary>
        /// Sets and gets the OraMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan OraMinimo
        {
            get
            {
                return _oraMinimo;
            }

            set
            {
                if (_oraMinimo == value)
                {
                    return;
                }

                _oraMinimo = value;
                RangeMinimo = (int)_oraMinimo.TotalMinutes/15;
                RaisePropertyChanged(OraMinimoPropertyName);
            }
        }

    

        /// <summary>
        /// The <see cref="OraMassimo" /> property's name.
        /// </summary>
        public const string OraMassimoPropertyName = "OraMassimo";

        private TimeSpan _oraMassimo = new TimeSpan(24, 0, 0);

        /// <summary>
        /// Sets and gets the OraMassimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan OraMassimo
        {
            get
            {
                return _oraMassimo;
            }

            set
            {
                if (_oraMassimo == value)
                {
                    return;
                }

                _oraMassimo = value;
                RangeMassimo = (int) _oraMassimo.TotalMinutes/15;
                RaisePropertyChanged(OraMassimoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="FiltroOraMassimo" /> property's name.
        /// </summary>
        public const string FiltroOraMassimoPropertyName = "FiltroOraMassimo";

        private TimeSpan _filtrooraMassimo = new TimeSpan(24, 0, 0);

        /// <summary>
        /// Sets and gets the OraMassimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan FiltroOraMassimo
        {
            get
            {
                return _filtrooraMassimo;
            }

            set
            {
                if (_filtrooraMassimo == value)
                {
                    return;
                }

                _filtrooraMassimo = value;
                RaisePropertyChanged(FiltroOraMassimoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="FiltroOraMinimo" /> property's name.
        /// </summary>
        public const string FiltroOraMinimoPropertyName = "FiltroOraMinimo";

        private TimeSpan _filtrooraMinimo = new TimeSpan(0);

        /// <summary>
        /// Sets and gets the OraMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan FiltroOraMinimo
        {
            get
            {
                return _filtrooraMinimo;
            }

            set
            {
                if (_filtrooraMinimo == value)
                {
                    return;
                }

                _filtrooraMinimo = value;
                RaisePropertyChanged(FiltroOraMinimoPropertyName);
            }
        }




        /// <summary>
        /// The <see cref="RangeMinimo" /> property's name.
        /// </summary>
        public const string RangeMinimoPropertyName = "RangeMinimo";

        private int _rangeMinimo = 0;

        /// <summary>
        /// Sets and gets the RangeMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int RangeMinimo
        {
            get
            {
                return _rangeMinimo;
            }

            set
            {
                if (_rangeMinimo == value)
                {
                    return;
                }

                _rangeMinimo = value;
                FiltroRangeMinimo = _rangeMinimo;
                RaisePropertyChanged(RangeMinimoPropertyName);
            }
        }

       

        /// <summary>
        /// The <see cref="RangeMassimo" /> property's name.
        /// </summary>
        public const string RangeMassimoPropertyName = "RangeMassimo";

        private int _rangeMassimo = 0;

        /// <summary>
        /// Sets and gets the RangeMassimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int RangeMassimo
        {
            get
            {
                return _rangeMassimo;
            }

            set
            {
                if (_rangeMassimo == value)
                {
                    return;
                }

                _rangeMassimo = value;
                FiltroRangeMassimo = _rangeMassimo;
                RaisePropertyChanged(RangeMassimoPropertyName);
            }

        }


        /// <summary>
        /// The <see cref="FiltroRangeMassimo" /> property's name.
        /// </summary>
        public const string FiltroRangeMassimoPropertyName = "FiltroRangeMassimo";

        private int _filtrorangeMassimo = 0;

        /// <summary>
        /// Sets and gets the FiltroRangeMassimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FiltroRangeMassimo
        {
            get
            {
                return _filtrorangeMassimo;
            }

            set
            {
                if (_filtrorangeMassimo == value)
                {
                    return;
                }

                _filtrorangeMassimo = value;
                FiltroOraMassimo = TimeSpan.FromMinutes(_filtrorangeMassimo*15);
                if (IsFiltraggioAttivo)
                    RefreshFiltro();
                RaisePropertyChanged(FiltroRangeMassimoPropertyName);
            }
        }




        /// <summary>
        /// The <see cref="FiltroRangeMinimo" /> property's name.
        /// </summary>
        public const string FiltroRangeMinimoPropertyName = "FiltroRangeMinimo";

        private int _filtrorangeMinimo = 0;

        /// <summary>
        /// Sets and gets the FiltroRangeMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FiltroRangeMinimo
        {
            get
            {
                return _filtrorangeMinimo;
            }

            set
            {
                if (_filtrorangeMinimo == value)
                {
                    return;
                }

                _filtrorangeMinimo = value;
                FiltroOraMinimo = TimeSpan.FromMinutes(_filtrorangeMinimo*15);
                if (IsFiltraggioAttivo)
                    RefreshFiltro();
                RaisePropertyChanged(FiltroRangeMinimoPropertyName);
            }
        }



        /// <summary>
        /// The <see cref="TitoloCorsoSelezionato" /> property's name.
        /// </summary>
        public const string TitoloCorsoSelezionatoPropertyName = "TitoloCorsoSelezionato";

        private string _titoloCorsoSelezionato = "Corsi Attivi";

        /// <summary>
        /// Sets and gets the TitoloCorsoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TitoloCorsoSelezionato
        {
            get
            {
                return _titoloCorsoSelezionato;
            }

            set
            {
                if (_titoloCorsoSelezionato == value)
                {
                    return;
                }

                _titoloCorsoSelezionato = value;
                RaisePropertyChanged(TitoloCorsoSelezionatoPropertyName);
            }
        }


      
        private RelayCommand _tornaSelezioneTipoAttivita;

        /// <summary>
        /// Gets the TornaSelezioneTipoAttivita.
        /// </summary>
        public RelayCommand TornaSelezioneTipoAttivita
        {
            get
            {
                return _tornaSelezioneTipoAttivita
                    ?? (_tornaSelezioneTipoAttivita = new RelayCommand(
                    () =>
                    {
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowSelezioneAttivita = false;
                    }));
            }
        }
        private RelayCommand _annullaSelezioneAttivita;

        /// <summary>
        /// Gets the TornaSelezioneTipoAttivita.
        /// </summary>
        public RelayCommand AnnullaSelezioneAttivita
        {
            get
            {
                return _annullaSelezioneAttivita
                    ?? (_annullaSelezioneAttivita = new RelayCommand(
                    () =>
                    {
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowSelezioneTipoAttivita = false;
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowSelezioneAttivita = false;
                    }));
            }
        }



        private RelayCommand<int> _selezionaAttivita;

        /// <summary>
        /// Gets the SelezionaAttivita.
        /// </summary>
        public RelayCommand<int> SelezionaAttivita
        {
            get
            {
                return _selezionaAttivita
                    ?? (_selezionaAttivita = new RelayCommand<int>(
                    p =>
                    {

                        AnnullaSelezioneAttivita.Execute(null);
                        SimpleIoc.Default.GetInstance<AnagraficaAttivitaViewModel>().AddAttivita.Execute(p);
                        


                    }));
            }
        }

        private RelayCommand<int> _displayInfoAttivita;

        /// <summary>
        /// Gets the DisplayInfoAttivita.
        /// </summary>
        public RelayCommand<int> DisplayInfoAttivita
        {
            get
            {
                return _displayInfoAttivita
                    ?? (_displayInfoAttivita = new RelayCommand<int>(
                     p =>
                    {
                        MessageBox.Show("IMPLEMENTARE VISUALIZZAZIONE INFORMAZIONI COME COSTI, NUMERI PARTECIPANTi, ECC");
                    }));
            }
        }
      

    }
}