using GPNuoto.Model;
using GPNuoto.View.Riepiloghi;
using GPNuoto.ViewModel;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for FrontendView.
    /// </summary>
    public partial class RiepiloghiView : UserControl

    {
        public string LastBtnPressed { get; set; }
        private UCRiepilogoIscrizioni ctrri = new UCRiepilogoIscrizioni();
        private UCRiepilogoPersonalizzati ctrtp = new UCRiepilogoPersonalizzati();
        /// <summary>
        /// Initializes a new instance of the FrontendView class.
        /// </summary>
        public RiepiloghiView()
        {
            InitializeComponent();
            LastBtnPressed = String.Empty;
            ctrri.DataContext = new RiepilogoIscrizioniViewModel();
            Grid.SetRow(ctrri, 0);
            Grid.SetColumn(ctrri, 1);
            this.gridMain.Children.Add(ctrri);
            ctrtp.DataContext = new ManagerRiepiloghiPersonalizzatiViewModel();
            Grid.SetRow(ctrtp, 0);
            Grid.SetColumn(ctrtp, 1);
            this.gridMain.Children.Add(ctrtp);
            ctrri.Visibility = System.Windows.Visibility.Hidden;
            ctrtp.Visibility = System.Windows.Visibility.Hidden;
        }

        private void btnMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (LastBtnPressed.CompareTo(((Button)sender).Name)!=0)
            {
                //if (LastBtnPressed != string.Empty)
                //{
                //    throw new NotImplementedException();
                //}
                
                LastBtnPressed = ((Button)sender).Name;
                if (LastBtnPressed.CompareTo("btnIscrizioni") == 0)
                {
                     ctrtp.Visibility = System.Windows.Visibility.Hidden;
                     ctrri.Visibility = System.Windows.Visibility.Visible;
                     btnIscrizioni.SetResourceReference(Control.BackgroundProperty, "AccentColorBrush4");
                     btnPersonalizzati.SetResourceReference(Control.BackgroundProperty, "WindowTitleColorBrush");

                }
                 else
                    if (LastBtnPressed.CompareTo("btnPersonalizzati") == 0)
                    {
                            ctrtp.Visibility = System.Windows.Visibility.Visible;
                            ctrri.Visibility = System.Windows.Visibility.Hidden;
                            btnPersonalizzati.SetResourceReference(Control.BackgroundProperty, "AccentColorBrush4");
                            btnIscrizioni.SetResourceReference(Control.BackgroundProperty, "WindowTitleColorBrush");

                    }


            }
            
            //Background = "{DynamicResource WindowTitleColorBrush}"

        }

        //private void btnPersonalizzati_Click(object sender, System.Windows.RoutedEventArgs e)
        //{

        //}
    }
}