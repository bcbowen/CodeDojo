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
	public int NextGreaterElement(int n)
	{
		if (n < 10)
		{
			return -1;
		}

		if (n < 100)
		{
			int swapped = SwapDigits(n);
			return swapped > n ? swapped : -1;
		}

		return GetNext(n);
	}

	internal int GetNext(int n)
	{
		int[] digits = GetDigits(n);

		for (int i = digits.Length - 1; i > 0; i--)
		{
			if (digits[i] > digits[i - 1])
			{
				int index = i;
				int value = digits[i];
				for (int j = i; j < digits.Length; j++)
				{
					if (digits[j] < value && digits[j] > digits[i - 1]) 
					{
						index = j; 
						value = digits[j];
					}
				}

				int temp = digits[i - 1];
				digits[i - 1] = digits[index];
				digits[index] = temp;
				Array.Sort(digits, i, digits.Length - i);
				return GetValue(digits);
			}

		}

		return -1;
	}

	internal int SwapDigits(int n)
	{
		int[] digits = GetDigits(n);

		return digits[1] * 10 + digits[0];
	}

	internal int GetValue(int[] digits)
	{
		long value = 0;
		long place = 1;
		for (int i = digits.Length - 1; i >= 0; i--)
		{
			value += digits[i] * place;
			place *= 10;
		}
		return value <= int.MaxValue ? (int)value : -1;
	}

	internal int[] GetDigits(int n)
	{
		List<int> digits = new List<int>();

		while (n > 0)
		{
			int digit = n % 10;
			digits.Insert(0, digit);
			n /= 10;
		}
		return digits.ToArray();
	}
}

#region helperTests

[Theory]
[InlineData(21, 12)]
[InlineData(56, 65)]
[InlineData(65, 56)]
void SwapDigitsTest(int n, int expected)
{
	int result = new Solution().SwapDigits(n);
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(21, new[] { 2, 1 })]
[InlineData(56, new[] { 5, 6 })]
[InlineData(65, new[] { 6, 5 })]
[InlineData(65, new[] { 6, 5 })]
void GetDigitsTest(int n, int[] expected)
{
	int[] result = new Solution().GetDigits(n);
	Assert.Equal(expected, result);
}

[Theory]
/**/
[InlineData(new[] { 2, 1 }, 21)]
[InlineData(new[] { 2, 1, 4 }, 214)]
[InlineData(new[] { 2, 1, 4, 7 }, 2147)]
[InlineData(new[] { 2, 1, 4, 7, 9 }, 21479)]
[InlineData(new[] { 2, 1, 4, 7, 4, 8, 3, 6, 4, 7 }, 2147483647)]
[InlineData(new[] { 2, 1, 4, 7, 4, 8, 3, 6, 4, 8 }, -1)]
[InlineData(new[] { 9, 1, 9, 9, 9, 9, 9, 9, 9, 9 }, -1)]
void GetValueTest(int[] digits, int expected)
{
	int result = new Solution().GetValue(digits);
	Assert.Equal(expected, result);
}


#endregion

#region private::Tests

/*
Example 1:

Input: n = 12
Output: 21
Example 2:

Input: n = 21
Output: -1
 
 Input
230241
Output
231024
Expected
230412
 
 Input
1222 2333
Output
12223 332
Expected
12223 233
 
Input:
1999999999
Output:
610065407
Expected:
-1 
*/

[Theory]
[InlineData(1999999999, -1 )]
[InlineData(12222333, 12223233)]
[InlineData(1265, 1526)]
[InlineData(2147483486, -1)]
[InlineData(1265, 1526)]
[InlineData(230241, 230412)]
[InlineData(12, 21)]
[InlineData(21, -1)]
[InlineData(2, -1)]
[InlineData(100, -1)]
[InlineData(231, 312)]
[InlineData(5432, -1)]
[InlineData(5423, 5432)]
/**/
void TestMain(int n, int expected)
{
	int result = new Solution().NextGreaterElement(n);
	Assert.Equal(expected, result);
}


#endregion