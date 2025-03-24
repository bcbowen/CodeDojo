<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

class Solution 
{
	public IList<string> CommonChars(string[] words)
	{
		Dictionary<char, int> main = GetCharCounts(words[0]);

		for (int i = 1; i < words.Length; i++)
		{
			Dictionary<char, int> next = GetCharCounts(words[i]);

			foreach (char key in main.Keys)
			{
				if (next.ContainsKey(key)) 
				{
					main[key] = Math.Min(main[key], next[key]); 
				}
				else 
				{
					main[key] = 0; 
				}
				
			}

		}

		List<string> result = new List<string>();
		foreach (char key in main.Keys)
		{
			for (int i = 0; i < main[key]; i++) 
			{
				result.Add(key.ToString()); 
			}
		} 
		return result; 
	}

	public Dictionary<char, int> GetCharCounts(string word)
	{
		Dictionary<char, int> charCounts = new Dictionary<char, int>();
		foreach (char c in word)
		{
			if (!charCounts.ContainsKey(c)) charCounts.Add(c, 0);

			charCounts[c]++;
		}
		return charCounts;
	}	
	
}


/*
Example 1:

Input: words = ["bella","label","roller"]
Output: ["e","l","l"]
Example 2:

Input: words = ["cool","lock","cook"]
Output: ["c","o"]
*/

[Theory]
[InlineData(new[] {"bella","label","roller"}, new[] {"e","l","l"})]
[InlineData(new[] {"cool","lock","cook"}, new[] {"c","o"})]
void Test(string[] words, string[] expected) 
{
	List<string> result = new Solution().CommonChars(words).ToList();
	Assert.Equal(result.Count, expected.Length);
	foreach(string c in result) 
	{
		Assert.True(expected.Contains(c)); 
	}
	
}