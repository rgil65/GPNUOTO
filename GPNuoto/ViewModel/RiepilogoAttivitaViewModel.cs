using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPNuoto.ViewModel
{
    public class RiepilogoAttivitaViewModel : ViewModelBase
    {
    
        public int ID { get; set; }

        public int IDTipoAttivita { get; set; }


        /// <summary>
        /// The <see cref="BackColorAttivita" /> property's name.
        /// </summary>
        public const string BackColorAttivitaPropertyName = "BackColorAttivita";

        private string _backColorAttivita = string.Empty;

        /// <summary>
        /// Sets and gets the BackColorAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BackColorAttivita
        {
            get
           {
                return _backColorAttivita;
            }

            set
            {
                if (_backColorAttivita == value)
                {
                    return;
                }

                _backColorAttivita = value;
                RaisePropertyChanged(BackColorAttivitaPropertyName);
            }

        }

        /// <summary>
        /// The <see cref="ForeColorAttivita" /> property's name.
        /// </summary>
        public const string ForeColorAttivitaPropertyName = "ForeColorAttivita";

        private string _foreColorAttivita = string.Empty;

        /// <summary>
        /// Sets and gets the BackColorAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ForeColorAttivita
        {
            get
            {
                return _foreColorAttivita;
            }

            set
            {
                if (_foreColorAttivita == value)
                {
                    return;
                }

                _foreColorAttivita = value;
                RaisePropertyChanged(ForeColorAttivitaPropertyName);
            }

        }

        /// <summary>
        /// The <see cref="NumeroIscritti" /> property's name.
        /// </summary>
        public const string NumeroIscrittiPropertyName = "NumeroIscritti";

        private int _numeroIscritti = 0;

        /// <summary>
        /// Sets and gets the NumeroIscritti property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumeroIscritti
        {
            get
            {
                return _numeroIscritti;
            }

            set
            {
                if (_numeroIscritti == value)
                {
                    return;
                }

                _numeroIscritti = value;
                RaisePropertyChanged(NumeroIscrittiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NumeroIscrittiAttivi" /> property's name.
        /// </summary>
        public const string NumeroIscrittiAttiviPropertyName = "NumeroIscrittiAttivi";

        private int _numeroIscrittiAttivi = 0;

        /// <summary>
        /// Sets and gets the NumeroIscrittiAttivi property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumeroIscrittiAttivi
        {
            get
            {
                return _numeroIscrittiAttivi;
            }

            set
            {
                if (_numeroIscrittiAttivi == value)
                {
                    return;
                }

                _numeroIscrittiAttivi = value;
                RaisePropertyChanged(NumeroIscrittiAttiviPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Titolo" /> property's name.
        /// </summary>
        public const string TitoloPropertyName = "Titolo";

        private string _titolo = "titolo di prova";// string.Empty;

        /// <summary>
        /// Sets and gets the Titolo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Titolo
        {
            get
            {
                return _titolo;
            }

            set
            {
                if (_titolo == value)
                {
                    return;
                }

                _titolo = value;
                RaisePropertyChanged(TitoloPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DataInizio" /> property's name.
        /// </summary>
        public const string DataInizioPropertyName = "DataInizio";

        private DateTime _dataInizio = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataInizio
        {
            get
            {
                return _dataInizio;
            }

            set
            {
                if (_dataInizio == value)
                {
                    return;
                }

                _dataInizio = value;
                RaisePropertyChanged(DataInizioPropertyName);
            }
        }
    }
}
