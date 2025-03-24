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
	public int[] AnswerQueries(int[] nums, int[] queries)
	{
		int[] result = new int[queries.Length];
		Array.Sort(nums);
		for (int k = 0; k < queries.Length; k++) 
		{
			int total = queries[k]; 
			int count = 0;
			int currentTotal = nums[0];
			int i = 0;
			int j = 0;
			int maxCount = 0;
			while(i < nums.Length)
			{
				if (nums[i] <= total)
				{
					currentTotal = nums[i];
					count = 1;
					j = i; 
					while (currentTotal <= total && j < nums.Length) 
					{
						j++;
						if (j < nums.Length) 
						{
							currentTotal += nums[j]; 
							if (currentTotal <= total) count++;
						}
					}
					maxCount = Math.Max(count, maxCount);
					i++;
				}
				else 
				{
					i++;
				}
			}
			result[k] = maxCount;
		} 
		return result;
	}
}

[Theory]
[InlineData(new[] {4,5,2,1}, new[] {3,10,21}, new[] {2,3,4})]
[InlineData(new[] {2,3,4,5}, new[] {1}, new[] {0})]
[InlineData(new[] {100000}, new[] {100000}, new[] {1})]
void TestAnswerQueries(int[] nums, int[] queries, int[] expected)
{
	int[] result = new Solution().AnswerQueries(nums, queries); 
	Assert.Equal(expected, result);	
}

[Fact]
void EdgeTest1() 
{
	int[] nums = { 736411, 184882, 914641, 37925, 214915 };
	int[] queries = { 665450 };
	int[] expected = {3};
	int[] result = new Solution().AnswerQueries(nums, queries);
	Assert.Equal(expected, result);
}
/*

Input
[736411,184882,914641,37925,214915]
[331244,273144,118983,118252,305688,718089,665450]
Output
[2,2,1,1,2,2,2]
Expected
[2,2,1,1,2,3,3]

Example 1:

Input: nums = [4,5,2,1], queries = [3,10,21]
Output: [2,3,4]
Explanation: We answer the queries as follows:
- The subsequence [2,1] has a sum less than or equal to 3. It can be proven that 2 is the maximum size of such a subsequence, so answer[0] = 2.
- The subsequence [4,5,1] has a sum less than or equal to 10. It can be proven that 3 is the maximum size of such a subsequence, so answer[1] = 3.
- The subsequence [4,5,2,1] has a sum less than or equal to 21. It can be proven that 4 is the maximum size of such a subsequence, so answer[2] = 4.
Example 2:

Input: nums = [2,3,4,5], queries = [1]
Output: [0]
Explanation: The empty subsequence is the only subsequence that has a sum less than or equal to 1, so answer[0] = 0.
*/
