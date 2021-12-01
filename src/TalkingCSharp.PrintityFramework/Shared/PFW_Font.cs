﻿using PdfSharpCore.Drawing;
using System.Drawing;

namespace PrintityFramework.Shared;

public class PFW_Font
{
    public string FontName { get; set; } = "Arial";
    public bool Bold { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    public int Size { get; set; }
    public Color Color { get; set; } = Color.FromArgb(0, 0, 0);
    public PFW_Font SetFontName(string fontName)
    {
        this.FontName = FontName;
        return this;
    }

    public PFW_Font SetBold(bool bold)
    {
        this.Bold = bold;
        return this;
    }

    public PFW_Font SetItalic(bool italic)
    {
        this.Italic = italic;
        return this;
    }

    public PFW_Font SetUderline(bool underLine)
    {
        this.Underline = underLine;
        return this;
    }

    public PFW_Font SetSize(int size)
    {
        this.Size = size;
        return this;
    }

    public PFW_Font SetColor(Color color)
    {
        this.Color = color;
        return this;
    }

    public XFont GetXFont()
    {
        XFontStyle style;
        if (Bold && Italic)
        {
            style = XFontStyle.BoldItalic;
        }
        else if (Bold)
        {
            style = XFontStyle.Bold;
        } 
        else if (Italic)
        {
            style = XFontStyle.Italic;
        }
        else
        {
            style = XFontStyle.Regular;
        }
        var output = new XFont(FontName, Size,style);
        return output;
    }
    public XBrush GetXBrush()
    {
        XBrush output = new XSolidBrush(XColor.FromArgb(Color.ToArgb()));
        return output;
    }

    public XPen GetXPen()
    {
        return new XPen(XColor.FromArgb(Color.ToArgb()));
    }

    public XSize MeasureStringSize(string text, XGraphics graphics)
    {
        return graphics.MeasureString(text, GetXFont());
    }
}

