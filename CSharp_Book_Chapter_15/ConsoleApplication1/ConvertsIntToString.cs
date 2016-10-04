using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ConvertsIntToString
    {
        delegate string ConvertIntToString(int i);

        private static string HiThere(int i)
        {
            return $"Hi there! #{i * 100}";
        }

        static void Main(string[] args)
        {
            ConvertIntToString someMethod = new ConvertIntToString(HiThere);
            string message = someMethod(5);
            Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
