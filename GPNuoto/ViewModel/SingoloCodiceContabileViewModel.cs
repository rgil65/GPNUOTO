using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingoloCodiceContabileViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloCodiceContabileViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        [PreferredConstructor]
        public SingoloCodiceContabileViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
        }

    
        /// <summary>
        /// The <see cref="Codice" /> property's name.
        /// </summary>
        public const string CodicePropertyName = "Codice";

        private string _codice = string.Empty;

        /// <summary>
        /// Sets and gets the Codice property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Codice
        {
            get
            {
                return _codice;
            }

            set
            {
                if (_codice == value)
                {
                    return;
                }

                _codice = value.Trim();
                
                 CanSave = CheckForSave();
                RaisePropertyChanged(CodicePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Descrizione" /> property's name.
        /// </summary>
        public const string DescrizionePropertyName = "Descrizione";

        private string _descrizione = string.Empty;

        /// <summary>
        /// Sets and gets the Descrizione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Descrizione
        {
            get
            {
                return _descrizione;
            }

            set
            {
                if (_descrizione == value)
                {
                    return;
                }

                _descrizione = value;
                CanSave = CheckForSave();
                RaisePropertyChanged(DescrizionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Indice" /> property's name.
        /// </summary>
        public const string IndicePropertyName = "Indice";

        private string _indice = string.Empty;

        /// <summary>
        /// Sets and gets the Indice property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Indice
        {
            get
            {
                return _indice;
            }

            set
            {
                if (_indice == value)
                {
                    return;
                }

                _indice = value;
                CanSave = CheckForSave();
                RaisePropertyChanged(IndicePropertyName);
            }
        }

        bool CheckForSave()
        {
            bool bRet = false;

            bRet = _codice.Trim().Length > 0 && _descrizione.Trim().Length > 0;
            if (bRet && IsNew)
                return !dataservice.IsCodiceContabile(_codice);
            else
                return bRet;
        }
        /// <summary>
        /// The <see cref="bSegno" /> property's name.
        /// </summary>
        public const string bSegnoPropertyName = "bSegno";

        private bool _bSegno = true;

        /// <summary>
        /// Sets and gets the bSegno property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool bSegno
        {
            get
            {
                return _bSegno;
            }

            set
            {
                if (_bSegno == value)
                {
                    return;
                }

                _bSegno = value;
                CanSave = CheckForSave();
                RaisePropertyChanged(bSegnoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ImportoPredefinito" /> property's name.
        /// </summary>
        public const string ImportoPredefinitoPropertyName = "ImportoPredefinito";

        private decimal _importoPredefinito = 0;

        /// <summary>
        /// Sets and gets the ImportoPredefinito property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoPredefinito
        {
            get
            {
                return _importoPredefinito;
            }

            set
            {
                if (_importoPredefinito == value)
                {
                    return;
                }

                CanSave = CheckForSave();
                _importoPredefinito = value;
                RaisePropertyChanged(ImportoPredefinitoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="IsAttivitaExtra" /> property's name.
        /// </summary>
        public const string IsAttivitaExtraPropertyName = "IsAttivitaExtra";

        private bool _isAttivitaExtra = false;

        /// <summary>
        /// Sets and gets the IsAttivitaExtra property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivitaExtra
        {
            get
            {
                return _isAttivitaExtra;
            }

            set
            {
                if (_isAttivitaExtra == value)
                {
                    return;
                }

                _isAttivitaExtra = value;
                CanSave = CheckForSave();
                RaisePropertyChanged(IsAttivitaExtraPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsFiscale" /> property's name.
        /// </summary>
        public const string IsFiscalePropertyName = "IsFiscale";

        private bool _isFiscale = false;

        /// <summary>
        /// Sets and gets the IsFiscale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsFiscale
        {
            get
            {
                return _isFiscale;
            }

            set
            {
                if (_isFiscale == value)
                {
                    return;
                }

                _isFiscale = value;
                CanSave = CheckForSave();
                RaisePropertyChanged(IsFiscalePropertyName);
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
                CanSave = CheckForSave();
                RaisePropertyChanged(IsAttivoPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IsErasabled" /> property's name.
        /// </summary>
        public const string IsErasabledPropertyName = "IsErasabled";

        private bool _isErasabled = false;

        /// <summary>
        /// Sets and gets the IsErasabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsErasabled
        {
            get
            {
                return _isErasabled;
            }

            set
            {
                if (_isErasabled == value)
                {
                    return;
                }

                _isErasabled = value;
                RaisePropertyChanged(IsErasabledPropertyName);
            }
        }

          /// <summary>
        /// The <see cref="IsNew" /> property's name.
        /// </summary>
        public const string IsNewPropertyName = "IsNew";

        private bool _isNew = false;

        /// <summary>
        /// Sets and gets the IsEditable property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsNew
        {
            get
            {
                return _isNew;
            }

            set
            {
                if (_isNew == value)
                {
                    return;
                }

                _isNew = value;
                RaisePropertyChanged(IsNewPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsEditable" /> property's name.
        /// </summary>
        public const string IsEditablePropertyName = "IsEditable";

        private bool _isEditable = true;

        /// <summary>
        /// Sets and gets the IsEditable property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsEditable
        {
            get
            {
                return _isEditable;
            }

            set
            {
                if (_isEditable == value)
                {
                    return;
                }

                _isEditable = value;
                RaisePropertyChanged(IsNewPropertyName);
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
        
    }
}