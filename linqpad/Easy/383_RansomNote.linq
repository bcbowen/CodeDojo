<Query Kind="Program" />

void Main()
{
	Test("a", "b", false);
	Test("aa", "ab", false);
	Test("aa", "aab", true);
}

public void Test(string ransomNote, string magazine, bool expected) 
{
	bool result = new Solution().CanConstruct(ransomNote, magazine);
	if (result == expected)
	{
		Console.WriteLine($"PASS note: {ransomNote} mag: {magazine}");
	}
	else
	{
		Console.WriteLine($"FAIL note: {ransomNote} mag: {magazine} expected: {expected}");
	}
}

public class Solution
{
	public bool CanConstruct(string ransomNote, string magazine)
	{
		Dictionary<char, int> letters = new Dictionary<char, int>();
		foreach(char c in magazine)
		{
			if (letters.ContainsKey(c)) 
			{
				letters[c]++;
			}
			else 
			{
				letters.Add(c, 1);
			}
		}

		foreach(char c in ransomNote)
		{
			if (!letters.ContainsKey(c) || letters[c] < 1)
			{
				return false;
			}
			else
			{
				letters[c]--;
			}
		}
		
		return true;
	}
}