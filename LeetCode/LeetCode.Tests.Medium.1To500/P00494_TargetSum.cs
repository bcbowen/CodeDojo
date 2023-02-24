using LeetCode.Solutions.Medium.P00494_TargetSum;

namespace LeetCode.Tests.Medium.P00494_TargetSum;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(new[] { 1, 1, 1, 1, 1 }, 3, 5)]
    [TestCase(new[] { 1 }, 1, 1)]
    public void P00494_TargetSumTest(int[] nums, int target, int expected) 
    {
        int result = new Solution().FindTargetSumWays(nums, target);
        Assert.That(result, Is.EqualTo(expected));
    }
}

/*
Example 1:

Input: nums = [1,1,1,1,1], target = 3
Output: 5
Explanation: There are 5 ways to assign symbols to make the sum of nums be target 3.
-1 + 1 + 1 + 1 + 1 = 3
+1 - 1 + 1 + 1 + 1 = 3
+1 + 1 - 1 + 1 + 1 = 3
+1 + 1 + 1 - 1 + 1 = 3
+1 + 1 + 1 + 1 - 1 = 3
Example 2:

Input: nums = [1], target = 1
Output: 1
*/