using GalaSoft.MvvmLight;
using GPNuoto.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPNuoto.Model
{

    public class ShowSelezioneAttivita : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool ShowWindow { get; set; }
        public ShowSelezioneAttivita(bool showDialog)
            : base(showDialog)
        {
            ShowWindow = showDialog;
        }
    }
    public class ShowStampaRicevuta : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool ShowWindow { get; set; }
        public ShowStampaRicevuta(bool showDialog)
            : base(showDialog)
        {
            ShowWindow = showDialog;
        }
    }


    
    public class ShowSelezioneTipoAttivita : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool ShowWindow { get; set; }
        public ShowSelezioneTipoAttivita(bool showDialog)
            : base(showDialog)
        {
            ShowWindow = showDialog;
        }
    }

    public class ShowEditAttivita : GalaSoft.MvvmLight.Messaging.GenericMessage<SingolaAnagraficaAttivitaViewModel>
    {
        public SingolaAnagraficaAttivitaViewModel DataContext { get; set; }
        public ShowEditAttivita(SingolaAnagraficaAttivitaViewModel dc)
            : base(dc)
        {
            DataContext = dc;
        }
    }

    public class ShowEditDateAttivita : GalaSoft.MvvmLight.Messaging.GenericMessage<SingolaAnagraficaAttivitaViewModel>
    {
        public SingolaAnagraficaAttivitaViewModel DataContext { get; set; }
        public ShowEditDateAttivita(SingolaAnagraficaAttivitaViewModel dc)
            : base(dc)
        {
            DataContext = dc;
        }
    }



    public class AddSingoloIngresso : GalaSoft.MvvmLight.Messaging.GenericMessage<SelezioneIntervalloTempoModel>
    {
        public SelezioneIntervalloTempoModel IntervalloTempo { get; set; }
        public AddSingoloIngresso(SelezioneIntervalloTempoModel it)
            : base(it)
        {
            IntervalloTempo = it;
        }
    }


    public class ShowEditPagamento : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditPagamento(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }

    public class ShowEditAltriMovimenti : GalaSoft.MvvmLight.Messaging.GenericMessage<SingoloMovimentoViewModel>
    {
        public SingoloMovimentoViewModel dataContext { get; set; }
        public ShowEditAltriMovimenti(SingoloMovimentoViewModel smvm)
            : base(smvm)
        {
            dataContext = smvm;
        }
    }

 

    public class ShowEditModalitaPagamento : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditModalitaPagamento(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }

    public class ShowEditLuogoNascita : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditLuogoNascita(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }

    public class ShowEditComuneResidenza : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditComuneResidenza(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }
    public class ShowEditUtenti : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditUtenti(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }

    public class ShowEditTipoPagamentoVario : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditTipoPagamentoVario(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }


    public class ShowEditCodiciContabili : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditCodiciContabili(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }

    public class ShowGestioneCodiciContabili : GalaSoft.MvvmLight.Messaging.GenericMessage<SingoloCodiceContabileViewModel>
    {
        public SingoloCodiceContabileViewModel CodiceContabile { get; set; }
        public ShowGestioneCodiciContabili(SingoloCodiceContabileViewModel obj)
            :base(obj)
        {
            CodiceContabile = obj;
        }
    }


    public class ShowEditTipoAttivitaCorsi : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditTipoAttivitaCorsi(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }

    public class ShowEditProgettazioneCalendario : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditProgettazioneCalendario(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }
    public class ShowEditPagamentiVari : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditPagamentiVari(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }

    public class ShowEditProgrammazioneCorso : GalaSoft.MvvmLight.Messaging.GenericMessage<bool>
    {
        public bool bShow { get; set; }
        public ShowEditProgrammazioneCorso(bool bshow)
            : base(bshow)
        {
            bShow = bshow;
        }
    }


    public class RefreshCalendarioCorsi : GalaSoft.MvvmLight.Messaging.MessageBase
    {
    }


    public class RefreshReportPersonalizzato : GalaSoft.MvvmLight.Messaging.GenericMessage<ReportPersonalizzatoViewModel>
    {

        ReportPersonalizzatoViewModel  Report { get; set; }
        public RefreshReportPersonalizzato(ReportPersonalizzatoViewModel rpt)
          : base(rpt)
        {
            Report = rpt;
        }
    }


    public class StampaRicevuta : GalaSoft.MvvmLight.Messaging.MessageBase
    {
    }

    public class ShowAddMovimento : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public bool bShow;
        public ShowAddMovimento(bool Show)
        {
            bShow = Show;
        }
    }

    public class StampaRicevutaFiscale : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public SingoloMovimentoViewModel movimento;
        public StampaRicevutaFiscale(SingoloMovimentoViewModel sm)
        {
            movimento = sm;
        }
    }


    public class StampaBadge : GalaSoft.MvvmLight.Messaging.MessageBase
    {
    }


    public class ShowUndoEdit : GalaSoft.MvvmLight.Messaging.GenericMessage<ViewModelBase>
    {
        public ViewModelBase DataContext;
        public ShowUndoEdit(ViewModelBase dc)
            : base(dc)
        {
            DataContext = dc;
        }
    }
    

    public class ShowMessageBoxView : GalaSoft.MvvmLight.Messaging.GenericMessage<string>
    {
        public string   sMessaggio;
        public ShowMessageBoxView(string  messaggio)
            :base(messaggio)
        {
            sMessaggio = messaggio;
            
        }
    }



    public class RefreshCalendarioDate : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public SingolaAttivitaViewModel savm;
        public RefreshCalendarioDate(SingolaAttivitaViewModel _savm)
        {
            savm = _savm;
        }
    }

    public class RefreshCalendarioBlackDate : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public SingolaAttivitaViewModel savm;
        public RefreshCalendarioBlackDate(SingolaAttivitaViewModel _savm)
        {
            savm = _savm;
        }
    }


    //public class RefreshInformazioniAggiuntiveAnagrafica : GalaSoft.MvvmLight.Messaging.MessageBase
    //{
        
    //    public RefreshInformazioniAggiuntiveAnagrafica()
    //    {

    //    }
    //}

    public class ShowLoginView : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public string sMessaggio;
        public ShowLoginView()
        {

        }
    }

    public class ShowAccoglienzaView : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public ShowAccoglienzaView()
        {

        }
    }


    public class ChangeUserLogin : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public string sMessaggio;
        public ChangeUserLogin()
        {

        }
    }


    public class ShowEditTipoAttivita : GalaSoft.MvvmLight.Messaging.MessageBase
    {
        public TipoAttivitaViewModel TAVM;
        public ShowEditTipoAttivita(TipoAttivitaViewModel tavm)
        {
            TAVM = tavm;
        }
    }
}

