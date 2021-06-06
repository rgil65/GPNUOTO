using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPNuoto.ViewModel
{
    public class LogTornelliViewModel : ViewModelBase
    {

        /// <summary>
        /// The <see cref="Note" /> property's name.
        /// </summary>
        public const string NotePropertyName = "Note";

        private string _note = string.Empty;


        public string Log { get; set; }
        /// <summary>
        /// Sets and gets the Note property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Note
        {
            get
            {
                return _note;
            }

            set
            {
                if (_note == value)
                {
                    return;
                }

                _note = value;
                RaisePropertyChanged(NotePropertyName);
            }
        }

        public int IDAnagrafica { get; set; }
        public int IDAnagraficaAttivitaDate { get; set; }

        public int IDAttivita { get; set; }

        public int Autorizzazionems { get; set; }

        public int IDCorsi { get; set; }

        public int IDMovimento { get; set; }

        public bool IsIngresso { get; set; }

        public int TipoIngresso { get; set; }
        public int IDAnagraficaAttivita { get; set; }
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
            }
        }
        /// <summary>
        /// The <see cref="IsAutorizzato" /> property's name.
        /// </summary>
        public const string IsAutorizzatoPropertyName = "IsAutorizzato";


        private bool isAutorizzato = false;

        /// <summary>
        /// Sets and gets the IsAutorizzato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAutorizzato
        {
            get
            {
                return isAutorizzato;
            }

            set
            {
                if (isAutorizzato == value)
                {
                    return;
                }

                isAutorizzato = value;
                RaisePropertyChanged(IsAutorizzatoPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="DataInizioCorso" /> property's name.
        /// </summary>
        public const string DataInizioCorsoPropertyName = "DataInizioCorso";

        private DateTime _datainiziocorso = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataInizioCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataInizioCorso
        {
            get
            {
                return _datainiziocorso;
            }

            set
            {
                if (_datainiziocorso == value)
                {
                    return;
                }

                _datainiziocorso = value;
                RaisePropertyChanged(DataInizioCorsoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DataFineCorso" /> property's name.
        /// </summary>
        public const string DataFineCorsoPropertyName = "DataFineCorso";

        private DateTime _dataFineCorso = DateTime.Now;

        /// <summary>
        /// Sets and gets the DataFineCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime DataFineCorso
        {
            get
            {
                return _dataFineCorso;
            }

            set
            {
                if (_dataFineCorso == value)
                {
                    return;
                }

                _dataFineCorso = value;
                RaisePropertyChanged(DataFineCorsoPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="LetturaBadge" /> property's name.
        /// </summary>
        public const string LetturaBadgePropertyName = "LetturaBadge";

        private string _letturaBadge = string.Empty;

        /// <summary>
        /// Sets and gets the LetturaBadge property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LetturaBadge
        {
            get
            {
                return _letturaBadge;
            }

            set
            {
                if (_letturaBadge == value)
                {
                    return;
                }

                _letturaBadge = value;
                RaisePropertyChanged(LetturaBadgePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CodiceContabile" /> property's name.
        /// </summary>
        public const string CodiceContabilePropertyName = "CodiceContabile";

        private string _codiceContabile = string.Empty;

        /// <summary>
        /// Sets and gets the CodiceContabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceContabile
        {
            get
            {
                return _codiceContabile;
            }

            set
            {
                if (_codiceContabile == value)
                {
                    return;
                }

                _codiceContabile = value;
                RaisePropertyChanged(CodiceContabilePropertyName);
            }
        }


    }
}
