using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
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
    
        
    ///  UNA CASSA APERTA PER OGNI UTENZA INDIPENDENTEMENTE DAL CODICE CONTABILE
    
    public class CassaViewModel : ViewModelBase
    {

        
        public enum StatoCassa  {NonDefinito,Chiusa, Aperta };
        /// <summary>
        /// Initializes a new instance of the CassaViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        [PreferredConstructor]
        public CassaViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
       
            if (ViewModelBase.IsInDesignModeStatic)
            {
                CodiceCassa = "001010";
                User = "gilberto";
                NoteApertura = "La nota di apertura";
                NoteChiusura = "Questa è la nota di chiusura";
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
        /// The <see cref="Stato" /> property's name.
        /// </summary>
        public const string StatoPropertyName = "Stato";

        private  StatoCassa _stato = StatoCassa.NonDefinito;

        /// <summary>
        /// Sets and gets the Stato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public  StatoCassa Stato
        {
            get
            {
                return _stato;
            }

            set
            {
                if (_stato == value)
                {
                    return;
                }

                _stato = value;
                RaisePropertyChanged(IsCassaOpenPropertyName);
                RaisePropertyChanged(StatoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsCassaOpen" /> property's name.
        /// </summary>
        public const string IsCassaOpenPropertyName = "IsCassaOpen";

        /// <summary>
        /// Sets and gets the IsCassaOpen property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsCassaOpen
        {
            get
            {
                return Stato == StatoCassa.Aperta;
            }

        }

        /// <summary>
        /// The <see cref="DataApertura" /> property's name.
        /// </summary>
        public const string DataAperturaPropertyName = "DataApertura";

        private DateTime _dataApertura = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataApertura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataApertura
        {
            get
            {
                return _dataApertura;
            }

            set
            {
                if (_dataApertura == value)
                {
                    return;
                }

                _dataApertura = value;
                RaisePropertyChanged(DataAperturaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DataChiusura" /> property's name.
        /// </summary>
        public const string DataChiusuraPropertyName = "DataChiusura";

        private DateTime _dataChiusura = new DateTime(1,1,1);
            
        /// <summary>
        /// Sets and gets the DataChiusura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataChiusura
        {
            get
            {
                return _dataChiusura;
            }

            set
            {
                if (_dataChiusura == value)
                {
                    return;
                }

                _dataChiusura = value;
                RaisePropertyChanged(DataChiusuraPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ValoreApertura" /> property's name.
        /// </summary>
        public const string ValoreAperturaPropertyName = "ValoreApertura";

        private decimal _valoreApertura = 0;

        /// <summary>
        /// Sets and gets the ValoreApertura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ValoreApertura
        {
            get
            {
                return _valoreApertura;
            }

            set
            {
                if (_valoreApertura == value)
                {
                    return;
                }

                _valoreApertura = value;
                RaisePropertyChanged(ValoreAperturaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ValoreAperturaReale" /> property's name.
        /// </summary>
        public const string ValoreAperturaRealePropertyName = "ValoreAperturaReale";

        private decimal _valoreAperturaReale = 0;

        /// <summary>
        /// Sets and gets the ValoreAperturaReale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ValoreAperturaReale
        {
            get
            {
                return _valoreAperturaReale;
            }

            set
            {
                if (_valoreAperturaReale == value)
                {
                    return;
                }

                _valoreAperturaReale = value;
                RaisePropertyChanged(ValoreAperturaRealePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ValoreChiusura" /> property's name.
        /// </summary>
        public const string ValoreChiusuraPropertyName = "ValoreChiusura";

        private decimal _valoreChiusura = 0;

        /// <summary>
        /// Sets and gets the ValoreChiusura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ValoreChiusura
        {
            get
            {
                return _valoreChiusura;
            }

            set
            {
                if (_valoreChiusura == value)
                {
                    return;
                }

                _valoreChiusura = value;
                RaisePropertyChanged(ValoreChiusuraPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ValoreChiusuraReale" /> property's name.
        /// </summary>
        public const string ValoreChiusuraRealePropertyName = "ValoreChiusuraReale";

        private decimal _valoreChiusuraReale = 0;

        /// <summary>
        /// Sets and gets the ValoreChiusuraReale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ValoreChiusuraReale
        {
            get
            {
                return _valoreChiusuraReale;
            }

            set
            {
                if (_valoreChiusuraReale == value)
                {
                    return;
                }

                _valoreChiusuraReale = value;
                RaisePropertyChanged(ValoreChiusuraRealePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="NoteApertura" /> property's name.
        /// </summary>
        public const string NoteAperturaPropertyName = "NoteApertura";

        private string _noteApertura = string.Empty;

        /// <summary>
        /// Sets and gets the NoteApertura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NoteApertura
        {
            get
            {
                return _noteApertura;
            }

            set
            {
                if (_noteApertura == value)
                {
                    return;
                }

                _noteApertura = value;
                RaisePropertyChanged(NoteAperturaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NoteChiusura" /> property's name.
        /// </summary>
        public const string NoteChiusuraPropertyName = "NoteChiusura";

        private string _noteChiusura = string.Empty;

        /// <summary>
        /// Sets and gets the NoteChiusura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NoteChiusura
        {
            get
            {
                return _noteChiusura;
            }

            set
            {
                if (_noteChiusura == value)
                {
                    return;
                }

                _noteChiusura = value;
                RaisePropertyChanged(NoteChiusuraPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="User" /> property's name.
        /// </summary>
        public const string UserPropertyName = "User";

        private string _user = string.Empty;

        /// <summary>
        /// Sets and gets the User property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string User
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

                _user = value;
                RaisePropertyChanged(NomeCompletoCassaPropertyName);
                RaisePropertyChanged(UserPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CodiceCassa" /> property's name.
        /// </summary>
        public const string CodiceCassaPropertyName = "CodiceCassa";

        private string _codiceCassa = string.Empty;

        /// <summary>
        /// Sets and gets the CodiceCassa property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceCassa
        {
            get
            {
                return _codiceCassa;
            }

            set
            {
                if (_codiceCassa == value)
                {
                    return;
                }

                _codiceCassa = value;
                RaisePropertyChanged(NomeCompletoCassaPropertyName);
                RaisePropertyChanged(CodiceCassaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NomeCompletoCassa" /> property's name.
        /// </summary>
        public const string NomeCompletoCassaPropertyName = "NomeCompletoCassa";

        private string _nomeCompletoCassa = string.Empty;

        /// <summary>
        /// Sets and gets the NomeCompletoCassa property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NomeCompletoCassa
        {
            get
            {
                return _user+"-"+_codiceCassa;
            }

          
        }

        /// <summary>
        /// The <see cref="IsSelected" /> property's name.
        /// </summary>
        public const string IsSelectedPropertyName = "IsSelected";

        private bool _isSelected = false;

        /// <summary>
        /// Sets and gets the IsSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                if (_isSelected == value)
                {
                    return;
                }

                _isSelected = value;
                RaisePropertyChanged(IsSelectedPropertyName);
            }
        }
        private RelayCommand _confermaAperturaCassa;

        /// <summary>
        /// Gets the ApriCassa.
        /// </summary>
        public RelayCommand ConfermaAperturaCassa
        {
            get
            {
                return _confermaAperturaCassa
                    ?? (_confermaAperturaCassa = new RelayCommand(
                    () =>
                    {
                        string msg;

                        if (ValoreApertura != ValoreAperturaReale && NoteApertura == string.Empty)
                            msg = "Il valore di cassa differisce dal valore calcolato.\nE' opportuno inserire una nota esplicativa.\n Confermi richiesta apertura?";
                        else
                            msg = "Confermi richiesta apertura?";
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowMessageBoxView>(new ShowMessageBoxView(msg));
                    }));
            }
        }

        private RelayCommand _apriCassa;

        /// <summary>
        /// Gets the ApriCassa.
        /// </summary>
        public RelayCommand ApriCassa
        {
            get
            {
                return _apriCassa
                    ?? (_apriCassa = new RelayCommand(
                    () =>
                    {
                        dataservice.ApriCassa(this);
                        
                        
                    }));
            }
        }


        private RelayCommand _confermaChiusuraCassa;

        /// <summary>
        /// Gets the ApriCassa.
        /// </summary>
        public RelayCommand ConfermaChiusuraCassa
        {
            get
            {
                return _confermaChiusuraCassa
                    ?? (_confermaChiusuraCassa = new RelayCommand(
                    () =>
                    {
                        string msg;

                        if (ValoreChiusura != ValoreChiusuraReale && NoteChiusura == string.Empty)
                            msg = "Il valore di cassa differisce dal valore calcolato.\nE' opportuno inserire una nota esplicativa.\n Confermi richiesta chiusura?";
                        else
                            msg = "Confermi richiesta chiusura?";
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowMessageBoxView>(new ShowMessageBoxView(msg));
                    }));
            }
        }




        ///   CHIUDERE UNA CASSA SIGNIFICA AFFERMARE DI AVER TRASFERITO I SOLDI ALL'UFFICIO CONTABILE
        private RelayCommand _chiudiCassa;

        /// <summary>
        /// Gets the ChiudiCassa.
        /// </summary>
        public RelayCommand ChiudiCassa
        {
            get
            {
                return _chiudiCassa
                    ?? (_chiudiCassa = new RelayCommand(
                    () =>
                    {
                        dataservice.SalvaChiusuraCassa(this);
                        dataservice.GetStatoCassa(this);
                    }));
            }
        }

        private RelayCommand _refreshCassa;

        /// <summary>
        /// Gets the RefreshCassa.
        /// </summary>
        public RelayCommand RefreshCassa
        {
            get
            {
                return _refreshCassa
                    ?? (_refreshCassa = new RelayCommand(
                    () =>
                    {
                        dataservice.GetStatoCassa(this);
                    }));
            }
        }

    }
}