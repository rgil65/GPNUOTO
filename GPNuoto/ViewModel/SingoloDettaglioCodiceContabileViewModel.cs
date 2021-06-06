using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingoloDettaglioCodiceContabileViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloCodiceContabileViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        [PreferredConstructor]
        public SingoloDettaglioCodiceContabileViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            ID = -1;
        }

        public int ID { get; set; }

        /// <summary>
        /// The <see cref="Descrizione" /> property's name.
        /// </summary>
        public const string DescrizionePropertyName = "Descrizione";

        private string _descrizione = string.Empty;

        /// <summary>
        /// Sets and gets the Descrizione property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Descrizione
        {
            get
            {
                return _descrizione;
            }

            set
            {
                if (_descrizione == value)
                {
                    return;
                }

                _descrizione = value;
                RaisePropertyChanged(DescrizionePropertyName);
            }
        }

    
        /// <summary>
        /// The <see cref="ImportoPredefinito" /> property's name.
        /// </summary>
        public const string ImportoPredefinitoPropertyName = "ImportoPredefinito";

        private decimal _importoPredefinito = 0;

        /// <summary>
        /// Sets and gets the ImportoPredefinito property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoPredefinito
        {
            get
            {
                return _importoPredefinito;
            }

            set
            {
                if (_importoPredefinito == value)
                {
                    return;
                }

                _importoPredefinito = value;
                RaisePropertyChanged(ImportoPredefinitoPropertyName);
            }
        }


        
    }
}