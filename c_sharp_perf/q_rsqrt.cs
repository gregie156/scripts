using System;
using System.Diagnostics;

/*
regular: 28400
quick:   258101
https://en.wikipedia.org/wiki/Fast_inverse_square_root

Maybe with unsafe code we could use pointers and make it faster
*/
					
public class Program
{
	
	static float Q_rsqrt( float number )
	{
		int i;
		float x2, y;
		const float threehalfs = 1.5F;

		x2 = number * 0.5F;
		y  = number;
		i  = BitConverter.SingleToInt32Bits(y);                    // evil floating point bit level hacking
		i  = 0x5f3759df - ( i >> 1 );               // what the fuck? 
		y  = BitConverter.Int32BitsToSingle(i);
		y  = y * ( threehalfs - ( x2 * y * y ) );   // 1st iteration
	//	y  = y * ( threehalfs - ( x2 * y * y ) );   // 2nd iteration, this can be removed

		return y;
	}
	
	public static void Main()
	{
		var iterations = 10000;
		Stopwatch stopwatch;
		
		stopwatch = Stopwatch.StartNew();
		for (var i = 0; i < iterations; i++)
		{
			var fi = (float)i;
			var b = Math.Sqrt(fi);
		}
		stopwatch.Stop();
		Console.WriteLine("regular: " + stopwatch.ElapsedTicks);
		
				
		GC.Collect(GC.MaxGeneration, GCCollectionMode.Aggressive, true, true);		
		GC.WaitForPendingFinalizers();

		
		stopwatch = Stopwatch.StartNew();
		for (var i = 0; i < iterations; i++)
		{
			var fi = (float)i;
			var b = 1/Q_rsqrt(fi);
		}
		stopwatch.Stop();
		Console.WriteLine("quick:   " + stopwatch.ElapsedTicks);
	}
}
