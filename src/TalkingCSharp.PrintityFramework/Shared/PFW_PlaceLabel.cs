using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared.Core;
using System.Drawing;
namespace PrintityFramework.Shared;

public class PFW_PlaceLabel : IPFW_BoundsObject
{
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public string? Text { get; set; }
    public PFW_Font? Font { get; set; }
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    public PFW_VerticalAlignment VAlign { get; set; } = PFW_VerticalAlignment.Middle;
    public PFW_PlaceLabel SetBounds(RectangleF bounds, PFW_MeasurementsEnum unit)
    {
        this.Bounds = bounds;
        this.BoundsUnit = unit;
        return this;
    }

    public PFW_PlaceLabel SetText(string text)
    {
        this.Text = text;
        return this;
    }

    public PFW_PlaceLabel SetFont(PFW_Font font)
    {
        this.Font = font;
        return this;
    }
    public PFW_PlaceLabel SetHAlign(PFW_HorizontalAlignment align)
    {
        this.HAlign = align;
        return this;
    }
    public PFW_PlaceLabel SetVAlign(PFW_VerticalAlignment align)
    {
        this.VAlign = align;
        return this;
    }

    public void Draw(XGraphics graphic, PdfPage page)
    {
        DrawRectangle(graphic, page);
        DrawText(graphic, page);
    }

    private void DrawRectangle(XGraphics graphic, PdfPage page)
    {
        graphic.DrawRectangle(Font?.GetXPen(), PFW_Helper.GetBounds(this, page));
    }

    private void DrawText(XGraphics graphic, PdfPage page)
    {
        XTextFormatter formatter = new XTextFormatter(graphic);
        //formatter.LayoutRectangle = PFW_Helper.GetBounds(this, page);
        //formatter.Text = Text;
        //formatter.Font = Font?.GetXFont();
        //formatter.Alignment = XParagraphAlignment.Center;
        formatter.DrawString(Text,
            Font?.GetXFont(),
            Font?.GetXBrush(),
            PFW_Helper.GetBounds(this, page),
            XStringFormats.TopLeft);


        //graphic.DrawString(Text,
        //    Font?.GetXFont(),
        //    Font?.GetXBrush(),
        //    PFW_Helper.GetBounds(this, page),
        //    PFW_Helper.GetStringFormat(HAlign, VAlign));
    }
}

