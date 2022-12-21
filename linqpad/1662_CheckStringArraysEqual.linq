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
	public bool ArrayStringsAreEqual(string[] word1, string[] word2)
	{
		StringBuilder sb1 = new StringBuilder();
		foreach (string s in word1)
		{
			sb1.Append(s); 
		}

		StringBuilder sb2 = new StringBuilder();
		foreach (string s in word2)
		{
			sb2.Append(s);
		}
		
		return sb1.Equals(sb2);
	}
}

#region private::Tests

[Theory]
[InlineData(new[] {"ab", "c"}, new[] {"a", "bc"}, true)]
[InlineData(new[] {"a", "cb"}, new[] {"ab", "c"}, false)]
[InlineData(new[] {"abc", "d", "defg"}, new[] {"abcddefg"}, true)]
[InlineData(new[] {"bbb"}, new[] {"bbb"}, true)]
[InlineData(new[] {"bbb"}, new[] {"bb"}, false)]
[InlineData(new[] {"bb"}, new[] {"bbb"}, false)]

void Test(string[] word1, string[] word2, bool expected) 
{
	bool result = new Solution().ArrayStringsAreEqual(word1, word2);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: word1 = ["ab", "c"], word2 = ["a", "bc"]
Output: true
Explanation:
word1 represents string "ab" + "c" -> "abc"
word2 represents string "a" + "bc" -> "abc"
The strings are the same, so return true.

Example 2:
Input: word1 = ["a", "cb"], word2 = ["ab", "c"]
Output: false

Example 3:
Input: word1  = ["abc", "d", "defg"], word2 = ["abcddefg"]
Output: true
*/
#endregion