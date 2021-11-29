using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework.Shared
{
    public class PFW_Helper
    {
        public static double LocationHelperX(float src,PFW_MeasurementsEnum measure,PdfPage page)
        {
            XUnit pdfUnit = new XUnit();
            if(measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Point = src;
            }
            if(measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src * page.Width.Millimeter / 100;
            }
            return pdfUnit.Millimeter;
        }

        public static double LocationHelperY(float src, PFW_MeasurementsEnum measure, PdfPage page)
        {
            XUnit pdfUnit = new XUnit();
            if (measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Point = src;
            }
            if (measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src * page.Height.Millimeter / 100;
            }
            return pdfUnit.Millimeter;
        }

        public static SizeF SizeHelper(SizeF src, PFW_MeasurementsEnum measure, PdfPage page)
        {
            XUnit pdfUnit = new XUnit();
            SizeF output = new SizeF();
            if (measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Point = src.Width;
            }
            if (measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src.Width * page.Width.Millimeter / 100;
            }
            output.Width = (float)pdfUnit.Millimeter;

            if (measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Point = src.Height;
            }
            if (measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src.Height * page.Height.Millimeter / 100;
            }
            output.Height = (float)pdfUnit.Millimeter;

            return output;
        }
    }
}
