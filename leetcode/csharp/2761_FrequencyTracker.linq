<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class FrequencyTracker
{

	private Dictionary<int, int> _frequencies;
	private Dictionary<int, int> _values; 

	/*
	FrequencyTracker(): Initializes the FrequencyTracker object with an empty array initially.
	void add(int number): Adds number to the data structure.
	void deleteOne(int number): Deletes one occurence of number from the data structure. The data structure may not contain number, and in this case nothing is deleted.
	bool hasFrequency(int frequency): Returns true if there is a number in the data structure that occurs
	frequency number of times, otherwise, it returns false.
	
	With one dictionary for values, the largest case fails with TLE and takes 72 seconds in Linqpad. Adding
	a second dictionary for lookups: 
	
	frequencies: counts of frequencies for each value. ex: values [1, 1, 2, 2, 3, 3, 3, 4]: 2 values have a frequency of 2, one 3 and one 1
	values: the values with the counts. In the above example: 1 has 2, 2 has 2, 3 has 3, 4 has 1. 
	
	Having 2 dictionaries is crazy but should save time with the test case with 200k of each operation (ie 200 lookups for frequency 2) 
	*/

	public FrequencyTracker()
	{
		_frequencies = new Dictionary<int, int>();
		_values = new Dictionary<int, int>(); 
	}

	public void Add(int number)
	{
		if (!_values.ContainsKey(number))
		{
			_values.Add(number, 0);
		}
		_values[number]++;

		if (_values[number] > 1) 
		{
			_frequencies[_values[number] - 1]--; 
		}

		IncrementFrequency(_values[number]);
	}

	public void DeleteOne(int number)
	{
		if (!_values.ContainsKey(number)) return;
		
		// decrement the current freq
		DecrementFrequency(_values[number]); 

		if (_values.ContainsKey(number) && _values[number] > 0)
		{
			_values[number]--;
		}

		IncrementFrequency(_values[number]);
		
	}

	public bool HasFrequency(int frequency)
	{
		return _frequencies.ContainsKey(frequency) && _frequencies[frequency] > 0;
	}

	internal void IncrementFrequency(int value)
	{
		if (!_frequencies.ContainsKey(value))
		{
			_frequencies.Add(value, 0);
		}
		_frequencies[value]++;
	}

	internal void DecrementFrequency(int value)
	{
		if (_frequencies.ContainsKey(value) && _frequencies[value] > 0)
		{
			_frequencies[value]--;
		}
	}
}

[Fact]
void TestExample1()
{
	/*
		Example 1:

		Input
		["FrequencyTracker", "add", "add", "hasFrequency"]
		[[], [3], [3], [2]]
		Output
		[null, null, null, true]

		Explanation
		FrequencyTracker frequencyTracker = new FrequencyTracker();
		frequencyTracker.add(3); // The data structure now contains [3]
		frequencyTracker.add(3); // The data structure now contains [3, 3]
		frequencyTracker.hasFrequency(2); // Returns true, because 3 occurs twice
	
	*/
	FrequencyTracker f = new FrequencyTracker();
	f.Add(3);
	f.Add(3);
	Assert.True(f.HasFrequency(2));
}

[Fact]
void TestExample2()
{
	/*
		Example 2:

		Input
		["FrequencyTracker", "add", "deleteOne", "hasFrequency"]
		[[], [1], [1], [1]]
		Output
		[null, null, null, false]

		Explanation
		FrequencyTracker frequencyTracker = new FrequencyTracker();
		frequencyTracker.add(1); // The data structure now contains [1]
		frequencyTracker.deleteOne(1); // The data structure becomes empty []
		frequencyTracker.hasFrequency(1); // Returns false, because the data structure is empty
	*/
	FrequencyTracker f = new FrequencyTracker();
	f.Add(1);
	f.DeleteOne(1);
	Assert.False(f.HasFrequency(1));
}

[Fact]
void TestExample3()
{
	/*
	Example 3:

	Input
	["FrequencyTracker", "hasFrequency", "add", "hasFrequency"]
	[[], [2], [3], [1]]
	Output
	[null, false, null, true]

	Explanation
	FrequencyTracker frequencyTracker = new FrequencyTracker();
	frequencyTracker.hasFrequency(2); // Returns false, because the data structure is empty
	frequencyTracker.add(3); // The data structure now contains [3]
	frequencyTracker.hasFrequency(1); // Returns true, because 3 occurs once
	*/
	FrequencyTracker f = new FrequencyTracker();
	Assert.False(f.HasFrequency(2));
	f.Add(2);
	f.Add(3);
	Assert.False(f.HasFrequency(2));
	Assert.True(f.HasFrequency(1));
}

[Fact]
void DeleteValueThatDoesNotExist() 
{
	FrequencyTracker f = new FrequencyTracker(); 
	f.DeleteOne(1); 
	// if this doesn't throw the test passes
}


private static string GetDataDirectoryPath()
{
	DirectoryInfo queryPath = new FileInfo(Util.CurrentQueryPath).Directory;
	DirectoryInfo dataDirectory = queryPath.Parent.GetDirectories().First(d => d.Name == "Data");
	return dataDirectory.FullName;
}

/// <summary>
/// * Without compression, takes ~12.5 seconds
/// * With compression takes ~.09 seconds! 
/// </summary>
[Fact]
void BigTest()
{
	string path = Path.Combine(GetDataDirectoryPath(), "2671_FrequencyTracker.txt");
	Assert.True(File.Exists(path));
	string[] operations;
	string[] values;
	using (StreamReader reader = new StreamReader(path)) 
	{
		string line = reader.ReadLine(); 
		operations = line.Split(",");
		line = reader.ReadLine(); 
		values = line.Split(",");
	
		reader.Close(); 
	}

	FrequencyTracker f = new FrequencyTracker();
	int i = 0;
	int trueCount = 0; 
	int falseCount = 0; 
	while (i < operations.Length)
	{
		switch (operations[i]) 
		{
			case "a": 
				f.Add(int.Parse(values[i])); 
				break;
			case "h":
				if (f.HasFrequency(int.Parse(values[i])))
				{
					trueCount++;
				}
				else 
				{
					falseCount++; 
				}
				break;
		}
		i++;
	}
	Console.WriteLine($"true: {trueCount}"); 
	Console.WriteLine($"false: {falseCount}"); 
}


[Fact]
void LeetCodeFailedCase1097() 
{
	/*
	["FrequencyTracker","add","add","deleteOne","hasFrequency","hasFrequency","deleteOne","deleteOne","hasFrequency","deleteOne","hasFrequency","hasFrequency","add","deleteOne"]
	[[],[14],[35],[15],[1],[1],[9],[14],[1],[35],[1],[1],[38],[31]]
	[null,null,null,null,true,true,null,null,true,null,false,false,null,null]
		
	"FrequencyTracker" [] null
	add 14 null
	add 35 null
	deleteOne 15 null
	hasFrequency 1 true
	hasFrequency 1 true
	deleteOne 9 null
	deleteOne 14 null
	hasFrequency 1 true
	deleteOne 35 null
	hasFrequency 1 false
	hasFrequency 1 false
	add 38 null
	deleteOne 31 null
	*/
	
	FrequencyTracker f = new FrequencyTracker(); 
	f.Add(14); 
	f.Add(35); 
	f.DeleteOne(15); 
	bool br = f.HasFrequency(1); 
	bool be = true; 
	Assert.Equal(be, br); 
	br = f.HasFrequency(1); 
	Assert.Equal(be, br);
	f.DeleteOne(9);
	f.DeleteOne(14);
	br = f.HasFrequency(1);
	Assert.Equal(be, br);
	f.DeleteOne(35);
	be = false;
	br = f.HasFrequency(1);
	Assert.Equal(be, br);
	br = f.HasFrequency(1);
	Assert.Equal(be, br);
	f.Add(38); 
	f.DeleteOne(31);

}
