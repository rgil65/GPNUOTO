using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GPNuoto.Model;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;



namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>

    
    public class TesseraViewModel : ViewModelBase
    {

        
        /// <summary>
        /// Initializes a new instance of the TesseraViewModel class.
        /// </summary>
        /// 
        IDataService dataservice;
        public TesseraViewModel(IDataService ds)
        {

            dataservice = ds;
            if (ViewModelBase.IsInDesignModeStatic)
            {
                Riga0 = "SCUOLA NUOTO ADULTI";
                Riga1 = "Romanato Gilberto";
                Riga2 = "25/10/1965";
                Riga3 = "RMNGBR65R25B554E";
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode("ROMANATO GILBERTO", QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap bitmap = qrCode.GetGraphic(20, Color.Black, Color.White, true);
                using (var memory = new MemoryStream())
                {
                    bitmap.Save(memory, ImageFormat.Png);
                    memory.Position = 0;

                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    QRCode =  bitmapImage;
                }
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

        /// <summary>
        /// The <see cref="Riga0" /> property's name.
        /// </summary>
        public const string Riga0PropertyName = "Riga0";

        private string _riga0 = string.Empty;

        /// <summary>
        /// Sets and gets the Riga1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Riga0
        {
            get
            {
                return _riga0;
            }

            set
            {
                if (_riga0 == value)
                {
                    return;
                }

                _riga0 = value;
                RaisePropertyChanged(Riga0PropertyName);
            }
        }



        /// <summary>
        /// The <see cref="Riga1" /> property's name.
        /// </summary>
        public const string Riga1PropertyName = "Riga1";

        private string _riga1 = string.Empty;

        /// <summary>
        /// Sets and gets the Riga1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Riga1
        {
            get
            {
                return _riga1;
            }

            set
            {
                if (_riga1 == value)
                {
                    return;
                }

                _riga1 = value;
                RaisePropertyChanged(Riga1PropertyName);
            }
        }

        /// <summary>
        /// The <see cref="Riga2" /> property's name.
        /// </summary>
        public const string Riga2PropertyName = "Riga2";

        private string _riga2 = string.Empty;

        /// <summary>
        /// Sets and gets the Riga1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Riga2
        {
            get
            {
                return _riga2;
            }

            set
            {
                if (_riga2 == value)
                {
                    return;
                }

                _riga2 = value;
                RaisePropertyChanged(Riga2PropertyName);
            }
        }



        /// <summary>
        /// The <see cref="Riga3" /> property's name.
        /// </summary>
        public const string Riga3PropertyName = "Riga3";

        private string _riga3 = string.Empty;

        /// <summary>
        /// Sets and gets the Riga1 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Riga3
        {
            get
            {
                return _riga3;
            }

            set
            {
                if (_riga3 == value)
                {
                    return;
                }

                _riga3 = value;
                RaisePropertyChanged(Riga3PropertyName);
            }
        }

        public void Refresh(AnagraficaViewModel avm)
        {
            if (avm != null)
            {
                ElencoTipiAttivitaSvolte = dataservice.GetElencoTipiAttivitaForAnagrafica(avm.IDAnagrafica);

                if (ElencoTipiAttivitaSvolte.Count > 0)
                {
                    RefreshBadge(1);
                    CurrentIndexBadge = 1;
                }
                else
                {
                    Riga0 = QRCodeViewModel.QRCODE_ACCOMPAGNATORE;
                    CurrentIndexBadge = 0;
                }
                Riga1 = avm.Cognome + " " + avm.Nome;
                Riga2 = ((System.DateTime)avm.DataNascita).ToString("dd/MM/yyyy");
                Riga3 = avm.CodiceFiscale;
            }
            else
                Riga0 = Riga1 = Riga2 = Riga3 = string.Empty;

            string[] parametriqrcode= { "", "" };

            parametriqrcode[0] = Riga3;
            parametriqrcode[1] = Riga0;

            string qcode = QRCodeViewModel.GetQRCodeString(QRCodeViewModel.TipoQRCode.Tessera, parametriqrcode);
            QRCode = QRCodeViewModel.GetQRCodeBitmap(qcode);
        }

        /// <summary>
        /// The <szzzzzee cref="CurrentIndexBadge" /> property's name.
        /// </summary>
        public const string CurrentIndexBadgePropertyName = "CurrentIndexBadge";

        private int _currentIndexBadge = -1;

        /// <summary>
        /// Sets and gets the CurrentIndexBadge property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CurrentIndexBadge
        {
            get
            {
                return _currentIndexBadge;
            }

            set
            {
                if (_currentIndexBadge == value)
                {
                    return;
                }

                _currentIndexBadge = value;
                RaisePropertyChanged(CurrentIndexBadgePropertyName);
                RaisePropertyChanged(IsFirstTipoAttivitaPropertyName);
                RaisePropertyChanged(IsLastTipoAttivitaPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="IsFirstTipoAttivita" /> property's name.
        /// </summary>
        public const string IsFirstTipoAttivitaPropertyName = "IsFirstTipoAttivita";

        /// <summary>
        /// Sets and gets the IsFirstTipoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsFirstTipoAttivita
        {
            get
            {

                return (CurrentIndexBadge <= 0);
            }
        }

        private RelayCommand _BadgeSuccessivo;

        /// <summary>
        /// Gets the BadgeSuccessivo.
        /// </summary>
        public RelayCommand BadgeSuccessivo
        {
            get
            {
                return _BadgeSuccessivo
                    ?? (_BadgeSuccessivo = new RelayCommand(
                    () =>
                    {
                        RefreshBadge(CurrentIndexBadge + 1);
                    }));
            }
        }


        private RelayCommand _BadgePrecedente;

        /// <summary>
        /// Gets the BadgePrecedente.
        /// </summary>
        public RelayCommand BadgePrecedente
        {
            get
            {
                return _BadgePrecedente
                    ?? (_BadgePrecedente = new RelayCommand(
                    () =>
                    {
                        RefreshBadge(CurrentIndexBadge - 1);
                    }));
            }
        }

        /// <summary>
        /// The <see cref="IslastTipoAttivita" /> property's name.
        /// </summary>
        public const string IsLastTipoAttivitaPropertyName = "IsLastTipoAttivita";

        /// <summary>
        /// Sets and gets the IsFirstTipoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLastTipoAttivita
        {
            get
            {

                return (ElencoTipiAttivitaSvolte == null || ElencoTipiAttivitaSvolte.Count == CurrentIndexBadge);
            }
        }


        /// <summary>
        /// The <see cref="ElencoTipiAttivitaSvolte" /> property's name.
        /// </summary>
        public const string ElencoTipiAttivitaSvoltePropertyName = "ElencoTipiAttivitaSvolte";

        private List<TipoAttivitaROViewModel> _elencoTipiAttivitaSvolte = null;

        /// <summary>
        /// Sets and gets the ElencoTipiAttivitaSvolte property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<TipoAttivitaROViewModel> ElencoTipiAttivitaSvolte
        {
            get
            {
                return _elencoTipiAttivitaSvolte;
            }

            set
            {
                if (_elencoTipiAttivitaSvolte == value)
                {
                    return;
                }

                _elencoTipiAttivitaSvolte = value;
                RaisePropertyChanged(ElencoTipiAttivitaSvoltePropertyName);
                RaisePropertyChanged(IsFirstTipoAttivitaPropertyName);
                RaisePropertyChanged(IsLastTipoAttivitaPropertyName);
            }
        }


        void RefreshBadge(int iIndex)
        {
            if (iIndex == 0)
            {
                CurrentIndexBadge = iIndex;
                Riga0 = "ACCOMPAGNATORE";
                string[] parametriqrcode = { "", "" };
                parametriqrcode[0] = Riga3;
                parametriqrcode[1] = Riga0;
                string qcode = QRCodeViewModel.GetQRCodeString(QRCodeViewModel.TipoQRCode.Tessera, parametriqrcode);
                QRCode = QRCodeViewModel.GetQRCodeBitmap(qcode);
            }
            else
            if (ElencoTipiAttivitaSvolte != null && iIndex > 0 && iIndex <= ElencoTipiAttivitaSvolte.Count)
            {
                CurrentIndexBadge = iIndex;
                Riga0 = ElencoTipiAttivitaSvolte[iIndex-1].Titolo;

                string[] parametriqrcode = { "", "" };

                parametriqrcode[0] = Riga3;
                parametriqrcode[1] = Riga0;
                string qcode = QRCodeViewModel.GetQRCodeString(QRCodeViewModel.TipoQRCode.Tessera, parametriqrcode);
                QRCode = QRCodeViewModel.GetQRCodeBitmap(qcode);

            }
        }




        private RelayCommand _stampaBadge;

        /// <summary>
        /// Gets the StampaRicevuta.
        /// </summary>
        public RelayCommand StampaBadge
        {
            get
            {
                return _stampaBadge
                    ?? (_stampaBadge = new RelayCommand(
                    () =>
                    {
                        //MessageBox.Show("Operazioni prima di stampare");
                        GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<StampaBadge>(new StampaBadge());

                    }));
            }
        }

        private RelayCommand<string> _RicercaQRCode;

        /// <summary>
        /// Gets the RicercaQRCode.
        /// </summary>
        public RelayCommand<string> RicercaQRCode
        {
            get
            {
                return _RicercaQRCode
                    ?? (_RicercaQRCode = new RelayCommand<string>(
                    p =>
                    {
                        SimpleIoc.Default.GetInstance<AnagraficaViewModel>().ResultSetFromCF(QRCodeViewModel.CodiceFiscaleFromQrCode(p));

                    }));
            }
        }

        public string QRCODE_ACCOMPAGNATORE { get; private set; }
    }
}