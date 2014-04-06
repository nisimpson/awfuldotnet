using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
#if WINDOWS_PHONE
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Input;
#else
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media;
#endif

namespace AwfulNET.Common
{
    public class UIExtensions : DependencyObject
    {
        #region TapCommand

        public static readonly DependencyProperty TapCommandProperty =
            DependencyProperty.RegisterAttached("TapCommand",
            typeof(ICommand),
            typeof(UIExtensions),
            new PropertyMetadata(null, new PropertyChangedCallback(OnTapCommandChanged)));

        private static void OnTapCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            if (e.NewValue != null)
            {
                element.Tap += element_Tap;
            }
            else
                element.Tap -= element_Tap;
        }

        static void element_Tap(object sender, GestureEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            ICommand command = GetTapCommand(element);
            command.Execute(element.DataContext);
        }

        public static ICommand GetTapCommand(FrameworkElement element)
        {
            return element.GetValue(TapCommandProperty) as ICommand;
        }

        public static void SetTapCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(TapCommandProperty, value);
        }

#endregion TapCommand

        #region CollapseOnEmpty

         public static readonly DependencyProperty CollapseOnEmptyProperty =
            DependencyProperty.RegisterAttached(
            "CollapseOnEmpty",
            typeof(bool),
            typeof(UIExtensions),
            new PropertyMetadata(false, OnCollapseOnEmptyChanged));


        private static void OnCollapseOnEmptyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock block = d as TextBlock;
            if ((bool)e.NewValue)
            {
                block.SizeChanged += block_SizeChanged;
            }
            else
            {
                block.SizeChanged -= block_SizeChanged;
            }
        }

        private static void block_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            if (string.IsNullOrEmpty(text.Text))
                text.Visibility = Visibility.Collapsed;
            else
                text.Visibility = Visibility.Visible;
        }

        public static bool GetCollapseOnEmpty(TextBlock element)
        {
            return (bool)element.GetValue(CollapseOnEmptyProperty);
        }

        public static void SetCollapseOnEmpty(TextBlock element, bool value)
        {
            element.SetValue(CollapseOnEmptyProperty, value);
        }
    
        #endregion CollapseOnEmpty

        #region HideOnNullOrEmpty

        public static readonly DependencyProperty HideOnNullOrEmptyProperty =
            DependencyProperty.RegisterAttached(
            "HideOnNullOrEmpty",
            typeof(bool),
            typeof(UIExtensions),
            new PropertyMetadata(false, HideOnNullOrEmptyPropertyChanged));

        private static void HideOnNullOrEmptyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
#if WINDOWS_PHONE

            TextBlock textBlock = d as TextBlock;
            if ((bool)e.NewValue)
            {
                textBlock.TextInput += textBlock_TextInput;
                textBlock.TextInputStart += textBlock_TextInputStart;
            }
            else
            {
                textBlock.TextInputStart -= textBlock_TextInputStart;
                textBlock.TextInput -= textBlock_TextInput;
            }
#else
            throw new PlatformNotSupportedException("UIExtensions not supported on Windows Store applications.");
#endif
        }

#if WINDOWS_PHONE
        static void textBlock_TextInputStart(object sender, TextCompositionEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            HideOnNullOrEmpty(text);
        }

         static void textBlock_TextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            HideOnNullOrEmpty(text);
        }

        static void textBlock_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
#endif

        public static bool GetHideOnNullOrEmpty(TextBlock element)
        {
            return (bool)element.GetValue(HideOnNullOrEmptyProperty);
        }

        public static void SetHideOnNullOrEmpty(TextBlock element, bool value)
        {
            element.SetValue(HideOnNullOrEmptyProperty, value);
        }

        static void HideOnNullOrEmpty(TextBlock textBlock)
        {
            if (string.IsNullOrEmpty(textBlock.Text))
                textBlock.Visibility = Visibility.Collapsed;
            else
                textBlock.Visibility = Visibility.Visible;
        }

        #endregion HideOnNullOrEmpty

        #region IsSmartVisibility

        public static readonly DependencyProperty IsSmartVisibilityEnabledProperty =
            DependencyProperty.RegisterAttached(
            "IsSmartVisibilityEnabled",
            typeof(bool),
            typeof(UIExtensions),
            new PropertyMetadata(false, OnIsSmartVisibilityEnabledChanged));

        private static void OnIsSmartVisibilityEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Image img = d as Image;
            if ((bool)e.NewValue)
            {
                img.ImageFailed += img_ImageFailed;
                img.ImageOpened += img_ImageOpened;
            }
            else
            {
                img.ImageFailed -= img_ImageFailed;
                img.ImageOpened -= img_ImageOpened;
            }
        }

        static void img_ImageOpened(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            img.Visibility = Visibility.Visible;
        }

        static void img_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            Image img = sender as Image;
            img.Visibility = Visibility.Collapsed;
        }

        public static bool GetIsSmartVisibilityEnabled(Image element)
        {
            return (bool)element.GetValue(IsSmartVisibilityEnabledProperty);
        }

        public static void SetIsSmartVisibilityEnabled(Image element, bool value)
        {
            element.SetValue(IsSmartVisibilityEnabledProperty, value);
        }

        #endregion IsSmartVisibility

        #region ImageOpenedStoryboard

        public static readonly DependencyProperty ImageOpenedStoryboardProperty =
            DependencyProperty.RegisterAttached(
            "ImageOpenedStoryboard",
            typeof(Storyboard),
            typeof(UIExtensions),
            new PropertyMetadata(null, OnImageOpenedStoryboardPropertyChanged));

        private static void OnImageOpenedStoryboardPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Image img = d as Image;
            if (e.NewValue!= null)
            {
                img.ImageOpened += img_ImageOpenedForStoyboard;
            }
            else
            {
                img.ImageOpened -= img_ImageOpenedForStoyboard;
            }
        }

        public static Storyboard GetImageOpenedStoryboard(Image element)
        {
            return element.GetValue(ImageOpenedStoryboardProperty) as Storyboard;
        }

        public static void SetImageOpenedStoryboard(Image element, Storyboard value)
        {
            element.SetValue(ImageOpenedStoryboardProperty, value);
        }

        private static void img_ImageOpenedForStoyboard(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            //img.ImageOpened -= img_ImageOpenedForStoyboard;
            Storyboard animation = GetImageOpenedStoryboard(img);
            animation.Begin();
        }

        #endregion ImageOpenedStoryboard

        #region ImageBrushOpenedStoryboard

        public static readonly DependencyProperty ImageBrushOpenedStoryboardProperty =
           DependencyProperty.RegisterAttached(
           "ImageBrushOpenedStoryboard",
           typeof(Storyboard),
           typeof(UIExtensions),
           new PropertyMetadata(null, OnImageBrushOpenedStoryboardPropertyChanged));

        private static void OnImageBrushOpenedStoryboardPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageBrush img = d as ImageBrush;
            if (e.NewValue != null)
            {
                img.ImageOpened += img_ImageBrushOpenedForStoyboard;
            }
            else
            {
                img.ImageOpened -= img_ImageBrushOpenedForStoyboard;
            }
        }


        private static void img_ImageBrushOpenedForStoyboard(object sender, RoutedEventArgs e)
        {
            ImageBrush img = sender as ImageBrush;
            //img.ImageOpened -= img_ImageBrushOpenedForStoyboard;
            Storyboard animation = GetImageBrushOpenedStoryboard(img);
            animation.Begin();
        }

        public static Storyboard GetImageBrushOpenedStoryboard(ImageBrush element)
        {
            return element.GetValue(ImageBrushOpenedStoryboardProperty) as Storyboard;
        }

        public static void SetImageBrushOpenedStoryboard(ImageBrush element, Storyboard value)
        {
            element.SetValue(ImageBrushOpenedStoryboardProperty, value);
        }

        #endregion

        #region ImageFailedStoryboard

        public static readonly DependencyProperty ImageFailedStoryboardProperty =
           DependencyProperty.RegisterAttached(
           "ImageFailedStoryboard",
           typeof(Storyboard),
           typeof(UIExtensions),
           new PropertyMetadata(null, OnImageFailedStoryboardPropertyChanged));

        private static void OnImageFailedStoryboardPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Image img = d as Image;
            if (e.NewValue != null)
            {
                img.ImageFailed += img_ImageFailedForStoyboard;
            }
            else
            {
                img.ImageFailed -= img_ImageFailedForStoyboard;
            }
        }

        public static Storyboard GetImageFailedStoryboard(Image element)
        {
            return element.GetValue(ImageFailedStoryboardProperty) as Storyboard;
        }

        public static void SetImageFailedStoryboard(Image element, Storyboard value)
        {
            element.SetValue(ImageFailedStoryboardProperty, value);
        }

        private static void img_ImageFailedForStoyboard(object sender, RoutedEventArgs e)
        {
            Image img = sender as Image;
            //img.ImageFailed -= img_ImageFailedForStoyboard;
            Storyboard animation = GetImageFailedStoryboard(img);
            animation.Begin();
        }


        #endregion
    }
}
