using LeetCode.Solutions.P00283_MoveZeros;

namespace LeetCode.Tests.P00283_MoveZeros;

public class Tests
{
    [TestCase(new[] { 0,1,0,3,12}, new[] { 1,3,12,0,0})]
    [TestCase(new[] { 0 }, new[] { 0 })]
    public void MoveZerosTest(int[] nums, int[] expected) 
    {
        new Solution().MoveZeroes(nums);
        Assert.That(expected, Is.EqualTo(nums));
    }
    /*


Input: nums = [0]
Output: [0]
    */

}