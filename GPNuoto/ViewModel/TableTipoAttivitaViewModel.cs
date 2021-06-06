using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using System.Collections.Generic;
using System.Linq;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TableTipoAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CodicContabiliViewModel class.
        /// </summary>
        IDataService dataservice;
        public TableTipoAttivitaViewModel(IDataService ds)
        {

            if (ViewModelBase.IsInDesignModeStatic)
            {
                Elenco = new List<TipoAttivitaViewModel>();
                TipoAttivitaViewModel mp = new TipoAttivitaViewModel();
                mp.BackgroundColor = "red";
                mp.ForegroundColor = "white";
                mp.Titolo = "Nuovo tipo attivita";
                Elenco.Add(mp);
                ElementoSelezionato = mp;
                ElementoEdit = mp;
            }
            else
            {
                dataservice = ds;
                Elenco = dataservice.GetElencoTipoAttivita(bShowAll);
            }

        }

        /// <summary>
        /// The <see cref="Elenco" /> property's name.
        /// </summary>
        public const string ElencoPropertyName = "Elenco";

        private List<TipoAttivitaViewModel> _elenco = null;

        /// <summary>
        /// Sets and gets the Elenco property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<TipoAttivitaViewModel> Elenco
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

        private TipoAttivitaViewModel _elementoSelezionato = null;

        /// <summary>
        /// Sets and gets the ElementoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TipoAttivitaViewModel ElementoSelezionato
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

        private TipoAttivitaViewModel _elementoEdit = null;

        /// <summary>
        /// Sets and gets the ElementoEdit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TipoAttivitaViewModel ElementoEdit
        {
            get
            {
                if (_elementoEdit == null)
                    _elementoEdit = new TipoAttivitaViewModel();
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
                RefreshElenco.Execute(null);
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
                        ElementoEdit = new TipoAttivitaViewModel();
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditTipoAttivitaCorsi>(new ShowEditTipoAttivitaCorsi(true));
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
                        Elenco = dataservice.GetElencoTipoAttivita(bShowAll);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditTipoAttivitaCorsi>(new ShowEditTipoAttivitaCorsi(false));

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
                        dataservice.UpdateTipoAttivita(ElementoEdit);
                        Elenco = dataservice.GetElencoTipoAttivita(bShowAll);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditTipoAttivitaCorsi>(new ShowEditTipoAttivitaCorsi(false));
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
                            ElementoEdit.IsErasabled = dataservice.IsTipoAttivitaErasable(ElementoEdit.ID);
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditTipoAttivitaCorsi>(new ShowEditTipoAttivitaCorsi(true));
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
                        // Salvo la selezione
                        List<TipoAttivitaViewModel> ElencoSelezioni = Elenco.Where(p => p.IsSelezionata).ToList();
                        List<TipoAttivitaViewModel> elenco = dataservice.GetElencoTipoAttivita(bShowAll);
                        // Ripristino selezione
                        foreach (TipoAttivitaViewModel tavm in ElencoSelezioni)
                        {
                            int k = elenco.FindIndex(p => p.ID == tavm.ID);
                            if (k != -1)
                                elenco[k].IsSelezionata = true;
                        }
                        Elenco = elenco;
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
                            dataservice.DeleteTipoAttivita(ElementoEdit);
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditTipoAttivitaCorsi>(new ShowEditTipoAttivitaCorsi(false));
                            ElementoEdit = null;
                            Elenco = dataservice.GetElencoTipoAttivita(bShowAll);
                            
                        }
                    }));
            }
        }
    }
}