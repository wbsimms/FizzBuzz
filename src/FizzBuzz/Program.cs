using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz.Lib;

namespace FizzBuzz
{
	class Program
	{
		static void Main(string[] args)
		{
			FizzBuzz.Lib.FizzBuzz buzz = new FizzBuzz.Lib.FizzBuzz(new List<FizzBuzzConfiguration>()
			{
				new FizzBuzzConfiguration() {Text = "Foo", Value = 3},
				new FizzBuzzConfiguration() {Text = "Bar", Value = 5},
                new FizzBuzzConfiguration() {Text = "Zip", Value = 7}
			});
			int count = Int32.MaxValue/8; // don't run this. :)
			//int count = 100;
			Console.WriteLine(DateTime.Now.ToString());
			buzz.BuildResults(count);
			Console.WriteLine(DateTime.Now.ToString());
			//foreach (var i in Enumerable.Range(1, count))
			//{
			//	var result = buzz.GetResult(i);
			//	Console.WriteLine(result.Value + " " + result.Result);
			//}
		}
	}
}
