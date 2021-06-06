using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
    public class RegistroCassaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the RegistroCassaViewModel class.
        /// </summary>
        IDataService dataservice;
        public RegistroCassaViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                _elencoCasseDaValidare = new List<CassaViewModel>();
                CassaViewModel cvm = new CassaViewModel();
                _elencoCasseDaValidare.Add(cvm);
                _elencoCasseDaValidare.Add(cvm);
            }
        }
        /// <summary>
        /// The <see cref="ElencoCasseDaValidare" /> property's name.
        /// </summary>
        public const string ElencoCasseDaValidarePropertyName = "ElencoCasseDaValidare";

        private List<CassaViewModel> _elencoCasseDaValidare = null;

        /// <summary>
        /// Sets and gets the ElencoCasseDaValidare property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<CassaViewModel> ElencoCasseDaValidare
        {
            get
            {
                if (_elencoCasseDaValidare == null)
                    _elencoCasseDaValidare = dataservice.GetElencoCasseNonValidate();
                return _elencoCasseDaValidare;
            }

            set
            {
                if (_elencoCasseDaValidare == value)
                {
                    return;
                }

                _elencoCasseDaValidare = value;
                RaisePropertyChanged(ElencoCasseDaValidarePropertyName);
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

        private RelayCommand<CassaViewModel> _selezionaCassa;

        /// <summary>
        /// Gets the SelezionaCassa.
        /// </summary>
        public RelayCommand<CassaViewModel> SelezionaCassa
        {
            get
            {
                return _selezionaCassa
                    ?? (_selezionaCassa = new RelayCommand<CassaViewModel>(
                    p =>
                    {
                        foreach (CassaViewModel cvm in _elencoCasseDaValidare)
                            if (cvm.ID != p.ID)
                                cvm.IsSelected = false;
                            else
                            {
                                cvm.IsSelected = true;
                                ElencoMovimenti = dataservice.GetElencoMovimentiCassa(cvm);

                            }
                    }));
            }
        }
        private RelayCommand _refreshControlloCasse;

        /// <summary>
        /// Gets the RefreshControlloCasse.
        /// </summary>
        public RelayCommand RefreshControlloCasse
        {
            get
            {
                return _refreshControlloCasse
                    ?? (_refreshControlloCasse = new RelayCommand(
                    () =>
                    {
                        ElencoCasseDaValidare = dataservice.GetElencoCasseNonValidate();
                        ElencoMovimenti = null;
                    }));
            }
        }
        private RelayCommand<CassaViewModel> _convalidaCassa;

        /// <summary>
        /// Gets the ConvalidaCassa.
        /// </summary>
        public RelayCommand<CassaViewModel> ConvalidaCassa
        {
            get
            {
                return _convalidaCassa
                    ?? (_convalidaCassa = new RelayCommand<CassaViewModel>(
                    p =>
                    {
                        dataservice.ConvalidaCassa(p);
                        RefreshControlloCasse.Execute(null);
                    }));
            }
        }
    }
}