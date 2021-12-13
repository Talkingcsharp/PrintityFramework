using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace PrintityFramework;

public class PFW_PlaceHeaderValue: IPFW_HeaderBoundsObject, IPFW_DrawableObject
{
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public RectangleF HeaderBounds { get; set; }
    public PFW_MeasurementsEnum HeaderBoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public string Header { get; set; } = "";
    public string Text { get; set; } = "";
    public PFW_Font Font { get; set; } = PFW_Defaults.DefaultFont;
    public PFW_Font HeaderFont { get; set; } = PFW_Defaults.DefaultHeaderFont;
    public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
    public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;
    public Color BackGroundColor { get; set; } = PFW_Defaults.DefaultBackgroundColor;
    public Color HeaderBackgroundColor { get; set; } = PFW_Defaults.DefaultHeraderBackgroundColor;

    public PFW_Border Border { get; set; } = PFW_Defaults.DefaultBorder;
    public PFW_Border HeaderBorder { get; set; } = PFW_Defaults.DefaultBorder;

    public PFW_PlaceHeaderValue SetBorder(PFW_Border border)
    {
        this.Border = border;
        return this;
    }

    public PFW_PlaceHeaderValue SetHeaderBorder(PFW_Border border)
    {
        this.HeaderBorder = border;
        return this;
    }
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

    public PFW_PlaceHeaderValue SetBackgroundColor(Color color)
    {
        this.BackGroundColor = color;
        return this;
    }

    public PFW_PlaceHeaderValue SetHeaderBackgroundColor(Color color)
    {
        this.HeaderBackgroundColor = color;
        return this;
    }

    public void Draw(XGraphics graphic, PdfPage page)
    {
        DrawHeaderBackground(graphic, page);
        DrawHeaderBorders(graphic, page);
        DrawHeaderText(graphic, page);
        DrawBackground(graphic, page);
        DrawBorders(graphic, page);
        DrawText(graphic, page);
    }
    private void DrawBackground(XGraphics graphic,PdfPage page)
    {
        if (BackGroundColor != Color.Transparent)
        {
            graphic.DrawRectangle(new XSolidBrush(XColor.FromArgb(BackGroundColor.ToArgb())), PFW_MeasurementesHelper.GetBounds(this, page));
        }
    }
    private void DrawBorders(XGraphics graphic, PdfPage page)
    {
        Border.Draw(graphic, PFW_MeasurementesHelper.GetBounds(this, page));
        
    }

    private void DrawText(XGraphics graphic, PdfPage page)
    {
        PFW_TextHelper.DrawText(graphic, Text, Font, PFW_MeasurementesHelper.GetBounds(this, page), true, HAlign);
    }

    private void DrawHeaderBackground(XGraphics graphic,PdfPage page)
    {
        if (HeaderBackgroundColor != Color.Transparent)
        {
            graphic.DrawRectangle(new XSolidBrush(XColor.FromArgb(HeaderBackgroundColor.ToArgb())), PFW_MeasurementesHelper.GetHeaderBounds(this, page));
        }
    }
    private void DrawHeaderBorders(XGraphics graphic,PdfPage page)
    {
        HeaderBorder.Draw(graphic, PFW_MeasurementesHelper.GetHeaderBounds(this, page));
    }
    private void DrawHeaderText(XGraphics graphic,PdfPage page)
    {
        PFW_TextHelper.DrawText(graphic, Header, HeaderFont, PFW_MeasurementesHelper.GetHeaderBounds(this, page), true, HeaderHAlign);
    }
}

