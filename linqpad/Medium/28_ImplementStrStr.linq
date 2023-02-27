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
	public int StrStr(string haystack, string needle)
	{
		if (needle == "") return 0;

		for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
		{
			if(haystack[i] == needle[0])
			{
				if (haystack.Substring(i, needle.Length) == needle) 
				{
					return i;
				}
			}
		}
		 
		return -1;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);
/*
Example 1:

Input: haystack = "hello", needle = "ll"
Output: 2
Example 2:

Input: haystack = "aaaaa", needle = "bba"
Output: -1
*/
[Theory]
[InlineData("hello", "ll", 2)]
[InlineData("aaaaa", "bba", -1)]
[InlineData("hello", "he", 0)]
[InlineData("hello", "h", 0)]
[InlineData("hello", "lo", 3)]
void StrStrTest(string haystack, string needle, int expected)
{
	int result = new Solution().StrStr(haystack, needle); 
	Assert.Equal(expected, result);
}



#endregion