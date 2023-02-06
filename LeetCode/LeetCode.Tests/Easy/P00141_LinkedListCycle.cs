using LeetCode.Solutions.Easy.P00141_LinkedListCycle;
using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Tests.Easy.P00141_LinkedListCycle;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    [TestCase(new[] { 3, 2, 0, -4 }, 1, true)]
    [TestCase(new[] { 1, 2 }, 0, true)]
    [TestCase(new[] { 1 }, -1, false)]
    [TestCase(new[] { 3, 2, 0, -4 }, -1, false)]
    [TestCase(new[] { 3, 2, 0, -4, 9, 8, 7, 5 }, 3, true)]
    public void TestHasCycle(int[] nodes, int pos, bool expected)
    {
        ListNode root = Solution.Initialize(nodes, pos);
        bool result = new Solution().HasCycle(root);
        Assert.AreEqual(expected, result);
    }

}