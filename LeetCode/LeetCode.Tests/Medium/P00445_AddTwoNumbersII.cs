using LeetCode.Models.LinkedList;
using LeetCode.Solutions.Medium.P00445_AddTwoNumbersII;

namespace LeetCode.Tests.Medium.P00445_AddTwoNumbersII;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [TestCase(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 8, 0, 7 })]
    [TestCase(new[] { 7, 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 8, 0, 7 })]
    [TestCase(new[] { 2, 8 }, new[] { 0 }, new[] { 2, 8 })]
    [TestCase(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 5, 6, 4 }, new[] { 7, 2, 4, 3 }, new[] { 7, 8, 0, 7 })]
    [TestCase(new[] { 0 }, new[] { 2, 8 }, new[] { 2, 8 })]
    [TestCase(new[] { 5 }, new[] { 5 }, new[] { 1, 0 })]
    [TestCase(new[] { 6, 1, 0, 0 }, new[] { 4, 3, 2, 1 }, new[] { 1, 0, 4, 2, 1 })]
    public void AddTest(int[] values1, int[] values2, int[] expected)
    {
        ListNode list1 = Solution.InitList(values1);
        ListNode list2 = Solution.InitList(values2);
        ListNode result = new Solution().AddTwoNumbers(list1, list2);

        foreach (int value in expected)
        {
            Assert.That(result.val, Is.EqualTo(value));
            result = result.next;
        }



    }
    /*
    Input: l1 = [7,2,4,3], l2 = [5,6,4]
    Output: [7,8,0,7]
    Example 2:

    Input: l1 = [2,4,3], l2 = [5,6,4]
    Output: [8,0,7]
    Example 3:

    Input: l1 = [0], l2 = [0]
    Output: [0]
    */

    [TestCase(new[] { 1, 2, 3, 4, 5 })]
    [TestCase(new[] { 1, 2, 3, 4 })]
    [TestCase(new[] { 1 })]
    [TestCase(new[] { 1, 2, 3 })]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
    [TestCase(new[] { 1, 2 })]
    /**/
    public void ReverseTest(int[] values)
    {
        ListNode list = Solution.InitList(values);
        ListNode reversed = Solution.ReverseList(list);
        ListNode tail = Solution.FindTail(reversed);
        Assert.Null(tail.next);
        for (int i = values.Length - 1; i >= 0; i--)
        {
            Assert.That(reversed.val, Is.EqualTo(values[i]));
            reversed = reversed.next;
        }
    }

    [TestCase(new[] { 1, 2, 3, 4 }, 4)]
    [TestCase(new[] { 1 }, 1)]
    [TestCase(new[] { 1, 2, 3 }, 3)]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, 5)]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
    public void FindTailTest(int[] values, int expected)
    {
        ListNode list = Solution.InitList(values);
        ListNode tail = Solution.FindTail(list);
        Assert.That(tail.val, Is.EqualTo(expected));
    }


}