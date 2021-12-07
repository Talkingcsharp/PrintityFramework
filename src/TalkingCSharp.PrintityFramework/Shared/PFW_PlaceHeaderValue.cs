using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace PrintityFramework.Shared;

public class PFW_PlaceHeaderValue: IPFW_HeaderBoundsObject, IPFW_DrawableObject
{
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public RectangleF HeaderBounds { get; set; }
    public PFW_MeasurementsEnum HeaderBoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public string? Header { get; set; }
    public string? Text { get; set; }
    public PFW_Font? Font { get; set; }
    public PFW_Font? HeaderFont { get; set; }
    public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
    public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;

    public PFW_PlaceHeaderValue SetBounds(RectangleF bounds, PFW_MeasurementsEnum unit)
    {
        this.Bounds = bounds;
        this.BoundsUnit = unit;
        return this;
    }
    public PFW_PlaceHeaderValue SetHeaderBounds(RectangleF bounds, PFW_MeasurementsEnum unit)
    {
        this.HeaderBounds = bounds;
        this.HeaderBoundsUnit = unit;
        return this;
    }
    public PFW_PlaceHeaderValue SetHeader(string header)
    {
        this.Header = header;
        return this;
    }
    public PFW_PlaceHeaderValue SetText(string text)
    {
        this.Text = text;
        return this;
    }

    public PFW_PlaceHeaderValue SetFont(PFW_Font font)
    {
        this.Font = font;
        return this;
    }

    public PFW_PlaceHeaderValue SetHeaderFont(PFW_Font font)
    {
        this.HeaderFont = font;
        return this;
    }
    public PFW_PlaceHeaderValue SetHeaderHAlign(PFW_HorizontalAlignment align)
    {
        this.HeaderHAlign = align;
        return this;
    }
    public PFW_PlaceHeaderValue SetHeaderVAlign(PFW_VerticalAlignment align)
    {
        this.HeaderVAlien = align;
        return this;
    }

    public PFW_PlaceHeaderValue SetHAlign(PFW_HorizontalAlignment align)
    {
        this.HAlign = align;
        return this;
    }
    public PFW_PlaceHeaderValue SetVAlign(PFW_VerticalAlignment align)
    {
        this.VAlien = align;
        return this;
    }

    public void Draw(XGraphics graphic, PdfPage page)
    {
        DrawHeaderBorders(graphic, page);
        DrawHeaderText(graphic, page);
        DrawBorders(graphic, page);
        DrawText(graphic, page);
    }

    private void DrawBorders(XGraphics graphic, PdfPage page)
    {
        graphic.DrawRectangle(Font?.GetXPen(), PFW_Helper.GetBounds(this, page));
    }

    private void DrawText(XGraphics graphic, PdfPage page)
    {
        XTextFormatter formatter = new XTextFormatter(graphic);
        formatter.Alignment = PFW_Helper.GetParagraphAlign(HAlign);
        formatter.DrawString(Text,
            Font?.GetXFont(),
            Font?.GetXBrush(),
            PFW_Helper.GetBounds(this, page),
            XStringFormats.TopLeft);
    }

    private void DrawHeaderBorders(XGraphics graphic,PdfPage page)
    {
        graphic.DrawRectangle(HeaderFont?.GetXPen(), PFW_Helper.GetHeaderBounds(this, page));
    }
    private void DrawHeaderText(XGraphics graphic,PdfPage page)
    {
        XTextFormatter formatter = new XTextFormatter(graphic);
        formatter.Alignment = PFW_Helper.GetParagraphAlign(HeaderHAlign);
        formatter.DrawString(Header,
            HeaderFont?.GetXFont(),
            HeaderFont?.GetXBrush(),
            PFW_Helper.GetHeaderBounds(this, page),
            XStringFormats.TopLeft);
    }
}

