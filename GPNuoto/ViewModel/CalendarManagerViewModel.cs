using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GPNuoto.ViewModel
{
    public class ItemSettimanale:ViewModelBase
    {
        /// <summary>
        /// The <see cref="FrazioneOraria" /> property's name.
        /// </summary>
        public const string FrazioneOrariaPropertyName = "FrazioneOraria";

        private TimeSpan _frazioneOraria;

        /// <summary>
        /// Sets and gets the FrazioneOraria property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan FrazioneOraria
        {
            get
            {
                return _frazioneOraria;
            }

            set
            {
                if (_frazioneOraria == value)
                {
                    return;
                }

                _frazioneOraria = value;
                RaisePropertyChanged(FrazioneOrariaPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="Settimana" /> property's name.
        /// </summary>
        public const string SettimanaPropertyName = "Settimana";

        private List<ItemCalendario>[] _settimana = new List<ItemCalendario>[7];

        /// <summary>
        /// Sets and gets the Settimana property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ItemCalendario>[] Settimana
        {
            get
            {
                return _settimana;
            }

            set
            {
                if (_settimana == value)
                {
                    return;
                }

                _settimana = value;
                RaisePropertyChanged(SettimanaPropertyName);
            }
        }

    }
    public class ItemCalendario:ViewModelBase
    {
        public int idCorso { get; set; }
        /// <summary>
        /// The <see cref="BackgroundColor" /> property's name.
        /// </summary>
        public const string BackgroundColorPropertyName = "BackgroundColor";

        private string _backgroundColor = string.Empty;

        /// <summary>
        /// Sets and gets the BackgroundColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }

            set
            {
                if (_backgroundColor == value)
                {
                    return;
                }

                _backgroundColor = value;
                RaisePropertyChanged(BackgroundColorPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="ForegroundColor" /> property's name.
        /// </summary>
        public const string ForegroundColorPropertyName = "ForegroundColor";

        private string _foregroundColor = string.Empty;

        /// <summary>
        /// Sets and gets the ForegroundColor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ForegroundColor
        {
            get
            {
                return _foregroundColor;
            }

            set
            {
                if (_foregroundColor == value)
                {
                    return;
                }

                _foregroundColor = value;
                RaisePropertyChanged(ForegroundColorPropertyName);
            }
        }
    }


    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CalendarManagerViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the CalendarManagerViewModel class.
        /// </summary>
        /// 
       
        private IDataService dataservice;
        public CalendarManagerViewModel(IDataService ds)
        {
           
            if (ViewModelBase.IsInDesignModeStatic)
            {
                ElencoTipoAttivita = new List<TipoAttivitaViewModel>();
                ElencoCorsiSelezionati = new List<CorsoViewModel>();

                CorsoViewModel cvm = new CorsoViewModel();
                cvm.TipoAttivita = new TipoAttivitaViewModel();
                cvm.TipoAttivita.BackgroundColor = "#0824f9";
                cvm.TipoAttivita.ForegroundColor = "#ffffff";
                
                cvm.ID = 1;
                cvm.Titolo = "Scuola nuoto adulti - Lun/Gio - 19:00";
                cvm.Note = "Una nota del corso";
                CorsoSelezionato = cvm;
                ElencoCorsiSelezionati.Add(cvm);
                cvm = new CorsoViewModel();
                cvm.TipoAttivita = new TipoAttivitaViewModel();
                cvm.TipoAttivita.BackgroundColor = "Red";
                cvm.TipoAttivita.ForegroundColor = "White";
                cvm.ID = 1;
                cvm.Titolo = "Scuola nuoto adulti - Lun/Gio - 19:45";
                cvm.Note = "Una nota del corso";
                cvm.ElencoAttivita = new List<SingolaAttivitaViewModel>();
                SingolaAttivitaViewModel savm = new SingolaAttivitaViewModel(dataservice);
                savm.ID = 1;
                savm.Titolo = "Gen-Mar";
                savm.DataFine = new DateTime(2017, 3, 31);
                savm.DataInizio = new DateTime(2017,1,1);
                savm.IsAttivo = true;
                cvm.ElencoAttivita.Add(savm);
                CorsoSelezionato = cvm;
                ElencoCorsiSelezionati.Add(cvm);
                CorsoSelezionato = cvm;
                
                MatriceCorsi = new List<ItemSettimanale>();
                ItemSettimanale iso = new ItemSettimanale();
                iso.FrazioneOraria = TimeSpan.FromMinutes(5 * 104);
                iso.Settimana[1] = new List<ItemCalendario>();
                ItemCalendario ic = new ItemCalendario();
                ic.idCorso = 63;
                ic.ForegroundColor = "White";
                ic.BackgroundColor = "Blue";
                iso.Settimana[1].Add(ic);
                ic = new ItemCalendario();
                ic.idCorso = 64;
                ic.ForegroundColor = "White";
                ic.BackgroundColor = "Red";
                iso.Settimana[1].Add(ic);


                MatriceCorsi.Add(iso);

                iso = new ItemSettimanale();
                iso.FrazioneOraria = TimeSpan.FromMinutes(5 * 105);
                iso.Settimana[1] = new List<ItemCalendario>();
                ic = new ItemCalendario();
                ic.idCorso = 63;
                ic.ForegroundColor = "White";
                ic.BackgroundColor = "Blue";
                iso.Settimana[1].Add(ic);
                ic = new ItemCalendario();
                ic.idCorso = 64;
                ic.ForegroundColor = "White";
                ic.BackgroundColor = "Red";
                iso.Settimana[1].Add(ic);
                MatriceCorsi.Add(iso);

                iso = new ItemSettimanale();
                iso.FrazioneOraria = TimeSpan.FromMinutes(5 * 106);
                iso.Settimana[1] = new List<ItemCalendario>();
                ic = new ItemCalendario();
                ic.idCorso = 63;
                ic.ForegroundColor = "White";
                ic.BackgroundColor = "Blue";
                iso.Settimana[1].Add(ic);
                ic = new ItemCalendario();
                ic.idCorso = 64;
                ic.ForegroundColor = "White";
                ic.BackgroundColor = "Red";
                iso.Settimana[1].Add(ic);
                MatriceCorsi.Add(iso);


                CorsoEdit = new CorsoEditViewModel();
                
                CorsoEdit.Titolo = "Prova";
                CorsoEdit.EditElencoOrari = new ObservableCollection<OrarioCorsoViewModel>();
                OrarioCorsoViewModel ocvm = new OrarioCorsoViewModel();
                ocvm.GiornoSettimana = DayOfWeek.Monday;
                ocvm.OraInizio = new TimeSpan(8, 15, 0);
                ocvm.OraFine = new TimeSpan(9, 0, 0);
                CorsoEdit.EditElencoOrari.Add(ocvm);


            }
            else
            {
                dataservice = ds;
                
            }
        }

        public void ChangedTipoAttivita()
        {
            MatriceCorsi = CalcolaCalendario();

        }

        /// <summary>
        /// The <see cref="MatriceCorsi" /> property's name.
        /// </summary>
        public const string MatriceCorsiPropertyName = "MatriceCorsi";

        private  List<ItemSettimanale> _matriceCorsi = null;

        /// <summary>
        /// Sets and gets the MatriceCorsi property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ItemSettimanale> MatriceCorsi
        {
            get
            {
                return _matriceCorsi;
            }
           
            set
            {
                if (_matriceCorsi == value)
                {
                    return;
                }

                _matriceCorsi = value;
                RaisePropertyChanged(MatriceCorsiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoCorsiSelezionati" /> property's name.
        /// </summary>
        public const string ElencoCorsiSelezionatiPropertyName = "ElencoCorsiSelezionati";

        private List<CorsoViewModel> _elencoCorsiSelezionati = null;

        /// <summary>
        /// Sets and gets the ElencoCorsiSelezionati property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<CorsoViewModel> ElencoCorsiSelezionati
        {
            get
            {
                return _elencoCorsiSelezionati;
            }

            set
            {
                if (_elencoCorsiSelezionati == value)
                {
                    return;
                }

                _elencoCorsiSelezionati = value;
                RaisePropertyChanged(ElencoCorsiSelezionatiPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CorsoSelezionato" /> property's name.
        /// </summary>
        public const string CorsoSelezionatoPropertyName = "CorsoSelezionato";

        private CorsoViewModel _corsoSelezionato = null;

        /// <summary>
        /// Sets and gets the CorsoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CorsoViewModel CorsoSelezionato
        {
            get
            {
                return _corsoSelezionato;
            }

            set
            {
                if (_corsoSelezionato == value)
                {
                    return;
                }

                _corsoSelezionato = value;
                CorsoHaveProgrammazioneSettimanale = (_corsoSelezionato != null && _corsoSelezionato.ProgrammazioneSettimanale.Count() != 0);
                RaisePropertyChanged(CorsoSelezionatoPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CorsoHaveProgrammazioneSettimanale" /> property's name.
        /// </summary>
        public const string CorsoHaveProgrammazioneSettimanalePropertyName = "CorsoHaveProgrammazioneSettimanale";

        private bool _corsoHaveProgrammazioneSettimanale = false;

        /// <summary>
        /// Sets and gets the CorsoHaveProgrammazioneSettimanale property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CorsoHaveProgrammazioneSettimanale
        {
            get
            {
                return _corsoHaveProgrammazioneSettimanale;
            }

            set
            {
                if (_corsoHaveProgrammazioneSettimanale == value)
                {
                    return;
                }

                _corsoHaveProgrammazioneSettimanale = value;
                RaisePropertyChanged(CorsoHaveProgrammazioneSettimanalePropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CorsoEdit" /> property's name.
        /// </summary>
        public const string CorsoEditPropertyName = "CorsoEdit";

        private CorsoEditViewModel _corsoEdit = null;

        /// <summary>
        /// Sets and gets the CorsoSelezionato property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CorsoEditViewModel CorsoEdit
        {
            get
            {
                return _corsoEdit;
            }

            set
            {
                if (_corsoEdit == value)
                {
                    return;
                }

                _corsoEdit = value;
                RaisePropertyChanged(CorsoEditPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SingolaAttivitaEdit" /> property's name.
        /// </summary>
        public const string SingolaAttivitaEditPropertyName = "SingolaAttivitaEdit";

        private SingolaAttivitaViewModel _singolaAttivitaEdit = null;

        /// <summary>
        /// Sets and gets the SingolaAttivitaEdit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SingolaAttivitaViewModel SingolaAttivitaEdit
        {
            get
            {
                return _singolaAttivitaEdit;
            }

            set
            {
                if (_singolaAttivitaEdit == value)
                {
                    return;
                }

                _singolaAttivitaEdit = value;
                RaisePropertyChanged(SingolaAttivitaEditPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="IsShowAll" /> property's name.
        /// </summary>
        public const string IsShowAllPropertyName = "IsShowAll";

        private bool _isShowAll = false;

        /// <summary>
        /// Sets and gets the IsShowAll property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsShowAll
        {
            get
            {
                return _isShowAll;
            }

            set
            {
                if (_isShowAll == value)
                {
                    return;
                }

                _isShowAll = value;
                SimpleIoc.Default.GetInstance<TableTipoAttivitaViewModel>().bShowAll = value;
                RaisePropertyChanged(IsShowAllPropertyName);
            }
        }



        private List<ItemSettimanale> CalcolaCalendario()
        {
            ElencoTipoAttivita = SimpleIoc.Default.GetInstance<TableTipoAttivitaViewModel>().Elenco.Where(p => p.IsSelezionata).ToList();
            
            ElencoCorsiSelezionati = dataservice.GetMatriceCorsi(ElencoTipoAttivita,IsShowAll);

            Dictionary<int,ItemSettimanale> MC= new Dictionary<int,ItemSettimanale>();

            foreach(CorsoViewModel c in ElencoCorsiSelezionati.Where(p=>p.IsAttivo))
                foreach(OrarioCorsoViewModel oc in c.ProgrammazioneSettimanale)
                {
                    int iStart = (((int)oc.OraInizio.TotalMinutes) / 5);
                    int iEnd = (((int)oc.OraFine.TotalMinutes)/5)-1;
                    for(int j=iStart;j<=iEnd;j++)
                    {
                        if (!MC.ContainsKey(j))
                        {
                            ItemSettimanale set = new ItemSettimanale();
                            set.FrazioneOraria = TimeSpan.FromMinutes(j*5);
                            MC.Add(j, set);
                        }

                        ItemCalendario ic = new ItemCalendario();
                        ic.idCorso = c.ID;
                        ic.ForegroundColor = c.TipoAttivita.ForegroundColor;
                        ic.BackgroundColor = c.TipoAttivita.BackgroundColor;


                         if (MC[j].Settimana[(int)oc.GiornoSettimana] == null)
                            MC[j].Settimana[(int)oc.GiornoSettimana] = new List<ItemCalendario>();
                        MC[j].Settimana[(int)oc.GiornoSettimana].Add(ic);
                    }
                }
            return MC.OrderBy(key => key.Key).Select(p=>p.Value).ToList<ItemSettimanale>();
            
        }
        /// <summary>
        /// The <see cref="ItemsCalendarioAttivita" /> property's name.
        /// <</summary>
        public const string ItemsCalendarioAttivitaPropertyName = "ItemsCalendarioAttivita";

        private List<ItemCalendario> _itemsCalendarioAttivita = null;

        /// <summary>
        /// Sets and gets the ItemsCalendarioAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ItemCalendario> ItemsCalendarioAttivita
        {
            get
            {
                return _itemsCalendarioAttivita;
            }

            set
            {
                if (_itemsCalendarioAttivita == value)
                {
                    return;
                }

                _itemsCalendarioAttivita = value;
                RaisePropertyChanged(ItemsCalendarioAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="ElencoTipoAttivita" /> property's name.
        /// </summary>
        public const string ElencoTipoAttivitaPropertyName = "ElencoTipoAttivita";

        private List<TipoAttivitaViewModel> _elencoTipoAttiviva = new List<TipoAttivitaViewModel>();

        /// <summary>
        /// Sets and gets the ElencoTipoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<TipoAttivitaViewModel> ElencoTipoAttivita
        {
            get
            {
                return _elencoTipoAttiviva;
            }

            set
            {
                if (_elencoTipoAttiviva == value)
                {
                    return;
                }

                _elencoTipoAttiviva = value;
                RaisePropertyChanged(ElencoTipoAttivitaPropertyName);
            }
        }

        
        private RelayCommand<CorsoViewModel> _invertiStatoAttivazioneCorso;

        /// <summary>
        /// Gets the InvertiStatoAttivazioneCorso.
        /// </summary>
        public RelayCommand<CorsoViewModel> InvertiStatoAttivazioneCorso
        {
            get
            {
                return _invertiStatoAttivazioneCorso
                    ?? (_invertiStatoAttivazioneCorso = new RelayCommand<CorsoViewModel>(
                    p =>
                    {
                        p.IsAttivo =  dataservice.StatoAttivazioneCorso(p.ID, !p.IsAttivo);
                        CorsoSelezionato = null;
                        MatriceCorsi = CalcolaCalendario();
                    }));
            }
        }


        private RelayCommand<SingolaAttivitaViewModel> _invertiStatoAttivazioneProgrammazione;

        /// <summary>
        /// Gets the InvertiStatoAttivazioneCorso.
        /// </summary>
        public RelayCommand<SingolaAttivitaViewModel> InvertiStatoAttivazioneProgrammazione
        {
            get
            {
                return _invertiStatoAttivazioneProgrammazione
                    ?? (_invertiStatoAttivazioneProgrammazione = new RelayCommand<SingolaAttivitaViewModel>(
                    p =>
                    {
                        p.IsAttivo = dataservice.StatoAttivazioneProgrammazione(p.ID, !p.IsAttivo);
                        CorsoSelezionato.RefreshElencoAttivita(IsShowAll);
                    }));
            }
        }


        private RelayCommand _addAttivita;

        /// <summary>
        /// Gets the AddAttivita.
        /// </summary>
        public RelayCommand AddAttivita
        {
            get
            {
                return _addAttivita
                    ?? (_addAttivita = new RelayCommand(
                    () =>
                    {
                        CorsoEdit = new CorsoEditViewModel();
                        CorsoEdit.TipoAttivita = ElencoTipoAttivita.First();
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgettazioneCalendario>(new ShowEditProgettazioneCalendario(true));
                    }));
            }
        }

        private RelayCommand _annullaEditAttivita;

        /// <summary>
        /// Gets the AnnullaEdit.
        /// </summary>
        public RelayCommand AnnullaEditAttivita
        {
            get
            {
                return _annullaEditAttivita
                    ?? (_annullaEditAttivita = new RelayCommand(
                    () =>
                    {
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgettazioneCalendario>(new ShowEditProgettazioneCalendario(false));

                    }));
            }
        }

        private RelayCommand __salvaModificheAttivita;

        /// <summary>
        /// Gets the AnnullaEdit.
        /// </summary>
        public RelayCommand SalvaModificheAttivita
        {
            get
            {
                return __salvaModificheAttivita
                    ?? (__salvaModificheAttivita = new RelayCommand(
                    () =>
                    {
                        dataservice.UpdateCorso(CorsoEdit);
                        CorsoEdit = null;
                        MatriceCorsi = CalcolaCalendario();
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgettazioneCalendario>(new ShowEditProgettazioneCalendario(false));

                    }));
            }
        }

        private RelayCommand __deleteAttivita;

        /// <summary>
        /// Gets the DeleteAttivita.
        /// </summary>
        public RelayCommand DeleteAttivita
        {
            get
            {
                return __deleteAttivita
                    ?? (__deleteAttivita = new RelayCommand(
                    () =>
                    {
                        dataservice.RemoveCorso(CorsoEdit);
                        CorsoEdit = null;
                        MatriceCorsi = CalcolaCalendario();
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgettazioneCalendario>(new ShowEditProgettazioneCalendario(false));

                    }));
            }
        }



        private RelayCommand __editAttivita;

        /// <summary>
        /// Gets the AnnullaEdit.
        /// </summary>
        public RelayCommand EditAttivita
        {
            get
            {
                return __editAttivita
                    ?? (__editAttivita = new RelayCommand(
                    () =>
                    {
                        // Copia del corso selezionato
                        CorsoEditViewModel cevm = dataservice.GetCorso(CorsoSelezionato.ID);
                        List<TipoAttivitaViewModel> tl = new List<TipoAttivitaViewModel>();
                        tl.Add(cevm.TipoAttivita);
                        ElencoTipoAttivita.Clear(); 
                        ElencoTipoAttivita = tl;
                        cevm.CalcolaGrigliaProgrammazione();
                        cevm.CanSave = false;
                        CorsoEdit =  cevm;

                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgettazioneCalendario>(new ShowEditProgettazioneCalendario(true));
                    }));
            }
        }

        private RelayCommand _addProgrammazione;

        /// <summary>
        /// Gets the AddAttivita.
        /// </summary>
        public RelayCommand AddProgrammazione
        {
            get
            {
                return _addProgrammazione
                    ?? (_addProgrammazione = new RelayCommand(
                    () =>
                    {
                        
                        CorsoEdit = new CorsoEditViewModel();
                        CorsoEdit.ID = CorsoSelezionato.ID;
                        CorsoEdit.TipoAttivita = CorsoSelezionato.TipoAttivita;
                        CorsoEdit.Titolo = CorsoSelezionato.Titolo;
                        CorsoEdit.TipoCorso = CorsoSelezionato.TipoCorso;
                        CorsoEdit.EditElencoOrari = new ObservableCollection<OrarioCorsoViewModel>(CorsoSelezionato.ProgrammazioneSettimanale);
                        SingolaAttivitaEdit = new SingolaAttivitaViewModel(dataservice);
                        SingolaAttivitaEdit.IDCorso = CorsoEdit.ID;
                        SingolaAttivitaEdit.CorsoEdit = CorsoEdit;
                        SingolaAttivitaEdit.CanDelete = false;
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshCalendarioDate>(new RefreshCalendarioDate(SingolaAttivitaEdit));
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgrammazioneCorso>(new ShowEditProgrammazioneCorso(true));
                    }));
            }
        }



        private RelayCommand _annullaEditProgrammazione;

        /// <summary>
        /// Gets the AnnullaEdit.
        /// </summary>
        public RelayCommand AnnullaEditProgrammazione
        {
            get
            {
                return _annullaEditProgrammazione
                    ?? (_annullaEditProgrammazione = new RelayCommand(
                    () =>
                    {
                        CorsoSelezionato.RefreshElencoAttivita(IsShowAll);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgrammazioneCorso>(new ShowEditProgrammazioneCorso(false));

                    }));
            }
        }


        private RelayCommand _saveProgrammazione;

        /// <summary>
        /// Gets the SaveProgrammazione.
        /// </summary>
        public RelayCommand SaveProgrammazione
        {
            get
            {
                return _saveProgrammazione
                    ?? (_saveProgrammazione = new RelayCommand(
                    () =>
                    {
                        if (SingolaAttivitaEdit != null)
                        {
                            dataservice.SaveProgrammazione(SingolaAttivitaEdit);
                            CorsoSelezionato.RefreshElencoAttivita(IsShowAll);
                            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgrammazioneCorso>(new ShowEditProgrammazioneCorso(false));
                        }

                    }));
            }
        }


        private RelayCommand<SingolaAttivitaViewModel> _editProgrammazione;

        /// <summary>
        /// Gets the AddAttivita.
        /// </summary>
        public RelayCommand<SingolaAttivitaViewModel> EditProgrammazione
        {
            get
            {
                return _editProgrammazione
                    ?? (_editProgrammazione = new RelayCommand<SingolaAttivitaViewModel>(
                    (savm) =>
                    {
                        SingolaAttivitaEdit = savm;
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshCalendarioDate>(new RefreshCalendarioDate(SingolaAttivitaEdit));
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgrammazioneCorso>(new ShowEditProgrammazioneCorso(true));
                    }));
            }
        }

        private RelayCommand _deleteProgrammazione;

        /// <summary>
        /// Gets the DeleteProgrammazione.
        /// </summary>
        public RelayCommand DeleteProgrammazione
        {
            get
            {
                return _deleteProgrammazione
                    ?? (_deleteProgrammazione = new RelayCommand(()=>
                    {
                        dataservice.RemoveProgrammazione(SingolaAttivitaEdit);
                        CorsoSelezionato.RefreshElencoAttivita(IsShowAll);
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<ShowEditProgrammazioneCorso>(new ShowEditProgrammazioneCorso(false));
                    }));
            }
        }

    }
}