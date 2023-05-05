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
	public string GcdOfStrings(string str1, string str2)
	{
		int len = 1;
		string gcd = "";
		string maxGcd = ""; 
		while (len <= str1.Length && len <= str2.Length) 
		{
			gcd = str1.Substring(0, len);
			if (CheckGcd(gcd, str1, str2))
			{
				maxGcd = gcd;
			}
			len++;
		}

		return maxGcd;
	}

	

	internal bool CheckGcd(string gcd, string str1, string str2)
	{
		return IsGcd(str1, gcd) && IsGcd(str2, gcd);		
	}

	internal bool IsGcd(string value, string gcd)
	{
		if (string.IsNullOrEmpty(gcd)) return false;
		if (value.Length % gcd.Length != 0) return false;
		
		int i = 0;
		int j = 0;
		while (i < value.Length)
		{
			if (value[i] != gcd[j]) return false;
			i++; 
			j = (j + 1) % gcd.Length;
		}
		
		return true;
	}
}

/*
  Example 1:
  Input: str1 = "ABCABC", str2 = "ABC"
  Output: "ABC"

  Example 2:
  Input: str1 = "ABABAB", str2 = "ABAB"
  Output: "AB"

  Example 3:
  Input: str1 = "LEET", str2 = "CODE"
  Output: ""

  Example 4:
  Input: str1 = "ABABABAB", str2 = "ABAB"
  Output: "ABAB"

  */
[Theory]
[InlineData("ABCABC", "ABC", "ABC")]
[InlineData("ABABAB", "ABAB", "AB")]
[InlineData("LEET", "CODE", "")]
[InlineData("ABABABAB", "ABAB", "ABAB")]
public void Test(string str1, string str2, string expected) 
{
	string result = new Solution().GcdOfStrings(str1, str2); 
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("ADAD", "AD", true)]
[InlineData("ADAG", "AD", false)]
[InlineData("ADAD", "A", false)]
[InlineData("ABCDABCD", "ABCD", true)]
[InlineData("ABCDABCDAB", "ABCD", false)]
public void IsGcdTest(string value, string gcd, bool expected) 
{
	bool result = new Solution().IsGcd(value, gcd); 
	Assert.Equal(expected, result); 
}
