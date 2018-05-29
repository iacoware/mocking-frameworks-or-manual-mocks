using System;
using System.Linq;

namespace MockingFrameworkOrManualMocks
{
    public class SuperMegaUseCase
    {
        private readonly ICustomerRepo customerRepo;
        private readonly IDisplay display;

        public SuperMegaUseCase(ICustomerRepo customerRepo, IDisplay display)
        {
            this.customerRepo = customerRepo;
            this.display = display;
        }

        public void DoSomething()
        {
            try
            {
                customerRepo.LoadAll()
                    .ToList()
                    .ForEach(name => display.Show(name));

            }
            catch (InvalidOperationException )
            {
                //Do something useful
            }
        }
    }
}