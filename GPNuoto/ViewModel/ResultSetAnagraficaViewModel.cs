using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ResultSetAnagraficaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ResultSetAnagraficaViewModel class.
        /// </summary>
        public ResultSetAnagraficaViewModel()
        {
        }


        /// <summary>
        /// The <see cref="IDAnagrafica" /> property's name.
        /// </summary>
        public const string IDAnagraficaPropertyName = "IDAnagrafica";

        private int _iDAnagrafica = -1;

        /// <summary>
        /// Sets and gets the IDAnagrafica property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDAnagrafica
        {
            get
            {
                return _iDAnagrafica;
            }

            set
            {
                if (_iDAnagrafica == value)
                {
                    return;
                }

                _iDAnagrafica = value;
                RaisePropertyChanged(IDAnagraficaPropertyName);
            }
        }


        /// <summary>
            /// The <see cref="Nominativo" /> property's name.
            /// </summary>
        public const string NominativoPropertyName = "Nominativo";

        private string _nominativo = string.Empty;

        /// <summary>
        /// Sets and gets the Nominativo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nominativo
        {
            get
            {
                return _nominativo;
            }

            set
            {
                if (_nominativo == value)
                {
                    return;
                }

                _nominativo = value;
                RaisePropertyChanged(NominativoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CodiceFiscale" /> property's name.
        /// </summary>
        public const string CodiceFiscalePropertyName = "CodiceFiscale";

        private string _codiceFiscale = string.Empty;

        /// <summary>
        /// Sets and gets the CodiceFiscale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceFiscale
        {
            get
            {
                return _codiceFiscale;
            }

            set
            {
                if (_codiceFiscale == value)
                {
                    return;
                }

                _codiceFiscale = value;
                RaisePropertyChanged(CodiceFiscalePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ResidenzaVia" /> property's name.
        /// </summary>
        public const string ResidenzaViaPropertyName = "ResidenzaVia";

        private string _residenzaVia = string.Empty;

        /// <summary>
        /// Sets and gets the ResidenzaVia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ResidenzaVia
        {
            get
            {
                return _residenzaVia;
            }

            set
            {
                if (_residenzaVia == value)
                {
                    return;
                }

                _residenzaVia = value;
                RaisePropertyChanged(ResidenzaViaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ResidenzaCAP" /> property's name.
        /// </summary>
        public const string ResidenzaCAPPropertyName = "ResidenzaCAP";

        private string _residenzaCAP = string.Empty;

        /// <summary>
        /// Sets and gets the ResidenzaCAP property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ResidenzaCAP
        {
            get
            {
                return _residenzaCAP;
            }

            set
            {
                if (_residenzaCAP == value)
                {
                    return;
                }

                _residenzaCAP = value;
                RaisePropertyChanged(ResidenzaCAPPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ResidenzaComune" /> property's name.
        /// </summary>
        public const string ResidenzaComunePropertyName = "ResidenzaComune";

        private string _residenzaComune = string.Empty;

        /// <summary>
        /// Sets and gets the ResidenzaComune property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ResidenzaComune
        {
            get
            {
                return _residenzaComune;
            }

            set
            {
                if (_residenzaComune == value)
                {
                    return;
                }

                _residenzaComune = value;
                RaisePropertyChanged(ResidenzaComunePropertyName);
            }
        }
    }
}