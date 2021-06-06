using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingolaAnagraficaAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingolaAnagraficaAttivitaViewModel class.
        /// </summary>
        IDataService dataservice;
        public SingolaAnagraficaAttivitaViewModel()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                ElencoDateCorso = new ObservableCollection<SingolaDataAttivitaViewModel>();
                SingolaDataAttivitaViewModel sda = new SingolaDataAttivitaViewModel();
                ElencoDateCorso.Add(sda);
            }
        }
        public SingolaAnagraficaAttivitaViewModel(IDataService ds)
        {
            dataservice = ds;
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
                if (_id > 0)
                    IsModified = false;
                 RaisePropertyChanged(IDPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="TitoloAttivita" /> property's name.
        /// </summary>
        public const string TitoloAttivitaPropertyName = "TitoloAttivita";

        private string _titoloAttivita = string.Empty;

        /// <summary>
        /// Sets and gets the TitoloAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TitoloAttivita
        {
            get
            {
                return _titoloAttivita;
            }

            set
            {
                if (_titoloAttivita == value)
                {
                    return;
                }

                _titoloAttivita = value;
                RaisePropertyChanged(TitoloAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TipoCorso" /> property's name.
        /// </summary>
        public const string TipoCorsoPropertyName = "TipoCorso";

        private CorsoViewModel.TipoCorsoValue _tipoCorso = CorsoViewModel.TipoCorsoValue.Singolo;

        /// <summary>
        /// Sets and gets the TipoCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CorsoViewModel.TipoCorsoValue TipoCorso
        {
            get
            {
                return _tipoCorso;
            }

            set
            {
                if (_tipoCorso == value)
                {
                    return;
                }

                _tipoCorso = value;
                RaisePropertyChanged(TipoCorsoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="PeriodoAttivita" /> property's name.
        /// </summary>
        public const string PeriodoAttivitaPropertyName = "PeriodoAttivita";

        

        /// <summary>
        /// Sets and gets the PeriodoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PeriodoAttivita
        {
            get
            {
                return "dal "+DataInizio.ToString("dd/MM/yyyy")+" al "+DataFine.ToString("dd/MM/yyyy");
            }

        }
        /// <summary>
        /// The <see cref="DataInizio" /> property's name.
        /// </summary>
        public const string DataInizioPropertyName = "DataInizio";

        private DateTime _Datainizio;

        /// <summary>
        /// Sets and gets the DataInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataInizio
        {
            get
            {
                return _Datainizio;
            }

            set
            {
                if (_Datainizio == value)
                {
                    return;
                }
                
                _Datainizio = value;
                RaisePropertyChanged(DataInizioPropertyName);
                RaisePropertyChanged(DataInizioPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DataFine" /> property's name.
        /// </summary>
        public const string DataFinePropertyName = "DataFine";

        private DateTime _dataFine;

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
                RaisePropertyChanged(StatoAttivitaColorPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CanSelezionareDate" /> property's name.
        /// </summary>
        public const string CanSelezionareDatePropertyName = "CanSelezionareDate";

        /// <summary>
        /// Sets and gets the anSelezionareDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanSelezionareDate
        {
            get
            {
                return (_elencoDateCorso != null && _elencoDateCorso.Count>0);
            }

        }



        /// <summary>
        /// The <see cref="Importo" /> property's name.
        /// </summary>
        public const string ImportoPropertyName = "Importo";

        private decimal _importo = 0;
        private decimal _importoSP = 0;

        /// <summary>
        /// Sets and gets the Importo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal Importo
        {
            get
            {
                return _importo;
            }

            set
            {
                if (_importo == value)
                {
                    return;
                }

                _importo = value;
                if (_importo != _importoSP)
                    IsModified = true;
                RaisePropertyChanged(ImportoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IngressiPrevisti" /> property's name.
        /// </summary>
        public const string IngressiPrevistiPropertyName = "IngressiPrevisti";

        private int _ingressiPrevisti = 0;

        /// <summary>
        /// Sets and gets the IngressiPrevisti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IngressiPrevisti
        {
            get
            {
                return _ingressiPrevisti;
            }

            set
            {
                if (_ingressiPrevisti == value)
                {
                    return;
                }

                _ingressiPrevisti = value;
                RaisePropertyChanged(IngressiPrevistiPropertyName);
            }
        }



        /// <summary>
        /// The <see cref="NumeroIngressi" /> property's name.
        /// </summary>
        public const string NumeroIngressiPropertyName = "NumeroIngressi";

        private int _numeroIngressi = 0;
        private int _numeroIngressiSP = 0;

        /// <summary>
        /// Sets and gets the NumeroIngressi property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumeroIngressi
        {
            get
            {
                return _numeroIngressi;
            }

            set
            {
                if (_numeroIngressi == value)
                {
                    return;
                }
                _numeroIngressi = value;
                RaisePropertyChanged(NumeroIngressiPropertyName);
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
                RaisePropertyChanged(CostoLordoLezionePropertyName);
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
        /// The <see cref="StatoAttivitaColor" /> property's name.
        /// </summary>
        public const string StatoAttivitaColorPropertyName = "StatoAttivitaColor";


        /// <summary>
        /// Sets and gets the StatoAttivitaColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StatoAttivitaColor
        {
            get
            {
                if (DataFine <= DateTime.Now)
                    return "Gray";
                else
                    if (TotalePagato >= Importo)
                    return "Green";
                else
                    return "Red";
            }

           
        }


        /// <summary>
        /// The <see cref="IsErasable" /> property's name.
        /// </summary>
        public const string IsEraseblePropertyName = "IsErasable";

        /// <summary>
        /// Sets and gets the IsEraseble property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsErasable
        {
            get
            {
                if (DataFine <= DateTime.Now)
                    return false;
                else
                    return (TotalePagato == 0);
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
                RaisePropertyChanged(IsPagabilePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsPagabile" /> property's name.
        /// </summary>
        public const string IsPagabilePropertyName = "IsPagabile";

        private bool _isPagabile = false;

        /// <summary>
        /// Sets and gets the IsPagabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsPagabile
        {
            get
            {
                _isPagabile = !IsModified && TotalePagato == 0;
                return _isPagabile;
            }

          
        }
       
        /// <summary>
        /// The <see cref="BackColor" /> property's name.
        /// </summary>
        public const string BackColorPropertyName = "BackColor";

        private string _backColor = "Blue";

        /// <summary>   
        /// Sets and gets the BackColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BackColor
        {
            get
            {
                return _backColor;
            }

            set
            {
                if (_backColor == value)
                {
                    return;
                }

                _backColor = value;
                RaisePropertyChanged(BackColorPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="ForegroundColor" /> property's name.
        /// </summary>
        public const string ForegroundColorPropertyName = "ForegroundColor";

        private string _foregroundColor = string.Empty;

        /// <summary>
        /// Sets and gets the ForegroundColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ForegroundColor
        {
            get
            {
                return _foregroundColor;
            }

            set
            {
                if (_foregroundColor == value)
                {
                    return;
                }

                _foregroundColor = value;
                RaisePropertyChanged(ForegroundColorPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="OrarioCorsi" /> property's name.
        /// </summary>
        public const string OrarioCorsiPropertyName = "OrarioCorsi";

        private List<string> _orarioCorsi = null;

        /// <summary>
        /// Sets and gets the OrarioCorsi property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<string> OrarioCorsi
        {
            get
            {
                return _orarioCorsi;
            }

            set
            {
                if (_orarioCorsi == value)
                {
                    return;
                }

                _orarioCorsi = value;
                RaisePropertyChanged(OrarioCorsiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TotalePagato" /> property's name.
        /// </summary>
        public const string TotalePagatoPropertyName = "TotalePagato";

        private decimal _totalePagato = 0;

        /// <summary>
        /// Sets and gets the HavePagamenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TotalePagato
        {
            get
            {
                return _totalePagato;
            }

            set
            {
                if (_totalePagato == value)
                {
                    return;
                }

                _totalePagato = value;
                if (TotalePagato > 0)
                    IsModified = false;
                else
                    IsModified = true;
                RaisePropertyChanged(TotalePagatoPropertyName);
                RaisePropertyChanged(IsPagabilePropertyName);
            }
        }

        /// <summary>
            /// The <see cref="CodiceContabile" /> property's name.
            /// </summary>
        public const string CodiceContabilePropertyName = "CodiceContabile";

        private string _codiceContabile = string.Empty;

        /// <summary>
        /// Sets and gets the CodiceContabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceContabile
        {
            get
            {
                return _codiceContabile;
            }

            set
            {
                if (_codiceContabile == value)
                {
                    return;
                }

                _codiceContabile = value;
                RaisePropertyChanged(CodiceContabilePropertyName);
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
        /// The <see cref="Note" /> property's name.
        /// </summary>
        public const string NotePropertyName = "Note";

        private string _note = string.Empty;
        private string _noteSP = string.Empty;
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
                if (_note.CompareTo(_noteSP) != 0)
                    IsModified = true;
                RaisePropertyChanged(NotePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoDateCorso" /> property's name.
        /// </summary>
        public const string ElencoDateCorsoPropertyName = "ElencoDateCorso";

        private ObservableCollection<SingolaDataAttivitaViewModel> _elencoDateCorso = null;

        /// <summary>
        /// Sets and gets the ElencoDateCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<SingolaDataAttivitaViewModel> ElencoDateCorso
        {
            get
            {
                return _elencoDateCorso;
            }

            set
            {
                if (_elencoDateCorso == value)
                {
                    return;
                }

                _elencoDateCorso = value;
                RaisePropertyChanged(CanSelezionareDatePropertyName);
                RaisePropertyChanged(ElencoDateCorsoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoDateCorsoSelezione" /> property's name.
        /// </summary>
        public const string ElencoDateCorsoSelezionePropertyName = "ElencoDateCorsoSelezione";

        private SingolaDataAttivitaViewModel _elencoDateCorsoSelezione = null;

        /// <summary>
        /// Sets and gets the ElencoDateCorsoSelezione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingolaDataAttivitaViewModel ElencoDateCorsoSelezione
        {
            get
            {
                return _elencoDateCorsoSelezione;
            }

            set
            {
                if (_elencoDateCorsoSelezione == value)
                {
                    return;
                }

                _elencoDateCorsoSelezione = value;
                RaisePropertyChanged(ElencoDateCorsoSelezionePropertyName);
            }
        }
        public  void SaveParametri()
        {

            _numeroIngressiSP = _numeroIngressi;
            _importoSP = _importo;
            _noteSP = _note;
            IsModified = false;
        }

        public void RestoreParametri()
        {

            NumeroIngressi = _numeroIngressiSP;
            Importo = _importoSP;
            Note = _noteSP;
            IsModified = false;
        }
        private RelayCommand _verificaDateAttivita;

        /// <summary>
        /// Gets the VerificaDateAttivita.
        /// </summary>
        public RelayCommand VerificaDateAttivita
        {
            get
            {
                return _verificaDateAttivita
                    ?? (_verificaDateAttivita = new RelayCommand(
                    () =>
                    {
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditDateAttivita>(new ShowEditDateAttivita(this));
                    }));
            }
        }


        private RelayCommand<bool> _chiudiEditAttivita;

        /// <summary>
        /// Gets the ChiudiEditAttivita.
        /// </summary>
        public RelayCommand<bool> ChiudiEditAttivita
        {
            get
            {
                return _chiudiEditAttivita
                    ?? (_chiudiEditAttivita = new RelayCommand<bool>(
                    p =>
                    {

                        if (IsModified && p == false)
                        {
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowUndoEdit>(new ShowUndoEdit(this));
                        }
                       else
                        {
                            if (IsModified)
                                RestoreParametri();
                            SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowEditAttivita = false;
                        }
                    }));
            }
        }


        private RelayCommand _chiudiEditDateAttivita;

        /// <summary>
        /// Gets the ChiudiEditAttivita.
        /// </summary>
        public RelayCommand ChiudiEditDateAttivita
        {
            get
            {
                return _chiudiEditDateAttivita
                    ?? (_chiudiEditDateAttivita = new RelayCommand(
                    () =>
                    {
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditDateAttivita>(new ShowEditDateAttivita(null));
                    }));
            }
        }


        private RelayCommand _eliminaAttivita;

        /// <summary>
        /// Gets the EliminaAttivita.
        /// </summary>
        public RelayCommand EliminaAttivita
        {
            get
            {
                return _eliminaAttivita
                    ?? (_eliminaAttivita = new RelayCommand(
                    () =>
                    {
                        
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().DeleteAttivita.Execute(this);
                    }));
            }
        }

        private RelayCommand _pagaAttivita;

        /// <summary>
        /// Gets the EliminaAttivita.
        /// </summary>
        public RelayCommand PagaAttivita
        {
            get
            {
                return _pagaAttivita
                    ?? (_pagaAttivita = new RelayCommand(
                    () =>
                    {

                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().PagamentoAttivita.Execute(this);
                    }));
            }
        }




        private RelayCommand _salvaEditAttivita;

        /// <summary>
        /// Gets the SalvaEditAttivita.
        /// </summary>
        public RelayCommand SalvaEditAttivita
        {
            get
            {
                return _salvaEditAttivita
                    ?? (_salvaEditAttivita = new RelayCommand(
                    () =>
                    {
                        dataservice.SaveAttivita(ID, NumeroIngressi, Importo, Note);
                        IsModified = false;
                        SaveParametri();

                    }));
            }
        }

        private RelayCommand<SingolaDataAttivitaViewModel> _attivazionedisattivazionedata;

        /// <summary>
        /// Gets the AttivazioneDisattivazioneData.
        /// </summary>
        public RelayCommand<SingolaDataAttivitaViewModel> AttivazioneDisattivazioneData
        {
            get
            {
                return _attivazionedisattivazionedata
                    ?? (_attivazionedisattivazionedata = new RelayCommand<SingolaDataAttivitaViewModel>(
                    p =>
                    {
                        p.IsAttivo = !p.IsAttivo;
                        dataservice.StatoAttivazioneDataAnagraficaAttivita(p.ID,p.IsAttivo);
                        NumeroIngressi = ElencoDateCorso.Where(k=>k.IsAttivo==true).Count();
                    }));
            }
        }

       
        private RelayCommand<SelezioneIntervalloTempoModel> _addSingoloIngresso;

        public RelayCommand<SelezioneIntervalloTempoModel> AddSingoloIngresso
        {
            get
            {
                return _addSingoloIngresso
                    ?? (_addSingoloIngresso = new RelayCommand<SelezioneIntervalloTempoModel>(
                    p =>
                    {
                        DateTime DInizio = new DateTime(p.Data.Year, p.Data.Month, p.Data.Day, ((DateTime) p.OraInizio).Hour, ((DateTime) p.OraInizio).Minute, 0);
                        DateTime DFine = new DateTime(p.Data.Year, p.Data.Month, p.Data.Day, ((DateTime) p.OraFine).Hour, ((DateTime) p.OraFine).Minute, 0);
                        ElencoDateCorso = dataservice.AddSingoloIngresso(ID, DInizio, DFine,TipoCorso == CorsoViewModel.TipoCorsoValue.Abbonamento);
                        NumeroIngressi = ElencoDateCorso.Where(k => k.IsAttivo == true).Count();
                    }));
            }
        }


        private RelayCommand _AddPresenza;

        /// <summary>
        /// Gets the AddPresenza.
        /// </summary>
        public RelayCommand AddPresenza
        {
            get
            {
                return _AddPresenza
                    ?? (_AddPresenza = new RelayCommand(
                    () =>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   
                    {
                        ElencoDateCorsoSelezione.IsPresente = true;
                        dataservice.UpdateStatoPresenza(ElencoDateCorsoSelezione.ID, true);
                    }));
            }
        }

        private RelayCommand _RemovePresenza;

        /// <summary>
        /// Gets the RemovePresenza.
        /// </summary>
        public RelayCommand RemovePresenza
        {
            get
            {
                return _RemovePresenza
                    ?? (_RemovePresenza = new RelayCommand(
                    () =>
                    {
                        ElencoDateCorsoSelezione.IsPresente = false;
                        dataservice.UpdateStatoPresenza(ElencoDateCorsoSelezione.ID, false);
                    }));
            }
        }

    }
}