using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GPNuoto.Model;
using GPNuoto.ViewModel;


namespace GPNuoto.Design
{
    public class DesignDataService : IDataService
    {
        List<int> GetAnagraficaByCF(string CF)
        {
            throw new NotImplementedException();
        }

        //anagrafica GetAnagraficaById(int id)
        //{
        //    throw new NotImplementedException();
        //}



        //void LoadInfoAggiuntive(int idRecord, Dictionary<string, InfoAggiuntiveModel.InfoAdd> InfoAddMatrix)
        //{
        //    throw new NotImplementedException();
        //}

        int SaveAnagrafica(AnagraficaViewModel avm)
        {
            throw new NotImplementedException();
        }



        void IDataService.GetAnagraficaById(AnagraficaViewModel avm, int id)
        {
            throw new NotImplementedException();
        }

        string IDataService.GetCAP(int ID)
        {
            return "X00001";
        }

        string IDataService.GetCodiceISTAT(int ID)
        {
            throw new NotImplementedException();
        }

        List<LookupViewModel> IDataService.GetElencoLocalita()
        {
            List<LookupViewModel> Elenco = new List<LookupViewModel>();

            return Elenco;
        }

        List<LookupViewModel> IDataService.GetElencoLuoghiNascita(bool bEstero)
        {
            List<LookupViewModel> lvm = new List<LookupViewModel>();

            return lvm;
        }

        //List<setupinformazioniaggiuntive> IDataService.GetSetupInformazioniAggiuntive()
        //{
        //    List<setupinformazioniaggiuntive> lsi = new List<setupinformazioniaggiuntive>();
        //    setupinformazioniaggiuntive sia = new setupinformazioniaggiuntive();
        //    sia.CodInfo = "CERTMED";
        //    sia.TipoInformazione = "Data";
        //    sia.Descrizione = "Certificato medico";
        //    lsi.Add(sia);
        //    return lsi;
        //}



        ObservableCollection<ResultSetAnagraficaViewModel> IDataService.QueryAnagrafica(AnagraficaViewModel avm)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<ResultSetAnagraficaViewModel> IDataService.QueryAnagraficaFromID(List<int> idlist)
        {
            throw new NotImplementedException();
        }

        int IDataService.SaveAnagrafica(AnagraficaViewModel avm)
        {
            throw new NotImplementedException();
        }



        List<TipoAttivitaViewModel> IDataService.GetElencoTipoAttivita(bool bAll)
        {
            throw new NotImplementedException();
        }
        List<TipoAttivitaROViewModel> IDataService.GetElencoTipoAttivitaRO(bool bAll)
        {
            List<TipoAttivitaROViewModel> lista = new List<TipoAttivitaROViewModel>();
            TipoAttivitaROViewModel ta = new TipoAttivitaROViewModel();
            ta.Titolo = "Scuola Nuoto Adulti";
            ta.BackgroundColor = "Blue";
            ta.ID = 1;


            lista.Add(ta);

            return lista;
        }

        public List<string> GetElencoCorsiAttivi(int IDTipoAttivita)
        {
            throw new NotImplementedException();
        }

        List<ROAttivitaViewModel> IDataService.GetElencoCorsiAttivi(int IDTipoAttivita)
        {
            List<ROAttivitaViewModel> lista = new List<ROAttivitaViewModel>();
            ROAttivitaViewModel roavm = new ROAttivitaViewModel();
            roavm.Corso = GetROCorso(1);
            roavm.DataFine = new DateTime(2017, 12, 31, 0, 0, 0);
            roavm.DataInizio = new DateTime(2017, 10, 31, 0, 0, 0);
            roavm.ID = 1;
            roavm.IDCorso = roavm.Corso.ID;
            roavm.IsAttivo = true;
            roavm.IsFiltrata = false;
            roavm.Note = "Note attivita view model";
            roavm.NumeroLezioni = 15;
            roavm.Titolo = "Titolo Attivita";
            lista.Add(roavm);

            return lista;

        }



        public void AddAttivita(int IDAnagrafica, int IDAttivita)
        {
            throw new NotImplementedException();
        }

        public List<SingolaAnagraficaAttivitaViewModel> LoadAttivita(int IDAnagrafica)
        {
            throw new NotImplementedException();
        }

        public void SaveAttivita(int ID, int NumeroIngressi, decimal Importo, string Note)
        {
            throw new NotImplementedException();
        }

        public void DeleteAttivita(int ID)
        {
            throw new NotImplementedException();
        }

        public List<ModalitaPagamentoViewModel> GetElencoModalitaPagamento()
        {
            throw new NotImplementedException();
        }



        List<SingoloMovimentoViewModel> IDataService.LoadPagamenti(int IDAnagrafica)
        {
            throw new NotImplementedException();
        }

        public int SavePagamento(SingoloMovimentoViewModel spvm, SingoloUtenteViewModel suv, bool bIsAutoTrasferimento)
        {
            throw new NotImplementedException();
        }

        public bool GetUser(SingoloUtenteViewModel suvm)
        {
            throw new NotImplementedException();
        }

        public string GetCodiceContabileFromAttivita(int ID)
        {
            throw new NotImplementedException();
        }

        public string GetComuneFromID(int ID)
        {
            return "Comune di prova";
        }

        public CassaViewModel GetStatoCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        public List<SingoloMovimentoViewModel> GetElencoMovimenti(DateTime data)
        {
            throw new NotImplementedException();
        }

        public void ApriCassa(CassaViewModel cvm)
        {
            cvm.Stato = CassaViewModel.StatoCassa.Aperta;
        }

        public void SalvaChiusuraCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        public List<CorsoViewModel> GetMatriceCorsi(List<TipoAttivitaViewModel> listaattivita, bool bAll)
        {
            throw new NotImplementedException();
        }

        public bool StatoAttivazioneCorso(int ID, bool newState)
        {
            throw new NotImplementedException();
        }

        public List<SingoloCodiceContabileViewModel> GetElencoCodiciContabili(bool bAll, bool? bExtra)
        {
            throw new NotImplementedException();
        }

        public List<ModalitaPagamentoViewModel> GetElencoModalitaPagamento(bool bAll)
        {
            throw new NotImplementedException();
        }

        public bool IsModalitaPagamento(string codice)
        {
            return true;
        }
        public bool UpdateModalitaPagamento(ModalitaPagamentoViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public void DeleteModalitaPagamento(ModalitaPagamentoViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public bool IsCodiceContabile(string codice)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCodiceContabile(SingoloCodiceContabileViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public void DeleteCodiceContabile(SingoloCodiceContabileViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLuogoNascita(SingoloLuogoNascitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public void DeleteLuogoNascita(SingoloLuogoNascitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public List<SingoloLuogoNascitaViewModel> GetTabellaLuoghiNascita(string txtFiltro)
        {
            throw new NotImplementedException();
        }

        public bool UpdateComuneResidenza(SingoloComuneResidenzaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public void DeleteComuneResidenza(SingoloComuneResidenzaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public List<SingoloComuneResidenzaViewModel> GetTabellaComuniResidenza(string txtFiltro)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUtente(SingoloUtenteViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public List<SingoloUtenteViewModel> GetTabellaUtenti()
        {
            throw new NotImplementedException();
        }

        public List<SingoloUtenteViewModel> GetTabellaUtenti(bool bShowAll)
        {
            throw new NotImplementedException();
        }

        public bool IsUser(string user)
        {
            return false;
        }

        public void DeleteUtente(SingoloUtenteViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public void UpdateUtentePassword(SingoloUtenteViewModel mpvm, string pwd)
        {
            throw new NotImplementedException();
        }

        public void DeleteTipoAttivita(TipoAttivitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTipoAttivita(TipoAttivitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        public bool IsTipoAttivita(string stipoattivita)
        {
            return false;
        }

        public bool IsTipoAttivitaErasable(int idTA)
        {
            throw new NotImplementedException();
        }

        public void UpdateCorso(CorsoEditViewModel cevm)
        {
            throw new NotImplementedException();
        }

        public CorsoEditViewModel GetCorso(int ID)
        {
            throw new NotImplementedException();
        }

        public void RemoveCorso(CorsoEditViewModel cevm)
        {
            throw new NotImplementedException();
        }

        public void SaveProgrammazione(SingolaAttivitaViewModel sa)
        {
            throw new NotImplementedException();
        }

        public List<SingolaAttivitaViewModel> GetElencoAttivitaProgrammate(int ID, bool bAll)
        {
            throw new NotImplementedException();
        }

        public bool StatoAttivazioneProgrammazione(int ID, bool newState)
        {
            throw new NotImplementedException();
        }

        public void RemoveProgrammazione(SingolaAttivitaViewModel savm)
        {
            throw new NotImplementedException();
        }

        public bool StatoAttivazioneDataAnagraficaAttivita(int ID, bool newState)
        {
            throw new NotImplementedException();
        }

        public List<SingoloCodiceContabileViewModel> GetElencoAltriMovimenti()
        {
            throw new NotImplementedException();
        }

        public List<CassaViewModel> GetElencoCasseNonValidate()
        {
            return null;
        }

        public List<SingoloMovimentoViewModel> GetElencoMovimentiCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        public void ConvalidaCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        public List<SingolaFatturaViewModel> GetElencoRichiestaFatture()
        {
            throw new NotImplementedException();
        }

        public ModalitaPagamentoViewModel GetModalitaPagamentoFromID(string Key)
        {
            throw new NotImplementedException();
        }

        public void RegistraFattura(SingolaFatturaViewModel sfvm)
        {
            throw new NotImplementedException();
        }

        public List<SingoloTrasferimentoViewModel> GetElencoTrasferimenti()
        {
            throw new NotImplementedException();
        }

        public bool CheckForUserAuthorize(SingoloUtenteViewModel suvm)
        {
            throw new NotImplementedException();
        }

        public bool CheckForCodiceISTAT(string stringValue)
        {
            throw new NotImplementedException();
        }

        public bool CheckForCodiceContabile(string scodice)
        {
            throw new NotImplementedException();
        }

        public void TraferisciContabilita(ElementoMatriceTrasferimentoViewModel stvm)
        {
            throw new NotImplementedException();
        }

        public string GetVersioneDatabase()
        {
            throw new NotImplementedException();
        }

        public ROCorsoViewModel GetROCorso(int ID)
        {
            ROCorsoViewModel ro = new ROCorsoViewModel();
            ro.CostoIvaLezione = 10;
            ro.CostoLordoLezione = 50;
            ro.ID = 1;
            ro.IDTipoAttivita = 1;
            ro.IsAttivo = true;
            ro.Note = "Note corso di prova";
            ro.NumeroLezioni = 15;
            ro.TipoCorso = CorsoViewModel.TipoCorsoValue.Fisso;
            ro.DettaglioOrari = new List<OrarioCorsoViewModel>();
            OrarioCorsoViewModel ocvm = new OrarioCorsoViewModel();
            ocvm.GiornoSettimana = DayOfWeek.Monday;
            ocvm.ID = 1;
            ocvm.OraFine = new TimeSpan(12, 0, 0);
            ocvm.OraInizio = new TimeSpan(11, 0, 0);
            ro.DettaglioOrari.Add(ocvm);
            return ro;
        }

        public List<SingoloMovimentoViewModel> GetElencoAltriPagamenti(DateTime Data)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovimento(SingoloMovimentoViewModel smvm)
        {
            throw new NotImplementedException();
        }

        public string GetNoteCorsoFromIDAnagraficaAttivita(int IDAA)
        {
            throw new NotImplementedException();
        }

        public void RemoveAnagrafica(int ID)
        {
            throw new NotImplementedException();
        }

        public bool CanRemoveAnagrafica(int ID)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<SingolaDataAttivitaViewModel> AddSingoloIngresso(int IDAnagraficaAttivita, DateTime DataInizio, DateTime DataFine, bool bIsAbbonamento)
        {
            throw new NotImplementedException();
        }

        public int GetNumeroIscrizioni(int idAttivita)
        {
            return 100;
        }

        public List<RiepilogoAttivitaViewModel> GetRiepilogoAttivita(List<int> ListIDTipoAttivita)
        {
            List<RiepilogoAttivitaViewModel> lista = new List<RiepilogoAttivitaViewModel>();
            RiepilogoAttivitaViewModel ravm = new RiepilogoAttivitaViewModel();
            ravm.ID = 1;
            ravm.IDTipoAttivita = 1;
            lista.Add(ravm);
            ravm = new RiepilogoAttivitaViewModel();
            ravm.ID = 2;
            ravm.IDTipoAttivita = 2;
            lista.Add(ravm);
            return lista;
        }

        public List<AnagraficaROViewModel> GetElencoIscritti(int idAttivita)
        {
            List<AnagraficaROViewModel> lista = new List<AnagraficaROViewModel>();

            AnagraficaROViewModel arovm = new AnagraficaROViewModel();
            lista.Add(arovm);
            arovm = new AnagraficaROViewModel();
            lista.Add(arovm);
            return lista;


        }

        public List<TipoAttivitaROViewModel> GetElencoTipiAttivitaForAnagrafica(int IDAnagrafica)
        {
            List<TipoAttivitaROViewModel> lta = new List<TipoAttivitaROViewModel>();

            TipoAttivitaROViewModel tvm = new TipoAttivitaROViewModel();
            tvm.BackgroundColor = "DarkBlue";
            tvm.CodiceContabileCassa = "0000";
            tvm.Durata = new TimeSpan(10, 0, 0);
            tvm.ForegroundColor = "White";
            tvm.GruppiXLivello = false;
            tvm.ID = 1;
            tvm.IsAttivo = true;
            tvm.ProgrammazioneFine = new TimeSpan(10, 0, 0);
            tvm.ProgrammazioneInizio = new TimeSpan(9, 0, 0);
            tvm.Titolo = "Tipo di prova";
            lta.Add(tvm);
            return lta;

        }

        public ObservableCollection<ResultSetAnagraficaViewModel> QueryAnagraficaByCode(string CF)
        {
            throw new NotImplementedException();
        }

        public bool IsMovimentoFiscaleFromCodiceContabile(string codicecontabile)
        {
            throw new NotImplementedException();
        }

        public SingoloCodiceContabileViewModel GetCodiceContabileFromCodice(string sCodice)
        {
            throw new NotImplementedException();
        }

        public void RemoveMovimento(SingoloMovimentoViewModel smvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.RemoveAnagrafica(int ID)
        {
            throw new NotImplementedException();
        }

        bool IDataService.CanRemoveAnagrafica(int ID)
        {
            throw new NotImplementedException();
        }

        string IDataService.GetVersioneDatabase()
        {
            throw new NotImplementedException();
        }

        ObservableCollection<ResultSetAnagraficaViewModel> IDataService.QueryAnagraficaByCode(string CF)
        {
            throw new NotImplementedException();
        }

        List<RiepilogoAttivitaViewModel> IDataService.GetRiepilogoAttivita(List<int> ListIDTipoAttivita)
        {
            throw new NotImplementedException();
        }

        void IDataService.AddAttivita(int IDAnagrafica, int IDAttivita)
        {
            throw new NotImplementedException();
        }

        List<SingolaAnagraficaAttivitaViewModel> IDataService.LoadAttivita(int IDAnagrafica)
        {
            throw new NotImplementedException();
        }

        void IDataService.SaveAttivita(int ID, int NumeroIngressi, decimal Importo, string Note)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteAttivita(int ID)
        {
            throw new NotImplementedException();
        }

        int IDataService.SavePagamento(SingoloMovimentoViewModel spvm, SingoloUtenteViewModel suvm, bool bIsAutoTrasferimento)
        {
            throw new NotImplementedException();
        }

        bool IDataService.IsMovimentoFiscaleFromCodiceContabile(string codicecontabile)
        {
            throw new NotImplementedException();
        }

        bool IDataService.GetUser(SingoloUtenteViewModel suvm)
        {
            throw new NotImplementedException();
        }



        SingoloCodiceContabileViewModel IDataService.GetCodiceContabileFromCodice(string sCodice)
        {
            throw new NotImplementedException();
        }

        string IDataService.GetComuneFromID(int ID)
        {
            throw new NotImplementedException();
        }

        CassaViewModel IDataService.GetStatoCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        List<SingoloMovimentoViewModel> IDataService.GetElencoMovimenti(DateTime data)
        {
            throw new NotImplementedException();
        }

        void IDataService.ApriCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.SalvaChiusuraCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        List<CorsoViewModel> IDataService.GetMatriceCorsi(List<TipoAttivitaViewModel> listaattivita, bool bAll)
        {
            throw new NotImplementedException();
        }

        bool IDataService.StatoAttivazioneCorso(int ID, bool newState)
        {
            throw new NotImplementedException();
        }

        void IDataService.RemoveMovimento(SingoloMovimentoViewModel smvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.UpdateMovimento(SingoloMovimentoViewModel smvm)
        {
            throw new NotImplementedException();
        }

        bool IDataService.StatoAttivazioneDataAnagraficaAttivita(int ID, bool newState)
        {
            throw new NotImplementedException();
        }

        List<SingoloCodiceContabileViewModel> IDataService.GetElencoCodiciContabili(bool bAll, bool? bExtra)
        {
            throw new NotImplementedException();
        }

        List<ModalitaPagamentoViewModel> IDataService.GetElencoModalitaPagamento(bool bAll)
        {
            throw new NotImplementedException();
        }

        bool IDataService.IsModalitaPagamento(string codice)
        {
            throw new NotImplementedException();
        }

        bool IDataService.UpdateModalitaPagamento(ModalitaPagamentoViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteModalitaPagamento(ModalitaPagamentoViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        bool IDataService.IsCodiceContabile(string codice)
        {
            throw new NotImplementedException();
        }

        bool IDataService.UpdateCodiceContabile(SingoloCodiceContabileViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteCodiceContabile(SingoloCodiceContabileViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        List<SingoloCodiceContabileViewModel> IDataService.GetElencoAltriMovimenti()
        {
            throw new NotImplementedException();
        }

        List<CassaViewModel> IDataService.GetElencoCasseNonValidate()
        {
            throw new NotImplementedException();
        }

        List<SingoloMovimentoViewModel> IDataService.GetElencoMovimentiCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.ConvalidaCassa(CassaViewModel cvm)
        {
            throw new NotImplementedException();
        }

        List<SingolaFatturaViewModel> IDataService.GetElencoRichiestaFatture()
        {
            throw new NotImplementedException();
        }

        ModalitaPagamentoViewModel IDataService.GetModalitaPagamentoFromID(string Key)
        {
            throw new NotImplementedException();
        }

        void IDataService.RegistraFattura(SingolaFatturaViewModel sfvm)
        {
            throw new NotImplementedException();
        }

        List<SingoloTrasferimentoViewModel> IDataService.GetElencoTrasferimenti()
        {
            throw new NotImplementedException();
        }



        void IDataService.TraferisciContabilita(ElementoMatriceTrasferimentoViewModel stvm)
        {
            throw new NotImplementedException();
        }

        List<SingoloMovimentoViewModel> IDataService.GetElencoAltriPagamenti(DateTime Data)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteMovimento(SingoloMovimentoViewModel smvm)
        {
            throw new NotImplementedException();
        }

        bool IDataService.UpdateLuogoNascita(SingoloLuogoNascitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteLuogoNascita(SingoloLuogoNascitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        List<SingoloLuogoNascitaViewModel> IDataService.GetTabellaLuoghiNascita(string txtFiltro)
        {
            throw new NotImplementedException();
        }

        bool IDataService.UpdateComuneResidenza(SingoloComuneResidenzaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteComuneResidenza(SingoloComuneResidenzaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        List<SingoloComuneResidenzaViewModel> IDataService.GetTabellaComuniResidenza(string txtFiltro)
        {
            throw new NotImplementedException();
        }

        bool IDataService.IsUser(string user)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteUtente(SingoloUtenteViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        bool IDataService.UpdateUtente(SingoloUtenteViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        void IDataService.UpdateUtentePassword(SingoloUtenteViewModel mpvm, string pwd)
        {
            throw new NotImplementedException();
        }

        List<SingoloUtenteViewModel> IDataService.GetTabellaUtenti(bool bShowAll)
        {
            throw new NotImplementedException();
        }

        bool IDataService.CheckForUserAuthorize(SingoloUtenteViewModel suvm)
        {
            throw new NotImplementedException();
        }

        bool IDataService.IsTipoAttivita(string stipoattivita)
        {
            throw new NotImplementedException();
        }

        bool IDataService.IsTipoAttivitaErasable(int idTA)
        {
            throw new NotImplementedException();
        }

        void IDataService.DeleteTipoAttivita(TipoAttivitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        bool IDataService.UpdateTipoAttivita(TipoAttivitaViewModel mpvm)
        {
            throw new NotImplementedException();
        }

        int IDataService.GetNumeroIscrizioni(int idAttivita)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<SingolaDataAttivitaViewModel> IDataService.AddSingoloIngresso(int IDAnagraficaAttivita, DateTime DataInizio, DateTime DataFine, bool bIsAbbonamento)
        {
            throw new NotImplementedException();
        }

        List<AnagraficaROViewModel> IDataService.GetElencoIscritti(int idAttivita)
        {
            throw new NotImplementedException();
        }

        List<TipoAttivitaROViewModel> IDataService.GetElencoTipiAttivitaForAnagrafica(int IDAnagrafica)
        {
            throw new NotImplementedException();
        }

        CorsoEditViewModel IDataService.GetCorso(int ID)
        {
            throw new NotImplementedException();
        }

        void IDataService.UpdateCorso(CorsoEditViewModel cevm)
        {
            throw new NotImplementedException();
        }

        void IDataService.RemoveCorso(CorsoEditViewModel cevm)
        {
            throw new NotImplementedException();
        }

        ROCorsoViewModel IDataService.GetROCorso(int ID)
        {
            throw new NotImplementedException();
        }

        string IDataService.GetNoteCorsoFromIDAnagraficaAttivita(int IDAA)
        {
            throw new NotImplementedException();
        }

        void IDataService.SaveProgrammazione(SingolaAttivitaViewModel sa)
        {
            throw new NotImplementedException();
        }

        List<SingolaAttivitaViewModel> IDataService.GetElencoAttivitaProgrammate(int ID, bool bAll)
        {
            throw new NotImplementedException();
        }

        bool IDataService.StatoAttivazioneProgrammazione(int ID, bool newState)
        {
            throw new NotImplementedException();
        }

        void IDataService.RemoveProgrammazione(SingolaAttivitaViewModel savm)
        {
            throw new NotImplementedException();
        }

        bool IDataService.CheckForCodiceISTAT(string stringValue)
        {
            throw new NotImplementedException();
        }

        public void GetAnagraficaById(AnagraficaViewModel avm, int id)
        {
            throw new NotImplementedException();
        }

        AnagraficaROViewModel IDataService.GetAnagraficaById(int id)
        {
            throw new NotImplementedException();
        }

        List<int> IDataService.GetAnagraficaByCF(string CF)
        {
            throw new NotImplementedException();
        }

        public List<string> GetElencoDateAttivita(int IDAnagraficaAttivita)
        {
            throw new NotImplementedException();
        }

        public bool CheckForRinnovo(string sCodiceFiscale, string sAttivita)
        {
            throw new NotImplementedException();
        }

        public bool RinnovoAttivita(string sCodiceFiscale, string sAttivita)
        {
            throw new NotImplementedException();
        }





        bool IDataService.CheckForRinnovo(string sCodiceFiscale, string sAttivita)
        {
            throw new NotImplementedException();
        }

        List<string> IDataService.GetElencoDateAttivita(int IDAnagraficaAttivita)
        {
            throw new NotImplementedException();
        }

        bool IDataService.RinnovoAttivita(string sCodiceFiscale, string sAttivita)
        {
            throw new NotImplementedException();
        }

        LogTornelliViewModel IDataService.CheckIngresso(QRCodeViewModel.QrCodeEntry qe, DateTime data, int mmAnticipoApertura, int mmAnticipoChiusura)
        {
            throw new NotImplementedException();
        }

        public void SaveTornelloLog(LogTornelliViewModel log, bool IsSimulazione, bool IsEntrataGarantita)
        {
            throw new NotImplementedException();
        }

        public void SalvaPresenza(LogTornelliViewModel log)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatoPresenza(int ID, bool stato)
        {
            throw new NotImplementedException();
        }

        public List<SingoloDettaglioCodiceContabileViewModel> GetDettagliCodiceContabile(string Codice)
        {
            throw new NotImplementedException();
        }

        public void AddDettaglioCodiceContabile(SingoloCodiceContabileViewModel CodiceContabile, SingoloDettaglioCodiceContabileViewModel cd)
        {
            throw new NotImplementedException();
        }

        public void RemoveDettaglioCodiceContabile(SingoloDettaglioCodiceContabileViewModel dettaglio)
        {
            throw new NotImplementedException();
        }

        public bool CheckForDettagliMovimento(string sCodice)
        {
            throw new NotImplementedException();
        }

        public List<ScontrinoViewModel> GetScontrinoFromMovimento(int IDMovimento)
        {
            throw new NotImplementedException();
        }
        public List<ReportPersonalizzatoViewModel> GetElencoReport()
        {
            throw new NotImplementedException();
        }
        public ReportPersonalizzatoViewModel GetReport(int ID)
        {
            throw new NotImplementedException();
        }

        public void ReportSaveQuery(int ID, string Query)
        {
            throw new NotImplementedException();
        }
    }
}