<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class NumArray
{
	private int[] _nums; 

	public NumArray(int[] nums)
	{
		_nums = nums;
	}

	public int SumRange_1(int left, int right)
	{
		int sum = 0;
		for(int i = left; i <= right; i++) 
		{
			sum += _nums[i]; 
		}
		
		return sum;
	}

	public int SumRange(int left, int right)
	{
		int[] sums = new int[_nums.Length];
		int total = 0;
		for(int i = 0; i < _nums.Length; i++) 
		{
			total += _nums[i]; 
			sums[i] = total;
		}
		int result = sums[right] - (left > 0 ? sums[left - 1] : 0);
		return result;
	}
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(left,right);
 */

#region private::Tests

/*
Input
["NumArray", "sumRange", "sumRange", "sumRange"]
[[[-2, 0, 3, -5, 2, -1]], [0, 2], [2, 5], [0, 5]]
Output
[null, 1, -1, -3]

Explanation
NumArray numArray = new NumArray([-2, 0, 3, -5, 2, -1]);
numArray.sumRange(0, 2); // return (-2) + 0 + 3 = 1
numArray.sumRange(2, 5); // return 3 + (-5) + 2 + (-1) = -1
numArray.sumRange(0, 5); // return (-2) + 0 + 3 + (-5) + 2 + (-1) = -3
*/

[Theory]
[InlineData(new[] {-2, 0, 3, -5, 2, -1}, 0, 2, 1)]
[InlineData(new[] {-2, 0, 3, -5, 2, -1}, 2, 5, -1)]
[InlineData(new[] {-2, 0, 3, -5, 2, -1}, 0, 5, -3)]
void SumRangeTests(int[] nums, int start, int end, int expected) 
{
	NumArray n = new NumArray(nums); 
	int result = n.SumRange(start, end); 
	Assert.Equal(expected, result);
}

#endregion