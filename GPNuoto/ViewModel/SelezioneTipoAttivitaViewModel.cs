using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Linq;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SelezioneTipoAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CorsiSelezioneViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public SelezioneTipoAttivitaViewModel(IDataService _dataservice)
        {

            dataservice = _dataservice;
            if (IsInDesignMode)
            {
                // Do something that only happens on Design mode
                ElencoTipoAttivita = new List<TipoAttivitaViewModel>();
                TipoAttivitaViewModel avm = new TipoAttivitaViewModel();
                avm.Titolo = "Attivita1";
                ElencoTipoAttivita.Add(avm);
                avm = new TipoAttivitaViewModel();
                avm.Titolo = "Attivita2";
                ElencoTipoAttivita.Add(avm);
                avm = new TipoAttivitaViewModel();
                avm.Titolo = "Attivita3";
                ElencoTipoAttivita.Add(avm);
            }else
            {

                _elencotipoAttivita = _dataservice.GetElencoTipoAttivita(false);


            }
        }

        /// <summary>
        /// The <see cref="ElencoTipoAttivita" /> property's name.
        /// </summary>
        public const string ElencoTipoAttivitaPropertyName = "ElencoTipoAttivita";

        private List<TipoAttivitaViewModel> _elencotipoAttivita = new List<TipoAttivitaViewModel>();

        /// <summary>
        /// Sets and gets the ResultSet property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<TipoAttivitaViewModel> ElencoTipoAttivita
        {
            get
            {
                return _elencotipoAttivita;
            }

            set
            {
                if (_elencotipoAttivita == value)
                {
                    return;
                }

                _elencotipoAttivita = value;
                RaisePropertyChanged(ElencoTipoAttivitaPropertyName);
            }
        }

      

        private RelayCommand _annullaSelezioneAttivita;

        /// <summary>
        /// Gets the AnnullaSelezioneAttivita.
        /// </summary>
        public RelayCommand AnnullaSelezioneAttivita
        {
            get
            {
                return _annullaSelezioneAttivita
                    ?? (_annullaSelezioneAttivita = new RelayCommand(
                    () =>
                    {
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowSelezioneTipoAttivita = false;
                    }));
            }
        }

        private RelayCommand<TipoAttivitaViewModel> _selezionaTipoAttivita;

        /// <summary>
        /// Gets the SelezionaAttivita.
        /// </summary>
        public RelayCommand<TipoAttivitaViewModel> SelezionaTipoAttivita
        {
            get
            {
                return _selezionaTipoAttivita
                    ?? (_selezionaTipoAttivita = new RelayCommand<TipoAttivitaViewModel>(
                    p =>
                    {


                        SimpleIoc.Default.GetInstance<SelezioneAnagraficaAttivitaViewModel>().TipoAttivita = p;

                        //SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowSelezioneTipoAttivita = false;
                        //GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshCalendarioCorsi>(new RefreshCalendarioCorsi());
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowSelezioneAttivita = true;

                    }));
            }
        }


      
    }
}