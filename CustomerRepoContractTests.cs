using System;
using Xunit;

namespace MockingFrameworkOrManualMocks
{
    public abstract class CustomerRepoContractTests
    {
        protected abstract ICustomerRepo CreateWith(params string[] customers);
        protected abstract ICustomerRepo CreateEmpty();

        [Fact]
        public void ManyCustomers()
        {
            var customerRepo = CreateWith("one", "two");

            var all = customerRepo.LoadAll();

            Assert.Contains<string>("one", all);
            Assert.Contains<string>("two", all);
        }

        [Fact]
        public void NoCustomers()
        {
            var customerRepo = CreateEmpty();

            Assert.Throws<InvalidOperationException>(() => customerRepo.LoadAll());
        }
    }
}