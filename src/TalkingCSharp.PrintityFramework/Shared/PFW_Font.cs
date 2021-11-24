using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared
{
    public class PFW_Font
    {
        public string FontName { get; set; } = "Arial";
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public bool Underline { get; set; }
        public int Size { get; set; }
        public Color Color { get; set; } = Color.FromArgb(0, 0, 0);
    }
}
