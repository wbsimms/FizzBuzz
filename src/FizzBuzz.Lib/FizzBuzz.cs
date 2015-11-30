using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Lib
{
	// This provides random access to results.
    public class FizzBuzz
    {
	    private List<FizzBuzzConfiguration> clientConfiguration;
	    private List<FizzBuzzConfigurationInt> storage; 

	    public FizzBuzz(List<FizzBuzzConfiguration> configurations)
	    {
		    this.clientConfiguration = configurations;
			this.storage = new List<FizzBuzzConfigurationInt>();
	    }

	    public FizzBuzzResult GetResult(int value)
	    {

			var retval = new FizzBuzzResult() { Value = value};
			StringBuilder sb = new StringBuilder();
		    foreach (var store in storage)
		    {
			    if (store.BitArray[value])
				    sb.Append(store.Config.Text + " ");
		    }

		    retval.Result = sb.Length == 0 ? value.ToString() : sb.ToString().TrimEnd();
		    return retval;
	    }

	    private void SetUp(int max)
	    {
			if (clientConfiguration.Select(x => x.Value).Distinct().Count() < clientConfiguration.Count)
				throw new ArgumentException("You have duplicate values");
			if (clientConfiguration.Select(x => x.Text).Distinct().Count() < clientConfiguration.Count)
				throw new ArgumentException("You have duplicate text");

			foreach (var config in clientConfiguration)
		    {
				storage.Add(new FizzBuzzConfigurationInt()
				{
					Config = config,
					BitArray = new BitArray(max+1,false)
				});
		    }

	    }

	    public bool BuildResults(int max)
	    {
			if (max >= Int32.MaxValue) throw new ArgumentException("Max value is" + Int32.MaxValue);
			SetUp(max);

			foreach (var i in Enumerable.Range(1, max))
			{
				foreach (var store in storage)
				{
					if (i % store.Config.Value == 0)
					{
						store.BitArray[i] = true;
					}
				}
			}
		    return true;
	    }

	    class FizzBuzzConfigurationInt
	    {
		    public FizzBuzzConfiguration Config { get; set; }
		    public BitArray BitArray { get; set; }
	    }
    }
}
