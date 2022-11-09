using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class test
    {
        static void Main(string[] args)
        {
            double a = 12.435;
            double b=Math.Round(a, 2);
            string c = a.ToString("0.00");
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.ReadKey();

        }
    }
}
