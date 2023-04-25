using System;
using System.Diagnostics;
using System.Collections.Generic;


					
public class Program
{
	public static int l = 100000;
	public static Stopwatch w;


	public static void Main()
	{
		reg();
		mat();
	}
	
	public static void mat()
	{
		var dim = (int)Math.Sqrt(l);
		var matrix = new int[dim, dim];
				int b; int c;
		var jagged = new int[dim][];
		for(var i = 0; i < dim; i +=1)
		{
			jagged[i] = new int[dim];
		}

		b=0;
		w = Stopwatch.StartNew();
		for(var i = 0; i < dim; i +=1 )
					for(var j = 0; j < dim; j +=1 )

		{
			b = b + matrix[i, j]; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("for matrix " + w.ElapsedTicks);
		
		b=0;
		w = Stopwatch.StartNew();
		for(var i = 0; i < dim; i +=1 )
			for(var j = 0; j < dim; j +=1 )

		{
			b = b + jagged[i][j]; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("for jagged " + w.ElapsedTicks);		

	}

	public static void reg()
	{
		
		int b; int c;
		
		int[] arr = new int[l];
		List<int> lst = new List<int>();
		HashSet<int> hash = new HashSet<int>();

		
		for(var i = 0; i < l; i += 1)
		{
			arr[i] = i;
			lst.Add(i);
			hash.Add(i);
		}
		
		b=0;
		w = Stopwatch.StartNew();
		foreach(var a in hash)
		{
			b = b + a; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("foreach hash " + w.ElapsedTicks);
		

		b=0;
		w = Stopwatch.StartNew();
		foreach(var a in lst)
		{
			b = b + a; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("foreach list " + w.ElapsedTicks);	
		
		b=0;
		w = Stopwatch.StartNew();
		foreach(var a in arr)
		{
			b = b + a; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("foreach arr " + w.ElapsedTicks);	
		
		b=0;
		w = Stopwatch.StartNew();
		for(var i = 0; i<l; i+=1)
		{
			if (hash.Contains(i))
			b = i; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("for hash " + w.ElapsedTicks);	
		
		b=0;
		w = Stopwatch.StartNew();
		for(var i = 0; i<l; i+=1)
		{
			b = b + lst[i]; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("for list " + w.ElapsedTicks);	
		
		b=0;
		w = Stopwatch.StartNew();
		for(var i = 0; i<l; i+=1)
		{
			b = b + arr[i]; 
		}
		w.Stop();
		c = b + 1;
		Console.WriteLine("for arr " + w.ElapsedTicks);	
		

	}
}