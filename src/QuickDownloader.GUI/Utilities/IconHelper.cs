using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ModernWpf;

namespace QuickDownloader.GUI.Utilities
{
    public static class IconHelper
    {
        private const string BasePath = "pack://application:,,,/Resources/Icons/";
        private const string FallbackIcon = "err_icon_16.ico";

        public static readonly DependencyProperty IconNameProperty =
            DependencyProperty.RegisterAttached(
                "IconName",
                typeof(string),
                typeof(IconHelper),
                new PropertyMetadata(null, OnIconNameChanged));

        public static string GetIconName(DependencyObject obj)
        {
            return (string)obj.GetValue(IconNameProperty);
        }

        public static void SetIconName(DependencyObject obj, string value)
        {
            obj.SetValue(IconNameProperty, value);
        }

        private static void OnIconNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Image image)
            {
                UpdateImageSource(image);
                
                // Optional: Hook into theme changes to update dynamically
                ThemeManager.Current.ActualApplicationThemeChanged += (s, args) => 
                {
                    UpdateImageSource(image);
                };
            }
        }

        public static void UpdateImageSource(Image image)
        {
            string? iconName = GetIconName(image);
            if (string.IsNullOrEmpty(iconName)) return;

            image.Source = GetIcon(iconName);
        }

        public static ImageSource GetIcon(string iconName)
        {
            bool isDarkTheme = ThemeManager.Current.ActualApplicationTheme == ApplicationTheme.Dark;
            
            string requestedName = iconName;
            if (isDarkTheme)
            {
                int extIndex = iconName.LastIndexOf('.');
                if (extIndex >= 0)
                    requestedName = iconName.Insert(extIndex, "_dark");
                else
                    requestedName += "_dark";
            }

            string uriString = BasePath + requestedName;
            
            try
            {
                // Try to resolve the resource from the assembly
                var resourceUri = new Uri(uriString.Replace("pack://application:,,,", ""), UriKind.Relative);
                var streamInfo = Application.GetResourceStream(resourceUri);
                if (streamInfo != null)
                {
                    return new BitmapImage(new Uri(uriString, UriKind.Absolute));
                }
            }
            catch
            {
                // Ignored, will fall back to default
            }

            // Fallback to error icon
            return new BitmapImage(new Uri(BasePath + FallbackIcon, UriKind.Absolute));
        }
    }
}
