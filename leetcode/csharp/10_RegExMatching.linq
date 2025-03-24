<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  
}

class Solution 
{
	bool?[][] memo; 

	public bool IsMatch(string s, string p) 
	{
		memo = new bool?[s.Length + 1][];
		for (int i = 0; i < memo.Length; i++) 
		{
			memo[i] = new bool?[p.Length + 1];
		}
		return Dp(0, 0, s, p); 
	}

	public bool Dp(int i, int j, string text, string pattern)
	{
		if (memo[i][j] != null)
		{
			return memo[i][j].Value;
		}

		bool ans;
		if (j == pattern.Length)
		{
			ans = i == text.Length;
		}
		else
		{
			bool firstMatch = (i < text.Length && (pattern[j] == text[i] ||
			pattern[j] == '.'));

			if (j + 1 < pattern.Length && pattern[j + 1] == '*') 
			{
				ans = (Dp(i, j + 2, text, pattern) || firstMatch && Dp(i + 1, j, text, pattern));
			}
			else 
			{
				ans = firstMatch && Dp(i + 1, j + 1, text, pattern); 
			}
		}
		
		memo[i][j] = ans;
		return ans; 
	}
	
}


public bool IsMatch1(string s, string p)
{
	int si = 0; 
	int pi = 0;

	Func<int, (int, string)> GetNextToken = (int index) =>
	{
		if (index >= p.Length) return (-1, string.Empty);
		
		if (index < p.Length - 1)
		{
			if (p[index + 1] == '*')
			{
				return (index + 2, p.Substring(index, 2)); 
			}
		}
		
		return (index + 1, p.Substring(index, 1)); 
	}; 

	while (pi < p.Length)
	{
		(int index, string token) = GetNextToken(pi); 
		pi = index;

		if (token.Length == 2)
		{
			// ex: "c*"
			// matches 0 or many characters ('c')
			// if ".*", match zero or more characters to the end of the string
			if (token[0] == '.')
			{
				if (pi > p.Length - 1) 
				{
					return true;
				}
				else 
				{
					char next = p[pi];
					while(si < s.Length && s[si] != next)
					{
						si++; 
					}
					if (si == s.Length) return false; 
				}
			}

			// edge case: we have a * followed by the same character, so we don't want to go all the way to the end
			bool backup = (pi < p.Length && s[si] == p[pi] && s[si] == token[0]);  
			while(si < s.Length && s[si] == token[0]) 
			{
				si++; 
			}
			if (backup) si--; 
			
		}
		else
		{
			if (token == ".") 
			{
				// matches any single character
				si++; 
			}
			else 
			{
				// exact match
				if (si > s.Length - 1 || s[si] != token[0]) return false; 
				si++; 
			}
		}
		
	}
	if (si < s.Length) return false; 
	
	return true; 
}

/*
Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
Example 2:

Input: s = "aa", p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
Example 3:

Input: s = "ab", p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".

"ab"
p = ".*c"
false

s = "aaa"
p = "aaaa"

s = "aaa"
p = "a*a"
true

s = "aaa"
p = "ab*a*c*a"
true

*/

[Theory]
[InlineData("aa", "a", false)]
[InlineData("ab", ".*c", false)]
[InlineData("aaa", ".*aaaa", false)]
[InlineData("aaa", "ab*a*c*a", true)]
[InlineData("abc", ".*c", true)]
[InlineData("aa", "a*", true)]
[InlineData("ab", ".*", true)]
[InlineData("aab", "c*a*b", true)]
[InlineData("aaa", "a*a", true)]
void Test(string s, string p, bool expected) 
{
	bool result = new Solution().IsMatch(s, p); 
	Assert.Equal(expected, result); 
}

