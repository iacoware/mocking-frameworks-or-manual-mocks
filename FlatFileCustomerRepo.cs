using System.IO;

namespace MockingFrameworkOrManualMocks
{
    public class FlatFileCustomerRepo : ICustomerRepo
    {
        private readonly string fileName;

        public FlatFileCustomerRepo(string fileName)
        {
            this.fileName = fileName;
        }

        public string[] LoadAll()
        {
            return File.ReadAllLines(fileName);
        }
    }
}