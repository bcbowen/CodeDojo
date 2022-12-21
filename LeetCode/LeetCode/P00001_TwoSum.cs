using LeetCode.Solutions.P00001_TwoSum;

namespace LeetCode.Tests.P00001_TwoSum
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [TestCase(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [TestCase(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        [TestCase(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new[] { 5, 11 })]
        public void Test(int[] nums, int target, int[] expected)
        {
            int[] solution = new Solution().TwoSum(nums, target);
            Assert.That(solution, Is.EqualTo(expected));
        }
    }
}