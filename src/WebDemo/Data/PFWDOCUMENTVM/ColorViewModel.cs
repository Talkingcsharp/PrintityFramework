using System.ComponentModel;
using System.Drawing;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class ColorViewModel
    {
        [DefaultValue("White")]
        public string ColorName { get; set; } = "White";
        [DefaultValue("#FFF")]
        public string ColorHex { get; set; } = "#FFF";
        [DefaultValue(255)]
        public int ColorR { get; set; } = 255;
        [DefaultValue(255)]
        public int ColorG { get; set; } = 255;
        [DefaultValue(255)]
        public int ColorB { get; set; } = 255;

        public Color Export()
        {
            if(ColorName is not null && !string.IsNullOrEmpty(ColorName))
            {
                if (Enum.TryParse<KnownColor>(ColorName, out _))
                {
                    return Color.FromKnownColor(Enum.Parse<KnownColor>(ColorName));
                }
            }

            if (ColorHex is not null && !string.IsNullOrEmpty(ColorHex))
            {
                return ColorTranslator.FromHtml(ColorHex);
            }
            return Color.FromArgb(ColorR, ColorG, ColorB);
        }

        public static ColorViewModel FromColor(Color input)
        {
            ColorViewModel output = new ColorViewModel();
            output.ColorName = input.Name;
            output.ColorHex = ColorTranslator.ToHtml(input);
            output.ColorR = input.R;
            output.ColorG = input.G;
            output.ColorB = input.B;
            return output;
        }
    }
}
