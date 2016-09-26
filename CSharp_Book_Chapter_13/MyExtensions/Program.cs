using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExtension;

namespace MyExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Clones are wreaking havoc at the factory. Help!";
            Console.WriteLine(message.IsDistressCall());
            Console.ReadKey();
        }
    }
}
