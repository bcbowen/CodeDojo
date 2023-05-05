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
	public int AddDigits(int num)
	{
		int result = 0;
		while(num > 0) 
		{
			result += (num % 10);
			num /= 10; 
			
		}
		if (result < 10) return result; 
		
		return AddDigits(result); 
	}
}

/*

Example 1:
Input: num = 38
Output: 2
Explanation: The process is
38 --> 3 + 8 --> 11
11 --> 1 + 1 --> 2 
Since 2 has only one digit, return it.

Example 2:
Input: num = 0
Output: 0
*/

[Theory]
[InlineData(38, 2)]
[InlineData(0, 0)]
void Test(int num, int expected) 
{
	int result = new Solution().AddDigits(num);
	Assert.Equal(expected, result);
}
