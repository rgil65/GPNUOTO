using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Converters;
using GPNuoto.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AnagraficaAttivitaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CorsiViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public AnagraficaAttivitaViewModel(IDataService _dataService)
        {
            
            if (ViewModelBase.IsInDesignModeStatic)
            {
                List<SingolaAnagraficaAttivitaViewModel> lsavm = new List<SingolaAnagraficaAttivitaViewModel>();
                SingolaAnagraficaAttivitaViewModel sa = new SingolaAnagraficaAttivitaViewModel(dataservice);
                sa.DataInizio = new DateTime(2016,9,10);
                sa.DataFine = DateTime.Now;
                sa.TitoloAttivita = "Scuola nuoto adulti";
                sa.BackColor = "Blue";
                sa.ForegroundColor = "White";
                lsavm.Add(sa);
                ElencoAttivita = lsavm;
            }else
                dataservice = _dataService;
        }

        /// <summary>
        /// The <see cref="IsAnagraficaSelected" /> property's name.
        /// </summary>
        public const string IsAnagraficaSelectedPropertyName = "IsAnagraficaSelected";

        private bool _isAnagraficaSelected = false;

        /// <summary>
        /// Sets and gets the IsAnagraficaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAnagraficaSelected
        {
            get
            {
                return _isAnagraficaSelected;
            }

            set
            {
                

                _isAnagraficaSelected = value;
                if (_isAnagraficaSelected)
                    ElencoAttivita = dataservice.LoadAttivita(SimpleIoc.Default.GetInstance<AnagraficaViewModel>().IDAnagrafica);
                else
                    ElencoAttivita = null;
                        
                RaisePropertyChanged(IsAnagraficaSelectedPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoAttivita" /> property's name.
        /// </summary>
        public const string ElencoAttivitaPropertyName = "ElencoAttivita";

        private List<SingolaAnagraficaAttivitaViewModel> _elencoAttivita = null;

        /// <summary>
        /// Sets and gets the ElencoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingolaAnagraficaAttivitaViewModel> ElencoAttivita
        {
            get
            {
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
        /// The <see cref="ElencoPagamenti" /> property's name.
        /// </summary>
        public const string ElencoPagamentiPropertyName = "ElencoPagamenti";

        private List<SingoloMovimentoViewModel> _elencoPagamenti = null;

        /// <summary>
        /// Sets and gets the ElencoPagamenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloMovimentoViewModel> ElencoPagamenti
        {
            get
            {
                return _elencoPagamenti;
            }

            set
            {
                if (_elencoPagamenti == value)
                {
                    return;
                }

                _elencoPagamenti = value;
                RaisePropertyChanged(ElencoPagamentiPropertyName);
            }
        }

        
        private RelayCommand _nuovaAttivita;

        /// <summary>
        /// Gets the MyCommand.
        /// </summary>
        public RelayCommand NuovaAttivita
        {
            get
            {
                return _nuovaAttivita
                    ?? (_nuovaAttivita = new RelayCommand(
                     () =>
                    {

                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ShowSelezioneTipoAttivita = true;
                        

                    }));
            }
        }

        private RelayCommand<int> _addAttivita;

        /// <summary>
        /// Gets the AddAttivita.
        /// </summary>
        public RelayCommand<int> AddAttivita
        {
            get
            {
                return _addAttivita
                    ?? (_addAttivita = new RelayCommand<int>(
                    p =>
                    {
                        dataservice.AddAttivita(SimpleIoc.Default.GetInstance<AnagraficaViewModel>().IDAnagrafica, p);
                        ElencoAttivita = dataservice.LoadAttivita(SimpleIoc.Default.GetInstance<AnagraficaViewModel>().IDAnagrafica);
                        SimpleIoc.Default.GetInstance<TesseraViewModel>().Refresh(SimpleIoc.Default.GetInstance<AnagraficaViewModel>());
                    }));
            }
        }


        private RelayCommand<SingolaAnagraficaAttivitaViewModel> _deleteAttivita;

        /// <summary>
        /// Gets the EditAttivita.
        /// </summary>
        public RelayCommand<SingolaAnagraficaAttivitaViewModel> DeleteAttivita
        {
            get
            {
                return _deleteAttivita
                    ?? (_deleteAttivita = new RelayCommand<SingolaAnagraficaAttivitaViewModel>(
                    p =>
                    {
                        dataservice.DeleteAttivita(p.ID);
                        ElencoAttivita = dataservice.LoadAttivita(SimpleIoc.Default.GetInstance<AnagraficaViewModel>().IDAnagrafica);
                    }));
            }
        }

        private RelayCommand _refreshAttivita;

        /// <summary>
        /// Gets the RefreshAttivita.
        /// </summary>
        public RelayCommand RefreshAttivita
        {
            get
            {
                return _refreshAttivita
                    ?? (_refreshAttivita = new RelayCommand(
                    () =>
                    {
                        ElencoAttivita = dataservice.LoadAttivita(SimpleIoc.Default.GetInstance<AnagraficaViewModel>().IDAnagrafica);
                    }));
            }
        }


      
    }
}