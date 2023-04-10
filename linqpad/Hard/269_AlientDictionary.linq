<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public string AlienOrder(string[] words)
	{

		// 'a' (97) - 'z' (122)
		int[] inDegrees = new int[26]; 
		Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>(); 
		
	}
}

/*
Input: words = ["wrt","wrf","er","ett","rftt"]
Output: "wertf"


w-e
e-r
t-f
r-t

w - e - r - t - f
*/

[Theory]
[InlineData(new[] {"wrt","wrf","er","ett","rftt"}, "wertf")]
[InlineData(new[] {"z","x"}, "zx")]
[InlineData(new[] {"z","x","z"}, "")]
void Test(string[] words, string expected) 
{
	string result = new Solution().AlienOrder(words);
	Assert.Equal(expected, result); 
}
