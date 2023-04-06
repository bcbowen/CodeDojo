<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

[Theory]
[InlineData(234, 15)]
[InlineData(4421, 21)]
void SubtractProductAndSumTest(int n, int expected) 
{
	int result = new Solution().SubtractProductAndSum(n); 
	Assert.Equal(expected, result);
}

public class Solution
{
	public int SubtractProductAndSum(int n)
	{
		int sum = SumDigits(n); 
		int product = ProductDigits(n); 
		return product - sum;
	}

	int SumDigits(int val)
	{
		int[] digits = GetDigits(val);
		return digits.Sum(d => d);
	}

	int ProductDigits(int val)
	{
		int[] digits = GetDigits(val);
		int product = 1;
		foreach (int digit in digits)
		{
			product *= digit;
		}
		return product;
	}

	int[] GetDigits(int val)
	{
		List<int> digits = new List<int>();
		while (val > 0)
		{
			digits.Add(val % 10);
			val /= 10;
		}
		digits.Reverse();
		return digits.ToArray();
	}

}
