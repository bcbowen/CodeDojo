using LeetCode.Solutions.Medium.P00045_JumpGameII;

namespace LeetCode.Tests.Medium.P00045_JumpGameII;

[Category("Medium")]
[TestFixture]
public partial class Tests
{
    [TestCase(new[] { 2, 3, 1, 1, 4 }, 2)]
    [TestCase(new[] { 2, 3, 0, 1, 4 }, 2)]
    public void JumpTest(int[] nums, int expected) 
    {
        int result = new Solution().Jump(nums);
        Assert.That(result, Is.EqualTo(expected));
    }

}