namespace WebDemo.Data
{
    public class SamplePrintityTableModelService
    {
        public static List<SamplePrintityTableModel> PrepareRandomList(int recordsCount = 100)
        {
            List<SamplePrintityTableModel> output = new List<SamplePrintityTableModel>();
            Random rand = new Random();
            for(int i =1;i<= recordsCount; i++)
            {
                output.Add(new SamplePrintityTableModel
                {
                    Date = DateTime.Now.AddDays(rand.Next(1000, 10000) * -1),
                    Id = i,
                    IsTrue = i % 2 == 0,
                    Name = Guid.NewGuid().ToString(),
                    Nullable = (i % 3 == 0) ? rand.Next(5, 50000) : null
                });
            }
            return output;
        }
    }
}
