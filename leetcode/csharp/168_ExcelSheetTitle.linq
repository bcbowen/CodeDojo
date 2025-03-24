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
	public string ConvertToTitle(int n)
	{
		string ans = "";
		while (n > 0)
		{
			n--;
			ans = (char)(n % 26 + 'A') + ans;
			n /= 26;
		}
		return ans;
	}
}

#region private::Tests

[Theory]
[InlineData(1, "A")]
[InlineData(28, "AB")]
[InlineData(701, "ZY")]
[InlineData(2_147_483_647, "FXSHRXW")]
void Test(int col, string expected) 
{
	string result = new Solution().ConvertToTitle(col); 
	Assert.Equal(expected, result);
}

/*

Example 1:
Input: columnNumber = 1
Output: "A"

Example 2:
Input: columnNumber = 28
Output: "AB"

Example 3:
Input: columnNumber = 701
Output: "ZY"

*/
#endregion