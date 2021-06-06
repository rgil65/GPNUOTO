using GalaSoft.MvvmLight;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ROAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ROSingolaAttivitaViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public ROAttivitaViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
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
        /// The <see cref="IDCorso" /> property's name.
        /// </summary>
        public const string IDCorsoPropertyName = "IDCorso";

        private int _idCorso = 0;

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
                RaisePropertyChanged(DataFinePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NumeroLezioni" /> property's name.
        /// </summary>
        public const string NumeroLezioniPropertyName = "NumeroLezioni";

        private int _numeroLezioni = 0;

        /// <summary>
        /// Sets and gets the NumeroLezioni property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumeroLezioni
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
                RaisePropertyChanged(NumeroLezioniPropertyName);
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
        /// The <see cref="IsFiltrata" /> property's name.
        /// </summary>
        public const string IsFiltrataPropertyName = "IsFiltrata";

        private bool _isFiltrata = false;

        /// <summary>
        /// Sets and gets the IsFiltrata property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsFiltrata
        {
            get
            {
                return _isFiltrata;
            }

            set
            {
                if (_isFiltrata == value)
                {
                    return;
                }

                _isFiltrata = value;
                RaisePropertyChanged(IsFiltrataPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NumeroIscritti" /> property's name.
        /// </summary>
        public const string NumeroIscrittiPropertyName = "NumeroIscritti";

        private int _numeroIscritti = 0;

        /// <summary>
        /// Sets and gets the NumeroIscritti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumeroIscritti
        {
            get
            {
                return _numeroIscritti;
            }

            set
            {
                if (_numeroIscritti == value)
                {
                    return;
                }

                _numeroIscritti = value;
                RaisePropertyChanged(NumeroIscrittiPropertyName);
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
                if (ImportoCorso != 0)
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



        /// <summary>
        /// The <see cref="Corso" /> property's name.
        /// </summary>
        public const string CorsoPropertyName = "Corso";

        private ROCorsoViewModel _corso = null; 

        /// <summary>
        /// Sets and gets the Corso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ROCorsoViewModel Corso
        {
            get
            {
                if (_corso == null && IDCorso > 0)
                    _corso = dataservice.GetROCorso(IDCorso);
                return _corso;
            }

            set
            {
                if (_corso == value)
                {
                    return;
                }

                _corso = value;
                RaisePropertyChanged(CorsoPropertyName);
            }
        }
    }
}