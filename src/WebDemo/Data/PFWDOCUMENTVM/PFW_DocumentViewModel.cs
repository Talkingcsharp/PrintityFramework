using PrintityFramework;
using PrintityFramework.Shared;
using System.Drawing;

namespace WebDemo.Data.PFWDOCUMENTVM
{
    public class PFW_DocumentViewModel
    {
        public PFW_PaperSizesEnum PaperSize { get; set; } = PFW_PaperSizesEnum.A4;
        private Size _Size
        {
            get
            {
                if (PaperSize == PFW_PaperSizesEnum.A4)
                {
                    return new Size
                    {
                        Height = 297,
                        Width = 210
                    };
                }
                if (PaperSize == PFW_PaperSizesEnum.A5)
                {
                    return new Size
                    {
                        Height = 210,
                        Width = 184
                    };
                }

                throw new NotSupportedException("Selected paper size is not supported");
            }
            set { }
        }
        public List<PFW_TableViewModel> Tables { get; set; } = new List<PFW_TableViewModel>();
        public List<PFW_PlaceLabelViewModel> Labels { get; set; } = new List<PFW_PlaceLabelViewModel>();
        public List<PFW_PlaceHeaderValueViewModel> PlaceHeaderValues { get; set; } = new List<PFW_PlaceHeaderValueViewModel>();

        public PFW_Document ToDocument()
        {
            var output = new PFW_Document();
            output.PaperSize = PaperSize;
            foreach (var item in Tables)
            {
                var table = new PFW_Table<dynamic>()
                    .SetAlternateBackgroundColor(item.AlternateBackgroundColor.Export())
                    .SetBackgroundColor(item.BackgroundColor.Export())
                    .SetBounds(item.Bounds, item.BoundsUnit)
                    .SetData(item.Data.Cast<dynamic>().ToList())
                    .SetHeaderBackgroundColor(item.HeaderBackgroundColor.Export())
                    .SetRowHeaderHeight(item.RowHeaderHeight)
                    .SetRowHeight(item.RowHeight);

                foreach (var column in item.Columns)
                {
                    table.AddColumn(new PFW_TableColumn()
                        .SetAlternateBackgroundColor(column.AlternateBackgroundColor.Export())
                        .SetAlternatingFont(column.AlternatingFont.Export())
                        .SetBackgroundColor(column.BackgroundColor.Export())
                        .SetBorder(column.Border.Export())
                        .SetFont(column.Font.Export())
                        .SetHAlign(column.HAlign)
                        .SetHeaderBackgroundColor(column.HeaderBackgroundColor.Export())
                        .SetHeaderBorder(column.HeaderBorder.Export())
                        .SetHeaderFont(column.HeaderFont.Export())
                        .SetHeaderHAlign(column.HeaderHAlign)
                        .SetHeaderText(column.HeaderText)
                        .SetHeaderVAlign(column.HeaderVAlien)
                        .SetPropertyName(column.PropertyName)
                        .SetVAlign(column.VAlien)
                        .SetWidth(column.Width, column.WidthUnit));
                }
                output.AddTable(table);
            }
            foreach (var item in Labels)
            {
                output.Labels.Add(new PFW_PlaceLabel()
                    .SetBounds(item.Bounds, item.BoundsUnit)
                    .SetBackgroundColor(item.BackgroundColor.Export())
                    .SetBorder(item.Border.Export())
                    .SetFont(item.Font.Export())
                    .SetHAlign(item.HAlign)
                    .SetText(item.Text));
            }
            foreach (var item in PlaceHeaderValues)
            {
                output.PlaceHeaderValues.Add(new PFW_PlaceHeaderValue()
                    .SetBackgroundColor(item.BackGroundColor.Export())
                    .SetBorder(item.Border.Export())
                    .SetBounds(item.Bounds, item.BoundsUnit)
                    .SetFont(item.Font.Export())
                    .SetHAlign(item.HAlign)
                    .SetHeader(item.Header)
                    .SetHeaderBackgroundColor(item.HeaderBackgroundColor.Export())
                    .SetHeaderBorder(item.HeaderBorder.Export())
                    .SetHeaderBounds(item.HeaderBounds, item.HeaderBoundsUnit)
                    .SetHeaderFont(item.HeaderFont.Export())
                    .SetHeaderHAlign(item.HeaderHAlign)
                    .SetHeaderVAlign(item.HeaderVAlien)
                    .SetText(item.Text)
                    .SetVAlign(item.VAlien));
            }
            return output;
        }

    }
}
