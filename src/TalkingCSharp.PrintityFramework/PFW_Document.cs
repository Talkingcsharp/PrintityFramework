using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;
using System.Reflection.Metadata;

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
        PdfDocument document = new PdfDocument();
        var page = document.AddPage();
        DrawPage(page);
        while (Tables.Any(a => a.HasNewPages))
        {
            page = document.AddPage();
            DrawPage(page);
        }
        
        MemoryStream ms = new MemoryStream();
        document.Save(ms, true);
        return ms;
    }
    public List<MemoryStream> CreateDocumentAsImages()
    {
        PdfDocument document = new PdfDocument();
        var page = document.AddPage();
        DrawPage(page);
        while (Tables.Any(a => a.HasNewPages))
        {
            page = document.AddPage();
            DrawPage(page);
        }

        List<MemoryStream> output = new List<MemoryStream>();
        foreach(var item in document.Pages)
        {
            output.Add(GetPageasImage(item));
        }
        return output;
    }

    private MemoryStream GetPageasImage(PdfPage page)
    {
        
        XGraphics graphics = XGraphics.FromPdfPage(page);
        XImage image = XBitmapImage.CreateBitmap((int)page.Width.Point, (int)page.Height.Point);
        XGraphics imageGraphics = XGraphics.FromImage(image);
        imageGraphics.Restore(graphics.Save());
        return image.AsJpeg();
    }

    public void CreateDocument(string fileName)
    {
        PdfDocument document = new PdfDocument();
        var page = document.AddPage();
        DrawPage(page);
        while(Tables.Any(a => a.HasNewPages))
        {
            page = document.AddPage();
            DrawPage(page);
        }
        document.Save(fileName);
    }

    private void DrawPage(PdfPage page)
    {
        using (var graphic = XGraphics.FromPdfPage(page))
        {
            foreach (var item in Labels)
            {
                item.Draw(graphic, page);
            }
            foreach (var item in PlaceHeaderValues)
            {
                item.Draw(graphic, page);
            }
            foreach (var item in Tables)
            {
                item.Draw(graphic, page);
            }
        }
    }
}

