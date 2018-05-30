using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MockingFrameworkOrManualMocks
{
    public class ConsoleDisplayTests : IDisposable
    {
        private TextWriter oldOut;
        private StringWriter newOut;

        public ConsoleDisplayTests()
        {
            newOut = new StringWriter();
            oldOut = Console.Out;
            Console.SetOut(newOut);
        }

        public void Dispose()
        {
            Console.SetOut(oldOut);
            newOut.Dispose();
        }

        [Fact]
        public void ManyNames()
        {
            var display = new ConsoleDisplay();

            display.Show("first");
            display.Show("second");

            var output = newOut.ToString();
            Assert.Contains("first", output);
            Assert.Contains("second", output);
        }
    }
}
