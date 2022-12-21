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
	private Dictionary<int, int> _numValues;
	private Dictionary<int, int> _maxPoints;

	public Solution()
	{
		_numValues = new Dictionary<int, int>();
		_maxPoints = new Dictionary<int, int>();
	}

	public int DeleteAndEarn(int[] nums)
	{
		int maxValue = int.MinValue;

		foreach (int num in nums)
		{
			if (num > maxValue) maxValue = num;

			if (!_numValues.ContainsKey(num))
			{
				_numValues.Add(num, 0);
			}
			_numValues[num] += num;
		}

		if (_numValues.Keys.Count == 1)
		{
			return _numValues[maxValue];
		}

		return MaxPoints(maxValue);
	}

	private int MaxPoints(int value)
	{
		if (value == 0) return 0;
		if (value == 1)
		{
			return _numValues.ContainsKey(1) ? _numValues[1] : 0;
		}
		
		if (_maxPoints.ContainsKey(value))
		{
			return _maxPoints[value];
		}
		else
		{
			int currentValue = _numValues.ContainsKey(value) ? _numValues[value] : 0;
			int maxPoints = Math.Max(MaxPoints(value - 2) + currentValue, MaxPoints(value - 1));
			_maxPoints.Add(value, maxPoints);
			return maxPoints;
		}

	}
}

#region Tests

[Theory]
[InlineData(new[] { 3, 4, 2 }, 6)]
[InlineData(new[] { 2, 2, 3, 3, 3, 4 }, 9)]
[InlineData(new[] { 1 }, 1)]
[InlineData(new[] { 1, 3 }, 4)]
[InlineData(new[] { 2, 2, 3, 3, 3 }, 9)]
[InlineData(new[] { 1, 1, 1, 2, 4, 5, 5, 5, 6 }, 18)]
void Test(int[] nums, int expected)
{
	int result = new Solution().DeleteAndEarn(nums);
	Assert.Equal(expected, result);
}

/*
Input:
[1,1,1,2,4,5,5,5,6]
Output:
15
Expected:
18

Example 1:
Input: nums = [3,4,2]
Output: 6
Explanation: You can perform the following operations:
- Delete 4 to earn 4 points. Consequently, 3 is also deleted. nums = [2].
- Delete 2 to earn 2 points. nums = [].
You earn a total of 6 points.

Example 2:
Input: nums = [2,2,3,3,3,4]
Output: 9
Explanation: You can perform the following operations:
- Delete a 3 to earn 3 points. All 2's and 4's are also deleted. nums = [3,3].
- Delete a 3 again to earn 3 points. nums = [3].
- Delete a 3 once more to earn 3 points. nums = [].
You earn a total of 9 points.
*/

#endregion