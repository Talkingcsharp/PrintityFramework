using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;
namespace PrintityFramework;

public class PFW_Document
{
    public PFW_PaperSizesEnum PaperSize { get; set; } = PFW_PaperSizesEnum.A4;
    private Size _Size { 
        get
        {
            if(PaperSize== PFW_PaperSizesEnum.A4)
            {
                return new Size
                {
                    Height = 297,
                    Width = 210
                };
            }
            if(PaperSize == PFW_PaperSizesEnum.A5)
            {
                return new Size
                {
                    Height = 210,
                    Width = 184
                };
            }
            
            throw new NotSupportedException("Selected paper size is not supported");
        }
        set{}
    }
    public List<IPFW_DrawableTable> Tables { get; set; } = new List<IPFW_DrawableTable>();
    public List<PFW_PlaceLabel> Labels { get; set; } = new List<PFW_PlaceLabel>();
    public List<PFW_PlaceHeaderValue> PlaceHeaderValues { get; set; } = new List<PFW_PlaceHeaderValue>();

    public PFW_Document AddTable(IPFW_DrawableTable table)
    {
        Tables.Add(table);
        return this;
    }

    public PFW_Document AddHeaderValue(PFW_PlaceHeaderValue headerValue)
    {
        this.PlaceHeaderValues.Add(headerValue);
        return this;
    }

    public PFW_Document AddLabel(PFW_PlaceLabel label)
    {
        this.Labels.Add(label);
        return this;
    }

    public SizeF GetSize()
    {
        return new SizeF
        {
            Height = (float)new XUnit(_Size.Height, XGraphicsUnit.Millimeter).Value,
            Width = (float)new XUnit(_Size.Width, XGraphicsUnit.Millimeter).Value
        };
    }

    public Stream CreateDocument()
    {
        PdfSharpCore.Pdf.PdfDocument document = new PdfSharpCore.Pdf.PdfDocument();
        var page = document.AddPage();
        page.Height = new XUnit(_Size.Height, XGraphicsUnit.Millimeter);
        page.Width = new XUnit(_Size.Width, XGraphicsUnit.Millimeter);
        var graphic = XGraphics.FromPdfPage(page);

        foreach(var item in Labels)
        {
            item.Draw(graphic, page);
            graphic.DrawRectangle(XPens.Black, new XRect
            {
                X = PFW_MeasurementesHelper.LocationHelperX(item.Bounds.X, item.BoundsUnit, page),
                Y = PFW_MeasurementesHelper.LocationHelperY(item.Bounds.Y, item.BoundsUnit, page),
                Height = PFW_MeasurementesHelper.SizeHelper(item.Bounds.Size, item.BoundsUnit, page).Height,
                Width = PFW_MeasurementesHelper.SizeHelper(item.Bounds.Size, item.BoundsUnit, page).Width
            });

            graphic.DrawString(item.Text, 
                new XFont(item.Font?.FontName, item.Font?.Size?? 0, XFontStyle.Regular),
                XBrushes.Black, 
                new XPoint(PFW_MeasurementesHelper.LocationHelperX(item.Bounds.X, item.BoundsUnit, page),
                PFW_MeasurementesHelper.LocationHelperY(item.Bounds.Y, item.BoundsUnit, page)));
        }
        MemoryStream ms = new MemoryStream();
        document.Save(ms, true);
        return ms;
    }

    public void CreateDocument(string fileName)
    {
        PdfDocument document = new PdfDocument();
        var page = document.AddPage();
        var graphic = XGraphics.FromPdfPage(page);

        foreach (var item in Labels)
        {
            item.Draw(graphic, page);
        }

        foreach(var item in PlaceHeaderValues)
        {
            item.Draw(graphic, page);
        }

        foreach(var item in Tables)
        {
            item.Draw(graphic, page, 0);
        }
        document.Save(fileName);
    }
}

