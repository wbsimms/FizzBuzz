# FizzBuzz
This is for Clear Measure

There are two classes of interest:

1. FizzBuzz
	1. For random access retrieval
1. FizzBuzzEnumerable
	1. For one-way retrieval

## FizzBuzz

Usage:

###- Create your configurations

```c#
var config = new List<FizzBuzzConfiguration>()
{
	new FizzBuzzConfiguration() {Text = "Fizz", Value = 3},
	new FizzBuzzConfiguration() {Text = "Buzz", Value = 5},
};
```

###- Create your FizzBuzz instance and build the result set for the desired number of records

```c#
FizzBuzz fb = new FizzBuzz(config);
fb.BuildResult(40) // FizzBuzz to 40
``` 

###- Retreive the results in any order desired

```C#
string result = fb.GetResult(15).Result; // result is "Fizz Buzz"
string result = fb.GetResult(3).Result; // result is "Fizz"
```

## FizzBuzzEnumerable

Usage:

###- Create your configurations

```c#
var config = new List<FizzBuzzConfiguration>()
{
	new FizzBuzzConfiguration() {Text = "Fizz", Value = 3},
	new FizzBuzzConfiguration() {Text = "Buzz", Value = 5},
};
```

###- Create your FizzBuzzEnumerable with the number of records and configurations

```c#
FizzBuzzEnumerable fb = new FizzBuzzEnumerable(15, config);
```

###- Loop through the records
```c#
foreach (var result in fb)
{
	console.writeline(result);
}
```