namespace PrintityFramework.Shared;

public class PFW_Column
{
    public string PropertyName { get; set; }
    public string DisplayName { get; set; }
    public int Width { get; set; }
    public PFW_MeasurementsEnum WidthUnit { get; set; } = PFW_MeasurementsEnum.Px;
    public PFW_Font HeaderFont { get; set; }
    public PFW_Font Font { get; set; }
    public PFW_Font AlternatingFont { get; set; }
    public PFW_HorizontalAlignment HeaderHAlign { get; set; } = PFW_HorizontalAlignment.Left;
    public PFW_VerticalAlignment HeaderVAlien { get; set; } = PFW_VerticalAlignment.Middle;
    public PFW_HorizontalAlignment HAlign { get; set; } = PFW_HorizontalAlignment.Center;
    public PFW_VerticalAlignment VAlien { get; set; } = PFW_VerticalAlignment.Middle;
}

