using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingoloMovimentoModificaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SingoloMovimentoViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        [PreferredConstructor]
        public SingoloMovimentoModificaViewModel()
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                ImportoPagato = 999;
                //ModalitaPagamento = "C";
                //Descrizione = "Descrizione di prova";
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
        /// <summary>
        /// The <see cref="ImportoPagato" /> property's name.
        /// </summary>
        public const string ImportoPagatoPropertyName = "ImportoPagato";

        private decimal _importoPagato = 0;

        /// <summary>
        /// Sets and gets the Importo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoPagato
        {
            get
            {
                return _importoPagato;
            }

            set
            {
                if (_importoPagato == value)
                {
                    return;
                }

                _importoPagato = value;
//                Sconto = ImportoPagare - ImportoPagato;
                RaisePropertyChanged(ImportoPagatoPropertyName);
            }
        }




        /// <summary>
        /// The <see cref="ModalitaPagamento" /> property's name.
        /// </summary>
        public const string ModalitaPagamentoPropertyName = "ModalitaPagamento";

        private string _modalitaPagamento = "";

        /// <summary>
        /// Sets and gets the ModalitaPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ModalitaPagamento
        {
            get
            {
                return _modalitaPagamento;
            }

            set
            {
                if (_modalitaPagamento == value)
                {
                    return;
                }

                _modalitaPagamento = value;
                
                RaisePropertyChanged(ModalitaPagamentoPropertyName);
            }
        }


        /// <summary>
        /// The <see cref="ElencoModalitaPagamento" /> property's name.
        /// </summary>
        public const string ElencoModalitaPagamentoPropertyName = "ElencoModalitaPagamento";

        private List<ModalitaPagamentoViewModel> _elencoModalitaPagamento = null;

        /// <summary>
        /// Sets and gets the ElencoModalitaPagamento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ModalitaPagamentoViewModel> ElencoModalitaPagamento
        {
            get
            {
                if (_elencoModalitaPagamento == null)
                {
                    _elencoModalitaPagamento = dataservice.GetElencoModalitaPagamento(false);
                }

                return _elencoModalitaPagamento;
            }

            set
            {
                if (_elencoModalitaPagamento == value)
                {
                    return;
                }

                _elencoModalitaPagamento = value;
                RaisePropertyChanged(ElencoModalitaPagamentoPropertyName);
            }
        }

    }
}