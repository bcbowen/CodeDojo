using LeetCode.Solutions.P00002_Add2Numbers;

namespace LeetCode.Tests.P00002_Add2Numbers
{
    public class Tests
    {
        [Test]
        [TestCase(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
        [TestCase(new[] { 0 }, new[] { 0 }, new[] { 0 })]
        [TestCase(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
        public void AddTwoNumbersTest(int[] values1, int[] values2, int[] expected)
        {
            ListNode list1 = ListNode.Init(values1);
            ListNode list2 = ListNode.Init(values2);
            ListNode result = new Solution().AddTwoNumbers(list1, list2);

            if (expected.Length > 0)
            {
                ListNode current = result;
                int i = 0;
                while (current != null)
                {
                    Assert.AreEqual(expected[i++], current.val);
                    current = current.next;
                }
                // i will have been iterated passed the end of the array if the number of nodes match the number of array elements
                Assert.AreEqual(i, expected.Length);
            }
            else
            {
                Assert.Null(result);
            }

        }
    }
}