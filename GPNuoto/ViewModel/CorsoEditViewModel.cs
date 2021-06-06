using GalaSoft.MvvmLight;
using System;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// 

    public class ElementoProgrammazioneOrariaViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Orario" /> property's name.
        /// </summary>
        public const string OrarioPropertyName = "Orario";

        private TimeSpan _orario = new TimeSpan(0);

        /// <summary>
        /// Sets and gets the Orario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan Orario
        {
            get
            {
                return _orario;
            }

            set
            {
                if (_orario == value)
                {
                    return;
                }

                _orario = value;
                RaisePropertyChanged(OrarioPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="RangeOrario" /> property's name.
        /// </summary>
        public const string RangeOrarioPropertyName = "RangeOrario";

        private string _rangeOrario = string.Empty;

        /// <summary>
        /// Sets and gets the RangeOrario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string RangeOrario
        {
            get
            {
                return _rangeOrario;
            }

            set
            {
                if (_rangeOrario == value)
                {
                    return;
                }

                _rangeOrario = value;
                RaisePropertyChanged(RangeOrarioPropertyName);
            }
        }

        public const string COLOR_EMPTY = "transparent";
        /// <summary>
        /// The <see cref="GiornoSettimana" /> property's name.
        /// </summary>
        public const string GiornoSettimanaPropertyName = "GiornoSettimana";

        private ObservableCollection<string> _giornoSettimana = null;

        /// <summary>
        /// Sets and gets the GiornoSettimana property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> GiornoSettimana
        {
            get
            {
                if (_giornoSettimana == null)
                {
                    _giornoSettimana = new ObservableCollection<string>();
                    for (int i = 0; i < 7; i++)
                        _giornoSettimana.Add(COLOR_EMPTY);
                }

                return _giornoSettimana;
            }

            set
            {
                if (_giornoSettimana == value)
                {
                    return;
                }

                _giornoSettimana = value;
                RaisePropertyChanged(GiornoSettimanaPropertyName);
            }
        }
    }


    public class CorsoEditViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CorsoViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public CorsoEditViewModel()
        {
             if (ViewModelBase.IsInDesignModeStatic)
            {
                GrigliaProgrammazioneOraria = new List<ElementoProgrammazioneOrariaViewModel>();
                ElementoProgrammazioneOrariaViewModel epo = new ElementoProgrammazioneOrariaViewModel();
                EditElencoOrari = new ObservableCollection<OrarioCorsoViewModel>();
                OrarioCorsoViewModel ocvm = new OrarioCorsoViewModel();
                ocvm.GiornoSettimana = DayOfWeek.Monday;
                ocvm.OraInizio = new TimeSpan(0, 15, 0);
                ocvm.OraFine = new TimeSpan(1, 0, 0);
                
                EditElencoOrari.Add(ocvm);
                ocvm = new OrarioCorsoViewModel();
                ocvm.GiornoSettimana = DayOfWeek.Friday;
                ocvm.OraInizio = new TimeSpan(1, 15, 0);
                ocvm.OraFine = new TimeSpan(2, 0, 0);
                EditElencoOrari.Add(ocvm);
                CalcolaGrigliaProgrammazione();


            }
            dataservice = SimpleIoc.Default.GetInstance<IDataService>();
            ID = 0;
        }

        public int ID { get; set; }

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
                CanSave = CheckForSave();
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
                CanSave = CheckForSave();
                RaisePropertyChanged(NotePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="TipoCorso" /> property's name.
        /// </summary>
        public const string TipoCorsoPropertyName = "TipoCorso";

        private CorsoViewModel.TipoCorsoValue _tipoCorso = CorsoViewModel.TipoCorsoValue.Fisso;

        /// <summary>
        /// Sets and gets the TipoCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CorsoViewModel.TipoCorsoValue TipoCorso
        {
            get
            {
                return _tipoCorso;
            }

            set
            {
                if (_tipoCorso == value)
                {
                    return;
                }

                _tipoCorso = value;
                RaisePropertyChanged(TipoCorsoPropertyName);
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
        ///// <summary>
        ///// The <see cref="ProgrammazioneSettimanale" /> property's name.
        ///// </summary>
        //public const string ProgrammazioneSettimanalePropertyName = "ProgrammazioneSettimanale";

        //private List<OrarioCorsoViewModel> _programmazioneSettimanale = new List<OrarioCorsoViewModel>();

        ///// <summary>
        ///// Sets and gets the ProgrammazioneSettimanale property.
        ///// Changes to that property's value raise the PropertyChanged event. 
        ///// </summary>
        //public List<OrarioCorsoViewModel> ProgrammazioneSettimanale
        //{
        //    get
        //    {
        //        return _programmazioneSettimanale;
        //    }

        //    set
        //    {
        //        if (_programmazioneSettimanale == value)
        //        {
        //            return;
        //        }

        //        _programmazioneSettimanale = value;
        //        ObservableCollection<OrarioCorsoViewModel> lsa = new ObservableCollection<OrarioCorsoViewModel>();
        //        foreach (OrarioCorsoViewModel savm in ProgrammazioneSettimanale)
        //            lsa.Add(savm);
        //        EditElencoOrari = lsa;
        //        RaisePropertyChanged(ProgrammazioneSettimanalePropertyName);
        //    }
        //}
        /// <summary>
        /// The <see cref="TipoAttivita" /> property's name.
        /// </summary>
        public const string TipoAttivitaPropertyName = "TipoAttivita";

        private TipoAttivitaViewModel _tipoattivita = null;

        /// <summary>
        /// Sets and gets the TipoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TipoAttivitaViewModel TipoAttivita
        {
            get
            {
                return _tipoattivita;
            }

            set
            {
                if (_tipoattivita == value)
                {
                    return;
                }

                _tipoattivita = value;
                if (_tipoattivita != null)
                {
                    ProgrammazioneInizio = _tipoattivita.ProgrammazioneInizio;
                    ProgrammazioneFine = _tipoattivita.ProgrammazioneFine;
                    DurataPianificazione = _tipoattivita.Durata;
                    StepPianificazione = _tipoattivita.StepPianificazione;
                    CalcolaGrigliaProgrammazione();
                }
                IsParametriModificati = false;
                CanSave = CheckForSave();
                RaisePropertyChanged(TipoAttivitaPropertyName);
            }
        }
        /// <summary>
            /// The <see cref="EditElencoOrari" /> property's name.
            /// </summary>
        public const string EditElencoOrariPropertyName = "EditElencoOrari";

        private ObservableCollection<OrarioCorsoViewModel> _editElencoOrari = null;

        /// <summary>
        /// Sets and gets the EditElencoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<OrarioCorsoViewModel> EditElencoOrari
        {
            get
            {
                if (_editElencoOrari == null)
                    _editElencoOrari = new ObservableCollection<OrarioCorsoViewModel>();

                return _editElencoOrari;
            }

            set
            {
                if (_editElencoOrari == value)
                {
                    return;
                }

                _editElencoOrari = value;
                CanSave = CheckForSave();
                CanDelete = CheckForDelete();
                RaisePropertyChanged(EditElencoOrariPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ProgrammazioneInizio" /> property's name.
        /// </summary>
        public const string ProgrammazioneInizioPropertyName = "ProgrammazioneInizio";

        private TimeSpan _programmazioneInizio = new TimeSpan(0);

        /// <summary>
        /// Sets and gets the ProgrammazioneInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan ProgrammazioneInizio
        {
            get
            {
                return _programmazioneInizio;
            }

            set
            {
                if (_programmazioneInizio == value)
                {
                    return;
                }

                _programmazioneInizio = value;
                IsParametriModificati = true;

                RaisePropertyChanged(ProgrammazioneInizioPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsParametriModificati" /> property's name.
        /// </summary>
        public const string IsParametriModificatiPropertyName = "IsParametriModificati";

        private bool _isParametriModificati = false;

        /// <summary>
        /// Sets and gets the IsParametriModificati property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsParametriModificati
        {
            get
            {
                return _isParametriModificati;
            }

            set
            {
                if (_isParametriModificati == value)
                {
                    return;
                }

                _isParametriModificati = value;
                RaisePropertyChanged(IsParametriModificatiPropertyName);
            }
        }
       
        bool CheckForSave()
        {
            
            return (!HaveAttivitaCollegate  && Titolo.Trim().Length > 0);

        }

        bool CheckForDelete()
        {
            if ((_editElencoOrari == null || _editElencoOrari.Count() == 0) && !HaveAttivitaCollegate)
                return true;
            else
                return false;
        }

        /// <summary>
        /// The <see cref="ProgrammazioneFine" /> property's name.
        /// </summary>
        public const string ProgrammazioneFinePropertyName = "ProgrammazioneFine";

        private TimeSpan _programmazioneFine = new TimeSpan(1440);

        /// <summary>
        /// Sets and gets the ProgrammazioneInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan ProgrammazioneFine
        {
            get
            {
                return _programmazioneFine;
            }

            set
            {
                if (_programmazioneFine == value)
                {
                    return;
                }

                _programmazioneFine = value;
                IsParametriModificati = true;
                RaisePropertyChanged(ProgrammazioneFinePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="StepPianificazione" /> property's name.
        /// </summary>
        public const string StepPianificazionePropertyName = "StepPianificazione";

        private TimeSpan _stepPianificazione = new TimeSpan(0,15,0);

        /// <summary>
        /// Sets and gets the StepPianificazione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan StepPianificazione
        {
            get
            {
                return _stepPianificazione;
            }

            set
            {
                if (_stepPianificazione == value)
                {
                    return;
                }

                _stepPianificazione = value;
                IsParametriModificati = true;
                RaisePropertyChanged(StepPianificazionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DurataPianificazione" /> property's name.
        /// </summary>
        public const string DurataPianificazionePropertyName = "DurataPianificazione";

        private TimeSpan _durataPianificazione = new TimeSpan(0,45,0);

        /// <summary>
        /// Sets and gets the DurataPianificazione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan DurataPianificazione
        {
            get
            {
                return _durataPianificazione;
            }

            set
            {
                if (_durataPianificazione == value)
                {
                    return;
                }

                _durataPianificazione = value;
                IsParametriModificati = true;
                RaisePropertyChanged(DurataPianificazionePropertyName);
            }
        }

        private RelayCommand _salvaParametriProgrammazione;

        /// <summary>
        /// Gets the SalvaParametriProgrammazione.
        /// </summary>
        public RelayCommand SalvaParametriProgrammazione
        {
            get
            {
                return _salvaParametriProgrammazione
                    ?? (_salvaParametriProgrammazione = new RelayCommand(
                    () =>
                    {
                        TipoAttivita.Durata = DurataPianificazione;
                        TipoAttivita.ProgrammazioneFine = ProgrammazioneFine;
                        TipoAttivita.ProgrammazioneInizio = ProgrammazioneInizio;
                        TipoAttivita.StepPianificazione = StepPianificazione;
                        dataservice.UpdateTipoAttivita(TipoAttivita);
                        IsParametriModificati = false;
                        CalcolaGrigliaProgrammazione();
                    }));
            }
        }
        /// <summary>
        /// The <see cref="GrigliaProgrammazioneOraria" /> property's name.
        /// </summary>
        public const string GrigliaProgrammazioneOrariaPropertyName = "GrigliaProgrammazioneOraria";

        private List<ElementoProgrammazioneOrariaViewModel> _grigliaProgrammazioneOraria = null;

        /// <summary>
        /// Sets and gets the GrigliaProgrammazioneOraria property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ElementoProgrammazioneOrariaViewModel> GrigliaProgrammazioneOraria
        {
            get
            {
                return _grigliaProgrammazioneOraria;
            }

            set
            {
                if (_grigliaProgrammazioneOraria == value)
                {
                    return;
                }

                _grigliaProgrammazioneOraria = value;
                RaisePropertyChanged(GrigliaProgrammazioneOrariaPropertyName);
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
        /// The <see cref="HaveAttivitaCollegate" /> property's name.
       /// </summary>
        public const string HaveAttivitaCollegatePropertyName = "HaveAttivitaCollegate";

        private bool _haveAttivitaCollegate = false;

        /// <summary>
        /// Sets and gets the HaveAttivitaCollegate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool HaveAttivitaCollegate
        {
            get
            {
                return _haveAttivitaCollegate;
            }

            set
            {
                if (_haveAttivitaCollegate == value)
                {
                    return;
                }

                _haveAttivitaCollegate = value;
                if (_haveAttivitaCollegate)
                    CanDelete = false;
                RaisePropertyChanged(HaveAttivitaCollegatePropertyName);
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
        

        public void CalcolaGrigliaProgrammazione()
        {
            List<ElementoProgrammazioneOrariaViewModel> Griglia = new List<ElementoProgrammazioneOrariaViewModel>();

            
            TimeSpan current = new TimeSpan(ProgrammazioneInizio.Ticks);
            long   Diff = ProgrammazioneFine.Ticks - ProgrammazioneInizio.Ticks;
            TimeSpan Delta = new TimeSpan(Diff<0?0:Diff);
            int item = (int)Delta.TotalMinutes / (int) StepPianificazione.TotalMinutes;

            for (int j=0;j<item;j++)
            {
                ElementoProgrammazioneOrariaViewModel epo = new ElementoProgrammazioneOrariaViewModel();
                epo.Orario = current;
                current = current.Add(StepPianificazione);
                TimeSpan tn = epo.Orario;
                epo.RangeOrario = epo.Orario.ToString("hh\\:mm") + " - " + current.ToString("hh\\:mm");
                Griglia.Add(epo);
            }
            GrigliaProgrammazioneOraria = Griglia;
            // Carico elementi pre-esistenti
            foreach (OrarioCorsoViewModel oc in EditElencoOrari)
            {
                int i = GrigliaProgrammazioneOraria.FindIndex(p => p.Orario == oc.OraInizio);
                if (i>=0)
                {
                    TimeSpan t = oc.OraInizio;
                    while(i<GrigliaProgrammazioneOraria.Count && t<oc.OraFine)
                    {
                        GrigliaProgrammazioneOraria[i].GiornoSettimana[(int)oc.GiornoSettimana] = TipoAttivita.BackgroundColor;
                        i++;
                        t = t.Add(StepPianificazione);
                    }
                }
            }

            
        }
     
        public void AddRemoveOrario(ElementoProgrammazioneOrariaViewModel epo, int iIndex)
        {
            if (epo.GiornoSettimana[iIndex].CompareTo(ElementoProgrammazioneOrariaViewModel.COLOR_EMPTY) == 0)
            {
                // In teoria aggiungo un orario
                // Verifico se ho spazio
                int i = GrigliaProgrammazioneOraria.FindIndex(p => p.Orario == epo.Orario);

                bool bAddOrario = true;
                for (int j = 0; j < DurataPianificazione.TotalMinutes / StepPianificazione.TotalMinutes && (j+i)<GrigliaProgrammazioneOraria.Count; j++)
                    if (GrigliaProgrammazioneOraria[i + j].GiornoSettimana[iIndex].CompareTo(ElementoProgrammazioneOrariaViewModel.COLOR_EMPTY) != 0)
                        bAddOrario = false;
                if (bAddOrario)
                {
                    OrarioCorsoViewModel oc = new OrarioCorsoViewModel();
                    oc.GiornoSettimana = (DayOfWeek)iIndex;
                    oc.OraInizio = new TimeSpan(i * StepPianificazione.Ticks+ProgrammazioneInizio.Ticks);
                    oc.OraFine = oc.OraInizio + DurataPianificazione;

                    for (int j = 0; j < DurataPianificazione.TotalMinutes / StepPianificazione.TotalMinutes && (i+j)<GrigliaProgrammazioneOraria.Count; j++)
                        GrigliaProgrammazioneOraria[i + j].GiornoSettimana[iIndex] = TipoAttivita.BackgroundColor;
                    EditElencoOrari.Add(oc);
                }
            }
            else
            {
                // rimozione di un orario
                TimeSpan ftp = epo.Orario;
                foreach (OrarioCorsoViewModel oc in EditElencoOrari)
                {
                    if (oc.GiornoSettimana == (DayOfWeek)iIndex && ftp >= oc.OraInizio && ftp <= oc.OraFine)
                    {

                        // Remove 
                        if (RemoveFromGrigliaProgrammazione(oc))
                                EditElencoOrari.Remove(oc);
                        break;
                    }

                }
            }
            CanSave = CheckForSave();
            CanDelete = CheckForDelete();
        }
        private bool RemoveFromGrigliaProgrammazione(OrarioCorsoViewModel oc)
        {

            int iIndex = (int)oc.GiornoSettimana;
            int j = GrigliaProgrammazioneOraria.FindIndex(p => p.Orario == oc.OraInizio);

            if (j != -1)
            {
                while (j<GrigliaProgrammazioneOraria.Count && GrigliaProgrammazioneOraria[j].Orario <= oc.OraFine)
                {
                    GrigliaProgrammazioneOraria[j].GiornoSettimana[iIndex] = ElementoProgrammazioneOrariaViewModel.COLOR_EMPTY;
                    j++;
                }
                return true;
            }
            else
                return false;

        }

        private RelayCommand<OrarioCorsoViewModel> _RemoveOrario;

        /// <summary>
        /// Gets the RemoveOrario.
        /// </summary>
        public RelayCommand<OrarioCorsoViewModel> RemoveOrario
        {
            get
            {
                return _RemoveOrario
                    ?? (_RemoveOrario = new RelayCommand<OrarioCorsoViewModel>(
                    p =>
                    {
                        if (RemoveFromGrigliaProgrammazione(p))
                            EditElencoOrari.Remove(p);
                        CanSave = CheckForSave();
                        CanDelete = CheckForDelete();
                    }));
            }
        }

        public void Refresh()
        {


        }
       


        


    }
}