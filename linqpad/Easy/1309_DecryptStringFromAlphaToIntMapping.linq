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
	public string FreqAlphabets(string s)
	{
		// 'a': 1; 'i': 9
		// 'j': 10#; 'z': 26#
		// 'a' ASCII: 97
		
		
		Dictionary<string, char> lookup = LoadDictionary();
		
		Stack<char> letters = new Stack<char>();
		int i = s.Length - 1;
		
		while (i >= 0)
		{
			if (s[i] == '#') 
			{
				letters.Push(lookup[s.Substring(i - 2, 3)]);
				i -= 3;
			}
			else
			{
				letters.Push(lookup[s[i].ToString()]);
				i--;
			}
		}

		StringBuilder result = new StringBuilder();
		while(letters.Count > 0) 
		{
			result.Append(letters.Pop());
		}
		return result.ToString();
	}

	internal Dictionary<string, char> LoadDictionary() 
	{
		Dictionary<string, char> lookup = new Dictionary<string, char>();
		
		int val = 1;
		for (int i = 97; i < 106; i++) 
		{
			lookup.Add(val.ToString(), (char)i);
			val++;
		}

		for(int i = 106; i <= 122; i++)
		{
			lookup.Add($"{val}#", (char)i);
			val++;
		}
		
		return lookup;
	}
}

/*
Example 1:

Input: s = "10#11#12"
Output: "jkab"
Explanation: "j" -> "10#" , "k" -> "11#" , "a" -> "1" , "b" -> "2".
Example 2:

Input: s = "1326#"
Output: "acz"
*/

[Theory]
[InlineData("10#11#12", "jkab")]
[InlineData("1326#", "acz")]
void DecodeTest(string s, string expected) 
{
	string result = new Solution().FreqAlphabets(s);
	Assert.Equal(expected, result);
}

[Fact]
void DictionarySmokeTests() 
{
	Dictionary<string, char> lookup = new Solution().LoadDictionary(); 
	Assert.Equal(lookup.Keys.Count, 26);
}

[Theory]
[InlineData("1", 'a')]
[InlineData("9", 'i')]
[InlineData("10#", 'j')]
[InlineData("26#", 'z')]
void DictionarySmokeTests(string key, char expected)
{
	Dictionary<string, char> lookup = new Solution().LoadDictionary();
	char result = lookup[key];
	Assert.Equal(expected, result);
}
