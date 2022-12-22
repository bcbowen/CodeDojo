using LeetCode.Solutions.P00013_RomanToInt;

namespace LeetCode.Tests.P00013_RomanToInt
{
    public class Tests
    {
        [Test]
        [TestCase("III", 3)]
        [TestCase("LVIII", 58)]
        [TestCase("MCMXCIV", 1994)]
        public void TestPalindromeNumber(string input, int expected)
        {
            int result = new Solution().RomanToInt(input);
            Assert.AreEqual(expected, result);
        }
    }
}