using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPNuoto.ViewModel
{
    public class RiepilogoIscrizioniViewModel : ViewModelBase
    {
        IDataService dataservice;
        public RiepilogoIscrizioniViewModel()
        {

            dataservice = ServiceLocator.Current.GetInstance<IDataService>();


            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<TipoAttivitaROChangeSelezione>(this,
            new Action<TipoAttivitaROChangeSelezione>(ChangeSelezione));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                ElencoTipoAttivita = dataservice.GetElencoTipoAttivitaRO(false);
            }
        }

        private void ChangeSelezione(TipoAttivitaROChangeSelezione obj)
        {
            ElencoAttivita = dataservice.GetRiepilogoAttivita(ElencoTipoAttivita.Where<TipoAttivitaROViewModel>(p => p.IsSelezionata).Select(k => k.ID).ToList<int>());
        }

        /// <summary>
        /// The <see cref="ElencoTipoAttivita" /> property's name.
        /// </summary>
        public const string ElencoTipoAttivitaPropertyName = "ElencoTipoAttivita";

        private List<TipoAttivitaROViewModel> _elencoTipoAttivita = null;

        /// <summary>
        /// Sets and gets the ElencoTipoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<TipoAttivitaROViewModel> ElencoTipoAttivita
        {
            get
            {
                if (_elencoTipoAttivita == null)
                    ElencoTipoAttivita = dataservice.GetElencoTipoAttivitaRO(false);
                return _elencoTipoAttivita;
            }

            set
            {
                if (_elencoTipoAttivita == value)
                {
                    return;
                }

                _elencoTipoAttivita = value;
                RaisePropertyChanged(ElencoTipoAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoAttivita" /> property's name.
        /// </summary>
        public const string ElencoAttivitaPropertyName = "ElencoAttivita";

        private List<RiepilogoAttivitaViewModel> _elencoAttivita = null;

        /// <summary>
        /// Sets and gets the ElencoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<RiepilogoAttivitaViewModel> ElencoAttivita
        {
            get
            {
                if (_elencoAttivita == null)
                {
                    ElencoAttivita = dataservice.GetRiepilogoAttivita(ElencoTipoAttivita.Where<TipoAttivitaROViewModel>(p => p.IsSelezionata).Select(k => k.ID).ToList<int>());
                }
                return _elencoAttivita;
            }

            set
            {
                if (_elencoAttivita == value)
                {
                    return;
                }

                _elencoAttivita = value;
                RaisePropertyChanged(ElencoAttivitaPropertyName);
            }
        }

        /// <summary>
            /// The <see cref="CurrentRiepilogoAttivita" /> property's name.
            /// </summary>
        public const string CurrentRiepilogoAttivitaPropertyName = "CurrentRiepilogoAttivita";

        private RiepilogoAttivitaViewModel _currentRiepilogoAttivita = null;

        /// <summary>
        /// Sets and gets the CurrentRiepilogoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RiepilogoAttivitaViewModel CurrentRiepilogoAttivita
        {
            get
            {
                return _currentRiepilogoAttivita;
            }

            set
            {
                if (_currentRiepilogoAttivita == value)
                {
                    return;
                }

                _currentRiepilogoAttivita = value;
                if (CurrentRiepilogoAttivita != null)
                    ElencoIscritti = dataservice.GetElencoIscritti(CurrentRiepilogoAttivita.ID);
                else
                    ElencoIscritti = null;
                RaisePropertyChanged(CurrentRiepilogoAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoIscritti" /> property's name.
        /// </summary>
        public const string ElencoIscrittiPropertyName = "ElencoIscritti";

        private List<AnagraficaROViewModel> _elencoIscritti = null;

        /// <summary>
        /// Sets and gets the ElencoIscritti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<AnagraficaROViewModel> ElencoIscritti
        {
            get
            {
                return _elencoIscritti;
            }

            set
            {
                if (_elencoIscritti == value)
                {
                    return;
                }

                _elencoIscritti = value;

               
                RaisePropertyChanged(ElencoIscrittiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsIscrittoSelezionato" /> property's name.
        /// </summary>
        public const string IsIscrittoSelezionatoPropertyName = "IsIscrittoSelezionato";

        private AnagraficaROViewModel _isIscrittoSelezionato = null;

        /// <summary>
        /// Sets and gets the ElencoIscritti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AnagraficaROViewModel IsIscrittoSelezionato
        {
            get
            {
                return _isIscrittoSelezionato;
            }

            set
            {
                if (_isIscrittoSelezionato == value)
                {
                    return;
                }

                _isIscrittoSelezionato = value;
                RaisePropertyChanged(IsIscrittoSelezionatoPropertyName);
            }
        }

       

       

    }
}
