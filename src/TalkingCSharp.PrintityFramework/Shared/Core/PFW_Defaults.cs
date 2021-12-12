using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared.Core
{
    public class PFW_Defaults
    {
        public static Color DefaultColor => Color.Black;
        public static Color DefaultAlternateColor => Color.Gray;
        public static Color DefaultHeaderColor => Color.Black;
        public static int DefaultFontSize => 12;
        public static int DefaultHeaderFontSize => 14;
        public static int DefaultAlternateFonrSize => 12;

        public static string DefaultFontFamilyName => "Arial";
        public static string DefaultAlternateFontFamilyName => "Arial";
        public static string DefaultHeaderFontFamilyName => "Tahoma";
        public static PFW_Font DefaultFont => new PFW_Font()
            .SetFontName(DefaultFontFamilyName)
            .SetBold(false)
            .SetColor(DefaultColor)
            .SetItalic(false)
            .SetSize(12)
            .SetUderline(false);

        public static PFW_Font DefaultHeaderFont => new PFW_Font()
            .SetFontName(DefaultHeaderFontFamilyName)
            .SetBold(true)
            .SetColor(DefaultHeaderColor)
            .SetItalic(false)
            .SetSize(DefaultHeaderFontSize)
            .SetUderline(false);

        public static PFW_Font DefaultAlternateFont => new PFW_Font()
            .SetFontName(DefaultAlternateFontFamilyName)
            .SetBold(true)
            .SetColor(DefaultAlternateColor)
            .SetItalic(false)
            .SetSize(DefaultAlternateFonrSize)
            .SetUderline(false);
    }
}
