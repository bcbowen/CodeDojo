<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


/** * Definition for singly-linked list.*/
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
	public ListNode SwapNodes(ListNode head, int k)
	{
		ListNode pre1 = null; 
		ListNode node1 = head; 
		
		
		if (k > 1) 
		{
			int i = 1;
			pre1 = node1;
			while (i < k) 
			{	
				pre1 = pre1.next; 
				node1 = node1.next;
			}
		}

		ListNode pre2 = head;
		ListNode node2 = head;
		ListNode end = node1;
		while (end.next != null) 
		{
			end = end.next;
			pre2 = node2;
			node2 = node2.next;
		}
		
		if (pre1 != null) pre1.next = node2; 
		pre2.next = node1;
		
		ListNode temp = node2.next;
		
		node2.next = node1.next; 
		node1.next = temp;
		
		return head;
	}

	/*
	internal static ListNode Linkify(int[] values)
	{
		ListNode head = new ListNode(values[0]);
		ListNode current = head;
		for (int i = 1; i < values.Length; i++)
		{
			current.next = new ListNode(values[i]);
			current = current.next;
		}

		return head;

	}

	internal static int[] Delinkify(ListNode node)
	{
		List<int> values = new List<int>();
		while (node != null)
		{
			values.Add(node.val);
			node = node.next;
		}

		return values.ToArray();
	}
	*/
}

/*
Input: head = [1,2,3,4,5], k = 2
Output: [1,4,3,2,5]
Example 2:

Input: head = [7,9,6,6,7,8,3,0,9,5], k = 5
Output: [7,9,6,6,8,7,3,0,9,5]
*/

/// <summary>
/// You are given the head of a linked list, and an integer k.
/// Return the head of the linked list after swapping the values of the kth node from the beginning and the kth node from the end (the list is 1 - indexed).
/// </summary>

[Theory]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 4, 3, 2, 5 })] // swap 
[InlineData(new[] { 7, 9, 6, 6, 7, 8, 3, 0, 9, 5 }, 5, new[] { 7, 9, 6, 6, 8, 7, 3, 0, 9, 5 })]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 1, new[] { 5, 2, 3, 4, 1 })]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 3, new[] { 1, 2, 3, 4, 5 })]
void Test(int[] values, int k, int[] expected)
{
	ListNode node = Linkify(values);
	int[] result = Delinkify(new Solution().SwapNodes(node, k));
	Assert.Equal(expected, result);

}

private ListNode Linkify(int[] values)
{
	ListNode head = new ListNode(values[0]);
	ListNode current = head;
	for (int i = 1; i < values.Length; i++)
	{
		current.next = new ListNode(values[i]);
		current = current.next;
	}

	return head;

}

private int[] Delinkify(ListNode node)
{
	List<int> values = new List<int>();
	while (node != null)
	{
		values.Add(node.val);
		node = node.next;
	}

	return values.ToArray();
}

/*
[Fact]
void LinkifyTest()
{
	int[] values = new int[] { 1, 2, 3, 4 };
	ListNode node = Solution.Linkify(values);

	foreach (int value in values)
	{
		Assert.Equal(value, node.val);
		node = node.next;
	}
}

[Fact]
void DelinkifyTest()
{
	ListNode head = new ListNode(1);
	ListNode current = head;
	for (int i = 2; i < 5; i++)
	{
		current.next = new ListNode(i);
		current = current.next;
	}

	int[] expected = new int[] { 1, 2, 3, 4 };
	int[] result = Solution.Delinkify(head);
	Assert.Equal(expected, result);


}
*/
