using LeetCode.Solutions.Easy.P00160_IntersectionOfTwoLinkedLists;
using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Tests.Easy.P00160_IntersectionOfTwoLinkedLists;

[TestFixture]
[Category("Easy")]
public class Tests
{
    [Test]
    [TestCase(new[] { 4, 1, 8, 4, 5 }, new[] { 5, 6, 1, 8, 4, 5 }, 2, 3, 8)]
    [TestCase(new[] { 1, 9, 1, 2, 4 }, new[] { 3, 2, 4 }, 3, 1, 2)]
    [TestCase(new[] { 2, 6, 4 }, new[] { 1, 5 }, 3, 2, null)]
    public void TestHasCycle(int[] listA, int[] listB, int skipA, int skipB, int? expected)
    {
        (ListNode nodeA, ListNode nodeB) = Solution.Initialize(listA, listB, skipA, skipB);
        ListNode result = new Solution().GetIntersectionNode(nodeA, nodeB);
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