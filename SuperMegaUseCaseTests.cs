using System;
using Moq;
using Xunit;

namespace MockingFrameworkOrManualMocks
{
    public class SuperMegaUseCaseTests
    {
        [Fact]
        public void ManyCustomersBetter()
        {
            var customerRepo = new InMemoryCustomerRepo("massimo", "matteo");
            var display = new DisplaySpy();
            var superMega = new SuperMegaUseCase(customerRepo, display);

            superMega.DoSomething();

            Assert.Contains("massimo", display.Output);
            Assert.Contains("matteo", display.Output);
        }

        [Fact]
        public void NoCustomerBetter()
        {
            var customerRepo = new InMemoryCustomerRepo();
            var display = new DisplaySpy();
            var superMega = new SuperMegaUseCase(customerRepo, display);

            superMega.DoSomething();

            Assert.Equal("", display.Output);
        }
        
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

    public class DisplaySpy : IDisplay
    {
        private string output = "";

        public void Show(string name)
        {
            output += name + Environment.NewLine;
        }

        public string Output => output;
    }
}
