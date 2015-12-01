using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Lib
{
	public class FizzBuzzEvents
	{
		private int maxValue;
		private List<FizzBuzzConfiguration> clientConfiguration;
		public delegate void FizzBuzzResultHandler(FizzBuzzEvents obj, ResultEventArgs args);
		public event FizzBuzzResultHandler FizzBuzzResulted;

		public FizzBuzzEvents(int maxValue, List<FizzBuzzConfiguration> configurations)
		{
			if (maxValue >= Int32.MaxValue) throw new ArgumentException("Max value is " + Int32.MaxValue);
			this.maxValue = maxValue;
			this.clientConfiguration = configurations;
		}

		public void GetResults()
		{
			foreach (var i in Enumerable.Range(1, maxValue))
			{
				string retval = "";
				foreach (var config in clientConfiguration)
				{
					if (i % config.Value == 0)
					{
						retval += config.Text + " ";
					}
				}
				if (string.IsNullOrEmpty(retval))
					retval = i.ToString();
				if (FizzBuzzResulted != null)
					FizzBuzzResulted(this,new ResultEventArgs() {Result = new FizzBuzzResult() {Result = retval.TrimEnd(), Value = i} });
			}
		}
	}

	public class ResultEventArgs : EventArgs	
	{
		public FizzBuzzResult Result { get; set; }
	}
}
