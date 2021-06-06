
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Converters;
using GPNuoto.Model;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GPNuoto.ViewModel
{

    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AnagraficaViewModel : ViewModelBase
    {
        public enum TipoFatturazione  {Nessuna,Fattura,FatturaElettronica};

        //public InfoAggiuntiveModel     AnagraficaInfoAdd;
        /// <summary>
        /// Initializes a new instance of the AnagraficaViewModel class.
        /// </summary>
        /// 

        IDataService _dataservice;
        [PreferredConstructor]
        public AnagraficaViewModel()

        {
            _dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            //if (_dataservice != null)
            //{
            //    AnagraficaInfoAdd = new InfoAggiuntiveModel(_dataservice);
            //}
            IsCodiceFiscaleOK = false;
            IsFieldChanged = false;
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
        //public AnagraficaViewModel(anagrafica entity)
        //    :this()
        //{
        //    Cognome = entity.Cognome;
        //    Nome = entity.Nome;
        //    CAP = entity.CAP;
        //    Cellulare = entity.Cellulare;
        //    CodiceFiscale = entity.CodiceFiscale;
        //    DataNascita = entity.DataNascita;
        //    Indirizzo = entity.Indirizzo;
        //    TipoFattura = (AnagraficaViewModel.TipoFatturazione)entity.Fattura;
        //    FatturaPIVACF = entity.FatturaPIVACF;
        //    Localita = entity.Localita;
        //    IDComuneResidenza = (entity.IDComuneResidenza !=null) ? (int) entity.IDComuneResidenza : -1;
        //    IDAnagrafica = entity.IDAnagrafica;
        //    DenominazioneFattura = (entity.DenominazioneFattura != null) ?  entity.DenominazioneFattura : string.Empty;
        //    FatturaCodiceUnivoco = entity.FatturaCodiceUnivoco != null ? entity.FatturaCodiceUnivoco : string.Empty;
        //    FatturaIndirizzo = entity.FatturaIndirizzo != null ? entity.FatturaIndirizzo : string.Empty;
        //    DataScadenzaCertificatoMedico = entity.DataScadenzaCertificatoMedico != null ? entity.FatturaIndirizzo : string.Empty;
        //    // COMPLETARE CARICAMENTO ANAGRAFICA SU ENTITY

        //}

        //public void SetDFValue(string FieldName,object objValue)
        //{
        //    AnagraficaInfoAdd.SetValue( FieldName,  objValue);
        //    IsFieldChanged = true;
        //}
       

        //LOOKUP
        /// <summary>
        /// The <see cref="ElencoLuoghiNascita" /> property's name.
        /// </summary>
        public const string ElencoLuoghiNascitaPropertyName = "ElencoLuoghiNascita";

        private List<LookupViewModel> _elencoLuoghiNascita = null;

        /// <summary>
        /// Sets and gets the ElencoLuoghiNascita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<LookupViewModel> ElencoLuoghiNascita
        {
            get
            {
                if (_elencoLuoghiNascita == null)
                {

                    _elencoLuoghiNascita = _dataservice.GetElencoLuoghiNascita(_statoNascita.CompareTo("Italia") != 0);



                }

                return _elencoLuoghiNascita;
            }

            set
            {
                if (_elencoLuoghiNascita == value)
                {
                    return;
                }

                _elencoLuoghiNascita = value;
                RaisePropertyChanged(ElencoLuoghiNascitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoLocalita" /> property's name.
        /// </summary>
        public const string ElencoLocalitaPropertyName = "ElencoLocalita";

        private List<LookupViewModel> _elencoLocalita = null;

        /// <summary>
        /// Sets and gets the ElencoLuoghiNascita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<LookupViewModel> ElencoLocalita
        {
            get
            {
                if (_elencoLocalita == null)
                {

                    

                    _elencoLocalita = _dataservice.GetElencoLocalita();

                }

                return _elencoLocalita;
            }

            set
            {
                if (_elencoLocalita == value)
                {
                    return;
                }

                _elencoLocalita = value;
                RaisePropertyChanged(ElencoLocalitaPropertyName);
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
                //if (_idAnagrafica == value)
                //{
                //    return;
                //}

                _idAnagrafica = value;
                DeletedOn = _idAnagrafica > 0 && _dataservice.CanRemoveAnagrafica(_idAnagrafica);
                AnagraficaAttivitaViewModel cvm = SimpleIoc.Default.GetInstance<AnagraficaAttivitaViewModel>();
                PagamentiViewModel pvm = SimpleIoc.Default.GetInstance<PagamentiViewModel>();
                if (_idAnagrafica <= 0)
                    ShowSelezioneAttivita = false;
                cvm.IsAnagraficaSelected = (_idAnagrafica > 0);
                pvm.IsAnagraficaSelected = (_idAnagrafica > 0);
                ShowSelezioneAttivita = false;
                ShowSelezioneTipoAttivita = false;
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
                ClearOn = _cognome != string.Empty || ClearOn;
                IsFieldChanged = _cognome != string.Empty || IsFieldChanged; 
                RaisePropertyChanged(CognomePropertyName);
                RaisePropertyChanged(CodiceFiscalePropertyName);
                RaisePropertyChanged(SavedOnPropertyName);


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
                ClearOn = _nome != string.Empty || ClearOn;
                IsFieldChanged = _nome != string.Empty || IsFieldChanged;
                RaisePropertyChanged(CodiceFiscalePropertyName);
                RaisePropertyChanged(NomePropertyName);
                RaisePropertyChanged(SavedOnPropertyName);

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
                ClearOn = _dataNascita != null || ClearOn;
                IsFieldChanged = _dataNascita != null || IsFieldChanged;
                RaisePropertyChanged(CodiceFiscalePropertyName);
                RaisePropertyChanged(DataNascitaPropertyName);
                RaisePropertyChanged(EtaPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="Eta" /> property's name.
        /// </summary>
        public const string EtaPropertyName = "Eta";

        

        /// <summary>
        /// Sets and gets the Eta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Eta
        {
            get
            {
                if (DataNascita != null)
                {
                    int age;
                    age = DateTime.Now.Year - ((DateTime)DataNascita).Year;

                    if (age > 0)
                    {
                        age -= Convert.ToInt32(DateTime.Now.Date < ((DateTime)DataNascita).Date.AddYears(age));
                    }
                    else
                        return null;
                    return age;
                }
                else
                    return null;
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
                ElencoLuoghiNascita = null;
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
                ClearOn = _idluogoNascita > 0 || ClearOn;
                IsFieldChanged = _idluogoNascita > 0 || IsFieldChanged;
                RaisePropertyChanged(CodiceFiscalePropertyName);
                RaisePropertyChanged(IDLuogoNascitaPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="idln" /> property's name.
        /// </summary>
        public const string idlnPropertyName = "idln";

        private int _idln = -1;

        /// <summary>
        /// Sets and gets the idln property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int idln
        {
            get
            {
                return _idln;
            }

            set
            {
                if (_idln == value)
                {
                    return;
                }

                _idln = value;
                if (_idln == -1)
                    IDLuogoNascita = -1;
                RaisePropertyChanged(idlnPropertyName);
            }
        }

        public bool IsCodiceFiscaleOK { get; set; }

        
        /// <summary>
        /// The <see cref="IsFieldChanged" /> property's name.
        /// </summary>
        public const string IsFieldChangedPropertyName = "IsFieldChanged";

        private bool _isFieldChanged = false;

        /// <summary>
        /// Sets and gets the IsFieldChanged property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsFieldChanged
        {
            get
            {
                return _isFieldChanged;
            }

            set
            {
                if (_isFieldChanged == value)
                {
                    return;
                }

                _isFieldChanged = value;
                RaisePropertyChanged(SavedOnPropertyName);
                RaisePropertyChanged(ClearOnPropertyName);
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
                //if (_codiceFiscale == string.Empty)
                //{
                //    if (_cognome != string.Empty && _nome != string.Empty && _dataNascita != null && _dataNascita.Year > 1900 && IDLuogoNascita != -1 && Sesso != string.Empty)
                //    {
                //        string codiceISTAT = _ctx.luoghinascita.Where(p => p.IDLuoghiNascita == IDLuogoNascita).Select(p => p.CodiceISTAT).First();

                //        _codiceFiscale = GPNuoto.Model.CodiceFiscale.CalcolaCodiceFiscale(_cognome, _nome, _dataNascita, Sesso.First(), codiceISTAT);
                //        FindAnagraficaForCF.Execute(CodiceFiscale);
                //        IsFieldChanged = (IDAnagrafica == 0);
                //        IsCodiceFiscaleOK = _codiceFiscale != string.Empty;
                //        ClearOn = _codiceFiscale != string.Empty || ClearOn;
                //    }
                //}
                return _codiceFiscale;
            }

            set
            {
                if (_codiceFiscale == value)
                {
                    return;
                }
                _codiceFiscale = value;
                if (!ViewModelBase.IsInDesignModeStatic)
                {
                    ClearOn = _codiceFiscale != string.Empty || ClearOn;
                    IsCodiceFiscaleOK = GPNuoto.Model.CodiceFiscale.ControlloFormaleOK(_codiceFiscale);
                    if (IsCodiceFiscaleOK)
                    {
                        int ID = IDAnagrafica;
                        FindAnagraficaForCF.Execute(CodiceFiscale);
                        IsFieldChanged = (IDAnagrafica == -1 || IDAnagrafica == ID);

                    }
                }
                 RaisePropertyChanged(CodiceFiscalePropertyName);
                 RaisePropertyChanged(SavedOnPropertyName);
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
                RaisePropertyChanged(SavedOnPropertyName);

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
                ClearOn = _indirizzo != string.Empty || ClearOn;
                IsFieldChanged = _indirizzo != string.Empty || IsFieldChanged;
                RaisePropertyChanged(IndirizzoPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
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
                ClearOn = _idComuneResidenza > 0 || ClearOn;
                IsFieldChanged = _idComuneResidenza > 0 || IsFieldChanged;
                RaisePropertyChanged(IDComuneResidenzaPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="idcr" /> property's name.
        /// </summary>
        public const string idcrPropertyName = "idcr";

        private int _idcr = -1;

        /// <summary>
        /// Sets and gets the idcr property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int idcr
        {
            get
            {
                return _idcr;
            }

            set
            {
                if (_idcr == value)
                {
                    return;
                }

                _idcr = value;
                if (_idcr == -1)
                    IDComuneResidenza = -1;
                RaisePropertyChanged(idcrPropertyName);
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

                ClearOn = _localita != string.Empty || ClearOn;
                IsFieldChanged = _localita != string.Empty || IsFieldChanged;
                RaisePropertyChanged(LocalitaPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
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
                ClearOn = _cap != string.Empty ||ClearOn;
                IsFieldChanged = _cap != string.Empty || IsFieldChanged;
                RaisePropertyChanged(CAPPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
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
                ClearOn = _telefono != string.Empty || ClearOn;
                IsFieldChanged = _telefono != string.Empty || IsFieldChanged;
                RaisePropertyChanged(TelefonoPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
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
                ClearOn = (_cellulare != string.Empty) || ClearOn;
                IsFieldChanged = (_cellulare != string.Empty) || IsFieldChanged;
                RaisePropertyChanged(CellularePropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
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
                ClearOn = _email != string.Empty || ClearOn;
                IsFieldChanged = _email != string.Empty || IsFieldChanged;
                RaisePropertyChanged(EmailPropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DataScadenzaCertificatoMedico" /> property's name.
        /// </summary>
        public const string DataScadenzaCertificatoMedicoPropertyName = "DataScadenzaCertificatoMedico";

        private DateTime? _dataScadenzaCertificatoMedico = null;

        /// <summary>
        /// Sets and gets the DataScadenzaCertificatoMedico property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? DataScadenzaCertificatoMedico
        {
            get
            {
                return _dataScadenzaCertificatoMedico;
            }

            set
            {
                if (_dataScadenzaCertificatoMedico == value)
                {
                    return;
                }
                IsFieldChanged = true;
                _dataScadenzaCertificatoMedico = value;
                RaisePropertyChanged(DataScadenzaCertificatoMedicoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ConsegnatoRegolamentoPrivacy" /> property's name.
        /// </summary>
        public const string ConsegnatoRegolamentoPrivacyPropertyName = "ConsegnatoRegolamentoPrivacy";

        private bool _consegnatoRegolamentoPrivacy = false;

        /// <summary>
        /// Sets and gets the ConsegnatoRegolamentoPrivacy property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ConsegnatoRegolamentoPrivacy
        {
            get
            {
                return _consegnatoRegolamentoPrivacy;
            }

            set
            {
                if (_consegnatoRegolamentoPrivacy == value)
                {
                    return;
                }
                IsFieldChanged = true;
                _consegnatoRegolamentoPrivacy = value;
                RaisePropertyChanged(ConsegnatoRegolamentoPrivacyPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="LivelloNuoto" /> property's name.
        /// </summary>
        public const string LivelloNuotoPropertyName = "LivelloNuoto";

        private int _livelloNuoto = 0;

        /// <summary>
        /// Sets and gets the LivelloNuoto property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LivelloNuoto
        {
            get
            {
                return _livelloNuoto;
            }

            set
            {
                if (_livelloNuoto == value)
                {
                    return;
                }
                IsFieldChanged = true;
                _livelloNuoto = value;
                RaisePropertyChanged(LivelloNuotoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AssicuratoFinoA" /> property's name.
        /// </summary>
        public const string AssicuratoFinoAPropertyName = "AssicuratoFinoA";

        private DateTime? _assicuratoFinoA = null;

        /// <summary>
        /// Sets and gets the AssicuratoFinoA property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? AssicuratoFinoA
        {
            get
            {
                return _assicuratoFinoA;
            }

            set
            {
                if (_assicuratoFinoA == value)
                {
                    return;
                }
                IsFieldChanged = true;
                _assicuratoFinoA = value;
                RaisePropertyChanged(AssicuratoFinoAPropertyName);
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
                ClearOn = _note != string.Empty || ClearOn;
                IsFieldChanged = _note != string.Empty || IsFieldChanged;
                RaisePropertyChanged(NotePropertyName);
                RaisePropertyChanged(SavedOnPropertyName);
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
        /// The <see cref="SavedOn" /> property's name.
        /// </summary>
        public const string SavedOnPropertyName = "SavedOn";

        /// <summary>
        /// Sets and gets the IsFieldChanged property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool SavedOn
        {
            get
            {
                return IsCodiceFiscaleOK && IsFieldChanged && IsAnagraficaCorretta();
            }

        }
        /// <summary>
        /// The <see cref="DeletedOn" /> property's name.
        /// </summary>
        public const string DeletedOnPropertyName = "DeletedOn";

        private bool _deleteOn = false;

        /// <summary>
        /// Sets and gets the DeletedOn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool DeletedOn
        {
            get
            {
                return _deleteOn;
            }

            set
            {
                if (_deleteOn == value)
                {
                    return;
                }

                _deleteOn = value;
                RaisePropertyChanged(DeletedOnPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ClearOn" /> property's name.
        /// </summary>
        public const string ClearOnPropertyName = "ClearOn";

        private bool _clearOn = false;

        /// <summary>
        /// Sets and gets the DeletedOn property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ClearOn
        {
            get
            {
                return _clearOn;
            }

            set
            {
                if (_clearOn == value)
                {
                    return;
                }

                _clearOn = value;
                RaisePropertyChanged(ClearOnPropertyName);
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
                IsFieldChanged = true;
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
                IsFieldChanged = true;
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
                IsFieldChanged = true;
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
                IsFieldChanged = true;
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
                IsFieldChanged = true;
                RaisePropertyChanged(FatturaCodiceUnivocoPropertyName);
            }
        }


         /// <summary>
        /// The <see cref="CurrentAttivitaEdit" /> property's name.
        /// </summary>
        public const string CurrentAttivitaEditPropertyName = "CurrentAttivitaEdit";

        private SingolaAnagraficaAttivitaViewModel _currentAttivitaedit;

        /// <summary>
        /// Sets and gets the CurrentAttivitaEdit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingolaAnagraficaAttivitaViewModel CurrentAttivitaEdit
        {
            get
            {
                return _currentAttivitaedit;
            }

            set
            {
                if (_currentAttivitaedit == value)
                {
                    return;
                }

                _currentAttivitaedit = value;
                RaisePropertyChanged(CurrentAttivitaEditPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ShowTipoSelezioneAttivita" /> property's name.
        /// </summary>
        public const string ShowSelezioneTipoAttivitaPropertyName = "ShowSelezioneTipoAttivita";

        private bool _showSelezioneTipoAttivita = false;

        /// <summary>
        /// Sets and gets the ShowSelezioneAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowSelezioneTipoAttivita
        {
            get
            {
                return _showSelezioneTipoAttivita;
            }

            set
            {
                if (_showSelezioneTipoAttivita == value)
                {
                    return;
                }

                _showSelezioneTipoAttivita = value;
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowSelezioneTipoAttivita>(new ShowSelezioneTipoAttivita(_showSelezioneTipoAttivita));
                RaisePropertyChanged(ShowSelezioneTipoAttivitaPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ShowSelezioneAttivita" /> property's name.
        /// </summary>
        public const string ShowSelezioneAttivitaPropertyName = "ShowSelezioneAttivita";

        private bool _showSelezioneAttivita = false;

        /// <summary>
        /// Sets and gets the ShowSelezioneAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowSelezioneAttivita
        {
            get
            {
                return _showSelezioneAttivita;
            }

            set
            {
                if (_showSelezioneAttivita == value)
                {
                    return;
                }

                _showSelezioneAttivita = value;
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowSelezioneAttivita>(new ShowSelezioneAttivita(_showSelezioneAttivita));
                RaisePropertyChanged(ShowSelezioneAttivitaPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ShowEditAttivita" /> property's name.
        /// </summary>
        public const string ShowEditPropertyName = "ShowEditAttivita";

        private bool _showEditAttivita = false;

        /// <summary>
        /// Sets and gets the ShowSelezioneAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowEditAttivita
        {
            get
            {
                return _showEditAttivita;
            }

            set
            {
                if (_showEditAttivita == value)
                {
                    return;
                }

                _showEditAttivita = value;
                if  (_showEditAttivita)
                    GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditAttivita>(new ShowEditAttivita(CurrentAttivitaEdit));
                else
                    GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditAttivita>(new ShowEditAttivita(null));
                RaisePropertyChanged(ShowSelezioneAttivitaPropertyName);
            }
        }



        /// <summary>
        /// The <see cref="ShowEditPagamento" /> property's name.
        /// </summary>
        public const string ShowEditPagamentoPropertyName = "ShowEditPagamento";

        private bool _showEditPagamento = false;

        /// <summary>
        /// Sets and gets the ShowSelezioneAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ShowEditPagamento
        {
            get
            {
                return _showEditPagamento;
            }

            set
            {
                if (_showEditPagamento == value)
                {
                    return;
                }

                       _showEditPagamento = value;
                if (_showEditPagamento)
                    GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditPagamento>(new ShowEditPagamento(true));
                else
                    GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditPagamento>(new ShowEditPagamento(false));
                RaisePropertyChanged(ShowEditPagamentoPropertyName);
            }
        }





        /// <summary>
        /// The <see cref="ResultSet" /> property's name.
        /// </summary>
        public const string ResultSetPropertyName = "ResultSet";

        private ObservableCollection<ResultSetAnagraficaViewModel> _resultSet = new ObservableCollection<ResultSetAnagraficaViewModel>();

        /// <summary>
        /// Sets and gets the ResultSet property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ResultSetAnagraficaViewModel> ResultSet
        {
            get
            {
                return _resultSet;
            }

            set
            {
                if (_resultSet == value)
                {
                    return;
                }

                _resultSet = value;
                RaisePropertyChanged(ResultSetPropertyName);
            }
        }

        /// <summary>
            /// The <see cref="SelectedAnagrafica" /> property's name.
            /// </summary>
        public const string SelectedAnagraficaPropertyName = "SelectedAnagrafica";

        private ResultSetAnagraficaViewModel _selectedAnagrafica = null;

        /// <summary>
        /// Sets and gets the SelectedAnagrafica property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ResultSetAnagraficaViewModel SelectedAnagrafica
        {
            get
            {
                return _selectedAnagrafica;
            }

            set
            {
                if (_selectedAnagrafica == value)
                {
                    return;
                }

                _selectedAnagrafica = value;
                RaisePropertyChanged(SelectedAnagraficaPropertyName);
            }
        }
        private RelayCommand<string> _FindAnagraficaForCF;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public  RelayCommand<string> FindAnagraficaForCF
        {
            get
            {
                return _FindAnagraficaForCF
                    ?? (_FindAnagraficaForCF = new RelayCommand<string>(
                    p =>
                    {
                        List<int> ql = _dataservice.GetAnagraficaByCF(CodiceFiscale);
                        
                        if (ql.Count() > 0)
                        {

                            // Trovata anagrafica
                            _dataservice.GetAnagraficaById(this, ql.First());


                            //var view = new SampleDialog
                            //{
                            //    DataContext = new SampleDialogViewModel()
                            //};

                            //show the dialog
                            //var result = await DialogHost.Show(view, "RootDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

                            //check the result...
                           // Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));




                        }

                    }));
            }
            
        }
        /// <summary>
        /// The <see cref="IndirizzoFatturaCalcolato" /> property's name.
        /// </summary>
        public const string IndirizzoFatturaCalcolatoPropertyName = "IndirizzoFatturaCalcolato";

        

        /// <summary>
        /// Sets and gets the IndirizzoFatturaCalcolato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string IndirizzoFatturaCalcolato
        {
            get
            {
                if (FatturaIndirizzo != string.Empty)
                    return FatturaIndirizzo;
                else
                {
                    string s = Indirizzo + " - " + CAP + (Localita != string.Empty ? " " + Localita : string.Empty);
                    if (IDComuneResidenza > 0)
                    {
                        s = s + " "+_dataservice.GetComuneFromID(IDComuneResidenza);
                    }
                    return s;
                }
                
            }

        }
        private RelayCommand _salvaRecord;

        /// <summary>
        /// Gets the SalvaRecord.
        /// </summary>
        public RelayCommand SalvaRecord
        {
            get
            {
                return _salvaRecord
                    ?? (_salvaRecord = new RelayCommand(
                    () =>
                    {
                        string codiceISTAT = _dataservice.GetCodiceISTAT(IDLuogoNascita); 
                        bool bSave = true;
                        if (GPNuoto.Model.CodiceFiscale.CalcolaCodiceFiscale(Cognome, Nome,(DateTime)DataNascita, Sesso.First(), codiceISTAT).CompareTo(CodiceFiscale) != 0)
                            bSave = MessageBox.Show("Il codice fiscale inserito sembra non coincedere con il calcolo dello stesso a partire dai dati inseriti. Si desidera forzare il CODICE FISCALE inserito?", "Attenzione CODICE FISCALE non coerente con i dati", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
                        if (bSave)
                        {

                            IDAnagrafica = _dataservice.SaveAnagrafica(this);
                            IsFieldChanged = false;
                            SimpleIoc.Default.GetInstance<AnagraficaAttivitaViewModel>().IsAnagraficaSelected = true;

                        }
                        }));
            }
        }



        private RelayCommand __rimuoviAnagrafica;

        /// <summary>
        /// Gets the SalvaRecord.
        /// </summary>
        public RelayCommand RimuoviAnagrafica
        {
            get
            {
                return __rimuoviAnagrafica
                    ?? (__rimuoviAnagrafica = new RelayCommand(
                    () =>
                    {
                        bool bCancella = MessageBox.Show("Questa operazione elimina l'anagrafica e tutti gli elementi collegati. Vuoi annullare l'operazione?", "Attenzione", MessageBoxButton.YesNo) == MessageBoxResult.No;
                        if (bCancella)
                        {
                            
                            if (ResultSet != null)
                            {
                                ResultSetAnagraficaViewModel rsa = ResultSet.First(p => p.IDAnagrafica == IDAnagrafica);
                                ResultSet.Remove(rsa);
                            }
                            _dataservice.RemoveAnagrafica(IDAnagrafica);
                            NuovoRecord.Execute(null);
                        }

                    }));
            }
        }



        private RelayCommand _NuovoRecord;

        /// <summary>
        /// Gets the ResetAnagrafica.
        /// </summary>
        public RelayCommand NuovoRecord
        {
            get
            {
                return _NuovoRecord
                    ?? (_NuovoRecord = new RelayCommand(ClearCurrentAnagrafica));
            }
        }


        private RelayCommand _gotoAnagrafica;

        /// <summary>
        /// Gets the GotoAnagrafica.
        /// </summary>
        public RelayCommand GotoAnagrafica
        {
            get
            {
                return _gotoAnagrafica
                    ?? (_gotoAnagrafica = new RelayCommand(ExecuteGotoAnagrafica));
            }
        }

        private void ExecuteGotoAnagrafica()
        {
            if (SelectedAnagrafica != null)
            {
                //int id = ResultSet[SelectedAnagrafica].IDAnagrafica;
                _dataservice.GetAnagraficaById(this,SelectedAnagrafica.IDAnagrafica);
                if (ShowEditAttivita)
                ShowEditAttivita = false;
                if (ShowSelezioneAttivita)
                    ShowSelezioneAttivita = false;
                if (ShowEditPagamento)
                    ShowEditPagamento = false;
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditDateAttivita>(new ShowEditDateAttivita(null));
            }
        }



        private RelayCommand _ricercaAnagrafica;

        /// <summary>
        /// Gets the ResetAnagrafica.
        /// </summary>
        public RelayCommand RicercaAnagrafica
        {
            get
            {
                return _ricercaAnagrafica
                    ?? (_ricercaAnagrafica = new RelayCommand(RicercaAnagraficaStart));
            }
        }

        private RelayCommand _calcolaCodiceFiscale;

        /// <summary>
        /// Gets the ResetAnagrafica.
        /// </summary>
        public RelayCommand CalcolaCodiceFiscale
        {
            get
            {
                return _calcolaCodiceFiscale
                    ?? (_calcolaCodiceFiscale = new RelayCommand(
                        () =>
                        {
                            if (_cognome != string.Empty && _nome != string.Empty && _dataNascita != null && ((DateTime)_dataNascita).Year > 1900 && IDLuogoNascita != -1 && Sesso != string.Empty)
                            {
                                string codiceISTAT = _dataservice.GetCodiceISTAT(IDLuogoNascita);

                                CodiceFiscale = GPNuoto.Model.CodiceFiscale.CalcolaCodiceFiscale(_cognome, _nome, (DateTime)_dataNascita, Sesso.First(), codiceISTAT);
                            }

                        }));
            }
        }

     

        private RelayCommand<SingolaAnagraficaAttivitaViewModel> _editAttivita;

        /// <summary>
        /// Gets the EditAttivita.
        /// </summary>
        public RelayCommand<SingolaAnagraficaAttivitaViewModel> EditAttivita
        {
            get
            {
                return _editAttivita
                    ?? (_editAttivita = new RelayCommand<SingolaAnagraficaAttivitaViewModel>(
                    p =>
                    {
                        CurrentAttivitaEdit = p;
                        CurrentAttivitaEdit.SaveParametri();
                        ShowEditAttivita = true;
                    }));
            }
        }


        private RelayCommand<SingolaAnagraficaAttivitaViewModel> _deleteAttivita;

        /// <summary>
        /// Gets the EditAttivita.
        /// </summary>
        public RelayCommand<SingolaAnagraficaAttivitaViewModel> DeleteAttivita
        {
            get
            {
                return _deleteAttivita
                    ?? (_deleteAttivita = new RelayCommand<SingolaAnagraficaAttivitaViewModel>(
                    p =>
                    {
                        CurrentAttivitaEdit = null;
                        ShowEditAttivita = false;
                        SimpleIoc.Default.GetInstance<AnagraficaAttivitaViewModel>().DeleteAttivita.Execute(p);

                    }));
            }
        }


       private RelayCommand<SingolaAnagraficaAttivitaViewModel> _pagamentoAttivita;

        /// <summary>
        /// Gets the EditAttivita.
        /// </summary>
        public RelayCommand<SingolaAnagraficaAttivitaViewModel> PagamentoAttivita
        {
            get
            {
                return _pagamentoAttivita
                    ?? (_pagamentoAttivita = new RelayCommand<SingolaAnagraficaAttivitaViewModel>(
                    p =>
                    {
                        ShowEditAttivita = false;
                        ShowEditPagamento = true;
                        SimpleIoc.Default.GetInstance<PagamentiViewModel>().PagamentoAttivita.Execute(p);
                    }));
            }
        }


        private RelayCommand _pagamentoExtraAttivita;

        /// <summary>
        /// Gets the EditAttivita.
        /// </summary>
        public RelayCommand PagamentoExtraAttivita
        {
            get
            {
                return _pagamentoExtraAttivita
                    ?? (_pagamentoExtraAttivita = new RelayCommand(
                    () =>
                    {
                        ShowEditPagamento = true;
                        SimpleIoc.Default.GetInstance<PagamentiViewModel>().PagamentoExtraAttivita.Execute(null);
                    }));
            }
        }


        private RelayCommand _clear;

        /// <summary>
        /// Gets the Clear.
        /// </summary>
        public RelayCommand Clear
        {
            get
            {
                return _clear
                    ?? (_clear = new RelayCommand(
                    () =>
                    {
                        ClearCurrentAnagrafica();
                        ResultSet = null;
                    }));
            }
        }

        private RelayCommand _clearOnlyAnagrafica;

        /// <summary>
        /// Gets the Clear.
        /// </summary>
        public RelayCommand ClearOnlyAnagrafica
        {
            get
            {
                return _clearOnlyAnagrafica
                    ?? (_clearOnlyAnagrafica = new RelayCommand(
                    () =>
                    {
                        ClearCurrentAnagrafica();
                        
                    }));
            }
        }

        private RelayCommand<QRCodeViewModel.QrCodeEntry> _rinnovaAttivita;

        /// <summary>
        /// Gets the RinnnovaAttivita.
        /// </summary>
        public RelayCommand<QRCodeViewModel.QrCodeEntry> RinnnovaAttivita
        {
            get
            {
                return _rinnovaAttivita
                    ?? (_rinnovaAttivita = new RelayCommand<QRCodeViewModel.QrCodeEntry>(
                    p =>
                    {
                        // in qrcode del quale ci interessa CF e attività
                        _dataservice.RinnovoAttivita(p.CodiceFiscale, p.Attivita);



                        


                    }));
            }
        }


        private void ClearCurrentAnagrafica()
        {
            
            IDAnagrafica = -1;
            CAP = string.Empty;
            Cellulare = string.Empty;
            Cognome = string.Empty;
            DataNascita = null ;
            Email = string.Empty;
            IDComuneResidenza = -1;
            IDLuogoNascita = -1;
            Indirizzo = string.Empty;
            Nome = string.Empty;
            Note = string.Empty;
            Sesso = "Maschio";
            Telefono = string.Empty;
            CodiceFiscale = string.Empty;
            DenominazioneFattura = string.Empty;
            FatturaIndirizzo = string.Empty;
            FatturaPIVACF = string.Empty; ;
            FatturaCodiceUnivoco = string.Empty;
            TipoFattura  = TipoFatturazione.Nessuna;
            Localita = string.Empty;
            //AnagraficaInfoAdd.Clear();
            DataScadenzaCertificatoMedico = null;
            AssicuratoFinoA = null;
            LivelloNuoto = 0;
            ConsegnatoRegolamentoPrivacy = false;
            IsFieldChanged = false;
            ClearOn = false;
            if (ShowEditAttivita)
                ShowEditAttivita = false;
            if(ShowSelezioneAttivita)
                ShowSelezioneAttivita = false;
            if (ShowEditPagamento)
                ShowEditPagamento = false;
            SimpleIoc.Default.GetInstance<TesseraViewModel>().Refresh(null);
            //GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshInformazioniAggiuntiveAnagrafica>(new RefreshInformazioniAggiuntiveAnagrafica());
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditDateAttivita>(new ShowEditDateAttivita(null));

        }

        void RicercaAnagraficaStart()
        {
            // Acquisisco i parametri di filtraggio
            ResultSet = _dataservice.QueryAnagrafica(this);
          
        }


        bool IsAnagraficaCorretta()
        {
            return (Cognome != string.Empty && Nome != string.Empty && IDLuogoNascita > 0 && DataNascita != null) ;
        }

       public void ResultSetFromID(List<int> idList,bool bSetFirst)
        {

            ResultSet = null;
            ResultSet = _dataservice.QueryAnagraficaFromID(idList);
            if (bSetFirst && ResultSet.Count() > 0)
            {
                SelectedAnagrafica = null;
                //IDAnagrafica = -1;
                //SetCurrentAnagrafica(_dataservice.GetAnagraficaById(ResultSet[0].IDAnagrafica));

                SelectedAnagrafica = ResultSet[0];
                GotoAnagrafica.Execute(SelectedAnagrafica);

            }
        }
    
        public void ResultSetFromCF(string CF)
        {
            ResultSet = null;
            ResultSet =  _dataservice.QueryAnagraficaByCode(CF);

            if (ResultSet.Count() > 0)
            {
                SelectedAnagrafica = ResultSet[0];
                GotoAnagrafica.Execute(SelectedAnagrafica);
            }

        }

        private void SetCurrentAnagrafica(AnagraficaROViewModel rec)
        {
            IDAnagrafica = rec.IDAnagrafica;
            CAP = rec.CAP;
            Cellulare = rec.Cellulare;
            CodiceFiscale = rec.CodiceFiscale;
            Cognome = rec.Cognome;
            DataNascita = rec.DataNascita;
            Email = rec.Email;
            IDComuneResidenza = (int)rec.IDComuneResidenza;
            IDLuogoNascita = rec.IDLuogoNascita;
            Indirizzo = rec.Indirizzo;
            Localita = rec.Localita;
            Nome = rec.Nome;
            Note = rec.Note;
            Sesso = rec.Sesso;
            Telefono = rec.Telefono;
            TipoFattura = rec.TipoFattura;
            DenominazioneFattura = rec.DenominazioneFattura;
            FatturaIndirizzo = rec.FatturaIndirizzo;
            FatturaPIVACF = rec.FatturaPIVACF;
            FatturaCodiceUnivoco = rec.FatturaCodiceUnivoco;
            DataScadenzaCertificatoMedico = rec.DataScadenzaCertificatoMedico;
            ConsegnatoRegolamentoPrivacy = rec.ConsegnatoRegolamentoPrivacy;
            AssicuratoFinoA = rec.AssicuratoFinoA;
            LivelloNuoto = rec.LivelloNuoto;
            //AnagraficaInfoAdd.LoadValues(rec.IDAnagrafica);
        }


    }

}