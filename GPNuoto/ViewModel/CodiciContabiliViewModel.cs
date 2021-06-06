using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using System.Collections.Generic;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CodiciContabiliViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CodicContabiliViewModel class.
        /// </summary>
        IDataService dataservice;
        public CodiciContabiliViewModel(IDataService ds)
        {
            dataservice = ds;
            if (ViewModelBase.IsInDesignModeStatic)
            {
                Elenco = new List<SingoloCodiceContabileViewModel>();
                SingoloCodiceContabileViewModel scc = new SingoloCodiceContabileViewModel();
                scc.Codice = "010101";
                scc.Descrizione = "Cassa 01";
                scc.Indice = "01";
                scc.IsAttivo = true;
                scc.IsAttivitaExtra = true;
                scc.IsFiscale = true;
                scc.bSegno = false;
                Elenco.Add(scc);
            }
            else
                Elenco = dataservice.GetElencoCodiciContabili(bShowAll,null);

        }

        /// <summary>
        /// The <see cref="Elenco" /> property's name.
        /// </summary>
        public const string ElencoPropertyName = "Elenco";

        private List<SingoloCodiceContabileViewModel> _elenco = null;

        /// <summary>
        /// Sets and gets the Elenco property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloCodiceContabileViewModel> Elenco
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

        private SingoloCodiceContabileViewModel _elementoSelezionato = null;

        /// <summary>
        /// Sets and gets the ElementoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloCodiceContabileViewModel ElementoSelezionato
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

        /// <summary>
        /// The <see cref="ElementoEdit" /> property's name.
        /// </summary>
        public const string ElementoEditPropertyName = "ElementoEdit";

        private SingoloCodiceContabileViewModel _elementoEdit = null;

        /// <summary>
        /// Sets and gets the ElementoEdit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloCodiceContabileViewModel ElementoEdit
        {
            get
            {
                if (_elementoEdit == null)
                    _elementoEdit = new SingoloCodiceContabileViewModel();
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
                        ElementoEdit = new SingoloCodiceContabileViewModel();
                        ElementoEdit.IsNew = true;
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditCodiciContabili>(new ShowEditCodiciContabili(true));
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
                        Elenco = dataservice.GetElencoCodiciContabili(bShowAll,null);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditCodiciContabili>(new ShowEditCodiciContabili(false));

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
                        dataservice.UpdateCodiceContabile(ElementoEdit);
                        Elenco = dataservice.GetElencoCodiciContabili(bShowAll,null);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditCodiciContabili>(new ShowEditCodiciContabili(false));
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
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditCodiciContabili>(new ShowEditCodiciContabili(true));
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
                        Elenco = dataservice.GetElencoCodiciContabili(bShowAll,null);
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
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditCodiciContabili>(new ShowEditCodiciContabili(false));
                            dataservice.DeleteCodiceContabile(ElementoEdit);
                            ElementoEdit = null;
                            Elenco = dataservice.GetElencoCodiciContabili(bShowAll ,null);
                        }
                    }));
            }
        }

        private RelayCommand _gestioneDettagli;

        /// <summary>
        /// Gets the GestioneDettagli.
        /// </summary>
        public RelayCommand GestioneDettagli
        {
            get
            {
                return _gestioneDettagli
                    ?? (_gestioneDettagli = new RelayCommand(
                    () =>
                    {
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowGestioneCodiciContabili>(new ShowGestioneCodiciContabili(this.ElementoEdit));
                            //dataservice.DeleteCodiceContabile(ElementoEdit);
                            //ElementoEdit = null;
                            //Elenco = dataservice.GetElencoCodiciContabili(bShowAll, null);
                    }));
            }
        }

    }
}