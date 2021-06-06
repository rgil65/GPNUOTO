using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class FattureViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the FattureViewModel class.
        /// </summary>
        IDataService dataservice;
        public FattureViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                _elencoRichiesteFatture = new List<SingolaFatturaViewModel>();
                SingolaFatturaViewModel cvm = new SingolaFatturaViewModel();
                _elencoRichiesteFatture.Add(cvm);
                _elencoRichiesteFatture.Add(cvm);
            }
        }

        /// <summary>
        /// The <see cref="ElencoRichiesteFatture" /> property's name.
        /// </summary>
        public const string ElencoRichiesteFatturePropertyName = "ElencoRichiesteFatture";

        private List<SingolaFatturaViewModel> _elencoRichiesteFatture = null;

        /// <summary>
        /// Sets and gets the ElencoRichiesteFatture property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingolaFatturaViewModel> ElencoRichiesteFatture
        {
            get
            {
                if (_elencoRichiesteFatture == null)
                    RefreshRichiesteFatture.Execute(null);
                return _elencoRichiesteFatture;
            }

            set
            {
                if (_elencoRichiesteFatture == value)
                {
                    return;
                }

                _elencoRichiesteFatture = value;
                RaisePropertyChanged(ElencoRichiesteFatturePropertyName);
            }
        }

        private RelayCommand _refreshRichiesteFatture;

        /// <summary>
        /// Gets the RefreshControlloCasse.
        /// </summary>
        public RelayCommand RefreshRichiesteFatture
        {
            get
            {
                return _refreshRichiesteFatture
                    ?? (_refreshRichiesteFatture = new RelayCommand(
                    () =>
                    {
                        ElencoRichiesteFatture = dataservice.GetElencoRichiestaFatture();
                    }));
            }
        }
        private RelayCommand<SingolaFatturaViewModel> _convalidaCreazioneFattura;

        /// <summary>
        /// Gets the ConvalidaCreazioneFattura.
        /// </summary>
        public RelayCommand<SingolaFatturaViewModel> ConvalidaCreazioneFattura
        {
            get
            {
                return _convalidaCreazioneFattura
                    ?? (_convalidaCreazioneFattura = new RelayCommand<SingolaFatturaViewModel>(
                    p =>
                    {
                        dataservice.RegistraFattura(p);
                        ElencoRichiesteFatture = dataservice.GetElencoRichiestaFatture();
                    }));
            }
        }
    }
}