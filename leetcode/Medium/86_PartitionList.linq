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

internal ListNode BuildList(int[] values)
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

public ListNode Partition(ListNode head, int x)
{
	ListNode p1Tail; 
	ListNode partition = head;
	ListNode p2Head;

	while(partition != null && partition.val != x) 
	{
		p1Tail = partition; 
		partition = partition.next;
	}
}

/*

Input: head = [1,4,3,2,5,2], x = 3
Output: [1,2,2,4,3,5]
Example 2:

Input: head = [2,1], x = 2
Output: [1,2]
 

*/

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

