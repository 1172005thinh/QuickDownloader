using System.Windows;
using System.Windows.Media;
using ModernWpf;

namespace QuickDownloader.GUI.Utilities
{
    public static class ColorHelper
    {
        public static void Initialize()
        {
            // Apply initial theme
            var initialTheme = ThemeManager.Current?.ActualApplicationTheme ?? ApplicationTheme.Light;
            ApplyTheme(initialTheme);

            // Hook into theme changes
            if (ThemeManager.Current != null)
            {
                ThemeManager.Current.ActualApplicationThemeChanged += (s, e) => 
                {
                    ApplyTheme(ThemeManager.Current.ActualApplicationTheme);
                };
            }
        }

        public static void ApplyTheme(ApplicationTheme theme)
        {
            if (theme == ApplicationTheme.Light)
            {
                SetColor("AppBackground", "#FFFFFF");
                SetColor("AppPrimary", "#FF0000");
                SetColor("AppSecondary", "#F0F0F0");
                SetColor("AppRegularText", "#000000");
                SetColor("AppInfoText", "#3D3D3D");
                SetColor("AppWarningText", "#FFA500");
                SetColor("AppErrorText", "#FF0000");
                SetColor("AppSuccessText", "#00A300");
                SetColor("AppURLText", "#0000FF");
                SetColor("AppDisabledText", "#A9A9A9");
            }
            else // Dark theme
            {
                SetColor("AppBackground", "#181818");
                SetColor("AppPrimary", "#FF0000");
                SetColor("AppSecondary", "#282828");
                SetColor("AppRegularText", "#FFFFFF");
                SetColor("AppInfoText", "#CFCFCF");
                SetColor("AppWarningText", "#D18800");
                SetColor("AppErrorText", "#D10000");
                SetColor("AppSuccessText", "#008000");
                SetColor("AppURLText", "#2E2EFF");
                SetColor("AppDisabledText", "#494949");
            }
            
            SetColor("AppTransparent", "#00000000");
        }

        private static void SetColor(string name, string hex)
        {
            var color = (Color)ColorConverter.ConvertFromString(hex);
            Application.Current.Resources[name + "Color"] = color;
            
            var brush = new SolidColorBrush(color);
            brush.Freeze(); // Optimize brush performance
            Application.Current.Resources[name + "Brush"] = brush;
        }
    }
}
