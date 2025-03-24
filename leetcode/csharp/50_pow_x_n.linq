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
	public double MyPow(double x, int n)
	{
		if (x == 1) return x;
		if (x == -1) return (n % 2) == 0 ? 1 : -1;
		
		long exponent = n;
		if (Math.Abs(exponent) > 10000) 
		{
			if (Math.Abs(x) < .01 || exponent < 0) return 0; 
			if (x >= 1.01) return double.PositiveInfinity;
			if (x <= -1.01) return (n % 2) == 0 ? double.NegativeInfinity : double.PositiveInfinity;
			
		} 
		
		double val = exponent >= 0 ? x : 1/x;
		double result = 1;
		for (int i = 1; i <= Math.Abs(exponent); i++) 
		{
			result *= val;
		}
		
		return result;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(2, 10, 1024)]
[InlineData(2.1, 3, 9.26100)]
[InlineData(2, -2, .25)]
public void Test(double x, int n, double expected) 
{
	double result = new Solution().MyPow(x, n); 
	Assert.Equal(expected, result, 4);
}

[Fact]
public void NegativePowerTest()
{
	double x = 2; 
	int n = -2; 
	double expected = .25;
	double result = new Solution().MyPow(x, n);
	Assert.Equal(expected, result, 4);
}

[Fact]
public void TinyValueHugeExponentTest() 
{
	double x = .00001;
	int n = 2147483647;
	double expected = 0;
	double result = new Solution().MyPow(x, n);
	Assert.Equal(expected, result); 
	
}

[Theory]
[InlineData(1.00001, 123456, 3.43684)]
[InlineData(-1.00001, 447125, -87.46403)]
public void AlmostOneHugeExponentTest(double x, int n, double expected) 
{
	double result = new Solution().MyPow(x, n);
	Assert.Equal(expected, result, 5);
}

[Fact]
public void HugeNegativeExponentAlsoZero()
{
	double x = 2; 
	int n = -2147483648;
	double expected = 0; 
	double result = new Solution().MyPow(x, n); 
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(1, -2147483646, 1)]
[InlineData(1, 2147483647, 1)]
[InlineData(-1, 2147483646, 1)]
[InlineData(-1, 2147483647, -1)]
public void OnesTest(double x, int n, double expected) 
{
	double result = new Solution().MyPow(x, n); 
	Assert.Equal(expected, result);
} 

/*
0.00001
2147483647

Example 1:
Input: x = 2.00000, n = 10
Output: 1024.00000

Example 2:
Input: x = 2.10000, n = 3
Output: 9.26100

Example 3:
Input: x = 2.00000, n = -2
Output: 0.25000
Explanation: 2-2 = 1/22 = 1/4 = 0.25
*/
#endregion