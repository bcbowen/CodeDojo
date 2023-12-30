<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  
}

public bool IsMatch(string s, string p)
{
	int si = 0; 
	int pi = 0;

	while (pi < p.Length)
	{
		switch (p[pi]) 
		{
			case '.': 
				si++; 
				break; 
			case '*': 
				char c = s[si]; 
				while(si < s.Length && s[si] == c) si++; 
				break; 
			default: 
				if (s[si] != p[pi]) return false; 
				si++; 
				break; 
		}
		pi++; 
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
*/

[Theory]
[InlineData("aa", "a", false)]
[InlineData("aa", "a*", true)]
[InlineData("ab", ".*", true)]
void Test(string s, string p, bool expected) 
{
	bool result = IsMatch(s, p); 
	Assert.Equal(expected, result); 
}

