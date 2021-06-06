using GPNuoto.Model;
using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GPNuoto
{
    /// <summary>
    /// Description for FrontendView.
    /// </summary>
    public partial class FrontendView : UserControl

    {
        /// <summary>
        /// Initializes a new instance of the FrontendView class.
        /// </summary>
        public FrontendView()
        {
            InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowSelezioneAttivita>(this,
              new Action<ShowSelezioneAttivita>(ShowSelezioniAttivita));
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowSelezioneTipoAttivita>(this,
             new Action<ShowSelezioneTipoAttivita>(ShowSelezioniTipoAttivita));
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditAttivita>(this,
             new Action<ShowEditAttivita>(ShowEditAttivita));
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditDateAttivita>(this,
             new Action<ShowEditDateAttivita>(ShowEditDateAttivita));
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<ShowEditPagamento>(this,
         new Action<ShowEditPagamento>(ShowEditPagamento));
        }

        private void ShowEditAttivita(ShowEditAttivita obj)
        {


            if (obj.DataContext != null)
            {
                this.EditAttivita.DataContext = obj.DataContext;
                Storyboard sb = this.FindResource("OpenEditAttivita") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("CloseEditAttivita") as Storyboard;
                sb.Begin();
            }
        }

        private void ShowEditDateAttivita(ShowEditDateAttivita obj)
        {


            if (obj.DataContext != null)
            {
                this.EditDateAttivita.DataContext = obj.DataContext;
                //Storyboard sb = this.FindResource("OpenEditDateAttivita") as Storyboard;
                //sb.Begin();
                this.EditDateAttivita.Visibility = System.Windows.Visibility.Visible;

            }
            else
            {
                    //Storyboard sb = this.FindResource("CloseEditDateAttivita") as Storyboard;
                    //sb.Begin();
                this.EditDateAttivita.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void ShowEditPagamento(ShowEditPagamento obj)
        {


            if (obj.bShow)
            {
                Storyboard sb = this.FindResource("OpenPagamento") as Storyboard;
                DoubleAnimationUsingKeyFrames dkf = ((DoubleAnimationUsingKeyFrames)(sb.Children[0]));
                dkf.KeyFrames[0].Value = this.grpbox_Pagamenti.ActualWidth;
               
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("ClosePagamento") as Storyboard;
                sb.Begin();
  
            }
        }

        private void ShowSelezioniAttivita(ShowSelezioneAttivita spm)
        {
            if (spm.ShowWindow)
            { 
                Storyboard sb = this.FindResource("OpenSelezioneAttivita") as Storyboard;
                //DoubleAnimationUsingKeyFrames dkf = ((DoubleAnimationUsingKeyFrames)(sb.Children[0]));
                //dkf.KeyFrames[0].Value = this.grpbox_SelezioneAttivita.ActualWidth;
                //this.grpbox_SelezioneAttivita.Visibility = System.Windows.Visibility.Visible;
                sb.Begin();
            }else{
                Storyboard sb = this.FindResource("CloseSelezioneAttivita") as Storyboard;
                //DoubleAnimationUsingKeyFrames dkf = ((DoubleAnimationUsingKeyFrames)(sb.Children[0]));
                //dkf.KeyFrames[1].Value = this.grpbox_SelezioneAttivita.ActualWidth;
                sb.Begin();
                //this.grpbox_SelezioneAttivita.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void ShowSelezioniTipoAttivita(ShowSelezioneTipoAttivita spm)
        {
            if (spm.ShowWindow)
            {
                Storyboard sb = this.FindResource("OpenSlideTA") as Storyboard;
                DoubleAnimationUsingKeyFrames dkf = ((DoubleAnimationUsingKeyFrames)(sb.Children[0]));
                dkf.KeyFrames[0].Value = this.grpbox_SelezioneTipoAttivita.ActualWidth;
                sb.Begin();
            }                                   
            else
            {
                Storyboard sb = this.FindResource("CloseSlideTA") as Storyboard;
                DoubleAnimationUsingKeyFrames dkf = ((DoubleAnimationUsingKeyFrames)(sb.Children[0]));
                dkf.KeyFrames[1].Value = this.grpbox_SelezioneTipoAttivita.ActualWidth;
                sb.Begin();
            }
        }
    }
}