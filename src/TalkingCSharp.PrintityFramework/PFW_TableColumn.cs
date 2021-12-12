using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;

namespace PrintityFramework;

public class PFW_TableColumn : IPFW_DrawableColumn
{
    public string PropertyName { get; set; } = "";
    public string HeaderText { get; set; } = "";
    public float Width { get; set; }
    public PFW_MeasurementsEnum WidthUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public PFW_Font HeaderFont { get; set; } = PFW_Defaults.DefaultHeaderFont;
    public PFW_Font Font { get; set; } = PFW_Defaults.DefaultFont;
    public PFW_Font AlternatingFont { get; set; } = PFW_Defaults.DefaultAlternateFont;
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

    public void Draw(XGraphics graphic, XRect bounds, string value, bool isAlternate)
    {
        graphic.DrawRectangle(Font.GetXPen(), bounds);
        if (isAlternate)
        {
            PFW_TextHelper.DrawText(graphic, value, AlternatingFont, bounds, true, HAlign);
        }
        else
        {   
            PFW_TextHelper.DrawText(graphic, value, Font, bounds, true, HAlign);
        }
        
    }

    public void DrawHeader(XGraphics graphic, XRect bounds)
    {
        graphic.DrawRectangle(HeaderFont.GetXPen(), bounds);
        PFW_TextHelper.DrawText(graphic, HeaderText, HeaderFont, bounds, true, HeaderHAlign);
    }

}

