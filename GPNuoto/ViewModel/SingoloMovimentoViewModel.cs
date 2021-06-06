using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingoloMovimentoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloMovimentoViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        [PreferredConstructor]
        public SingoloMovimentoViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                ImportoPagato = 999;
                DataPagamento = DateTime.Now; ;
                ModalitaPagamento = new ModalitaPagamentoViewModel();
                Descrizione = "Descrizione di prova";
            }
            CanSave = CheckForSave();
        }

        public SingoloMovimentoViewModel(bool bOnlyExtra)
            :this()
        {
            FiltroOnlyAttivitaExtra = bOnlyExtra;
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

        /// <summary>
        /// The <see cref="CanDelete" /> property's name.
        /// </summary>
        public const string CanDeletePropertyName = "CanDelete";

        private bool _canDelete = false;

        /// <summary>
        /// Sets and gets the CanDelete property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanDelete
        {
            get
            {
                return _canDelete;
            }

            set
            {
                if (_canDelete == value)
                {
                    return;
                }

                _canDelete = value;
                RaisePropertyChanged(CanDeletePropertyName);
            }
        }



        /// <summary>
        /// The <see cref="IsMovimentoFiscale" /> property's name.
        /// </summary>
        public const string IsMovimentoFiscalePropertyName = "IsMovimentoFiscale";

        private bool _isMovimentoFiscale = false;

        /// <summary>
        /// Sets and gets the IsMovimentoFiscale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsMovimentoFiscale
        {
            get
            {
                return _isMovimentoFiscale;
            }

            set
            {
                if (_isMovimentoFiscale == value)
                {
                    return;
                }

                _isMovimentoFiscale = value;
                RaisePropertyChanged(IsMovimentoFiscalePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IsRicevutaFiscaleStampabile" /> property's name.
        /// </summary>
        public const string IsRicevutaFiscaleStampabilePropertyName = "IsRicevutaFiscaleStampabile";

        

        /// <summary>
        /// Sets and gets the IsRicevutaFiscaleStampabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsRicevutaFiscaleStampabile
        {
            get
            {
                return ID > 0 && IsMovimentoFiscale;
            }

            
        }


        /// <summary>
        /// The <see cref="FiltroOnlyAttivitaExtra" /> property's name.
        /// </summary>
        public const string FiltroOnlyAttivitaExtraPropertyName = "FiltroOnlyAttivitaExtra";

        private bool _filtroOnlyAttivitaExtra = true;

        /// <summary>
        /// Sets and gets the FiltroOnlyAttivitaExtra property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool FiltroOnlyAttivitaExtra
        {
            get
            {
                return _filtroOnlyAttivitaExtra;
            }

            set
            {
                if (_filtroOnlyAttivitaExtra == value)
                {
                    return;
                }

                _filtroOnlyAttivitaExtra = value;
                RaisePropertyChanged(FiltroOnlyAttivitaExtraPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsModified" /> property's name.
        /// </summary>
        public const string IsModifiedPropertyName = "IsModified";

        private bool _isModified = false;

        /// <summary>
        /// Sets and gets the IsModified property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsModified
        {
            get
            {
                return _isModified;
            }

            set
            {
                if (_isModified == value)
                {
                    return;
                }

                _isModified = value;
                RaisePropertyChanged(IsModifiedPropertyName);
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
                CanSave = CheckForSave();
                RaisePropertyChanged(IDPropertyName);
                RaisePropertyChanged(IsRicevutaFiscaleStampabilePropertyName);

            }
        }

        /// <summary>
        /// The <see cref="IDAnagraficaAttivita" /> property's name.
        /// </summary>
        public const string IDAnagraficaAttivitaPropertyName = "IDAnagraficaAttivita";

        private int _idAnagraficaAttivita = 0;

        /// <summary>
        /// Sets and gets the IDAnagraficaAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDAnagraficaAttivita
        {
            get
            {
                return _idAnagraficaAttivita;
            }

            set
            {
                if (_idAnagraficaAttivita == value)
                {
                    return;
                }

                _idAnagraficaAttivita = value;
                
                
                RaisePropertyChanged(IDAnagraficaAttivitaPropertyName);
            }
        }
        public int IDAnagrafica { get; set; }


        public AnagraficaROViewModel AnagraficaCollegata

        {
            get
            {
                if (IDAnagrafica > 0)
                    return dataservice.GetAnagraficaById(IDAnagrafica);
                else
                    return null;
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
        /// The <see cref="DataPagamento" /> property's name.
        /// </summary>
        public const string DataPagamentoPropertyName = "DataPagamento";

        private DateTime _dataPagamento = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataPagamento
        {
            get
            {
                return _dataPagamento;
            }

            set
            {
                if (_dataPagamento == value)
                {
                    return;
                }

                _dataPagamento = value;
                SimpleIoc.Default.GetInstance<StampaRicevutaViewModel>().
                RaisePropertyChanged(DataPagamentoPropertyName);
            }
        }

       
        /// <summary>
        /// The <see cref="DataOraPagamento" /> property's name.
        /// </summary>
        public const string DataOraPagamentoPropertyName = "DataOraPagamento";

        

        /// <summary>
        /// Sets and gets the DataOraPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DataOraPagamento
        {
            get
            {
                return DataPagamento.ToString("dd/MM/yyyy HH:mm");
                        
            }

          
        }

        /// <summary>
        /// The <see cref="ImportoPagare" /> property's name.
        /// </summary>
        public const string ImportoPagarePropertyName = "ImportoPagare";

        private decimal _importoPagare = 0;

        /// <summary>
        /// Sets and gets the Importo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoPagare
        {
            get
            {
                return _importoPagare;
            }

            set
            {
                if (_importoPagare == value)
                {
                    return;
                }

                _importoPagare = value;
                ImportoPagato = ImportoPagare - Sconto;
                CanSave = CheckForSave();
                RaisePropertyChanged(ImportoPagarePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ImportoPagato" /> property's name.
        /// </summary>
        public const string ImportoPagatoPropertyName = "ImportoPagato";

        private decimal _importoPagato = 0;

        /// <summary>
        /// Sets and gets the Importo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoPagato
        {
            get
            {
                return _importoPagato;
            }

            set
            {
                if (_importoPagato == value)
                {
                    return;
                }

                _importoPagato = value;
                Sconto = ImportoPagare - ImportoPagato;
                CanSave = CheckForSave();
                RaisePropertyChanged(ImportoPagatoPropertyName);
            }
        }



        /// <summary>
        /// The <see cref="Sconto" /> property's name.
        /// </summary>
        public const string ScontoPropertyName = "Sconto";

        private decimal _sconto = 0;

        /// <summary>
        /// Sets and gets the Sconto property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal Sconto
        {
            get
            {
                return _sconto;
            }

            set
            {
                if (_sconto == value)
                {
                    return;
                }

                _sconto = value;

                ImportoPagato = ImportoPagare - Sconto;
                CanSave = CheckForSave();
                RaisePropertyChanged(ScontoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ModalitaPagamento" /> property's name.
        /// </summary>
        public const string ModalitaPagamentoPropertyName = "ModalitaPagamento";

        private ModalitaPagamentoViewModel _modalitaPagamento = null;

        /// <summary>
        /// Sets and gets the ModalitaPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ModalitaPagamentoViewModel ModalitaPagamento
        {
            get
            {
                return _modalitaPagamento;
            }

            set
            {
                if (_modalitaPagamento == value)
                {
                    return;
                }

                _modalitaPagamento = value;
                CanSave = CheckForSave();
                
                RaisePropertyChanged(ModalitaPagamentoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsRicevutaStampata" /> property's name.
        /// </summary>
        public const string IsRicevutaStampataPropertyName = "IsRicevutaStampata";

        private bool _isRicevutaStampata = false;

        /// <summary>
        /// Sets and gets the IsRicevutaStampata property. 
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsRicevutaStampata
        {
            get
            {
                return _isRicevutaStampata;
            }

            set
            {
                if (_isRicevutaStampata == value)
                {
                    return;
                }

                _isRicevutaStampata = value;
                RaisePropertyChanged(IsRicevutaStampataPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CCAvere" /> property's name.
        /// </summary>
        public const string CCAverePropertyName = "CCAvere";

        private string _ccavere = string.Empty;

        /// <summary>
        /// Sets and gets the CCAvere property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CCAvere
        {
            get
            {
                return _ccavere;
            }

            set
            {
                if (_ccavere == value)
                {
                    return;
                }

                _ccavere = value;
                if (_ccavere != string.Empty)
                    IsModified = true;
                IsMovimentoFiscale = dataservice.IsMovimentoFiscaleFromCodiceContabile(_ccavere);
                CanSave = CheckForSave();
                RaisePropertyChanged(CCAverePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CCDare" /> property's name.
        /// </summary>
        public const string CCDarePropertyName = "CCDare";

        private string _ccdare = string.Empty;

        /// <summary>
        /// Sets and gets the CCDare property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CCDare
        {
            get
            {
                return _ccdare;
            }

            set
            {
                if (_ccdare == value)
                {
                    return;
                }

                _ccdare = value;
                RaisePropertyChanged(CCDarePropertyName);
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
                RaisePropertyChanged(UserPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Nominativo" /> property's name.
        /// </summary>
        public const string NominativoPropertyName = "Nominativo";

        private string _nominativo = string.Empty;

        /// <summary>
        /// Sets and gets the Nominativo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nominativo
        {
            get
            {
                return _nominativo;
            }

            set
            {
                if (_nominativo == value)
                {
                    return;
                }

                _nominativo = value;
                RaisePropertyChanged(NominativoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoModalitaPagamento" /> property's name.
        /// </summary>
        public const string ElencoModalitaPagamentoPropertyName = "ElencoModalitaPagamento";

        private List<ModalitaPagamentoViewModel> _elencoModalitaPagamento = null;

        /// <summary>
        /// Sets and gets the ElencoModalitaPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ModalitaPagamentoViewModel> ElencoModalitaPagamento
        {
            get
            {
                if (_elencoModalitaPagamento == null)
                {
                    _elencoModalitaPagamento = dataservice.GetElencoModalitaPagamento(false);
                    //ModalitaPagamento = _elencoModalitaPagamento.Find(p => p.Key[0] == 'C');
                }

                return _elencoModalitaPagamento;
            }

            set
            {
                if (_elencoModalitaPagamento == value)
                {
                    return;
                }

                _elencoModalitaPagamento = value;
                RaisePropertyChanged(ElencoModalitaPagamentoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoAltriMovimenti" /> property's name.
        /// </summary>
        public const string ElencoAltriMovimentiPropertyName = "ElencoAltriMovimenti";

        private List<SingoloCodiceContabileViewModel> _elencoAltriMovimenti = null;

        /// <summary>
        /// Sets and gets the ElencoAltriMovimenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloCodiceContabileViewModel> ElencoAltriMovimenti
        {
            get
            {
                if (_elencoAltriMovimenti == null)
                {
                    _elencoAltriMovimenti = dataservice.GetElencoCodiciContabili(false, FiltroOnlyAttivitaExtra);
                    MovimentoSelezionato = null;
                    CanSave = CheckForSave();
                }
                return _elencoAltriMovimenti;
            }

            set
            {
                if (_elencoAltriMovimenti == value)
                {
                    return;
                }

                _elencoAltriMovimenti = value;
                RaisePropertyChanged(ElencoAltriMovimentiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoCausaliContabili" /> property's name.
        /// </summary>
        public const string ElencoCausaliContabiliPropertyName = "ElencoCausaliContabili";

        private List<SingoloCodiceContabileViewModel> _elencoCausaliContabili = null;

        /// <summary>
        /// Sets and gets the ElencoCausaliContabili property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloCodiceContabileViewModel> ElencoCausaliContabili
        {
            get
            {
                if (_elencoCausaliContabili == null)
                {
                    _elencoCausaliContabili = dataservice.GetElencoCodiciContabili(false, false);
                    MovimentoSelezionato = null;
                }
                return _elencoCausaliContabili;
            }

            set
            {
                if (_elencoCausaliContabili == value)
                {
                    return;
                }

                _elencoCausaliContabili = value;
                RaisePropertyChanged(ElencoCausaliContabiliPropertyName);
            }
        }



        /// <summary>
            /// The <see cref="MovimentoSelezionato" /> property's name.
            /// </summary>
        public const string MovimentoSelezionatoPropertyName = "MovimentoSelezionato";

        private SingoloCodiceContabileViewModel _movimentoSelezionato = null;

        /// <summary>
        /// Sets and gets the MovimentoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloCodiceContabileViewModel MovimentoSelezionato
        {
            get
            {
                return _movimentoSelezionato;
            }

            set
            {
                if (_movimentoSelezionato == value)
                {
                    return;
                }

                _movimentoSelezionato = value;
                if (_movimentoSelezionato != null)
                {
                    CCAvere = _movimentoSelezionato.Codice;
                    Segno = (short)(_movimentoSelezionato.bSegno ? 1 : -1);
                    Descrizione = _movimentoSelezionato.Descrizione;
                    //if (ImportoPagare == 0)
                        ImportoPagare = _movimentoSelezionato.ImportoPredefinito;
                }
                else
                    Descrizione = string.Empty;
                CanSave = CheckForSave();
                HaveDettagli = (_movimentoSelezionato != null && dataservice.CheckForDettagliMovimento(_movimentoSelezionato.Codice));
                RaisePropertyChanged(MovimentoSelezionatoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsRichiestaFattura" /> property's name.
        /// </summary>
        public const string IsRichiestaFatturaPropertyName = "IsRichiestaFattura";

        private bool _isRichiestaFattura = false;

        /// <summary>
        /// Sets and gets the IsRichiestaFattura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsRichiestaFattura
        {
            get
            {
                return _isRichiestaFattura;
            }

            set
            {
                if (_isRichiestaFattura == value)
                {
                    return;
                }

                _isRichiestaFattura = value;
                RaisePropertyChanged(IsRichiestaFatturaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Segno" /> property's name.
        /// </summary>
        public const string SegnoPropertyName = "Segno";

        private short _segno = 1;

        /// <summary>
        /// Sets and gets the Segno property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Segno
        {
            get
            {
                return _segno;
            }

            set
            {
                if (_segno == value)
                {
                    return;
                }

                _segno = value;
                RaisePropertyChanged(SegnoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsMovimentoTrasferito" /> property's name.
        /// </summary>
        public const string IsMovimentoTrasferitoPropertyName = "IsMovimentoTrasferito";

        private bool _isMovimentoTrasferito = false;

        /// <summary>
        /// Sets and gets the IsMovimentoTrasferito property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsMovimentoTrasferito
        {
            get
            {
                return _isMovimentoTrasferito;
            }

            set
            {
                if (_isMovimentoTrasferito == value)
                {
                    return;
                }

                _isMovimentoTrasferito = value;
                RaisePropertyChanged(IsMovimentoTrasferitoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="HaveDettagli" /> property's name.
        /// </summary>
        public const string HaveDettagliPropertyName = "HaveDettagli";

        private bool _haveDettagli = false;

        /// <summary>
        /// Sets and gets the HaveDettagli property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool HaveDettagli
        {
            get
            {
                return _haveDettagli;
            }

            set
            {
                if (_haveDettagli == value)
                {
                    return;
                }

                _haveDettagli = value;
                RaisePropertyChanged(HaveDettagliPropertyName);
            }
        }

        public List<ScontrinoViewModel> DettagliMovimento { get; set; }


        bool CheckForSave()
        {
            return (ID <= 0 && MovimentoSelezionato != null && CCDare != string.Empty && CCAvere != string.Empty);
        }
        private RelayCommand _AnnullaPagamento;

        /// <summary>
        /// Gets the AnnullaPagamento.
        /// </summary>
        public RelayCommand AnnullaPagamento
        {
            get
            {
                return _AnnullaPagamento
                    ?? (_AnnullaPagamento = new RelayCommand(
                    () =>
                    {
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowEditPagamento = false;
                        MovimentoSelezionato = null;
                    }));
            }
        }

        private RelayCommand _salvaPagamento;

        /// <summary>
        /// Gets the SavePagamento.
        /// </summary>
        public RelayCommand SalvaPagamento
        {
            get
            {
                return _salvaPagamento
                    ?? (_salvaPagamento = new RelayCommand(
                    () =>
                    {
                        if (this.ModalitaPagamento == null)
                            ModalitaPagamento = ElencoModalitaPagamento.Find(k => k.Key.CompareTo("C") == 0);

                        ID = dataservice.SavePagamento(this, SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>(),false);
                        User = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().user;
                        CCDare = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().CodiceContabileCassa;
                        IsModified = false;
                        SimpleIoc.Default.GetInstance<AnagraficaAttivitaViewModel>().RefreshAttivita.Execute(null);
                        SimpleIoc.Default.GetInstance<MovimentiViewModel>().RefreshMovimenti.Execute(null);
                        SimpleIoc.Default.GetInstance<PagamentiViewModel>().RefreshPagamenti.Execute(null);
                        SimpleIoc.Default.GetInstance<CassaViewModel>().RefreshCassa.Execute(null);
                        SimpleIoc.Default.GetInstance<StampaRicevutaViewModel>().Pagamento = this;
                        SimpleIoc.Default.GetInstance<StampaRicevutaViewModel>().Anagrafica = new AnagraficaROViewModel(SimpleIoc.Default.GetInstance<AnagraficaViewModel>());
                    }));
            }
        }


        private RelayCommand _salvaMovimentoContabile;

        /// <summary>
        /// Gets the SavePagamento.
        /// </summary>
        public RelayCommand SalvaMovimentoContabile
        {
            get
            {
                return _salvaMovimentoContabile
                    ?? (_salvaMovimentoContabile = new RelayCommand(
                    () =>
                    {

                        // Salvataggio di un movimento non collegato ad anagrafica
                        IDAnagrafica = 0;
                        IDAnagraficaAttivita = 0;
                        ID = dataservice.SavePagamento(this, SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>(), false);
                        User = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().user;
                        CCDare = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().CodiceContabileCassa;
                        IsModified = false;
                        SimpleIoc.Default.GetInstance<MovimentiViewModel>().RefreshMovimenti.Execute(null);
                        SimpleIoc.Default.GetInstance<CassaViewModel>().RefreshCassa.Execute(null);
                        SimpleIoc.Default.GetInstance<MovimentiViewModel>().SelezionaMovimento(ID);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowAddMovimento>(new ShowAddMovimento(false));
                    }));
            }
        }



        private RelayCommand _stampaRicevuta;

        /// <summary>
        /// Gets the StampaRicevuta.
        /// </summary>
        public RelayCommand StampaRicevuta
        {
            get
            {
                return _stampaRicevuta
                    ?? (_stampaRicevuta = new RelayCommand(
                    () =>
                    {
                        //MessageBox.Show("Operazioni prima di stampare");
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<StampaRicevuta>(new StampaRicevuta());

                    }));
            }
        }
        private RelayCommand _stampaRicevutaFiscale;

        /// <summary>
        /// Gets the StampaRicevutaFiscale.
        /// </summary>
        public RelayCommand StampaRicevutaFiscale
        {
            get
            {
                return _stampaRicevutaFiscale
                    ?? (_stampaRicevutaFiscale = new RelayCommand(
                    () =>
                    {
                        SingoloCodiceContabileViewModel cc = dataservice.GetCodiceContabileFromCodice(CCAvere);
                        // Determino template di stampa
                        string sFile = cc.Descrizione.Replace(" ", "_").ToUpper() + ".txt";
                        sFile = System.AppDomain.CurrentDomain.BaseDirectory + "\\TemplateStampaFiscale\\" + sFile;
                        if (!File.Exists(sFile))
                            sFile = System.AppDomain.CurrentDomain.BaseDirectory + "\\TemplateStampaFiscale\\Standard.txt";

                        // Lettura scontrino
                        try
                        {   // Open the text file using a stream reader.
                            String line;
                            using (StreamReader sr = new StreamReader(sFile))
                            {
                                // Read the stream to a string, and write the string to the console.
                                line = sr.ReadToEnd();
                                
                            }
                            // DA TEMPLATE A STAMPA
                            // Pulizia decrizione
                            
                            string descri = cc.Descrizione;
                            descri =  descri.Length <= 30 ? descri : descri.Substring(0, 30);
                            descri = descri.Replace("/", " ");
                            line = line.Replace("@DESCRIZIONE", descri);
                            line = line.Replace("@IMPORTO", (ImportoPagato.ToString("n2").Replace(".","")).Replace(",","."));
                            switch (ModalitaPagamento.Key[0])
                                {
                                    case 'B':
                                    line = line.Replace("@TIPOPAGAMENTO", "4");
                                    break;
                                    case 'C':
                                    line = line.Replace("@TIPOPAGAMENTO", "1");
                                    break;
                                    case 'V':
                                    line = line.Replace("@TIPOPAGAMENTO", "5");
                                    break;
                                }
                            SingoloCodiceContabileViewModel sccvm =  dataservice.GetCodiceContabileFromCodice(CCAvere);
                            string nomefile = "default.txt";
                            if (sccvm.IsAttivitaExtra)
                            {
                                line = line.Replace("@QRCODE", "");
                                nomefile = DataPagamento.ToString(QRCodeViewModel.QRCODE_FORMATODATA) + "_" + ID.ToString() + ".txt";
                            }
                            else
                            {
                                string[] parametriqrcode = { "", "", "" };
                                parametriqrcode[0] = sccvm.Descrizione;
                                parametriqrcode[1] = DataPagamento.ToString(QRCodeViewModel.QRCODE_FORMATODATA);
                                parametriqrcode[2] = ID.ToString();

                                nomefile = parametriqrcode[1] + "_" + parametriqrcode[2] + ".txt";

                                string qcode = QRCodeViewModel.GetQRCodeString(QRCodeViewModel.TipoQRCode.Biglietto, parametriqrcode);
                                line = line.Replace("@QRCODE", qcode);
                            }
                            // PROCEDO A VERIFICA PER SCONTRINO MULTIRIGA
                            int ix = line.IndexOf("##");  // Identificativo inizio riga multipla
                            if (ix >= 0)
                            {
                                int ix2 = line.IndexOf('\n', ix);
                                string template = line.Substring(ix, ix2 - ix+1);

                                List<ScontrinoViewModel> scontrino = dataservice.GetScontrinoFromMovimento(ID);
                                string s = string.Empty; 
                                foreach(ScontrinoViewModel svm in scontrino)
                                    s = s +template.Replace("##","").Replace("#Descrizione", svm.Codice).Replace("#Prezzo",svm.ImportoUnitario.ToString("n2").Replace(",",".")).Replace("#Quantita", svm.Quantita.ToString());

                                line = line.Replace(template, s);
                                //Console.WriteLine(template);

                                    

                            }


                            // PROCEDO CON LA STAMPA

                            using (StreamWriter so = new StreamWriter(Properties.Settings.Default["DirectoryStampanteFiscale"]+"\\"+nomefile))
                            {
                                 so.Write(line);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("The file could not be read:");
                            Console.WriteLine(e.Message);
                        }



                    }));
            }
        }
    }
}