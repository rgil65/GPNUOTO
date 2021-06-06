using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using GPNuoto.ViewModel;
using System.Collections.Generic;

namespace GPNuoto.ViewModel
{

    public enum TipoDato { Intero, Stringa, Decimale, Data, NonRiconosciuto };

    public class HeaderReport
    {
        public string FieldName { get; set; }
        public string Formato { get; set; }
        public TipoDato TipoFormato { get; set; }
    }
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ReportPersonalizzatoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CodicContabiliViewModel class.
        /// </summary>
        
        public ReportPersonalizzatoViewModel()
        {
            
        }

        public int ID { get; set; }
        public string  Nome { get; set; }
        public string Descrizione { get; set; }
        public string Query { get; set; }
        public string QueryOriginale { get; set; }

        public List<HeaderReport>   Header{ get; set; }
        public List<List<object>> Records { get; set; }
    }
}