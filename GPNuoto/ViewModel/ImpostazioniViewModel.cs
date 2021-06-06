using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System.Windows;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ImpostazioniViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the UtenteViewModel class.
        /// </summary>
        /// 
        

        public ImpostazioniViewModel()
        {
            
        }

        /// <summary>
        /// The <see cref="DBConnectionString" /> property's name.
        /// </summary>
        public const string DBConnectionStringPropertyName = "DBConnectionString";

        private string _dbConnectionString = string.Empty;

        /// <summary>
        /// Sets and gets the DBConnectionString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DBConnectionString
        {
            get
            {
                if (_dbConnectionString == string.Empty)
                {
                    _dbConnectionString = Properties.Settings.Default.DBConnectionString;
                }
                return _dbConnectionString;
            }

            set
            {
                if (_dbConnectionString == value)
                {
                    return;
                }

                _dbConnectionString = value;
                Properties.Settings.Default["DBConnectionString"] = _dbConnectionString;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(DBConnectionStringPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DirectoryStampanteFiscale" /> property's name.
        /// </summary>
        public const string DirectoryStampanteFiscalePropertyName = "DirectoryStampanteFiscale";

        private string _directoryStampanteFiscale = "";

        /// <summary>
        /// Sets and gets the DirectoryStampanteFiscale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DirectoryStampanteFiscale
        {
            get
            {
                if (_directoryStampanteFiscale == string.Empty)
                {
                    _directoryStampanteFiscale = Properties.Settings.Default.DirectoryStampanteFiscale;
                }
                return _directoryStampanteFiscale;
            }

            set
            {
                if (_directoryStampanteFiscale == value)
                {
                    return;
                }

                _directoryStampanteFiscale = value;
                Properties.Settings.Default["DirectoryStampanteFiscale"] = _directoryStampanteFiscale;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(DirectoryStampanteFiscalePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="StampanteRicevuta" /> property's name.
        /// </summary>
        public const string StampanteRicevutaPropertyName = "StampanteRicevuta";

        private string _stampanteRicevuta = string.Empty;

        /// <summary>
        /// Sets and gets the StampanteRicevuta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StampanteRicevuta
        {
            get
            {
                if (_stampanteRicevuta == string.Empty)
                {
                    _stampanteRicevuta = Properties.Settings.Default.StampanteRicevuta;
                }
                return _stampanteRicevuta;
            }

            set
            {
                if (_stampanteRicevuta == value)
                {
                    return;
                }

                _stampanteRicevuta = value;
                Properties.Settings.Default["StampanteRicevuta"] = _stampanteRicevuta;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(StampanteRicevutaPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="StampanteBadge" /> property's name.
        /// </summary>
        public const string StampanteBadgePropertyName = "StampanteBadge";

        private string _stampanteBadge = string.Empty;

        /// <summary>
        /// Sets and gets the StampanteBadge property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StampanteBadge
        {
            get
            {
                if (_stampanteBadge == string.Empty)
                {
                     _stampanteBadge = Properties.Settings.Default.StampanteBadge;
                }
                return _stampanteBadge;
            }

            set
            {
                if (_stampanteBadge == value)
                {
                    return;
                }

                _stampanteBadge = value;
                Properties.Settings.Default["StampanteBadge"] = _stampanteBadge;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(StampanteBadgePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AnticipoIngresso" /> property's name.
        /// </summary>
        public const string AnticipoIngressoPropertyName = "AnticipoIngresso";

        private int _anticipoIngresso = 0;

        /// <summary>
        /// Sets and gets the StampanteBadge property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int AnticipoIngresso
        {
            get
            {
                if (_anticipoIngresso == 0)
                {
                    _anticipoIngresso = Properties.Settings.Default.AnticipoIngresso;
                }
                return _anticipoIngresso;
            }

            set
            {
                if (_anticipoIngresso == value)
                {
                    return;
                }

                _anticipoIngresso = value;
                Properties.Settings.Default["AnticipoIngresso"] = _anticipoIngresso;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(AnticipoIngressoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="AnticipoFineCorso" /> property's name.
        /// </summary>
        public const string AnticipoFineCorsoPropertyName = "AnticipoFineCorso";

        private int _anticipoFineCorso = 0;

        /// <summary>
        /// Sets and gets the StampanteBadge property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int AnticipoFineCorso
        {
            get
            {
                if (_anticipoFineCorso == 0)
                {
                    _anticipoFineCorso = Properties.Settings.Default.AnticipoFineCorso;
                }
                return _anticipoFineCorso;
            }

            set
            {
                if (_anticipoFineCorso == value)
                {
                    return;
                }

                _anticipoFineCorso = value;
                Properties.Settings.Default["AnticipoFineCorso"] = _anticipoFineCorso;
                Properties.Settings.Default.Save();
                RaisePropertyChanged(AnticipoFineCorsoPropertyName);
            }
        }


    }
}