using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Lib
{
	// This is only good for one-way traversal.
	public class FizzBuzzEnumerable : IEnumerable<string>
	{
		private int maxValue;
		private List<FizzBuzzConfiguration> clientConfiguration;

		public FizzBuzzEnumerable(int maxValue, List<FizzBuzzConfiguration> configurations)
		{
			if (maxValue >= Int32.MaxValue) throw new ArgumentException("Max value is " + Int32.MaxValue);
			this.maxValue = maxValue;
			this.clientConfiguration = configurations;
		}

		public IEnumerator<string> GetEnumerator()
		{
			foreach (var i in Enumerable.Range(1,maxValue))
			{
				string retval = "";
				foreach (var config in clientConfiguration)
				{
					if (i % config.Value == 0)
					{
						retval += config.Text+" ";
					}
				}
				if (string.IsNullOrEmpty(retval))
					retval = i.ToString();
				yield return retval.TrimEnd();
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
