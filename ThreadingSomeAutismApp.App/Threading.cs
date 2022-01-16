using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingSomeAutismApp.App
{
    internal class Threading
    {
        private double x = 0;
        private double fx = 0;
        private const double eps = double.Epsilon;
        private static object locker = new object();
        private int n = Environment.ProcessorCount;
        private int m = 2;
        private Thread threading;
        

        private int a;
        private int b;
        private double h;
        public Threading(int ax, int bx)
        {
            a = ax;
            b = bx;
            h = (bx - ax) / (n * m);
            StartingThreads();
        }
        private void StartingThreads()
        {
            for (int i = 0; i < n; i++)
            {
                threading = new Thread(SolveFx);
                threading.Name = "Поток " + i.ToString();
                threading.Start();
            }
        }
        private void SolveFx()
        {
            lock (locker)
            {
                for (int i = 0; i < m; i++)
                {
                    x += h;
                    fx += Math.Round(h * (Math.Sqrt(1 - (1 / Math.Pow(eps, x))) / ((x * x) + 1)), 3);
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, fx);
                    Thread.Sleep(100);
                }
            }
        }
    }
}
