using LeetCode.Solutions.Easy.P01470_ShuffleArray;

namespace LeetCode.Tests.Easy.P01470_ShuffleArray;

[TestFixture]
[Category("Easy")]
public class Tests
{
	[TestCase(new[] { 2, 5, 1, 3, 4, 7 }, 3, new[] { 2, 3, 5, 4, 1, 7 })]
	[TestCase(new[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
	[TestCase(new[] { 1, 1, 2, 2 }, 2, new[] { 1, 2, 1, 2 })]
	public void TestShuffle(int[] nums, int n, int[] expected)
	{
		int[] result = new Solution().Shuffle(nums, n);
		Assert.That(result, Is.EqualTo(expected));
	}

	/*
	Example 1:
	Input: nums = [2,5,1,3,4,7], n = 3
	Output: [2,3,5,4,1,7] 
	Explanation: Since x1=2, x2=5, x3=1, y1=3, y2=4, y3=7 then the answer is [2,3,5,4,1,7].

	Example 2:
	Input: nums = [1,2,3,4,4,3,2,1], n = 4
	Output: [1,4,2,3,3,2,4,1]

	Example 3:
	Input: nums = [1,1,2,2], n = 2
	Output: [1,2,1,2]

	*/

}