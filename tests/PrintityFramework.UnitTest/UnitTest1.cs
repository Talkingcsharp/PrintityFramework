using PrintityFramework.Shared;
using System.Drawing;
using System.IO;
using Xunit;

namespace PrintityFramework.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var doc = new PFW_Document()
                .AddLabel(new PFW_PlaceLabel()
                .SetHAlign(PFW_HorizontalAlignment.Center)
                .SetVAlign(PFW_VerticalAlignment.Middle)
                .SetText("Test")
                .SetFont(new PFW_Font()
                    .SetSize(20)
                    .SetFontName("Arial"))
                .SetBounds(new RectangleF
                {
                    X = 50,
                    Y = 300,
                    Height = 500,
                    Width = 500
                }, PFW_MeasurementsEnum.Dot))
                .AddLabel(new PFW_PlaceLabel()
                .SetHAlign(PFW_HorizontalAlignment.Left)
                .SetVAlign(PFW_VerticalAlignment.Top)
                .SetText("Left top")
                .SetFont(new PFW_Font()
                    .SetSize(20)
                    .SetFontName("Arial"))
                .SetBounds(new RectangleF
                {
                    X = 50,
                    Y = 900,
                    Height = 500,
                    Width = 500
                }, PFW_MeasurementsEnum.Dot))
                .AddLabel(new PFW_PlaceLabel()
                .SetHAlign(PFW_HorizontalAlignment.Right)
                .SetVAlign(PFW_VerticalAlignment.Bottom)
                .SetText("Right bottom")
                .SetFont(new PFW_Font()
                    .SetSize(20)
                    .SetFontName("Arial"))
                .SetBounds(new RectangleF
                {
                    X = 50,
                    Y = 1500,
                    Height = 500,
                    Width = 500
                }, PFW_MeasurementsEnum.Dot))
                ;

            doc.CreateDocument("myfile.pdf");
            Assert.True(File.Exists("myfile.pdf"));
        }
    }
}