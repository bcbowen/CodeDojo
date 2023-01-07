using LeetCode.Solutions.P01335_MinDifficultyOfJobSchedule;

namespace LeetCode.Tests.P01335_MinDifficultyOfJobSchedule;

public class Tests
{
    [TestCase(new[] { 6, 5, 4, 3, 2, 1 }, 2, 7)]
    [TestCase(new[] { 9, 9, 9 }, 4, -1)]
    [TestCase(new[] { 1, 1, 1 }, 3, 3)]
    public void Test(int[] jobDifficulty, int d, int expected)
    {
        int result = new Solution().MinDifficulty(jobDifficulty, d);
        Assert.That(result, Is.EqualTo(expected));
    }

}