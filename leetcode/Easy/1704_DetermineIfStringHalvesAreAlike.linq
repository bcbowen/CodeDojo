<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public bool HalvesAreAlike(string s)
{
	return GetVowelCount(s.Substring(0, s.Length / 2)) == GetVowelCount(s.Substring(s.Length / 2));
}

internal int GetVowelCount(string s) 
{
	char[] vowels = new[] {'A', 'E', 'I', 'O', 'U'}; 
	return s.ToUpper().ToCharArray().Count(c => vowels.Contains(c)); 
}

/*
Example 1:
Input: s = "book"
Output: true
Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore, they are alike.

Example 2:
Input: s = "textbook"
Output: false
Explanation: a = "text" and b = "book". a has 1 vowel whereas b has 2. Therefore, they are not alike.
Notice that the vowel o is counted twice.
*/

[Theory] 
[InlineData("book", true)]
[InlineData("textbook", false)]
void Test(string s, bool expected)
{
	bool result = HalvesAreAlike(s); 
	Assert.Equal(expected, result); 
}

