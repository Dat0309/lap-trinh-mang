using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadExample
{
    public class ThreadClass
    {
		private const int RAND_SLEEP_MAX = 1000;
		private const int LOOP_COUNT = 10;
		private string msg;

		public ThreadClass(string message)
		{
			this.msg = message;
		}

		public void Run()
		{
			Random random = new Random();
			for (int i = 0; i < LOOP_COUNT; i++)
			{
				Console.WriteLine(msg + " (Thread ID: " + Thread.CurrentThread.GetHashCode() + ")");
				try
				{
					Thread.Sleep(random.Next(0, RAND_SLEEP_MAX));
				}
				catch (Exception)
				{
				}
			}
		}
	}
}
