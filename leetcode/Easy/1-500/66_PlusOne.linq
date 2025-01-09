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
	public int[] PlusOne(int[] digits)
	{
		bool carry = true;
		
		for (int i = digits.Length - 1; i >= 0; i--)
		{
			if (carry)
			{
				if (digits[i] == 9) 
				{
					digits[i] = 0;
				}
				else
				{
					digits[i]++;
					carry = false;
				}
			}
			if (!carry) break;
		}
		if (carry) 
		{
			int[] digits2 = new int[digits.Length + 1];
			digits2[0] = 1;
			for(int i = 1; i < digits2.Length; i++) 
			{
				digits2[i] = digits[i - 1];
			}
			return digits2;
		}
		else 
		{
			return digits;
		}
		
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Theory]
[InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 4 })]
[InlineData(new[] { 4, 3, 2, 1 }, new[] { 4, 3, 2, 2 })]
[InlineData(new[] { 9 }, new[] { 1, 0 })]
void TestPlusOne(int[] digits, int[] expected)
{
	int[] result = new Solution().PlusOne(digits);
	Assert.Equal(expected, result);
}
/*
Example 1:

Input: digits = [1,2,3]
Output: [1,2,4]
Explanation: The array represents the integer 123.
Incrementing by one gives 123 + 1 = 124.
Thus, the result should be [1,2,4].
Example 2:

Input: digits = [4,3,2,1]
Output: [4,3,2,2]
Explanation: The array represents the integer 4321.
Incrementing by one gives 4321 + 1 = 4322.
Thus, the result should be [4,3,2,2].
Example 3:

Input: digits = [9]
Output: [1,0]
Explanation: The array represents the integer 9.
Incrementing by one gives 9 + 1 = 10.
Thus, the result should be [1,0].
*/
#endregion