using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using static GPNuoto.ViewModel.AnagraficaViewModel;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingolaAnagraficaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingolaAnagraficaViewModel class.
        /// </summary>
        /// 
        //public InfoAggiuntiveModel AnagraficaInfoAdd;

        
        IDataService _dataservice;
        [PreferredConstructor]
        public SingolaAnagraficaViewModel()

        {
            _dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            //if (_dataservice != null)
            //{
            //    AnagraficaInfoAdd = new InfoAggiuntiveModel(_dataservice);
            //}
            if (ViewModelBase.IsInDesignModeStatic)
            {
                //CurrentAttivitaEdit = new SingolaAnagraficaAttivitaViewModel(_dataservice);
                //CurrentAttivitaEdit.ElencoDateCorso = new ObservableCollection<SingolaDataAttivitaViewModel>();
                //SingolaDataAttivitaViewModel savm = new SingolaDataAttivitaViewModel();
                //CurrentAttivitaEdit.ElencoDateCorso.Add(savm);
                Cognome = "Rossi";
                Nome = "Mario";
                TipoFattura = TipoFatturazione.FatturaElettronica;
                CodiceFiscale = "RMNGBR65RB554E";
                FatturaPIVACF = "1209384394";
                Indirizzo = "Via Mira, 11";
                Localita = "Località";
                IDComuneResidenza = 100;
                FatturaCodiceUnivoco = "UF1D0M";
            }

        }
    
        /// <summary>
        /// The <see cref="IDAnagrafica" /> property's name.
        /// </summary>
        public const string IDAnagraficaPropertyName = "IDAnagrafica";

        private int _idAnagrafica = -1;

        /// <summary>
        /// Sets and gets the idAnagrafica property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDAnagrafica
        {
            get
            {
                return _idAnagrafica;
            }

            set
            {
                if (_idAnagrafica == value)
                {
                    return;
                }

                _idAnagrafica = value;
                RaisePropertyChanged(IDAnagraficaPropertyName);
            }
        }



        /// <summary>
        /// The <see cref="Cognome" /> property's name.
        /// </summary>
        public const string CognomePropertyName = "Cognome";

        private string _cognome = "";

        /// <summary>
        /// Sets and gets the Cognome property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Cognome
        {
            get
            {
                return _cognome;
            }



            set
            {


                if (_cognome == value)
                {
                    return;
                }

                _cognome = value;
                RaisePropertyChanged(CognomePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Nome" /> property's name.
        /// </summary>
        public const string NomePropertyName = "Nome";

        private string _nome = "";

        /// <summary>
        /// Sets and gets the Cognome property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nome
        {
            get
            {
                return _nome;
            }



            set
            {


                if (_nome == value)
                {
                    return;
                }

                _nome = value;
                RaisePropertyChanged(NomePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="DataNascita" /> property's name.
        /// </summary>
        public const string DataNascitaPropertyName = "DataNascita";

        private DateTime? _dataNascita;

        /// <summary>
        /// Sets and gets the DataNascita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? DataNascita
        {
            get
            {
                return _dataNascita;
            }

            set
            {
                if (_dataNascita == value)
                {
                    return;
                }

                _dataNascita = value;
                RaisePropertyChanged(DataNascitaPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="StatoNascita" /> property's name.
        /// </summary>
        public const string StatoNascitaPropertyName = "StatoNascita";

        private string _statoNascita = "Italia";

        /// <summary>
        /// Sets and gets the StatoNascita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StatoNascita
        {
            get
            {
                return _statoNascita;
            }

            set
            {
                if (_statoNascita == value)
                {
                    return;
                }

                _statoNascita = value;
                IDLuogoNascita = -1;
                RaisePropertyChanged(StatoNascitaPropertyName);


            }
        }

        /// <summary>
        /// The <see cref="IDLuogoNascita" /> property's name.
        /// </summary>
        public const string IDLuogoNascitaPropertyName = "IDLuogoNascita";

        private int _idluogoNascita = -1;

        /// <summary>
        /// Sets and gets the IDLuogoNascita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDLuogoNascita
        {
            get
            {
                return _idluogoNascita;
            }

            set
            {
                if (_idluogoNascita == value)
                {
                    return;
                }

                _idluogoNascita = value;
                RaisePropertyChanged(IDLuogoNascitaPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="CodiceFiscale" /> property's name.
        /// </summary>
        public const string CodiceFiscalePropertyName = "CodiceFiscale";

        private string _codiceFiscale = string.Empty;

        /// <summary>
        /// Sets and gets the CodiceFiscale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceFiscale
        {
            get
            {
               
                return _codiceFiscale;
            }

            set
            {
                if (_codiceFiscale == value)
                {
                    return;
                }
                _codiceFiscale = value;
                RaisePropertyChanged(CodiceFiscalePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Sesso" /> property's name.
        /// </summary>
        public const string SessoPropertyName = "Sesso";

        private string _sesso = "Maschio";

        /// <summary>
        /// Sets and gets the Sesso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Sesso
        {
            get
            {
                return _sesso;
            }

            set
            {
                if (_sesso == value)
                {
                    return;
                }

                _sesso = value;
                RaisePropertyChanged(SessoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Indirizzo" /> property's name.
        /// </summary>
        public const string IndirizzoPropertyName = "Indirizzo";

        private string _indirizzo = string.Empty;

        /// <summary>
        /// Sets and gets the Indirizzo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Indirizzo
        {
            get
            {
                return _indirizzo;
            }

            set
            {
                if (_indirizzo == value)
                {
                    return;
                }

                _indirizzo = value;
                RaisePropertyChanged(IndirizzoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="IDComuneResidenza" /> property's name.
        /// </summary>
        public const string IDComuneResidenzaPropertyName = "IDComuneResidenza";

        private int _idComuneResidenza = -1;

        /// <summary>
        /// Sets and gets the IDLuogoNascita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDComuneResidenza
        {
            get
            {
                return _idComuneResidenza;
            }

            set
            {
                if (_idComuneResidenza == value)
                {
                    return;
                }

                _idComuneResidenza = value;
                if (_idComuneResidenza > 0)
                    CAP = _dataservice.GetCAP(IDComuneResidenza);
                RaisePropertyChanged(IDComuneResidenzaPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Localita" /> property's name.
        /// </summary>
        public const string LocalitaPropertyName = "Localita";

        private string _localita = string.Empty;

        /// <summary>
        /// Sets and gets the Localita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Localita
        {
            get
            {
                return _localita;
            }

            set
            {
                if (_localita == value)
                {
                    return;
                }

                _localita = value;
                RaisePropertyChanged(LocalitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CAP" /> property's name.
        /// </summary>
        public const string CAPPropertyName = "CAP";

        private string _cap = string.Empty;

        /// <summary>
        /// Sets and gets the CAP property.
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

                _cap = value;
                RaisePropertyChanged(CAPPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Telefono" /> property's name.
        /// </summary>
        public const string TelefonoPropertyName = "Telefono";

        private string _telefono = string.Empty;

        /// <summary>
        /// Sets and gets the Telefono property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                if (_telefono == value)
                {
                    return;
                }
                _telefono = value;
                RaisePropertyChanged(TelefonoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Cellulare" /> property's name.
        /// </summary>
        public const string CellularePropertyName = "Cellulare";

        private string _cellulare = string.Empty;

        /// <summary>
        /// Sets and gets the Cellulare property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Cellulare
        {
            get
            {
                return _cellulare;
            }

            set
            {
                if (_cellulare == value)
                {
                    return;
                }

                _cellulare = value;
                RaisePropertyChanged(CellularePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Email" /> property's name.
        /// </summary>
        public const string EmailPropertyName = "Email";

        private string _email = string.Empty;

        /// <summary>
        /// Sets and gets the Email property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (_email == value)
                {
                    return;
                }

                _email = value;
                RaisePropertyChanged(EmailPropertyName);
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
        /// The <see cref="NominativoFattura" /> property's name.
        /// </summary>
        public const string NominativoFatturaPropertyName = "NominativoFattura";



        /// <summary>
        /// Sets and gets the NominativoFattura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NominativoFattura
        {
            get
            {
                if (DenominazioneFattura != string.Empty)
                    return DenominazioneFattura;
                else
                    return Cognome + " " + Nome;
            }

        }

        /// <summary>
        /// The <see cref="TipoFattura" /> property's name.
        /// </summary>
        public const string TipoFatturaPropertyName = "TipoFattura";

        private TipoFatturazione _tipoFattura = TipoFatturazione.Nessuna;

        /// <summary>
        /// Sets and gets the TipoFattura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TipoFatturazione TipoFattura
        {
            get
            {
                return _tipoFattura;
            }

            set
            {
                if (_tipoFattura == value)
                {
                    return;
                }

                _tipoFattura = value;
               RaisePropertyChanged(TipoFatturaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DenominazioneFattura" /> property's name.
        /// </summary>
        public const string DenominazioneFatturaPropertyName = "DenominazioneFattura";

        private string _denominazioneFattura = string.Empty;

        /// <summary>
        /// Sets and gets the DenominazioneFattura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DenominazioneFattura
        {
            get
            {
                return _denominazioneFattura;
            }

            set
            {
                if (_denominazioneFattura == value)
                {
                    return;
                }

                _denominazioneFattura = value;
                RaisePropertyChanged(DenominazioneFatturaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="FatturaPIVACF" /> property's name.
        /// </summary>
        public const string FatturaPivaCfPropertyName = "FatturaPivaCf";

        private string _fatturaPivaCF = string.Empty;

        /// <summary>
        /// Sets and gets the FatturaPIVACF property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FatturaPIVACF
        {
            get
            {
                return _fatturaPivaCF;
            }

            set
            {
                if (_fatturaPivaCF == value)
                {
                    return;
                }

                _fatturaPivaCF = value;
                RaisePropertyChanged(FatturaPivaCfPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="FatturaIndirizzo" /> property's name.
        /// </summary>
        public const string FatturaIndirizzoPropertyName = "FatturaIndirizzo";

        private string _fatturaIndirizzo = string.Empty;

        /// <summary>
        /// Sets and gets the FatturaIndirizzo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FatturaIndirizzo
        {
            get
            {
                return _fatturaIndirizzo;
            }

            set
            {
                if (_fatturaIndirizzo == value)
                {
                    return;
                }

                _fatturaIndirizzo = value;
                   RaisePropertyChanged(FatturaIndirizzoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="FatturaCodiceUnivoco" /> property's name.
        /// </summary>
        public const string FatturaCodiceUnivocoPropertyName = "FatturaCodiceUnivoco";

        private string _fatturaCodiceUnivoco = string.Empty;

        /// <summary>
        /// Sets and gets the FatturaCodiceUnivoco property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FatturaCodiceUnivoco
        {
            get
            {
                return _fatturaCodiceUnivoco;
            }

            set
            {
                if (_fatturaCodiceUnivoco == value)
                {
                    return;
                }

                _fatturaCodiceUnivoco = value;
                RaisePropertyChanged(FatturaCodiceUnivocoPropertyName);
            }
        }
    }
}