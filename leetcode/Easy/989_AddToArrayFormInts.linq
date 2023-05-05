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
	public IList<int> AddToArrayForm(int[] num, int k)
	{
		// count digits in k
		int n = 0;
		int k2 = k;
		while(k2 > 0) 
		{
			k2 /= 10;
			n++;
		}
		
		List<int> result = new List<int>();
		
		int i;
		// start with zeros for result, with one extra in case we carry
		for(i = 0; i < Math.Max(num.Length, n) + 1; i++) 
		{
			result.Add(0);
		}
		
		bool carry = false;

		int val;
		int sum;
		i = num.Length - 1;
		int j = result.Count - 1;
		while (k > 0 || i >= 0)
		{
			val = k % 10;
			sum = (i >= 0 ? num[i] : 0) + val + (carry ? 1 : 0);
			carry = sum > 9;
			result[j] = sum % 10;
			i--;
			j--;
			k /= 10;

		}
		if (carry)
		{
			result[j] = 1;
			carry = false;
		}

		if (result[0] == 0) result.RemoveAt(0);
		return result;
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 1, 2, 0, 0 }, 34, new[] { 1, 2, 3, 4 })]
[InlineData(new[] { 2, 7, 4 }, 181, new[] { 4, 5, 5 })]
[InlineData(new[] { 2, 1, 5 }, 806, new[] { 1, 0, 2, 1 })]
[InlineData(new[] { 2, 1 }, 999, new[] { 1, 0, 2, 0 })]
void Test(int[] num, int k, int[] expected)
{
	IList<int> result = new Solution().AddToArrayForm(num, k);
	Assert.Equal(expected, result);
}

/*
Example 1:
Input: num = [1,2,0,0], k = 34
Output: [1,2,3,4]
Explanation: 1200 + 34 = 1234

Example 2:
Input: num = [2,7,4], k = 181
Output: [4,5,5]
Explanation: 274 + 181 = 455

Example 3:
Input: num = [2,1,5], k = 806
Output: [1,0,2,1]
Explanation: 215 + 806 = 1021
*/

#endregion