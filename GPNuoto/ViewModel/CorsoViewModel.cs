using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    /// 
    public class OrarioCorsoViewModel : ViewModelBase
    {
        public int ID { get; set; }
        /// <summary>
        /// The <see cref="OraInizio" /> property's name.
        /// </summary>
        public const string OraInizioPropertyName = "OraInizio";

        private TimeSpan _oraInizio = new TimeSpan(0);

        /// <summary>
        /// Sets and gets the OraInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan OraInizio
        {
            get
            {
                return _oraInizio;
            }

            set
            {
                if (_oraInizio == value)
                {
                    return;
                }

                _oraInizio = value;
                RaisePropertyChanged(OraInizioPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="OraFine" /> property's name.
        /// </summary>
        public const string OraFinePropertyName = "OraFine";

        private TimeSpan _oraFine = new TimeSpan(0);

        /// <summary>
        /// Sets and gets the OraFine property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan OraFine
        {
            get
            {
                return _oraFine;
            }

            set
            {
                if (_oraFine == value)
                {
                    return;
                }

                _oraFine = value;
                RaisePropertyChanged(OraFinePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="GiornoSettimana" /> property's name.
        /// </summary>
        public const string GiornoSettimanaPropertyName = "GiornoSettimana";

        private DayOfWeek _giornoSettimana = DayOfWeek.Sunday;

        /// <summary>
        /// Sets and gets the GiornoSettimana property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DayOfWeek GiornoSettimana
        {
            get
            {
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



    public class CorsoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CorsoViewModel class.
        /// </summary>
        /// 
        public enum TipoCorsoValue {Fisso,Abbonamento,Singolo }; 
        public CorsoViewModel()
        {
        }

        public int ID { get; set; }


        public TipoAttivitaViewModel TipoAttivita { get; set; }


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
                RaisePropertyChanged(TitoloPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TipoCorso" /> property's name.
        /// </summary>
        public const string TipoCorsoPropertyName = "TipoCorso";

        private TipoCorsoValue _tipoCorso = TipoCorsoValue.Fisso;

        /// <summary>
        /// Sets and gets the TipoCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TipoCorsoValue TipoCorso
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
                RaisePropertyChanged(NotePropertyName);
            }
        }

        

        /// <summary>
        /// The <see cref="ProgrammazioneSettimanale" /> property's name.
        /// </summary>
        public const string ProgrammazioneSettimanalePropertyName = "ProgrammazioneSettimanale";

        private List<OrarioCorsoViewModel> _programmazioneSettimanale = new List<OrarioCorsoViewModel>();

        /// <summary>
        /// Sets and gets the ProgrammazioneSettimanale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<OrarioCorsoViewModel> ProgrammazioneSettimanale
        {
            get
            {
               return _programmazioneSettimanale;
            }

            set
            {
                if (_programmazioneSettimanale == value)
                {
                    return;
                }

                _programmazioneSettimanale = value;
                RaisePropertyChanged(ProgrammazioneSettimanalePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoAttivita" /> property's name.
        /// </summary>
        public const string ElencoAttivitaPropertyName = "ElencoAttivita";

        private List<SingolaAttivitaViewModel> _elencoAttivita = null;

        /// <summary>
        /// Sets and gets the ElencoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingolaAttivitaViewModel> ElencoAttivita
        {
            get
            {
                return _elencoAttivita;
            }

            set
            {
                if (_elencoAttivita == value)
                {
                    return;
                }

                _elencoAttivita = value;
                RaisePropertyChanged(ElencoAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AttivitaSelezionata" /> property's name.
        /// </summary>
        public const string AttivitaSelezionataPropertyName = "AttivitaSelezionata";

        private SingolaAttivitaViewModel _attivitaSelezionata = null;

        /// <summary>
        /// Sets and gets the AttivitaSelezionata property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingolaAttivitaViewModel AttivitaSelezionata
        {
            get
            {
                return _attivitaSelezionata;
            }

            set
            {
                if (_attivitaSelezionata == value)
                {
                    return;
                }

                _attivitaSelezionata = value;
                RaisePropertyChanged(AttivitaSelezionataPropertyName);
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

        public  void RefreshElencoAttivita(bool bAll)
        {
            IDataService ds = SimpleIoc.Default.GetInstance<IDataService>();
            ElencoAttivita = null;
            ElencoAttivita = ds.GetElencoAttivitaProgrammate(this.ID,bAll);
        }

    }
}