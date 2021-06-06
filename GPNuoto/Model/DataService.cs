using System;
using System.Linq;
using GPNuoto.ViewModel;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using DBManagerMySql;
using Microsoft.Practices.ServiceLocation;
using MySql.Data.MySqlClient;
using static GPNuoto.ViewModel.AnagraficaViewModel;

namespace GPNuoto.Model
{
    //public class setupinformazioniaggiuntive
    //{
    //    public int IDSetupInformazioniAggiuntive { get; set; }
    //    public string CodInfo { get; set; }
    //    public string TipoInformazione { get; set; }
    //    public string Descrizione { get; set; }
    //    public int Ordine { get; set; }
    //    public string Parametrizzazione { get; set; }

    //}

    //public class anagrafica
    //{
    //    public anagrafica()
    //    {

    //    }

    //    public int IDAnagrafica { get; set; }
    //    public string Cognome { get; set; }
    //    public string Nome { get; set; }
    //    public int IDLuogoNascita { get; set; }
    //    public System.DateTime DataNascita { get; set; }
    //    public string Sesso { get; set; }
    //    public string CodiceFiscale { get; set; }
    //    public Nullable<int> IDComuneResidenza { get; set; }
    //    public string CAP { get; set; }
    //    public string Indirizzo { get; set; }
    //    public string Note { get; set; }
    //    public string Localita { get; set; }
    //    public string Telefono { get; set; }
    //    public string Cellulare { get; set; }
    //    public string Email { get; set; }
    //    public short Fattura { get; set; }
    //    public string DenominazioneFattura { get; set; }
    //    public string FatturaPIVACF { get; set; }
    //    public string FatturaIndirizzo { get; set; }
    //    public string FatturaCodiceUnivoco { get; set; }

    //    pub
    //}


    public class DataService : IDataService
    {





        public const string DATEFORMATADDFIELDS = "yyyyMMdd";


        private DbServiceMySql DBService = null;
        public DataService()
        {
            ImpostazioniViewModel ivm = ServiceLocator.Current.GetInstance<ImpostazioniViewModel>();
            DBService = new DbServiceMySql(ivm.DBConnectionString);
        }

        public string GetVersioneDatabase()
        {
            string versione = "?";
            using (QueryReader dtm = DBService.GetReader("SELECT * from versionedb"))
            {
                dtm.dr.Read();
                versione = dtm.dr["Versione"].ToString();
            }
            return versione;
        }


        public void WriteLog(string Sezione, string Log)
        {
            // Inserimento
            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("insert into LogTable(Data,Sezione,Log) values(now(),@Sezione,@Log)"))
            {

                dtm.SetValue("Sezione", Sezione);
                dtm.SetValue("Log", Log);
                dtm.InsertUpdateRecord();
            }
        }

        #region GESTIONE ANAGRAFICA
        public void RemoveAnagrafica(int ID)
        {

            if (CanRemoveAnagrafica(ID))
            {

                //using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("delete from informazioniaggiuntive where IDRecord =" + ID.ToString()))
                //{
                //    // Cancello informazioni aggiuntive
                //    dtm.InsertUpdateRecord();
                //}

                using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("delete from anagrafica where IDAnagrafica=" + ID.ToString()))
                {
                    // Cancello informazioni aggiuntive
                    dtm.InsertUpdateRecord();
                }
            }
        }

        public bool CanRemoveAnagrafica(int ID)
        {
            if (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from movimenti where idAnagrafica=" + ID.ToString())) > 0) return false;

            if (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from anagraficaattivita where idAnagrafica=" + ID.ToString())) > 0) return false;
            return true;

        }
        #endregion
        //public List<setupinformazioniaggiuntive> GetSetupInformazioniAggiuntive()
        //{
        //    List<setupinformazioniaggiuntive> lista = new List<setupinformazioniaggiuntive>();
        //    using (QueryReader dtm = DBService.GetReader("SELECT * FROM setupinformazioniaggiuntive order by ordine"))
        //    {
        //        while (dtm.dr.Read())
        //        {
        //            setupinformazioniaggiuntive lt = new setupinformazioniaggiuntive();
        //            lt.IDSetupInformazioniAggiuntive = DbServiceMySql.DB2I(dtm.dr["IDSetupInformazioniAggiuntive"]);
        //            lt.Ordine = DbServiceMySql.DB2I(dtm.dr["Ordine"]);
        //            lt.Parametrizzazione = dtm.dr["Parametrizzazione"].ToString();
        //            lt.CodInfo = dtm.dr["CodInfo"].ToString();
        //            lt.TipoInformazione = dtm.dr["TipoInformazione"].ToString();
        //            lt.Descrizione = dtm.dr["Descrizione"].ToString();
        //            lista.Add(lt);
        //        }
        //    }

        //    return lista;
        //}

        public List<LookupViewModel> GetElencoLuoghiNascita(bool bEstero)
        {

            List<LookupViewModel> elencoLuoghiNascita = new List<LookupViewModel>();
            using (QueryReader dtm = DBService.GetReader("SELECT IDLuoghiNascita,Descrizione FROM luoghinascita where DescrizioneAggiuntiva" + (bEstero ? "!='Italia" : "='Italia") + "'"))
            {
                while (dtm.dr.Read())
                    elencoLuoghiNascita.Add(new LookupViewModel(DbServiceMySql.DB2I(dtm.dr["IDLuoghiNascita"]), dtm.dr["Descrizione"].ToString()));
            }
            return elencoLuoghiNascita;
        }

        public List<LookupViewModel> GetElencoLocalita()
        {
            List<LookupViewModel> elencoLocalita = new List<LookupViewModel>();

            using (QueryReader dtm = DBService.GetReader("SELECT IDComuneResidenza,concat(Comune,'(',SiglaProvincia,')') as Descrizione FROM comuneresidenza order by Descrizione"))
            {
                while (dtm.dr.Read())
                    elencoLocalita.Add(new LookupViewModel(DbServiceMySql.DB2I(dtm.dr["IDComuneResidenza"]), dtm.dr["Descrizione"].ToString()));
            }
            return elencoLocalita;
        }

        public string GetCAP(int ID)
        {
            return DbServiceMySql.DB2I(DBService.GetScalar("select CAP from comuneresidenza where IDComuneResidenza=" + ID.ToString())).ToString();
        }


        public string GetCodiceISTAT(int ID)
        {
            using (QueryReader dtm = DBService.GetReader("select CodiceISTAT from luoghinascita where IDLuoghiNascita=" + ID.ToString()))
            {
                if (dtm.dr.Read())
                    return dtm.dr["CodiceISTAT"].ToString();
                else
                    return string.Empty;
            }
        }


        //private TipoInfoAdd TipoInformazioneStringToEnum(string sTipo)
        //{


        //    if (sTipo.CompareTo("Data") == 0)
        //        return TipoInfoAdd.Data;
        //    else
        //        if (sTipo.CompareTo("Testo") == 0)
        //        return TipoInfoAdd.Testo;
        //    else
        //        if (sTipo.CompareTo("Range") == 0)
        //        return TipoInfoAdd.Range;
        //    else
        //        if (sTipo.CompareTo("Livello") == 0)
        //        return TipoInfoAdd.Livello;
        //    else
        //        if (sTipo.CompareTo("SiNo") == 0)
        //        return TipoInfoAdd.SiNo;
        //    return TipoInfoAdd.Testo;
        //}

        //public void SaveInfoAggiuntive(int idRecord, Dictionary<string, InfoAggiuntiveModel.InfoAdd> InfoAddMatrix)
        //{
        //    foreach (var q in InfoAddMatrix)
        //    {
        //        string Valore = string.Empty;
        //        if (q.Value.Valore != null)
        //        {
        //            switch (q.Value.Tipo)
        //            {

        //                case TipoInfoAdd.Data:
        //                    CultureInfo provider = CultureInfo.InvariantCulture;
        //                    Valore = ((DateTime)q.Value.Valore).ToString(DATEFORMATADDFIELDS);
        //                    break;
        //                case TipoInfoAdd.Livello:
        //                case TipoInfoAdd.Range:
        //                    Valore = q.Value.Valore.ToString();
        //                    break;
        //                default:
        //                    Valore = q.Value.Valore.ToString();
        //                    break;

        //            }
        //        }
        //        if (q.Value.ID != 0)
        //        {
        //            // Update
        //            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("update informazioniaggiuntive set Valore=@Valore where IDInformazioniAggiuntive=" + q.Value.ID.ToString()))
        //            {

        //                dtm.SetValue("Valore", Valore);
        //                dtm.InsertUpdateRecord();
        //            }
        //        } else {
        //            // Inserimento
        //            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("insert into informazioniaggiuntive(IDSetupInformazioniAggiuntive,IDRecord,Valore) values(@IDSetupInformazioniAggiuntive,@IDRecord,@Valore)"))
        //            {

        //                dtm.SetValue("IDSetupInformazioniAggiuntive", q.Value.IDSetupInformazioniAggiuntive);
        //                dtm.SetValue("IDRecord", idRecord);
        //                dtm.SetValue("Valore", Valore);
        //                dtm.InsertUpdateRecord();
        //            }
        //        }
        //    }
        //}

        //public void LoadInfoAggiuntive(int idRecord, Dictionary<string, InfoAdd> InfoAddMatrix)
        //{

        //    using (QueryReader dtm = DBService.GetReader("SELECT IDInformazioniAggiuntive,Valore,TipoInformazione,CodInfo,informazioniaggiuntive.IDSetupInformazioniAggiuntive as IDSIA FROM informazioniaggiuntive inner join setupinformazioniaggiuntive on informazioniaggiuntive.IDSetupInformazioniAggiuntive = setupinformazioniaggiuntive.IDSetupInformazioniAggiuntive where IDRecord=" + idRecord.ToString()))
        //    {

        //        while (dtm.dr.Read())
        //        {
        //            InfoAddMatrix[dtm.dr["CodInfo"].ToString()].ID = DbServiceMySql.DB2I(dtm.dr["IDInformazioniAggiuntive"]);
        //            InfoAddMatrix[dtm.dr["CodInfo"].ToString()].IDSetupInformazioniAggiuntive = DbServiceMySql.DB2I(dtm.dr["IDSIA"]);
        //            switch (TipoInformazioneStringToEnum(dtm.dr["TipoInformazione"].ToString()))
        //            {
        //                case TipoInfoAdd.Data:
        //                    if (!DbServiceMySql.IsNull(dtm.dr["Valore"]))
        //                    {
        //                        CultureInfo provider = CultureInfo.InvariantCulture;
        //                        if (dtm.dr["Valore"].ToString() != string.Empty)
        //                        {
        //                            DateTime p = DateTime.ParseExact(dtm.dr["Valore"].ToString(), DATEFORMATADDFIELDS, provider);
        //                            InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = p;
        //                        }
        //                        else
        //                            InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = null;

        //                    }
        //                    else
        //                        InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = null;
        //                    break;
        //                case TipoInfoAdd.Livello:
        //                case TipoInfoAdd.Range:
        //                    if (!DbServiceMySql.IsNull(dtm.dr["Valore"]))
        //                        InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = DbServiceMySql.DB2I(dtm.dr["Valore"]);
        //                    else
        //                        InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = null;
        //                    break;
        //                case TipoInfoAdd.SiNo:
        //                    if (!DbServiceMySql.IsNull(dtm.dr["Valore"]) && dtm.dr["Valore"].ToString().CompareTo("True") == 0)
        //                        InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = (bool)true;
        //                    else
        //                        InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = (bool)false;
        //                    break;
        //                default:
        //                    InfoAddMatrix[dtm.dr["CodInfo"].ToString()].Valore = dtm.dr["Valore"].ToString();
        //                    break;
        //            }
        //        }
        //    }
        //}

        public void GetAnagraficaById(AnagraficaViewModel avm, int id)
        {

            using (QueryReader dtm = DBService.GetReader("SELECT * from anagrafica where IDAnagrafica=" + id.ToString()))
            {
                if (dtm.dr.Read())
                    LoadAnagrafica(avm, dtm.dr);
            }

        }
        public AnagraficaROViewModel GetAnagraficaById(int id)
        {
            using (QueryReader dtm = DBService.GetReader("SELECT * from anagrafica where IDAnagrafica=" + id.ToString()))
            {
                if (dtm.dr.Read())
                    return m2vmAnagraficaROViewModel(dtm.dr);
            }
            return null;
        }



        public List<int> GetAnagraficaByCF(string CF)
        {
            List<int> lista = new List<int>();
            using (QueryReader dtm = DBService.GetReader("SELECT idAnagrafica from anagrafica where CodiceFiscale='" + CF + "'"))
            {
                while (dtm.dr.Read())
                    lista.Add(DbServiceMySql.DB2I(dtm.dr["idAnagrafica"]));
            }
            return lista;
        }

        private void LoadAnagrafica(AnagraficaViewModel avm, MySqlDataReader dr)
        {

            avm.IDAnagrafica = DbServiceMySql.DB2I(dr["IDAnagrafica"]);

            avm.Cellulare = dr["Cellulare"].ToString();
            avm.CodiceFiscale = dr["CodiceFiscale"].ToString();
            avm.Cognome = dr["Cognome"].ToString();
            avm.DataNascita = DbServiceMySql.DB2DT(dr["DataNascita"]);
            avm.Email = dr["Email"].ToString();
            if (!DbServiceMySql.IsNull(dr["IDComuneResidenza"]))
                avm.IDComuneResidenza = DbServiceMySql.DB2I(dr["IDComuneResidenza"]);
            else
                avm.IDComuneResidenza = -1;
            avm.CAP = dr["CAP"].ToString();
            avm.IDLuogoNascita = DbServiceMySql.DB2I(dr["IDLuogoNascita"]);
            avm.StatoNascita = DbServiceMySql.DB2B(DBService.GetScalar("select Estero from luoghinascita where IDLuoghiNascita=" + avm.IDLuogoNascita.ToString())) ? "Estero" : "Italia";

            avm.Indirizzo = dr["Indirizzo"].ToString();
            avm.Localita = dr["Localita"].ToString();
            avm.Nome = dr["Nome"].ToString();
            avm.Note = dr["Note"].ToString();
            avm.Sesso = dr["Sesso"].ToString().CompareTo("M") == 0 ? "Maschio" : "Femmina";
            avm.Telefono = dr["Telefono"].ToString();
            avm.TipoFattura = (TipoFatturazione)DbServiceMySql.DB2I(dr["Fattura"]);
            avm.DenominazioneFattura = dr["DenominazioneFattura"].ToString(); ;
            avm.FatturaIndirizzo = dr["FatturaIndirizzo"].ToString();
            avm.FatturaPIVACF = dr["FatturaPIVACF"].ToString();
            avm.FatturaCodiceUnivoco = dr["FatturaCodiceUnivoco"].ToString();
            

            avm.DataScadenzaCertificatoMedico = DbServiceMySql.DB2DTN(dr["CERTMED"]);
            avm.ConsegnatoRegolamentoPrivacy = DbServiceMySql.DB2B(dr["REGPRY"]);
            avm.LivelloNuoto = DbServiceMySql.DB2I(dr["LIVNUO"]);
            avm.AssicuratoFinoA = DbServiceMySql.DB2DTN(dr["ASSNUO"]);

            avm.IsFieldChanged = false;
            avm.DeletedOn = CanRemoveAnagrafica(avm.IDAnagrafica);
            avm.ClearOn = true;
            //GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshInformazioniAggiuntiveAnagrafica>(new RefreshInformazioniAggiuntiveAnagrafica());
            SimpleIoc.Default.GetInstance<TesseraViewModel>().Refresh(avm);

        }

        public int SaveAnagrafica(AnagraficaViewModel avm)
        {

            string sql = string.Empty;
            if (avm.IDAnagrafica <= 0)
                sql = "insert into anagrafica(Cognome,Nome,IDLuogoNascita,DataNascita,Sesso,CodiceFiscale,IDComuneResidenza,CAP,Indirizzo,Note,Localita,Telefono,Cellulare,Email,Fattura,DenominazioneFattura,FatturaPIVACF,FatturaIndirizzo,FatturaCodiceUnivoco,CERTMED,REGPRY,LIVNUO,ASSNUO) " +
                      "values(@Cognome,@Nome,@IDLuogoNascita,@DataNascita,@Sesso,@CodiceFiscale,@IDComuneResidenza,@CAP,@Indirizzo,@Note,@Localita,@Telefono,@Cellulare,@Email,@Fattura,@DenominazioneFattura,@FatturaPIVACF,@FatturaIndirizzo,@FatturaCodiceUnivoco,@CERTMED,@REGPRY,@LIVNUO,@ASSNUO)";
            else
                sql = "update anagrafica set Cognome=@Cognome,Nome=@Nome,IDLuogoNascita=@IDLuogoNascita,DataNascita=@DataNascita,Sesso=@Sesso,CodiceFiscale=@CodiceFiscale,IDComuneResidenza=@IDComuneResidenza," +
                      "CAP=@CAP,Indirizzo=@Indirizzo,Note=@Note,Localita=@Localita,Telefono=@Telefono,Cellulare=@Cellulare,Email=@Email,Fattura=@Fattura," +
                      "DenominazioneFattura=@DenominazioneFattura,FatturaPIVACF=@FatturaPIVACF,FatturaIndirizzo=@FatturaIndirizzo,FatturaCodiceUnivoco=FatturaCodiceUnivoco, "+
                      "CERTMED=@CERTMED,REGPRY=@REGPRY,LIVNUO=@LIVNUO,ASSNUO=@ASSNUO where IDAnagrafica=" + avm.IDAnagrafica.ToString();

            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate(sql))
            {

                dtm.SetValue("Cognome", avm.Cognome);
                dtm.SetValue("Nome", avm.Nome);
                dtm.SetValue("IDLuogoNascita", avm.IDLuogoNascita);
                dtm.SetValue("DataNascita", avm.DataNascita);
                dtm.SetValue("Sesso", avm.Sesso.First().ToString());
                dtm.SetValue("CodiceFiscale", avm.CodiceFiscale);
                if (avm.IDComuneResidenza > 0)
                    dtm.SetValue("IDComuneResidenza", avm.IDComuneResidenza);
                else
                    dtm.SetValue("IDComuneResidenza", null);
                dtm.SetValue("CAP", avm.CAP);
                dtm.SetValue("Indirizzo", avm.Indirizzo);
                dtm.SetValue("Note", avm.Note);
                dtm.SetValue("Localita", avm.Localita);
                dtm.SetValue("Telefono", avm.Telefono);
                dtm.SetValue("Cellulare", avm.Cellulare);
                dtm.SetValue("Email", avm.Email);
                dtm.SetValue("Fattura", (short)avm.TipoFattura);
                dtm.SetValue("DenominazioneFattura", avm.DenominazioneFattura);
                dtm.SetValue("FatturaPIVACF", avm.FatturaPIVACF);
                dtm.SetValue("FatturaIndirizzo", avm.FatturaIndirizzo);
                dtm.SetValue("FatturaCodiceUnivoco", avm.FatturaCodiceUnivoco);
                dtm.SetValue("CERTMED", avm.DataScadenzaCertificatoMedico);
                dtm.SetValue("REGPRY", avm.ConsegnatoRegolamentoPrivacy);
                dtm.SetValue("LIVNUO", avm.LivelloNuoto);
                dtm.SetValue("ASSNUO", avm.AssicuratoFinoA);
                if (avm.IDAnagrafica <= 0)
                    avm.IDAnagrafica = (int)dtm.InsertUpdateRecord();
                else
                    dtm.InsertUpdateRecord();
            }
//            avm.AnagraficaInfoAdd.SaveValues(avm.IDAnagrafica);
            return avm.IDAnagrafica;
        }

        public ObservableCollection<ResultSetAnagraficaViewModel> QueryAnagrafica(AnagraficaViewModel avm)
        {
            string sql = "select IDAnagrafica,CodiceFiscale,concat(Cognome,' ',Nome) as Nominativo,Indirizzo, anagrafica.cap as CAPComune, comuneresidenza.comune as comunedescri,localita,SiglaProvincia from anagrafica left join comuneresidenza on anagrafica.IDComuneResidenza = comuneresidenza.IDComuneResidenza  where 1=1 ";

            bool bCognome = false;
            bool bNome = false;

            if (avm.Cognome != null && avm.Cognome.Trim() != string.Empty)
            { 
                sql = sql + "and Cognome like concat('%',@Cognome,'%')";
                bCognome = true;
            }
            if (avm.Nome != null && avm.Nome.Trim() != string.Empty)
            {
                sql = sql + "and Nome like concat('%',@Nome,'%')";
                bNome = true;
            }

            sql = sql + " order by Cognome,Nome";
            ObservableCollection<ResultSetAnagraficaViewModel> ResultSet = new ObservableCollection<ResultSetAnagraficaViewModel>();
            using (QueryReaderWithParameter dtm = DBService.GetReaderWithParameter(sql))
            {
                if (bCognome)
                    dtm.SetValue("Cognome", avm.Cognome.Trim());

                if (bNome)
                    dtm.SetValue("Nome", avm.Nome.Trim());
                dtm.Start();

                while (dtm.dr.Read())
                {
                    ResultSetAnagraficaViewModel rsvm = new ResultSetAnagraficaViewModel();
                    rsvm.IDAnagrafica = DbServiceMySql.DB2I(dtm.dr["IDAnagrafica"]);
                    rsvm.CodiceFiscale = dtm.dr["CodiceFiscale"].ToString();
                    rsvm.Nominativo = dtm.dr["Nominativo"].ToString();
                    rsvm.ResidenzaCAP = dtm.dr["CAPComune"].ToString();
                    rsvm.ResidenzaComune = (!DbServiceMySql.IsNull(dtm.dr["comunedescri"])) ? dtm.dr["comunedescri"].ToString() + (!DbServiceMySql.IsNull(dtm.dr["localita"]) ? " - " + dtm.dr["localita"].ToString() + "" : "") + "(" + dtm.dr["SiglaProvincia"] + ")" : string.Empty;
                    rsvm.ResidenzaVia = dtm.dr["Indirizzo"].ToString();
                    ResultSet.Add(rsvm);

                }

            }
            return ResultSet;
        }


        public ObservableCollection<ResultSetAnagraficaViewModel> QueryAnagraficaByCode(string CF)
        {
            string sql = "select IDAnagrafica,CodiceFiscale,concat(Cognome,' ',Nome) as Nominativo,Indirizzo, comuneresidenza.CAP as CAPComune, comuneresidenza.comune as comunedescri,localita,SiglaProvincia from anagrafica left join comuneresidenza on anagrafica.IDComuneResidenza = comuneresidenza.IDComuneResidenza  where CodiceFiscale='" + CF + "'";
            ObservableCollection<ResultSetAnagraficaViewModel> ResultSet = new ObservableCollection<ResultSetAnagraficaViewModel>();
            using (QueryReader dtm = DBService.GetReader(sql))
            {

                while (dtm.dr.Read())
                {
                    ResultSetAnagraficaViewModel rsvm = new ResultSetAnagraficaViewModel();
                    rsvm.IDAnagrafica = DbServiceMySql.DB2I(dtm.dr["IDAnagrafica"]);
                    rsvm.CodiceFiscale = dtm.dr["CodiceFiscale"].ToString();
                    rsvm.Nominativo = dtm.dr["Nominativo"].ToString();
                    rsvm.ResidenzaCAP = dtm.dr["CAPComune"].ToString();
                    rsvm.ResidenzaComune = (!DbServiceMySql.IsNull(dtm.dr["comunedescri"])) ? dtm.dr["comunedescri"].ToString() + (!DbServiceMySql.IsNull(dtm.dr["localita"]) ? " - " + dtm.dr["localita"].ToString() + "" : "") + "(" + dtm.dr["SiglaProvincia"] + ")" : string.Empty;
                    rsvm.ResidenzaVia = dtm.dr["Indirizzo"].ToString();
                    ResultSet.Add(rsvm);
                }
            }
            return ResultSet;
        }


        public ObservableCollection<ResultSetAnagraficaViewModel> QueryAnagraficaFromID(List<int> listid)
        {
            ObservableCollection<ResultSetAnagraficaViewModel> ResultSet = new ObservableCollection<ResultSetAnagraficaViewModel>();
            foreach (int id in listid)
            {
                string sql = "select IDAnagrafica,CodiceFiscale,concat(Cognome,' ',Nome) as Nominativo,Indirizzo, comuneresidenza.CAP as CAPComune, comuneresidenza.comune as comunedescri,localita,SiglaProvincia from anagrafica left join comuneresidenza on anagrafica.IDComuneResidenza = comuneresidenza.IDComuneResidenza  where IDAnagrafica=" + id.ToString();
                using (QueryReader dtm = DBService.GetReader(sql))
                {
                    dtm.dr.Read();
                    ResultSetAnagraficaViewModel rsvm = new ResultSetAnagraficaViewModel();
                    rsvm.IDAnagrafica = DbServiceMySql.DB2I(dtm.dr["IDAnagrafica"]);
                    rsvm.CodiceFiscale = dtm.dr["CodiceFiscale"].ToString();
                    rsvm.Nominativo = dtm.dr["Nominativo"].ToString();
                    rsvm.ResidenzaCAP = dtm.dr["CAPComune"].ToString();
                    rsvm.ResidenzaComune = (!DbServiceMySql.IsNull(dtm.dr["comunedescri"])) ? dtm.dr["comunedescri"].ToString() + (!DbServiceMySql.IsNull(dtm.dr["localita"]) ? " - " + dtm.dr["localita"].ToString() + "" : "") + "(" + dtm.dr["SiglaProvincia"] + ")" : string.Empty;
                    rsvm.ResidenzaVia = dtm.dr["Indirizzo"].ToString();
                    ResultSet.Add(rsvm);
                }
            }
            return ResultSet;
        }



        public List<TipoAttivitaViewModel> GetElencoTipoAttivita(bool bAll)
        {
            List<TipoAttivitaViewModel> lavm = new List<TipoAttivitaViewModel>();
            string sql = "select * from tipoattivita ";

            if (!bAll)
                sql = sql + " where Attivo=1";
            sql = sql + " order by Descrizione";
            using (QueryReader dtm = DBService.GetReader(sql))
            {
                while (dtm.dr.Read())
                    lavm.Add(m2vmTipoAttivitaViewModel(dtm.dr));
            }
            return lavm;
        }

        public List<string> GetElencoDateAttivita(int IDAnagraficaAttivita)
        {
            List<string> lista = new List<string>();
            using (QueryReader dtm = DBService.GetReader("SELECT date_format(DataInizio,'%d/%m/%Y') as data FROM anagraficaattivitadate where Attivo=1 and idAnagraficaAttivita ="+ IDAnagraficaAttivita.ToString()+" order by DataInizio"))
            {
                while (dtm.dr.Read())
                    lista.Add(dtm.dr["data"].ToString());
            }

            return lista;
        }


        public List<TipoAttivitaROViewModel> GetElencoTipoAttivitaRO(bool bAll)
        {
            List<TipoAttivitaROViewModel> lavm = new List<TipoAttivitaROViewModel>();
            string sql = "select * from tipoattivita ";

            if (!bAll)
                sql = sql + " where Attivo = 1";
            sql = sql + " order by Descrizione";
            using (QueryReader dtm = DBService.GetReader(sql))
            {
                while (dtm.dr.Read())
                    lavm.Add(m2vmTipoAttivitaROViewModel(dtm.dr));
            }
            return lavm;
        }


        private string[] DayNumToString = { "Domenica", "Lunedi", "Martedì", "Mercoledì", "Giovedì", "Venerdì", "Sabato" };

        private int PerceivedBrightness(Color c)
        {
            return (int)Math.Sqrt(
            c.R * c.R * .241 +
            c.G * c.G * .691 +
            c.B * c.B * .068);
        }

        public List<ROAttivitaViewModel> GetElencoCorsiAttivi(int IDTipoAttivita)
        {

            List<ROAttivitaViewModel> licvm = new List<ROAttivitaViewModel>();

            using (QueryReader dtm = DBService.GetReader("select attivita.* from attivita inner join corsi on attivita.idcorsi = corsi.idCorsi  where attivita.Attivo = 1 and corsi.Attivo = 1 and corsi.idTipoAttivita =" + IDTipoAttivita.ToString()))
            {
                while (dtm.dr.Read())
                    licvm.Add(m2vmROAttivitaViewModel(dtm.dr));
            }
            for (int i = 0; i < licvm.Count(); i++)
                licvm[i].NumeroIscritti = GetNumeroIscrizioni(licvm[i].ID);
            return licvm;
        }


        public void AddAttivita(int IDAnagrafica, int IDAttivita)
        {
            // Inserimento attivita
            int idAnagraficaAttivita = 0;
            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("insert into anagraficaattivita(idAnagrafica, idAttivita, DataInserimento, DataInizio, DataFine, TotaleLezioniEffettivo, TotaleDaPagare, Note)" +
                                  " select " + IDAnagrafica.ToString() + ",idAttivita,now(),DataInizio,DataFine,NumeroLezioni,CostoTotale,Note from attivita where idAttivita =" + IDAttivita.ToString()))
            {
                idAnagraficaAttivita = (int)dtm.InsertUpdateRecord();

            }
            // Inserimento attivita date

            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("insert into anagraficaattivitadate(idAnagraficaAttivita, DataInizio, DataFine, Attivo, Presente) " +
                                        "SELECT " + idAnagraficaAttivita.ToString() + ", Inizio, Fine, 1, 0 FROM attivitadate where idAttivita =" + IDAttivita.ToString()))
            {
                dtm.InsertUpdateRecord();
            }
        }

        public List<SingolaAnagraficaAttivitaViewModel> LoadAttivita(int IDAnagrafica)
        {
            List<SingolaAnagraficaAttivitaViewModel> lsa = new List<SingolaAnagraficaAttivitaViewModel>();
            using (QueryReader dtm = DBService.GetReader("SELECT idAnagraficaAttivita,anagraficaattivita.DataInizio as DataInizio,anagraficaattivita.DataFine as DataFine,attivita.idCorsi as idCorsi," +
                                     "Background,Foreground, TotaleLezioniEffettivo,NumeroLezioni,CostoLordoLezione,CostoIvaLezione,tipoattivita.Descrizione as Descrizione," +
                                     "TipoCorso,TotaleDaPagare,CodiceContabile,Segno,anagraficaattivita.note as Note FROM anagraficaattivita inner join attivita on anagraficaattivita.idAttivita = attivita.idAttivita " +
                                     "inner join corsi on attivita.idCorsi = corsi.idCorsi inner join tipoattivita on  corsi.idTipoAttivita = tipoattivita.idTipoAttivita inner join codicicontabili on tipoattivita.CodiceContabile = codicicontabili.Codice " +
                                     "where IDAnagrafica=" + IDAnagrafica.ToString() + " order by DataInserimento desc"))
            {

                while (dtm.dr.Read())
                {
                    SingolaAnagraficaAttivitaViewModel savm = new SingolaAnagraficaAttivitaViewModel(this);

                    savm.ID = DbServiceMySql.DB2I(dtm.dr["idAnagraficaAttivita"]);
                    if (!DbServiceMySql.IsNull(dtm.dr["DataInizio"]))
                        savm.DataInizio = DbServiceMySql.DB2DT(dtm.dr["DataInizio"]);
                    if (!DbServiceMySql.IsNull(dtm.dr["DataFine"]))
                        savm.DataFine = DbServiceMySql.DB2DT(dtm.dr["DataFine"]);

                    savm.BackColor = dtm.dr["Background"].ToString();
                    savm.NumeroIngressi = DbServiceMySql.DB2I(dtm.dr["TotaleLezioniEffettivo"]);
                    savm.IngressiPrevisti = DbServiceMySql.DB2I(dtm.dr["NumeroLezioni"]);
                    savm.CostoLordoLezione = DbServiceMySql.DB2D(dtm.dr["CostoLordoLezione"]);
                    savm.CostoIvaLezione = DbServiceMySql.DB2D(dtm.dr["CostoIvaLezione"]);
                    savm.ForegroundColor = dtm.dr["Foreground"].ToString();
                    savm.TitoloAttivita = dtm.dr["Descrizione"].ToString();
                    savm.TipoCorso = (CorsoViewModel.TipoCorsoValue)DbServiceMySql.DB2I(dtm.dr["TipoCorso"]);
                    savm.Importo = DbServiceMySql.DB2D(dtm.dr["TotaleDaPagare"]);
                    try
                    {
                        savm.TotalePagato = DbServiceMySql.DB2D(DBService.GetScalar("select sum(ImportoPagato+Sconto) from movimenti where idAnagraficaAttivita =" + savm.ID.ToString()));
                    }
                    catch
                    {
                        savm.TotalePagato = 0;
                    }
                    savm.CodiceContabile = dtm.dr["CodiceContabile"].ToString();
                    savm.Segno = (short)DbServiceMySql.DB2I16(dtm.dr["Segno"]);
                    savm.Note = dtm.dr["Note"].ToString();

                    savm.OrarioCorsi = new List<string>();

                    using (QueryReader dto = DBService.GetReader("select * from corsodettaglio where idCorsi =" + dtm.dr["idCorsi"].ToString()))
                    {
                        while (dto.dr.Read())
                        {
                            string OrarioCorso = DbServiceMySql.DB2TIME(dto.dr["OraInizio"]).ToString(@"hh\:mm") + "-" + DbServiceMySql.DB2TIME(dto.dr["OraFine"]).ToString(@"hh\:mm");
                            savm.OrarioCorsi.Add(DayNumToString[DbServiceMySql.DB2I(dto.dr["Giorno"])] + ":" + OrarioCorso);
                        }

                    }
                    using (QueryReader dta = DBService.GetReader("select * from anagraficaattivitadate where idAnagraficaAttivita =" + savm.ID.ToString()+" order by DataInizio"))
                    {
                        ObservableCollection<SingolaDataAttivitaViewModel> ls = new ObservableCollection<SingolaDataAttivitaViewModel>();
                        while (dta.dr.Read())
                            ls.Add(m2vmSingolaDataAttivitaViewModelFromAnagrafica(dta.dr));
                        savm.ElencoDateCorso = ls;
                    }
                    lsa.Add(savm);
                }
            }
            return lsa;
        }

        public List<SingoloMovimentoViewModel> LoadPagamenti(int IDAnagrafica)
        {

            List<SingoloMovimentoViewModel> lsp = new List<SingoloMovimentoViewModel>();

            using (QueryReader dtm = DBService.GetReader("select movimenti.*,concat(Cognome,' ',Nome) as Nominativo from movimenti left join anagrafica on movimenti.idAnagrafica = anagrafica.idanagrafica where anagrafica.idanagrafica =" + IDAnagrafica.ToString() + " order by Data desc"))
            {
                while (dtm.dr.Read())
                    lsp.Add(m2vmSingoloMovimentoViewModel(dtm.dr));
            }
            return lsp;
        }

        public void SaveAttivita(int ID, int NumeroIngressi, decimal Importo, string Note)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update anagraficaattivita set Note=@Note,TotaleDaPagare=@TotaleDaPagare,TotaleLezioniEffettivo=@TotaleLezioniEffettivo where idAnagraficaAttivita=" + ID.ToString()))
            {
                dtu.SetValue("Note", Note);
                dtu.SetValue("TotaleDaPagare", Importo); ;
                dtu.SetValue("TotaleLezioniEffettivo", NumeroIngressi);
                dtu.InsertUpdateRecord();
            }
        }

        public void DeleteAttivita(int ID)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from anagraficaattivita where idAnagraficaAttivita=" + ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
        }


        public int SavePagamento(SingoloMovimentoViewModel spvm, SingoloUtenteViewModel suvm, bool bAutoTrasferito)
        {

            string sql = string.Empty;
            if (spvm.ID == 0)
            {
                if (bAutoTrasferito)
                    sql = "insert into movimenti(Data,Totale,ImportoPagato,Sconto,CCDare,CCAvere,Descrizione,ModalitaPagamento,User,idAnagraficaAttivita,idAnagrafica,StampaRicevuta,RichiestaFattura,idTrasferimento) values(@Data,@Totale,@ImportoPagato,@Sconto,@CCDare,@CCAvere,@Descrizione,@ModalitaPagamento,@User,@idAnagraficaAttivita,@idAnagrafica,'N',@RichiestaFattura,0)";
                else
                    sql = "insert into movimenti(Data,Totale,ImportoPagato,Sconto,CCDare,CCAvere,Descrizione,ModalitaPagamento,User,idAnagraficaAttivita,idAnagrafica,StampaRicevuta,RichiestaFattura) values(@Data,@Totale,@ImportoPagato,@Sconto,@CCDare,@CCAvere,@Descrizione,@ModalitaPagamento,@User,@idAnagraficaAttivita,@idAnagrafica,'N',@RichiestaFattura)";
            } else
            {
                if (bAutoTrasferito)
                    sql = "update movimenti set Data=@Data,Totale=@Totale,ImportoPagato=@ImportoPagato,Sconto=@Sconto,CCDare=@CCDare,CCAvere=@CCAvere,Descrizione=@Descrizione,ModalitaPagamento=@ModalitaPagamento,User=@User,idAnagraficaAttivita=@idAnagraficaAttivita,idAnagrafica=@idAnagrafica,RichiestaFattura=@RichiestaFattura,idTrasferimento=0  where idMovimenti=" + spvm.ID.ToString();
                else
                    sql = "update movimenti set Data=@Data,Totale=@Totale,ImportoPagato=@ImportoPagato,Sconto=@Sconto,CCDare=@CCDare,CCAvere=@CCAvere,Descrizione=@Descrizione,ModalitaPagamento=@ModalitaPagamento,User=@User,idAnagraficaAttivita=@idAnagraficaAttivita,idAnagrafica=@idAnagrafica,RichiestaFattura=@RichiestaFattura  where idMovimenti=" + spvm.ID.ToString();
            }

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {
                dtu.SetValue("Data", spvm.DataPagamento);
                dtu.SetValue("Totale", spvm.ImportoPagare);
                dtu.SetValue("ImportoPagato", spvm.ImportoPagato);
                dtu.SetValue("Sconto", spvm.Sconto);
                dtu.SetValue("CCDare", suvm.CodiceContabileCassa);
                dtu.SetValue("CCAvere", spvm.CCAvere);
                dtu.SetValue("Descrizione", spvm.Descrizione);
                dtu.SetValue("ModalitaPagamento", spvm.ModalitaPagamento.Key.ToString());
                dtu.SetValue("User", suvm.user);
                dtu.SetValue("idAnagraficaAttivita", spvm.IDAnagraficaAttivita);
                dtu.SetValue("idAnagrafica", spvm.IDAnagrafica);
                dtu.SetValue("RichiestaFattura", spvm.IsRichiestaFattura);

                if (spvm.ID == 0)
                    spvm.ID = (int)dtu.InsertUpdateRecord();
                else
                    dtu.InsertUpdateRecord();
            }
            using (DBInsertUpdate dtd = DBService.GetDBInsertUpdate("delete from movimentidettagli where idMovimenti="+spvm.ID.ToString()))
            {
                    dtd.InsertUpdateRecord();
            }
            if (spvm.DettagliMovimento != null)
            {

                using (DBInsertUpdate dti = DBService.GetDBInsertUpdate("insert into movimentidettagli(idMovimenti,Codice,ImportoUnitario,Quantita) values(@idMovimenti,@Codice,@ImportoUnitario,@Quantita)"))
                {

                    foreach (ScontrinoViewModel s in spvm.DettagliMovimento)
                    {
                        dti.SetValue("idMovimenti", spvm.ID);
                        dti.SetValue("Codice", s.Codice);
                        dti.SetValue("ImportoUnitario", s.ImportoUnitario);
                        dti.SetValue("Quantita", s.Quantita);
                        dti.InsertUpdateRecord();
                    }
                }



            }
            return spvm.ID;
        }


        public void RemoveMovimento(SingoloMovimentoViewModel smvm)
        {
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from movimentidettagli where idMovimenti=" + smvm.ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from movimenti where idMovimenti=" + smvm.ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
        }

        public void UpdateMovimento(SingoloMovimentoViewModel smvm)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update movimenti set ModalitaPagamento=@ModalitaPagamento,ImportoPagato=@ImportoPagato,Sconto=Totale-ImportoPagato where idMovimenti=" + smvm.ID.ToString()))
            {
                dtu.SetValue("ModalitaPagamento", smvm.ModalitaPagamento.Key.ToString());
                dtu.SetValue("ImportoPagato", smvm.ImportoPagato); ;
                dtu.InsertUpdateRecord();
            }
        }


        public List<ScontrinoViewModel> GetScontrinoFromMovimento(int IDMovimento)
        {

            List<ScontrinoViewModel> lista = new List<ScontrinoViewModel>();

            using (QueryReader dtm = DBService.GetReader("select * from movimentidettagli where idMovimenti = " + IDMovimento.ToString()))
            {
                while (dtm.dr.Read())
                    lista.Add(m2vmScontrinoViewModel(dtm.dr));
            }
            return lista;

        }



        public bool GetUser(SingoloUtenteViewModel suvm)
        {

            using (QueryReader dtm = DBService.GetReader("select * from utenti where user ='" + suvm.user + "'"))
            {
                if (dtm.dr.Read())
                {

                    suvm.IsLogin = true;
                    suvm.IsAttivaAccoglienza = DbServiceMySql.DB2B(dtm.dr["Accoglienza"]);
                    suvm.IsAttivaConfigurazione = DbServiceMySql.DB2B(dtm.dr["Configurazione"]);
                    suvm.IsAttivaContabilita = DbServiceMySql.DB2B(dtm.dr["Contabilita"]);
                    suvm.IsAttivaProgettazioneCorsi = DbServiceMySql.DB2B(dtm.dr["ProgettazioneCorsi"]);
                    if (!DbServiceMySql.IsNull(dtm.dr["Note"]))
                        suvm.Note = dtm.dr["Note"].ToString(); ;
                    suvm.CodiceContabileCassa = dtm.dr["Cassa"].ToString();
                    return true;
                }
                else
                    return false;
            }
        }

        public bool CheckForUserAuthorize(SingoloUtenteViewModel suvm)
        {
            string pwd = SingoloUtenteViewModel.MD5Hash(suvm.password);
            int iret = DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from utenti where BINARY User ='" + suvm.user + "' and password='" + pwd + "'"));
            return ( iret != 0);
        }

        public bool IsMovimentoFiscaleFromCodiceContabile(string codicecontabile)
        {
            using (QueryReader dtm = DBService.GetReader("select Fiscale from codicicontabili where Codice ='" + codicecontabile + "'"))
            {
                if (dtm.dr.Read())
                    return DbServiceMySql.DB2B(dtm.dr["Fiscale"]);
                else
                    return false;
            }
        }

        public string GetComuneFromID(int ID)
        {
            using (QueryReader dtm = DBService.GetReader("select concat(Comune,'(',SiglaProvincia,')') as descrizione  from comuneresidenza where IDComuneResidenza =" + ID.ToString()))
            {

                dtm.dr.Read();
                return dtm.dr["descrizione"].ToString();
            }
        }

        public CassaViewModel GetStatoCassa(CassaViewModel cvm)
        {
            SingoloUtenteViewModel UtenteCorrente = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>();

            using (QueryReader dtm = DBService.GetReader("select *  from registrocassa where DataChiusura is null and  User ='" + UtenteCorrente.user + "'"))
            {

                if (dtm.dr.Read())
                {
                    // La cassa risulta aperta
                    cvm.DataApertura = DbServiceMySql.DB2DT(dtm.dr["DataApertura"]);
                    cvm.ValoreApertura = DbServiceMySql.DB2D(dtm.dr["ValoreApertura"]);
                    cvm.ValoreAperturaReale = DbServiceMySql.DB2D(dtm.dr["ValoreAperturaReale"]);
                    cvm.NoteApertura = dtm.dr["NoteApertura"].ToString();
                    cvm.CodiceCassa = dtm.dr["Cassa"].ToString();
                    cvm.User = dtm.dr["User"].ToString();
                    cvm.ID = DbServiceMySql.DB2I(dtm.dr["idRegistroCassa"]);
                    cvm.ValoreChiusura = cvm.ValoreAperturaReale + GetTotaleMovimentiNonTraferiti(UtenteCorrente.user, "C", cvm.DataApertura);
                    // Calcolo movimentazioni successive
                    cvm.Stato = CassaViewModel.StatoCassa.Aperta;
                    cvm.CodiceCassa = UtenteCorrente.CodiceContabileCassa;
                    cvm.User = UtenteCorrente.user;
                }
                else
                {
                    cvm.Stato = CassaViewModel.StatoCassa.Chiusa;
                    cvm.DataApertura = DateTime.Now;
                    cvm.ValoreApertura = 0;
                    cvm.ValoreAperturaReale = 0;
                    cvm.ValoreChiusura = 0;
                    cvm.ValoreChiusuraReale = 0;
                    cvm.CodiceCassa = UtenteCorrente.CodiceContabileCassa;
                    cvm.User = UtenteCorrente.user;

                }
            }
            return cvm;
        }

        decimal GetTotaleMovimentiNonTraferiti(string user, string modalitapagamento, DateTime datainizio)
        {
            string dinizio = datainizio.ToString("yyyyMMddHHmmss");
            using (QueryReader dtm = DBService.GetReader("select sum(convert(if(segno=0,-1,1),decimal)*importopagato) as Totale from movimenti inner join codicicontabili on movimenti.CCAvere = codicicontabili.Codice where User = '" + user + "' and date_format(Data,'%Y%m%d%H%i%s') > '" + dinizio + "'  and ModalitaPagamento = '" + modalitapagamento + "' and idTrasferimento is null"))
            {
                dtm.dr.Read();
                return DbServiceMySql.DB2D(dtm.dr["Totale"]);
            }
        }



        public List<SingoloMovimentoViewModel> GetElencoMovimenti(DateTime data)
        {
            List<SingoloMovimentoViewModel> lm = new List<SingoloMovimentoViewModel>();
            string dinizio = data.ToString("yyyyMMdd");
            using (QueryReader dtm = DBService.GetReader("select movimenti.*,concat(Cognome,' ',Nome) as Nominativo from movimenti left join anagrafica on movimenti.idAnagrafica = anagrafica.idanagrafica where date_format(Data,'%Y%m%d') = '" + dinizio + "' order by Data desc"))
            {
                while (dtm.dr.Read())
                    lm.Add(m2vmSingoloMovimentoViewModel(dtm.dr));

            }
            return lm;
        }

        public List<SingoloMovimentoViewModel> GetElencoMovimentiCassa(CassaViewModel cvm)
        {
            List<SingoloMovimentoViewModel> lsm = new List<SingoloMovimentoViewModel>();

            string dapertura = cvm.DataApertura.ToString("yyyyMMddHHmmss");
            using (QueryReader dtm = DBService.GetReader("select movimenti.*,concat(Cognome,' ',Nome) as Nominativo from movimenti left join anagrafica on movimenti.idAnagrafica = anagrafica.idanagrafica where user = '" + cvm.User + "' " +
                                     "and  idTrasferimento is null and data >= '" + dapertura + "' order by data desc"))
            {
                while (dtm.dr.Read())
                    if (cvm.DataChiusura == null || DbServiceMySql.DB2DT(dtm.dr["Data"]) <= cvm.DataChiusura)
                        lsm.Add(m2vmSingoloMovimentoViewModel(dtm.dr));

            }
            return lsm;
        }

        public void ConvalidaCassa(CassaViewModel cvm)
        {
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update registrocassa set DataValidazione = now() where idRegistroCassa =" + cvm.ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
            foreach (SingoloMovimentoViewModel sm in GetElencoMovimentiCassa(cvm))
            {
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update movimenti set idTrasferimento = 0 where idMovimenti =" + sm.ID.ToString()))
                {
                    dtu.InsertUpdateRecord();
                }
            }
        }

        public void ApriCassa(CassaViewModel cvm)
        {


            DateTime DataOggi = DateTime.Now;
            // Verifico se c'è cassa aperta
            using (QueryReader dtm = DBService.GetReader("SELECT * FROM registrocassa where user ='" + cvm.User + "' and DataChiusura is null"))
            {
                bool bCassaAperta = dtm.dr.Read();
                if (bCassaAperta)
                {
                    MessageBox.Show("ERRORE SULLE CASSE - LA CASSA RISULTA APERTA E NON CHIUSA");
                    return;
                }
                SingoloUtenteViewModel UtenteCorrente = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>();

                DataOggi = DateTime.Now;
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into registrocassa(User,Cassa,DataApertura,ValoreApertura,ValoreAperturaReale,NoteApertura) values(@User,@Cassa,@DataApertura,@ValoreApertura,@ValoreAperturaReale,@NoteApertura)"))
                {
                    dtu.SetValue("User", UtenteCorrente.user);
                    dtu.SetValue("Cassa", UtenteCorrente.CodiceContabileCassa);
                    dtu.SetValue("DataApertura", DataOggi);
                    dtu.SetValue("ValoreApertura", cvm.ValoreApertura);
                    dtu.SetValue("ValoreAperturaReale", cvm.ValoreAperturaReale);
                    dtu.SetValue("NoteApertura", cvm.NoteApertura);
                    cvm.Stato = CassaViewModel.StatoCassa.Aperta;
                    dtu.InsertUpdateRecord();
                }
                cvm.ValoreChiusura = cvm.ValoreAperturaReale;
            }
        }

        public void SalvaChiusuraCassa(CassaViewModel cvm)
        {
            DateTime DataOggi = DateTime.Now;
            SingoloUtenteViewModel UtenteCorrente = SimpleIoc.Default.GetInstance<SingoloUtenteViewModel>();
            // Verifico se c'è cassa aperta
            if (DbServiceMySql.DB2I(DBService.GetScalar("SELECT count(*) FROM registrocassa where user = '" + cvm.User + "' and DataChiusura is null")) == 1)
            {
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update registrocassa set ValoreChiusura=@ValoreChiusura,ValoreChiusuraReale=@ValoreChiusuraReale,NotaChiusura=@NotaChiusura,DataChiusura=now()  where user = '" + cvm.User + "' and DataChiusura is null"))
                {
                    dtu.SetValue("ValoreChiusura", cvm.ValoreChiusura);
                    dtu.SetValue("ValoreChiusuraReale", cvm.ValoreChiusuraReale);
                    dtu.SetValue("NotaChiusura", cvm.NoteChiusura);
                    dtu.InsertUpdateRecord();
                }
            }
        }

        public List<CorsoViewModel> GetMatriceCorsi(List<TipoAttivitaViewModel> listaattivita, bool bAll)
        {
            List<CorsoViewModel> lcvm = new List<CorsoViewModel>();
            foreach (TipoAttivitaViewModel tavm in listaattivita)
            {
                string sql;
                if (bAll)
                    sql = "select * from corsi where idTipoAttivita =" + tavm.ID.ToString();
                else
                    sql = "select * from corsi where Attivo=1 and  idTipoAttivita =" + tavm.ID.ToString();

                using (QueryReader dtc = DBService.GetReader(sql))
                {

                    while (dtc.dr.Read())
                    {
                        CorsoViewModel cvm = new CorsoViewModel();
                        cvm.ID = DbServiceMySql.DB2I(dtc.dr["idCorsi"]);
                        cvm.TipoAttivita = tavm;
                        cvm.Note = dtc.dr["Note"].ToString();
                        cvm.Titolo = dtc.dr["NomeCorso"].ToString();
                        cvm.TipoCorso = (CorsoViewModel.TipoCorsoValue)DbServiceMySql.DB2I(dtc.dr["TipoCorso"]);
                        cvm.IsAttivo = DbServiceMySql.DB2B(dtc.dr["Attivo"]);

                        using (QueryReader dtd = DBService.GetReader("select * from corsodettaglio where idCorsi=" + cvm.ID.ToString()))
                        {
                            while (dtd.dr.Read())
                            {
                                OrarioCorsoViewModel ocvm = new OrarioCorsoViewModel();
                                ocvm.ID = DbServiceMySql.DB2I(dtd.dr["idCorsoDettaglioOrari"]);
                                ocvm.OraInizio = DbServiceMySql.DB2TIME(dtd.dr["OraInizio"]);
                                ocvm.OraFine = DbServiceMySql.DB2TIME(dtd.dr["OraFine"]);
                                ocvm.GiornoSettimana = (DayOfWeek)DbServiceMySql.DB2I(dtd.dr["Giorno"]);
                                cvm.ProgrammazioneSettimanale.Add(ocvm);
                            }
                        }
                        string sqlr;
                        if (bAll)
                            sqlr = "select * from attivita where idCorsi=" + cvm.ID.ToString();
                        else
                            sqlr = "select * from attivita where Attivo=1 and  idCorsi=" + cvm.ID.ToString();

                        using (QueryReader dta = DBService.GetReader(sqlr))
                        {
                            cvm.ElencoAttivita = new List<SingolaAttivitaViewModel>();
                            while (dta.dr.Read())
                                cvm.ElencoAttivita.Add(m2vmSingolaAttivitaViewModel(dta.dr));

                        }
                        lcvm.Add(cvm);
                    }
                }
            }
            return lcvm;
        }
        public bool StatoAttivazioneCorso(int ID, bool newState)
        {
            
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update corsi set Attivo="+(newState?"1":"0")+" where idCorsi="+ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
            return newState;
        }

        private int GetNextAttivita(string sCodiceFiscale, string sAttivita)
        {
            int ia = (int)DbServiceMySql.DB2I(DBService.GetScalar("select max(attivita.idAttivita) from corsi inner join tipoattivita on tipoattivita.idTipoAttivita = corsi.idTipoAttivita inner join attivita on attivita.idCorsi = corsi.idCorsi inner join anagraficaattivita on anagraficaattivita.idattivita = attivita.idAttivita  inner join anagrafica  on anagrafica.idanagrafica = anagraficaattivita.idanagrafica" +
                                                   " where CodiceFiscale = '" + sCodiceFiscale + "' and tipoattivita.Descrizione = '" + sAttivita + "'"));
            using (QueryReader dta = DBService.GetReader("select idAttivita from attivita where idCorsi = (select idCorsi from attivita where idattivita = " + ia.ToString() + ") and idAttivita >" + ia.ToString() + " order by  idAttivita asc"))
            {

                if (dta.dr.Read())
                    return DbServiceMySql.DB2I(dta.dr["idAttivita"]);
                else
                    return -1;
            }
        }
        public bool CheckForRinnovo(string sCodiceFiscale, string sAttivita)
        {
            return GetNextAttivita(sCodiceFiscale, sAttivita) != -1;
        }

        public bool  RinnovoAttivita(string sCodiceFiscale,string sAttivita)
        {
            int ia = GetNextAttivita(sCodiceFiscale, sAttivita);
            int idAnagrafica = (int)DbServiceMySql.DB2I(DBService.GetScalar("select max(idAnagrafica) from anagrafica where CodiceFiscale='"+ sCodiceFiscale + "'"));
            if (ia != -1)
            {
                // Inserisco attivita
                int idAnagraficaAttivita = 0;
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into anagraficaattivita(idAnagrafica,idAttivita,DataInserimento,DataInizio,DataFine,TotaleLezioniEffettivo,TotaleDaPagare,Note) " +
                                            "  select " + idAnagrafica.ToString() + ",idAttivita,now(),DataInizio,DataFine,NumeroLezioni,CostoTotale,Note from attivita   " +
                                            "where idAttivita = " + ia.ToString())) 
                {
                    idAnagraficaAttivita = (int)dtu.InsertUpdateRecord();
                }
                // Inserisco le date

                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into anagraficaattivitadate(idAnagraficaAttivita, DataInizio, DataFine, Attivo, Presente, DataManuale) "+
                                            " select "+ idAnagraficaAttivita.ToString() + ", Inizio, Fine, 1, 0, 0 from attivitadate where idAttivita = "+ia.ToString()))
                {
                    dtu.InsertUpdateRecord();
                }
                return true;
            }
            else
                return false;
        }

        #region Accoglienza
        public bool StatoAttivazioneDataAnagraficaAttivita(int ID,  bool newState)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update anagraficaattivitadate set Attivo=" + (newState ? "1" : "0") + " where idAnagraficaAttivitaDate=" + ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
            int IDAnagraficaAttivita = DbServiceMySql.DB2I(DBService.GetScalar("select IDAnagraficaAttivita from anagraficaattivitadate where idAnagraficaAttivitaDate=" + ID.ToString()));
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update anagraficaattivita set TotaleLezioniEffettivo = (select count(*) from anagraficaattivitadate where idAnagraficaAttivita = " + IDAnagraficaAttivita.ToString() + " and Attivo=1) where idAnagraficaAttivita =" + IDAnagraficaAttivita.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
            return newState;
        }
        #endregion
        #region Contabilita

        public SingoloCodiceContabileViewModel GetCodiceContabileFromCodice(string sCodice)
        {
            using (QueryReader dtm = DBService.GetReader("select * from codicicontabili where Codice='"+sCodice+"'"))
            {

                if (dtm.dr.Read())
                    return m2vmSingoloCodiceContabileViewModel(dtm.dr);
                else
                    return null;
            }
        }
        public List<SingoloCodiceContabileViewModel> GetElencoCodiciContabili(bool bAll, bool? bExtra)
        {
            string sql;
            if (bAll)
            {
                if (bExtra == null)
                    sql = "select * from codicicontabili";
                else
                    sql = (bool)bExtra?"select * from codicicontabili where ExtraAttivita=true": "select * from codicicontabili where ExtraAttivita=false";
            }
            else
            {
                if (bExtra != null)
                    sql = (bool)bExtra?"select * from codicicontabili where Attivo=1 && ExtraAttivita=true": "select * from codicicontabili where Attivo=1 && ExtraAttivita=false";
                else
                    sql = "select * from codicicontabili where Attivo=1";
            }
            List<SingoloCodiceContabileViewModel> lscc = new List<SingoloCodiceContabileViewModel>();

            using (QueryReader dtm = DBService.GetReader(sql+" order by Descrizione"))
            {
                while (dtm.dr.Read())
                    lscc.Add(m2vmSingoloCodiceContabileViewModel(dtm.dr));
            }
            return lscc;
        }

        public List<SingoloDettaglioCodiceContabileViewModel> GetDettagliCodiceContabile(string Codice)
        {

            List<SingoloDettaglioCodiceContabileViewModel> lista = new List<SingoloDettaglioCodiceContabileViewModel>();

            using (QueryReader dtm = DBService.GetReader("select * from codicicontabilidettagli where CodiceContabile='"+Codice+"'"))
            {
                while (dtm.dr.Read())
                    lista.Add(m2vmSingoloDettaglioCodiceContabileViewModel(dtm.dr));
            }
            return lista;

        }


        public void AddDettaglioCodiceContabile(SingoloCodiceContabileViewModel CodiceContabile, SingoloDettaglioCodiceContabileViewModel cd)
        {

            // Controllo se esiste già codice
            if (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from codicicontabilidettagli where CodiceContabile='"+CodiceContabile.Codice+"' and Descrizione='"+cd.Descrizione+"'")) != 0)
            {
                // Aggiornamento
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update codicicontabilidettagli set Importo=@Importo where CodiceContabile='" + CodiceContabile.Codice + "' and Descrizione='" + cd.Descrizione + "'"))
                {
                    dtu.SetValue("Importo", cd.ImportoPredefinito);
                    dtu.InsertUpdateRecord();
                }

            }
            else
            {
                // Inserimento
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into codicicontabilidettagli(CodiceContabile,Descrizione,Importo) values(@CodiceContabile,@Descrizione,@Importo)"))
                {
                    dtu.SetValue("Importo", cd.ImportoPredefinito);
                    dtu.SetValue("CodiceContabile", CodiceContabile.Codice);
                    dtu.SetValue("Descrizione", cd.Descrizione);
                    dtu.InsertUpdateRecord();
                }

            }
        }

        public bool CheckForDettagliMovimento(string sCodice)
        {
            return DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from codicicontabilidettagli where CodiceContabile='" + sCodice + "'")) != 0;
        }
        public void RemoveDettaglioCodiceContabile(SingoloDettaglioCodiceContabileViewModel dettaglio)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  codicicontabilidettagli where idCodiciContabiliDettagli = "+dettaglio.ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
        }

        public List<ModalitaPagamentoViewModel> GetElencoModalitaPagamento(bool bAll)
        {
            List<ModalitaPagamentoViewModel> lmp = new List<ModalitaPagamentoViewModel>();
            string sql;
            if (bAll)
                sql = "select * from modalitapagamento";
            else
                sql = "select * from modalitapagamento where Attivo=1";
            using (QueryReader dtm = DBService.GetReader(sql))
            {
                while (dtm.dr.Read())
                    lmp.Add(m2mvModalitaPagamentoViewModel(dtm.dr));
            }
            return lmp;
        }


        public bool IsModalitaPagamento(string codice)
        {
            return (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from modalitapagamento where KeyModalita ='"+codice+"'")) > 0);
        }

        public bool UpdateModalitaPagamento(ModalitaPagamentoViewModel mpvm)
        {
            string sql;

            if (IsModalitaPagamento(mpvm.Key))
                sql = "update modalitapagamento set Attivo=@Attivo,Descrizione=@Descrizione where KeyModalita='" + mpvm.Key + "'";
            else
                sql = "insert into modalitapagamento(KeyModalita,Attivo,Descrizione) values('"+mpvm.Key+"',@Attivo,@Descrizione)";
            

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {
                dtu.SetValue("Attivo", mpvm.IsAttivo);
                dtu.SetValue("Descrizione", mpvm.Descrizione);
                dtu.InsertUpdateRecord();
            }
            return true;
        }

        ModalitaPagamentoViewModel GetModalitaPagamento(string codice)
        {
            using (QueryReader dtm = DBService.GetReader("select * from modalitapagamento where KeyModalita='" + codice + "'"))
            {
                if (dtm.dr.Read())
                    return m2mvModalitaPagamentoViewModel(dtm.dr);
                else
                    return null;

            }
        }

        public void DeleteModalitaPagamento(ModalitaPagamentoViewModel mpvm)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  modalitapagamento where KeyModalita='"+ mpvm.Key + "'"))
            {
                dtu.InsertUpdateRecord();
            }
        }

        public bool IsCodiceContabile(string codice)
        {
            return (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from codicicontabili where Codice ='" + codice + "'")) > 0);
        }

        public bool UpdateCodiceContabile(SingoloCodiceContabileViewModel mpvm)
        {


            string sql;

            if (IsCodiceContabile(mpvm.Codice))
                sql = "update codicicontabili set Attivo=@Attivo,Descrizione=@Descrizione,ExtraAttivita=@ExtraAttivita,Fiscale=@Fiscale,Segno=@Segno,Indice=@Indice,ImportoPredefinito=@ImportoPredefinito where Codice='" + mpvm.Codice + "'";
            else
                sql = "insert into codicicontabili(Codice,Attivo,Descrizione,ExtraAttivita,Fiscale,Segno,Indice,ImportoPredefinito) values('" + mpvm.Codice + "',@Attivo,@Descrizione,@ExtraAttivita,@Fiscale,@Segno,@Indice,@ImportoPredefinito)";


            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {

                dtu.SetValue("Attivo",mpvm.IsAttivo);
                dtu.SetValue("Descrizione", mpvm.Descrizione);
                dtu.SetValue("ExtraAttivita", mpvm.IsAttivitaExtra);
                dtu.SetValue("Fiscale", mpvm.IsFiscale);
                dtu.SetValue("Segno", mpvm.bSegno);
                dtu.SetValue("Indice",mpvm.Indice);
                dtu.SetValue("ImportoPredefinito",mpvm.ImportoPredefinito);
                dtu.InsertUpdateRecord();
            }
            return true;
        }

        public void DeleteCodiceContabile(SingoloCodiceContabileViewModel mpvm)
        {
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  codicicontabili where Codice='" + mpvm.Codice + "'"))
            {
                dtu.InsertUpdateRecord();
            }
        }

        public List<SingoloCodiceContabileViewModel> GetElencoAltriMovimenti()
        {
            List<SingoloCodiceContabileViewModel> lscvm = new List<SingoloCodiceContabileViewModel>();

            using (QueryReader dtm = DBService.GetReader("select * from codicicontabili where ExtraAttivita=1 and Attivo=1"))
            {
                while (dtm.dr.Read())
                    lscvm.Add(m2vmSingoloCodiceContabileViewModel(dtm.dr));
            }
            return lscvm;
        }

        public List<CassaViewModel> GetElencoCasseNonValidate()
        {

            List<CassaViewModel> lcvm = new List<CassaViewModel>();
            using (QueryReader dtm = DBService.GetReader("select * from registrocassa where DataValidazione is null and DataChiusura is not null"))
            {
                while (dtm.dr.Read())
                    lcvm.Add(m2mvCassaViewModel(dtm.dr));
            }
            return lcvm;
        }

        public List<SingolaFatturaViewModel> GetElencoRichiestaFatture()
        {
            List<SingolaFatturaViewModel> lsfvm = new List<SingolaFatturaViewModel>();
            using (QueryReader dtm = DBService.GetReader("SELECT  movimenti.*,concat(Cognome,' ',Nome) as Nominativo from movimenti        left join anagrafica on movimenti.idAnagrafica = anagrafica.idanagrafica  where RichiestaFattura=1 and  (select count(*) from fatture where fatture.idMovimento = movimenti.idMovimenti) = 0"))
            {
                while (dtm.dr.Read())
                {
                    SingolaFatturaViewModel sfvm = new SingolaFatturaViewModel();

                    sfvm.Anagrafica = GetAnagrafica(DbServiceMySql.DB2I(dtm.dr["idAnagrafica"]));
                    sfvm.Movimento = m2vmSingoloMovimentoViewModel(dtm.dr); 
                    lsfvm.Add(sfvm);
                }
            }
            return lsfvm;
         }

        SingolaAnagraficaViewModel GetAnagrafica(int ID)
        {
            using (QueryReader dtm = DBService.GetReader("SELECT * FROM anagrafica where idAnagrafica="+ID.ToString()))
            {
                if (dtm.dr.Read())
                    return m2vmSingolaAnagraficaViewModel(dtm.dr);
                else
                    return null;
            }
        }


        public ModalitaPagamentoViewModel GetModalitaPagamentoFromID(string Key)
        {
            using (QueryReader dtm = DBService.GetReader("SELECT * FROM modalitapagamento where KeyModalita=" +Key))
            {
                if (dtm.dr.Read())
                    return m2mvModalitaPagamentoViewModel(dtm.dr);
                else
                    return null;
            }
        }

        public void RegistraFattura(SingolaFatturaViewModel sfvm)
        {
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into fatture(idMovimento,DataFattura,NumeroFattura) values(@idMovimento,@DataFattura,@NumeroFattura)"))
            {
                dtu.SetValue("idMovimento",sfvm.Movimento.ID);
                dtu.SetValue("DataFattura",new DateTime(sfvm.DataFattura.Year, sfvm.DataFattura.Month, sfvm.DataFattura.Day, 0, 0, 0, 0));
                dtu.SetValue("NumeroFattura",sfvm.NumeroFattura);
                dtu.InsertUpdateRecord();
            }
        }


        public List<SingoloTrasferimentoViewModel> GetElencoTrasferimenti()
        {
            List<SingoloTrasferimentoViewModel> let = new List<SingoloTrasferimentoViewModel>();


            using (QueryReader dtm = DBService.GetReader("select date(Data) as DT,ModalitaPagamento,CCAvere,sum(ImportoPagato) as Totale from movimenti where idTrasferimento = 0 "+
                               "group by DT, ModalitaPagamento, CCAvere")) 
            {
                while (dtm.dr.Read())
                {
                    SingoloTrasferimentoViewModel stvm = new SingoloTrasferimentoViewModel();
                    stvm.DataMovimenti = DbServiceMySql.DB2DT(dtm.dr["DT"]);
                    stvm.ModalitaPagamento = GetModalitaPagamento(dtm.dr["ModalitaPagamento"].ToString());
                    stvm.CausaleMovimento = GetCodiceContabileFromCodice(dtm.dr["CCAvere"].ToString());
                    stvm.Totale = DbServiceMySql.DB2D(dtm.dr["Totale"]);
                    stvm.Trasferito = stvm.Totale;
                    let.Add(stvm);
                }
            }
 
            return let;
        }
        
        public void TraferisciContabilita(ElementoMatriceTrasferimentoViewModel estvm)
        {
            foreach (SingoloTrasferimentoViewModel stvm in estvm.Elementi)
            {
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into trasferimentomovimenti(DataTraferimento,DataMovimenti,ModalitaPagamento,CCMovimento,Totale,Trasferito,Nota) values(now(),@DataMovimenti,@ModalitaPagamento,@CCMovimento,@Totale,@Trasferito,@Nota)"))
                {

                    dtu.SetValue("DataMovimenti", stvm.DataMovimenti);
                    dtu.SetValue("ModalitaPagamento", stvm.ModalitaPagamento.Key);
                    dtu.SetValue("CCMovimento", stvm.CausaleMovimento.Codice);
                    dtu.SetValue("Totale", stvm.Totale);
                    dtu.SetValue("Trasferito", stvm.Trasferito);
                    dtu.SetValue("Nota", stvm.Nota);
                    int idTrasferimentoMovimenti = (int)dtu.InsertUpdateRecord();
                    using (DBInsertUpdate dtum = DBService.GetDBInsertUpdate("update movimenti set idTrasferimento="+ idTrasferimentoMovimenti.ToString() + " where idTrasferimento = 0 and date_format(Data,'%Y%m%d') =  '"+ stvm.DataMovimenti.ToString("yyyyMMdd") + "' and ModalitaPagamento = '"+ stvm.ModalitaPagamento.Key + "' and CCAvere = '"+ stvm.CausaleMovimento.Codice + "'"))
                    {
                        dtum.InsertUpdateRecord();
                    }
                }
            }
        } 

        public List<SingoloMovimentoViewModel> GetElencoAltriPagamenti(DateTime Data)
        {
            List<SingoloMovimentoViewModel> lsm = new List<SingoloMovimentoViewModel>();
            using (QueryReader dtm = DBService.GetReader("select  movimenti.*,'' as Nominativo from movimenti  where idAnagrafica is null and date_format(Data,'%Y%m%d') =  '" + Data.ToString("yyyyMMdd")+ "' and idTrasferimento=0"))
            
            {
                while (dtm.dr.Read())
                    lsm.Add(m2vmSingoloMovimentoViewModel(dtm.dr));
            }
            return lsm;
        }

        public void DeleteMovimento(SingoloMovimentoViewModel smvm)
        { 
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  movimenti where idMovimenti=" + smvm.ID))
            {
                dtu.InsertUpdateRecord();
            }
        }

        #endregion

        #region TabelleAnagrafica

        public List<SingoloLuogoNascitaViewModel> GetTabellaLuoghiNascita(string txtFiltro)
        {
            List<SingoloLuogoNascitaViewModel> lnp = new List<SingoloLuogoNascitaViewModel>();
            txtFiltro = txtFiltro.Trim();

            string lnquery;
            if (txtFiltro.Length > 0)
                lnquery = "select * from luoghinascita where Descrizione like '%"+txtFiltro+"%'";
            else
                lnquery = "select * from luoghinascita";

            using (QueryReader dtm = DBService.GetReader(lnquery))
            {
                while (dtm.dr.Read())
                    lnp.Add(m2vmSingoloLuogoNascitaViewModel(dtm.dr));
            }
            return lnp;
        }

        public bool UpdateLuogoNascita(SingoloLuogoNascitaViewModel mpvm)
        {

            string sql;
            if (mpvm.ID > 0)
                sql = "update luoghinascita set Descrizione=@Descrizione,DescrizioneAggiuntiva=@DescrizioneAggiuntiva,CodiceISTAT=@CodiceISTAT,Estero=@Estero where IDLuoghiNascita=" + mpvm.ID.ToString();
            else
                sql = "insert into luoghinascita(Descrizione,DescrizioneAggiuntiva,CodiceISTAT,Estero) values(@Descrizione,@DescrizioneAggiuntiva,@CodiceISTAT,@Estero)";

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {
                dtu.SetValue("Descrizione", mpvm.Descrizione);
                dtu.SetValue("DescrizioneAggiuntiva", mpvm.DescrizioneAggiuntiva);
                dtu.SetValue("Estero", mpvm.IsEstero);
                dtu.SetValue("CodiceISTAT", mpvm.CodiceISTAT);
                if (mpvm.ID <= 0)
                    mpvm.ID = (int)dtu.InsertUpdateRecord();
                else
                    dtu.InsertUpdateRecord();
            }
            return true;
        }

        public void DeleteLuogoNascita(SingoloLuogoNascitaViewModel mpvm)
        {
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  luoghinascita where IDLuoghiNascita=" + mpvm.ID))
            {
                dtu.InsertUpdateRecord();
            }
        }


        public List<SingoloComuneResidenzaViewModel> GetTabellaComuniResidenza(string txtFiltro)
        {
            List<SingoloComuneResidenzaViewModel> lnp = new List<SingoloComuneResidenzaViewModel>();
            txtFiltro = txtFiltro.Trim();

            string lnquery;
            if (txtFiltro.Length > 0)
                lnquery = "select * from comuneresidenza where Comune like'%"+txtFiltro+"%' order by Comune";
            else
                lnquery = "select * from comuneresidenza order by Comune";

            using (QueryReader dtm = DBService.GetReader(lnquery))
            {
                while (dtm.dr.Read())
                    lnp.Add(m2vmSingoloComuneResidenzaViewModel(dtm.dr));
            }

            return lnp;
        }

        public bool UpdateComuneResidenza(SingoloComuneResidenzaViewModel mpvm)
        {


            string sql;
            if (mpvm.ID > 0)
                sql = "update comuneresidenza set Comune=@Comune,CAP=@CAP,SiglaProvincia=@SiglaProvincia where IDComuneResidenza=" + mpvm.ID.ToString();
            else
                sql = "insert into comuneresidenza(Comune,CAP,SiglaProvincia) values(@Comune,@CAP,@SiglaProvincia)";

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {
                dtu.SetValue("Comune", mpvm.Descrizione);
                dtu.SetValue("CAP", mpvm.CAP);
                dtu.SetValue("SiglaProvincia", mpvm.SiglaProvincia);
                if (mpvm.ID <= 0)
                    mpvm.ID = (int)dtu.InsertUpdateRecord();
                else
                    dtu.InsertUpdateRecord();
            }
            return true;
        }

        public void DeleteComuneResidenza(SingoloComuneResidenzaViewModel mpvm)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  comuneresidenza where IDComuneResidenza=" + mpvm.ID))
            {
                dtu.InsertUpdateRecord();
            }
        }

        #endregion

        #region utenti


        public bool IsUser(string user)
        {
            return DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from utenti where user='"+user+"'"))!=0;
        }

        public List<SingoloUtenteViewModel> GetTabellaUtenti(bool bShowAll)
        {
            List<SingoloUtenteViewModel> lnp = new List<SingoloUtenteViewModel>();


            string lnquery;
            if (bShowAll)
                lnquery = "select * from utenti order by user";
            else
                lnquery = "select * from utenti where Attivo=1 order by user";

            using (QueryReader dtm = DBService.GetReader(lnquery))
            {
                while (dtm.dr.Read())
                    lnp.Add(m2vmSingoloUtenteViewModel(dtm.dr));
            }
           return lnp;
        }

        public bool UpdateUtente(SingoloUtenteViewModel mpvm)
        {

            string sql;
            if (IsUser(mpvm.user))
                sql = "update utenti set Cassa=@Cassa,Attivo=@Attivo,Accoglienza=@Accoglienza,Configurazione=@Configurazione,Contabilita=@Contabilita,ProgettazioneCorsi=@ProgettazioneCorsi,Note=@Note where user='" + mpvm.user+"'";
            else
                sql = "insert into utenti(user,Cassa,Attivo,Accoglienza,Configurazione,Contabilita,ProgettazioneCorsi,Note) values(" + mpvm.user+ ",@Cassa,@Attivo,@Accoglienza,@Configurazione,@Contabilita,@ProgettazioneCorsi,@Note)";

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {
                dtu.SetValue("Cassa", mpvm.CodiceContabileCassa);
                dtu.SetValue("Attivo", mpvm.IsAttivo);
                dtu.SetValue("Accoglienza", mpvm.IsAttivaAccoglienza);
                dtu.SetValue("Configurazione", mpvm.IsAttivaConfigurazione);
                dtu.SetValue("Contabilita", mpvm.IsAttivaContabilita);
                dtu.SetValue("ProgettazioneCorsi", mpvm.IsAttivaProgettazioneCorsi);
                dtu.SetValue("Note", mpvm.Note);
                dtu.InsertUpdateRecord();
            }
            return true;
        }

        public void DeleteUtente(SingoloUtenteViewModel mpvm)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  utenti where user='" + mpvm.user+"'"))
            {
                dtu.InsertUpdateRecord();
            }
        }

        public void UpdateUtentePassword(SingoloUtenteViewModel suvm, string pwd)
        {
            using(DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update  utenti set Password=@pwd where user='" + suvm.user + "'"))
            {
                dtu.SetValue("pwd", pwd);
                dtu.InsertUpdateRecord();
            }
        }
        #endregion
        #region  Attivita

        public bool IsTipoAttivita(string descrizione)
        {
            return DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from tipoattivita where Descrizione='"+descrizione+"'")) != 0;
        }


        public bool UpdateTipoAttivita(TipoAttivitaViewModel mpvm)
        {

            string sql;
            if (mpvm.ID > 0)
                sql = "update tipoattivita set  Background=@Background,Foreground=@Foreground,CodiceContabile=@CodiceContabile,Descrizione=@Descrizione,Attivo=@Attivo,Durata=@Durata,GruppiXLivello=@GruppiXLivello,ProgrammazioneFine=@ProgrammazioneFine,ProgrammazioneInizio=@ProgrammazioneInizio,Passo=@Passo where idTipoAttivita=" + mpvm.ID.ToString();
            else
                sql = "insert into tipoattivita(Background,Foreground,CodiceContabile,Descrizione,Attivo,Durata,GruppiXLivello,ProgrammazioneFine,ProgrammazioneInizio,Passo) values(@Background,@Foreground,@CodiceContabile,@Descrizione,@Attivo,@Durata,@GruppiXLivello,@ProgrammazioneFine,@ProgrammazioneInizio,@Passo)";

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {
                dtu.SetValue("Background", mpvm.BackgroundColor);
                dtu.SetValue("Foreground", mpvm.ForegroundColor);
                dtu.SetValue("CodiceContabile", mpvm.CodiceContabileCassa);
                dtu.SetValue("Descrizione", mpvm.Titolo);
                dtu.SetValue("Attivo", mpvm.IsAttivo);
                dtu.SetValue("Durata", mpvm.Durata);
                dtu.SetValue("GruppiXLivello", mpvm.GruppiXLivello);
                dtu.SetValue("ProgrammazioneFine", mpvm.ProgrammazioneFine);
                dtu.SetValue("ProgrammazioneInizio", mpvm.ProgrammazioneInizio);
                dtu.SetValue("Passo", mpvm.StepPianificazione);
                dtu.InsertUpdateRecord();
            }
            return true;
        }

        public void DeleteTipoAttivita(TipoAttivitaViewModel mpvm)
        {
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  tipoattivita where idtipoattivita=" + mpvm.ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
        }

        public bool IsTipoAttivitaErasable(int idTA)
        {
            return DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from corsi where idTipoAttivita ="+idTA.ToString())) == 0;

        }

        public string GetNoteCorsoFromIDAnagraficaAttivita(int IDAA)
        {
            using (QueryReader dtm = DBService.GetReader("select attivita.Note as Note from anagraficaattivita inner join attivita on anagraficaattivita.idAttivita = attivita.idAttivita where idAnagraficaAttivita = "+ IDAA.ToString()))
            {
                if (dtm.dr.Read())
                    return dtm.dr["Note"].ToString();
                return string.Empty;
            }
        }
        public ObservableCollection<SingolaDataAttivitaViewModel> AddSingoloIngresso(int IDAnagraficaAttivita, DateTime DataInizio, DateTime DataFine,bool bIsAbbonamento)
        {
            ObservableCollection<SingolaDataAttivitaViewModel> ElencoDateCorso = new ObservableCollection<SingolaDataAttivitaViewModel>();

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into anagraficaattivitadate(idAnagraficaAttivita,Attivo,DataManuale,DataFine,DataInizio,Presente) values(@idAnagraficaAttivita,1,1,@DataFine,@DataInizio,@Presente)"))
            {

                dtu.SetValue("idAnagraficaAttivita", IDAnagraficaAttivita);
                dtu.SetValue("DataFine", DataFine);
                dtu.SetValue("DataInizio", DataInizio);
                dtu.SetValue("Presente", bIsAbbonamento);
                dtu.InsertUpdateRecord();
            }
            if (!bIsAbbonamento)
            {
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update anagraficaattivita set TotaleLezioniEffettivo=TotaleLezioniEffettivo+1 where idAnagraficaAttivita=" + IDAnagraficaAttivita.ToString()))
                {
                    dtu.InsertUpdateRecord();
                }
            }
            using (QueryReader dtm = DBService.GetReader("select * from anagraficaattivitadate where idAnagraficaAttivita="+ IDAnagraficaAttivita.ToString()+" order by DataInizio"))
            {
                while (dtm.dr.Read())
                    ElencoDateCorso.Add(m2vmSingolaDataAttivitaViewModelFromAnagrafica(dtm.dr));
            }
            return ElencoDateCorso;
        }

        public int GetNumeroIscrizioni(int idAttivita)
        {
            return DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from anagraficaattivita where idAttivita="+idAttivita.ToString()));

        }

        public List<AnagraficaROViewModel> GetElencoIscritti(int idAttivita)
        {
            List<AnagraficaROViewModel> lista = new List<AnagraficaROViewModel>();
            
            using (QueryReader dtm = DBService.GetReader("select   (movimenti.Totale-movimenti.Sconto-movimenti.ImportoPagato) as T,anagrafica.* from anagraficaattivita  inner join  anagrafica  on anagraficaattivita.idAnagrafica=anagrafica.IDAnagrafica left join movimenti on anagraficaattivita.idAnagraficaAttivita = movimenti.idAnagraficaAttivita    where idAttivita=" + idAttivita.ToString()))
            {
                while (dtm.dr.Read())
                {
                    AnagraficaROViewModel ar = m2vmAnagraficaROViewModel(dtm.dr);
                    ar.IsPagamentiEffettuati = !DbServiceMySql.IsNull(dtm.dr["T"]) && DbServiceMySql.DB2D(dtm.dr["T"]) <= 0;
                    lista.Add(ar);
                }
            }
            return lista;
        }

        //private TipoAttivitaROViewModel TipoAttivita2ROViewModel(tipoattivita ta)
        //{
        //    TipoAttivitaROViewModel tavm = new TipoAttivitaROViewModel();
        //    tavm.BackgroundColor = ta.Background;
        //    tavm.CodiceContabileCassa = ta.CodiceContabile;
        //    tavm.Durata = ta.Durata;
        //    tavm.ForegroundColor = ta.Foreground;
        //    tavm.GruppiXLivello = ta.GruppiXLivello;
        //    tavm.ID = ta.idTipoAttivita;
        //    tavm.IsAttivo = ta.Attivo;
        //    tavm.ProgrammazioneFine = ta.ProgrammazioneFine;
        //    tavm.ProgrammazioneInizio = ta.ProgrammazioneInizio;
        //    tavm.Titolo = ta.Descrizione;
        //    return tavm;
        //}

        public List<TipoAttivitaROViewModel> GetElencoTipiAttivitaForAnagrafica(int IDAnagrafica)
        {

            List<TipoAttivitaROViewModel> lista = new List<TipoAttivitaROViewModel>();

            using (QueryReader dtm = DBService.GetReader("SELECT distinct tipoattivita.* FROM anagraficaattivita inner join attivita on anagraficaattivita.idAttivita = attivita.idAttivita "+
                                     "inner join corsi on attivita.idCorsi = corsi.idCorsi inner join tipoattivita on corsi.idTipoAttivita = tipoattivita.idTipoAttivita  where anagraficaattivita.DataFine >= now() and idAnagrafica ="+IDAnagrafica.ToString()))
            {
                while (dtm.dr.Read())
                    lista.Add(m2vmTipoAttivitaROViewModel(dtm.dr));
            }
            return lista;
        }



        #endregion

        #region CORSI
        public void UpdateCorso(CorsoEditViewModel cevm)
        {

            string sql;
            if (cevm.ID > 0)
                sql = "update corsi set NomeCorso=@NomeCorso,Note=@Note,TipoCorso=@TipoCorso where idCorsi=" + cevm.ID.ToString();
            else
                sql = "insert into corsi(idTipoAttivita,Attivo,NomeCorso,Note,TipoCorso) values(" + cevm.TipoAttivita.ID + ",1,@NomeCorso,@Note,@TipoCorso)";

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate(sql))
            {
                dtu.SetValue("NomeCorso", cevm.Titolo);
                dtu.SetValue("Note", cevm.Note);
                dtu.SetValue("TipoCorso", (short)cevm.TipoCorso);
                if (cevm.ID <= 0)
                    cevm.ID = (int)dtu.InsertUpdateRecord();
                else
                    dtu.InsertUpdateRecord();
            }
            // Elimino dettagli esistenti e sostituisco con i nuovi
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from corsodettaglio where idCorsi="+cevm.ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
        
            foreach (OrarioCorsoViewModel oc in cevm.EditElencoOrari.ToList())
            {
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into corsodettaglio(idCorsi,OraInizio,OraFine,Giorno) values(@idCorsi,@OraInizio,@OraFine,@Giorno)"))
                {
                    dtu.SetValue("idCorsi", cevm.ID);
                    dtu.SetValue("OraInizio", oc.OraInizio);
                    dtu.SetValue("OraFine", oc.OraFine);
                    dtu.SetValue("Giorno", (int)oc.GiornoSettimana);
                    dtu.InsertUpdateRecord();
                }
            }
        }


        public CorsoEditViewModel GetCorso(int ID)
        {
            CorsoEditViewModel CorsoEdit = new CorsoEditViewModel();

            using (QueryReader dtm = DBService.GetReader("select * from corsi inner join tipoattivita on corsi.idTipoAttivita = tipoattivita.idTipoAttivita where idCorsi=" + ID.ToString()))
            {
                if (dtm.dr.Read())
                {
                    CorsoEdit.ID = DbServiceMySql.DB2I(dtm.dr["idCorsi"]);
                    CorsoEdit.DurataPianificazione = DbServiceMySql.DB2TIME(dtm.dr["Durata"]);
                    CorsoEdit.StepPianificazione = DbServiceMySql.DB2TIME(dtm.dr["Passo"]);
                    CorsoEdit.ProgrammazioneInizio = DbServiceMySql.DB2TIME(dtm.dr["ProgrammazioneInizio"]);
                    CorsoEdit.ProgrammazioneFine = DbServiceMySql.DB2TIME(dtm.dr["ProgrammazioneFine"]);
                    CorsoEdit.TipoAttivita = m2vmTipoAttivitaViewModel(dtm.dr);
                    CorsoEdit.Titolo = dtm.dr["NomeCorso"].ToString();
                    CorsoEdit.TipoCorso = (CorsoViewModel.TipoCorsoValue)DbServiceMySql.DB2I(dtm.dr["TipoCorso"]);
                    CorsoEdit.Note = dtm.dr["Note"].ToString();
                    


                }
            }
            // Lettura dettagli
            CorsoEdit.EditElencoOrari = new ObservableCollection<OrarioCorsoViewModel>();
            using (QueryReader dtm = DBService.GetReader("select * from corsodettaglio where idCorsi=" + ID.ToString()))
            {
                
                while (dtm.dr.Read())
                {
                    OrarioCorsoViewModel oc = new OrarioCorsoViewModel();
                    oc.ID = DbServiceMySql.DB2I(dtm.dr["idCorsoDettaglioOrari"]);
                    oc.OraInizio = DbServiceMySql.DB2TIME(dtm.dr["OraInizio"]);
                    oc.OraFine = DbServiceMySql.DB2TIME(dtm.dr["OraFine"]);
                    oc.GiornoSettimana = (DayOfWeek)DbServiceMySql.DB2I(dtm.dr["Giorno"]);
                    CorsoEdit.EditElencoOrari.Add(oc);
                }
            }

            CorsoEdit.HaveAttivitaCollegate = DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from attivita where idCorsi ="+ ID.ToString())) != 0;
            CorsoEdit.CanDelete = !CorsoEdit.HaveAttivitaCollegate && CorsoEdit.EditElencoOrari.Count() == 0;
            return CorsoEdit;
        }

        public void RemoveCorso(CorsoEditViewModel cevm)
        {
            if (cevm.CanDelete)
            {
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from  corsi where idCorsi=" + cevm.ID.ToString()))
                {
                    dtu.InsertUpdateRecord();
                }
            }
        }
        #endregion

        #region Programmazione/Attivita
        public void SaveProgrammazione(SingolaAttivitaViewModel savm)
        {

            savm.IsAttivo = true;
            if (savm.ID > 0)
            {
                // Devo fare un update dell'attività
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update attivita set  Attivo=1,DataFine=@DataFine,DataInizio=@DataInizio,Titolo=@Titolo,Note=@Note,NumeroLezioni=@NumeroLezioni,CostoIvaLezione=@CostoIvaLezione,CostoLordoLezione=@CostoLordoLezione,CostoTotale=@CostoTotale where idAttivita=" + savm.ID.ToString()))
                {
                    dtu.SetValue("DataFine", savm.DataFine);
                    dtu.SetValue("DataInizio", savm.DataInizio);
                    dtu.SetValue("Titolo", savm.Titolo);
                    dtu.SetValue("Note", savm.Note);
                    dtu.SetValue("NumeroLezioni", savm.NumeroLezioni);
                    dtu.SetValue("CostoIvaLezione", savm.CostoIvaLezione);
                    dtu.SetValue("CostoLordoLezione", savm.CostoLordoLezione);
                    dtu.SetValue("CostoTotale", savm.ImportoCorso);
                    dtu.InsertUpdateRecord();
                }
            }
            else
            {
                 
                using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into attivita(idCorsi,Attivo,DataFine,DataInizio,Titolo,Note,NumeroLezioni,CostoIvaLezione,CostoLordoLezione,CostoTotale) values(@idCorsi,1,@DataFine,@DataInizio,@Titolo,@Note,@NumeroLezioni,@CostoIvaLezione,@CostoLordoLezione,@CostoTotale)"))
                {
                    dtu.SetValue("idCorsi", savm.IDCorso);
                    dtu.SetValue("DataFine", savm.DataFine);
                    dtu.SetValue("DataInizio", savm.DataInizio);
                    dtu.SetValue("Titolo", savm.Titolo);
                    dtu.SetValue("Note", savm.Note);
                    dtu.SetValue("NumeroLezioni", savm.NumeroLezioni);
                    dtu.SetValue("CostoIvaLezione", savm.CostoIvaLezione);
                    dtu.SetValue("CostoLordoLezione", savm.CostoLordoLezione);
                    dtu.SetValue("CostoTotale", savm.ImportoCorso);
                    savm.ID = (int)dtu.InsertUpdateRecord();
                }
            }

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update corsi set Attivo=1 where idCorsi = "+savm.IDCorso.ToString()))
            {
                dtu.InsertUpdateRecord();
            }


            if (savm.ElencoDateCorso != null)
            {

                // Controllo le date da cancellare
                using (QueryReader dtm = DBService.GetReader("select idAttivitaDate from attivitadate where idAttivita=" + savm.ID.ToString()))
                {
                    while(dtm.dr.Read())
                        if (savm.ElencoDateCorso.Count(p => p.ID == DbServiceMySql.DB2I(dtm.dr["idAttivitaDate"])) == 0)
                        {
                            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from attivitadate where idAttivitaDate = " + dtm.dr["idAttivitaDate"].ToString()))
                            {
                                dtu.InsertUpdateRecord();
                            }
                        }

                }

                // Controllo le date da aggiungere
                foreach (SingolaDataAttivitaViewModel dt in savm.ElencoDateCorso)
                {
                    if (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from attivitadate where idAttivitaDate=" + dt.ID.ToString()))==0)
                    {

                        using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("insert into attivitadate(idAttivita,Inizio,Fine) values(@idAttivita,@Inizio,@Fine)"))
                        {
                            dtu.SetValue("idAttivita", savm.ID);
                            dtu.SetValue("Inizio", dt.Inizio);
                            dtu.SetValue("Fine", dt.Fine);
                            dtu.InsertUpdateRecord();
                        }
                    }
                }
            }
        }

        public List<SingolaAttivitaViewModel> GetElencoAttivitaProgrammate(int ID, bool bAll)
        {
            List<SingolaAttivitaViewModel> lsa = new List<SingolaAttivitaViewModel>();
            string sql;

            if (bAll)
                sql = "select * from attivita where idCorsi="+ID.ToString();
            else
                sql = "select * from attivita where Attivo=1 and idCorsi=" + ID.ToString();

            using (QueryReader dtm = DBService.GetReader(sql))
            {
                while (dtm.dr.Read())
                    lsa.Add(m2vmSingolaAttivitaViewModel(dtm.dr));
            }
            return lsa;
        }

        public bool StatoAttivazioneProgrammazione(int ID, bool newState)
        {
            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("update attivita set Attivo=@Attivo where idAttivita = " + ID.ToString()))
            {
                dtu.SetValue("Attivo", newState);
                dtu.InsertUpdateRecord();
            }
            return newState;
        }
        public void RemoveProgrammazione(SingolaAttivitaViewModel savm)
        {

            using (DBInsertUpdate dtu = DBService.GetDBInsertUpdate("delete from attivita  where idAttivita = " + savm.ID.ToString()))
            {
                dtu.InsertUpdateRecord();
            }
        }
        #endregion

        #region Configurazione

        public bool CheckForCodiceISTAT(string stringValue)
        {

            return DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from luoghinascita where CodiceISTAT='"+ stringValue + "'")) > 0;

        }

        public ROCorsoViewModel GetROCorso(int ID)
        {
            using (QueryReader dtm = DBService.GetReader("select * from corsi where idCorsi="+ID.ToString()))
            {
                if (dtm.dr.Read())
                    return m2vmROCorsoViewModel(dtm.dr);
                else
                    return null;
            }
        }


        #endregion

        #region Riepiloghi
        public List<RiepilogoAttivitaViewModel> GetRiepilogoAttivita(List<int> ListIDTipoAttivita)
        {
            List<RiepilogoAttivitaViewModel> lista = new List<RiepilogoAttivitaViewModel>();
            if (ListIDTipoAttivita == null || ListIDTipoAttivita.Count() == 0) return lista;

            foreach (int id in ListIDTipoAttivita)
            {
                using (QueryReader dtm = DBService.GetReader("select * from  attivita inner join corsi on attivita.idCorsi = corsi.idCorsi inner join tipoattivita on corsi.idTipoAttivita = tipoattivita.idTipoAttivita where attivita.Attivo=1  and tipoattivita.idTipoAttivita=" + id.ToString()))
                {
                    while (dtm.dr.Read())
                    {
                        RiepilogoAttivitaViewModel ravm = new RiepilogoAttivitaViewModel();
                        ravm.ID = DbServiceMySql.DB2I(dtm.dr["idAttivita"]);
                        ravm.IDTipoAttivita = DbServiceMySql.DB2I(dtm.dr["idTipoAttivita"]);
                        ravm.ForeColorAttivita = dtm.dr["Foreground"].ToString();
                        ravm.BackColorAttivita = dtm.dr["Background"].ToString();
                        ravm.Titolo = dtm.dr["Titolo"].ToString();
                        ravm.DataInizio = DbServiceMySql.DB2DT(dtm.dr["DataInizio"]);
                        ravm.NumeroIscritti = GetNumeroIscrizioni(ravm.ID);
                        lista.Add(ravm);
                    }
                }
            }
            return lista.OrderBy(p=>p.DataInizio).ToList();
        }
        #endregion


        #region DBToVIEWMODEL
        TipoAttivitaViewModel m2vmTipoAttivitaViewModel(MySqlDataReader dr)
        {
            TipoAttivitaViewModel avm = new TipoAttivitaViewModel();
            avm.ID = DbServiceMySql.DB2I(dr["idTipoAttivita"]);
            avm.Titolo = dr["Descrizione"].ToString();
            avm.BackgroundColor = dr["Background"].ToString();
            avm.ForegroundColor = dr["Foreground"].ToString();
            avm.CodiceContabileCassa = dr["CodiceContabile"].ToString();
            avm.GruppiXLivello = DbServiceMySql.DB2B(dr["GruppiXLivello"]);
            avm.ProgrammazioneFine = DbServiceMySql.DB2TIME(dr["ProgrammazioneFine"]);
            avm.ProgrammazioneInizio = DbServiceMySql.DB2TIME(dr["ProgrammazioneInizio"]);
            avm.Durata = DbServiceMySql.DB2TIME(dr["Durata"]);
            avm.StepPianificazione = (DbServiceMySql.DB2TIME(dr["Passo"]) < new TimeSpan(0, 5, 0)) ? new TimeSpan(0, 5, 0) : DbServiceMySql.DB2TIME(dr["Passo"]);
            avm.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            avm.CanSave = false;
            avm.IsErasabled = false;
            avm.IsEditable = true;
            avm.IsNew = false;
            return avm;
        }

        TipoAttivitaROViewModel m2vmTipoAttivitaROViewModel(MySqlDataReader dr)
        {
            TipoAttivitaROViewModel avm = new TipoAttivitaROViewModel();
            avm.ID = DbServiceMySql.DB2I(dr["idTipoAttivita"]);
            avm.Titolo = dr["Descrizione"].ToString();
            avm.BackgroundColor = dr["Background"].ToString();
            avm.ForegroundColor = dr["Foreground"].ToString();
            avm.CodiceContabileCassa = dr["CodiceContabile"].ToString();
            avm.GruppiXLivello = DbServiceMySql.DB2B(dr["GruppiXLivello"]);
            avm.ProgrammazioneFine = DbServiceMySql.DB2TIME(dr["ProgrammazioneFine"]);
            avm.ProgrammazioneInizio = DbServiceMySql.DB2TIME(dr["ProgrammazioneInizio"]);
            avm.Durata = DbServiceMySql.DB2TIME(dr["Durata"]);
            avm.StepPianificazione = (DbServiceMySql.DB2TIME(dr["Passo"]) < new TimeSpan(0, 5, 0)) ? new TimeSpan(0, 5, 0) : DbServiceMySql.DB2TIME(dr["Passo"]);
            avm.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            return avm;
        }

        ROAttivitaViewModel m2vmROAttivitaViewModel(MySqlDataReader dr)
        {
            ROAttivitaViewModel avm = new ROAttivitaViewModel();
            avm.ID = DbServiceMySql.DB2I(dr["idAttivita"]);
            avm.IDCorso = DbServiceMySql.DB2I(dr["idCorsi"]);
            avm.Titolo = dr["Titolo"].ToString();
            avm.DataInizio = DbServiceMySql.DB2DT(dr["DataInizio"]);
            avm.DataFine = DbServiceMySql.DB2DT(dr["DataFine"]);
            avm.NumeroLezioni = DbServiceMySql.DB2I(dr["NumeroLezioni"]);
            avm.Note = dr["Note"].ToString();
            avm.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            return avm;
        }

        SingoloMovimentoViewModel m2vmSingoloMovimentoViewModel(MySqlDataReader dr)
        {

            SingoloMovimentoViewModel spvm = new SingoloMovimentoViewModel();

            spvm.ID = DbServiceMySql.DB2I(dr["idMovimenti"]);
            spvm.IDAnagrafica = DbServiceMySql.DB2I(dr["idAnagrafica"]);
            spvm.IDAnagraficaAttivita = DbServiceMySql.DB2I(dr["idAnagraficaAttivita"]);
            spvm.IsMovimentoFiscale = IsMovimentoFiscaleFromCodiceContabile(dr["CCAvere"].ToString());
            spvm.Descrizione = dr["Descrizione"].ToString();
            spvm.DataPagamento = DbServiceMySql.DB2DT(dr["Data"]);
            spvm.IsRichiestaFattura = DbServiceMySql.DB2B(dr["RichiestaFattura"]);
            try
            {
                spvm.ImportoPagare = DbServiceMySql.DB2D(dr["Totale"]);
            }
            catch
            {
                spvm.ImportoPagare = 0;
            }
            spvm.ImportoPagato = DbServiceMySql.DB2D(dr["ImportoPagato"]);
            try
            {
                spvm.Sconto = DbServiceMySql.DB2D(dr["Sconto"]);
            }
            catch
            {
                spvm.Sconto = 0;
            }
            spvm.Nominativo = dr["Nominativo"].ToString();
            spvm.ModalitaPagamento = GetModalitaPagamento(dr["ModalitaPagamento"].ToString());
            spvm.IsRicevutaStampata = (dr["StampaRicevuta"].ToString().Length > 0 && dr["StampaRicevuta"].ToString().First<char>() == 'S');
            spvm.CCAvere = dr["CCAvere"].ToString();
            spvm.CCDare = dr["CCDare"].ToString();
            spvm.User = dr["User"].ToString();
            spvm.IsMovimentoTrasferito = !DbServiceMySql.IsNull(dr["idTrasferimento"]);
            spvm.CanDelete = true;
            return spvm;
        }


        SingolaAttivitaViewModel m2vmSingolaAttivitaViewModel(MySqlDataReader dr)
        {
            SingolaAttivitaViewModel savm = new SingolaAttivitaViewModel(this);
            savm.ID = DbServiceMySql.DB2I(dr["idAttivita"]);
            savm.Titolo = dr["Titolo"].ToString();
            savm.DataFine = DbServiceMySql.DB2DT(dr["DataFine"]);
            savm.DataInizio = DbServiceMySql.DB2DT(dr["DataInizio"]);
            savm.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            savm.NumeroLezioni = (short)DbServiceMySql.DB2I(dr["NumeroLezioni"]);
            savm.CostoIvaLezione = DbServiceMySql.DB2D(dr["CostoIvaLezione"]);
            savm.CostoLordoLezione = DbServiceMySql.DB2D(dr["CostoLordoLezione"]);
            savm.ImportoCorso = DbServiceMySql.DB2D(dr["CostoTotale"]);
            savm.Note = dr["Note"].ToString();
            savm.IDCorso = DbServiceMySql.DB2I(dr["idCorsi"]);

            
            using (QueryReader dtm = DBService.GetReader("SELECT * FROM attivitadate where idAttivita="+savm.ID.ToString()))
            {
                ObservableCollection<SingolaDataAttivitaViewModel> ls = new ObservableCollection<SingolaDataAttivitaViewModel>();
                while (dtm.dr.Read())
                    ls.Add(m2vmSingolaDataAttivitaViewModelFromAttivita(dtm.dr));
                if (ls.Count()>0)
                    savm.ElencoDateCorso = ls;
            }
            savm.CanDelete = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from anagraficaattivita where idAttivita ="+savm.ID.ToString()))==0);
            return savm;
        }

        SingoloCodiceContabileViewModel m2vmSingoloCodiceContabileViewModel(MySqlDataReader dr)
        {
            SingoloCodiceContabileViewModel scc = new SingoloCodiceContabileViewModel();
            scc.Codice = dr["Codice"].ToString();
            scc.Descrizione = dr["Descrizione"].ToString();
            scc.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            scc.Indice = dr["Indice"].ToString();
            scc.bSegno = DbServiceMySql.DB2B(dr["Segno"]);
            scc.IsAttivitaExtra = DbServiceMySql.DB2B(dr["ExtraAttivita"]);
            scc.IsNew = false;
            scc.IsFiscale = DbServiceMySql.DB2B(dr["Fiscale"]);
            scc.ImportoPredefinito = DbServiceMySql.DB2D(dr["ImportoPredefinito"]);
            scc.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from tipoattivita where CodiceContabile='"+scc.Codice+"'")) == 0);
            if (scc.IsErasabled)
                scc.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from utenti where cassa='" + scc.Codice + "'")) == 0);
            if (scc.IsErasabled)
                scc.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from registrocassa where Cassa='" + scc.Codice + "'")) == 0);
            if (scc.IsErasabled)
                scc.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from movimenti where CCDare='" + scc.Codice + "' or CCAvere='"+ scc.Codice + "'")) == 0);
            scc.CanSave = false;
            scc.IsEditable = scc.IsErasabled;
            return scc;
        }


        SingoloDettaglioCodiceContabileViewModel m2vmSingoloDettaglioCodiceContabileViewModel(MySqlDataReader dr)
        {
            SingoloDettaglioCodiceContabileViewModel scc = new SingoloDettaglioCodiceContabileViewModel();
            scc.ID = DbServiceMySql.DB2I(dr["idCodiciContabiliDettagli"]);
            scc.Descrizione = dr["Descrizione"].ToString();
            scc.ImportoPredefinito = DbServiceMySql.DB2D(dr["Importo"]);
            return scc;
        }


        ModalitaPagamentoViewModel m2mvModalitaPagamentoViewModel(MySqlDataReader dr)
        {


            ModalitaPagamentoViewModel mpvm = new ModalitaPagamentoViewModel();

            mpvm.Key = dr["KeyModalita"].ToString();
            mpvm.Descrizione = dr["Descrizione"].ToString();
            mpvm.IsNew = false;
            mpvm.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            mpvm.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from movimenti where ModalitaPagamento='"+ mpvm.Key + "'")) ==0);
            mpvm.CanSave = false;
            return mpvm;
        }

        CassaViewModel m2mvCassaViewModel(MySqlDataReader dr)
        {
            CassaViewModel cvm = new CassaViewModel();
            cvm.ID = DbServiceMySql.DB2I(dr["idRegistroCassa"]);
            cvm.NoteApertura = dr["NoteApertura"].ToString();
            cvm.NoteChiusura = dr["NotaChiusura"].ToString();
            cvm.ValoreApertura = DbServiceMySql.DB2D(dr["ValoreApertura"]);
            cvm.ValoreAperturaReale = DbServiceMySql.DB2D(dr["ValoreAperturaReale"]);
            cvm.ValoreChiusura = DbServiceMySql.DB2D(dr["ValoreChiusura"]);
            cvm.ValoreChiusuraReale = DbServiceMySql.DB2D(dr["ValoreChiusuraReale"]);
            cvm.User = dr["User"].ToString();
            cvm.CodiceCassa = dr["Cassa"].ToString();
            cvm.DataApertura = DbServiceMySql.DB2DT(dr["DataApertura"]);
            if (!DbServiceMySql.IsNull(dr["DataChiusura"]))
                cvm.DataChiusura = DbServiceMySql.DB2DT(dr["DataChiusura"]);
            return cvm;
        }

        ScontrinoViewModel m2vmScontrinoViewModel(MySqlDataReader dr)
        {

            ScontrinoViewModel svm = new ScontrinoViewModel();
            svm.Codice = dr["Codice"].ToString();
            svm.ImportoUnitario = DbServiceMySql.DB2D(dr["ImportoUnitario"]);
            svm.Quantita = DbServiceMySql.DB2I(dr["Quantita"]);
            return svm;

        }
        

        SingolaAnagraficaViewModel m2vmSingolaAnagraficaViewModel(MySqlDataReader dr)
        {
            SingolaAnagraficaViewModel savm = new SingolaAnagraficaViewModel();
            savm.Cognome = dr["Cognome"].ToString();
            savm.Nome = dr["Nome"].ToString();
            savm.CAP = dr["CAP"].ToString();
            savm.Cellulare = dr["Cellulare"].ToString();
            savm.CodiceFiscale = dr["CodiceFiscale"].ToString();
            savm.DataNascita = DbServiceMySql.DB2DT(dr["DataNascita"]);
            savm.Indirizzo = dr["Indirizzo"].ToString();
            savm.TipoFattura = (AnagraficaViewModel.TipoFatturazione)DbServiceMySql.DB2I(dr["Fattura"]);
            savm.FatturaPIVACF = dr["FatturaPIVACF"].ToString();
            savm.Localita = dr["Localita"].ToString();
            savm.IDComuneResidenza = (!DbServiceMySql.IsNull(dr["IDComuneResidenza"]) ? DbServiceMySql.DB2I(dr["IDComuneResidenza"]) : -1);
            savm.IDAnagrafica = DbServiceMySql.DB2I(dr["IDAnagrafica"]);
            savm.DenominazioneFattura = dr["DenominazioneFattura"].ToString();
            savm.FatturaCodiceUnivoco = dr["FatturaCodiceUnivoco"].ToString();
            savm.FatturaIndirizzo = dr["FatturaIndirizzo"].ToString();
            return savm;
        }


        SingoloLuogoNascitaViewModel m2vmSingoloLuogoNascitaViewModel(MySqlDataReader dr)
        {
           
            SingoloLuogoNascitaViewModel lns = new SingoloLuogoNascitaViewModel();
            lns.ID = DbServiceMySql.DB2I(dr["IDLuoghiNascita"]);
            lns.IsEstero = DbServiceMySql.DB2B(dr["Estero"]);
            lns.CodiceISTAT = dr["CodiceISTAT"].ToString();
            lns.Descrizione = dr["Descrizione"].ToString();
            lns.DescrizioneAggiuntiva = dr["DescrizioneAggiuntiva"].ToString();
            lns.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from Anagrafica where IDLuogoNascita=" + lns.ID.ToString())) == 0);
            lns.IsEditable = false;
            lns.IsNew = false;
            lns.CanSave = false;
            return lns;
        }

        SingoloComuneResidenzaViewModel m2vmSingoloComuneResidenzaViewModel(MySqlDataReader dr)
        {
            SingoloComuneResidenzaViewModel lns = new SingoloComuneResidenzaViewModel();

            lns.ID = DbServiceMySql.DB2I(dr["IDComuneResidenza"]);
            lns.Descrizione = dr["Comune"].ToString();
            lns.CAP = dr["CAP"].ToString();
            lns.SiglaProvincia = dr["SiglaProvincia"].ToString();
            lns.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("select count(*) from Anagrafica where IDComuneResidenza=" + lns.ID.ToString())) == 0);
            lns.IsEditable = false;
            lns.IsNew = false;
            lns.CanSave = false;
            return lns;
        }

        SingoloUtenteViewModel m2vmSingoloUtenteViewModel(MySqlDataReader dr)
        { 

            SingoloUtenteViewModel lns = new SingoloUtenteViewModel();
            lns.user = dr["User"].ToString();
            lns.Note = dr["Note"].ToString();
            lns.CodiceContabileCassa = dr["Cassa"].ToString();
            lns.IsAttivaAccoglienza = DbServiceMySql.DB2B(dr["Accoglienza"]);
            lns.IsAttivaConfigurazione = DbServiceMySql.DB2B(dr["Configurazione"]);
            lns.IsAttivaContabilita = DbServiceMySql.DB2B(dr["Contabilita"]);
            lns.IsAttivaProgettazioneCorsi = DbServiceMySql.DB2B(dr["ProgettazioneCorsi"]);
            lns.IsErasabled = (DbServiceMySql.DB2I(DBService.GetScalar("SELECT count(*) FROM  registrocassa where user = '"+lns.user+"'"))==0) && (DbServiceMySql.DB2I(DBService.GetScalar("SELECT count(*) FROM  movimenti where user = '" + lns.user + "'")) == 0);
            lns.IsEditable = false;
            lns.IsNew = false;
            lns.CanSave = false;
            return lns;
        }

        SingolaDataAttivitaViewModel m2vmSingolaDataAttivitaViewModelFromAttivita(MySqlDataReader dr)
        {
            SingolaDataAttivitaViewModel sdv = new SingolaDataAttivitaViewModel();
            sdv.Inizio = DbServiceMySql.DB2DT(dr["Inizio"]);
            sdv.Fine = DbServiceMySql.DB2DT(dr["Fine"]);
            sdv.ID = DbServiceMySql.DB2I(dr["idAttivitaDate"]);
            return sdv;
        }


        SingolaDataAttivitaViewModel m2vmSingolaDataAttivitaViewModelFromAnagrafica(MySqlDataReader dr)
        {
            SingolaDataAttivitaViewModel sdv = new SingolaDataAttivitaViewModel();
            sdv.Inizio = DbServiceMySql.DB2DT(dr["DataInizio"]);
            sdv.Fine = DbServiceMySql.DB2DT(dr["DataFine"]);
            sdv.ID = DbServiceMySql.DB2I(dr["idAnagraficaAttivitaDate"]);
            sdv.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            sdv.IsDataManuale = DbServiceMySql.DB2B(dr["DataManuale"]);
            sdv.IsPresente = DbServiceMySql.DB2I(dr["Presente"])>0;
            return sdv;
        }

        AnagraficaROViewModel m2vmAnagraficaROViewModel(MySqlDataReader dr)
    {
            AnagraficaROViewModel arovm = new AnagraficaROViewModel();
            arovm.IDAnagrafica = DbServiceMySql.DB2I(dr["IDAnagrafica"]);
            arovm.DataScadenzaCertificatoMedico = DbServiceMySql.DB2DTN(dr["CERTMED"]);
            arovm.ConsegnatoRegolamentoPrivacy = DbServiceMySql.DB2B(dr["REGPRY"]);
            arovm.LivelloNuoto = DbServiceMySql.DB2I(dr["LIVNUO"]);
            arovm.AssicuratoFinoA = DbServiceMySql.DB2DTN(dr["ASSNUO"]);
            arovm.Cellulare = dr["Cellulare"].ToString();
            arovm.Telefono = dr["Telefono"].ToString();
            arovm.CodiceFiscale = dr["CodiceFiscale"].ToString();
            arovm.Cognome = dr["Cognome"].ToString();
            arovm.Nome = dr["Nome"].ToString();
            arovm.DataNascita = DbServiceMySql.DB2DT(dr["DataNascita"]);
            return arovm;
    }

    ROCorsoViewModel m2vmROCorsoViewModel(MySqlDataReader dr)
    {
            ROCorsoViewModel cvm = new ROCorsoViewModel();
            cvm.ID = DbServiceMySql.DB2I(dr["idCorsi"]);
            cvm.IDTipoAttivita = DbServiceMySql.DB2I(dr["idTipoAttivita"]);
            cvm.TipoCorso = (CorsoViewModel.TipoCorsoValue)DbServiceMySql.DB2I(dr["TipoCorso"]);
            cvm.Note = dr["Note"].ToString();
            cvm.IsAttivo = DbServiceMySql.DB2B(dr["Attivo"]);
            List <OrarioCorsoViewModel> locvm = new List<OrarioCorsoViewModel>();
            using (QueryReader dtd = DBService.GetReader("select * from corsodettaglio where idCorsi=" + cvm.ID.ToString()))
            {
                while (dtd.dr.Read())
                {
                    OrarioCorsoViewModel ocvm = new OrarioCorsoViewModel();
                    ocvm.ID = DbServiceMySql.DB2I(dtd.dr["idCorsoDettaglioOrari"]);
                    ocvm.OraInizio = DbServiceMySql.DB2TIME(dtd.dr["OraInizio"]);
                    ocvm.OraFine = DbServiceMySql.DB2TIME(dtd.dr["OraFine"]);
                    ocvm.GiornoSettimana = (DayOfWeek)DbServiceMySql.DB2I(dtd.dr["Giorno"]);
                    locvm.Add(ocvm);
                }
            }
            cvm.DettaglioOrari = locvm;
            return cvm;

        }



        //public TipoAttivitaViewModel TipoAttivitaEntityToViewModel(tipoattivita ta)
        //{
        //        TipoAttivitaViewModel avm = new TipoAttivitaViewModel();

        //        avm.ID = ta.idTipoAttivita;
        //        avm.Titolo = ta.Descrizione;
        //        avm.BackgroundColor = ta.Background;
        //        avm.ForegroundColor = ta.Foreground;
        //        avm.CodiceContabileCassa = ta.CodiceContabile;
        //        avm.ProgrammazioneFine = ta.ProgrammazioneFine;
        //        avm.ProgrammazioneInizio = ta.ProgrammazioneInizio;
        //        avm.Durata = ta.Durata;
        //        avm.GruppiXLivello = ta.GruppiXLivello;
        //        avm.StepPianificazione = (ta.Passo < new TimeSpan(0, 5, 0)) ? new TimeSpan(0, 5, 0) : ta.Passo;
        //        avm.IsAttivo = ta.Attivo;
        //        avm.CanSave = false;
        //        avm.IsErasabled = false;
        //        avm.IsEditable = true;
        //        avm.IsNew = false;
        //        return avm;
        //    }





        #endregion
        #region Gestione Tornelli
        public void SaveTornelloLog(LogTornelliViewModel log, bool IsSimulazione, bool IsEntrataGarantita)
        {
            try
            {

                string sql = "insert into logtornelli(Data,LetturaBadge,IDAnagrafica,IDAttivita,IDMovimento,IDCorsi,IDAnagraficaAttivitaDate,Note,Autorizzato,Autorizzazionems,CodiceContabile,IngressoUscita,Simulazione,EntrataGarantita) ";
                sql = sql + "values ('" + DateTime2MysqlDateTime(log.Data) + "','" + log.LetturaBadge + "'," + log.IDAnagrafica.ToString() + "," + log.IDAttivita.ToString() + "," + log.IDMovimento.ToString() + "," + log.IDCorsi;
                sql = sql + "," + log.IDAnagraficaAttivitaDate.ToString() + ",'" + log.Note + "'," + (log.IsAutorizzato ? "1" : "0") + "," + log.Autorizzazionems.ToString() + ",'" + log.CodiceContabile + "'";
                sql = sql + ",'" + (log.IsIngresso ? "I" : "U") + "'," + (IsSimulazione ? "1" : "0") + "," + (IsEntrataGarantita ? "1" : "0") + ")";
                using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate(sql))
                {
                    dtm.InsertUpdateRecord();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("LOG FALLITO:" + Ex.ToString());
            }
        }

        public void SalvaPresenza(LogTornelliViewModel log)
        {
            if (log.IsAutorizzato)
            {
                if (log.IDMovimento != 0)
                {
                    // Si tratta di attività senza anagrafica legata ad un biglietto emesso direttamente senza riferimenti in anagrafica
                    using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("insert into ingressisenzaanagrafica(IDMovimento,idCorsi,DataInizio,DataFine) values(@IDMovimento,@idCorsi,@DataInizio,@DataFine)"))
                    {
                        dtm.SetValue("IDMovimento", log.IDMovimento);
                        dtm.SetValue("idCorsi", log.IDCorsi);
                        dtm.SetValue("DataInizio", log.DataInizioCorso);
                        dtm.SetValue("DataFine", log.DataFineCorso);
                        dtm.InsertUpdateRecord();
                    }

                }
                else
                {
                    // Attività legata ad anagrafica e specifica attivita
                    if (log.TipoIngresso == 0)
                    {
                        // FISSO
                        using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("update anagraficaattivitadate set Presente=Presente+1 where idAnagraficaAttivitaDate =" + log.IDAnagraficaAttivitaDate.ToString()))
                        {
                            dtm.InsertUpdateRecord();
                        }
                    }
                    else
                    {
                        // Singolo o abbonamento
                        using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("insert into anagraficaattivitadate(idAnagraficaAttivita,DataInizio,DataFine,Attivo,Presente) values(@idAnagraficaAttivita,@DataInizio,@DataFine,1,1)"))
                        {
                            dtm.SetValue("idAnagraficaAttivita", log.IDAnagraficaAttivita);
                            dtm.SetValue("DataInizio", log.DataInizioCorso);
                            dtm.SetValue("DataFine", log.DataFineCorso);
                            dtm.InsertUpdateRecord();
                        }

                    }

                }


            }

        }

        string DateTime2MysqlDateTime(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");

        }
        string DateTime2MysqlDate(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");

        }

        private bool IsDataInRange(DateTime dc, DateTime di, DateTime df)
        {
            DateTime dcn = new DateTime(dc.Year, dc.Month, dc.Day);
            DateTime din = new DateTime(di.Year, di.Month, di.Day);
            DateTime dfn = new DateTime(df.Year, df.Month, df.Day);
            return (DateTime.Compare(dcn, di) >= 0 && DateTime.Compare(dcn, dfn) <= 0);
        }

        public LogTornelliViewModel CheckIngresso(QRCodeViewModel.QrCodeEntry qe, DateTime data, int mmAnticipoApertura, int mmAnticipoChiusura)
        {

            LogTornelliViewModel LT = new LogTornelliViewModel();
            LT.Data = data;
            int IDTipoAttivita = 0;
            LT.IsAutorizzato = false;
            LT.LetturaBadge = qe.Lettura;
            int mmData = data.Hour * 60 + data.Minute;
            LT.IDAnagraficaAttivita = 0;

            if (qe.Errore != null && qe.Errore != string.Empty)
            {
                LT.CodiceContabile = qe.CodiceContabile;
                LT.IDMovimento = qe.IDMovimento;
                LT.LetturaBadge = qe.Lettura;
                LT.Note = qe.Errore;
                LT.IsAutorizzato = false;
                return LT;

            }

            if (qe.Tipo == QRCodeViewModel.TipoQRCode.Tessera)
            {

                //LT.Log += "Tipo Badge:TESSERA\n";
                try
                {
                    LT.IDAnagrafica = (int)DBService.GetScalar("SELECT IDAnagrafica FROM anagrafica WHERE CodiceFiscale='" + qe.CodiceFiscale + "'");
                    LT.Log += "Anagrafica individuata:" + LT.IDAnagrafica.ToString();
                }
                catch
                {
                    LT.IsAutorizzato = false;
                    LT.Note = "Codice fiscale non trovato o duplicato";
                    //LT.Log  += LT.Note;
                }

                // Determino il tipo di attivita
                using (QueryReader dtm = DBService.GetReader("SELECT IDTipoAttivita,CodiceContabile FROM TipoAttivita WHERE Descrizione='" + qe.Attivita + "'"))
                {
                    if (dtm.dr.Read())
                    {
                        IDTipoAttivita = DbServiceMySql.DB2I(dtm.dr["IDTipoAttivita"]);
                        LT.CodiceContabile = dtm.dr["CodiceContabile"].ToString();
                        LT.Log += "Individuata tipo attivita:" + IDTipoAttivita.ToString() + "\nDeterminato codice contabile:" + LT.CodiceContabile;


                    }
                    else
                    {
                        LT.IsAutorizzato = false;
                        LT.Note = "Tipo attività non trovato o duplicato";
                        LT.Log += LT.Note + "\n";
                    }

                }
                // Determino elenco attivita
                LT.IDCorsi = 0;
                using (QueryReader dtm = DBService.GetReader("SELECT idAnagraficaAttivita, anagraficaattivita.idAttivita as c2, anagraficaattivita.DataInizio as c3, anagraficaattivita.DataFine as c4, TipoCorso, NumeroLezioni, corsi.idCorsi as c5 FROM anagraficaattivita inner join attivita on anagraficaattivita.idAttivita = attivita.idAttivita  inner join corsi on attivita.idcorsi = corsi.idcorsi " +
                            " where corsi.idtipoattivita = " + IDTipoAttivita + " and idAnagrafica = " + LT.IDAnagrafica.ToString()))
                {
                    try
                    {
                        while (LT.IsAutorizzato == false && dtm.dr.Read())
                        {
                            LT.IDAnagraficaAttivita = DbServiceMySql.DB2I(dtm.dr["idAnagraficaAttivita"]);
                            LT.IDAttivita = DbServiceMySql.DB2I(dtm.dr["c2"]);
                            DateTime di = DbServiceMySql.DB2DT(dtm.dr["c3"]);
                            DateTime df = DbServiceMySql.DB2DT(dtm.dr["c4"]);
                            short TipoCorso = DbServiceMySql.DB2I16(dtm.dr["TipoCorso"]);
                            short NumeroLezioni = DbServiceMySql.DB2I16(dtm.dr["NumeroLezioni"]);
                            LT.IDCorsi = DbServiceMySql.DB2I(dtm.dr["c5"]);
                            if (IsDataInRange(data, di, df))
                            {
                                if (TipoCorso == 0)
                                {
                                    // FISSO
                                    LT.TipoIngresso = 0;
                                    using (QueryReader dtf = DBService.GetReader("SELECT idAnagraficaAttivitaDate, hour(DataInizio)*60+minute(DataInizio) as ti ,hour(DataFine)*60+minute(DataFine) as te FROM anagraficaattivitadate " +
                                                            " where idAnagraficaAttivita = " + LT.IDAnagraficaAttivita.ToString() + " and Attivo = 1 and Year(DataInizio)  =" + data.Year.ToString() + " and dayofyear(datainizio) = " + data.DayOfYear.ToString()))
                                    {
                                        while (dtf.dr.Read() && LT.IsAutorizzato == false)
                                        {
                                            int IDAnagraficaAttivitaDate = DbServiceMySql.DB2I(dtf.dr["idAnagraficaAttivitaDate"]);
                                            int ti = DbServiceMySql.DB2I(dtf.dr["ti"]);
                                            int te = DbServiceMySql.DB2I(dtf.dr["te"]);
                                            if (ti - mmAnticipoApertura <= mmData && te - mmAnticipoChiusura >= mmData)
                                            {
                                                LT.IsAutorizzato = true;
                                                LT.IDAnagraficaAttivitaDate = IDAnagraficaAttivitaDate;
                                                LT.Note = "Tessera-Attività programmata fissa";
                                            }
                                        }
                                        if (!LT.IsAutorizzato)
                                            LT.Note = "Data/orario non consentito";
                                    }
                                }
                                else
                                {
                                    using (QueryReader dtf = DBService.GetReader("SELECT OraInizio,OraFine FROM corsodettaglio inner join corsi on corsi.idcorsi = corsodettaglio.idCorsi inner join attivita on attivita.idCorsi = corsi.idCorsi  where attivita.idAttivita = " + LT.IDAttivita.ToString() + " and Giorno = " + ((int)data.DayOfWeek).ToString() + " and(hour(OraInizio) * 60 + minute(OraInizio) - " + mmAnticipoApertura.ToString() + ") <= " + mmData.ToString() + "&& (hour(OraFine) * 60 + minute(OraFine) - " + mmAnticipoChiusura.ToString() + ") >= " + mmData.ToString()))
                                    {
                                        // Calcolo se c'è accesso all'attività in questione in questo orario
                                        if (dtf.dr.Read())
                                        {
                                            TimeSpan ti = DbServiceMySql.DB2TIME(dtf.dr["OraInizio"]);
                                            TimeSpan te = DbServiceMySql.DB2TIME(dtf.dr["OraFine"]);
                                            LT.DataInizioCorso = new DateTime(LT.Data.Year, LT.Data.Month, LT.Data.Day, 0, 0, 0) + ti;
                                            LT.DataFineCorso = new DateTime(LT.Data.Year, LT.Data.Month, LT.Data.Day, 0, 0, 0) + te;
                                            // L'orario è corretto a questo punto controllo quanti ingressi rimanenti
                                            // Memorizzo orario

                                            // ABBONAMENTO e SINGOLO
                                            LT.TipoIngresso = TipoCorso;
                                            long nCount2 = DbServiceMySql.DB2I(DBService.GetScalar("SELECT count(*) FROM anagraficaattivitadate where idAnagraficaAttivita = " + LT.IDAnagraficaAttivita.ToString() + " and Attivo = 1"));
                                            if (nCount2 < NumeroLezioni)
                                            {
                                                LT.IsAutorizzato = true;
                                                if (TipoCorso == 1)
                                                    LT.Note = "Ingresso in abbonamento n." + (nCount2 + 1) + " su " + NumeroLezioni.ToString();
                                                else
                                                    LT.Note = "Ingresso singolo";

                                            }
                                            else
                                                if (TipoCorso == 1)
                                                LT.Note = "Ingresso in abbonamento completo (" + NumeroLezioni.ToString() + ")";
                                            else
                                                LT.Note = "Ingresso singolo già usato";
                                        }
                                    }
                                }
                            }
                        }
                        if (!LT.IsAutorizzato && LT.Note == string.Empty)
                            LT.Note = "Nessuna attività  trovata";
                    }
                    catch (Exception Ex)
                    {
                        LT.IsAutorizzato = false;
                        LT.Note = "Attività non trovata/non attiva/duplicata";
                    }
                }
            }
            else
            if (qe.Tipo == QRCodeViewModel.TipoQRCode.Biglietto)
            {

                // Controllo da subito se biglietto è gia stato usato
                try
                {
                    long nCount = (long)DBService.GetScalar("select count(*) from ingressisenzaanagrafica where IDMovimento=" + qe.IDMovimento);
                    if (nCount == 0)
                    {
                        LT.IDMovimento = qe.IDMovimento;
                        using (QueryReader drq = DBService.GetReader("SELECT codicicontabili.Codice,corsi.idCorsi,corsodettaglio.OraInizio as oi, corsodettaglio.OraFine as of FROM corsodettaglio inner join corsi on corsodettaglio.idCorsi = corsi.idCorsi inner join tipoattivita on corsi.idTipoAttivita = tipoattivita.idTipoAttivita inner join codicicontabili on tipoattivita.CodiceContabile = codicicontabili.Codice " +
                                                 " where corsi.Attivo = 1 and TipoCorso = 2 and codicicontabili.Descrizione = '" + qe.CodiceContabile + "' and Giorno = " + ((int)data.DayOfWeek).ToString() + " and(hour(OraInizio) * 60 + minute(OraInizio) - " + mmAnticipoApertura.ToString() + ") <= " + mmData.ToString() + " && (hour(OraFine) * 60 + minute(OraFine) - " + mmAnticipoChiusura.ToString() + ") >= " + mmData.ToString()))
                        {
                            if (drq.dr.Read())
                            {
                                LT.CodiceContabile = drq.dr[0].ToString();
                                LT.Note = "Biglietto autorizzato";
                                LT.IDCorsi = DbServiceMySql.DB2I(drq.dr[1]);
                                TimeSpan ti = DbServiceMySql.DB2TIME(drq.dr["oi"]);
                                TimeSpan te = DbServiceMySql.DB2TIME(drq.dr["of"]);
                                LT.DataInizioCorso = new DateTime(LT.Data.Year, LT.Data.Month, LT.Data.Day, 0, 0, 0) + ti;
                                LT.DataFineCorso = new DateTime(LT.Data.Year, LT.Data.Month, LT.Data.Day, 0, 0, 0) + te;
                                LT.IsAutorizzato = true;
                            }
                            else
                                LT.Note = "Biglietto-Attività non disponibili in questo momento";
                        }
                    }
                    else
                        LT.Note = "Biglietto-Ingresso singolo già usato";
                }
                catch (Exception Ex)
                {
                    LT.IsAutorizzato = false;
                }
                if (!LT.IsAutorizzato && LT.Note == string.Empty)
                    LT.Note = "Biglietto - Attività non disponibile";
            }
            return LT;
        }
        public void UpdateStatoPresenza(int ID, bool stato)
        {

            // Singolo o abbonamento
            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("update anagraficaattivitadate Set Presente = @Presente where idAnagraficaAttivitaDate=@idAnagraficaAttivitaDate"))
            {
                dtm.SetValue("idAnagraficaAttivitaDate", ID);
                dtm.SetValue("Presente", stato);
                dtm.InsertUpdateRecord();
            }


        }

        #endregion
        #region ReportPersonalizzati
        public List<ReportPersonalizzatoViewModel> GetElencoReport()
        {
            List<ReportPersonalizzatoViewModel> lista = new List<ReportPersonalizzatoViewModel>();
            using (QueryReader dtd = DBService.GetReader("select * from exportpersonalizzati order by Nome"))
            {
                while (dtd.dr.Read())
                    lista.Add(m2vmReportPersonalizzatoViewModel(dtd.dr));
            }
            return lista;
        }
        public ReportPersonalizzatoViewModel GetReport(int ID)
        {
            ReportPersonalizzatoViewModel rpvm = null;
            using (QueryReader dtd = DBService.GetReader("select * from exportpersonalizzati where idExportPersonalizzati = "+ID.ToString()))
            {
                if (dtd.dr.Read())
                rpvm = m2vmReportPersonalizzatoViewModel(dtd.dr);
            }
            if (rpvm != null)
            {

                using (QueryReader dtq = DBService.GetReader(rpvm.Query))
                {
                    try
                    {
                        if (dtq.dr.Read())
                        {
                            // Estraggo Header
                            rpvm.Header = new List<HeaderReport>();
                            for (int i = 0; i < dtq.dr.FieldCount;i++)
                            {
                                HeaderReport hd = new HeaderReport();

                                hd.FieldName = dtq.dr.GetName(i);
                                if (dtq.dr.GetFieldType(i) == typeof(string))
                                {
                                    hd.Formato = string.Empty;
                                    hd.TipoFormato = TipoDato.Stringa;
                                }
                                else
                                if (dtq.dr.GetFieldType(i) == typeof(int) || dtq.dr.GetFieldType(i) == typeof(Int16) || dtq.dr.GetFieldType(i) == typeof(Int32) || dtq.dr.GetFieldType(i) == typeof(UInt64))
                                {
                                    hd.Formato = string.Empty;
                                    hd.TipoFormato = TipoDato.Intero;
                                }
                                else
                                if (dtq.dr.GetFieldType(i) == typeof(DateTime))
                                {
                                    hd.Formato = "YYYY-mm-dd";
                                    hd.TipoFormato = TipoDato.Data;
                                }else
                                if (dtq.dr.GetFieldType(i) == typeof(Decimal))
                                {
                                    hd.Formato = "D2";
                                    hd.TipoFormato = TipoDato.Decimale;
                                }
                                else
                                {
                                    hd.Formato = "*";
                                    hd.TipoFormato = TipoDato.NonRiconosciuto;
                                }
                                rpvm.Header.Add(hd);
                            }
                            // Leggo i vari record
                            rpvm.Records = new List<List<object>>();
                            bool bFine = false;
                            while (!bFine)
                            {
                                List<object> riga = new List<object>();
                                for (int i = 0; i < dtq.dr.FieldCount; i++)
                                {
                                    if (!DbServiceMySql.IsNull(dtq.dr[i]))
                                        riga.Add(dtq.dr[i]);
                                    else
                                        riga.Add(null);
                                }
                                rpvm.Records.Add(riga);
                                bFine = !dtq.dr.Read();
                            }
                        }
                    }catch
                    {
                        rpvm = null;

                    }
                }

            }
            return rpvm;

        }

        public void ReportSaveQuery(int ID, string Query)
        {
            using (DBInsertUpdate dtm = DBService.GetDBInsertUpdate("update exportpersonalizzati set QueryAggiornata = @Query where idExportPersonalizzati = "+ID.ToString()))
            {
                dtm.SetValue("Query", Query);
                dtm.InsertUpdateRecord();
            }
        }

        ReportPersonalizzatoViewModel m2vmReportPersonalizzatoViewModel(MySqlDataReader dr)
        {
            ReportPersonalizzatoViewModel sdv = new ReportPersonalizzatoViewModel();
            sdv.ID = DbServiceMySql.DB2I(dr["idExportPersonalizzati"]);
            sdv.Nome = dr["Nome"].ToString();
            sdv.Descrizione = dr["Descrizione"].ToString();
            sdv.QueryOriginale = dr["Query"].ToString();
            sdv.Query = dr["QueryAggiornata"].ToString();
            if (sdv.Query == string.Empty)
                sdv.Query = sdv.QueryOriginale;
            return sdv;
        }

        #endregion
    }
}