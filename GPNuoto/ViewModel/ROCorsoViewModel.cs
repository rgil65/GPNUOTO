using GalaSoft.MvvmLight;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ROCorsoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the ROCorsoViewModel1 class.
        /// </summary>
        IDataService dataservice;
        public ROCorsoViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
        }

        /// <summary>
        /// The <see cref="ID" /> property's name.
        /// </summary>
        public const string IDPropertyName = "ID";

        private int _id = 0;

        /// <summary>
        /// Sets and gets the ID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(IDPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IDTipoAttivita" /> property's name.
        /// </summary>
        public const string IDTipoAttivitaPropertyName = "IDTipoAttivita";

        private int _idTipoAttivita = 0;

        /// <summary>
        /// Sets and gets the idTipoAttivta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IDTipoAttivita
        {
            get
            {
                return _idTipoAttivita;
            }

            set
            {
                if (_idTipoAttivita == value)
                {
                    return;
                }

                _idTipoAttivita = value;
                RaisePropertyChanged(IDTipoAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="TipoCorso" /> property's name.
        /// </summary>
        public const string TipoCorsoPropertyName = "TipoCorso";

        private CorsoViewModel.TipoCorsoValue _tipoCorso = CorsoViewModel.TipoCorsoValue.Singolo;

        /// <summary>
        /// Sets and gets the TipoCorso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CorsoViewModel.TipoCorsoValue  TipoCorso
        {
            get
            {
                return _tipoCorso;
            }

            set
            {
                if (_tipoCorso == value)
                {
                    return;
                }

                _tipoCorso = value;
                RaisePropertyChanged(TipoCorsoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Note" /> property's name.
        /// </summary>
        public const string NotePropertyName = "Note";

        private string _note = string.Empty;

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
        /// <summary>
        /// The <see cref="CostoIvaLezione" /> property's name.
        /// </summary>
        public const string CostoIvaLezionePropertyName = "CostoIvaLezione";

        private decimal _costoIvaLezione = 0;

        /// <summary>
        /// Sets and gets the CostoIvaLezione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CostoIvaLezione
        {
            get
            {
                return _costoIvaLezione;
            }

            set
            {
                if (_costoIvaLezione == value)
                {
                    return;
                }

                _costoIvaLezione = value;
                RaisePropertyChanged(CostoIvaLezionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CostoLordoLezione" /> property's name.
        /// </summary>
        public const string CostoLordoLezionePropertyName = "CostoLordoLezione";

        private decimal _costoLordoLezione = 0;

        /// <summary>
        /// Sets and gets the CostoLordoLezione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CostoLordoLezione
        {
            get
            {
                return _costoLordoLezione;
            }

            set
            {
                if (_costoLordoLezione == value)
                {
                    return;
                }

                _costoLordoLezione = value;
                RaisePropertyChanged(CostoLordoLezionePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="NumeroLezioni" /> property's name.
        /// </summary>
        public const string NumeroLezioniPropertyName = "NumeroLezioni";

        private int _numeroLezioni = 0;

        /// <summary>
        /// Sets and gets the NumeroLezioni property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumeroLezioni
        {
            get
            {
                return _numeroLezioni;
            }

            set
            {
                if (_numeroLezioni == value)
                {
                    return;
                }

                _numeroLezioni = value;
                RaisePropertyChanged(NumeroLezioniPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsAttivo" /> property's name.
        /// </summary>
        public const string IsAttivoPropertyName = "IsAttivo";

        private bool _isAttivo = true;

        /// <summary>
        /// Sets and gets the IsAttivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsAttivo
        {
            get
            {
                return _isAttivo;
            }

            set
            {
                if (_isAttivo == value)
                {
                    return;
                }

                _isAttivo = value;
                RaisePropertyChanged(IsAttivoPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="DettaglioOrari" /> property's name.
        /// </summary>
        public const string DettaglioOrariPropertyName = "DettaglioOrari";

        private List<OrarioCorsoViewModel> _dettaglioOrari = null;

        /// <summary>
        /// Sets and gets the DettaglioOrari property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<OrarioCorsoViewModel> DettaglioOrari
        {
            get
            {
                return _dettaglioOrari;
            }

            set
            {
                if (_dettaglioOrari == value)
                {
                    return;
                }

                _dettaglioOrari = value;
                RaisePropertyChanged(DettaglioOrariPropertyName);
            }
        }
    }
}