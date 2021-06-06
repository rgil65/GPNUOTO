using GalaSoft.MvvmLight;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingoloComuneResidenzaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloCodiceContabileViewModel class.
        /// </summary>
        public SingoloComuneResidenzaViewModel()
        {
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
        /// The <see cref="CAP" /> property's name.
        /// </summary>
        public const string CAPPropertyName = "CAP";

        private string _cap = string.Empty;

        /// <summary>
        /// Sets and gets the Codice property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CAP
        {
            get
            {
                return _cap;
            }

            set
            {
                if (_cap == value)
                {
                    return;
                }

                _cap = value.Trim();
                if (_descrizione.Length > 0)
                    CanSave = true;
                RaisePropertyChanged(CAPPropertyName);
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
                if (_descrizione.Length > 0)
                    CanSave = true;
                RaisePropertyChanged(DescrizionePropertyName);
            }
        }

        /// <summary>
            /// The <see cref="SiglaProvincia" /> property's name.
            /// </summary>
        public const string SiglaProvinciaPropertyName = "SiglaProvincia";

        private string _siglaprovincia = string.Empty;

        /// <summary>
        /// Sets and gets the SiglaProvincia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SiglaProvincia
        {
            get
            {
                return _siglaprovincia;
            }

            set
            {
                if (_siglaprovincia == value)
                {
                    return;
                }

                _siglaprovincia = value;
                RaisePropertyChanged(SiglaProvinciaPropertyName);
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

        private bool _isNew = true;

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