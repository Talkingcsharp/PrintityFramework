using System.Drawing;

namespace PrintityFramework.Shared;

public class PFW_Table
{
    public ICollection<PFW_Column> Columns { get; set; } = new List<PFW_Column>();
    public float RowHeaderHeight { get; set; } = 50;
    public PFW_MeasurementsEnum RowHeaderHeightUnit { get; set; } = PFW_MeasurementsEnum.Px;
    public float RowHeight { get; set; } = 40;
    public PFW_MeasurementsEnum RowHeightUnit { get; set; } = PFW_MeasurementsEnum.Px;
    public SizeF Size { get; set; }
    public PFW_MeasurementsEnum SizeUnit { get; set; } = PFW_MeasurementsEnum.Px;
    public ICollection<object> Data { get; set; } = new List<object>();
    public float StartX { get; set; } = 5;
    public PFW_MeasurementsEnum StartXUnit { get; set; } = PFW_MeasurementsEnum.Percent;
    public float StartY { get; set; } = 200;
    public PFW_MeasurementsEnum StartYUnit { get; set; } = PFW_MeasurementsEnum.Px;
    public PFW_Table AddColumn(PFW_Column column)
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

    public PFW_Table SetSize(SizeF size, PFW_MeasurementsEnum unit)
    {
        this.Size = size;
        this.SizeUnit = unit;
        return this;
    }

    public PFW_Table SetData(ICollection<object> data)
    {
        this.Data = data;
        return this;
    }

    public PFW_Table SetStartX(float x, PFW_MeasurementsEnum unit)
    {
        this.StartX = x;
        this.StartYUnit = unit;
        return this;
    }

    public PFW_Table SetStartY(float y, PFW_MeasurementsEnum unit)
    {
        this.StartY = y;
        this.StartYUnit = unit;
        return this;
    }
}

