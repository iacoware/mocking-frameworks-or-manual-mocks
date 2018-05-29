using System.IO;
using System.Linq;
using Xunit;

namespace MockingFrameworkOrManualMocks
{
    public class FlatFileCustomerRepoTests
    {
        private const string FileName = "customers.txt";

        public FlatFileCustomerRepoTests()
        {
            File.Delete(FileName);
        }

        [Fact]
        public void ManyCustomers()
        {
            File.WriteAllLines(FileName, new []{"one", "two"});
            var customerRepo = new FlatFileCustomerRepo(FileName);

            var all = customerRepo.LoadAll();

            Assert.Contains("one", all);
            Assert.Contains("two", all);
        }

        [Fact]
        public void NoCustomers()
        {
            File.WriteAllLines(FileName, new string[0]);
            var customerRepo = new FlatFileCustomerRepo(FileName);

            var all = customerRepo.LoadAll();

            Assert.False(all.Any());
        }
    }

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
