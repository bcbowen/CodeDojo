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
	public bool HasCycle(ListNode head)
	{
		ListNode fast = head;
		ListNode slow = head;
		int step = 0; 
		while(fast?.next?.next != null) 
		{
			if (step % 2 == 0) fast = fast.next;
			
			fast = fast.next;
			slow = slow.next;
			
			if (fast == slow) return true;
		}
		
		return false;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Input: head = [3,2,0,-4], pos = 1
Output: true

Input: head = [1,2], pos = 0
Output: true

Input: head = [1], pos = -1
Output: false
*/

[Theory]
[InlineData(new[] {3,2,0,-4}, 1, true)]
[InlineData(new[] {1,2}, 0, true)]
[InlineData(new[] {1}, -1, false)]
[InlineData(new[] {3,2,0,-4}, -1, false)]
[InlineData(new[] {3,2,0,-4, 9, 8, 7, 5}, 3, true)]
void TestHasCycle(int[] nodes, int pos, bool expected) 
{
	ListNode root = ListNode.Initialize(nodes, pos); 
	bool result = new Solution().HasCycle(root); 
	Assert.Equal(expected, result);
}

#endregion