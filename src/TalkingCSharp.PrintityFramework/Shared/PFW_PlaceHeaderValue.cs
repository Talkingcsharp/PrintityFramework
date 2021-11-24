using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared
{
    public class PFW_PlaceHeaderValue
    {
        public Rectangle Bounds { get; set; }
        public Rectangle HeaderBounds { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public PFW_Font Font { get; set; }
        public PFW_Font HeaderFont { get; set; }
        public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
        public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
        public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
        public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;
    }
}
