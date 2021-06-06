using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Converters;
using GPNuoto.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PagamentiViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CorsiViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public PagamentiViewModel(IDataService ds)
        {
            dataservice = ds;
            if (ViewModelBase.IsInDesignModeStatic)
            {
                List<SingoloMovimentoViewModel> lspvm = new List<SingoloMovimentoViewModel>();
                SingoloMovimentoViewModel sp = new SingoloMovimentoViewModel();
                sp.DataPagamento = new DateTime(2016, 9, 10);
                sp.Descrizione = "Corso Scuola nuoto del xxxx";
                sp.ImportoPagato = 120;
                sp.ImportoPagare = 130;
                sp.Sconto = 10;
                lspvm.Add(sp);
                ElencoPagamenti = lspvm;
            }
        }
        /// <summary>
        /// The <see cref="IsAnagraficaSelected" /> property's name.
        /// </summary>
        public const string IsAnagraficaSelectedPropertyName = "IsAnagraficaSelected";

        private bool _isAnagraficaSelected = false;

        /// <summary>
        /// Sets and gets the IsAnagraficaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAnagraficaSelected
        {
            get
            {
                return _isAnagraficaSelected;
            }

            set
            {
                

                _isAnagraficaSelected = value;

                if (_isAnagraficaSelected)
                    ElencoPagamenti = dataservice.LoadPagamenti(SimpleIoc.Default.GetInstance<AnagraficaViewModel>().IDAnagrafica);
                else
                    ElencoPagamenti = null;

                RaisePropertyChanged(IsAnagraficaSelectedPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ElencoPagamenti" /> property's name.
        /// </summary>
        public const string ElencoPagamentiPropertyName = "ElencoPagamenti";

        private List<SingoloMovimentoViewModel> _elencoPagamenti = null;

        /// <summary>
        /// Sets and gets the ElencoPagamenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloMovimentoViewModel> ElencoPagamenti
        {
            get
            {
                return _elencoPagamenti;
            }

            set
            {
                if (_elencoPagamenti == value)
                {
                    return;
                }

                _elencoPagamenti = value;
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowStampaRicevuta>(new ShowStampaRicevuta(false));
                RaisePropertyChanged(ElencoPagamentiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="MovimentoSelezionato" /> property's name.
        /// </summary>
        public const string MovimentoSelezionatoPropertyName = "MovimentoSelezionato";

        private SingoloMovimentoViewModel _movimentoSelezionato = null;

        /// <summary>
        /// Sets and gets the MovimentoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloMovimentoViewModel MovimentoSelezionato
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
                RaisePropertyChanged(MovimentoSelezionatoPropertyName);
                RaisePropertyChanged(IsMovimentoSelezionatoFiscalePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="CurrentPagamento" /> property's name.
        /// </summary>
        public const string CurrentPagamentoPropertyName = "CurrentPagamento";

        private SingoloMovimentoViewModel _currentPagamento;

        /// <summary>
        /// Sets and gets the CurrentPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloMovimentoViewModel CurrentPagamento
        {
            get
            {
                if (_currentPagamento == null)
                    _currentPagamento = new SingoloMovimentoViewModel();
                return _currentPagamento;
            }

            set
            {
                if (_currentPagamento == value)
                {
                    return;
                }

                _currentPagamento = value;
                RaisePropertyChanged(CurrentPagamentoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsMovimentoSelezionatoFiscale" /> property's name.
        /// </summary>
        public const string IsMovimentoSelezionatoFiscalePropertyName = "IsMovimentoSelezionatoFiscale";
        

        /// <summary>
        /// Sets and gets the IsMovimentoSelezionatoFiscale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsMovimentoSelezionatoFiscale
        {
            get
            {
                return (_movimentoSelezionato != null && _movimentoSelezionato.IsMovimentoFiscale);
                    ;
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
                        CurrentPagamento = null;
                        CurrentPagamento.ID = 0;
                        CurrentPagamento.DataPagamento = DateTime.Now;
                        string sOrari = string.Empty;
                        try
                        {
                           sOrari = p.OrarioCorsi.Aggregate((current, next) => current + "-" + next);
                        }
                        catch
                        {
                            
                        }
                        CurrentPagamento.Descrizione = p.TitoloAttivita + " " + p.PeriodoAttivita + "\n" + "Tipo:" + p.TipoCorso.ToString() + " N.Lezioni:" + p.NumeroIngressi + "\n" + sOrari+"\n"+ p.Note;
                        CurrentPagamento.ImportoPagare = p.Importo;
                        CurrentPagamento.ImportoPagato = p.Importo;
                        CurrentPagamento.Sconto = 0;
                        CurrentPagamento.CCAvere = p.CodiceContabile;
                        CurrentPagamento.Segno = p.Segno;
                        CurrentPagamento.IsModified = true;
                        CurrentPagamento.ModalitaPagamento = CurrentPagamento.ElencoModalitaPagamento.Find(k => k.Key.CompareTo("C")==0);
                        CurrentPagamento.IsRichiestaFattura = (SimpleIoc.Default.GetInstance<AnagraficaViewModel>()).TipoFattura != AnagraficaViewModel.TipoFatturazione.Nessuna;
                        CurrentPagamento.IDAnagraficaAttivita = p.ID;
                        CurrentPagamento.IDAnagrafica = (SimpleIoc.Default.GetInstance<AnagraficaViewModel>()).IDAnagrafica;
                        CurrentPagamento.MovimentoSelezionato = null;

                    }));
            }
        }

        private RelayCommand _refreshPagamenti;

        /// <summary>
        /// Gets the RefreshPagamenti.
        /// </summary>
        public RelayCommand RefreshPagamenti
        {
            get
            {
                return _refreshPagamenti
                    ?? (_refreshPagamenti = new RelayCommand(
                    () =>
                    {
                        ElencoPagamenti = dataservice.LoadPagamenti(SimpleIoc.Default.GetInstance<AnagraficaViewModel>().IDAnagrafica);

                    }));
            }
        }

        private RelayCommand _pagamentoExtraAttivita;

        /// <summary>
        /// Gets the AddPagamento.
        /// </summary>
        public RelayCommand PagamentoExtraAttivita
        {
            get
            {
                return _pagamentoExtraAttivita
                    ?? (_pagamentoExtraAttivita = new RelayCommand(
                    () =>
                    {

                        CurrentPagamento.ID = 0;
                        CurrentPagamento.DataPagamento = DateTime.Now;
                        CurrentPagamento.Descrizione = string.Empty;
                        CurrentPagamento.ImportoPagare = 0;
                        CurrentPagamento.ImportoPagato = 0;
                        CurrentPagamento.Sconto = 0;
                        CurrentPagamento.IsModified = true;
                        CurrentPagamento.IDAnagraficaAttivita = 0;
                        CurrentPagamento.MovimentoSelezionato = CurrentPagamento.ElencoAltriMovimenti.First();
                        CurrentPagamento.Descrizione = CurrentPagamento.MovimentoSelezionato.Descrizione;
                        CurrentPagamento.IDAnagrafica = (SimpleIoc.Default.GetInstance<AnagraficaViewModel>()).IDAnagrafica;

                    }));
            }
        }
       
    }
}