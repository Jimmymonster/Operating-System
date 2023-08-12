//test resource sharing
using System;
using System.Threading;

namespace Experiment3
{
    class Program
    {
        static int resource = 10000;
        static void TestThread1()
        {
            //resource = 55555;
            for (int i = 0; i < 45555; i++)
            {
                resource++;
                Console.Write(".");
            }
        }
        static void Main(string[] args)
        {
            Thread th1 = new Thread(TestThread1);
            th1.Start();
            Thread.Sleep(10);
            th1.Join();
            Console.WriteLine("resource={0}", resource);
        }
    }
}