using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared
{
    public class PFW_Table
    {
        public ICollection<PFW_Column> Columns { get; set; } = new List<PFW_Column>();
        public int RowHeaderHeight { get; set; } = 50;
        public PFW_MeasurementsEnum RowHeaderHeightUnit { get; set; } = PFW_MeasurementsEnum.Px;
        public int RowHeight { get; set; } = 40;
        public PFW_MeasurementsEnum RowHeightUnit { get; set; } = PFW_MeasurementsEnum.Px;

        public List<object> Data { get; set; } = new List<object>();

        public int Width { get; set; } = 90;
        public PFW_MeasurementsEnum WidthUnit { get; set; } = PFW_MeasurementsEnum.Percent;

        public int StartX { get; set; } = 5;
        public PFW_MeasurementsEnum StartXUnit { get; set; } = PFW_MeasurementsEnum.Percent;
        public int StartY { get; set; } = 200;
        public PFW_MeasurementsEnum StartYUnit { get; set; } = PFW_MeasurementsEnum.Px;

        public int Height { get; set; } = 80;
        public PFW_MeasurementsEnum HeightUnit { get; set; } = PFW_MeasurementsEnum.Percent;
    }
}
