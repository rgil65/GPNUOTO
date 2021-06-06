using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using System.Collections.Generic;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TableModalitaPagamentoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CodicContabiliViewModel class.
        /// </summary>
        IDataService dataservice;
        public TableModalitaPagamentoViewModel(IDataService ds)
        {

            if (ViewModelBase.IsInDesignModeStatic)
            {
                Elenco = new List<ModalitaPagamentoViewModel>();
                ModalitaPagamentoViewModel mp = new ModalitaPagamentoViewModel();
                mp.Key = "C";
                mp.Descrizione = "Contanti";
                mp.IsAttivo = true;
                Elenco.Add(mp);
                ElementoSelezionato = mp;
                ElementoEdit = mp;
            }
            else
            {
                dataservice = ds;
                Elenco = dataservice.GetElencoModalitaPagamento(bShowAll);
            }

        }

        /// <summary>
        /// The <see cref="Elenco" /> property's name.
        /// </summary>
        public const string ElencoPropertyName = "Elenco";

        private List<ModalitaPagamentoViewModel> _elenco = null;

        /// <summary>
        /// Sets and gets the Elenco property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ModalitaPagamentoViewModel> Elenco
        {
            get
            {

                return _elenco;
            }

            set
            {
                if (_elenco == value)
                {
                    return;
                }

                _elenco = value;
                RaisePropertyChanged(ElencoPropertyName);
            }
        }

        /// <summary>
            /// The <see cref="ElementoSelezionato" /> property's name.
            /// </summary>
        public const string ElementoSelezionatoPropertyName = "ElementoSelezionato";

        private ModalitaPagamentoViewModel _elementoSelezionato = null;

        /// <summary>
        /// Sets and gets the ElementoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ModalitaPagamentoViewModel ElementoSelezionato
        {
            get
            {
                return _elementoSelezionato;
            }

            set
            {
                if (_elementoSelezionato == value)
                {
                    return;
                }

                _elementoSelezionato = value;
                RaisePropertyChanged(ElementoSelezionatoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElementoEdit" /> property's name.
        /// </summary>
        public const string ElementoEditPropertyName = "ElementoEdit";

        private ModalitaPagamentoViewModel _elementoEdit = null;

        /// <summary>
        /// Sets and gets the ElementoEdit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ModalitaPagamentoViewModel ElementoEdit
        {
            get
            {
                if (_elementoEdit == null)
                    _elementoEdit = new ModalitaPagamentoViewModel();
                return _elementoEdit;
            }

            set
            {
                if (_elementoEdit == value)
                {
                    return;
                }

                _elementoEdit = value;
                RaisePropertyChanged(ElementoEditPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="bShowAll" /> property's name.
        /// </summary>
        public const string bShowAllPropertyName = "bShowAll";

        private bool _bShowAll = false;

        /// <summary>
        /// Sets and gets the bShowAll property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool bShowAll
        {
            get
            {
                return _bShowAll;
            }

            set
            {
                if (_bShowAll == value)
                {
                    return;
                }

                _bShowAll = value;
                RaisePropertyChanged(bShowAllPropertyName);
            }
        }

        private RelayCommand _addCodice;

        /// <summary>
        /// Gets the AddCodice.
        /// </summary>
        public RelayCommand AddCodice
        {
            get
            {
                return _addCodice
                    ?? (_addCodice = new RelayCommand(
                    () =>
                    {
                        ElementoEdit = new ModalitaPagamentoViewModel();
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditModalitaPagamento>(new ShowEditModalitaPagamento(true));
                    }));
            }
        }

        private RelayCommand _annullaEdit;

        /// <summary>
        /// Gets the AnnullaEdit.
        /// </summary>
        public RelayCommand AnnullaEdit
        {
            get
            {
                return _annullaEdit
                    ?? (_annullaEdit = new RelayCommand(
                    () =>
                    {
                        Elenco = dataservice.GetElencoModalitaPagamento(bShowAll);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditModalitaPagamento>(new ShowEditModalitaPagamento(false));

                    }));
            }
        }


        private RelayCommand _saveRecord;

        /// <summary>
        /// Gets the AnnullaEdit.
        /// </summary>
        public RelayCommand SaveRecord
        {
            get
            {
                return _saveRecord
                    ?? (_saveRecord = new RelayCommand(
                    () =>
                    {
                        dataservice.UpdateModalitaPagamento(ElementoEdit);
                        Elenco = dataservice.GetElencoModalitaPagamento(bShowAll);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditModalitaPagamento>(new ShowEditModalitaPagamento(false));
                    }));
            }
        }

        private RelayCommand _openEdit;

        /// <summary>
        /// Gets the OpenEdit.
        /// </summary>
        public RelayCommand OpenEdit
        {
            get
            {
                return _openEdit
                    ?? (_openEdit = new RelayCommand(
                    () =>
                    {
                        if (ElementoSelezionato != null)
                        {
                            ElementoEdit = ElementoSelezionato;
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditModalitaPagamento>(new ShowEditModalitaPagamento(true));
                        }

                    }));
            }
        }

        private RelayCommand _refreshElenco;

        /// <summary>
        /// Gets the RefreshElenco.
        /// </summary>
        public RelayCommand RefreshElenco
        {
            get
            {
                return _refreshElenco
                    ?? (_refreshElenco = new RelayCommand(
                    () =>
                    {
                        Elenco = dataservice.GetElencoModalitaPagamento(bShowAll);
                    }));
            }
        }

        private RelayCommand _deleteRecord;

        /// <summary>
        /// Gets the RefreshElenco.
        /// </summary>
        public RelayCommand DeleteRecord
        {
            get
            {
                return _deleteRecord
                    ?? (_deleteRecord = new RelayCommand(
                    () =>
                    {
                        if (ElementoEdit != null)
                        {
                            dataservice.DeleteModalitaPagamento(ElementoEdit);
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditModalitaPagamento>(new ShowEditModalitaPagamento(false));
                            ElementoEdit = null;
                            Elenco = dataservice.GetElencoModalitaPagamento(bShowAll);
                            
                        }
                    }));
            }
        }
    }
}