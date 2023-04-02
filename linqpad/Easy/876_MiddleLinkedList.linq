<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


private ListNode InitNode(int[] vals) 
{
	ListNode head = new ListNode(vals[0]);
	ListNode current = head;
	for(int i = 1; i < vals.Length; i++) 
	{
		current.next = new ListNode(vals[i]); 
		current = current.next;
	}
	
	return head;
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
	public ListNode MiddleNode(ListNode head)
	{
		ListNode fast = head;
		ListNode slow = head; 
		int step = 0;

		while (fast != null)
		{
			if (step % 2 == 0)
			{
				if (fast.next != null) 
				{
					slow = slow.next;	
				}
				
			}
			step++; 
			fast = fast.next;			
		}
		
		return slow;
	}

	public ListNode MiddleNodeFirst(ListNode head)
	{
		List<ListNode> list = new List<ListNode>();
		ListNode current = head;
		while (true)
		{
			list.Add(current);
			current = current.next;
			if (current == null) break;
		}

		int index = list.Count / 2;

		return list[index];
	}
}

public static class LinkedListHelpers
{
	public static ListNode? Init(int[] values)
	{
		if (values == null || values.Length == 0) return null;

		ListNode head = new ListNode(values[0]);
		ListNode current = head;
		for (int i = 1; i < values.Length; i++)
		{
			current.next = new ListNode(values[i]);
			current = current.next;
		}

		return head;
	}

	public static bool ValuesMatch(ListNode head, int[] values)
	{
		if (head == null && values == null) return true;
		if (head == null || values == null) return false;

		ListNode current = head;
		int i = 0;
		while (current != null)
		{
			if (i > values.Length - 1) return false;
			if (current.val != values[i++]) return false;
			current = current.next;
		}
		if (i != values.Length) return false;

		return true;
	}
}

[Theory]
[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5 })]
[InlineData(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 5, 6 })]
public void Test(int[] values, int[] expectedValues)
{
	Solution solution = new Solution();
	ListNode head = LinkedListHelpers.Init(values);
	ListNode result = solution.MiddleNode(head);

	Assert.True(LinkedListHelpers.ValuesMatch(result, expectedValues));

}