using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Collections;
using System.Drawing;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class PFW_TableViewModel
    {
        public ICollection<PFW_TableColumnViewModel> Columns { get; set; }
        public float RowHeaderHeight { get; set; }
        public float RowHeight { get; set; }
        public RectangleF Bounds { get; set; }
        public PFW_MeasurementsEnum BoundsUnit { get; set; }
        public ColorViewModel BackgroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBackgroundColor);
        public ColorViewModel HeaderBackgroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultHeraderBackgroundColor);
        public ColorViewModel AlternateBackgroundColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultAlternatingBackgroundColor);
        public IList? Data { get; set; }
    }
}
