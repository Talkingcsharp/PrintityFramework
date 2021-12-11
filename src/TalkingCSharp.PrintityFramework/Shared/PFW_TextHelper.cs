using PdfSharpCore.Drawing;
using PdfSharpCore.Drawing.Layout;
using SixLabors.Fonts;
using static System.Net.Mime.MediaTypeNames;

namespace PrintityFramework.Shared;
public class PFW_TextHelper
{
    public static void DrawText(XGraphics graphics, string text, PFW_Font font, XRect bounds, bool wrap = true, PFW_HorizontalAlignment hAlign = PFW_HorizontalAlignment.Center)
    {
        PFW_TextFormatter formatter = new PFW_TextFormatter(graphics, text, font, bounds, hAlign);
        formatter.Draw();
    }

    private class PFW_TextFormatter
    {
        public string Text { get; set; }
        public XGraphics Graphics { get; set; }
        public XRect Bounds { get; set; }
        public PFW_Font Font { get; set; }
        public PFW_HorizontalAlignment HAlign { get; set; }

        class TextBlock
        {
            public string Text { get; set; } = "";
            public int StartINdex { get; set; }
            public int Length { get; set; }
        }

        List<TextBlock> Blocks = new List<TextBlock>();

        public PFW_TextFormatter(XGraphics graphics, string text, PFW_Font font, XRect bounds, PFW_HorizontalAlignment hAlign)
        {
            Text = text;
            Graphics = graphics;
            Bounds = bounds with { Height = bounds.Height - 4, Width = bounds.Width - 4, X = bounds.X + 2, Y = bounds.Y + 2 };
            Font = font;
            HAlign = hAlign;
        }

        public void Draw()
        {
            float lineHeight = (float)Graphics.MeasureString(Text, Font.GetXFont()).Height;
            float lineSpacing = 2;
            lineHeight = lineHeight + lineSpacing;
            int lineCount = (int)Math.Floor(Bounds.Height / lineHeight);
            CreateBlocks(lineCount);
            float currentY = (float)Bounds.Y + lineSpacing;
            for (int i = 0; i < lineCount; i++)
            {
                if(i == Blocks.Count)
                {
                    break;
                }
                //PFW_MeasurementesHelper.GetStringFormat(HAlign, PFW_VerticalAlignment.Top);
                Graphics.DrawString(Blocks[i].Text, Font.GetXFont(), Font.GetXBrush(), new XRect(Bounds.X, currentY, Bounds.Width, Bounds.Height), PFW_MeasurementesHelper.GetStringFormat(HAlign, PFW_VerticalAlignment.Top));
                currentY += lineHeight;
            }
        }

        private void CreateBlocks(int lineCount)
        {
            Blocks.Clear();
            int startIndex = 0;
            while (startIndex < Text.Length && Blocks.Count < lineCount)
            {
                TextBlock block = GetNextBlock(startIndex);
                Blocks.Add(block);
                startIndex = block.StartINdex + block.Length;
            }

            var lastBlock = Blocks.LastOrDefault();
            if (lastBlock is null)
            {
                return;
            }
            if (lastBlock.StartINdex + lastBlock.Length < Text.Length)
            {
                lastBlock.Text = lastBlock.Text.Substring(0, lastBlock.Text.Length - 4) + " ...";
            }

        }

        private TextBlock GetNextBlock(int startIndex)
        {
            TextBlock output = new TextBlock();
            for (int i = startIndex; i < Text.Length; i++)
            {
                string currentText = Text.Substring(startIndex, i - startIndex + 1);
                if (Graphics.MeasureString(currentText, Font.GetXFont()).Width > Bounds.Width)
                {
                    currentText = currentText.Substring(0, currentText.Length - 1);
                    if(!currentText.EndsWith(" "))
                    {
                        if(currentText.LastIndexOf(" ") > currentText.Length - 4)
                        {
                            currentText = currentText.Substring(0, currentText.LastIndexOf(" ") + 1);
                        }
                        else
                        {
                            currentText = currentText + "-";
                        }
                    }
                    output.Text = currentText;
                    output.StartINdex = startIndex;
                    output.Length = currentText.Length - 1;
                    return output;
                }
            }
            output.Text = Text.Substring(startIndex);
            output.StartINdex = startIndex;
            output.Length = output.Text.Length;
            return output;
        }
    }
}
