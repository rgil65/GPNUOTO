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
    public class SingoloTrasferimentoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloTraferimentoViewModel class.
        /// </summary>
        public SingoloTrasferimentoViewModel()
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                DataMovimenti = DateTime.Now;
                ModalitaPagamento = new ModalitaPagamentoViewModel();
                CausaleMovimento = new SingoloCodiceContabileViewModel();
                Totale = 100;
                Trasferito = 100;
            }
        }

        /// <summary>
        /// The <see cref="DataMovimenti" /> property's name.
        /// </summary>
        public const string DataMovimentiPropertyName = "DataMovimenti";

        private DateTime _dataMovimenti = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataMovimenti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataMovimenti
        {
            get
            {
                return _dataMovimenti;
            }

            set
            {
                if (_dataMovimenti == value)
                {
                    return;
                }

                _dataMovimenti = value;
                RaisePropertyChanged(DataMovimentiPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="ModalitaPagamento" /> property's name.
        /// </summary>
        public const string ModalitaPagamentoPropertyName = "ModalitaPagamento";

        private ModalitaPagamentoViewModel _modalitaPagamento = null;

        /// <summary>
        /// Sets and gets the ModalitaPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ModalitaPagamentoViewModel ModalitaPagamento
        {
            get
            {
                return _modalitaPagamento;
            }

            set
            {
                if (_modalitaPagamento == value)
                {
                    return;
                }

                _modalitaPagamento = value;
                RaisePropertyChanged(ModalitaPagamentoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CausaleMovimento" /> property's name.
        /// </summary>
        public const string CausaleMovimentoPropertyName = "CausaleMovimento";

        private SingoloCodiceContabileViewModel _causaleMovimento = null;

        /// <summary>
        /// Sets and gets the CausaleMovimento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloCodiceContabileViewModel CausaleMovimento
        {
            get
            {
                return _causaleMovimento;
            }

            set
            {
                if (_causaleMovimento == value)
                {
                    return;
                }

                _causaleMovimento = value;
                RaisePropertyChanged(CausaleMovimentoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Totale" /> property's name.
        /// </summary>
        public const string TotalePropertyName = "Totale";

        private decimal _totale = 0;

        /// <summary>
        /// Sets and gets the Totale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal Totale
        {
            get
            {
                return _totale;
            }

            set
            {
                if (_totale == value)
                {
                    return;
                }

                _totale = value;
                RaisePropertyChanged(TotalePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Trasferito" /> property's name.
        /// </summary>
        public const string TrasferitoPropertyName = "Trasferito";

        private decimal _trasferito = 0;

        /// <summary>
        /// Sets and gets the Traferito property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal Trasferito
        {
            get
            {
                return _trasferito;
            }

            set
            {
                if (_trasferito == value)
                {
                    return;
                }

                _trasferito = value;
                RaisePropertyChanged(TrasferitoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Nota" /> property's name.
        /// </summary>
        public const string NotaPropertyName = "Nota";

        private string _nota = string.Empty;

        /// <summary>
        /// Sets and gets the Nota property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nota
        {
            get
            {
                return _nota;
            }

            set
            {
                if (_nota == value)
                {
                    return;
                }

                _nota = value;
                RaisePropertyChanged(NotaPropertyName);
            }
        }
    }
}