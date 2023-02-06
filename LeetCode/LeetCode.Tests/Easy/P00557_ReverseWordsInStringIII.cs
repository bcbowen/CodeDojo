using LeetCode.Solutions.Easy.P00557_ReverseWordsInStringIII;

namespace LeetCode.Tests.Easy.P00557_ReverseWordsInStringIII;

public class Tests
{
    [TestCase("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
    [TestCase("God Ding", "doG gniD")]
    public void ReverseWordsTest(string s, string expected)
    {
        string result = new Solution().ReverseWords(s);
        Assert.That(result, Is.EqualTo(expected));
    }


}