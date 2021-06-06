using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace GPNuoto.ViewModel
{
    public class SingolaDataAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="ID" /> property's name.
        /// </summary>
        public const string IDPropertyName = "ID";

        private int _id = -1;

        /// <summary>
        /// Sets and gets the ID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(IDPropertyName);
            }
        }
        /// <summary>4
        /// The <see cref="Inizio" /> property's name.
        /// </summary>
        public const string InizioPropertyName = "Inizio";

        private DateTime _Inizio = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime Inizio
        {
            get
            {
                return _Inizio;
            }

            set
            {
                if (_Inizio == value)
                {
                    return;
                }

                _Inizio = value;
                RaisePropertyChanged(InizioPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Fine" /> property's name.
        /// </summary>
        public const string FinePropertyName = "Fine";

        private DateTime _fine = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataFine property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime Fine
        {
            get
            {
                return _fine;
            }

            set
            {
                if (_fine == value)
                {
                    return;
                }

                _fine = value;
                RaisePropertyChanged(FinePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsAttivo" /> property's name.
        /// </summary>
        public const string IsAttivoPropertyName = "IsAttivo";

        private bool _isAttivo = false;

        /// <summary>
        /// Sets and gets the IsAttivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivo
        {
            get
            {
                return _isAttivo;
            }

            set
            {
                if (_isAttivo == value)
                {
                    return;
                }

                _isAttivo = value;
                RaisePropertyChanged(IsAttivoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsDataManuale" /> property's name.
        /// </summary>
        public const string IsDataManualePropertyName = "IsDataManuale";

        private bool _isDataManuale = false;

        /// <summary>
        /// Sets and gets the IsDataManuale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsDataManuale
        {
            get
            {
                return _isDataManuale;
            }

            set
            {
                if (_isDataManuale == value)
                {
                    return;
                }

                _isDataManuale = value;
                RaisePropertyChanged(IsDataManualePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsPresente" /> property's name.
        /// </summary>
        public const string IsPresentePropertyName = "IsPresente";

        private bool _isPresente = false;

        /// <summary>
        /// Sets and gets the IsPresente property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsPresente
        {
            get
            {
                return _isPresente;
            }

            set
            {
                if (_isPresente == value)
                {
                    return;
                }

                _isPresente = value;
                RaisePropertyChanged(IsPresentePropertyName);
            }
        }
    }
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingolaAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingolaAttivitaViewModel class.
        /// </summary>
        /// 

        IDataService dataservice;
        public SingolaAttivitaViewModel(IDataService ds)
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                Titolo = "Lun-Mar";

            }
            else
            {
                dataservice = ds;
                //CorsoEdit = cvm;
                //if (cvm != null)
                //    CalcolaElencoBlackDate();
            }
        }

        /// <summary>
        /// The <see cref="CanSave" /> property's name.
        /// </summary>
        public const string CanSavePropertyName = "CanSave";

        private bool _canSave = false;

        /// <summary>
        /// Sets and gets the CanSave property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanSave
        {
            get
            {
                return _canSave;
            }

            set
            {
                if (_canSave == value)
                {
                    return;
                }

                _canSave = value;
                RaisePropertyChanged(CanSavePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CanDelete" /> property's name.
        /// </summary>
        public const string CanDeletePropertyName = "CanDelete";

        private bool _canDelete = false;

        /// <summary>
        /// Sets and gets the CanDelete property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return _canDelete;
            }

            set
            {
                if (_canDelete == value)
                {
                    return;
                }

                _canDelete = value;
                RaisePropertyChanged(CanDeletePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CanSelezionareDate" /> property's name.
        /// </summary>
        public const string CanSelezionareDatePropertyName = "CanSelezionareDate";

        private bool _canSelezionareDate = false;

        /// <summary>
        /// Sets and gets the CanSelezionareDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanSelezionareDate
        {
            get
            {
                return _canSelezionareDate;
            }

            set
            {
                if (_canSelezionareDate == value)
                {
                    return;
                }

                _canSelezionareDate = value;
                RaisePropertyChanged(CanSelezionareDatePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IDCorso" /> property's name.
        /// </summary>
        public const string IDCorsoPropertyName = "IDCorso";

        private int _idCorso = -1;

        /// <summary>
        /// Sets and gets the IDCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDCorso
        {
            get
            {
                return _idCorso;
            }

            set
            {
                if (_idCorso == value)
                {
                    return;
                }

                _idCorso = value;
                RaisePropertyChanged(IDCorsoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CorsoEdit" /> property's name.
        /// </summary>
        public const string CorsoEditPropertyName = "CorsoEdit";

        private CorsoEditViewModel _corsoEdit = null;

        /// <summary>
        /// Sets and gets the CorsoEditX property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CorsoEditViewModel CorsoEdit
        {
            get
            {
                if (_corsoEdit == null && IDCorso != -1)
                {
                    CorsoEdit = dataservice.GetCorso(IDCorso);
                    CalcolaElencoBlackDate();
                   
                }
                return _corsoEdit;
            }

            set
            {
                if (_corsoEdit == value)
                {
                    return;
                }
                _corsoEdit = value;
                if (_corsoEdit != null)
                {
                    CanSelezionareDate = CorsoEdit.TipoCorso == CorsoViewModel.TipoCorsoValue.Fisso;
                    CalcolaElencoBlackDate();
                }
                RaisePropertyChanged(CorsoEditPropertyName);
            }
        }

     
        /// <summary>
        /// The <see cref="CalendarioDateDisplay" /> property's name.
        /// </summary>
        public const string CalendarioDateDisplayPropertyName = "CalendarioDateDisplay";

        private DateTime _calendarioDateDisplay = DateTime.Now;

        /// <summary>
        /// Sets and gets the CalendarioDateDisplay property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime CalendarioDateDisplay
        {
            get
            {
                return _calendarioDateDisplay;
            }

            set 
            {
                if (_calendarioDateDisplay == value)
                {
                    return;
                }

                _calendarioDateDisplay = value;
                CalcolaElencoBlackDate();
                RaisePropertyChanged(CalendarioDateDisplayPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CalendarioBlackDates" /> property's name.
        /// </summary>
        public const string CalendarioBlackDatesPropertyName = "CalendarioBlackDates";

        private List<DateTime>  _calendarioBlackDates = null;

        /// <summary>
        /// Sets and gets the CalendarioBlackDates property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<DateTime> CalendarioBlackDates
        {
            get
            {
                return _calendarioBlackDates;
            }

            set
            {
                if (_calendarioBlackDates == value)
                {
                    return;
                }

                _calendarioBlackDates = value;
                
                RaisePropertyChanged(CalendarioBlackDatesPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ID" /> property's name.
        /// </summary>
        public const string IDPropertyName = "ID";

        private int _id = 0;

        /// <summary>
        /// Sets and gets the ID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(IDPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Titolo" /> property's name.
        /// </summary>
        public const string TitoloPropertyName = "Titolo";

        private string _titolo = string.Empty;

        /// <summary>
        /// Sets and gets the Titolo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Titolo
        {
            get
            {
                return _titolo;
            }

            set
            {
                if (_titolo == value)
                {
                    return;
                }

                _titolo = value;
                CanSave = true;
                RaisePropertyChanged(TitoloPropertyName);
            }
        }

        
        /// <summary>
        /// The <see cref="Note" /> property's name.
        /// </summary>
        public const string NotePropertyName = "Note";

        private string _note = string.Empty;

        /// <summary>
        /// Sets and gets the Note property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Note
        {
            get
            {
                return _note;
            }

            set
            {
                if (_note == value)
                {
                    return;
                }

                _note = value;
                CanSave = true;
                RaisePropertyChanged(NotePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="DataInizio" /> property's name.
        /// </summary>
        public const string DataInizioPropertyName = "DataInizio";

        private DateTime _dataInizio = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataInizio
        {
            get
            {
                return _dataInizio;
            }

            set
            {
                if (_dataInizio == value)
                {
                    return;
                }

                _dataInizio = value;
                
                CanSave = true;
                RaisePropertyChanged(DataInizioPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DataFine" /> property's name.
        /// </summary>
        public const string DataFinePropertyName = "DataFine";

        private DateTime _dataFine = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataFine property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataFine
        {
            get
            {
                return _dataFine;
            }

            set
            {
                if (_dataFine == value)
                {
                    return;
                }

                _dataFine = value;
                
                CanSave = true;
                RaisePropertyChanged(DataFinePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NumeroLezioni" /> property's name.
        /// </summary>
        public const string NumeroLezioniPropertyName = "NumeroLezioni";

        private short _numeroLezioni = 0;

        /// <summary>
        /// Sets and gets the NumeroLezioni property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short NumeroLezioni
        {
            get
            {
                return _numeroLezioni;
            }

            set
            {
                if (_numeroLezioni == value)
                {
                    return;
                }

                _numeroLezioni = value;
                if (ImportoCorso == 0)
                    ImportoCorso = _numeroLezioni * CostoLordoLezione;
                RaisePropertyChanged(NumeroLezioniPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CostoIvaLezione" /> property's name.
        /// </summary>
        public const string CostoIvaLezionePropertyName = "CostoIvaLezione";

        private decimal _costoIvaLezione = 0;

        /// <summary>
        /// Sets and gets the CostoIvaLezione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CostoIvaLezione
        {
            get
            {
                return _costoIvaLezione;
            }

            set
            {
                if (_costoIvaLezione == value)
                {
                    return;
                }

                _costoIvaLezione = value;
                RaisePropertyChanged(CostoIvaLezionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CostoLordoLezione" /> property's name.
        /// </summary>
        public const string CostoLordoLezionePropertyName = "CostoLordoLezione";

        private decimal _costoLordoLezione = 0;

        /// <summary>
        /// Sets and gets the CostoLordoLezione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CostoLordoLezione
        {
            get
            {
                return _costoLordoLezione;
            }

            set
            {
                if (_costoLordoLezione == value)
                {
                    return;
                }

                _costoLordoLezione = value;
                if (ImportoCorso == 0)
                    ImportoCorso = _numeroLezioni * CostoLordoLezione;
                RaisePropertyChanged(CostoLordoLezionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ImportoCorso" /> property's name.
        /// </summary>
        public const string ImportoCorsoPropertyName = "ImportoCorso";

        private decimal _importoCorso = 0;

        /// <summary>
        /// Sets and gets the ImportoCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoCorso
        {
            get
            {
                return _importoCorso;
            }

            set
            {
                if (_importoCorso == value)
                {
                    return;
                }
                _importoCorso = value;
                RaisePropertyChanged(ImportoCorsoPropertyName);
            }
        }


        private void ImpostaTitolo()
        {
            string m1 = string.Empty;
            string m2 = string.Empty;

            CultureInfo ci = new CultureInfo("it-IT");

            if (DataInizio != null)
                m1 = ((DateTime) DataInizio).ToString("MMMM", ci);
            if (DataFine != null)
                m2 = ((DateTime) DataFine).ToString("MMMM", ci);

            if (Titolo == string.Empty)
                Titolo = m1 + (m1 != string.Empty && m2.CompareTo(m1) != 0 ? "-" : "") + (m2.CompareTo(m1) != 0 ? m2 : string.Empty);
        }
        /// <summary>
        /// The <see cref="ElencoDateCorso" /> property's name.
        /// </summary>
        public const string ElencoDateCorsoPropertyName = "ElencoDateCorso";

        private ObservableCollection<SingolaDataAttivitaViewModel> _elencoDateCorso = null;

        /// <summary>
        /// Sets and gets the ElencoDateCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<SingolaDataAttivitaViewModel> ElencoDateCorso
        {
            get
            {
                return _elencoDateCorso;
            }

            set
            {
                if (_elencoDateCorso == value)
                {
                    return;
                }

                _elencoDateCorso = value;
                CanSave = true;
                if (_elencoDateCorso != null && _elencoDateCorso.Count() > 0)
                {
                    DateTime Max = ElencoDateCorso.Max(k => k.Inizio);
                    DateTime Min = ElencoDateCorso.Min(k => k.Inizio);
                    if (DataFine==null || DataFine < Max)
                        DataFine = new DateTime(Max.Year, Max.Month, Max.Day);
                    if (DataInizio==null || DataInizio > Min)
                        DataInizio = new DateTime(Min.Year, Min.Month, Min.Day);
                }



                RaisePropertyChanged(ElencoDateCorsoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsAttivo" /> property's name.
        /// </summary>
        public const string IsAttivoPropertyName = "IsAttivo";

        private bool _isAttivo = true;

        /// <summary>
        /// Sets and gets the IsAttivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivo
        {
            get
            {
                return _isAttivo;
            }

            set
            {
                if (_isAttivo == value)
                {
                    return;
                }

                _isAttivo = value;
                RaisePropertyChanged(IsAttivoPropertyName);
            }
        }

        private RelayCommand<DateTime> _RemoveDataAttivita;

        /// <summary>
        /// Gets the RemoveDataAttivita.
        /// </summary>
        public RelayCommand<DateTime> RemoveDataAttivita
        {
            get
            {
                return _RemoveDataAttivita
                    ?? (_RemoveDataAttivita = new RelayCommand<DateTime>(
                    p =>
                    {
                        ElencoDateCorso.Remove(ElencoDateCorso.Where(y => y.Inizio == p).First());
                        CanSave = true;
                        NumeroLezioni = (short) ElencoDateCorso.Count();
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshCalendarioDate>(new RefreshCalendarioDate(this));
                    }));
            }
        }

        

        public void CalcolaElencoDate(DateTime DataIniziale)
        {
            int iLezioni = NumeroLezioni;  
            DateTime dt = new DateTime(DataIniziale.Ticks);
            ObservableCollection<SingolaDataAttivitaViewModel> ListaDate = new ObservableCollection<SingolaDataAttivitaViewModel>();
            while (iLezioni > 0)
            {

                foreach (OrarioCorsoViewModel ocvm in CorsoEdit.EditElencoOrari.Where(p => p.GiornoSettimana == dt.DayOfWeek).ToList())
                {
                    SingolaDataAttivitaViewModel sda = new SingolaDataAttivitaViewModel();
                    sda.Inizio = new DateTime(dt.Year, dt.Month, dt.Day, ocvm.OraInizio.Hours, ocvm.OraInizio.Minutes, 0);
                    sda.Inizio = new DateTime(dt.Year, dt.Month, dt.Day, ocvm.OraInizio.Hours, ocvm.OraInizio.Minutes, 0);

                    ListaDate.Add(sda);
                    iLezioni--;
                    if (iLezioni <= 0) break;
                }
                dt = dt.AddDays(1);
            }
            ElencoDateCorso = ListaDate;
            ImpostaTitolo();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshCalendarioDate>(new RefreshCalendarioDate(this));

        }


        public void CalcolaElencoBlackDate()
        {
            DateTime dt = new DateTime(CalendarioDateDisplay.Year,CalendarioDateDisplay.Month,1,0,0,0);
            List<DateTime> ListaDate = new List<DateTime>();
            int month = dt.Month;
            while (dt.Month == month)
            {
                
                if (CorsoEdit.EditElencoOrari.Where(p => p.GiornoSettimana == dt.DayOfWeek).Count() == 0)
                    ListaDate.Add(dt);
                dt = dt.AddDays(1);
            }
            CalendarioBlackDates = ListaDate;
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshCalendarioBlackDate>(new RefreshCalendarioBlackDate(this));

        }





        public void CalcolaElencoDateFromDates(System.Windows.Controls.SelectedDatesCollection listadate)
        {

            ObservableCollection<SingolaDataAttivitaViewModel> ListaDate = new ObservableCollection<SingolaDataAttivitaViewModel> ();
            foreach (DateTime dt in listadate)
            {


                foreach (OrarioCorsoViewModel ocvm in CorsoEdit.EditElencoOrari.Where(p => p.GiornoSettimana == dt.DayOfWeek).ToList())
                {
                    SingolaDataAttivitaViewModel sd = new SingolaDataAttivitaViewModel();

                    sd.Inizio = new DateTime(dt.Year, dt.Month, dt.Day, ocvm.OraInizio.Hours, ocvm.OraInizio.Minutes, 0);
                    sd.Fine = new DateTime(dt.Year, dt.Month, dt.Day, ocvm.OraFine.Hours, ocvm.OraFine.Minutes, 0);
                    
                    ListaDate.Add(sd);
                }
            }
            ElencoDateCorso = ListaDate;
            NumeroLezioni = (short)ElencoDateCorso.Count();
        }


        public void UpdateElencoDate(ICollection AddedItems,ICollection RemovedItems)
        {
            if (ElencoDateCorso == null)
                ElencoDateCorso = new ObservableCollection<SingolaDataAttivitaViewModel>();
            foreach(DateTime da in AddedItems)
            {
                foreach (OrarioCorsoViewModel ocvm in CorsoEdit.EditElencoOrari.Where(p => p.GiornoSettimana == da.DayOfWeek).ToList())
                {
                    SingolaDataAttivitaViewModel sd = new SingolaDataAttivitaViewModel();

                    sd.Inizio = new DateTime(da.Year, da.Month, da.Day, ocvm.OraInizio.Hours, ocvm.OraInizio.Minutes, 0);
                    sd.Fine = new DateTime(da.Year, da.Month, da.Day, ocvm.OraFine.Hours, ocvm.OraFine.Minutes, 0);

                    DateTime nt = new DateTime(da.Year, da.Month, da.Day, ocvm.OraInizio.Hours, ocvm.OraInizio.Minutes, 0);
                    ElencoDateCorso.Add(sd);
                }

            }
            foreach (DateTime de in RemovedItems)
            {
                foreach (SingolaDataAttivitaViewModel dt in ElencoDateCorso.Where(k => k.Inizio.Year == de.Year && k.Inizio.Month==de.Month && k.Inizio.Day == de.Day).ToList())
                    ElencoDateCorso.Remove(dt);
            }
            NumeroLezioni = (short) ElencoDateCorso.Count();
        }
    }
}