<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

public string ClearDigits(string s)
{
	StringBuilder sb = new StringBuilder(s);
	while (char.IsDigit(sb[0])) 
	{
		sb.Remove(0, 1); 
	}
	for(int i = 0; i < sb.Length; i++)
	{
		if (char.IsDigit(sb[i]))
		{
			sb.Remove(i - 1, 2);
			i -= 2;
		}
	}
	
	return sb.ToString(); 
}

/*
Example 1:
Input: s = "abc"
Output: "abc"
Explanation:
There is no digit in the string.

Example 2:
Input: s = "cb34"
Output: ""
Explanation:
First, we apply the operation on s[2], and s becomes "c4".
Then we apply the operation on s[1], and s becomes "".
*/

[Theory]
[InlineData("abc", "abc")]
[InlineData("cb34", "")]
[InlineData("34cb", "cb")]
void Test(string s, string expected) 
{
	string result = ClearDigits(s); 
	Assert.Equal(expected, result); 
}

