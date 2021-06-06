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
    public class SelezioneIntervalloTempoModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SelezioneIntervalloTempoModell class.
        /// </summary>
        public SelezioneIntervalloTempoModel()
        {
        }

        /// <summary>
            /// The <see cref="Data" /> property's name.
            /// </summary>
        public const string DataPropertyName = "Data";

        private DateTime _data = DateTime.Now;

        /// <summary>
        /// Sets and gets the Data property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime Data
        {
            get
            {
                return _data;
            }

            set
            {
                if (_data == value)
                {
                    return;
                }

                _data = value;
                RaisePropertyChanged(DataPropertyName);
                RaisePropertyChanged(IsValidoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="OraInizio" /> property's name.
        /// </summary>
        public const string OraInizioPropertyName = "OraInizio";

        private DateTime? _oraInizio = new DateTime(0);

        /// <summary>
        /// Sets and gets the OraInizio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? OraInizio
        {
                get
            {
                return _oraInizio;
            }

            set
            {
                if (_oraInizio == value)
                {
                    return;
                }
                _oraInizio = value;
                RaisePropertyChanged(OraInizioPropertyName);
                RaisePropertyChanged(IsValidoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="OraFine" /> property's name.
        /// </summary>
        public const string OraFinePropertyName = "OraFine";

        private DateTime? _oraFine = new DateTime(0);

        /// <summary>
        /// Sets and gets the OraFine property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? OraFine
        {
            get
            {
                return _oraFine;
            }

            set
            {
                if (_oraFine == value)
                {
                    return;
                }

                _oraFine = value;
                RaisePropertyChanged(OraFinePropertyName);
                RaisePropertyChanged(IsValidoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsValido" /> property's name.
        /// </summary>
        public const string IsValidoPropertyName = "IsValido";

        /// <summary>
        /// Sets and gets the IsValido property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsValido
        {
            get
            {
                if (this.Data >= DateTime.Now.Date && this.OraInizio.Value.TimeOfDay.Ticks < this.OraFine.Value.TimeOfDay.Ticks)
                    return true;
                else
                    return false;
            }

        }
    }
}