using LeetCode.Solutions.Easy.P01790_OneStringSwapMakesStringsEqual;

namespace LeetCode.Tests.Easy.P01790_OneStringSwapMakesStringsEqual;

[TestFixture]
[Category("Easy")]
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