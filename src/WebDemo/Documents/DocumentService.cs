using PrintityFramework;
using PrintityFramework.Shared;
using PrintityFramework.Shared.Core;
using System.Drawing;
using WebDemo.Data;

namespace WebDemo.Documents
{
    public class DocumentService
    {
        public byte[] CreateSampleDocument(List<SamplePrintityTableModel> tableData)
        {
            var document = new PFW_Document();
            document
                .AddLabel(new PFW_PlaceLabel()
                    .SetBorder(new PFW_Border()
                        .SetBorderSize(0)
                        .SetBottomBorderColor(Color.Black)
                        .SetBottomBorderSize(1))
                    .SetFont(new PFW_Font()
                        .SetUderline(true)
                        .SetFontName(PFW_Defaults.DefaultHeaderFontFamilyName)
                        .SetSize(PFW_Defaults.DefaultHeaderFontSize))
                    .SetBounds(new RectangleF(10,10,80,5), PFW_MeasurementsEnum.Percent)
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
                        .SetWidth(30, PFW_MeasurementsEnum.Percent))
                    .AddColumn(new PFW_TableColumn()
                        .SetHeaderText("Nullable")
                        .SetPropertyName(nameof(SamplePrintityTableModel.Nullable))
                        .SetWidth(20, PFW_MeasurementsEnum.Percent))
                    .SetBounds(new RectangleF(10,20,80,75), PFW_MeasurementsEnum.Percent)
                    .SetData(tableData));

            var stream = document.CreateDocument();
            if(stream is null)
            {
                throw new Exception("Cannot create document");
            }
            return stream;
        }
    }
}
