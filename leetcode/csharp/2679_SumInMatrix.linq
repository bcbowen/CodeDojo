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
	public int MatrixSum(int[][] nums)
	{
		int score = 0;
		List<PriorityQueue<int, int>> numQueues = new List<PriorityQueue<int, int>>();
		foreach(int[] numRow in nums) 
		{
			PriorityQueue<int, int> rowQ = new PriorityQueue<int, int>();

			foreach (int num in numRow) 
			{
				rowQ.Enqueue(num, -num); 
			}
			
			numQueues.Add(rowQ); 
			
		}
		
		PriorityQueue<int, int> scoreQ = new PriorityQueue<int, int>(); 

		for(int i = 0; i < nums[0].Length; i++) 
		{
			scoreQ.Clear();
			for(int j = 0; j < nums.Length; j++) 
			{
				int val = numQueues[j].Dequeue();
				scoreQ.Enqueue(val, -val);
			}
			score += scoreQ.Dequeue();
		}
		
		return score; 
	}
}

/*
Example 1:

Input: nums = [[7,2,1],[6,4,2],[6,5,3],[3,2,1]]
Output: 15
Explanation: In the first operation, we remove 7, 6, 6, and 3. We then add 7 to our score. Next, we remove 2, 4, 5, and 2. We add 5 to our score. Lastly, we remove 1, 2, 3, and 1. We add 3 to our score. Thus, our final score is 7 + 5 + 3 = 15.
Example 2:

Input: nums = [[1]]
Output: 1
Explanation: We remove 1 and add it to the answer. We return 1.

*/
[Theory]
[InlineData(15, new[] { 7, 2, 1 }, new[] { 6, 4, 2 }, new[] { 6, 5, 3 }, new[] { 3, 2,1})]
[InlineData(1, new[] { 1})]
void Test(int expected, params int[][] nums) 
{
	int result = new Solution().MatrixSum(nums); 
	Assert.Equal(expected, result);
}
