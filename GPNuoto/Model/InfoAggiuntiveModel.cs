using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace GPNuoto.Model
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class InfoAggiuntiveModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the InfoAggiuntiveModel class.
        /// </summary>
        /// 
        public enum TipoInfoAdd {Data,Testo,Range,Livello,SiNo };

        public class InfoAdd
        {
            public int ID;
            public int IDSetupInformazioniAggiuntive;
            public string Descrizione;
            public TipoInfoAdd Tipo;
            public string Parametro;
            public object Valore;
        }
        

        public Dictionary<string,InfoAdd> InfoAddMatrix { get; set; }

        IDataService _dataservice;
        

        public InfoAggiuntiveModel(IDataService dataservice)
        {

            _dataservice = dataservice;
            List<setupinformazioniaggiuntive> lsia = dataservice.GetSetupInformazioniAggiuntive();


            
            InfoAddMatrix = new Dictionary<string, InfoAdd>();
            foreach (setupinformazioniaggiuntive sa in lsia)
            {
                InfoAdd nia = new InfoAdd();
                nia.Descrizione = sa.Descrizione;
                nia.IDSetupInformazioniAggiuntive = sa.IDSetupInformazioniAggiuntive;
                if (sa.TipoInformazione.CompareTo("Data") == 0)
                {
                    nia.Tipo = TipoInfoAdd.Data;
                }
                else
                    if (sa.TipoInformazione.CompareTo("Testo") == 0)
                    {
                        nia.Tipo = TipoInfoAdd.Testo;
                    }
                else
                    if (sa.TipoInformazione.CompareTo("Range") == 0)
                    nia.Tipo = TipoInfoAdd.Range;
                else
                    if (sa.TipoInformazione.CompareTo("Livello") == 0)
                    nia.Tipo = TipoInfoAdd.Livello;
                else
                    if (sa.TipoInformazione.CompareTo("SiNo") == 0)
                    nia.Tipo = TipoInfoAdd.SiNo;
                nia.Parametro = sa.Parametrizzazione;
                InfoAddMatrix.Add(sa.CodInfo, nia);
            }
        }

      


        public void Clear()
        {
            foreach(var ia in InfoAddMatrix)
            {
                ia.Value.ID = 0;
                switch(ia.Value.Tipo)
                {
                    case TipoInfoAdd.Data:
                    case TipoInfoAdd.Range:
                    case TipoInfoAdd.SiNo:
                        InfoAddMatrix[ia.Key].Valore = null;
                        break;
                    case TipoInfoAdd.Livello:
                        InfoAddMatrix[ia.Key].Valore = 0;
                        break;

                    default:
                        InfoAddMatrix[ia.Key].Valore = null;
                        break;
                }
            }
        }
        public void LoadValues(int idRecord)
        {

            _dataservice.LoadInfoAggiuntive(idRecord,InfoAddMatrix);
            


        }

        public void SaveValues(int idRecord)
        {

            _dataservice.SaveInfoAggiuntive(idRecord,InfoAddMatrix);

           
        }
        public void SetValue(string FieldName,object value)
        {

            InfoAddMatrix[FieldName].Valore = value;
        }
    }
}