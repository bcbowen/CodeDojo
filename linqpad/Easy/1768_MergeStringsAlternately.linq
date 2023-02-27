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
	public string MergeAlternately(string word1, string word2)
	{
		StringBuilder result = new StringBuilder();
		int i = 0;
		while (i < Math.Max(word1.Length, word2.Length)) 
		{
			if (i < word1.Length) result.Append(word1[i]);
			if (i < word2.Length) result.Append(word2[i]);
			i++;
		}
		return result.ToString();
	}
}

#region private::Tests


/*
Example 1:

Input: word1 = "abc", word2 = "pqr"
Output: "apbqcr"
Explanation: The merged string will be merged as so:
word1:  a   b   c
word2:    p   q   r
merged: a p b q c r
Example 2:

Input: word1 = "ab", word2 = "pqrs"
Output: "apbqrs"
Explanation: Notice that as word2 is longer, "rs" is appended to the end.
word1:  a   b 
word2:    p   q   r   s
merged: a p b q   r   s
Example 3:

Input: word1 = "abcd", word2 = "pq"
Output: "apbqcd"
Explanation: Notice that as word1 is longer, "cd" is appended to the end.
word1:  a   b   c   d
word2:    p   q 
merged: a p b q c   d
*/

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData("abc", "pqr", "apbqcr")]
[InlineData("ab", "pqrs", "apbqrs")]
[InlineData("abcd", "pq", "apbqcd")]
void Tests(string word1, string word2, string expected) 
{
	string result = new Solution().MergeAlternately(word1, word2);
	Assert.Equal(expected, result);
}

#endregion