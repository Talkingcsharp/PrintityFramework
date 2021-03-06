using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Collections;
using System.Drawing;
using System.Text.Json;

namespace PrintityFramework;

public class PFW_Table<DataType> : IPFW_BoundsObject, IPFW_DrawableTable where DataType : class
{
    public ICollection<PFW_TableColumn> Columns { get; set; } = new List<PFW_TableColumn>();
    public float RowHeaderHeight { get; set; } = PFW_Defaults.DefaultTableRowHeaderHeight;
    public float RowHeight { get; set; } = PFW_Defaults.DefaultTableRowHeight;
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; }
    public Color BackgroundColor { get; set; } = PFW_Defaults.DefaultBackgroundColor;
    public Color HeaderBackgroundColor { get; set; } = PFW_Defaults.DefaultHeraderBackgroundColor;
    public Color AlternateBackgroundColor { get; set; } = PFW_Defaults.DefaultAlternatingBackgroundColor;
    public IList? Data { get; set; }
    internal int CurrentRowIndex { get; private set; }
    public bool HasNewPages { get; private set; } = false;

    public PFW_Table<DataType> SetBackgroundColor(Color color)
    {
        this.BackgroundColor = color;
        return this;
    }

    public PFW_Table<DataType> SetAlternateBackgroundColor(Color color)
    {
        this.AlternateBackgroundColor = color;
        return this;
    }

    public PFW_Table<DataType> SetHeaderBackgroundColor(Color color)
    {
        this.HeaderBackgroundColor = color;
        return this;
    }
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
            SetColumnColors(item);
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
                item.Draw(graphic, columnBounds, Data?[CurrentRowIndex]?.GetStringValue(item)?? "", isAlternate);
                currentLocation.X += columnBounds.Width;
            }
            currentLocation.X = bounds.X;
            currentLocation.Y += rowHeight;
            CurrentRowIndex++;
            isAlternate = !isAlternate;
        }
        HasNewPages = CurrentRowIndex < Data?.Count;
    }

    private void SetColumnColors(PFW_TableColumn input)
    {
        if (input.BackgroundColor == PFW_Defaults.DefaultBackgroundColor)
        {
            input.SetBackgroundColor(this.BackgroundColor);
        }
        if (input.HeaderBackgroundColor == PFW_Defaults.DefaultHeraderBackgroundColor)
        {
            input.SetHeaderBackgroundColor(this.HeaderBackgroundColor);
        }
        if (input.AlternateBackgroundColor == PFW_Defaults.DefaultAlternatingBackgroundColor)
        {
            input.SetAlternateBackgroundColor(AlternateBackgroundColor);
        }
    }
}

public static class PFW_TableExtensions
{
    public static string GetStringValue(this object source, PFW_TableColumn column)
    {
        if(source is JsonElement)
        {
            JsonElement element = (JsonElement)source;
            JsonElement property;
            if (element.TryGetProperty(column.PropertyName, out property))
            {
                if (property.ValueKind == JsonValueKind.Number)
                {
                    return property.GetDouble().ToString();
                }
                else if (property.ValueKind == JsonValueKind.String)
                {
                    return property.GetString() ?? "";
                }
                else
                {
                    return property.GetRawText();
                }
                
                
            }
        }
        var propInfo = source.GetType().GetProperties().Where(p => p.Name == column.PropertyName).FirstOrDefault();
        if (propInfo is null)
        {
            return "";
        }
        var value = propInfo.GetValue(source);
        return value?.ToString() ?? "";
    }
}

