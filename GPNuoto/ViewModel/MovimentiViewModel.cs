using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MovimentiViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MovimentiViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public MovimentiViewModel(IDataService ds)
        {


            dataservice = ds;
            ElencoMovimenti = dataservice.GetElencoMovimenti(DataMovimenti);
            
        }

        /// <summary>
        /// The <see cref="DataMovimenti" /> property's name.
        /// </summary>
        public const string DataMovimentiPropertyName = "DataMovimenti";

        private DateTime _dataMovimenti = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataMovimenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataMovimenti
        {
            get
            {
                return _dataMovimenti;
            }

            set
            {
                if (_dataMovimenti == value)
                {
                    return;
                }

                _dataMovimenti = value;
                ElencoMovimenti = dataservice.GetElencoMovimenti(DataMovimenti);
                RaisePropertyChanged(TitoloFinestraPropertyName);
                RaisePropertyChanged(DataMovimentiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TitoloFinestra" /> property's name.
        /// </summary>
        public const string TitoloFinestraPropertyName = "TitoloFinestra";

        private string _titoloFinestra = string.Empty;

        /// <summary>
        /// Sets and gets the TitoloFinestra property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TitoloFinestra
        {
            get
            {
                _titoloFinestra = "Movimenti contabili del " + DataMovimenti.ToShortDateString();
                return _titoloFinestra;
            }

        }
        /// <summary>
        /// The <see cref="ElencoMovimenti" /> property's name.
        /// </summary>
        public const string ElencoMovimentiPropertyName = "ElencoMovimenti";

        private List<SingoloMovimentoViewModel> _elencoMovimenti = null;

        /// <summary>
        /// Sets and gets the ElencoMovimenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloMovimentoViewModel> ElencoMovimenti
        {
            get
            {
                return _elencoMovimenti;
            }

            set
            {
                if (_elencoMovimenti == value)
                {
                    return;
                }

                _elencoMovimenti = value;
                RaisePropertyChanged(ElencoMovimentiPropertyName);
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
                RaisePropertyChanged(IsMovimentoModificabilePropertyName);
            }
        }


        /// <summary>
        /// The <see cref="NewMovimento" /> property's name.
        /// </summary>
        public const string NewMovimentoPropertyName = "NewMovimento";

        private SingoloMovimentoViewModel _newmovimento = null;

        /// <summary>
        /// Sets and gets the MovimentoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloMovimentoViewModel NewMovimento
        {
            get
            {
                return _newmovimento;
            }

            set
            {
                if (_newmovimento == value)
                {
                    return;
                }

                _newmovimento = value;
                RaisePropertyChanged(NewMovimentoPropertyName);
            }
        }

        

        /// <summary>
        /// The <see cref="IsMovimentoModificabile" /> property's name.
        /// </summary>
        public const string IsMovimentoModificabilePropertyName = "IsMovimentoModificabile";


        /// <summary>
        /// Sets and gets the IsMovimentoModificabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsMovimentoModificabile
        {
            get
            {


                CassaViewModel cvm = SimpleIoc.Default.GetInstance<CassaViewModel>();
                return (_movimentoSelezionato != null && !_movimentoSelezionato.IsMovimentoTrasferito && _movimentoSelezionato.User.CompareTo(SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>().user) == 0 && cvm.IsCassaOpen && _movimentoSelezionato.DataPagamento > cvm.DataApertura);
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

        private RelayCommand<DateTime> _cambioDataMovimenti;

        /// <summary>
        /// Gets the CambioDataMovimenti.
        /// </summary>
        public RelayCommand<DateTime> CambioDataMovimenti
        {
            get
            {
                return _cambioDataMovimenti
                    ?? (_cambioDataMovimenti = new RelayCommand<DateTime>(
                    p =>
                    {
                        DataMovimenti = p;
                    }));
            }
        }

        private RelayCommand _refreshMovimenti;

        /// <summary>
        /// Gets the RefreshMovimenti   
        /// </summary>
        public RelayCommand RefreshMovimenti
        {
            get
            {
                return _refreshMovimenti
                    ?? (_refreshMovimenti = new RelayCommand(
                    () =>
                    {
                        ElencoMovimenti = dataservice.GetElencoMovimenti(DataMovimenti);
                        

                    }));
            }
        }

        private RelayCommand _addMovimento;

        /// <summary>
        /// Gets the AddMovimento.
        /// </summary>
        public RelayCommand AddMovimento
        {
            get
            {
                return _addMovimento
                    ?? (_addMovimento = new RelayCommand(
                    () =>
                    {
                        CassaViewModel cvm = SimpleIoc.Default.GetInstance<CassaViewModel>();
                        if (cvm.Stato == CassaViewModel.StatoCassa.Aperta)
                        {
                            NewMovimento = new SingoloMovimentoViewModel();
                            NewMovimento.CCDare = cvm.CodiceCassa;
                            NewMovimento.User = cvm.User;
                            NewMovimento.IDAnagrafica = NewMovimento.IDAnagraficaAttivita = 0;
                            NewMovimento.ModalitaPagamento = NewMovimento.ElencoModalitaPagamento.Find(k => k.Key.CompareTo("C") == 0);
                            NewMovimento.MovimentoSelezionato = NewMovimento.ElencoCausaliContabili[0];
                            ServiceLocator.Current.GetInstance<AnagraficaViewModel>().ClearOnlyAnagrafica.Execute(null);


                        }

                    }));
            }
        }

        private RelayCommand _removeMovimento;

        /// <summary>
        /// Gets the RemoveMovimento.
        /// </summary>
        public RelayCommand RemoveMovimento
        {
            get
            {
                return _removeMovimento
                    ?? (_removeMovimento = new RelayCommand(
                    () =>
                    {
                        if (IsMovimentoModificabile)
                        {
                           int IDAnagrafica = MovimentoSelezionato.IDAnagrafica;
                           dataservice.RemoveMovimento(MovimentoSelezionato);
                           ElencoMovimenti = dataservice.GetElencoMovimenti(DataMovimenti);
                           MovimentoSelezionato = null;
                            ServiceLocator.Current.GetInstance<AnagraficaViewModel>().ClearOnlyAnagrafica.Execute(null);
                            SimpleIoc.Default.GetInstance<CassaViewModel>().RefreshCassa.Execute(null);
                        }
                    }));
            }
        }

        private RelayCommand _updateMovimento;

        /// <summary>
        /// Gets the UpdateMovimento.
        /// </summary>
        public RelayCommand UpdateMovimento
        {
            get
            {
                return _updateMovimento
                    ?? (_updateMovimento = new RelayCommand(
                    () =>
                    {
                        if (IsMovimentoModificabile)
                        {
                            int IDAnagrafica = MovimentoSelezionato.IDAnagrafica;
                            dataservice.UpdateMovimento(MovimentoSelezionato);
                            ElencoMovimenti = dataservice.GetElencoMovimenti(DataMovimenti);
                            MovimentoSelezionato = null;
                            if (IDAnagrafica != 0)
                            {
                                List<int> idlist = new List<int>();
                                idlist.Add(IDAnagrafica);
                                ServiceLocator.Current.GetInstance<AnagraficaViewModel>().ResultSetFromID(idlist,true);
                                
                            }
                            SimpleIoc.Default.GetInstance<CassaViewModel>().RefreshCassa.Execute(null);
                        }
                    }));
            }
        }


        public void SelezionaMovimento(int IDMovimento)
       {
            
             MovimentoSelezionato = ElencoMovimenti.Find(p => p.ID == IDMovimento);
            
        }
    }
}