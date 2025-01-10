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
	/*
	We build a table of n rows (1-indexed). We start by writing 0 in the 1st row. Now in every subsequent row, 
	we look at the previous row and replace each occurrence of 0 with 01, and each occurrence of 1 with 10.
	*/
	public int KthGrammar(int n, int k)
	{
		bool curr = false;
		n -= 1;
		while(n > 0)
		{
			int threshold = (int)Math.Pow(2, n - 1);
			if (k > threshold) 
			{
				curr = !curr;
				k -= threshold; 
			}
			n -= 1;
		}
		return curr? 1 : 0;
		
	}
}

#region private::Tests

/*
Example 1:
Input: n = 1, k = 1
Output: 0
Explanation: row 1: 0

Example 2:
Input: n = 2, k = 1
Output: 0
Explanation: 
row 1: 0
row 2: 01

Example 3:
Input: n = 2, k = 2
Output: 1
Explanation: 
row 1: 0
row 2: 01
*/

[Theory]
[InlineData(1, 1, 0)]
[InlineData(2, 1, 0)]
[InlineData(2, 2, 1)]
[InlineData(30, 434991989, 0)]
void Test(int n, int k, int expected) 
{
	int result = new Solution().KthGrammar(n, k); 
	Assert.Equal(expected, result);
}

#endregion