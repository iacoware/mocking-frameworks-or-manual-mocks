using System.Linq;
using Moq;
using Xunit;

namespace MockingFrameworkOrManualMocks
{
    public class SuperMegaUseCaseTests
    {
        [Fact]
        public void ManyCustomers()
        {
            var customerRepo = new Mock<ICustomerRepo>();
            var display = new Mock<IDisplay>();

            customerRepo.Setup(x => x.LoadAll()).Returns(new[] {"massimo", "matteo"});

            var superMega = new SuperMegaUseCase(customerRepo.Object, display.Object);

            superMega.DoSomething();

            display.Verify(d => d.Show("massimo"), Times.Once);
            display.Verify(d => d.Show("matteo"), Times.Once);
        }
    }

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
            customerRepo.LoadAll()
                .ToList()
                .ForEach(name => display.Show(name));
        }
    }

    public interface IDisplay
    {
        void Show(string name);
    }

    public interface ICustomerRepo
    {
        string[] LoadAll();
    }
}
