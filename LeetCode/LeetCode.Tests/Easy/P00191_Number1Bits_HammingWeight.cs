using LeetCode.Solutions.Easy.P00191_Number1Bits_HammingWeight;

namespace LeetCode.Tests.Easy.P00191_Number1Bits_HammingWeight;

[TestFixture]
[Category("Easy")]
public class Tests
{

    [TestCase("00000000000000000000000000001011", 3)]
    [TestCase("00000000000000000000000010000000", 1)]
    [TestCase("11111111111111111111111111111101", 31)]
    [TestCase("00000000000000000000000000000001", 1)]
    [TestCase("00000000000000000000000000000010", 1)]
    public void HammingWeightTest(string s, int expected)
    {
        uint n = Convert.ToUInt32(s, 2);
        int result = new Solution().HammingWeight(n);
        Assert.AreEqual(expected, result);
    }
}