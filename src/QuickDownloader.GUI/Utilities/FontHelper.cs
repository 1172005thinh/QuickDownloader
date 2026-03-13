using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace QuickDownloader.GUI.Utilities
{
    public static class FontHelper
    {
        public static void Initialize()
        {
            var res = Application.Current.Resources;
            var fontFamily = new FontFamily("Segoe UI");
            res["PrimaryFontFamily"] = fontFamily;

            // S = 10pt = 13.333 DIPs
            res["FontSize_S"] = 13.333;
            // M = 12pt = 16.0 DIPs
            res["FontSize_M"] = 16.0;
            // L = 16pt = 21.333 DIPs
            res["FontSize_L"] = 21.333;
            // XL = 20pt = 26.667 DIPs
            res["FontSize_XL"] = 26.667;

            // S Styles (10pt)
            res["Font_S_R"] = CreateStyle(fontFamily, 13.333, FontWeights.Normal, FontStyles.Normal);
            res["Font_S_B"] = CreateStyle(fontFamily, 13.333, FontWeights.Bold, FontStyles.Normal);
            res["Font_S_I"] = CreateStyle(fontFamily, 13.333, FontWeights.Normal, FontStyles.Italic);
            res["Font_S_BI"] = CreateStyle(fontFamily, 13.333, FontWeights.Bold, FontStyles.Italic);

            // M Styles (12pt)
            res["Font_M_R"] = CreateStyle(fontFamily, 16.0, FontWeights.Normal, FontStyles.Normal);
            res["Font_M_B"] = CreateStyle(fontFamily, 16.0, FontWeights.Bold, FontStyles.Normal);
            res["Font_M_I"] = CreateStyle(fontFamily, 16.0, FontWeights.Normal, FontStyles.Italic);
            res["Font_M_BI"] = CreateStyle(fontFamily, 16.0, FontWeights.Bold, FontStyles.Italic);

            // L Styles (16pt)
            res["Font_L_R"] = CreateStyle(fontFamily, 21.333, FontWeights.Normal, FontStyles.Normal);
            res["Font_L_B"] = CreateStyle(fontFamily, 21.333, FontWeights.Bold, FontStyles.Normal);
            res["Font_L_I"] = CreateStyle(fontFamily, 21.333, FontWeights.Normal, FontStyles.Italic);
            res["Font_L_BI"] = CreateStyle(fontFamily, 21.333, FontWeights.Bold, FontStyles.Italic);

            // XL Styles (20pt)
            res["Font_XL_B"] = CreateStyle(fontFamily, 26.667, FontWeights.Bold, FontStyles.Normal);
        }

        private static Style CreateStyle(FontFamily family, double size, FontWeight weight, FontStyle style)
        {
            var s = new Style(typeof(TextBlock));
            s.Setters.Add(new Setter(TextBlock.FontFamilyProperty, family));
            s.Setters.Add(new Setter(TextBlock.FontSizeProperty, size));
            s.Setters.Add(new Setter(TextBlock.FontWeightProperty, weight));
            s.Setters.Add(new Setter(TextBlock.FontStyleProperty, style));
            // Use DynamicResource to link with the ColorHelper's AppRegularTextBrush
            s.Setters.Add(new Setter(TextBlock.ForegroundProperty, new DynamicResourceExtension("AppRegularTextBrush")));
            return s;
        }
    }
}
