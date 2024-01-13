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

internal List<int> GetValues(ListNode head)
{
	List<int> result = new List<int>();
	if (head != null)
	{
		ListNode current = head;
		while (current != null)
		{
			result.Add(current.val);
			current = current.next;
		}
	}
	return result;
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

    p2Head = partition.next;
	ListNode current; 
	// left of partition
	if (head != partition)
	{
		current = head;
		while (current.val > x && current != partition)
		{
			if (partition.next == null)
			{
				partition.next = current; 
				p2Head = current; 
				current = head = current.next;
				p2Head.next = null;
			}
			else 
			{
				partition.next = current; 
				current = head = current.next; 
				partition.next.next = p2Head; 
				p2Head = partition.next;
			}
		}
		
		while (current != partition)
		{
			if (current.next.val > x) 
			{
				
			}
		}
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

