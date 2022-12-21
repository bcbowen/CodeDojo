<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


// Definition for singly-linked list.
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
	public ListNode RotateRight(ListNode head, int k)
	{
		if (head == null || k == 0) return head;
		ListNode tail = head;
		ListNode current = head;
		int len = 1;
		while (tail.next != null)
		{
			tail = tail.next;
			len++; 
		}
		// if k > len, get the mod to find the number to shift
		k = k % len; 
		tail.next = head;

		// ex: 1-2-3-4-5, k = 2
		// 4 will be the new head, current will be 3
		// rotate list 2 to the right by rotating 3 to the left and removing the link from the new tail to the new head
		for (int i = 0; i < (len - k - 1); i++)
		{
			current = current.next;
		}
		ListNode newHead = current.next;
		current.next = null;
		return newHead;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);
/*
Input: head = [1,2,3,4,5], k = 2
Output: [4,5,1,2,3]

Input: head = [0,1,2], k = 4
Output: [2,0,1]

[1,2]
1
Output:
[1,2]
Expected:
[2,1]

*/

[Theory]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 4, 5, 1, 2, 3 })]
[InlineData(new int[0], 1, new int[0])]
[InlineData(new[] { 1, 2 }, 1, new[] { 2, 1 })]
[InlineData(new[] { 0, 1, 2 }, 4, new[] { 2, 0, 1 })]
void TestRotateRight(int[] nodes, int n, int[] expected)
{
	ListNode head = ListNode.Init(nodes);

	ListNode result = new Solution().RotateRight(head, n);
	ListNode node = result;
	int j = 0;
	if (expected.Length == 0)
	{
		Assert.Null(node);
	}
	else
	{
		while (node != null)
		{
			Assert.Equal(expected[j++], node.val);
			node = node.next;
		}
	}

}

#endregion