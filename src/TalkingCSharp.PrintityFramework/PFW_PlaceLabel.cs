using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.ComponentModel;
using System.Drawing;
namespace PrintityFramework;

public class PFW_PlaceLabel : IPFW_BoundsObject , IPFW_DrawableObject
{
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public string Text { get; set; } = "";
    public PFW_Font Font { get; set; } = PFW_Defaults.DefaultFont;
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    [Obsolete]
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
    [Obsolete]
    public PFW_PlaceLabel SetVAlign(PFW_VerticalAlignment align)
    {
        this.VAlign = align;
        return this;
    }

    public void Draw(XGraphics graphic, PdfPage page)
    {
        DrawBorders(graphic, page);
        DrawText(graphic, page);
    }

    private void DrawBorders(XGraphics graphic, PdfPage page)
    {
        graphic.DrawRectangle(Font?.GetXPen(), PFW_MeasurementesHelper.GetBounds(this, page));
    }

    private void DrawText(XGraphics graphic, PdfPage page)
    {
        PFW_TextHelper.DrawText(graphic, Text, Font, PFW_MeasurementesHelper.GetBounds(this, page), true, HAlign);
        //XTextFormatter formatter = new XTextFormatter(graphic);
        //formatter.Alignment = PFW_MeasurementesHelper.GetParagraphAlign(HAlign);
        //formatter.DrawString(Text,
        //    Font?.GetXFont(),
        //    Font?.GetXBrush(),
        //    PFW_MeasurementesHelper.GetBounds(this, page),
        //    XStringFormats.TopLeft);
    }
}

