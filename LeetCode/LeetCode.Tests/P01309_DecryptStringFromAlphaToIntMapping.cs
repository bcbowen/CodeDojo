using LeetCode.Solutions.P01309_DecryptStringFromAlphaToIntMapping;

namespace LeetCode.Tests.P01309_DecryptStringFromAlphaToIntMapping;

public class Tests
{
    [TestCase("10#11#12", "jkab")]
    [TestCase("1326#", "acz")]
    public void DecodeTest(string s, string expected)
    {
        string result = new Solution().FreqAlphabets(s);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void DictionarySmokeTests()
    {
        Dictionary<string, char> lookup = new Solution().LoadDictionary();
        Assert.That(lookup.Keys.Count, Is.EqualTo(26));
    }

    [TestCase("1", 'a')]
    [TestCase("9", 'i')]
    [TestCase("10#", 'j')]
    [TestCase("26#", 'z')]
    public void DictionarySmokeTests(string key, char expected)
    {
        Dictionary<string, char> lookup = new Solution().LoadDictionary();
        char result = lookup[key];
        Assert.That(result, Is.EqualTo(expected));
    }


}