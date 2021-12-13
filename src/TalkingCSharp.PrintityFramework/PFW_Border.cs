using PdfSharpCore.Drawing;
using PrintityFramework.Shared.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintityFramework
{
    public class PFW_Border: IPFW_DrawableBorder
    {
        public Color BorderColor { get; set; } = PFW_Defaults.DefaultBorderColor;
        public Color TopBorderColor { get; set; } = PFW_Defaults.DefaultBorderColor;
        public Color LeftBorderColor { get; set; } = PFW_Defaults.DefaultBorderColor;
        public Color BottomBorderColor { get; set; } = PFW_Defaults.DefaultBorderColor;
        public Color RightBorderColor { get; set; } = PFW_Defaults.DefaultBorderColor;
        public float BorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float TopBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float LeftBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float BottomBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public float RightBorderSize { get; set; } = PFW_Defaults.DefaultBorderSize;
        public PFW_Border SetBorderColor (Color color)
        {
            this.BorderColor = color;
            this.TopBorderColor = color;
            this.LeftBorderColor = color;
            this.BottomBorderColor = color;
            this.RightBorderColor = color;
            return this;
        }

        public PFW_Border SetTopBorderColor(Color color)
        {
            this.TopBorderColor = color;
            return this;
        }

        public PFW_Border SetLeftBorderColor(Color color)
        {
            this.LeftBorderColor = color;
            return this;
        }

        public PFW_Border SetBottomBorderColor(Color color)
        {
            this.BottomBorderColor = color;
            return this;
        }

        public PFW_Border SetRightBorderColor(Color color)
        {
            this.RightBorderColor = color;
            return this;
        }

        public PFW_Border SetBorderSize(float size)
        {
            this.BorderSize = size;
            this.TopBorderSize = size;
            this.LeftBorderSize = size;
            this.BottomBorderSize = size;
            this.RightBorderSize = size;
            return this;
        }

        public PFW_Border SetTopBorderSize(float size)
        {
            this.TopBorderSize = size;
            return this;
        }

        public PFW_Border SetLeftBorderSize(float size)
        {
            this.LeftBorderSize = size;
            return this;
        }

        public PFW_Border SetBottomBorderSize(float size)
        {
            this.BottomBorderSize = size;
            return this;
        }

        public PFW_Border SetRightBorderSize(float size)
        {
            this.RightBorderSize = size;
            return this;
        }

        public void Draw(XGraphics graphics,XRect bounds)
        {
            DrawTopBorder(graphics,bounds);
            DrawLeftBorder(graphics, bounds);
            DrawBottomBorder(graphics, bounds);
            DrawRightBorder(graphics, bounds);
        }

        private void DrawTopBorder(XGraphics graphics,XRect bounds)
        {
            if(TopBorderColor != Color.Transparent && TopBorderSize > 0)
            {
                graphics.DrawLine(new XPen(XColor.FromArgb(TopBorderColor.ToArgb()), TopBorderSize)
                    , new XPoint(bounds.X,bounds.Y)
                    , new XPoint(bounds.X + bounds.Width,bounds.Y));
            }
        }

        private void DrawLeftBorder(XGraphics graphics, XRect bounds)
        {
            if (LeftBorderColor != Color.Transparent && LeftBorderSize > 0)
            {
                graphics.DrawLine(new XPen(XColor.FromArgb(LeftBorderColor.ToArgb()), LeftBorderSize)
                    , new XPoint(bounds.X, bounds.Y)
                    , new XPoint(bounds.X, bounds.Y + bounds.Height));
            }
        }

        private void DrawBottomBorder(XGraphics graphics, XRect bounds)
        {
            if (BottomBorderColor != Color.Transparent && BottomBorderSize > 0)
            {
                graphics.DrawLine(new XPen(XColor.FromArgb(BottomBorderColor.ToArgb()), BottomBorderSize)
                    , new XPoint(bounds.X, bounds.Y + bounds.Height)
                    , new XPoint(bounds.X + bounds.Width, bounds.Y + bounds.Height));
            }
        }

        private void DrawRightBorder(XGraphics graphics, XRect bounds)
        {
            if (RightBorderColor != Color.Transparent && RightBorderSize > 0)
            {
                graphics.DrawLine(new XPen(XColor.FromArgb(RightBorderColor.ToArgb()), RightBorderSize)
                    , new XPoint(bounds.X + bounds.Width, bounds.Y)
                    , new XPoint(bounds.X + bounds.Width, bounds.Y + bounds.Height));
            }
        }
    }
}
