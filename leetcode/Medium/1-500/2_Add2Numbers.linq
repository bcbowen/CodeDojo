<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}

	public static ListNode Init(int[] values)
	{
		if (values.Length == 0) return null;

		ListNode head = new ListNode(values[0]);
		ListNode current = head;
		for (int i = 1; i < values.Length; i++)
		{
			current.next = new ListNode(values[i]);
			current = current.next;
		}

		return head;
	}
}

public class Solution
{
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		ListNode sum = null;
		ListNode current = null;
		int carry = 0;
		int value = 0;
		while (l1 != null || l2 != null)
		{
			value = carry;
			if (l1 != null)
			{
				value += l1.val;
				l1 = l1.next;
			}
			if (l2 != null)
			{
				value += l2.val;
				l2 = l2.next;
			}
			//value = l1.val + l2.val + carry;
			carry = value > 9 ? 1 : 0;
			//sum.val = value % 10;

			if (sum == null)
			{
				sum = new ListNode(value % 10);
				current = sum;
			}
			else
			{
				current.next = new ListNode(value % 10);
				current = current.next;
			}
		}
		if (carry == 1) current.next = new ListNode(carry);
		return sum;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
*/

[Theory]
[InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
[InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
[InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
void AddTwoNumbersTest(int[] values1, int[] values2, int[] expected)
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
			Assert.Equal(expected[i++], current.val);
			current = current.next;
		}
		// i will have been iterated passed the end of the array if the number of nodes match the number of array elements
		Assert.Equal(i, expected.Length);
	}
	else
	{
		Assert.Null(result);
	}

}

#endregion