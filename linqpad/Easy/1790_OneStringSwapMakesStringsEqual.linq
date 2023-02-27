<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

/*
Example 1:
Input: s1 = "bank", s2 = "kanb"
Output: true
Explanation: For example, swap the first character with the last character of s2 to make "bank".

Example 2:
Input: s1 = "attack", s2 = "defend"
Output: false
Explanation: It is impossible to make them equal with one string swap.

Example 3:
Input: s1 = "kelb", s2 = "kelb"
Output: true
Explanation: The two strings are already equal, so no string swap operation is required.
*/
[Theory]
[InlineData("bank", "kanb", true)]
[InlineData("attack", "defend", false)]
[InlineData("kelb", "kelb", true)]
void AreAlmostEqualTests(string s1, string s2, bool expected) 
{
	bool result = new Solution().AreAlmostEqual(s1, s2); 
	Assert.Equal(expected, result);
}

public class Solution
{
	public bool AreAlmostEqual(string s1, string s2)
	{
		if (s1 == null || s2 == null || s1.Length != s2.Length) return false;
		List<int> diffs = new List<int>();
		for (int i = 0; i < s1.Length; i++)
		{
			if (s1[i] != s2[i])
			{
				if (diffs.Count > 1) return false;
				diffs.Add(i);
			}
		}
		switch (diffs.Count)
		{
			case 0:
				return true;
			case 2:
				return s1[diffs[0]] == s2[diffs[1]] && s1[diffs[1]] == s2[diffs[0]];
			default:
				return false;
		}

	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion