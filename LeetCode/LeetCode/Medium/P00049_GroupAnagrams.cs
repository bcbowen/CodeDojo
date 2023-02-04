using LeetCode.Solutions.Medium.P00049_GroupAnagrams;

namespace LeetCode.Tests.Medium.P00049_GroupAnagrams;

[TestFixture]
[Category("Medium")]
public class Tests
{

    [Test]
    public void Test()
    {
        /*
        Example 1:
        Input: strs = ["eat","tea","tan","ate","nat","bat"]
        Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
        */

        string[] strs = new[] { "eat", "tea", "tan", "ate", "nat", "bat" };

        IList<IList<string>> result = new Solution().GroupAnagrams(strs);
        Assert.AreEqual(3, result.Count);
        for (int i = 0; i < result.Count; i++)
        {
            IList<string> row = result[i];
            switch (row.Count)
            {
                case 1:
                    Assert.AreEqual("bat", row[0]);
                    break;
                case 2:
                    Assert.True(row.Contains("nat"));
                    Assert.True(row.Contains("tan"));
                    break;
                case 3:
                    Assert.True(row.Contains("ate"));
                    Assert.True(row.Contains("eat"));
                    Assert.True(row.Contains("tea"));
                    break;
            }
        }

    }

    [Test]
    [TestCase("bad", "abd")]
    [TestCase("sack", "acks")]
    [TestCase("e", "e")]
    public void KeyTest(string value, string expected)
    {
        string result = new Solution().GetKey(value);
        Assert.AreEqual(expected, result);
    }

}