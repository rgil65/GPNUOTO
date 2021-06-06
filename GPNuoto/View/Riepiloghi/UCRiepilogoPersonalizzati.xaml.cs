using GPNuoto.Model;
using GPNuoto.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Ioc;
using System.Data;

namespace GPNuoto.View.Riepiloghi
{
    /// <summary>
    /// Logica di interazione per UCRiepilogoIscrizioni.xaml
    /// </summary>
    public partial class UCRiepilogoPersonalizzati : UserControl
    {

        public UCRiepilogoPersonalizzati()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<RefreshReportPersonalizzato>(this, new Action<RefreshReportPersonalizzato>(ReportPersonalizzatoRefresh));
        }

        private void ReportPersonalizzatoRefresh(RefreshReportPersonalizzato obj)
        {


            this.lvReport.Columns.Clear();
            this.txtTitoloReport.Text = string.Empty;
            if (obj.Content == null || obj.Content.Records == null) return;


            this.txtTitoloReport.Text = obj.Content.Nome;

            DataTable dt = new DataTable();


            



            foreach (HeaderReport hr in obj.Content.Header)
            {
                //DataGridTextColumn dgc = new DataGridTextColumn
                //{
                //    Header = 
                //};
               dt.Columns.Add(hr.FieldName,typeof(string));
            }




            //this.lvReport.Set
            foreach (List<object> row in obj.Content.Records)
            {
                
                dt.Rows.Add(row.ToArray());
                //ItemCollection ic = new this.lvReport.Items;

                //this.lvReport.Items.Add((new ItemCollection());

                //ItemCollection ic = new ItemCollection();
                //this.lvReport.Rows
                //foreach (string s in row)
                //{
                 
                //}

            }


            var cellStyle = new Style
            {
                TargetType = typeof(TextBlock),
                Setters =
                    {
                        new Setter(TextBlock.TextAlignmentProperty, TextAlignment.Right),
                        new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center),
                    }
            };


            this.lvReport.ItemsSource = dt.DefaultView;
        }

        private void btnExportExcel_Click(object sender, RoutedEventArgs e)
        {
            //configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Export"; //default file name
            dlg.DefaultExt = ".xlsx"; //default file extension
            dlg.Filter = "documenti xlsx (.xlsx)|*.xlsx"; //filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                ((ManagerRiepiloghiPersonalizzatiViewModel)this.DataContext).EseguiExportReportSelezionato.Execute(dlg.FileName);
           }
        }

        private void btnEditQuery_Click(object sender, RoutedEventArgs e)
        {
            EditQueryRiepilogo eqr = new EditQueryRiepilogo(this);
            eqr.DataContext = this.DataContext;
            if (eqr.ShowDialog() == true)
            {
                ((ManagerRiepiloghiPersonalizzatiViewModel)this.DataContext).SaveQuery.Execute(eqr.txtQuery.Text);
            }

        }
    }
}
