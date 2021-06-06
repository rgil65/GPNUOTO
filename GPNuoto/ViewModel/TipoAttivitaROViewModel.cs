using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPNuoto.ViewModel
{



    public class TipoAttivitaROChangeSelezione : GalaSoft.MvvmLight.Messaging.GenericMessage<TipoAttivitaROViewModel>
    {
        public TipoAttivitaROViewModel TA { get; set; }
        public TipoAttivitaROChangeSelezione(TipoAttivitaROViewModel _ta)
            : base(_ta)
        {
            TA = _ta;
        }
    }



    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class TipoAttivitaROViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the AnagraficaAttivitaViewModel1cs class.
        /// </summary>
        ///
        IDataService dataservice;
        public TipoAttivitaROViewModel()
        {
            dataservice = SimpleIoc.Default.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                Titolo = "Scuola nuoto adulti";
                BackgroundColor = "#0824f9";
                ForegroundColor = "#ffffff";
                IsAttivo = true;
                GruppiXLivello = false;
                
            }
        }

        
        /// <summary>
            /// The <see cref="Titolo" /> property's name.
            /// </summary>
        public const string TitoloPropertyName = "Titolo";

        private string _titolo = string.Empty;

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
        /// The <see cref="BackgroundColor" /> property's name.
        /// </summary>
        public const string BackgroundColorPropertyName = "BackgroundColor";

        private string _backgroundColor = "#FFFFFACD";

        /// <summary>
        /// Sets and gets the BackgroundColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }

            set
            {
                if (_backgroundColor == value)
                {
                    return;
                }

                _backgroundColor = value;
                RaisePropertyChanged(BackgroundColorPropertyName);
            } 
        }

        /// <summary>
        /// The <see cref="ForegroundColor" /> property's name.
        /// </summary>
        public const string ForegroundColorPropertyName = "ForegroundColor";

        private string _foregroundColor = "#FF000000";

        /// <summary>
        /// Sets and gets the ForegroundColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ForegroundColor
        {
            get
            {
                return _foregroundColor;
            }

            set
            {
                if (_foregroundColor == value)
                {
                    return;
                }

                _foregroundColor = value;
                RaisePropertyChanged(ForegroundColorPropertyName);
            }
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
        /// The <see cref="IsSelezionata" /> property's name.
        /// </summary>
        public const string IsSelezionataPropertyName = "IsSelezionata";

        private bool _isSelezionata = false;

        /// <summary>
        /// Sets and gets the IsSelezionata property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsSelezionata
        {
            get
            {
                return _isSelezionata;
            }

            set
            {
                if (_isSelezionata == value)
                {
                    return;
                }       

                _isSelezionata = value;
                GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<TipoAttivitaROChangeSelezione>(new TipoAttivitaROChangeSelezione(this));
                RaisePropertyChanged(IsSelezionataPropertyName);
                    
            }
        }
        /// <summary>
        /// The <see cref="CodiceContabileCassa" /> property's name.
        /// </summary>
        public const string CodiceContabileCassaPropertyName = "CodiceContabileCassa";

        private string _codiceContabileCassa = string.Empty;

        /// <summary>
        /// Sets and gets the CodiceContabileCassa property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CodiceContabileCassa
        {
            get
            {
                return _codiceContabileCassa;
            }

            set
            {
                if (_codiceContabileCassa == value)
                {
                    return;
                }

                _codiceContabileCassa = value;
                RaisePropertyChanged(CodiceContabileCassaPropertyName);
            }
        }

        
        public TimeSpan ProgrammazioneInizio { get; set; }
        public TimeSpan ProgrammazioneFine { get; set; }

        public TimeSpan StepPianificazione { get; set; }

        public TimeSpan Durata { get; set; }

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
        /// The <see cref="GruppiXLivello" /> property's name.
        /// </summary>
        public const string GruppiXLivelloPropertyName = "GruppiXLivello";

        private bool _gruppiXLivello = false;

        /// <summary>
        /// Sets and gets the GruppiXLivello property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool GruppiXLivello
        {
            get
            {
                return _gruppiXLivello;
            }

            set
            {
                if (_gruppiXLivello == value)
                {
                    return;
                }

                _gruppiXLivello = value;
                RaisePropertyChanged(GruppiXLivelloPropertyName);
            }
        }
    }
}