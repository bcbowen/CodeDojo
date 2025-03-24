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

#region private::Tests
[Theory]
[InlineData("a", "b", false)]
[InlineData("aa", "ab", false)]
[InlineData("aa", "aab", true)]
public void Test(string ransomNote, string magazine, bool expected)
{
	bool result = new Solution().CanConstruct(ransomNote, magazine);
	Assert.Equal(expected, result);
}

#endregion