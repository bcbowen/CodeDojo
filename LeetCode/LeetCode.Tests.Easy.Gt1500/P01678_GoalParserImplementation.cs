using LeetCode.Solutions.Easy.P01678_GoalParserImplementation;

namespace LeetCode.Tests.Easy.P01678_GoalParserImplementation;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [TestCase("G()(al)", "Goal")]
    [TestCase("G()()()()(al)", "Gooooal")]
    [TestCase("(al)G(al)()()G", "alGalooG")]
    public void Test(string command, string expected)
    {
        string result = new Solution().Interpret(command);
        Assert.That(result, Is.EqualTo(expected));
    }

}