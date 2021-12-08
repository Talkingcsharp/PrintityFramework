using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace PrintityFramework.Shared;

public class PFW_Table : IPFW_DrawableObject
{
    public ICollection<PFW_TableColumn> Columns { get; set; } = new List<PFW_TableColumn>();
    public float RowHeaderHeight { get; set; } = 50;
    public PFW_MeasurementsEnum RowHeaderHeightUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public float RowHeight { get; set; } = 40;
    public PFW_MeasurementsEnum RowHeightUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; }
    public ICollection<object>? Data { get; set; }
    public PFW_Table AddColumn(PFW_TableColumn column)
    {
        this.Columns.Add(column);
        return this;
    }
    public PFW_Table SetRowHeaderHeight(float height, PFW_MeasurementsEnum unit)
    {
        this.RowHeaderHeight = height;
        this.RowHeaderHeightUnit = unit;
        return this;
    }

    public PFW_Table SetRowHeight(float height, PFW_MeasurementsEnum unit)
    {
        this.RowHeight = height;
        this.RowHeightUnit = unit;
        return this;
    }

    public PFW_Table SetBounds(RectangleF bounds, PFW_MeasurementsEnum unit)
    {
        this.Bounds = bounds;
        this.BoundsUnit = unit;
        return this;
    }

    public PFW_Table SetData(ICollection<object> data)
    {
        this.Data = data;
        return this;
    }

   

    public void Draw(XGraphics graphic, PdfPage page)
    {
        
    }
}

