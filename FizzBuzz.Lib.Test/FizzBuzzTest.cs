using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace FizzBuzz.Lib.Test
{
	[TestFixture]
	public class FizzBuzzTest
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
			FizzBuzz fb = new FizzBuzz(config);
			Assert.IsNotNull(fb);
		}

		[Test]
		public void FizzBuzzShouldAppearFor15Test()
		{
			FizzBuzz fb = new FizzBuzz(config);
			var result = fb.BuildResults(16);
			Assert.IsTrue(result);
			Assert.AreEqual("Fizz Buzz", fb.GetResult(15).Result);
		}

		[Test]
		public void Int32MaxValueInvalidTest()
		{
			FizzBuzz fb = new FizzBuzz(config);
			Assert.Throws<ArgumentException>(() => fb.BuildResults(Int32.MaxValue));
		}

		[Test]
		public void DuplicateValuesTest()
		{
			config.Add(new FizzBuzzConfiguration()
			{
				Text = "Fizz",
				Value = 7
			});
			FizzBuzz fb = new FizzBuzz(config);
			Assert.Throws<ArgumentException>(() => fb.BuildResults(10));
		}

		[Test]
		public void DuplicateTextTest()
		{
			config.Add(new FizzBuzzConfiguration()
			{
				Text = "Zip",
				Value = 5
			});

			FizzBuzz fb = new FizzBuzz(config);
			Assert.Throws<ArgumentException>(() => fb.BuildResults(10));
		}



		[Test,Ignore("long test")]
		public void LargeValueWontBlowMemoryTest()
		{
			FizzBuzz fb = new FizzBuzz(config);
			Assert.IsTrue(fb.BuildResults(Int32.MaxValue-1));
		}

	}
}
