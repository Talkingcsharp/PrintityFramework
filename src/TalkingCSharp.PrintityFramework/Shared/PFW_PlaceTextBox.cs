using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared
{
    public class PFW_PlaceTextBox
    {
        public Rectangle Bounds { get; set; }
        public string Text { get; set; }
        public PFW_Font Font { get; set; }
        public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
        public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;
    }
}
