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
		for(int i = 1; i < values.Length; i++)
		{
			current.next = new ListNode(values[i]); 
			current = current.next;
		}
		
		return head;
	}
}

public class Solution
{
	public ListNode ReverseList(ListNode head)
	{
		if (head == null) return head;
		
		ListNode tail = head;
		ListNode next = head;
		ListNode last = null; 
		ListNode current = head;
		while(tail.next != null) 
		{
			tail = tail.next;
		}

		while (current != tail) 
		{
			next = current.next;
			tail.next = current; 
			// first time last will be null, which we want at the end of the reversed list
			current.next = last;
			last = current;
			current = next;
		}
		
		return current;
	}
}

#region private::Tests


/*

Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]

Input: head = [1,2]
Output: [2,1]

Input: head = []
Output: []

*/

[Theory]
[InlineData(new[] {1,2,3,4,5 }, new[] {5,4,3,2,1})]
[InlineData(new[] {1,2 }, new[] {2,1})]
[InlineData(new int [0], new int [0])]
void ReverseListTest(int[] head, int[] expected) 
{
	ListNode start = ListNode.Init(head);
	ListNode result = new Solution().ReverseList(start);

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