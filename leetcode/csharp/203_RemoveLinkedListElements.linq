<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


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
	public ListNode RemoveElements(ListNode head, int val)
	{
		while (head != null && head.val == val)
		{
			head = head.next;
		}

		if (head == null) return head;

		ListNode current = head;
		while(current != null)
		{
			ListNode peek = current.next;
			while (peek != null && peek.val == val)
			{
				peek = peek.next;
			}
			current.next = peek;
			current = current.next;
		}
		return head;
	}
}

#region private::Tests

/*
Input: head = [1,2,6,3,4,5,6], val = 6
Output: [1,2,3,4,5]

Input: head = [], val = 1
Output: []

Input: head = [7,7,7,7], val = 7
Output: []

*/

[Theory]
[InlineData(new[] { 1, 2, 6, 3, 4, 5, 6 }, 6, new[] { 1, 2, 3, 4, 5 })]
[InlineData(new[] { 1, 2, 6, 3, 4, 5, 6 }, 1, new[] { 2, 6, 3, 4, 5, 6 })]
[InlineData(new int[0], 1, new int[0])]
[InlineData(new[] { 7, 7, 7, 7 }, 7, new int[0])]
void ReverseListTest(int[] head, int value, int[] expected)
{
	ListNode start = ListNode.Init(head);
	ListNode result = new Solution().RemoveElements(start, value);

	if (head.Length > 0)
	{
		ListNode current = result;
		int i = 0;
		while (current != null)
		{
			Assert.Equal(expected[i++], current.val);
			current = current.next;
		}
	}
	else
	{
		Assert.Null(result);
	}

}


#endregion