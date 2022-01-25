using PrintityFramework;
using System.ComponentModel;
using System.Drawing;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class PFW_FontViewModel
    {
        [DefaultValue("Arial")]
        public string FontName { get; set; } = "Arial";
        [DefaultValue(false)]
        public bool Bold { get; set; }
        [DefaultValue(false)]
        public bool Italic { get; set; }
        [DefaultValue(false)]
        public bool Underline { get; set; }
        [DefaultValue(10)]
        public int Size { get; set; }
        public ColorViewModel Color { get; set; } = ColorViewModel.FromColor(System.Drawing.Color.Black);

        public static PFW_FontViewModel FromFont(PFW_Font input)
        {
            var output = new PFW_FontViewModel();
            output.Bold = input.Bold;
            output.Color = ColorViewModel.FromColor(input.Color);
            output.Italic = input.Italic;
            output.Size = input.Size;
            output.Underline = input.Underline;
            output.FontName = input.FontName;
            return output;
        }

        public PFW_Font Export()
        {
            return new PFW_Font()
                .SetBold(Bold)
                .SetColor(Color.Export())
                .SetFontName(FontName)
                .SetItalic(Italic)
                .SetSize(Size)
                .SetUderline(Underline);
            
        }
    }
}
