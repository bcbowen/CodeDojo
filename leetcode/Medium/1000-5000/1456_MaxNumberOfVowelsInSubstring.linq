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
	public int MaxVowels(string s, int k)
	{
		int maxCount; 
		int count = 0; 
		int i = 0;
		int j = 0;
		char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
		if (vowels.Contains(s[i]))
		{
			count++;
		} 
		
		while (j < k - 1) 
		{
			j++; 
			if (vowels.Contains(s[j])) count++; 
		}
		maxCount = count;

		while(j < s.Length - 1) 
		{
			if (vowels.Contains(s[i])) count--; 
			i++; 
			j++; 
			if (vowels.Contains(s[j])) count++;
			maxCount = Math.Max(maxCount, count); 
		}
		
		return maxCount; 
	}
}

/*
Example 1:
Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.

Example 2:
Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.

Example 3:
Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.

*/
[Theory]
[InlineData("abciiidef", 3, 3)]
[InlineData("aeiou", 2, 2)]
[InlineData("leetcode", 3, 2)]
void Test(string s, int k, int expected)
{
	int result = new Solution().MaxVowels(s, k); 
	Assert.Equal(expected, result);
}
