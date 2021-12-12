using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;

namespace PrintityFramework;

public class PFW_Table<DataType> : IPFW_BoundsObject, IPFW_DrawableTable
{
    public ICollection<PFW_TableColumn> Columns { get; set; } = new List<PFW_TableColumn>();
    public float RowHeaderHeight { get; set; } = 50;
    public float RowHeight { get; set; } = 40;
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; }
    public List<object>? Data { get; set; }
        internal int CurrentRowIndex { get; private set; }
    public bool HasNewPages { get; private set; } = false;
    public PFW_Table<DataType> AddColumn(PFW_TableColumn column)
    {
        this.Columns.Add(column);
        return this;
    }
    public PFW_Table<DataType> SetRowHeaderHeight(float height)
    {
        this.RowHeaderHeight = height;
        return this;
    }

    public PFW_Table<DataType> SetRowHeight(float height)
    {
        this.RowHeight = height;
        return this;
    }

    public PFW_Table<DataType> SetBounds(RectangleF bounds, PFW_MeasurementsEnum unit)
    {
        this.Bounds = bounds;
        this.BoundsUnit = unit;
        return this;
    }

    public PFW_Table<DataType> SetData(List<DataType> data)
    {
        this.Data = data.Cast<object>().ToList();
        return this;
    }

    public void Draw(XGraphics graphic, PdfPage page)
    {
        XRect bounds = PFW_MeasurementesHelper.GetBounds(this, page);
        XPoint currentLocation = new XPoint(bounds.X, bounds.Y);
        var rowHeight = XUnit.FromMillimeter(RowHeight).Point;
        var rowHeaderHeight = XUnit.FromMillimeter(RowHeaderHeight).Point;
        bool isAlternate = false;
        foreach (var item in Columns)
        {
            var columnBounds = PFW_MeasurementesHelper.GetTableHeaderColumnBounds(currentLocation, page, this, item);
            item.DrawHeader(graphic, columnBounds);
            currentLocation.X += columnBounds.Width;
        }

        currentLocation.X = bounds.X;
        currentLocation.Y += rowHeaderHeight;

        while (currentLocation.Y + RowHeight < bounds.Y + bounds.Height && Data is not null && CurrentRowIndex < Data.Count)
        {
            foreach (var item in Columns)
            {
                var columnBounds = PFW_MeasurementesHelper.GetTableColumnBounds(currentLocation, page, this, item);
                item.Draw(graphic, columnBounds, Data[CurrentRowIndex].GetStringValue(item), isAlternate);
                currentLocation.X += columnBounds.Width;
            }
            currentLocation.X = bounds.X;
            currentLocation.Y += rowHeight;
            CurrentRowIndex++;
            isAlternate = !isAlternate;
        }
        HasNewPages = CurrentRowIndex < Data?.Count;
    }
}

public static class PFW_TableExtensions
{
    public static string GetStringValue(this object source, PFW_TableColumn column)
    {
        var propInfo = source.GetType().GetProperties().Where(p => p.Name == column.PropertyName).FirstOrDefault();
        if (propInfo is null)
        {
            return "";
        }
        var value = propInfo.GetValue(source);
        return value?.ToString() ?? "";
    }
}

