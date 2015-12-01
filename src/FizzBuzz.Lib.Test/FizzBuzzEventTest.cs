using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace FizzBuzz.Lib.Test
{
	[TestFixture]
	public class FizzBuzzEventTest
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
			var fb = new FizzBuzzEvents(16,config);
			Assert.IsNotNull(fb);
		}

		[Test]
		public void FizzBuzzShouldAppearFor15Test()
		{
			var fb = new FizzBuzzEvents(16, config);
			fb.FizzBuzzResulted += (example, args) =>
			{
				Assert.IsNotNull(args.Result);
				if (args.Result.Value == 15)
				{
					Assert.AreEqual("Fizz Buzz", args.Result.Result);
				}
			};
			fb.GetResults();
		}


		[Test]
		public void Int32MaxValueInvalidTest()
		{
			Assert.Throws<ArgumentException>(() => new FizzBuzzEvents(Int32.MaxValue,config));
		}

		[Test]
		public void LargeValueWontBlowMemoryTest()
		{
			var fb = new FizzBuzzEvents(100, config);
			fb.FizzBuzzResulted += (obj, args) =>
			{
				Console.WriteLine(args.Result.Result);
			};
			fb.GetResults();
		}

	}
}
