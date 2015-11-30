using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzz.Lib.Test
{
	[TestFixture]
	public class FizzBuzzEnumerableTest
	{
		private List<FizzBuzzConfiguration> config;

		[SetUp]
		public void FixtureSetUp()
		{
			config = new List<FizzBuzzConfiguration>()
			{
				new FizzBuzzConfiguration() {Text = "Fizz", Value = 3},
				new FizzBuzzConfiguration() {Text = "Buzz", Value = 5},
			};
		}

		[Test]
		public void ConstructorTest()
		{
			FizzBuzzEnumerable fb = new FizzBuzzEnumerable(16,config);
			Assert.IsNotNull(fb);
		}

		[Test]
		public void FizzBuzzFor15Test()
		{
			FizzBuzzEnumerable fb = new FizzBuzzEnumerable(15, config);
			Assert.IsNotNull(fb);
			string retval = "";
			foreach (var result in fb)
			{
				retval = result;
			}
			Assert.AreEqual("Fizz Buzz", retval);
		}

		[Test,Ignore("long test")]
		public void IntMaxMinusOneTest()
		{
			FizzBuzzEnumerable fb = new FizzBuzzEnumerable(Int32.MaxValue-1, config);
			Assert.IsNotNull(fb);
			string retval = "";
			foreach (var result in fb)
			{
				retval = result;
			}
			Console.WriteLine(retval);
		}



	}
}
