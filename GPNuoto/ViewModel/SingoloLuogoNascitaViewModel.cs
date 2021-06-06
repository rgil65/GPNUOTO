using GalaSoft.MvvmLight;
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
    public class SingoloLuogoNascitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloCodiceContabileViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public SingoloLuogoNascitaViewModel()
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
        /// The <see cref="CodiceISTAT" /> property's name.
        /// </summary>
        public const string CodiceISTATPropertyName = "CodiceISTAT";

        private string _codiceISTAT = string.Empty;

        /// <summary>
        /// Sets and gets the Codice property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceISTAT
        {
            get
            {
                return _codiceISTAT;
            }

            set
            {
                if (_codiceISTAT == value)
                {
                    return;
                }

                _codiceISTAT = value.Trim();
                CanSave = CheckForSave();
                RaisePropertyChanged(CodiceISTATPropertyName);
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
        /// The <see cref="DescrizioneAggiuntiva" /> property's name.
        /// </summary>
        public const string DescrizioneAggiuntivaPropertyName = "DescrizioneAggiuntiva";

        private string _descrizioneAggiuntiva = string.Empty;

        /// <summary>
        /// Sets and gets the Descrizione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DescrizioneAggiuntiva
        {
            get
            {
                return _descrizioneAggiuntiva;
            }

            set
            {
                if (_descrizioneAggiuntiva == value)
                {
                    return;
                }

                _descrizioneAggiuntiva = value;
                CanSave = CheckForSave();
                RaisePropertyChanged(DescrizioneAggiuntivaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsEstero" /> property's name.
        /// </summary>
        public const string IsEsteroPropertyName = "IsEstero";

        private bool _isEstero = false;

        /// <summary>
        /// Sets and gets the bSegno property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsEstero
        {
            get
            {
                return _isEstero;
            }

            set
            {
               
                if (_isEstero == value)
                    return;
                _isEstero = value;
                CanSave = CheckForSave();
               
                RaisePropertyChanged(IsEsteroPropertyName);
            }
        }

        bool CheckForSave()
        {
            bool bRet = _codiceISTAT.Trim().Length > 0 && _descrizione.Length > 0;
            if (bRet && IsNew)
                return !dataservice.CheckForCodiceISTAT(_codiceISTAT.Trim());
            return bRet;

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