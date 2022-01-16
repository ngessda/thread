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
            new Threading(12,2);
            Console.ReadKey();
        }
    }
}
