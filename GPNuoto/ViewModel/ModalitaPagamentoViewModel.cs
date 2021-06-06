using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.ComponentModel;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ModalitaPagamentoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ModalitaPagamentoViewModel class.
        /// </summary>
        /// 
        public ModalitaPagamentoViewModel()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                Key = "C";
                Descrizione = "CONTANTI";
            }
        }

        /// <summary>
        /// The <see cref="Key" /> property's name.
        /// </summary>
        public const string KeyPropertyName = "Key";

        private string _key = "";

        /// <summary>
        /// Sets and gets the Key property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Key
        {
            get
            {
                return _key;
            }

            set
            {
                if (_key.CompareTo(value.Trim()) == 0)
                {
                    return;
                }
                _key = value.Trim();
                
                if (!SimpleIoc.Default.GetInstance<IDataService>().IsModalitaPagamento(_key) && Descrizione != string.Empty && Key.Length==1)
                    CanSave = true;
                else
                    CanSave = false;
                RaisePropertyChanged(KeyPropertyName);
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
                if (Descrizione != string.Empty && Key.Length == 1)
                    if (!IsNew || (IsNew && !SimpleIoc.Default.GetInstance<IDataService>().IsModalitaPagamento(Key)))
                        CanSave = true;
                    else
                        CanSave = false;
                else
                    CanSave = false;
                RaisePropertyChanged(DescrizionePropertyName);
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
                CanSave = true;
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