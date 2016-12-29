using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScript
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            object o = i;
            Console.WriteLine(i);
            Console.WriteLine(o);
            i = 5;
            Console.WriteLine(i);
            Console.WriteLine(o);
        }
    }
}
