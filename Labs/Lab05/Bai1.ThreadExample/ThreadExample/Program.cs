using System;
using System.Threading;

namespace ThreadExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThreadClass threadClass = new ThreadClass("The first thread is running...");
            Thread thread1 = new Thread(threadClass.Run);
            thread1.Start();

            ThreadClass threadClass1 = new ThreadClass("The second thread is running...");
            Thread thread2 = new Thread(threadClass1.Run);
            thread2.Start();

            Console.ReadKey();
        }
    }
}
