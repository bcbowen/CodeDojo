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
	public IList<IList<string>> GroupAnagrams(string[] strs)
	{
		List<IList<string>> result = new List<IList<string>>();
		Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
		foreach (string s in strs)
		{
			string key = GetKey(s);
			if (!anagrams.ContainsKey(key))
			{
				anagrams.Add(key, new List<string>());
			}
			anagrams[key].Add(s);
		}

		foreach (string key in anagrams.Keys)
		{
			result.Add(anagrams[key]);
		}

		return result;
	}

	internal string GetKey(string value)
	{
		char[] chars = value.ToCharArray();
		Array.Sort(chars);
		string key = new string(chars);
		return key;
	}
}

#region private::Tests

[Fact]
void Test()
{
	/*
	Example 1:
	Input: strs = ["eat","tea","tan","ate","nat","bat"]
	Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
	*/

	string[] strs = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };

	IList<IList<string>> result = new Solution().GroupAnagrams(strs);
	Assert.Equal(3, result.Count);
	for (int i = 0; i < result.Count; i++)
	{
		IList<string> row = result[i];
		switch(row.Count) 
		{
			case 1: 
				Assert.Equal("bat", row[0]); 
				break;
			case 2: 
				Assert.True(row.Contains("nat"));
				Assert.True(row.Contains("tan"));
				break;
			case 3:
				Assert.True(row.Contains("ate"));
				Assert.True(row.Contains("eat"));
				Assert.True(row.Contains("tea"));
				break;
		}
	}
	
}

[Theory]
[InlineData("bad", "abd")]
[InlineData("sack", "acks")]
[InlineData("e", "e")]
void KeyTest(string value, string expected)
{
	string result = new Solution().GetKey(value);
	Assert.Equal(expected, result);
}



/*
Example 2:
Input: strs = [""]
Output: [[""]]

Example 3:
Input: strs = ["a"]
Output: [["a"]]
*/

#endregion