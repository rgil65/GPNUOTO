using GalaSoft.MvvmLight;
using System;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingolaFatturaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingolaFatturaViewModel class.
        /// </summary>
        /// 
        
        public SingolaFatturaViewModel()
        {
           
            if (ViewModelBase.IsInDesignModeStatic)
            {
                Anagrafica = new SingolaAnagraficaViewModel();
                Movimento = new SingoloMovimentoViewModel();
            }

        }


        /// <summary>
        /// The <see cref="Anagrafica" /> property's name.
        /// </summary>
        public const string AnagraficaPropertyName = "Anagrafica";

        private SingolaAnagraficaViewModel _anagrafica = null;

        /// <summary>
        /// Sets and gets the Anagrafica property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingolaAnagraficaViewModel Anagrafica
        {
            get
            {
                return _anagrafica;
            }

            set
            {
                if (_anagrafica == value)
                {
                    return;
                }

                _anagrafica = value;
                RaisePropertyChanged(AnagraficaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Movimento" /> property's name.
        /// </summary>
        public const string MovimentoPropertyName = "Movimento";

        private SingoloMovimentoViewModel _movimento = null;

        /// <summary>
        /// Sets and gets the Movimento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloMovimentoViewModel Movimento
        {
            get
            {
                return _movimento;
            }

            set
            {
                if (_movimento == value)
                {
                    return;
                }

                _movimento = value;
                RaisePropertyChanged(MovimentoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DataFattura" /> property's name.
        /// </summary>
        public const string DataFatturaPropertyName = "DataFattura";

        private DateTime _dataFattura = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataFattura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataFattura
        {
            get
            {
                return _dataFattura;
            }

            set
            {
                if (_dataFattura == value)
                {
                    return;
                }

                _dataFattura = value;
                RaisePropertyChanged(DataFatturaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NumeroFattura" /> property's name.
        /// </summary>
        public const string NumeroFatturaPropertyName = "NumeroFattura";

        private string _numeroFattura = string.Empty;

        /// <summary>
        /// Sets and gets the NumeroFattura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NumeroFattura
        {
            get
            {
                return _numeroFattura;
            }

            set
            {
                if (_numeroFattura == value)
                {
                    return;
                }

                _numeroFattura = value;
                RaisePropertyChanged(NumeroFatturaPropertyName);
            }
        }
        
    }
}