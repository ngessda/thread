using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSomeAutismApp.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Threading x = new Threading(0, 1);
            Console.ReadKey();
        }
    }
}
