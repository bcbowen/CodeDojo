using LeetCode.Solutions.P00013_RomanToInt;

namespace LeetCode.Tests.P00013_RomanToInt
{

    /*
    Example 1:

Input: s = "III"
Output: 3
Explanation: III = 3.
Example 2:

Input: s = "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.
Example 3:

Input: s = "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
    */

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