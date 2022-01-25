using PrintityFramework;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class PFW_BorderViewModel
    {
        public ColorViewModel BorderColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBorderColor);
        public ColorViewModel TopBorderColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBorderColor);
        public ColorViewModel LeftBorderColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBorderColor);
        public ColorViewModel BottomBorderColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBorderColor);
        public ColorViewModel RightBorderColor { get; set; } = ColorViewModel.FromColor(PFW_Defaults.DefaultBorderColor);
        public float BorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float TopBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float LeftBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float BottomBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float RightBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;

        public PFW_Border Export()
        {
            return new PFW_Border()
                .SetBorderColor(BorderColor.Export())
                .SetBorderSize(BorderSize)
                .SetBottomBorderColor(BottomBorderColor.Export())
                .SetBottomBorderSize(BottomBorderSize)
                .SetLeftBorderColor(LeftBorderColor.Export())
                .SetLeftBorderSize(LeftBorderSize)
                .SetRightBorderColor(RightBorderColor.Export())
                .SetRightBorderSize(RightBorderSize)
                .SetTopBorderColor(TopBorderColor.Export())
                .SetTopBorderSize(TopBorderSize);
        }
    }
}
