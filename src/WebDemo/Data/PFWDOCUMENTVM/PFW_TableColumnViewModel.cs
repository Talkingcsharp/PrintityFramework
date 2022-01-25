using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.ComponentModel;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class PFW_TableColumnViewModel
    {
        [DefaultValue("")]
        public string PropertyName { get; set; } = "";
        [DefaultValue("")]
        public string HeaderText { get; set; } = "";
        [DefaultValue(100)]
        public float Width { get; set; }
        [DefaultValue(PFW_MeasurementsEnum.Dot)]
        public PFW_MeasurementsEnum WidthUnit { get; set; }
        public PFW_FontViewModel HeaderFont { get; set; } = PFW_FontViewModel.FromFont(PFW_Defaults.DefaultHeaderFont);
        public PFW_FontViewModel Font { get; set; } = PFW_FontViewModel.FromFont(PFW_Defaults.DefaultFont);
        public PFW_FontViewModel AlternatingFont { get; set; } = PFW_FontViewModel.FromFont(PFW_Defaults.DefaultAlternateFont);
        public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
        public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
        public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
        public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;
        public ColorViewModel BackgroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBackgroundColor);
        public ColorViewModel HeaderBackgroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultHeraderBackgroundColor);
        public ColorViewModel AlternateBackgroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultAlternatingBackgroundColor);
        public PFW_BorderViewModel Border { get; set; }
        public PFW_BorderViewModel HeaderBorder { get; set; }

    }
}
