using System;
using System.IO;
using System.Linq;

namespace MockingFrameworkOrManualMocks
{
    public class FlatFileCustomerRepo : ICustomerRepo
    {
        private readonly string fileName;

        public FlatFileCustomerRepo(string fileName)
        {
            this.fileName = fileName;
        }

        public string[] LoadAll()
        {
            var all = File.ReadAllLines(fileName);
            if (!all.Any()) throw new InvalidOperationException();

            return all;
        }
    }
}