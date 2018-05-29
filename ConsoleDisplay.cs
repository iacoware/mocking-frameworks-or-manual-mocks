using System;

namespace MockingFrameworkOrManualMocks
{
    public class ConsoleDisplay : IDisplay
    {
        public void Show(string name)
        {
            Console.WriteLine(name);
        }
    }
}