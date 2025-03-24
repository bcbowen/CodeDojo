<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


//  Definition for singly-linked list.
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
	public ListNode SwapPairs(ListNode head)
	{
		if (head == null) return head;

		if (head.next != null)
		{
			head = ProcessPair(head);
		}

		return head;
	}

	internal ListNode ProcessPair(ListNode node)
	{
		if (node == null || node.next == null) return node;
		node.next.next = ProcessPair(node.next.next); 
		ListNode newHead = node.next;
		node.next = node.next.next;
		newHead.next = node;
		return newHead;
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 1, 2, 3, 4 }, new[] { 2, 1, 4, 3 })]
[InlineData(new int[0], new int[0])]
[InlineData(new[] { 1 }, new[] { 1 })]
public void Test(int[] nodes, int[] expected)
{
	ListNode head = InitList(nodes);
	ListNode expectedList = InitList(expected);
	ListNode result = new Solution().SwapPairs(head);
	Assert.True(AreEqual(expectedList, result));

}

[Theory]
//[InlineData(null)]
//[InlineData(new int[0])]
[InlineData(new int[] { 1 })]
[InlineData(new int[] { 1, 2, 3 })]
public void InitListTests(int[] values)
{
	ListNode root = InitList(values);
	if (values == null || values.Length == 0)
	{
		Assert.Null(root);
	}
	else
	{
		ListNode current = root;
		foreach (int i in values)
		{
			Assert.Equal(i, current.val);
			current = current.next;
		}
		Assert.Null(current);
	}

}


[Theory]
[InlineData(new[] { 1 }, new[] { 1 }, true)]
[InlineData(new[] { 2 }, new[] { 1 }, false)]
[InlineData(new[] { 1, 2, 3 }, new[] { 1, 2 }, false)]
[InlineData(new[] { 1, 2 }, new[] { 1, 2, 3 }, false)]
[InlineData(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, true)]
[InlineData(new int[0], new[] { 1 }, false)]
[InlineData(new[] { 1 }, new int[0], false)]
[InlineData(new[] { 1 }, null, false)]
[InlineData(null, new[] { 1 }, false)]
public void AreEqualTests(int[] l, int[] r, bool expected)
{
	bool result = AreEqual(InitList(l), InitList(r)); 
	Assert.Equal(expected, result);
}

private ListNode InitList(int[] nodes)
{
	ListNode list = null;
	if (nodes != null && nodes.Length > 0)
	{
		list = new ListNode(nodes[0]);
		ListNode current = list;
		for (int i = 1; i < nodes.Length; i++)
		{
			current.next = new ListNode(nodes[i]);
			current = current.next;
		}
	}

	return list;
}

private bool AreEqual(ListNode l, ListNode r)
{
	if (l == null) return r == null;
	if (r == null) return false;

	ListNode currentL = l;
	ListNode currentR = r;

	while (currentL != null)
	{
		if (currentR == null) return false;
		if (currentL.val != currentR.val) return false;

		currentL = currentL.next;
		currentR = currentR.next;
	}

	if (currentR != null) return false;
	return true;
}

#endregion