<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

[Theory]
[InlineData(19, true)]
[InlineData(2, false)]
[InlineData(7, true)]
void IsHappyTest(int n, bool expected) 
{
	bool result = new Solution().IsHappy(n);
	Assert.Equal(expected, result);
}


public class Solution
{
	public bool IsHappy(int n)
	{
		int sumDigits = GetSumDigits(n);
		HashSet<int> seen = new HashSet<int>();
		while (sumDigits != 1)
		{
			if (seen.Contains(sumDigits)) break;
			seen.Add(sumDigits);
			sumDigits = GetSumDigits(sumDigits);
		}

		return sumDigits == 1;
	}

	private int GetSumDigits(int n)
	{
		int sum = 0;
		while (n > 0)
		{
			sum += (int)Math.Pow(n % 10, 2);
			n /= 10;
		}

		return sum;
	}

}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion