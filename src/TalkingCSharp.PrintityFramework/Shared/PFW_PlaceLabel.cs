using System.Drawing;

namespace PrintityFramework.Shared;

public class PFW_PlaceLabel
{
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Px;
    public string Text { get; set; }
    public PFW_Font Font { get; set; }
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;
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
        this.VAlien = align;
        return this;
    }
}

