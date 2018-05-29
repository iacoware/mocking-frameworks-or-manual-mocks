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

        [Fact]
        public void NoCustomer()
        {
            var customerRepo = new Mock<ICustomerRepo>();
            var display = new Mock<IDisplay>();

            customerRepo.Setup(x => x.LoadAll()).Returns(new string[0]);
            var superMega = new SuperMegaUseCase(customerRepo.Object, display.Object);

            superMega.DoSomething();

            display.Verify(d => d.Show(It.IsAny<string>()), Times.Never);
        }
    }
}
