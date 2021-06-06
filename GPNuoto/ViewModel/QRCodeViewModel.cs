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


//  QRCODE
//
//  I QRCode generati saranno nel formato     <TipoRecord><separatore>Field1<separatore>........<Fieldn> 
//  per un massimo di 150 caratteri
//  I tipi record previsti
//  T   tessera a seguire due field Codice Fiscale - Tipo attività
//  B   Biglietto singolo tre field Descrizione codice contabile di movimentazione - Data emissione YYYYMMDD - ID Movimento contabile emissione biglietto
//  E   Errore  un singolo field con messaggio di errore (es. superati 150 CAR)

namespace GPNuoto.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>




    public class QRCodeViewModel : ViewModelBase
    {

        public struct QrCodeEntry
        {
            public TipoQRCode Tipo;
            public string CodiceFiscale;
            public string Attivita;
            public string CodiceContabile;
            public DateTime DataEmissione;
            public int IDMovimento;
            public string Errore;
            public string Lettura;
        }

        public enum TipoQRCode
        {
            Tessera,
            Biglietto,
            Errore
        }

        static private string QRCODE_SEPARATOR = "$%";
        static private int QRCODE_MAXLEN = 150;
        static public string QRCODE_FORMATODATA = "yyyyMMdd";
        static public string QRCODE_ACCOMPAGNATORE = "ACCOMPAGNATORE";

        /// <summary>
        /// Initializes a new instance of the TesseraViewModel class.
        /// </summary>
        /// 

        public QRCodeViewModel()
        {

        }

        static public string GetQRCodeString(TipoQRCode tqrc, string[] fields)
        {

            string qcode = string.Empty;

            switch (tqrc)
            {
                case TipoQRCode.Biglietto:
                    qcode = "B";
                    break;
                case TipoQRCode.Tessera:
                    qcode = "T";
                    break;
            }
            foreach (string s in fields)
                qcode = qcode + QRCodeViewModel.QRCODE_SEPARATOR + s;

            if (qcode.Length > QRCODE_MAXLEN)
                qcode = "E" + QRCodeViewModel.QRCODE_SEPARATOR + "SUPERATO NUMERO MAX 150 CARATTERI";
            return qcode;
        }

        static public BitmapImage GetQRCodeBitmap(string qcode)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qcode, QRCodeGenerator.ECCLevel.Q);
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

                return bitmapImage;
            }
        }

        static public string CodiceFiscaleFromQrCode(string p)
        {
            string[] stringSeparators = new string[] { QRCODE_SEPARATOR };
            string[] s = p.Split(stringSeparators, StringSplitOptions.None);
            if (s[0].CompareTo("T") == 0)
                return s[1];
            else
                return string.Empty;
        }

        public QrCodeEntry QrCodeToData(string sqrc)
        {
            string[] stringSeparators = new string[] { QRCODE_SEPARATOR };
            string[] s = sqrc.Split(stringSeparators, StringSplitOptions.None);

            QrCodeEntry qe = new QrCodeEntry();
            if (s.Length < 3)
            {
                qe.Tipo = TipoQRCode.Errore;
                return qe;
            }

            qe.Lettura = sqrc;
            try
            {
                switch (s[0][0])
                {
                    case 'T':
                        qe.Tipo = TipoQRCode.Tessera;
                        qe.CodiceFiscale = s[1];
                        qe.Attivita = s[2];
                        break;
                    case 'B':
                        qe.Tipo = TipoQRCode.Biglietto;
                        qe.DataEmissione = new DateTime(Convert.ToInt16(s[2].Substring(0, 4)), Convert.ToInt16(s[2].Substring(4, 2)), Convert.ToInt16(s[2].Substring(6, 2)));
                        qe.IDMovimento = Convert.ToInt32(s[3]);
                        qe.CodiceContabile = s[1];
                        break;
                    default:
                        qe.Tipo = TipoQRCode.Errore;
                        qe.Errore = s[1];
                        break;
                };
            }catch
            {
                qe.Tipo = TipoQRCode.Errore;

            }

            return qe;
        }
    }

}

