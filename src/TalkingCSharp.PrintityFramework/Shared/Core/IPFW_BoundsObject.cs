using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared.Core
{
    public interface IPFW_BoundsObject
    {
        RectangleF Bounds { get; set; }
        PFW_MeasurementsEnum BoundsUnit { get; set; }
    }
}
