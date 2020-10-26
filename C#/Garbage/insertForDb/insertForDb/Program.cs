using insertForDb.Core;

using System;
using System.Threading;


namespace insertForDb
{
	class Program
	{

		static void Main(string[] args)
		{

			BeginProgram beginProgram = new BeginProgram();
			
			beginProgram.Start();
			Console.WriteLine(312312312321);
			Thread.CurrentThread.Join();
		}
	}
}
