using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MockingFrameworkOrManualMocks
{
    public class FlatFileCustomerRepoTests
    {
        [Fact]
        public void ManyCustomers()
        {
            File.WriteAllLines("customers.txt", new []{"one", "two"});

            var customerRepo = new FlatFileCustomerRepo("customers.txt");

            var all = customerRepo.LoadAll();

            Assert.Contains("one", all);
            Assert.Contains("two", all);
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
