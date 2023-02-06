using LeetCode.Solutions.P02389_LongestSubsequenceWithLimitedSum;

namespace LeetCode.Tests.P02389_LongestSubsequenceWithLimitedSum;

public class Tests
{
    
    [TestCase(new[] { 4, 5, 2, 1 }, new[] { 3, 10, 21 }, new[] { 2, 3, 4 })]
    [TestCase(new[] { 2, 3, 4, 5 }, new[] { 1 }, new[] { 0 })]
    [TestCase(new[] { 100000 }, new[] { 100000 }, new[] { 1 })]
    public void TestAnswerQueries(int[] nums, int[] queries, int[] expected)
    {
        int[] result = new Solution().AnswerQueries(nums, queries);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void EdgeTest1()
    {
        int[] nums = { 736411, 184882, 914641, 37925, 214915 };
        int[] queries = { 665450 };
        int[] expected = { 3 };
        int[] result = new Solution().AnswerQueries(nums, queries);
        Assert.AreEqual(expected, result);
    }

}