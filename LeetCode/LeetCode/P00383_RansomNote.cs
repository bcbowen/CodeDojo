using LeetCode.Solutions.P00383_RansomNote;

namespace LeetCode.Tests.P00383_RansomNote;

public class Tests
{
    [TestCase("a", "b", false)]
    [TestCase("aa", "ab", false)]
    [TestCase("aa", "aab", true)]
    public void Test(string ransomNote, string magazine, bool expected)
    {
        bool result = new Solution().CanConstruct(ransomNote, magazine);
        if (result == expected)
        {
            Console.WriteLine($"PASS note: {ransomNote} mag: {magazine}");
        }
        else
        {
            Console.WriteLine($"FAIL note: {ransomNote} mag: {magazine} expected: {expected}");
        }
    }

}