using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class StampaRicevutaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the StampaRicevutaViewModel class.
        /// </summary>
        /// 
        const int MAX_DATE = 30;
        IDataService dataservice;
        public StampaRicevutaViewModel(IDataService ds)
        {
             if(ViewModelBase.IsInDesignModeStatic)
            {
                NumeroRicevuta = 1;

                Anagrafica = new AnagraficaROViewModel();
                Anagrafica.Cognome = "Giorato";
                Anagrafica.Nome = "Michela";
                Anagrafica.CAP = "30010";
                Anagrafica.Indirizzo = "Via Dante, 1";
                Anagrafica.CodiceFiscale = "GRTMHL70R67G224A";

                Pagamento = new SingoloMovimentoViewModel();
                Pagamento.DataPagamento = DateTime.Now;
                Pagamento.ImportoPagato = 150;
                Pagamento.Descrizione = "Scuola nuoto adulti dal 01/09/2016 al 31/12/2016 (Lunedi: 19:00 - 19:45 - Giovedì:19:00 - 19:45)";
                Pagamento.ModalitaPagamento = new ModalitaPagamentoViewModel();
                Pagamento.ModalitaPagamento.Key = "C";
                Pagamento.ModalitaPagamento.Descrizione = "Contanti";
                Pagamento.User = "Cassiera";
                Pagamento.Segno = -1;
            }
            else
            {
                dataservice = ds;
                for (int i = 0; i < MAX_DATE; i++)
                    _Data[i] = string.Empty;
                Anagrafica = new AnagraficaROViewModel(SimpleIoc.Default.GetInstance<AnagraficaViewModel>());
                Pagamento = SimpleIoc.Default.GetInstance<PagamentiViewModel>().CurrentPagamento;


            }
        }

        /// <summary>
        /// The <see cref="Data" /> property's name.
        /// </summary>
        public const string DataPropertyName = "Data";

        private string[] _Data = new string[MAX_DATE];

        /// <summary>
        /// Sets and gets the Data property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string[] Data
        {
            get
            {
                return _Data;
            }

            set
            {
                if (_Data == value)
                {
                    return;
                }

                _Data = value;
                RaisePropertyChanged(DataPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ComuneResidenza" /> property's name.
        /// </summary>
        public const string ComuneResidenzaPropertyName = "ComuneResidenza";

        

        /// <summary>
        /// Sets and gets the ComuneResidenza property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ComuneResidenza
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                    return "Camponogara (VE)";
                else
                {
                    if (Anagrafica != null && Anagrafica.IDComuneResidenza >= 0)
                        return dataservice.GetComuneFromID(Anagrafica.IDComuneResidenza);
                    else
                        return string.Empty;
                }
            }

        }
        //}
        /// <summary>
        /// The <see cref="NumeroRicevuta" /> property's name.
        /// </summary>
        public const string NumeroRicevutaPropertyName = "NumeroRicevuta";

        private int _numeroRicevuta = 0;

        /// <summary>
        /// Sets and gets the NumeroRicevuta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumeroRicevuta
        {
            get
            {
                return _numeroRicevuta;
            }

            set
            {
                if (_numeroRicevuta == value)
                {
                    return;
                }

                _numeroRicevuta = value;
                RaisePropertyChanged(NumeroRicevutaPropertyName);
            }
        }

       
        /// <summary>
        /// The <see cref="Anagrafica" /> property's name.
        /// </summary>
        public const string AnagraficaPropertyName = "Anagrafica";

        private AnagraficaROViewModel _anagraficaViewModel = null;

        /// <summary>
        /// Sets and gets the Anagrafica property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AnagraficaROViewModel Anagrafica
        {
            get
            {
                return _anagraficaViewModel;
            }

            set
            {
                if (_anagraficaViewModel != value)
                    _anagraficaViewModel = value;

                RaisePropertyChanged(AnagraficaPropertyName);
                RaisePropertyChanged(ComuneResidenzaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Pagamento" /> property's name.
        /// </summary>
        public const string PagamentoPropertyName = "Pagamento";

        private SingoloMovimentoViewModel _pagamento = null;

        /// <summary>
        /// Sets and gets the Pagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloMovimentoViewModel Pagamento
        {
            get
            {
                return _pagamento;
            }

            set
            {

                for (int i = 0; i < MAX_DATE; i++)
                    _Data[i] = string.Empty;

                _pagamento = value;
              
                

                // Devo Calcolare le date del corso
                if (Pagamento.IDAnagraficaAttivita >= 0)
                {

                    List<string> dl =  dataservice.GetElencoDateAttivita(Pagamento.IDAnagraficaAttivita);
                    for (int i = 0; i < Math.Min(MAX_DATE, dl.Count); i++)
                        _Data[i] = dl[i];
                   
                }
                RaisePropertyChanged(DataPropertyName);

                RaisePropertyChanged(PagamentoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="QRCode" /> property's name.
        /// </summary>
        public const string QRCodePropertyName = "QRCode";

        private BitmapImage _qRCode = null;

        /// <summary>
        /// Sets and gets the QRCode property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public BitmapImage QRCode
        {
            get
            {
                return _qRCode;
            }

            set
            {
                if (_qRCode == value)
                {
                    return;
                }

                _qRCode = value;
                RaisePropertyChanged(QRCodePropertyName);
            }
        }
    }
}