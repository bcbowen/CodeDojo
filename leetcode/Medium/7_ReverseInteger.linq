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
	internal bool OverflowCheck(List<int> digits)
	{
		if (digits.Count < 10) return false;

		int[] maxDigits = { 2, 1, 4, 7, 4, 8, 3, 6, 4, 7 };
		for(int i = 0; i < digits.Count; i++)
		{
			if (digits[i] < maxDigits[i])
			{
				return false;
			}
			else if (digits[i] > maxDigits[i])
			{
				return true;
			}
		}
		return false;
	}
	
	public int Reverse(int x)
	{
		if (x == int.MinValue) return 0; 
		List<int> digits = new List<int>();
		bool isNeg = x < 0; 
		
		x = Math.Abs(x);
		while(x > 0) 
		{
			digits.Add(x % 10); 
			x /= 10;
		}
		
		if (OverflowCheck(digits)) return 0; 
		
		int multiplier = 1;
		int result = 0;
		for (int i = digits.Count - 1; i >= 0; i--)
		{
			int digit = digits[i];
			result += digit * multiplier; 
			multiplier *= 10;
		}
		
		return isNeg ? -result : result;
	}
}

/*
Example 1:
Input: x = 123
Output: 321

Example 2:
Input: x = -123
Output: -321

Example 3:
Input: x = 120
Output: 21


max Value = 2147483647
2147447412
uint max Value = 4294967295
*/

[Theory]
[InlineData(123, 321)]
[InlineData(-123, -321)]
[InlineData(120, 21)]
[InlineData(2147447413, 0)]
[InlineData(2147483647, 0)]
[InlineData(1534236469, 0)]
[InlineData(-2147483648, 0)]
[InlineData(2147483641, 1463847412)]
void Test(int x, int expected) 
{
	int result = new Solution().Reverse(x);
	Assert.Equal(expected, result);
}
