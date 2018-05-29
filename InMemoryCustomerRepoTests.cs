using System;
using System.Linq;

namespace MockingFrameworkOrManualMocks
{
    public class InMemoryCustomerRepoTests : CustomerRepoContractTests
    {
        protected override ICustomerRepo CreateWith(params string[] customers)
        {
            return new InMemoryCustomerRepo(customers);
        }

        protected override ICustomerRepo CreateEmpty()
        {
            return new InMemoryCustomerRepo();
        }
    }

    public class InMemoryCustomerRepo : ICustomerRepo
    {
        private readonly string[] customers;

        public InMemoryCustomerRepo(params string[] customers)
        {
            this.customers = customers;
        }

        public string[] LoadAll()
        {
            if (customers.Length == 0) throw new InvalidOperationException();

            return customers.ToArray();
        }
    }
}