using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class PFW_PlaceHeaderValueViewModel
    {
        public RectangleF Bounds { get; set; }
        public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
        public RectangleF HeaderBounds { get; set; }
        public PFW_MeasurementsEnum HeaderBoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
        public string Header { get; set; } = "";
        public string Text { get; set; } = "";
        public PFW_FontViewModel Font { get; set; }
        public PFW_FontViewModel HeaderFont { get; set; }
        public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
        public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
        public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
        public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;
        public ColorViewModel BackGroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBackgroundColor);
        public ColorViewModel HeaderBackgroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultHeraderBackgroundColor);

        public PFW_BorderViewModel Border { get; set; }
        public PFW_BorderViewModel HeaderBorder { get; set; }
    }
}
