using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class PFW_PlaceLabelViewModel
    {
        public ColorViewModel BackgroundColor { get; set; } = ColorViewModel.FromColor( PFW_Defaults.DefaultBackgroundColor);
        public RectangleF Bounds { get; set; }
        public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
        public string Text { get; set; } = "";
        public PFW_FontViewModel Font { get; set; }
        public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
        public PFW_BorderViewModel Border { get; set; }
    }
}
