<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int LongestPalindrome(string s)
{
	Dictionary<char, int> counts = new Dictionary<char, int>();
	foreach (char c in s) 
	{
		if (!counts.ContainsKey(c)) counts.Add(c, 0); 
		
		counts[c]++; 
	}

	bool hasOdd = false;
	int len = 0; 
	foreach(char c in counts.Keys)
	{
		if (counts[c] % 2 == 0) 
		{
			len += counts[c];
		}
		else
		{
			if (!hasOdd) 
			{
				hasOdd = true; 
				len += counts[c]; 
			}
			else 
			{
				len += counts[c] - 1; 
			}
		}
	}
	
	return len;
}

/*

Input: s = "abccccdd"
Output: 7

Input: s = "a"
Output: 1

*/

[Theory]
[InlineData("abccccdd", 7)]
[InlineData("a", 1)]
void Test(string s, int expected) 
{
	int result = LongestPalindrome(s);
	Assert.Equal(expected, result); 
}
