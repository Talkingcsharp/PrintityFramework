using PrintityFramework;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;
using WebDemo.Data;

namespace WebDemo.Documents
{
    public class DocumentService
    {
        public Stream CreateSampleDocument(List<SamplePrintityTableModel> tableData)
        {
            var document = new PFW_Document();
            document
                .AddLabel(new PFW_PlaceLabel()
                    .SetBorder(new PFW_Border()
                        .SetBorderSize(0)
                        .SetBottomBorderColor(Color.Black)
                        .SetBottomBorderSize(1))
                    .SetFont(PFW_Defaults.DefaultHeaderFont)
                    .SetBounds(new System.Drawing.RectangleF(10,10,80,5), PFW_MeasurementsEnum.Percent)
                    .SetHAlign(PFW_HorizontalAlignment.Center)
                    .SetText("Printity framework page header"))
                .AddTable(new PFW_Table<SamplePrintityTableModel>()
                    .AddColumn(new PFW_TableColumn()
                        .SetHeaderText("Id")
                        .SetPropertyName(nameof(SamplePrintityTableModel.Id))
                        .SetWidth(10, PFW_MeasurementsEnum.Percent))
                    .AddColumn(new PFW_TableColumn()
                        .SetHeaderText("Name")
                        .SetPropertyName(nameof(SamplePrintityTableModel.Name))
                        .SetWidth(40, PFW_MeasurementsEnum.Percent))
                    .AddColumn(new PFW_TableColumn()
                        .SetHeaderText("Date")
                        .SetPropertyName(nameof(SamplePrintityTableModel.Date))
                        .SetWidth(40, PFW_MeasurementsEnum.Percent))
                    .AddColumn(new PFW_TableColumn()
                        .SetHeaderText("Nullable")
                        .SetPropertyName(nameof(SamplePrintityTableModel.Nullable))
                        .SetWidth(10, PFW_MeasurementsEnum.Percent))
                    .SetBounds(new RectangleF(10,20,80,75), PFW_MeasurementsEnum.Percent)
                    .SetData(tableData));

            return document.CreateDocument();
        }
    }
}
