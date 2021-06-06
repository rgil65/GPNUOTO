using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using GPNuoto.ViewModel;
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
    public class CodiciContabiliDettagliViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CodicContabiliViewModel class.
        /// </summary>
        IDataService dataservice;
        public CodiciContabiliDettagliViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                CodiceContabile = new SingoloCodiceContabileViewModel();
                CodiceContabile.Descrizione = "Estivo";
            }

        }

        /// <summary>
        /// The <see cref="CodiceContabile" /> property's name.
        /// </summary>
        public const string CodiceContabilePropertyName = "CodiceContabile";

        private SingoloCodiceContabileViewModel _codiceContabile = null;

        /// <summary>
        /// Sets and gets the CodiceContabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloCodiceContabileViewModel CodiceContabile
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
                Elenco = null;
                ElementoSelezionato = null;
                if (value != null)
                    Elenco = dataservice.GetDettagliCodiceContabile(CodiceContabile.Codice);
                RaisePropertyChanged(CodiceContabilePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Elenco" /> property's name.
        /// </summary>
        public const string ElencoPropertyName = "Elenco";

        private List<SingoloDettaglioCodiceContabileViewModel> _elenco = null;

        /// <summary>
        /// Sets and gets the Elenco property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloDettaglioCodiceContabileViewModel> Elenco
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

        private SingoloDettaglioCodiceContabileViewModel _elementoSelezionato = null;

        /// <summary>
        /// Sets and gets the ElementoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloDettaglioCodiceContabileViewModel ElementoSelezionato
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
        /// The <see cref="IsShowAddCodice" /> property's name.
        /// </summary>
        public const string IsShowAddCodicePropertyName = "IsShowAddCodice";

        private bool _showAddCodice = false;

        /// <summary>
        /// Sets and gets the IsShowAddCodice property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsShowAddCodice
        {
            get
            {
                return _showAddCodice;
            }

            set
            {
                if (_showAddCodice == value)
                {
                    return;
                }

                _showAddCodice = value;
                RaisePropertyChanged(IsShowAddCodicePropertyName);
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

                _descrizione = value.Trim();
                IsShowAddCodice = _descrizione.Length > 0;
                RaisePropertyChanged(DescrizionePropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ImportoPredefinito" /> property's name.
        /// </summary>
        public const string ImportoPredefinitoPropertyName = "ImportoPredefinito";

        private decimal _importoPredefinito = 0;

        /// <summary>
        /// Sets and gets the ImportoPredefinito property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoPredefinito
        {
            get
            {
                return _importoPredefinito;
            }

            set
            {
                if (_importoPredefinito == value)
                {
                    return;
                }

                _importoPredefinito = value;
                RaisePropertyChanged(ImportoPredefinitoPropertyName);
            }
        }

        private RelayCommand _addDettaglio;

        /// <summary>
        /// Gets the AddDettaglio.
        /// </summary>
        public RelayCommand AddDettaglio
        {
            get
            {
                return _addDettaglio
                    ?? (_addDettaglio = new RelayCommand(
                    () =>
                    {
                        SingoloDettaglioCodiceContabileViewModel cd = new SingoloDettaglioCodiceContabileViewModel();
                        cd.Descrizione = Descrizione;
                        cd.ImportoPredefinito = ImportoPredefinito;
                        dataservice.AddDettaglioCodiceContabile(CodiceContabile,cd);
                        Descrizione = string.Empty;
                        ImportoPredefinito = 0;
                        Elenco = null;
                        Elenco = dataservice.GetDettagliCodiceContabile(CodiceContabile.Codice);
                    }));
            }
        }


        private RelayCommand _removeDettaglio;

        /// <summary>
        /// Gets the AddDettaglio.
        /// </summary>
        public RelayCommand RemoveDettaglio
        {
            get
            {
                return _removeDettaglio
                    ?? (_removeDettaglio = new RelayCommand(
                    () =>
                    {

                        if (ElementoSelezionato != null)
                        {
                            dataservice.RemoveDettaglioCodiceContabile(ElementoSelezionato);
                            Elenco = null;
                            Elenco = dataservice.GetDettagliCodiceContabile(CodiceContabile.Codice);
                        }
                    }));
            }
        }
    }
}