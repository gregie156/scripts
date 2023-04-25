using System;
using System.Diagnostics;
using System.Collections.Generic;


					
public class Program
{
	public static void Main()
	{
		Stopwatch w;
		var iters = 300 * 15;

		w = Stopwatch.StartNew();
		for (var i = 0; i <= iters; i+=1)
		{
			var a = i % 300;
			var b = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(a+1, 2));
		}
		w.Stop();	
		Console.WriteLine("pyth " + w.ElapsedTicks);	
		
		w = Stopwatch.StartNew();
		for (var i = 0; i <= iters; i+=1)
		{
			var a = i % 300;
			var angle =  Math.Atan((float)a/(a+1));
			var b = a / Math.Sin(angle);
		}
		w.Stop();	
		Console.WriteLine("trig " + w.ElapsedTicks);	
		
		
		var cache = new Dictionary<int, float>();
		w = Stopwatch.StartNew();
		for (var i = 0; i <= iters; i+=1)
		{
			var a = i % 300;
			if (!cache.ContainsKey(a))
			{
				var b = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(a+1, 2));
				cache[a] = (float)b;
			}
			var c = cache[a];
			
		}
		w.Stop();	
		Console.WriteLine("hash cache " + w.ElapsedTicks);	
		
		var cache2 = new float[350];
		w = Stopwatch.StartNew();
		for (var i = 0; i <= iters; i+=1)
		{
			var a = i % 300;
			if (cache2[a] == 0)
			{
				var b = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(a+1, 2));
				cache2[a] = (float)b * -1 -1;
			}
			var c = (cache2[a] + 1) * - 1;
			
		}
		w.Stop();	
		Console.WriteLine("array cache " + w.ElapsedTicks);	
		
		
		var cache3 = new float[350][];
		for (var i = 0; i < 350; i += 1)
		{
			cache3[i] = new float[350];
		}
		w = Stopwatch.StartNew();
		for (var i = 0; i <= iters; i+=1)
		{
			var a = i % 300;
			if (cache3[a][a+1] == 0)
			{
				var b = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(a+1, 2));
				cache3[a][a+1] = (float)b * -1 -1;
			}
			var c = (cache3[a][a+1] + 1) * - 1;
			
		}
		w.Stop();	
		Console.WriteLine("double-array cache " + w.ElapsedTicks);	
		
		var cache4 = new float[350,350];
		w = Stopwatch.StartNew();
		for (var i = 0; i <= iters; i+=1)
		{
			var a = i % 300;
			if (cache4[a, a+1] == 0)
			{
				var b = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(a+1, 2));
				cache4[a, a+1] = (float)b * -1 -1;
			}
			var c = (cache4[a, a+1] + 1) * - 1;
			
		}
		w.Stop();	
		Console.WriteLine("matrix cache " + w.ElapsedTicks);	

	}
}