using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared.Core;

namespace PrintityFramework.Shared;

public class PFW_TableColumn
{
    public string? PropertyName { get; set; }
    public string? HeaderText { get; set; }
    public float Width { get; set; }
    public PFW_MeasurementsEnum WidthUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public PFW_Font? HeaderFont { get; set; }
    public PFW_Font? Font { get; set; }
    public PFW_Font? AlternatingFont { get; set; }
    public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
    public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;

    public PFW_TableColumn SetPropertyName(string propertyName)
    {
        this.PropertyName = propertyName;
        return this;
    }

    public PFW_TableColumn SetHeaderText(string displayValue)
    {
        this.HeaderText = displayValue;
        return this;
    }

    public PFW_TableColumn SetWidth(int width, PFW_MeasurementsEnum unit)
    {
        this.Width = width;
        this.WidthUnit = unit;
        return this;
    }
    public PFW_TableColumn SetHeaderFont(PFW_Font font)
    {
        this.HeaderFont = font;
        return this;
    }

    public PFW_TableColumn SetFont(PFW_Font font)
    {
        this.Font = font;
        return this;
    }

    public PFW_TableColumn SetAlternatingFont(PFW_Font font)
    {
        this.AlternatingFont = font;
        return this;
    }

    public PFW_TableColumn SetHeaderHAlign(PFW_HorizontalAlignment align)
    {
        this.HeaderHAlign = align;
        return this;
    }

    public PFW_TableColumn SetHeaderVAlign(PFW_VerticalAlignment align)
    {
        this.HeaderVAlien = align;
        return this;
    }

    public PFW_TableColumn SetHAlign(PFW_HorizontalAlignment align)
    {
        this.HAlign = align;
        return this;
    }

    public PFW_TableColumn SetVAlign(PFW_VerticalAlignment align)
    {
        this.VAlien = align;
        return this;
    }

    public void Draw(XGraphics graphic, XRect bounds, string value)
    {
        graphic.DrawRectangle(Font?.GetXPen(), bounds);
        XTextFormatter formatter = new XTextFormatter(graphic);
        formatter.Alignment = PFW_Helper.GetParagraphAlign(HAlign);
        formatter.DrawString(value,
            Font?.GetXFont(),
            Font?.GetXBrush(),
            bounds,
            XStringFormats.TopLeft);
    }

    public void DrawHeader(XGraphics graphic, XRect bounds)
    {
        graphic.DrawRectangle(HeaderFont?.GetXPen(), bounds);
        XTextFormatter formatter = new XTextFormatter(graphic);
        formatter.Alignment = PFW_Helper.GetParagraphAlign(HeaderHAlign);
        formatter.DrawString(HeaderText,
            HeaderFont?.GetXFont(),
            HeaderFont?.GetXBrush(),
            bounds,
            XStringFormats.TopLeft);
    }

}

