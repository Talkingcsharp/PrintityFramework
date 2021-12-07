using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared.Core
{
    public interface IPFW_DrawableObject
    {
        void Draw(XGraphics graphic, PdfPage page);
    }
}
