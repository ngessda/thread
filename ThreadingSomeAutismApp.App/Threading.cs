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
        private static double x;
        private double result = 0;
        public double Result { get; }
        private int n = Environment.ProcessorCount;
        private const int m = 4;
        private Thread thread;

        private double a = 0;
        private double b = 0;
        private static double h;
        public Threading(double ax, double bx)
        {
            a = ax;
            b = bx;
            h = (b - a) / (n * m);
            StartingThreads();
        }
        private void StartingThreads()
        {
            for (int i = 0; i < n; i++)
            {
                thread = new Thread(new ParameterizedThreadStart(SolveFx));
                thread.Name = "Поток " + i.ToString();
                thread.Start(i + 1);
            }
        }
        private void SolveFx(object count)
        {
            double fx = 0;
            x = ((b - a) / n) * (int)count;
            for (int i = 0; i < m; i++)
            {
                x += h;
                fx += h * (Math.Sqrt(1 - (1 / Math.Exp(x))) / (Math.Pow(x, 2) + 1));
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, fx);
                Thread.Sleep(100);
            }
            lock((object)result)
            {
                result += fx;
                Console.WriteLine(Math.Round(result,3));
            }
        }
    }
}