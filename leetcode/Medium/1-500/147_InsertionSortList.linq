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

public ListNode InsertionSortList(ListNode head)
{
	ListNode sorted = new ListNode(head.val);
	while (head.next != null)
	{
		head = head.next;
		sorted = Insert(sorted, head.val);
	}

	return sorted;
}

private ListNode Insert(ListNode head, int value)
{
	ListNode node = new ListNode(value);
	ListNode current = head;

	if (value < head.val)
	{
		node.next = head;
		head = node;
	}
	else
	{
		while (current.next != null)
		{
			if (value < current.next.val)
			{
				node.next = current.next;
				current.next = node;
				return head;
			}

			current = current.next;
		}
		current.next = node;
	}
	return head;
}


#region private::Tests

[Theory]
//[InlineData()]
[InlineData(new[] { 1, 2, 3, 4 })]
[InlineData(new[] { -1, 5, 3, 4, 0 })]
[InlineData(new[] { 4, 2, 1, 3 })]
void Test(int[] values)
{
	ListNode result = InsertionSortList(InitList(values));
	Assert.True(IsSorted(result));
	int count = GetNodeCount(result); 
	Assert.Equal(values.Length, count); 
}

[Theory]
[InlineData(new[] { 1, 2, 3, 4 }, true)]
[InlineData(new[] { 4, 1, 2, 3, 4 }, false)]
[InlineData(new[] { 1, 2, 3, 4, 3 }, false)]
[InlineData(new[] { 1, 2, 3, 4, 4 }, true)]
[InlineData(new[] { 1, 1, 2, 3, 4 }, true)]
[InlineData(new[] { 4, 3, 2, 1 }, false)]
void IsSortedTest(int[] values, bool expected)
{
	ListNode head = InitList(values);
	bool result = IsSorted(head);
	Assert.Equal(expected, result);
}

private ListNode InitList(int[] values)
{
	if (values.Length == 0) return null;
	ListNode head = new ListNode(values[0]);
	ListNode node = head;
	for (int i = 1; i < values.Length; i++)
	{
		node.next = new ListNode(values[i]);
		node = node.next;
	}

	return head;
}

[Theory]
[InlineData(new[] {1, 2}, 3)]
[InlineData(new[] { 3 }, 1)]
[InlineData(new[] {1, 3}, 2)]
void InsertTests(int[] values, int value)
{
	ListNode head = InitList(values); 
	head = Insert(head, value); 
	Assert.True(IsSorted(head));
	int count = GetNodeCount(head);
	
	int expectedCount = values.Length + 1; 
	Assert.Equal(expectedCount, count); 
}

private int GetNodeCount(ListNode head) 
{
	ListNode node = head;
	int count = 0;
	while (node != null)
	{
		count++;
		node = node.next;
	}
	return count;
}

private bool IsSorted(ListNode head)
{
	int last = head.val;
	ListNode node = head;
	while (node.next != null)
	{
		node = node.next;
		if (node.val < last) return false;
		last = node.val;
	}
	return true;
}

#endregion