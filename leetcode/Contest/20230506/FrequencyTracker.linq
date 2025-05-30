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

	/*
	FrequencyTracker(): Initializes the FrequencyTracker object with an empty array initially.
	void add(int number): Adds number to the data structure.
	void deleteOne(int number): Deletes one occurence of number from the data structure. The data structure may not contain number, and in this case nothing is deleted.
	bool hasFrequency(int frequency): Returns true if there is a number in the data structure that occurs
	frequency number of times, otherwise, it returns false.
	*/

	public FrequencyTracker()
	{
		_frequencies = new Dictionary<int, int>(); 
	}

	public void Add(int number)
	{
		if (!_frequencies.ContainsKey(number)) 
		{
			_frequencies.Add(number, 0); 
		}
		_frequencies[number]++; 
	}

	public void DeleteOne(int number)
	{
		if (_frequencies.ContainsKey(number) && _frequencies[number] > 0) 
		{
			_frequencies[number]--;	 
		}
	}

	public bool HasFrequency(int frequency)
	{
		return _frequencies.Values.Any(v => v == frequency);
	}
}

/**
 * Your FrequencyTracker object will be instantiated and called as such:
 * FrequencyTracker obj = new FrequencyTracker();
 * obj.Add(number);
 * obj.DeleteOne(number);
 * bool param_3 = obj.HasFrequency(frequency);
 */


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
	f.Add(1); 
	Assert.True(f.HasFrequency(2)); 
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
	f.Add(2);
	f.Add(3);
	Assert.False(f.HasFrequency(2));
	Assert.True(f.HasFrequency(1));
}
