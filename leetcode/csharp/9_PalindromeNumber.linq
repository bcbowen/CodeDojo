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
	public bool IsPalindrome(int x)
	{
		if (x < 0) return false; 
		if (x < 10) return true;
		int[] digits = GetDigits(x);
		int l = 0;
		int r = digits.Length - 1;
		while (l < r) 
		{
			if (digits[l++] != digits[r--]) return false;
		}
		return true;
	}

	private int[] GetDigits(int i) 
	{
		List<int> digits = new List<int>();
		while (i > 0) 
		{
			digits.Insert(0, i % 10); 
			i /= 10;
		}	
		
		return digits.ToArray();
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

/*
Example 1:

Input: x = 121
Output: true
Explanation: 121 reads as 121 from left to right and from right to left.
Example 2:

Input: x = -121
Output: false
Explanation: From left to right, it reads -121. From right to left, it becomes 121-. Therefore it is not a palindrome.
Example 3:

Input: x = 10
Output: false
Explanation: Reads 01 from right to left. Therefore it is not a palindrome.
*/

[Theory]
[InlineData(121, true)]
[InlineData(-121, false)]
[InlineData(10, false)]
void TestPalindromeNumber(int x, bool expected)
{
	bool result = new Solution().IsPalindrome(x); 
	Assert.Equal(expected, result);
}

#endregion