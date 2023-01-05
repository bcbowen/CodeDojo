using LeetCode.Solutions.P01790_OneStringSwapMakesStringsEqual;

namespace LeetCode.Tests.P01790_OneStringSwapMakesStringsEqual;

public class Tests
{
    [TestCase("bank", "kanb", true)]
    [TestCase("attack", "defend", false)]
    [TestCase("kelb", "kelb", true)]
    public void AreAlmostEqualTests(string s1, string s2, bool expected)
    {
        bool result = new Solution().AreAlmostEqual(s1, s2);
        Assert.That(result, Is.EqualTo(expected));
    }

}