namespace PrintityFramework.Shared;

public class PFW_Column
{
    public string? PropertyName { get; set; }
    public string? DisplayValue { get; set; }
    public float Width { get; set; }
    public PFW_MeasurementsEnum WidthUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public PFW_Font? HeaderFont { get; set; }
    public PFW_Font? Font { get; set; }
    public PFW_Font? AlternatingFont { get; set; }
    public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
    public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;

    public PFW_Column SetPropertyName(string propertyName)
    {
        this.PropertyName = propertyName;
        return this;
    }

    public PFW_Column SetDisplayValue(string displayValue)
    {
        this.DisplayValue = displayValue;
        return this;
    }

    public PFW_Column SetWidth(int width, PFW_MeasurementsEnum unit)
    {
        this.Width = width;
        this.WidthUnit = unit;
        return this;
    }
    public PFW_Column SetHeaderFont(PFW_Font font)
    {
        this.HeaderFont = font;
        return this;
    }

    public PFW_Column SetFont(PFW_Font font)
    {
        this.Font = font;
        return this;
    }

    public PFW_Column SetAlternatingFont(PFW_Font font)
    {
        this.AlternatingFont = font;
        return this;
    }

    public PFW_Column SetHeaderHAlign(PFW_HorizontalAlignment align)
    {
        this.HeaderHAlign = align;
        return this;
    }

    public PFW_Column SetHeaderVAlign(PFW_VerticalAlignment align)
    {
        this.HeaderVAlien = align;
        return this;
    }

    public PFW_Column SetHAlign(PFW_HorizontalAlignment align)
    {
        this.HAlign = align;
        return this;
    }

    public PFW_Column SetVAlign(PFW_VerticalAlignment align)
    {
        this.VAlien = align;
        return this;
    }
}

