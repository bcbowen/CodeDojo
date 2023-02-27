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
	public string AddStrings(string x, string y)
	{
		int carry = 0;
		int top;
		int bottom;
		int sum;
		int n = Math.Max(x.Length, y.Length);
		x = x.PadLeft(n, '0');
		y = y.PadLeft(n, '0');
		if (x.Length == 1 || y.Length == 1)
		{
			return (int.Parse(x) + int.Parse(y)).ToString();
		}
		StringBuilder result = new StringBuilder();
		for (int i = x.Length - 1; i >= 0; i--)
		{
			top = int.Parse(x.Substring(i, 1));
			bottom = int.Parse(y.Substring(i, 1));
			sum = top + bottom + carry;
			if (sum > 9)
			{
				carry = 1;
				result.Insert(0, sum - 10);
			}
			else
			{
				carry = 0;
				result.Insert(0, sum);
			}
		}
		if (carry == 1)
		{
			result.Insert(0, carry);
		}
		return result.ToString().TrimStart('0');
	}
}

#region private::Tests

[Theory]
[InlineData("11", "123", "134")]
[InlineData("456", "77", "533")]
[InlineData("0", "0", "0")]
[InlineData("0", "9", "9")]
[InlineData("9", "0", "9")]
[InlineData("4600", "1564", "6164")]
[InlineData("0000", "4600", "4600")]
[InlineData("00000", "4600", "4600")]
[InlineData("000", "4600", "4600")]
//[InlineData("", "", "")]
void Test(string x, string y, string expected)
{
	string result = new Solution().AddStrings(x, y); 
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: num1 = "11", num2 = "123"
Output: "134"

Example 2:
Input: num1 = "456", num2 = "77"
Output: "533"

Example 3:
Input: num1 = "0", num2 = "0"
Output: "0"
*/

#endregion