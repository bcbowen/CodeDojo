<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int Divide(int dividend, int divisor)
{
	if (dividend > 0 && divisor > 0) 
	{
		return DividePositive(dividend, divisor);
	}
	else if (dividend < 0 && divisor < 0)
	{
		return DivideNegative(dividend, divisor); 
	}
	else 
	{
		return DivideMixed(dividend, divisor); 
	}
}

internal int DivideNegative(int dividend, int divisor)
{
	if (dividend == divisor) return 1;
	if (divisor == -1) return dividend == int.MinValue ? int.MaxValue : Math.Abs(dividend);
	if (dividend > divisor) return 0;

	int product = divisor;
	int answer = 1;
	while (dividend - product <= divisor)
	{
		product += divisor;
		answer++;
	}
	return answer;
}

internal int DividePositive(int dividend, int divisor) 
{
	if (dividend == divisor) return 1;
	if (divisor == 1) return dividend; 
	if (dividend < divisor) return 0;

	int product = divisor;
	int answer = 1;
	while (dividend - product >= divisor)
	{
		product += divisor;
		answer++;
	}

	return answer;
}

internal int DivideMixed(int dividend, int divisor) 
{
	if (divisor == 1) return dividend; 
	if (divisor == -1) return -dividend;

	// make both numbers negative because of int.minvalue -> can't take abs of minvalue 
	// Then switch signs
	if (dividend > 0)
	{
		dividend = -dividend;
	}
	else 
	{
		divisor = -divisor;
	}
	
	if (dividend == divisor) return -1;	
	if (dividend > divisor) return 0;
		
	int product = divisor;
	int answer = 1;
	while (dividend - product <= divisor)
	{
		product += divisor;
		answer++;
	}

	return -answer;
}


/*

Example 1:

Input: dividend = 10, divisor = 3
Output: 3
Explanation: 10/3 = 3.33333.. which is truncated to 3.

Example 2:
Input: dividend = 7, divisor = -3
Output: -2
Explanation: 7/-3 = -2.33333.. which is truncated to -2.

-2147483648
divisor =
-1

-2147483648
divisor = 2
-1,073,741,824

*/

[Theory]
[InlineData(10, 3, 3)]
[InlineData(7, -3, -2)]
[InlineData(8, 4, 2)]
[InlineData(8, 5, 1)]
[InlineData(3, 4, 0)]
[InlineData(-2147483648, -1, 2147483647)]
[InlineData(-2147483648, 2, -1073741824)]
void Test(int dividend, int divisor, int expected) 
{
	int result = Divide(dividend, divisor); 
	Assert.Equal(expected, result); 
}

