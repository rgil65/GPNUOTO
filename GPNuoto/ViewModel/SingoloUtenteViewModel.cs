using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingoloUtenteViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloUtenteViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public SingoloUtenteViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
        }

        public void Logout()
        {

            IsLogin = false;
            user = string.Empty;
            password = string.Empty;
            IsAttivaProgettazioneCorsi = false;
            IsAttivaContabilita = false;
            IsAttivaConfigurazione = false;
            IsAttivaAccoglienza = false;
            
        }
        /// <summary>
        /// The <see cref="user" /> property's name.
        /// </summary>
        public const string userPropertyName = "user";

        private string _user = string.Empty;

        /// <summary>
        /// Sets and gets the user property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string user
        {
            get
            {
                return _user;
            }

            set
            {
                if (_user == value)
                {
                    return;
                }

                _user = value.ToLower();
                _user = _user.Replace("\\", "");
                //if (_user != string.Empty)
                //    dataservice.GetStatoCassa(SimpleIoc.Default.GetInstance<CassaViewModel>());
                RaisePropertyChanged(userPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="password" /> property's name.
        /// </summary>
        public const string passwordPropertyName = "password";

        private string _password = string.Empty;

        /// <summary>
        /// Sets and gets the password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string password
        {
            get
            {
                return _password;
            }

            set
            {
                if (_password == value)
                {
                    return;
                }

                _password = value;
                RaisePropertyChanged(passwordPropertyName);
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
                if (user.Trim().Length > 0)
                    CanSave = true;
                RaisePropertyChanged(NotePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IsLogin" /> property's name.
        /// </summary>
        public const string IsLoginPropertyName = "IsLogin";

        private bool _isLogin = false;

        /// <summary>
        /// Sets and gets the IsLogin property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLogin
        {
            get
            {
                return _isLogin;
            }

            set
            {
                if (_isLogin == value)
                {
                    return;
                }

                _isLogin = value;
                RaisePropertyChanged(IsLoginPropertyName);
            }
        }

        /// <summary>
            /// The <see cref="CodiceContabileCassa" /> property's name.
            /// </summary>
        public const string CodiceContabileCassaPropertyName = "CodiceContabileCassa";

        private string _codiceContabileCassa = string.Empty;

        /// <summary>
        /// Sets and gets the CodiceContabileCassa property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceContabileCassa
        {
            get
            {
                return _codiceContabileCassa;
            }

            set
            {
                if (_codiceContabileCassa == value)
                {
                    return;
                }

                _codiceContabileCassa = value;
                if (user.Trim().Length > 0)
                    CanSave = true;
                RaisePropertyChanged(CodiceContabileCassaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsAttivaAccoglienza" /> property's name.
        /// </summary>
        public const string IsAttivaAccoglienzaPropertyName = "IsAttivaAccoglienza";

        private bool _isAttivaAccoglienza = false;

        /// <summary>
        /// Sets and gets the IsAttivaAccoglienza property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivaAccoglienza
        {
            get
            {
                return _isAttivaAccoglienza;
            }

            set
            {
                if (_isAttivaAccoglienza == value)
                {
                    return;
                }

                _isAttivaAccoglienza = value;
                if (user.Trim().Length > 0)
                    CanSave = true;
                RaisePropertyChanged(IsAttivaAccoglienzaPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IsAttivaProgettazioneCorsi" /> property's name.
        /// </summary>
        public const string IsAttivaProgettazioneCorsiPropertyName = "IsAttivaProgettazioneCorsi";

        private bool _isAttivaProgettazioneCorsi = false;

        /// <summary>
        /// Sets and gets the IsAttivaProgettazioneCorsi property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivaProgettazioneCorsi
        {
            get
            {
                return _isAttivaProgettazioneCorsi;
            }

            set
            {
                if (_isAttivaProgettazioneCorsi == value)
                {
                    return;
                }

                _isAttivaProgettazioneCorsi = value;
                if (user.Trim().Length > 0)
                    CanSave = true;
                RaisePropertyChanged(IsAttivaProgettazioneCorsiPropertyName);
            }
        }
        /// <summary>
            /// The <see cref="IsAttivaConfigurazione" /> property's name.
            /// </summary>
        public const string IsAttivaConfigurazionePropertyName = "IsAttivaConfigurazione";

        private bool _isAttivaConfigurazione = false;

        /// <summary>
        /// Sets and gets the IsAttivaConfigurazione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivaConfigurazione
        {
            get
            {
                return _isAttivaConfigurazione;
            }

            set
            {
                if (_isAttivaConfigurazione == value)
                {
                    return;
                }

                _isAttivaConfigurazione = value;
                if (user.Trim().Length > 0)
                    CanSave = true;
                RaisePropertyChanged(IsAttivaConfigurazionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsAttivaContabilita" /> property's name.
        /// </summary>
        public const string IsAttivaContabilitaPropertyName = "IsAttivaContabilita";

        private bool _isAttivaContabilita = false;

        /// <summary>
        /// Sets and gets the IsAttivaContabilita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivaContabilita
        {
            get
            {
                return _isAttivaContabilita;
            }

            set
            {
                if (_isAttivaContabilita == value)
                {
                    return;
                }

                _isAttivaContabilita = value;
                if (user.Trim().Length > 0)
                    CanSave = true;
                RaisePropertyChanged(IsAttivaContabilitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Abilitazioni" /> property's name.
        /// </summary>
        public const string AbilitazioniPropertyName = "Abilitazioni";



        /// <summary>
        /// Sets and gets the Abilitazioni property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Abilitazioni
        {
            get
            {
                string ab;
                ab = IsAttivaAccoglienza?"A":"-";
                ab = ab + (IsAttivaContabilita?"C":"-");
                ab = ab + (IsAttivaProgettazioneCorsi ? "P" : "-");
                ab = ab + (IsAttivaConfigurazione ? "C" : "-");
                return ab;
            }

        }
        /// <summary>
        /// The <see cref="ElencoCodiciContabili" /> property's name.
        /// </summary>
        public const string ElencoCodiciContabiliPropertyName = "ElencoCodiciContabili";

        private List<SingoloCodiceContabileViewModel> _elencoCodiciContabili = null;

        /// <summary>
        /// Sets and gets the ElencoCodiciContabili property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloCodiceContabileViewModel> ElencoCodiciContabili
        {
            get
            {
                if (_elencoCodiciContabili == null)
                {
                    IDataService ds = SimpleIoc.Default.GetInstance<IDataService>();
                    List<SingoloCodiceContabileViewModel> lcc = ds.GetElencoCodiciContabili(false, false);
                    _elencoCodiciContabili = lcc.OrderBy(p => p.Descrizione).ToList();
                }
                return _elencoCodiciContabili;
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
                if (user.Trim().Length > 0)
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

        public bool CheckForLogin()
        {
            
            IsLogin = dataservice.CheckForUserAuthorize(this);
            return IsLogin;
        }
    }
}