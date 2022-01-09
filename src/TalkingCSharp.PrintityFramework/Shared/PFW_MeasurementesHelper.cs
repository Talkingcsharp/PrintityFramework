using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace PrintityFramework.Shared
{
    public class PFW_MeasurementesHelper
    {
        public static double LocationHelperX(float src, PFW_MeasurementsEnum measure, PdfPage page)
        {
            XUnit pdfUnit = new XUnit();
            if (measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Millimeter = src;
            }
            if (measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src * page.Width.Millimeter / 100;
            }
            return pdfUnit.Point;
        }
        public static double LocationHelperY(float src, PFW_MeasurementsEnum measure, PdfPage page)
        {
            XUnit pdfUnit = new XUnit();
            if (measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Millimeter = src;
            }
            if (measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src * page.Height.Millimeter / 100;
            }
            return pdfUnit.Point;
        }
        public static SizeF SizeHelper(SizeF src, PFW_MeasurementsEnum measure, PdfPage page)
        {
            XUnit pdfUnit = new XUnit();
            SizeF output = new SizeF();
            if (measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Millimeter = src.Width;
            }
            if (measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src.Width / 100 * page.Width.Millimeter;
            }
            output.Width = (float)pdfUnit.Point;

            if (measure == PFW_MeasurementsEnum.Dot)
            {
                pdfUnit.Millimeter = src.Height;
            }
            if (measure == PFW_MeasurementsEnum.Percent)
            {
                pdfUnit.Millimeter = src.Height / 100 * page.Height.Millimeter;
            }
            output.Height = (float)pdfUnit.Point;

            return output;
        }
        public static XRect GetBounds(IPFW_BoundsObject source, PdfPage page)
        {
            return new XRect
            {
                X = PFW_MeasurementesHelper.LocationHelperX(source.Bounds.X, source.BoundsUnit, page),
                Y = PFW_MeasurementesHelper.LocationHelperY(source.Bounds.Y, source.BoundsUnit, page),
                Height = PFW_MeasurementesHelper.SizeHelper(source.Bounds.Size, source.BoundsUnit, page).Height,
                Width = PFW_MeasurementesHelper.SizeHelper(source.Bounds.Size, source.BoundsUnit, page).Width
            };
        }
        public static XRect GetHeaderBounds(IPFW_HeaderBoundsObject source, PdfPage page)
        {
            return new XRect
            {
                X = PFW_MeasurementesHelper.LocationHelperX(source.HeaderBounds.X, source.HeaderBoundsUnit, page),
                Y = PFW_MeasurementesHelper.LocationHelperY(source.HeaderBounds.Y, source.HeaderBoundsUnit, page),
                Height = PFW_MeasurementesHelper.SizeHelper(source.HeaderBounds.Size, source.HeaderBoundsUnit, page).Height,
                Width = PFW_MeasurementesHelper.SizeHelper(source.HeaderBounds.Size, source.HeaderBoundsUnit, page).Width
            };
        }
        public static XTextFormatter GetTextFormatter(XGraphics graphics, PFW_HorizontalAlignment hAlign, PFW_VerticalAlignment vAlign)
        {
            var output = new XTextFormatter(graphics);
            if (hAlign == PFW_HorizontalAlignment.Left)
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
        public static XStringFormat GetStringFormat(PFW_HorizontalAlignment hAlign, PFW_VerticalAlignment vAligm)
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
            if (hAlign == PFW_HorizontalAlignment.Left)
            {
                return XParagraphAlignment.Left;
            }

            if (hAlign == PFW_HorizontalAlignment.Right)
            {
                return XParagraphAlignment.Right;
            }

            return XParagraphAlignment.Center;
        }
        public static XRect GetTableColumnBounds<DataType>(XPoint startLocation, PdfPage page, PFW_Table<DataType> table, PFW_TableColumn column) where DataType : class
        {
            XRect parentBounds = GetBounds(table, page);
            float columnWidth;
            if(column.WidthUnit == PFW_MeasurementsEnum.Dot)
            {
                columnWidth = (float)XUnit.FromMillimeter(column.Width).Point;
            }
            else
            {
                columnWidth = (float) (column.Width / 100 * parentBounds.Width);
            }
            return new XRect
            {
                X = startLocation.X,
                Y = startLocation.Y,
                Height = XUnit.FromMillimeter(table.RowHeight).Point,
                Width = columnWidth
            };
        }
        public static XRect GetTableHeaderColumnBounds<DataType>(XPoint startLocation, PdfPage page, PFW_Table<DataType> table, PFW_TableColumn column) where DataType : class
        {
            XRect parentBounds = GetBounds(table, page);
            float columnWidth;
            if (column.WidthUnit == PFW_MeasurementsEnum.Dot)
            {
                columnWidth = (float)XUnit.FromMillimeter(column.Width).Point;
            }
            else
            {
                columnWidth = (float)(column.Width / 100 * parentBounds.Width);
            }
            return new XRect
            {
                X = startLocation.X,
                Y = startLocation.Y,
                Height = XUnit.FromMillimeter(table.RowHeaderHeight).Point,
                Width = columnWidth
            };
        }
    }
}
