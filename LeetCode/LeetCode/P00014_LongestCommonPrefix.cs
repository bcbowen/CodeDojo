using LeetCode.Solutions.P00014_LongestCommonPrefix;

namespace LeetCode.Tests.P00014_LongestCommonPrefix
{
    public class Tests
    {
        [Test]
        [TestCase(new string[] { "flower", "flow", "flight" }, "fl")]
        [TestCase(new string[] { "dog", "racecar", "car" }, "")]
        public void Test(string[] input, string expected)
        {
            string result = new Solution().LongestCommonPrefix(input);
            Assert.AreEqual(expected, result);
        }
    }
}