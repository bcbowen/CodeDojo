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

public ListNode ReverseKGroup(ListNode head, int k)
{
	List<ListNode> segments = new List<ListNode>(); 
	ListNode segment;
	ListNode remaining = head;
	do
	{
		(segment, remaining) = GetSegment(remaining, k); 
		segments.Add(segment);

	} while (remaining != null);
	for(int i = 0; i < segments.Count - 1; i++)
	{
		segments[i] = ReverseList(segments[i]); 
	}
	
	int length; 
	ListNode tail;
	(length, tail) = GetListLength(segments[segments.Count - 1]);
	if (length == k) 
	{
		segments[segments.Count - 1] = ReverseList(segments[segments.Count - 1]); 
	}

	head = segments[0];
	for (int i = 1; i < segments.Count; i++)
	{
		(length, tail) = GetListLength(head); 
		tail.next = segments[i]; 
	}
		
	
	return head;
}

internal (int length, ListNode tail) GetListLength(ListNode head) 
{
	int length = 0; 
	if(head == null) return (length, head); 
	ListNode current = head;
	length++;
	while(current.next != null) 
	{
		current = current.next; 
		length++; 
	}
	return (length, current); 
}

internal ListNode ReverseList(ListNode head) 
{
	(int _, ListNode tail) = GetListLength(head);
	ListNode newHead = tail;
	while (head != newHead) 
	{
		ListNode current = head; 
		head = head.next;
		current.next = newHead.next; 
		newHead.next = current;
	}
	
	return head;
}

internal (ListNode segment, ListNode remaining) GetSegment(ListNode head, int segmentLength) 
{
	int count = 1; 
	ListNode remaining = head.next;
	ListNode tail = head;
	while (count < segmentLength && remaining != null) 
	{
		remaining = remaining.next; 
		tail = tail.next; 
		count++; 
	}
	tail.next = null; 
	return (head, remaining); 
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

/*

Input: head = [1,2,3,4,5], k = 2
Output: [2,1,4,3,5]

Input: head = [1,2,3,4,5], k = 3
Output: [3,2,1,4,5]
*/
[Theory]
[InlineData(new[] {1,2,3,4,5 },2 , new[] {2,1,4,3,5})]
[InlineData(new[] { 1,2,3,4,5},3 , new[] {3,2,1,4,5})]
void Test(int[] listValues, int k, int[] expectedValues) 
{
	ListNode head = BuildList(listValues); 
	ListNode result = ReverseKGroup(head, k);
	int[] resultValues = GetValues(result).ToArray();
	Assert.Equal(expectedValues, resultValues); 
}

[Theory]
[InlineData(new[] {1}, new[] {1})]
[InlineData(new[] {1, 2}, new[] {2, 1})]
[InlineData(new[] {1, 2, 3, 4, 5}, new[] {5, 4, 3, 2, 1})]
[InlineData(new[] {1, 2, 3, 4, 5, 6}, new[] {6, 5, 4, 3, 2, 1})]
[InlineData(new int[0], new int[0])]
void ReverseListTest(int[] listValues, int[] expectedValues)
{
	ListNode head = BuildList(listValues); 
	ListNode reversedList = ReverseList(head); 
	int[] reversedValues = GetValues(reversedList).ToArray(); 
	Assert.Equal(expectedValues, reversedValues); 
}

[Theory]
[InlineData(new[] {1, 2, 3, 4, 5}, 2, 3)]
[InlineData(new[] {1, 2, 3, 4, 5}, 3, 4)]
[InlineData(new[] {1, 2, 3}, 2, 3)]
[InlineData(new[] {1, 2, 3}, 3, -1)]
[InlineData(new[] {1, 2}, 3, -1)]
void GetSegmentTest(int[] values, int k, int newHeadValue)
{
	ListNode head = BuildList(values); 
	(ListNode segment, ListNode remaining) = GetSegment(head, k);

	if (newHeadValue == -1) 
	{
		Assert.Null(remaining);
	}
	else 
	{
		Assert.Equal(newHeadValue, remaining.val); 
		(int length, ListNode _) = GetListLength(segment); 
		Assert.Equal(k, length); 
	}
}
