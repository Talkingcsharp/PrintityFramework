using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System.Drawing;
namespace PrintityFramework.Shared;

public class PFW_PlaceLabel
{
    public RectangleF Bounds { get; set; }
    public PFW_MeasurementsEnum BoundsUnit { get; set; } = PFW_MeasurementsEnum.Dot;
    public string? Text { get; set; }
    public PFW_Font? Font { get; set; }
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

    public void Draw(XGraphics graphic,PdfPage page)
    {
        XRect bounds = new XRect
        {
            X = PFW_Helper.LocationHelperX(Bounds.X, BoundsUnit, page),
            Y = PFW_Helper.LocationHelperY(Bounds.Y, BoundsUnit, page),
            Height = PFW_Helper.SizeHelper(Bounds.Size, BoundsUnit, page).Height,
            Width = PFW_Helper.SizeHelper(Bounds.Size, BoundsUnit, page).Width
        };

        graphic.DrawRectangle(XPens.Black, bounds);

        var measure = graphic.MeasureString(Text, new XFont(Font?.FontName, Font?.Size ?? 0, XFontStyle.Regular));
        XPoint textLocation = new XPoint();
        if(HAlign == PFW_HorizontalAlignment.Left)
        {
            textLocation.X = bounds.X;
        }
        if(HAlign == PFW_HorizontalAlignment.Center)
        {
            textLocation.X = bounds.X + ((bounds.Width - measure.Width) / 2);
        }
        if(HAlign == PFW_HorizontalAlignment.Right)
        {
            textLocation.X = bounds.X + bounds.Width - measure.Width;
        }

        if(VAlien == PFW_VerticalAlignment.Top)
        {
            textLocation.Y = bounds.Y + measure.Height;
        }

        if(VAlien == PFW_VerticalAlignment.Middle)
        {
            textLocation.Y = bounds.Y + (bounds.Height / 2) + (measure.Height / 2);
        }
        if(VAlien == PFW_VerticalAlignment.Bottom)
        {
            textLocation.Y = bounds.Y + bounds.Height;
        }
        graphic.DrawString(Text,
            new XFont(Font?.FontName, Font?.Size ?? 0, XFontStyle.Regular),
            XBrushes.Black,
            textLocation);
    }
}

