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
	public int[] TwoSum(int[] numbers, int target)
	{
		int i = 0; 
		int j = numbers.Length - 1;
		int[] result = new int[2];
		while (i <= j) 
		{
			int sum = numbers[i] + numbers[j];
			if (sum == target) 
			{
				result[0] = i + 1; 
				result[1] = j + 1; 
				break;
			}
			else if (sum < target) 
			{
				i++;
			}
			else 
			{
				j--;
			}	
		}
		
		return result;
		
	}
}

/*
Example 1:

Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
Example 2:

Input: numbers = [2,3,4], target = 6
Output: [1,3]
Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
Example 3:

Input: numbers = [-1,0], target = -1
Output: [1,2]
Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
*/

[Theory]
[InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
[InlineData(new[] { 2, 3, 4 }, 6, new[] { 1, 3 })]
[InlineData(new[] { -1, 0 }, -1, new[] { 1, 2 })]
void TwoSumTest(int[] numbers, int target, int[] expected)
{ 
	int[] result = new Solution().TwoSum(numbers, target);
	Assert.Equal(expected, result);
}
