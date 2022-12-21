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
	public bool CloseStrings(string word1, string word2)
	{
		if (word1.Length != word2.Length) return false;
		if (!CheckLetters(word1, word2)) return false;
		
		return false;
	}

	internal static bool CheckLetters(string word1, string word2) 
	{
		HashSet<char> hs1 = new HashSet<char>();
		foreach (char c in word1) 
		{
			if (!hs1.Contains(c)) hs1.Add(c);
		}

		HashSet<char> hs2 = new HashSet<char>();
		foreach (char c in word2) 
		{
			if (!hs2.Contains(c)) hs2.Add(c);
		}
		
		if (hs1.Count != hs2.Count) return false;

		foreach (char c in hs1) 
		{
			if (!hs2.Contains(c)) return false;
		}
		
		return true;
	}

	internal static bool[] CheckString(string word1, string word2)
	{
		bool[] result = new bool[word1.Length];
		for (int i = 0; i < word1.Length; i++)
		{
			result[i] = word1[i] == word2[i];
		}
		return result;
	}

	internal static (bool, string, string) TrySwap1(string word1, string word2) 
	{
		bool swapped = false;
		bool[] stringCheck = CheckString(word1, word2);
		if (stringCheck.Count(c => !c) == 2) 
		{
			int i1 = -1;
			int i2 = -1;
			for (int i = 0; i < stringCheck.Length; i++)
			{
				if (!stringCheck[i])
				{
					if (i1 == -1) 
					{
						i1 = i;
					}
					else 
					{
						i2 = i;
						break;
					}
				}
			}
			if (word1[i1] == word2[i2] && word1[i2] == word2[i1]) 
			{
				StringBuilder sb = new StringBuilder(word1); 
				char c = sb[i1]; 
				sb[i1] = sb[i2]; 
				sb[i2] = c;
				word1 = sb.ToString();
				swapped = true;
			}
		}
		
		return (swapped, word1, word2); 
		
	}

	internal static (bool, string, string) TrySwap2(string word1, string word2)
	{
		bool swapped = false;
		bool[] stringCheck = CheckString(word1, word2);
		
		Dictionary<char, int> chars1 = new Dictionary<char, int>(); 
		Dictionary<char, int> chars2 = new Dictionary<char, int>();

		for (int i = 0; i < stringCheck.Length; i++)
		{
			if (!stringCheck[i])
			{
				if (!chars1.ContainsKey(word1[i])
				{
					chars1.Add(word1[i], 0); 
				}
				chars1[word1[i]]++;

				if (!chars2.ContainsKey(word2[i])
				{
					chars2.Add(word2[i], 0);
				}
				chars2[word2[i]]++;
			}
		}
		
		if (stringCheck.Count(c => !c) == 2)
		{
			int i1 = -1;
			int i2 = -1;
			for (int i = 0; i < stringCheck.Length; i++)
			{
				if (!stringCheck[i])
				{
					if (i1 == -1)
					{
						i1 = i;
					}
					else
					{
						i2 = i;
						break;
					}
				}
			}
			if (word1[i1] == word2[i2] && word1[i2] == word2[i1])
			{
				StringBuilder sb = new StringBuilder(word1);
				char c = sb[i1];
				sb[i1] = sb[i2];
				sb[i2] = c;
				word1 = sb.ToString();
				swapped = true;
			}
		}

		return (swapped, word1, word2);

	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData("abcdef", "abdcef", "abdcef", true)]
[InlineData("bool", "loob", "loob", true)]
[InlineData("abc", "def", "abc", false)]
[InlineData("bool", "goob", "bool", false)]
[InlineData("abcdef", "afcdeb", "afcdeb", true)]
// [InlineData("", "", "", false)]
private void TrySwap1Tests(string word1, string word2, string expectedWord1, bool expected)
{
	(bool result, string outWord1, string outWord2) = Solution.TrySwap1(word1, word2);
	Assert.Equal(expected, result);
	if (expected) 
	{
		Assert.Equal(expectedWord1, outWord1); 
		Assert.Equal(word2, outWord2); 
	}
	
}

[Theory]
[InlineData("aabc", "abc", true)]
[InlineData("cab", "abc", true)]
[InlineData("baccabcbacbabbabccbba", "cab", true)]
[InlineData("cab", "baccabcbacbabbabccbba", true)]
[InlineData("loop", "goob", false)]
[InlineData("crap", "carp", true)]
// [InlineData("", "", false)]
private void CheckLettersTests(string word1, string word2, bool expected)
{
	bool result = Solution.CheckLetters(word1, word2);
	Assert.Equal(expected, result);
}

#endregion