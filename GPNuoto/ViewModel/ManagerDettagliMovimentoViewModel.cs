using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GPNuoto.ViewModel
{


    public class ScontrinoViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="Quantita" /> property's name.
        /// </summary>
        public const string QuantitaPropertyName = "Quantita";

        private int _quantita = 0;

        /// <summary>
        /// Sets and gets the Quantita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Quantita
        {
            get
            {
                return _quantita;
            }

            set
            {
                if (_quantita == value)
                {
                    return;
                }

                _quantita = value;
                RaisePropertyChanged(QuantitaPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Codice" /> property's name.
        /// </summary>
        public const string CodicePropertyName = "Codice";

        private string _codice = string.Empty;

        /// <summary>
        /// Sets and gets the Codice property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Codice
        {
            get
            {
                return _codice;
            }

            set
            {
                if (_codice == value)
                {
                    return;
                }

                _codice = value;
                RaisePropertyChanged(CodicePropertyName);
            }

        }

        /// <summary>
        /// The <see cref="ImportoUnitario" /> property's name.
        /// </summary>
        public const string ImportoUnitarioPropertyName = "ImportoUnitario";

        private decimal _importUnitario = 0;

        /// <summary>
        /// Sets and gets the ImportoUnitario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal ImportoUnitario
        {
            get
            {
                return _importUnitario;
            }

            set
            {
                if (_importUnitario == value)
                {
                    return;
                }

                _importUnitario = value;
                RaisePropertyChanged(ImportoUnitarioPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Importo" /> property's name.
        /// </summary>
        public const string ImportoPropertyName = "Importo";

        /// <summary>
        /// Sets and gets the Totale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal Importo
        {
            get
            {
                return _quantita * ImportoUnitario;
            }
        }
    }


    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ManagerDettagliMovimentoViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the FattureViewModel class.
        /// </summary>
        /// 
       



        IDataService dataservice;
        private List<ScontrinoViewModel> ListaScontrino = new List<ScontrinoViewModel>();
        private SingoloMovimentoViewModel MovimentoCorrente;
        public ManagerDettagliMovimentoViewModel(SingoloMovimentoViewModel scvm)
        {
            dataservice = ServiceLocator.Current.GetInstance<IDataService>();
            MovimentoCorrente = scvm;
            if (MovimentoCorrente.DettagliMovimento != null)
            {
                ListaScontrino = MovimentoCorrente.DettagliMovimento;
                Scontrino = ListaScontrino;
            }
            if (ViewModelBase.IsInDesignModeStatic)
            {
                //List<SingoloDettaglioCodiceContabileViewModel> lista = new List<SingoloDettaglioCodiceContabileViewModel>();
                //SingoloDettaglioCodiceContabileViewModel sc1 = new SingoloDettaglioCodiceContabileViewModel();
                //sc1.Descrizione = "Intero";
                //sc1.ImportoPredefinito = 10.0m;
                //lista.Add(sc1);
                //SingoloDettaglioCodiceContabileViewModel sc2 = new SingoloDettaglioCodiceContabileViewModel();
                //sc2.Descrizione = "Ridotto";
                //sc1.ImportoPredefinito = 8.0m;
                //lista.Add(sc2);
                //Elenco = lista;
                //Totale = 100;
                //List<ScontrinoViewModel> listas = new List<ScontrinoViewModel>();
                //ScontrinoViewModel svm = new ScontrinoViewModel();
                //svm.Quantita = 2;
                //svm.Codice = "Intero";
                //listas.Add(svm);
                //svm.Quantita = 3;
                //svm.Codice = sc2;
                //listas.Add(svm);
                //Scontrino = listas;
            }
            else
            {
                CodiceContabile = MovimentoCorrente.MovimentoSelezionato;
                Elenco = dataservice.GetDettagliCodiceContabile(CodiceContabile.Codice);
            }
        }

          

        /// <summary>
        /// The <see cref="CodiceContabile" /> property's name.
        /// </summary>
        public const string CodiceContabilePropertyName = "CodiceContabile";

        private SingoloCodiceContabileViewModel _codiceContabile = null;

        /// <summary>
        /// Sets and gets the CodiceContabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingoloCodiceContabileViewModel CodiceContabile
        {
            get
            {
                return _codiceContabile;
            }

            set
            {
                if (_codiceContabile == value)
                {
                    return;
                }

                _codiceContabile = value;
                //Elenco = null;
                //ElementoSelezionato = null;
                //if (value != null)
                //    Elenco = dataservice.GetDettagliCodiceContabile(CodiceContabile.Codice);
                RaisePropertyChanged(CodiceContabilePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Elenco" /> property's name.
        /// </summary>
        public const string ElencoPropertyName = "Elenco";

        private List<SingoloDettaglioCodiceContabileViewModel> _elenco = null;

        /// <summary>
        /// Sets and gets the Elenco property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<SingoloDettaglioCodiceContabileViewModel> Elenco
        {
            get
            {
                return _elenco;
            }

            set
            {
                if (_elenco == value)
                {
                    return;
                }

                _elenco = value;
                RaisePropertyChanged(ElencoPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Totale" /> property's name.
        /// </summary>
        public const string TotalePropertyName = "Totale";

        private decimal _totale = 0;

        /// <summary>
        /// Sets and gets the Totale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal Totale
        {
            get
            {
                return _totale;
            }

            set
            {
                if (_totale == value)
                {
                    return;
                }

                _totale = value;
                RaisePropertyChanged(TotalePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Scontrino" /> property's name.
        /// </summary>
        public const string ScontrinoPropertyName = "Scontrino";

        private List<ScontrinoViewModel> _scontrino = null;

        /// <summary>
        /// Sets and gets the Scontrino property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ScontrinoViewModel> Scontrino
        {
            get
            {
                return _scontrino;
            }

            set
            {
                if (_scontrino == value)
                {
                    return;
                }

                _scontrino = value;
                RaisePropertyChanged(ScontrinoPropertyName);
            }
        }

        private RelayCommand<SingoloDettaglioCodiceContabileViewModel> _addDettaglio;

        /// <summary>
        /// Gets the AddDettaglio.
        /// </summary>
        public RelayCommand<SingoloDettaglioCodiceContabileViewModel> AddDettaglio
        {
            get
            {
                return _addDettaglio
                    ?? (_addDettaglio = new RelayCommand<SingoloDettaglioCodiceContabileViewModel>(
                    p =>
                    {
                        ScontrinoViewModel elemento = ListaScontrino.Find(x => x.Codice.CompareTo(p.Descrizione)==0);
                        if (elemento != null)
                            elemento.Quantita++;
                        else
                        {
                            ScontrinoViewModel svm = new ScontrinoViewModel();
                            svm.Quantita = 1;
                            svm.Codice = p.Descrizione;
                            svm.ImportoUnitario = p.ImportoPredefinito;
                            ListaScontrino.Add(svm);

                        }
                        CalcolaTotale();
                    }));
            }
        }

        private RelayCommand<SingoloDettaglioCodiceContabileViewModel> _removeDettaglio;

        /// <summary>
        /// Gets the RemoveDettaglio.
        /// </summary>
        public RelayCommand<SingoloDettaglioCodiceContabileViewModel> RemoveDettaglio
        {
            get
            {
                return _removeDettaglio
                    ?? (_removeDettaglio = new RelayCommand<SingoloDettaglioCodiceContabileViewModel>(
                    p =>
                    {
                        ScontrinoViewModel elemento = ListaScontrino.Find(x => x.Codice.CompareTo(p.Descrizione)==0);
                        if (elemento != null)
                        {
                            elemento.Quantita--;
                            if (elemento.Quantita <=0)
                                ListaScontrino.Remove(elemento);
                            CalcolaTotale();
                        }

                    }));
            }
        }

        private RelayCommand<List<ScontrinoViewModel>> _salvaDettagli;

        /// <summary>
        /// Gets the SalvaDettagli.
        /// </summary>
        public RelayCommand<List<ScontrinoViewModel>> SalvaDettagli
        {
            get
            {
                return _salvaDettagli
                    ?? (_salvaDettagli = new RelayCommand<List<ScontrinoViewModel>>(
                    p =>
                    {
                        if (p.Count > 0)
                        {
                            MovimentoCorrente.ImportoPagare = p.Sum(x => x.Importo);
                            string Descrizione = p[0].Quantita.ToString() + "-" + p[0].Codice;
                            for (int k=1;k<p.Count;k++)
                                Descrizione = Descrizione + ";" + p[k].Quantita.ToString() + "-" + p[k].Codice;
                            MovimentoCorrente.Descrizione = CodiceContabile.Descrizione + ":" + Descrizione;
                            MovimentoCorrente.DettagliMovimento = Scontrino;
                        }

                    }));
            }
        }

        void CalcolaTotale()
        {
            Scontrino = null;
            Scontrino = ListaScontrino;
            Totale = ListaScontrino.Sum(p => p.Importo);
        }

    }
}