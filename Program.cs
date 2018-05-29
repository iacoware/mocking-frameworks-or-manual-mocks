using System;
using System.IO;

namespace MockingFrameworkOrManualMocks
{
    class Program
    {
        static void Main(string[] args)
        {
            //File.WriteAllLines("customers.txt", new []{"massimo", "matteo"});
            File.WriteAllLines("customers.txt", new string[0]);

            var superMega = new SuperMegaUseCase(new FlatFileCustomerRepo("customers.txt"), new ConsoleDisplay());
            superMega.DoSomething();

            Console.WriteLine("\n\n\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
