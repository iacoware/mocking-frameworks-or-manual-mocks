using System.IO;
using System.Linq;

namespace MockingFrameworkOrManualMocks
{
    public class FlatFileCustomerRepoTests : CustomerRepoContractTests
    {
        private const string FileName = "customers.txt";

        public FlatFileCustomerRepoTests()
        {
            File.Delete(FileName);
        }

        protected override ICustomerRepo CreateWith(params string[] customers)
        {
            File.WriteAllLines(FileName, customers);
            return new FlatFileCustomerRepo(FileName);
        }

        protected override ICustomerRepo CreateEmpty()
        {
            File.WriteAllLines(FileName, new string[0]);
            return new FlatFileCustomerRepo(FileName);
        }
    }
}
