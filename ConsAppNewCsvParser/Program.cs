using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsAppNewCsvParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string AppPath = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            string FilePath = Path.Combine(AppPath, "CsvFiles", "SampleCsv.csv");

            CsvParserWithHeader cv = new CsvParserWithHeader(FilePath);
            List<SampleData> sdList = cv.Deserialize<SampleData>();
            foreach (var item in sdList)
            {
                Console.WriteLine("Id : {0}", item.Id);
                Console.WriteLine("Dept : {0}", item.Dept);
                Console.WriteLine("Name : {0}", item.Name);
                Console.WriteLine("Count : {0}", item.Count);
                Console.WriteLine("\n\n");
            }
            Console.ReadKey();
        }
    }
}
