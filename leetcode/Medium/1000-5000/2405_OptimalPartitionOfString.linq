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
	public int PartitionString(string s)
	{
		HashSet<char> partitionSet = new HashSet<char>();
		int partitionCount = 1;
		foreach (char c in s)
		{
			if (partitionSet.Contains(c))
			{ 
				partitionSet.Clear(); 
				partitionCount++;
			}
			
			partitionSet.Add(c);
		}
		return partitionCount;
	}
}

/*
Example 1:
Input: s = "abacaba"
Output: 4
Explanation:
Two possible partitions are ("a","ba","cab","a") and ("ab","a","ca","ba").
It can be shown that 4 is the minimum number of substrings needed.

Example 2:
Input: s = "ssssss"
Output: 6
Explanation:
The only valid partition is ("s","s","s","s","s","s").
 
*/

[Theory]
[InlineData("abacaba", 4)]
[InlineData("ssssss", 6)]
void Test(string s, int expected) 
{
	int result = new Solution().PartitionString(s); 
	Assert.Equal(expected, result);
}
