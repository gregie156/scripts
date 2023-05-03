/*
ticks using division: 17658265
ticks using multiply: 17998866
ticks sqrt          : 24415390
blank               : 14689054

*/

using System;
using System.Diagnostics;
					
public class Program
{
	public static void Main()
	{
		var iterations = 10000000;
		
		var watch = Stopwatch.StartNew();
		for (var i = 0; i < iterations; i++){
			var a = i / 2f;
		}
		watch.Stop();
		Console.WriteLine("ticks using division: " + watch.ElapsedTicks);

		GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);		
		GC.WaitForPendingFinalizers();
		
		var watch2 = Stopwatch.StartNew();
		for (var i = 0; i < iterations; i++){
			var a = i * 0.5f;
		}
		watch2.Stop();
		Console.WriteLine("ticks using multiply: " + watch2.ElapsedTicks);
		
		GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);		
		GC.WaitForPendingFinalizers();
		
		var watch3 = Stopwatch.StartNew();
		for (var i = 0; i < iterations; i++){
			var a = Math.Sqrt(i);
		}
		watch3.Stop();
		Console.WriteLine("ticks sqrt          : " + watch3.ElapsedTicks);
		
		GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);		
		GC.WaitForPendingFinalizers();

		
		watch3 = Stopwatch.StartNew();
		for (var i = 0; i < iterations; i++){
		}
		watch3.Stop();
		Console.WriteLine("blank               : " + watch3.ElapsedTicks);
		
		
	}
}
