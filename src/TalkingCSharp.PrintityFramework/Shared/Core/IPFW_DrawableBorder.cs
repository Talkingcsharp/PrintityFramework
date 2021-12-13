using PdfSharpCore.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared.Core
{
    public interface IPFW_DrawableBorder
    {
        void Draw(XGraphics graphics, XRect bounds);
    }
}
