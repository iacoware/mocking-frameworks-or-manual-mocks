using System;
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
            var customerRepo = CreateWith("one", "two");

            var all = customerRepo.LoadAll();

            Assert.Contains("one", all);
            Assert.Contains("two", all);
        }

        [Fact]
        public void NoCustomers()
        {
            var customerRepo = CreateEmpty();

            Assert.Throws<InvalidOperationException>(() => customerRepo.LoadAll());
        }

        private ICustomerRepo CreateWith(params string[] customers)
        {
            File.WriteAllLines(FileName, customers);
            return new FlatFileCustomerRepo(FileName);
        }

        private ICustomerRepo CreateEmpty()
        {
            File.WriteAllLines(FileName, new string[0]);
            return new FlatFileCustomerRepo(FileName);
        }
    }
}
