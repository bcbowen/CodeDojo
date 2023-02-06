using LeetCode.Solutions.Models.LinkedList;
using LeetCode.Solutions.Medium.P00142_LinkedListCycle2;

namespace LeetCode.Tests.Medium.P00142_LinkedListCycle2;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    [TestCase(new[] { 3, 2, 0, -4 }, 1, 2)]
    [TestCase(new[] { 1, 2 }, 0, 1)]
    [TestCase(new[] { 1 }, -1, null)]
    [TestCase(new[] { 3, 2, 0, -4 }, -1, null)]
    [TestCase(new[] { 3, 2, 0, -4, 9, 8, 7, 5 }, 3, -4)]
    [TestCase(new int[0], -1, null)]
    public void TestHasCycle(int[] nodes, int pos, int? expected)
    {
        ListNode root = Solution.Initialize(nodes, pos);
        ListNode result = new Solution().DetectCycle(root);
        if (result != null)
        {
            Assert.AreEqual(expected.Value, result.val);
        }
        else
        {
            Assert.Null(result);
        }

    }

}