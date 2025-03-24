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
	public bool IsAlienSorted(string[] words, string order)
	{
		Dictionary<char, int> dictionary = InitDictionary(order);
		int comparison;
		for (int i = 1; i < words.Length; i++) 
		{
			comparison = Compare(words[i - 1], words[i], dictionary);
			if (comparison > 0) return false;
		}

		return true;
	}

	internal Dictionary<char, int> InitDictionary(string order)
	{
		Dictionary<char, int> dictionary = new Dictionary<char, int>();
		int index = 0;

		foreach (char c in order)
		{
			dictionary.Add(c, index++);
		}
		
		return dictionary;
	}

	internal int Compare(string word1, string word2, Dictionary<char, int> dictionary)
	{
		int i = 0;
		while(i < Math.Min(word1.Length, word2.Length))
		{
			if (word1[i] != word2[i])
			{
				return dictionary[word1[i]] - dictionary[word2[i]];
			}
			i++;
		}
		return word1.Length - word2.Length;
	}
}

/*
Example 1:

Input: words = ["hello","leetcode"], order = "hlabcdefgijkmnopqrstuvwxyz"
Output: true
Explanation: As 'h' comes before 'l' in this language, then the sequence is sorted.
Example 2:

Input: words = ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
Output: false
Explanation: As 'd' comes after 'l' in this language, then words[0] > words[1], hence the sequence is unsorted.
Example 3:

Input: words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"
Output: false

Explanation: The first three characters "app" match, and the second string is shorter (in size.) According to lexicographical rules "apple" > "app", because 'l' > '∅', where '∅' is defined as the blank character which is less than any other character (More info).
*/

[Theory]
[InlineData(new[] {"hello","leetcode"}, "hlabcdefgijkmnopqrstuvwxyz", true)]
[InlineData(new[] {"word","world","row"}, "worldabcefghijkmnpqstuvxyz", false)]
[InlineData(new[] {"apple","app"}, "abcdefghijklmnopqrstuvwxyz", false)]
void TestVerification(string[] words, string alphabet, bool expected)
{
	bool result = new Solution().IsAlienSorted(words, alphabet); 
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("yadda", "yadda", 0)]
[InlineData("yadda", "yad", 1)]
[InlineData("yad", "yadda", -1)]
[InlineData("avocado", "banana", -1)]
[InlineData("zeus", "axle", 1)]
[InlineData("ball", "balls", -1)]
[InlineData("", "a", -1)]
[InlineData("a", "", 1)]
void CompareTests(string word1, string word2, int expected) 
{
	string order = "abcdefghijklmnopqrstuvwxyz";
	Dictionary<char, int> dictionary = new Solution().InitDictionary(order);
	int result = new Solution().Compare(word1, word2, dictionary);
	if (expected == 0)
	{ 
		Assert.Equal(expected, result);
	}
	else if (expected > 0)
	{ 
		Assert.True(result > 0);
	}
	else
	{
		Assert.True(result < 0);
	}
}
