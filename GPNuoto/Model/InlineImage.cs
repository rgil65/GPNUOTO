using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.IO;

namespace GPNuoto.Model
{

    
    [ContentProperty("Base64Source")]
    [Serializable]
    public class InlineImage : BlockUIContainer
    {
        public InlineImage()
        {

        }
        #region DependencyProperty 'Width'

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        /// <summary>
        /// Registers a dependency property to get or set the width
        /// </summary>
        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(double),
            typeof(InlineImage),
            new FrameworkPropertyMetadata(Double.NaN));

        #endregion

        #region DependencyProperty 'Height'

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        /// <summary>
        /// Registers a dependency property to get or set the height
        /// </summary>
        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(double),
            typeof(InlineImage),
            new FrameworkPropertyMetadata(Double.NaN));

        #endregion

        #region DependencyProperty 'Stretch'

        /// <summary>
        /// Gets or sets the stretch behavior.
        /// </summary>
        public Stretch Stretch
        {
            get { return (Stretch)GetValue(StretchProperty); }
            set { SetValue(StretchProperty, value); }
        }

        /// <summary>
        /// Registers a dependency property to get or set the stretch behavior
        /// </summary>
        public static readonly DependencyProperty StretchProperty =
            DependencyProperty.Register("Stretch", typeof(Stretch),
            typeof(InlineImage),
            new FrameworkPropertyMetadata(Stretch.Uniform));

        #endregion

        #region DependencyProperty 'StretchDirection'

        /// <summary>
        /// Gets or sets the stretch direction.
        /// </summary>
        public StretchDirection StretchDirection
        {
            get { return (StretchDirection)GetValue(StretchDirectionProperty); }
            set { SetValue(StretchDirectionProperty, value); }
        }

        /// <summary>
        /// Registers a dependency property to get or set the stretch direction
        /// </summary>
        public static readonly DependencyProperty StretchDirectionProperty =
            DependencyProperty.Register("StretchDirection", typeof(StretchDirection),
            typeof(InlineImage),
            new FrameworkPropertyMetadata(StretchDirection.Both));

        #endregion

        #region DependencyProperty 'Base64Source'

        /// <summary>
        /// Gets or sets the base64 source.
        /// </summary>
        public string Base64Source
        {
            get { return (string)GetValue(Base64SourceProperty); }
            set { SetValue(Base64SourceProperty, value); }
        }

        /// <summary>
        /// Registers a dependency property to get or set the base64 source
        /// </summary>
        public static readonly DependencyProperty Base64SourceProperty =
            DependencyProperty.Register("Base64Source", typeof(string), typeof(InlineImage),
            new FrameworkPropertyMetadata(null, OnBase64SourceChanged));

        #endregion

        #region Private Members

        private static void OnBase64SourceChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            var inlineImage = (InlineImage)sender;
            var stream = new MemoryStream(Convert.FromBase64String(inlineImage.Base64Source));

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();

            var image = new Image
            {
                Source = bitmapImage,
                Stretch = inlineImage.Stretch,
                StretchDirection = inlineImage.StretchDirection,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            if (!double.IsNaN(inlineImage.Width))
            {
                image.Width = inlineImage.Width;
            }

            if (!double.IsNaN(inlineImage.Height))
            {
                image.Height = inlineImage.Height;
            }

            inlineImage.Child = image;
        }

        #endregion

    }
}
