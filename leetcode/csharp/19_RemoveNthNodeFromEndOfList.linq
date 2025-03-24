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
}

public class Solution
{
	private ListNode RemoveLast(ListNode head) 
	{
		ListNode current = head;
		while (current.next.next != null) 
		{
			current = current.next;
		}
		current.next = null;
		return head;
	}

	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		if (head.next == null) return null;
		
		if (n == 1) return RemoveLast(head);
		
		ListNode current = head;
		ListNode peek = current;
		for(int i = 0; i < n; i++) 
		{
			peek = peek.next;
		}

		// if peek = null we have to remove the first node
		if (peek == null) return head.next;

		while (peek.next != null) 
		{
			current = current.next;
			peek = peek.next;
		}
		
		// remove current.next by pointing to the following node
		current.next = current.next.next;
		
		return head;
	}

	public ListNode RemoveNthFromEndFirst(ListNode head, int n)
	{
		if (head.next == null) return null;

		if (n == 1) return RemoveLast(head);

		int step = 0;
		ListNode first = head;
		ListNode second = head;
		while (first != null)
		{
			first = first.next;
			step++;
			if (step > n + 1)
			{
				second = second.next;
			}
		}
		if (second != head) second.next = second.next.next;
		return head;
	}
}

[Theory]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3, 5 })]
[InlineData(new[] { 1 }, 1, new int[0])]
[InlineData(new[] { 1, 2 }, 1, new[] { 1 })]
[InlineData(new[] { 1, 2 }, 2, new[] { 2 })]
void TestRemoveNodeFromEnd(int[] nodes, int n, int[] expected)
{
	ListNode head = new ListNode(nodes[0]);
	ListNode node = head;
	for (int i = 1; i < nodes.Length; i++)
	{
		node.next = new ListNode(nodes[i]);
		node = node.next;
	}

	ListNode result = new Solution().RemoveNthFromEnd(head, n);
	node = result;
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

/*
[1,2]
2
Output:
[1,2]
Expected:
[2]


Input: head = [1,2,3,4,5], n = 2
Output: [1,2,3,5]
Example 2:

Input: head = [1], n = 1
Output: []
Example 3:

Input: head = [1,2], n = 1
Output: [1]
*/
