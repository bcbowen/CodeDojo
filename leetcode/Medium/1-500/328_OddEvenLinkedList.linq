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
	// odd indices first, then even indices
	public ListNode OddEvenList(ListNode head)
	{
		if (head == null) return head; 
		ListNode oddTail = head;
		ListNode tail = head;
		while (oddTail?.next?.next != null)
		{
			oddTail = oddTail.next.next;
		}
		
		tail = oddTail.next;
		
		ListNode current = head;
		ListNode newOddTail = oddTail;
		while (current != oddTail)
		{
			newOddTail.next = current.next;
			current.next = current.next.next;

			newOddTail = newOddTail.next;
			newOddTail.next = tail;
			current = current.next;
		}
		return head;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Input: head = [1,2,3,4,5]
Output: [1,3,5,2,4]

Input: head = [2,1,3,5,6,4,7]
Output: [2,3,6,7,1,5,4]

Input:
[1,2,3,4,5,6,7,8]
Output:
[1,3,5,7,2,6,4,8]
Expected:
[1,3,5,7,2,4,6,8]


*/

[Theory]
[InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 3, 5, 2, 4 })]
[InlineData(new[] { 2, 1, 3, 5, 6, 4, 7 }, new[] { 2, 3, 6, 7, 1, 5, 4 })]
[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new[] { 1, 3, 5, 7, 2, 4, 6, 8 })]
[InlineData(new int[0], new int[0])]
void OddEvenListTest(int[] head, int[] expected)
{
	ListNode start = ListNode.Init(head);
	ListNode result = new Solution().OddEvenList(start);

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