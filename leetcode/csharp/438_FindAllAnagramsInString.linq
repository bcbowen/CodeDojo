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
	public IList<int> FindAnagrams(string s, string p)
	{
		List<int> indices = new List<int>();
		if(p.Length > s.Length) return indices;

		Dictionary<char, int> chars = new Dictionary<char, int>();
		Dictionary<char, int> charsCheck = new Dictionary<char, int>();
		foreach (char c in p)
		{
			if (!chars.ContainsKey(c))
			{
				chars.Add(c, 0);
			}
			if (!charsCheck.ContainsKey(c))
			{
				charsCheck.Add(c, 0);
			}
			chars[c]++;
		}

		int j = p.Length - 1;
		for (int k = 0; k <= j; k++)
		{
			if (charsCheck.ContainsKey(s[k]))
			{
				charsCheck[s[k]]++;
			}
		}

		if (CompareLists(chars, charsCheck))
		{
			indices.Add(0);
		}

		for (int i = 1; i <= s.Length - p.Length; i++)
		{
			if (charsCheck.ContainsKey(s[i - 1]))
			{
				charsCheck[s[i - 1]]--;
			}

			j++;
			if (charsCheck.ContainsKey(s[j]))
			{
				charsCheck[s[j]]++;
			}

			if (CompareLists(chars, charsCheck))
			{
				indices.Add(i);
			}

		}

		return indices;
	}

	private bool CompareLists(Dictionary<char, int> chars, Dictionary<char, int> charsCheck)
	{
		foreach (char key in chars.Keys)
		{
			if (chars[key] != charsCheck[key])
			{
				return false;
			}
		}
		return true;
	}
}

#region private::Tests

[Theory]
[InlineData("cbaebabacd", "abc", new[] { 0, 6 })]
[InlineData("abab", "ab", new[] { 0, 1, 2 })]
[InlineData("baa", "aa", new[] { 1 })]
[InlineData("aaaaaaaaaa", "aaaaaaaaaaaaa", new int[0])]
void Test(string s, string p, int[] expected)
{
	IList<int> result = new Solution().FindAnagrams(s, p);
	Assert.Equal(expected, result.ToArray());
}

/*

"aaaaaaaaaa"
"aaaaaaaaaaaaa"

Example 1:
Input: s = "cbaebabacd", p = "abc"
Output: [0,6]
Explanation:
The substring with start index = 0 is "cba", which is an anagram of "abc".
The substring with start index = 6 is "bac", which is an anagram of "abc".

Example 2:
Input: s = "abab", p = "ab"
Output: [0,1,2]
Explanation:
The substring with start index = 0 is "ab", which is an anagram of "ab".
The substring with start index = 1 is "ba", which is an anagram of "ab".
The substring with start index = 2 is "ab", which is an anagram of "ab".

*/

#endregion