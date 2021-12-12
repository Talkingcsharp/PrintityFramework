using PrintityFramework.Shared;
using System;
using System.Collections.Generic;
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
                .AddTable(new PFW_Table<Student>()
                    .SetBounds(new RectangleF(10, 2, 80, 75), PFW_MeasurementsEnum.Percent)
                    .SetData(PrepareList())
                    .SetRowHeaderHeight(14)
                    .SetRowHeight(15)
                    .AddColumn(new PFW_TableColumn()
                        .SetHAlign(PFW_HorizontalAlignment.Center)
                        .SetHeaderHAlign(PFW_HorizontalAlignment.Center)
                        .SetHeaderText("Id")
                        .SetPropertyName(nameof(Student.Id))
                        .SetWidth(10, PFW_MeasurementsEnum.Percent))
                    .AddColumn(new PFW_TableColumn()
                        .SetHAlign(PFW_HorizontalAlignment.Left)
                        .SetHeaderHAlign(PFW_HorizontalAlignment.Right)
                        .SetHeaderText("Name")
                        .SetPropertyName(nameof(Student.Name))
                        .SetWidth(40, PFW_MeasurementsEnum.Percent))
                    .AddColumn(new PFW_TableColumn()
                        .SetHAlign(PFW_HorizontalAlignment.Right)
                        .SetHeaderHAlign(PFW_HorizontalAlignment.Left)
                        .SetHeaderText("DOB")
                        .SetPropertyName(nameof(Student.DOB))
                        .SetWidth(40, PFW_MeasurementsEnum.Percent))
                    .AddColumn(new PFW_TableColumn()
                        .SetHAlign(PFW_HorizontalAlignment.Center)
                        .SetHeaderHAlign(PFW_HorizontalAlignment.Left)
                        .SetHeaderText("Male?")
                        .SetPropertyName(nameof(Student.IsMale))
                        .SetWidth(10, PFW_MeasurementsEnum.Percent)))
                .AddLabel(new PFW_PlaceLabel()
                    .SetBounds(new RectangleF(10, 85, 50, 10), PFW_MeasurementsEnum.Percent)
                    .SetFont(new PFW_Font()
                        .SetSize(8)
                        .SetColor(Color.Green))
                    .SetText("Quick Brown Foxes gives brands a voice. We provide strategic frameworks, creative power and expert guidance in communication. We work at the crossroads between what brands offer and what people need.")
                    .SetHAlign(PFW_HorizontalAlignment.Left)
                    );
            doc.CreateDocument("myfile.pdf");
            Assert.True(File.Exists("myfile.pdf"));
        }

        List<Student> PrepareList()
        {
            List<Student> output = new List<Student>();
            for (int i = 0; i < 20; i++)
            {
                output.Add(new Student
                {
                    Id = i * 2,
                    DOB = (i % 3 == 0) ? null : DateTime.Now.AddYears(i * -1),
                    Height = new Random().NextInt64(),
                    IsMale = i % 2 == 0,
                    Name = Guid.NewGuid().ToString().Replace("-", " ")
                });
            }
            return output;
        }

        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public DateTime? DOB { get; set; }
            public long Height { get; set; }
            public bool IsMale { get; set; }
        }
    }
}