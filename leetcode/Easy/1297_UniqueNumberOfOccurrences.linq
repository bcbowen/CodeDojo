<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public bool UniqueOccurrences(int[] arr)
{
	Dictionary<int, int> counter = new Dictionary<int, int>();
	foreach(int value in arr)
	{
		if (!counter.ContainsKey(value)) 
		{
			counter.Add(value, 0); 
		}
		counter[value]++; 
	}

	bool[] occurenceCounts = new bool[1001];
	foreach (int value in counter.Values) 
	{
		if (occurenceCounts[value]) return false; 
		occurenceCounts[value] = true; 
	}
	
	return true;
}

/*
Example 1:
Input: arr = [1,2,2,1,1,3]
Output: true
Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values have the same number of occurrences.

Example 2:
Input: arr = [1,2]
Output: false

Example 3:
Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
Output: true
*/

[Theory]
[InlineData(new[] {1,2,2,1,1,3},true )]
[InlineData(new[] {1,2},false )]
[InlineData(new[] {-3,0,1,-3,1,1,1,-3,10,0}, true)]
void Test(int[] values, bool expected) 
{
	bool result = UniqueOccurrences(values); 
	Assert.Equal(expected, result); 
}

