using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GPNuoto.Model;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPNuoto.ViewModel
{
    public class ManagerRiepiloghiPersonalizzatiViewModel : ViewModelBase
    {

        public ManagerRiepiloghiPersonalizzatiViewModel()
        {

        }



        /// <summary>
        /// The <see cref="ElencoReport" /> property's name.
        /// </summary>
        public const string ElencoReportPropertyName = "ElencoReport";

        private List<ReportPersonalizzatoViewModel> _elencoReport = null;

        /// <summary>
        /// Sets and gets the ElencoTipoAttivita property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<ReportPersonalizzatoViewModel> ElencoReport
        {
            get
            {
                if (_elencoReport == null)
                {
                    IDataService dataservice = ServiceLocator.Current.GetInstance<IDataService>();
                    _elencoReport = dataservice.GetElencoReport();
                }
                return _elencoReport;
            }
        }



        /// <summary>
        /// The <see cref="ReportSelezionato" /> property's name.
        /// </summary>
        public const string ReportSelezionatoPropertyName = "ReportSelezionato";

        private ReportPersonalizzatoViewModel _reportSelezionato = null;

        /// <summary>
        /// Sets and gets the CodiceContabile property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ReportPersonalizzatoViewModel ReportSelezionato
        {
            get
            {
                return _reportSelezionato;
            }

            set
            {
                if (_reportSelezionato == value)
                {
                    return;
                }

                _reportSelezionato = value;

                RaisePropertyChanged(ReportSelezionatoPropertyName);
            }
        }


        private RelayCommand _eseguiReportSelezionato;

        /// <summary>
        /// Gets the SalvaDettagli.
        /// </summary>
        public RelayCommand EseguiReportSelezionato
        {
            get
            {
                return _eseguiReportSelezionato
                    ?? (_eseguiReportSelezionato = new RelayCommand(
                    () =>
                    {
                      
                        if (ReportSelezionato != null)
                        {


                            IDataService dataservice = ServiceLocator.Current.GetInstance<IDataService>();
                            ReportPersonalizzatoViewModel rpvm =  dataservice.GetReport(ReportSelezionato.ID);
                              GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<RefreshReportPersonalizzato>(new RefreshReportPersonalizzato(rpvm));

                        }

                    }));
            }
        }

        private RelayCommand<string> _eseguiExportReportSelezionato;

        /// <summary>
        /// Gets the SalvaDettagli.
        /// </summary>
        public RelayCommand<string> EseguiExportReportSelezionato
        {
            get
            {
                return _eseguiExportReportSelezionato
                    ?? (_eseguiExportReportSelezionato = new RelayCommand<string>(
                    (p) =>
                    {

                        if (ReportSelezionato != null)
                        {
                            IDataService dataservice = ServiceLocator.Current.GetInstance<IDataService>();
                            try
                            {
                                ReportPersonalizzatoViewModel rpvm = dataservice.GetReport(ReportSelezionato.ID);


                                using (SpreadsheetDocument document = SpreadsheetDocument.Create(p, SpreadsheetDocumentType.Workbook))
                                {
                                    WorkbookPart workbookPart = document.AddWorkbookPart();
                                    workbookPart.Workbook = new Workbook();


                                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                                    var sheetData = new SheetData();
                                    worksheetPart.Worksheet = new Worksheet(sheetData);

                                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                                    Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = rpvm.Nome };

                                    sheets.Append(sheet);


                                    Row headerRow = new Row();

                                    List<String> columns = new List<string>();
                                    foreach (HeaderReport hr in rpvm.Header)
                                    {
                                        columns.Add(hr.FieldName);

                                        Cell cell = new Cell();

                                        cell.DataType = CellValues.String;
                                        cell.CellValue = new CellValue(hr.FieldName);
                                        headerRow.AppendChild(cell);
                                    }

                                    sheetData.AppendChild(headerRow);

                                    foreach (List<object> dsrow in rpvm.Records)
                                    {
                                        Row newRow = new Row();
                                        int i = 0;
                                        foreach (object col in dsrow)
                                        {
                                            Cell cell = new Cell();
                                            if (rpvm.Header[i].TipoFormato == TipoDato.Intero)
                                                cell.DataType = CellValues.Number;
                                            else
                                            if (rpvm.Header[i].TipoFormato == TipoDato.Decimale)
                                                cell.DataType = CellValues.Number;
                                            else
                                            if (rpvm.Header[i].TipoFormato == TipoDato.Data)
                                                cell.DataType = CellValues.Date;
                                            else
                                                cell.DataType = CellValues.String;


                                            if (rpvm.Header[i].TipoFormato == TipoDato.Data)
                                            {
                                                cell.DataType = CellValues.String;
                                                if (col != null)
                                                    cell.CellValue = new CellValue(((DateTime)col).ToString("yyyy-MM-dd"));
                                            }
                                            else
                                            {
                                                cell.CellValue = new CellValue();
                                                cell.CellValue.Text = Convert.ToString(col);
                                            }
                                            newRow.AppendChild(cell);
                                            i++;
                                        }
                                        sheetData.AppendChild(newRow);
                                    }
                                    workbookPart.Workbook.Save();
                                }
                            }catch
                            {
                               
                            }
                        }}));
            }
        }

        private RelayCommand<string> _saveQuery;

        /// <summary>
        /// Gets the SalvaDettagli.
        /// </summary>
        public RelayCommand<string> SaveQuery
        {
            get
            {
                return _saveQuery
                    ?? (_saveQuery = new RelayCommand<string>(
                    (p) =>
                    {

                        if (ReportSelezionato != null)
                        {
                            IDataService dataservice = ServiceLocator.Current.GetInstance<IDataService>();
                            ReportSelezionato.Query = p;
                            dataservice.ReportSaveQuery(ReportSelezionato.ID,p);
                        }
                    }));
            }
        }
    }
}
