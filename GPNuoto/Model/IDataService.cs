using GPNuoto.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GPNuoto.Model
{
    
    public interface IDataService
    {
        #region Altro
       
        #endregion
        #region GESTIONE ANAGRAFICA
        List<LookupViewModel> GetElencoLuoghiNascita(bool bEstero);
        List<LookupViewModel> GetElencoLocalita();
        //List<setupinformazioniaggiuntive> GetSetupInformazioniAggiuntive();

        void RemoveAnagrafica(int ID);
        bool CanRemoveAnagrafica(int ID);
        
        string GetVersioneDatabase();
      

        string GetCAP(int ID);
        string GetCodiceISTAT(int ID);
       // void SaveInfoAggiuntive(int idRecord, Dictionary<string, InfoAggiuntiveModel.InfoAdd> InfoAddMatrix);
      //  void LoadInfoAggiuntive(int idRecord, Dictionary<string, InfoAggiuntiveModel.InfoAdd> InfoAddMatrix);
        void GetAnagraficaById(AnagraficaViewModel avm, int id);
        AnagraficaROViewModel GetAnagraficaById(int id);
        List<int> GetAnagraficaByCF(string CF);
        int SaveAnagrafica(AnagraficaViewModel avm);
        ObservableCollection<ResultSetAnagraficaViewModel>  QueryAnagrafica(AnagraficaViewModel avm);
        ObservableCollection<ResultSetAnagraficaViewModel> QueryAnagraficaByCode(string CF);
        ObservableCollection<ResultSetAnagraficaViewModel> QueryAnagraficaFromID(List<int> listid);
        #endregion
        List<TipoAttivitaViewModel> GetElencoTipoAttivita(bool bAll);
        List<TipoAttivitaROViewModel> GetElencoTipoAttivitaRO(bool bAll);

        List<RiepilogoAttivitaViewModel> GetRiepilogoAttivita(List<int> ListIDTipoAttivita);

        List<ROAttivitaViewModel> GetElencoCorsiAttivi(int IDTipoAttivita);
       
        void AddAttivita(int IDAnagrafica, int IDAttivita);

        List<SingolaAnagraficaAttivitaViewModel> LoadAttivita(int IDAnagrafica);
        void SaveAttivita(int ID, int NumeroIngressi, decimal Importo, string Note);
        void DeleteAttivita(int ID);

        #region  Movimenti e Pagamenti
        List<SingoloMovimentoViewModel> LoadPagamenti(int IDAnagrafica);

        int SavePagamento(SingoloMovimentoViewModel spvm,SingoloUtenteViewModel suvm,bool bIsAutoTrasferimento);

        bool IsMovimentoFiscaleFromCodiceContabile(string codicecontabile);

        #endregion
        bool GetUser(SingoloUtenteViewModel suvm);


        SingoloCodiceContabileViewModel GetCodiceContabileFromCodice(string sCodice);

        string GetComuneFromID(int ID);
        CassaViewModel GetStatoCassa(CassaViewModel cvm);

        

        List<SingoloMovimentoViewModel> GetElencoMovimenti(DateTime data);

        void ApriCassa(CassaViewModel cvm);
        void SalvaChiusuraCassa(CassaViewModel cvm);

        List<CorsoViewModel> GetMatriceCorsi(List<TipoAttivitaViewModel> listaattivita,bool bAll);
        bool StatoAttivazioneCorso(int ID, bool newState);

        void RemoveMovimento(SingoloMovimentoViewModel smvm);
        void UpdateMovimento(SingoloMovimentoViewModel smvm);

        #region Accoglienza
        bool StatoAttivazioneDataAnagraficaAttivita(int ID,  bool newState);

        bool CheckForRinnovo(string sCodiceFiscale, string sAttivita);
        #endregion
        #region Contabilita
        List<SingoloCodiceContabileViewModel> GetElencoCodiciContabili(bool bAll,bool? bExtra);
        List<SingoloDettaglioCodiceContabileViewModel> GetDettagliCodiceContabile(string Codice);

        void AddDettaglioCodiceContabile(SingoloCodiceContabileViewModel CodiceContabile, SingoloDettaglioCodiceContabileViewModel cd);
        void RemoveDettaglioCodiceContabile(SingoloDettaglioCodiceContabileViewModel dettaglio);
        bool CheckForDettagliMovimento(string sCodice);

        List<ModalitaPagamentoViewModel> GetElencoModalitaPagamento(bool bAll);
        bool IsModalitaPagamento(string codice);
        bool UpdateModalitaPagamento(ModalitaPagamentoViewModel mpvm);
        void DeleteModalitaPagamento(ModalitaPagamentoViewModel mpvm);
        bool IsCodiceContabile(string codice);
        bool UpdateCodiceContabile(SingoloCodiceContabileViewModel mpvm);
        void DeleteCodiceContabile(SingoloCodiceContabileViewModel mpvm);
        List<SingoloCodiceContabileViewModel> GetElencoAltriMovimenti();

        List<CassaViewModel> GetElencoCasseNonValidate();

        List<SingoloMovimentoViewModel> GetElencoMovimentiCassa(CassaViewModel cvm);

        void ConvalidaCassa(CassaViewModel cvm);

        List<SingolaFatturaViewModel> GetElencoRichiestaFatture();

        ModalitaPagamentoViewModel GetModalitaPagamentoFromID(string Key);

        void RegistraFattura(SingolaFatturaViewModel sfvm);

        List<SingoloTrasferimentoViewModel> GetElencoTrasferimenti();


        void TraferisciContabilita(ElementoMatriceTrasferimentoViewModel stvm);

        List<SingoloMovimentoViewModel> GetElencoAltriPagamenti(DateTime Data);

        void DeleteMovimento(SingoloMovimentoViewModel smvm);

        List<ScontrinoViewModel> GetScontrinoFromMovimento(int IDMovimento);

        #endregion

        #region TabelleAnagrafiche
        bool UpdateLuogoNascita(SingoloLuogoNascitaViewModel mpvm);
        void DeleteLuogoNascita(SingoloLuogoNascitaViewModel mpvm);
        List<SingoloLuogoNascitaViewModel> GetTabellaLuoghiNascita(string txtFiltro);

        bool UpdateComuneResidenza(SingoloComuneResidenzaViewModel mpvm);
        void DeleteComuneResidenza(SingoloComuneResidenzaViewModel mpvm);
        List<SingoloComuneResidenzaViewModel> GetTabellaComuniResidenza(string txtFiltro);
        #endregion

        #region Utenti
        bool IsUser(string user);
        void DeleteUtente(SingoloUtenteViewModel mpvm);
        bool UpdateUtente(SingoloUtenteViewModel mpvm);
        void UpdateUtentePassword(SingoloUtenteViewModel mpvm,string pwd);
        List<SingoloUtenteViewModel> GetTabellaUtenti(bool bShowAll);

        bool CheckForUserAuthorize(SingoloUtenteViewModel suvm);
        #endregion

        #region Attivita
        bool IsTipoAttivita(string stipoattivita);
        bool IsTipoAttivitaErasable(int idTA);
        void DeleteTipoAttivita(TipoAttivitaViewModel mpvm);
        bool UpdateTipoAttivita(TipoAttivitaViewModel mpvm);

        int GetNumeroIscrizioni(int idAttivita);

        ObservableCollection<SingolaDataAttivitaViewModel> AddSingoloIngresso(int IDAnagraficaAttivita, DateTime DataInizio, DateTime DataFine,bool bIsAbbonamento);

        List<AnagraficaROViewModel> GetElencoIscritti(int idAttivita);

        List<TipoAttivitaROViewModel> GetElencoTipiAttivitaForAnagrafica(int IDAnagrafica);
        List<string> GetElencoDateAttivita(int IDAnagraficaAttivita);

        bool RinnovoAttivita(string sCodiceFiscale, string sAttivita);
        #endregion
        #region CORSI
        CorsoEditViewModel GetCorso(int ID);
        void UpdateCorso(CorsoEditViewModel cevm);
        void RemoveCorso(CorsoEditViewModel cevm);

        ROCorsoViewModel GetROCorso(int ID);
        string GetNoteCorsoFromIDAnagraficaAttivita(int IDAA);
        #endregion
        #region Programmazione-Corsi
        void SaveProgrammazione(SingolaAttivitaViewModel sa);
        List<SingolaAttivitaViewModel> GetElencoAttivitaProgrammate(int ID,bool bAll);
        bool StatoAttivazioneProgrammazione(int ID, bool newState);
        void RemoveProgrammazione(SingolaAttivitaViewModel savm);

        #endregion
        #region Configurazione
        bool CheckForCodiceISTAT(string stringValue);
        #endregion
        #region ReportPersonalizzati
        List<ReportPersonalizzatoViewModel> GetElencoReport();
        ReportPersonalizzatoViewModel GetReport(int ID);

        void ReportSaveQuery(int ID,string Query);
        #endregion

        #region
        LogTornelliViewModel CheckIngresso(QRCodeViewModel.QrCodeEntry qe, DateTime data, int mmAnticipoApertura, int mmAnticipoChiusura);
            void SaveTornelloLog(LogTornelliViewModel log, bool IsSimulazione, bool IsEntrataGarantita);
            void SalvaPresenza(LogTornelliViewModel log);
        void UpdateStatoPresenza(int ID, bool stato);

        #endregion

    }
}
