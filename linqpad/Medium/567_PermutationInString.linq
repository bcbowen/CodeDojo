<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public partial class Solution
{
	public bool CheckInclusion(string s1, string s2)
	{

		Dictionary<char, int> masterCounts = new Dictionary<char, int>();
		foreach (char c in s1)
		{
			if (!masterCounts.ContainsKey(c))
			{
				masterCounts.Add(c, 0);
			}
			masterCounts[c]++;
		}

		for (int i = 0; i <= s2.Length - s1.Length; i++)
		{
			char c = s2[i];
			if (masterCounts.ContainsKey(c))
			{
				string value = s2.Substring(i, s1.Length);
				if (IsPermutation(value, masterCounts)) return true;
			}
		}
		return false;
	}

	/// <summary>
	/// Value is a permutation of the characters stored in masterCounts
	/// </summary>
	/// <param name="value"></param>
	/// <param name="masterCounts"></param>
	/// <returns></returns>
	internal bool IsPermutation(string value, Dictionary<char, int> masterCounts)
	{
		Dictionary<char, int> charCounts = CopyCounts(masterCounts);
		foreach (char c in value)
		{
			if (charCounts.ContainsKey(c) && charCounts[c] > 0)
			{
				charCounts[c]--;
			}
			else
			{
				return false;
			}
		}

		return true;
	}

	private Dictionary<char, int> CopyCounts(Dictionary<char, int> masterCounts)
	{
		Dictionary<char, int> charCounts = new();
		foreach (char key in masterCounts.Keys)
		{
			charCounts[key] = masterCounts[key];
		}

		return charCounts;
	}
}

[Theory]
[InlineData("ac", "ac", true)]
[InlineData("ac", "ca", true)]
[InlineData("ac", "cb", false)]
[InlineData("ac", "ab", false)]
[InlineData("aaaabc", "caaaab", true)]
[InlineData("abcdef", "fedcba", true)]
[InlineData("aabbcc", "abcabc", true)]
public void P00567_PermutationInString_IsPermutationTests(string s1, string s2, bool expected)
{
	Dictionary<char, int> masterCounts = new Dictionary<char, int>();
	foreach (char c in s1)
	{
		if (!masterCounts.ContainsKey(c))
		{
			masterCounts.Add(c, 0);
		}
		masterCounts[c]++;
	}

	bool result = new Solution().IsPermutation(s2, masterCounts);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("ab", "eidbaooo", true)]
[InlineData("ab", "eidboaoo", false)]
[InlineData("ab", "eidoooba", true)]
[InlineData("ab", "baeidooo", true)]
[InlineData("ab", "abeidooo", true)]
[InlineData("ab", "eidoooab", true)]
[InlineData("aab", "eidooobaa", true)]
[InlineData("aba", "eidoooaab", true)]
[InlineData("aba", "abdoooaab", true)]
[InlineData("aba", "aabeidooo", true)]
[InlineData("aba", "baaeidooo", true)]
[InlineData("aba", "baeaidooo", false)]
[InlineData("aaa", "aaaidooo", true)]
[InlineData("aaa", "idoooaaa", true)]
[InlineData("aaa", "idaaaooo", true)]
public void P00567_PermutationInString_CheckInclusionTests(string s1, string s2, bool expected)
{
	bool result = new Solution().CheckInclusion(s1, s2);
	Assert.Equal(expected, result);
}