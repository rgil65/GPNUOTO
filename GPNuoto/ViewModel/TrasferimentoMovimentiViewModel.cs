using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;

namespace GPNuoto.ViewModel
{
    public class ElementoMatriceTrasferimentoViewModel: ViewModelBase
    {

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
                RaisePropertyChanged(DescrizionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Elementi" /> property's name.
        /// </summary>      
        public const string ElementiPropertyName = "Elementi";

        private List<SingoloTrasferimentoViewModel> _elementi = null;

        /// <summary>
        /// Sets and gets the Elementi property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloTrasferimentoViewModel> Elementi
        {
            get
            {
                return _elementi;
            }

            set
            {
                if (_elementi == value)
                {
                    return;
                }

                _elementi = value;
                RaisePropertyChanged(ElementiPropertyName);
            }
        }
    }
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TrasferimentoMovimentiViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the TrasferimentoMovimentiViewModel class.
        /// </summary>
        IDataService dataservice;
        public TrasferimentoMovimentiViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                MatriceTrasferimento = new List<ElementoMatriceTrasferimentoViewModel>();
                ElementoMatriceTrasferimentoViewModel emt = new ElementoMatriceTrasferimentoViewModel();
                MatriceTrasferimento.Add(emt);
                emt.Descrizione = "DESCRIZIONE CODICE CONTABILE";
                emt.Elementi = new List<SingoloTrasferimentoViewModel>();
                SingoloTrasferimentoViewModel stvm = new SingoloTrasferimentoViewModel();
                stvm.ModalitaPagamento = new ModalitaPagamentoViewModel();
                stvm.ModalitaPagamento.Descrizione = "Contanti";
                emt.Elementi.Add(stvm);
                stvm = new SingoloTrasferimentoViewModel();
                stvm.ModalitaPagamento = new ModalitaPagamentoViewModel();
                stvm.ModalitaPagamento.Descrizione = "Bonifico";
                emt.Elementi.Add(stvm);

                emt = new ElementoMatriceTrasferimentoViewModel();
                MatriceTrasferimento.Add(emt);
                emt.Descrizione = "DESCRIZIONE CODICE CONTABILE";
                emt.Elementi = new List<SingoloTrasferimentoViewModel>();
                stvm = new SingoloTrasferimentoViewModel();
                stvm.ModalitaPagamento = new ModalitaPagamentoViewModel();
                stvm.ModalitaPagamento.Descrizione = "Contanti";
                emt.Elementi.Add(stvm);
                stvm = new SingoloTrasferimentoViewModel();
                stvm.ModalitaPagamento = new ModalitaPagamentoViewModel();
                stvm.ModalitaPagamento.Descrizione = "Bonifico";
                emt.Elementi.Add(stvm);

            }
        }

        /// <summary>
        /// The <see cref="ElencoTrasferimenti" /> property's name.
        /// </summary>
        public const string ElencoTrasferimentiPropertyName = "ElencoTrasferimenti";

        private List<SingoloTrasferimentoViewModel> _elencoTrasferimenti = null;

        /// <summary>
        /// Sets and gets the ElencoTraferimenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloTrasferimentoViewModel> ElencoTrasferimenti
        {
            get
            {
                return _elencoTrasferimenti;
            }

            set
            {
                if (_elencoTrasferimenti == value)
                {
                    return;
                }
                _elencoTrasferimenti = value;

                RaisePropertyChanged(ElencoTrasferimentiPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="DataTrasferimento" /> property's name.
        /// </summary>
        public const string DataTrasferimentoPropertyName = "DataTrasferimento";

        private DateTime _dataTrasferimento = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataTrasferimento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataTrasferimento
        {
            get
            {
                return _dataTrasferimento;
            }

            set
            {
              
                _dataTrasferimento = value;

                CalcolaMatriceTrasferimento();
                RaisePropertyChanged(DataTrasferimentoPropertyName);
            }
        }


        /// <summary>
            /// The <see cref="MatriceTrasferimento" /> property's name.
            /// </summary>
        public const string MatriceTrasferimentoPropertyName = "MatriceTrasferimento";

        private List<ElementoMatriceTrasferimentoViewModel> _matrice = null;

        /// <summary>
        /// Sets and gets the MatriceTrasferimento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ElementoMatriceTrasferimentoViewModel> MatriceTrasferimento
        {
            get
            {
                return _matrice;
            }

            set
            {
                if (_matrice == value)
                {
                    return;
                }

                _matrice = value;
                RaisePropertyChanged(MatriceTrasferimentoPropertyName);
            }
        }

        void CalcolaMatriceTrasferimento()
        {
            List<ElementoMatriceTrasferimentoViewModel> mt = new List<ElementoMatriceTrasferimentoViewModel>();
            string sCausale = string.Empty;
            ElementoMatriceTrasferimentoViewModel  emt = null;

            foreach(SingoloTrasferimentoViewModel st in ElencoTrasferimenti.Where(p=>p.DataMovimenti == DataTrasferimento).OrderBy(p=>p.CausaleMovimento.Descrizione))
            {
                if (sCausale.CompareTo(st.CausaleMovimento.Descrizione) != 0)
                {
                    emt = new ElementoMatriceTrasferimentoViewModel();
                    emt.Descrizione = st.CausaleMovimento.Descrizione;
                    sCausale = emt.Descrizione;
                    emt.Elementi = new List<SingoloTrasferimentoViewModel>();
                    mt.Add(emt);
                }
                emt.Elementi.Add(st);
            }
            MatriceTrasferimento = mt;
        }

        /// <summary>
        /// The <see cref="ElencoDate" /> property's name.
        /// </summary>
        public const string ElencoDatePropertyName = "ElencoDate";

        private List<DateTime> _elencoDate = null;

        /// <summary>
        /// Sets and gets the ElencoDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<DateTime> ElencoDate
        {
            get
            {
                return _elencoDate;
            }

            set
            {
                if (_elencoDate == value)
                {
                    return;
                }

                _elencoDate = value;
                RaisePropertyChanged(ElencoDatePropertyName);
            }
        }

        /// <summary>
            /// The <see cref="IsNextDate" /> property's name.
            /// </summary>
        public const string IsNextDatePropertyName = "IsNextDate";


        /// <summary>
        /// Sets and gets the IsNextDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsNextDate
        {
            get
            {
                return (IndiceData>=0 && IndiceData<ElencoDate.Count-1);
            }

        }

        /// <summary>
        /// The <see cref="IsPrevDate" /> property's name.
        /// </summary>
        public const string IsPrevDatePropertyName = "IsPrevDate";

        /// <summary>
        /// Sets and gets the IsPrevDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsPrevDate
        {
            get
            {
                return (IndiceData>0);
            }

        }

        /// <summary>
        /// The <see cref="IndiceData" /> property's name.
        /// </summary>
        public const string IndiceDataPropertyName = "IndiceData";

        private int _indicedata = -1;

        /// <summary>
        /// Sets and gets the IndiceData property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IndiceData
        {
            get
            {
                return _indicedata;
            }

            set
            {
                if (_indicedata == value)
                {
                    return;
                }

                _indicedata = value;
                RaisePropertyChanged(IndiceDataPropertyName);
                RaisePropertyChanged(IsPrevDatePropertyName);
                RaisePropertyChanged(IsNextDatePropertyName);
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
                    _elencoCodiciContabili = dataservice.GetElencoCodiciContabili(false, null);
                return _elencoCodiciContabili;
            }

            set
            {
                if (_elencoCodiciContabili == value)
                {
                    return;
                }

                _elencoCodiciContabili = value;
                RaisePropertyChanged(ElencoCodiciContabiliPropertyName);
            }
        }

        private RelayCommand _refreshElencoTrasferimenti;

        /// <summary>
        /// Gets the RefreshControlloCasse.
        /// </summary>
        public RelayCommand RefreshElencoTrasferimenti
        {
            get
            {
                return _refreshElencoTrasferimenti
                    ?? (_refreshElencoTrasferimenti = new RelayCommand(
                    () =>
                    {
                        ElencoTrasferimenti = dataservice.GetElencoTrasferimenti();
                        ElencoDate = ElencoTrasferimenti.Select(p => p.DataMovimenti).Distinct().OrderBy(p => p.Date).ToList<DateTime>();
                        if (ElencoDate != null && ElencoDate.Count() > 0)
                        {
                            DataTrasferimento = ElencoDate[0];
                            IndiceData = 0;
                            
                        }
                        else
                        {
                            DataTrasferimento = DateTime.Now;
                            IndiceData = -1;
                        }
                        DateTime Dt = new DateTime(DataTrasferimento.Year, DataTrasferimento.Month, DataTrasferimento.Day,0,0,0,0);
                        ElencoMovimenti = dataservice.GetElencoAltriPagamenti(Dt);
                    //    MovimentoSelezionato = null;

                    }));
            }
        }

     

        private RelayCommand _gotoNextDate;

        /// <summary>
        /// Gets the GotoNextDate.
        /// </summary>
        public RelayCommand GotoNextDate
        {
            get
            {

                return _gotoNextDate

                    ?? (_gotoNextDate = new RelayCommand(
                    () =>
                    {
                        if (IndiceData < ElencoDate.Count-1)
                            IndiceData++;
                        if (ElencoDate.Count > 0)
                            DataTrasferimento = ElencoDate[IndiceData];

                    }));
            }
        }


        private RelayCommand _gotoPrevDate;

        /// <summary>
        /// Gets the GotoNextDate.
        /// </summary>
        public RelayCommand GotoPrevDate
        {
            get
            {

                return _gotoPrevDate

                    ?? (_gotoPrevDate = new RelayCommand(
                    () =>
                    {
                        if (IndiceData > 0)
                            IndiceData--;
                        if (ElencoDate.Count > 0)
                            DataTrasferimento = ElencoDate[IndiceData];

                    }));
            }
        }

        private RelayCommand<ElementoMatriceTrasferimentoViewModel> _eseguiTrasferimento;

        /// <summary>
        /// Gets the EseguiTrasferimento.
        /// </summary>
        public RelayCommand<ElementoMatriceTrasferimentoViewModel> EseguiTrasferimento
        {
            get
            {
                return _eseguiTrasferimento
                    ?? (_eseguiTrasferimento = new RelayCommand<ElementoMatriceTrasferimentoViewModel>(
                    p =>
                    {
                        dataservice.TraferisciContabilita(p);
                        RefreshElencoTrasferimenti.Execute(null);
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
                        SingoloMovimentoViewModel smvm = new SingoloMovimentoViewModel(false);
                        smvm.DataPagamento = new DateTime(DataTrasferimento.Year, DataTrasferimento.Month, DataTrasferimento.Day, 0, 0, 0, 0);
                        //smvm.CanSave = false;
                        //smvm.CanDelete = false;

                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditAltriMovimenti>(new ShowEditAltriMovimenti(smvm));

                    }));
            }
        }

        private RelayCommand<SingoloMovimentoViewModel> _deleteMovimento;

        /// <summary>
        /// Gets the DeleteMovimento.
        /// </summary>
        public RelayCommand<SingoloMovimentoViewModel> DeleteMovimento
        {
            get
            {
                return _deleteMovimento
                    ?? (_deleteMovimento = new RelayCommand<SingoloMovimentoViewModel>(
                    p =>
                    {
                        dataservice.DeleteMovimento(p);
                        RefreshElencoTrasferimenti.Execute(null);
                    }));
            }
        }


        private RelayCommand<SingoloMovimentoViewModel> _salvaMovimento;

        /// <summary>
        /// Gets the AddMovimento.
        /// </summary>
        public RelayCommand<SingoloMovimentoViewModel> SalvaMovimento
        {
            get
            {

                return _salvaMovimento

                    ?? (_salvaMovimento = new RelayCommand<SingoloMovimentoViewModel>(
                    p =>
                    {
                        p.ImportoPagare = p.ImportoPagato;
                        p.Sconto = 0;
                        dataservice.SavePagamento(p, SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>(),true);

                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditAltriMovimenti>(new ShowEditAltriMovimenti(null));
                        RefreshElencoTrasferimenti.Execute(null);
                    }));
            }
        }
        private RelayCommand _chiudiAltriMovimenti;

        /// <summary>
        /// Gets the AddMovimento.
        /// </summary>
        public RelayCommand ChiudiAltriMovimenti
        {
            get
            {

                return _chiudiAltriMovimenti

                    ?? (_chiudiAltriMovimenti = new RelayCommand(
                    () =>
                    {
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditAltriMovimenti>(new ShowEditAltriMovimenti(null));

                    }));
            }
        }

        
    }
}