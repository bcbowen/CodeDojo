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
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}

public class Solution
{
	public ListNode DeleteDuplicates(ListNode head)
	{
		if (head != null)
		{
			ListNode current = head;
			ListNode next = current.next;
			while (next != null)
			{
				while (next != null && current.val == next.val)
				{
					next = next.next;
				}
				
				if (next != null)
				{
					current.next = next;
					current = next;
				}
			}
			current.next = null;
		}

		return head;
	}

	public ListNode DeleteDuplicates_first(ListNode head)
	{
		if (head != null)
		{
			ListNode current = head;
			ListNode last = null;
			while (current != null)
			{
				last = current;
				while (current.val == last.val)
				{
					if (current.next == null)
					{
						last.next = null;
						current = null;
						break; 
					}
					else 
					{
						current = current.next;
					}
					
				}
				if (current != null) 
				{
					last.next = current;
					current = current.next;
				}
			}
		}
		
		return head;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
public void EmptyListReturnsNull() 
{
	ListNode node = null; 
	ListNode result = new Solution().DeleteDuplicates(node);
	Assert.Null(result);
}

[Theory]
[InlineData(new int[] { 1, 1, 2 }, new int[] { 1, 2 })]
[InlineData(new int[] { 1, 1, 2, 3, 3 }, new int[] { 1, 2, 3})]
public void Test(int[] values, int[] expected)
{
	ListNode node = null;
	if (values.Length > 0) 
	{
		node = new ListNode(values[0]);
		ListNode current = node;
		for (int i = 1; i < values.Length; i++) 
		{
			current.next = new ListNode(values[i]);
			current = current.next;
		}
	}
	
	ListNode result = new Solution().DeleteDuplicates(node);

	ListNode resultNode = result;
	for(int i = 0; i < expected.Length; i++) 
	{
		Assert.Equal(resultNode.val, expected[i]);
		resultNode = resultNode.next;
	}
	Assert.Null(resultNode);
}

#endregion