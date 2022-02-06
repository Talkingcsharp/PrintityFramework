using PdfSharpCore.Drawing;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;

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
    public Color BackgroundColor { get; set; } = PFW_Defaults.DefaultBackgroundColor;
    public Color HeaderBackgroundColor { get; set; } = PFW_Defaults.DefaultHeraderBackgroundColor;
    public Color AlternateBackgroundColor { get; set; } = PFW_Defaults.DefaultAlternatingBackgroundColor;
    public PFW_Border Border { get; set; } = PFW_Defaults.DefaultBorder;
    public PFW_Border HeaderBorder { get; set; } = PFW_Defaults.DefaultBorder;
    public PFW_TableColumn SetBorder(PFW_Border border)
    {
        this.Border = border;
        return this;
    }

    public PFW_TableColumn SetHeaderBorder(PFW_Border border)
    {
        this.HeaderBorder = border;
        return this;
    }
    public PFW_TableColumn SetBackgroundColor(Color color)
    {
        this.BackgroundColor = color;
        return this;
    }

    public PFW_TableColumn SetAlternateBackgroundColor(Color color)
    {
        this.AlternateBackgroundColor = color;
        return this;
    }

    public PFW_TableColumn SetHeaderBackgroundColor(Color color)
    {
        this.HeaderBackgroundColor = color;
        return this;
    }
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

    public PFW_TableColumn SetWidth(float width, PFW_MeasurementsEnum unit)
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
        DrawBackGround(graphic, bounds, isAlternate);
        DrawBorder(graphic, bounds);
        DrawText(graphic, bounds, value, isAlternate);
    }
    public void DrawHeader(XGraphics graphic, XRect bounds)
    {
        DrawHeaderBackground(graphic, bounds);
        DrawHeaderBorder(graphic, bounds);
        DrawHeaderText(graphic, bounds);
    }

    private void DrawBackGround(XGraphics graphic, XRect bounds, bool isAlternate)
    {
        if (isAlternate)
        {
            if (AlternateBackgroundColor != Color.Transparent)
            {
                graphic.DrawRectangle(new XSolidBrush(XColor.FromArgb(AlternateBackgroundColor.ToArgb())), bounds);
            }
        }
        else
        {
            if (BackgroundColor != Color.Transparent)
            {
                graphic.DrawRectangle(new XSolidBrush(XColor.FromArgb(BackgroundColor.ToArgb())), bounds);
            }
        }
    }
    private void DrawBorder(XGraphics graphic, XRect bounds)
    {
        Border.Draw(graphic, bounds);
    }
    private void DrawText(XGraphics graphic, XRect bounds, string value, bool isAlternate)
    {
        if (isAlternate)
        {
            PFW_TextHelper.DrawText(graphic, value, AlternatingFont, bounds, true, HAlign);
        }
        else
        {
            PFW_TextHelper.DrawText(graphic, value, Font, bounds, true, HAlign);
        }
    }
    private void DrawHeaderBackground(XGraphics graphic, XRect bounds)
    {
        if (HeaderBackgroundColor != Color.Transparent)
        {
            graphic.DrawRectangle(new XSolidBrush(XColor.FromArgb(HeaderBackgroundColor.ToArgb())), bounds);
        }
    }
    private void DrawHeaderBorder(XGraphics graphic, XRect bounds)
    {
        HeaderBorder.Draw(graphic, bounds);
    }
    private void DrawHeaderText(XGraphics graphic, XRect bounds)
    {
        PFW_TextHelper.DrawText(graphic, HeaderText, HeaderFont, bounds, true, HeaderHAlign);
    }
}

