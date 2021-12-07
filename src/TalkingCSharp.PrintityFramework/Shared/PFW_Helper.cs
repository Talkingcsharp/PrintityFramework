using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared.Core;
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

        public static XRect GetBounds(IPFW_BoundsObject source, PdfPage page)
        {
            return new XRect
            {
                X = PFW_Helper.LocationHelperX(source.Bounds.X, source.BoundsUnit, page),
                Y = PFW_Helper.LocationHelperY(source.Bounds.Y, source.BoundsUnit, page),
                Height = PFW_Helper.SizeHelper(source.Bounds.Size, source.BoundsUnit, page).Height,
                Width = PFW_Helper.SizeHelper(source.Bounds.Size, source.BoundsUnit, page).Width
            };
        }
        public static XTextFormatter GetTextFormatter(XGraphics graphics,PFW_HorizontalAlignment hAlign, PFW_VerticalAlignment vAlign)
        {
            var output = new XTextFormatter(graphics);
            if(hAlign == PFW_HorizontalAlignment.Left)
            {
                output.Alignment = XParagraphAlignment.Left;
            }

            if (hAlign == PFW_HorizontalAlignment.Center)
            {
                output.Alignment = XParagraphAlignment.Center;
            }

            if (hAlign == PFW_HorizontalAlignment.Right)
            {
                output.Alignment = XParagraphAlignment.Right;
            }
            return output;
        }
        public static XStringFormat GetStringFormat(PFW_HorizontalAlignment hAlign,PFW_VerticalAlignment vAligm)
        {
            switch (hAlign)
            {
                case (PFW_HorizontalAlignment.Left):
                    switch (vAligm)
                    {
                        case PFW_VerticalAlignment.Top: return XStringFormats.TopLeft;
                        case PFW_VerticalAlignment.Middle: return XStringFormats.CenterLeft;
                        default: return XStringFormats.BottomLeft;
                    }
                case (PFW_HorizontalAlignment.Center):
                    switch (vAligm)
                    {
                        case PFW_VerticalAlignment.Top: return XStringFormats.TopCenter;
                        case PFW_VerticalAlignment.Middle: return XStringFormats.Center;
                        default: return XStringFormats.BottomCenter;
                    }
                case (PFW_HorizontalAlignment.Right):
                    switch (vAligm)
                    {
                        case PFW_VerticalAlignment.Top: return XStringFormats.TopRight;
                        case PFW_VerticalAlignment.Middle: return XStringFormats.CenterRight;
                        default: return XStringFormats.BottomRight;
                    }
                default:
                    return XStringFormats.Center;
            }
        }

        public static XParagraphAlignment GetParagraphAlign(PFW_HorizontalAlignment hAlign)
        {
            if(hAlign == PFW_HorizontalAlignment.Left)
            {
                return XParagraphAlignment.Left;
            }

            if(hAlign == PFW_HorizontalAlignment.Right)
            {
                return XParagraphAlignment.Right;
            }

            return XParagraphAlignment.Center;
        }
    }
}
