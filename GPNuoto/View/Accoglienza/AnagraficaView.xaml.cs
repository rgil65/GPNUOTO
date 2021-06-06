using GPNuoto.ViewModel;
using GPNuoto.Model;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Markup;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;
using GalaSoft.MvvmLight.Ioc;

namespace GPNuoto
{
    /// <summary>
    /// Description for AnagraficaView.
    /// </summary>

    

    public partial class AnagraficaView : UserControl, IPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the AnagraficaView class.
        /// </summary>
        /// 
       public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Finds a Child of a given item in the visual tree. 
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName)
           where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }




        private void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
          PropertyChanged(this, new PropertyChangedEventArgs(info));            
    }

        public AnagraficaView()
        {
            InitializeComponent();
            

            //GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<RefreshInformazioniAggiuntiveAnagrafica>(this,
            // new Action<RefreshInformazioniAggiuntiveAnagrafica>(RefreshInformazioniAggiuntiveAnagraficaExec));


            //AnagraficaViewModel vm = (AnagraficaViewModel)(this.DataContext);
            //int iControl = 0;
            
            // Creazione campi dinamici
            //foreach (var m in vm.AnagraficaInfoAdd.InfoAddMatrix)
            //{
            //    if (iControl%2==0)
            //    {
            //        RowDefinition r = new RowDefinition();
            //        r.Height = new GridLength(60);
            //        this.InformazioniAggiuntive.RowDefinitions.Add(r);
            //    }
            //    StackPanel newSP = new StackPanel();
            //    newSP.Orientation = Orientation.Horizontal;
            //    TextBlock tb = new TextBlock();
            //    tb.Text = m.Value.Descrizione;
            //    tb.VerticalAlignment = VerticalAlignment.Center;
            //    newSP.Children.Add(tb);

            //    switch (m.Value.Tipo)
            //    { 
            //          case Model.InfoAggiuntiveModel.TipoInfoAdd.Data:
            //            DatePicker dp = new DatePicker();
            //            dp.Language =  XmlLanguage.GetLanguage("it-IT");
            //            dp.Name = m.Key;
            //            dp.Width = 90;
            //            dp.Margin = new Thickness(10, 0, 0, 10);
            //            dp.HorizontalAlignment = HorizontalAlignment.Left;
            //            dp.VerticalAlignment = VerticalAlignment.Center;
            //            Style style = this.FindResource("MaterialDesignFloatingHintDatePicker") as Style;
            //            dp.Style = style;
            //            dp.SelectedDateChanged += DatePickerDF_SelectedDateChanged;
            //            newSP.Children.Add(dp);
            //            break;
            //        case Model.InfoAggiuntiveModel.TipoInfoAdd.Livello:
            //            MaterialDesignThemes.Wpf.RatingBar Livello = new RatingBar();
            //            Livello.Name = m.Key;
            //            Livello.VerticalAlignment = VerticalAlignment.Center;
            //            string[] s = (m.Value.Parametro).Split(':');
            //            Livello.Max = Convert.ToInt16(s[1]);
            //            Livello.Min = Convert.ToInt16(s[0]); ;
            //            Livello.Value = 0;
            //            DependencyPropertyDescriptor ValueChanged = DependencyPropertyDescriptor.FromProperty(RatingBar.ValueProperty, typeof(RatingBar));
            //            if (ValueChanged != null)
            //            {
            //                ValueChanged.AddValueChanged(Livello, delegate
            //                {
            //                    ((TextBlock)((StackPanel)Livello.Parent).Children[2]).Text = Livello.Value.ToString("(0)");
            //                    vm.SetDFValue(Livello.Name,Livello.Value);
            //                });
            //            }
            //            newSP.Children.Add(Livello);
            //            TextBlock tbliv = new TextBlock();
            //            tbliv.Text = "(0)";
            //            tbliv.VerticalAlignment = VerticalAlignment.Center;
            //            newSP.Children.Add(tbliv);
            //            break;
            //        case Model.InfoAggiuntiveModel.TipoInfoAdd.Range:
            //            //wSP = (StackPanel)DeepCopy(this.Clone_Range);
            //            break;
            //        case Model.InfoAggiuntiveModel.TipoInfoAdd.SiNo:
            //            CheckBox SiNo = new CheckBox();
            //            SiNo.Name = m.Key;
            //            SiNo.Margin = new Thickness(10, 0, 0, 10);
            //            SiNo.VerticalAlignment = VerticalAlignment.Center;
            //            SiNo.HorizontalAlignment = HorizontalAlignment.Left;
            //            SiNo.Checked += SiNoDF_Checked;
            //            SiNo.Unchecked += SiNoDF_Checked;
            //            newSP.Children.Add(SiNo);
            //            break;
            //        case Model.InfoAggiuntiveModel.TipoInfoAdd.Testo:
            //            //newSP = DeepClone<StackPanel>(this.Clone_Testo);
            //            TextBox testo = new TextBox();
            //            testo.Name = m.Key;
            //            testo.Margin = new Thickness(10, 0, 0, 0);
            //            testo.VerticalAlignment = VerticalAlignment.Center;
            //            newSP.Children.Add(testo);
            //            break;

            //    }
            //    newSP.Visibility = Visibility.Visible;
            //    int irow = iControl / 2;
            //    int icol = iControl % 2;
            //    newSP.SetValue(Grid.RowProperty, irow);
            //    newSP.SetValue(Grid.ColumnProperty, icol);
            //    this.InformazioniAggiuntive.Children.Add(newSP);
            //    iControl++;
                

            //}
        }
        //private void SiNoDF_Checked(object sender, RoutedEventArgs e)
        //{
        //    AnagraficaViewModel vm = (AnagraficaViewModel)this.DataContext;
        //    vm.SetDFValue(((CheckBox)sender).Name, ((CheckBox)sender).IsChecked);
        //}

        //private void DatePickerDF_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    AnagraficaViewModel vm = (AnagraficaViewModel)this.DataContext;
        //    vm.SetDFValue(((DatePicker)sender).Name, ((DatePicker)sender).SelectedDate);
        //}

                
        //private void  RefreshInformazioniAggiuntiveAnagraficaExec(RefreshInformazioniAggiuntiveAnagrafica obj)
        //{
            


        //    AnagraficaViewModel vm = (AnagraficaViewModel)(this.DataContext);


        //    // Creazione campi dinamici
        //    foreach (var m in vm.AnagraficaInfoAdd.InfoAddMatrix)
        //    {
                

        //        switch (m.Value.Tipo)
        //        {
        //            case Model.InfoAggiuntiveModel.TipoInfoAdd.Data:
        //                DatePicker dp = FindChild<DatePicker>(this, m.Key);
        //                if (m.Value.Valore != null)
        //                    dp.SelectedDate = (DateTime)m.Value.Valore;
        //                else
        //                    dp.SelectedDate = null;
        //                break;
        //            case Model.InfoAggiuntiveModel.TipoInfoAdd.Livello:
        //                RatingBar rb = FindChild<RatingBar>(this, m.Key);
        //                if (m.Value.Valore != null)
        //                    rb.Value = (int)m.Value.Valore;
        //                else
        //                    rb.Value = 0;
        //                break;
        //            case Model.InfoAggiuntiveModel.TipoInfoAdd.Range:
        //                //wSP = (StackPanel)DeepCopy(this.Clone_Range);
        //                break;
        //            case Model.InfoAggiuntiveModel.TipoInfoAdd.SiNo:
        //                CheckBox ck = FindChild<CheckBox>(this, m.Key);
        //                if (m.Value.Valore != null && (bool)m.Value.Valore)
        //                    ck.IsChecked = true;
        //                else
        //                    ck.IsChecked = false;
        //                break;
        //            case Model.InfoAggiuntiveModel.TipoInfoAdd.Testo:
        //                break;

        //        }
 
        //    }
        //}

        private void btnQrCode_Click(object sender, RoutedEventArgs e)
        {
            QRCodeInputView dlg = new QRCodeInputView(this);
            if ((bool)dlg.ShowDialog())
            {
                //SimpleIoc.Default.GetInstance<TesseraViewModel>().RicercaQRCode.Execute(dlg.QRCodeText.Text);
                AnagraficaViewModel vm = (AnagraficaViewModel)this.DataContext;
                if (dlg.IsRinnovo)
                {
                    QRCodeViewModel qrvm = new QRCodeViewModel();
                    QRCodeViewModel.QrCodeEntry qe = qrvm.QrCodeToData(dlg.QRCodeText.Text);
                    vm.RinnnovaAttivita.Execute(qe);
                }
                SimpleIoc.Default.GetInstance<TesseraViewModel>().RicercaQRCode.Execute(dlg.QRCodeText.Text);
            }
        }
    }
}