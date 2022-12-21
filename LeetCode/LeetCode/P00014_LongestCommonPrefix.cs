using LeetCode.Solutions.P00014_LongestCommonPrefix;

namespace LeetCode.Tests.P00014_LongestCommonPrefix
{

    /*
void Main()
{
	Test(new string[] { "flower", "flow", "flight"}, "fl");
}

private void Test(string[] values, string expected) 
{
	Solution solution = new Solution();
	string prefix = solution.LongestCommonPrefix(values); 
	
	if (expected == prefix)
	{
		Console.WriteLine("PASS");
	}
	else
	{
		Console.WriteLine($"FAIL; Expected {expected} Got {prefix}");

    Input: strs = ["dog","racecar","car"]
Output: ""
Explanation: There is no common prefix among the input strings.
	}
	
}
    */

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