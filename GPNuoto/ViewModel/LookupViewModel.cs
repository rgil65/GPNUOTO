using GalaSoft.MvvmLight;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LookupViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the LookupViewModel class.
        /// </summary>
        public LookupViewModel()
        {
        }

        public LookupViewModel(int id, string sDescrizione)
        {
            ID = id;
            Descrizione = sDescrizione;
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
    }
}