<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int ScoreOfString(string s)
{
	int score = 0;
	for (int i = 1; i < s.Length; i++) 
	{
		score += Math.Abs((int)s[i - 1]-(int)s[i]); 
	}
	return score; 
}

/*

Input: s = "hello"
Output: 13

Input: s = "zaz"
Output: 50
*/

[Theory]
[InlineData("hello", 13)]
[InlineData("zaz", 50)]
void Test(string s, int expected) 
{
	int result = ScoreOfString(s); 
	Assert.Equal(expected, result); 
	
}
