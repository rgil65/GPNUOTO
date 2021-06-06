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
    public class TableLuoghiNascitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CodicContabiliViewModel class.
        /// </summary>
        IDataService dataservice;
        public TableLuoghiNascitaViewModel(IDataService ds)
        {

            if (ViewModelBase.IsInDesignModeStatic)
            {
                Elenco = new List<SingoloLuogoNascitaViewModel>();
                SingoloLuogoNascitaViewModel mp = new SingoloLuogoNascitaViewModel();
                mp.ID = 1;
                mp.CodiceISTAT = "03567";
                mp.Descrizione = "CAMPONOGARA";
                mp.DescrizioneAggiuntiva = "AGGIUNTIVA";
                mp.IsEstero = false;
                Elenco.Add(mp);
                ElementoSelezionato = mp;
                ElementoEdit = mp;
            }
            else
            {
                dataservice = ds;
                //Elenco = dataservice.GetTabellaLuoghiNascita(txtFiltro);
            }

        }

        /// <summary>
        /// The <see cref="Elenco" /> property's name.
        /// </summary>
        public const string ElencoPropertyName = "Elenco";

        private List<SingoloLuogoNascitaViewModel> _elenco = null;

        /// <summary>
        /// Sets and gets the Elenco property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloLuogoNascitaViewModel> Elenco
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

        private SingoloLuogoNascitaViewModel _elementoSelezionato = null;

        /// <summary>
        /// Sets and gets the ElementoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloLuogoNascitaViewModel ElementoSelezionato
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

        private SingoloLuogoNascitaViewModel _elementoEdit = null;

        /// <summary>
        /// Sets and gets the ElementoEdit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloLuogoNascitaViewModel ElementoEdit
        {
            get
            {
                if (_elementoEdit == null)
                    _elementoEdit = new SingoloLuogoNascitaViewModel();
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
        /// The <see cref="txtFiltro" /> property's name.
        /// </summary>
        public const string txtFiltroPropertyName = "txtFiltro";

        private string _txtFiltro = string.Empty;

        /// <summary>
        /// Sets and gets the txtFiltro property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string txtFiltro
        {
            get
            {
                return _txtFiltro;
            }

            set
            {
               if (_txtFiltro == value)
                {
                    return;
                }

                _txtFiltro = value;
                Elenco = dataservice.GetTabellaLuoghiNascita(txtFiltro);
                RaisePropertyChanged(txtFiltroPropertyName);
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
                        ElementoEdit = new SingoloLuogoNascitaViewModel();
                        ElementoEdit.IsNew = true;
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditLuogoNascita>(new ShowEditLuogoNascita(true));
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
                         //Elenco = dataservice.GetTabellaLuoghiNascita(txtFiltro);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditLuogoNascita>(new ShowEditLuogoNascita(false));

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
                        dataservice.UpdateLuogoNascita(ElementoEdit);
                        Elenco = dataservice.GetTabellaLuoghiNascita(txtFiltro);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditLuogoNascita>(new ShowEditLuogoNascita(false));
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
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditLuogoNascita>(new ShowEditLuogoNascita(true));
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
                        Elenco = dataservice.GetTabellaLuoghiNascita(txtFiltro);
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
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditLuogoNascita>(new ShowEditLuogoNascita(false));
                            dataservice.DeleteLuogoNascita(ElementoEdit);
                            ElementoEdit = null;
                            Elenco = dataservice.GetTabellaLuoghiNascita(txtFiltro);

                        }
                    }));
            }
        }
    }
}