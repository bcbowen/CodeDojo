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
	public ListNode(int x)
	{
		val = x;
		next = null;
	}

	public static ListNode Initialize(int[] nodes, int cycleIndex = -1)
	{
		if (nodes == null || nodes.Length == 0) return null;
		
		ListNode cycleNode = null;
		ListNode root = new ListNode(nodes[0]);
		ListNode current = root;
		for (int i = 0; i < nodes.Length - 1; i++)
		{
			if (i == cycleIndex)
			{
				cycleNode = current;
			}
			current.next = new ListNode(nodes[i + 1]);
			current = current.next;
		}
		current.next = cycleNode;

		return root;
	}
}

public class Solution
{
	public ListNode DetectCycle(ListNode head)
	{
		if (head == null) return head;
		
		ListNode current = head;
		HashSet<ListNode> visited = new HashSet<ListNode>();
		while (current.next != null)
		{
			if (visited.Contains(current)) return current;

			visited.Add(current);
			current = current.next;
		}

		return null;
	}

	/*
	Input: head = [3,2,0,-4], pos = 1
	Output: true

	Input: head = [1,2], pos = 0
	Output: true

	Input: head = [1], pos = -1
	Output: false
	*/

	[Theory]
	[InlineData(new[] { 3, 2, 0, -4 }, 1, 2)]
	[InlineData(new[] { 1, 2 }, 0, 1)]
	[InlineData(new[] { 1 }, -1, null)]
	[InlineData(new[] { 3, 2, 0, -4 }, -1, null)]
	[InlineData(new[] { 3, 2, 0, -4, 9, 8, 7, 5 }, 3, -4)]
	[InlineData(new int[0], -1, null)]
	void TestHasCycle(int[] nodes, int pos, int? expected)
	{
		ListNode root = ListNode.Initialize(nodes, pos);
		ListNode result = new Solution().DetectCycle(root);
		if (result != null)
		{
			Assert.Equal(expected.Value, result.val);
		}
		else
		{
			Assert.Null(result);
		}

	}
}
