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
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		l1 = ReverseList(l1);
		l2 = ReverseList(l2);
		
		bool carry = false;
		int value = l1.val + l2.val;
		if (value >= 10) 
		{
			value -= 10;
			carry = true;
		}
		ListNode resultRoot = new ListNode(value);
		ListNode resultCurrent = resultRoot;
		
		while (l1 != null && l1.next != null || l2 != null && l2.next != null)
		{
			if (l1 != null) l1 = l1.next;
			if (l2 != null) l2 = l2.next;
			value = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + (carry ? 1 : 0);
			if (value >= 10)
			{
				value -= 10;
				carry = true;
			}
			else
			{
				carry = false;
			}
			resultRoot = new ListNode(value);
			resultRoot.next = resultCurrent;
			resultCurrent = resultRoot;
		}
		if (carry)
		{
			resultRoot = new ListNode(1);
			resultRoot.next = resultCurrent;
		}

		return resultRoot;
	}

	internal static ListNode ReverseList(ListNode list)
	{
		if (list == null || list.next == null) return list;

		ListNode tail = FindTail(list);
		ListNode head = list;
		ListNode newTail = head;
		ListNode newHead = head;
		ListNode current = newTail;

		while (newHead != tail)
		{
			newHead = head;
			head = head.next;
			newHead.next = current;
			current = newHead;
		}
		newTail.next = null;
		return newHead;
	}

	internal static ListNode FindTail(ListNode list)
	{
		ListNode current = list;
		while (current.next != null)
		{
			current = current.next;
		}
		return current;
	}

	internal static ListNode InitList(int[] values)
	{
		ListNode root = new ListNode(values[0]);
		ListNode current = root;
		for (int i = 1; i < values.Length; i++)
		{
			current.next = new ListNode(values[i]);
			current = current.next;
		}

		return root;
	}
}

#region private::Tests

[Theory]
[InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 8, 0, 7 })]
[InlineData(new[] { 7, 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 8, 0, 7 })]
[InlineData(new[] { 2, 8 }, new[] { 0 }, new[] { 2, 8 })]
[InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
[InlineData(new[] { 5, 6, 4 }, new[] { 7, 2, 4, 3 }, new[] { 7, 8, 0, 7 })]
[InlineData(new[] { 0 }, new[] { 2, 8 }, new[] { 2, 8 })]
/**/
[InlineData(new[] { 5 }, new[] { 5 }, new[] { 1, 0 })]
[InlineData(new[] { 6, 1, 0, 0 }, new[] { 4, 3, 2, 1 }, new[] { 1, 0, 4, 2, 1 })]
public void AddTest(int[] values1, int[] values2, int[] expected)
{
	ListNode list1 = Solution.InitList(values1);
	ListNode list2 = Solution.InitList(values2);
	ListNode result = new Solution().AddTwoNumbers(list1, list2);

	try
	{
		foreach (int value in expected)
		{
			Assert.Equal(value, result.val);
			result = result.next;
		}
	}
	catch (Xunit.Sdk.EqualException)
	{
		Console.WriteLine($"Assert failed, result: ");
		result.Dump();
		throw;
	}
	
	
}
/*
Input: l1 = [7,2,4,3], l2 = [5,6,4]
Output: [7,8,0,7]
Example 2:

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [8,0,7]
Example 3:

Input: l1 = [0], l2 = [0]
Output: [0]
*/

[Theory]
[InlineData(new[] { 1, 2, 3, 4, 5 })]
[InlineData(new[] { 1, 2, 3, 4 })]
[InlineData(new[] { 1 })]
[InlineData(new[] { 1, 2, 3 })]
[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
[InlineData(new[] { 1, 2 })]
/**/
void ReverseTest(int[] values)
{
	ListNode list = Solution.InitList(values);
	ListNode reversed = Solution.ReverseList(list);
	ListNode tail = Solution.FindTail(reversed);
	Assert.Null(tail.next);
	for (int i = values.Length - 1; i >= 0; i--)
	{
		Assert.Equal(values[i], reversed.val);
		reversed = reversed.next;
	}
}

[Theory]
[InlineData(new[] { 1, 2, 3, 4 }, 4)]
[InlineData(new[] { 1 }, 1)]
[InlineData(new[] { 1, 2, 3 }, 3)]
[InlineData(new[] { 1, 2, 3, 4, 5 }, 5)]
[InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
void FindTailTest(int[] values, int expected)
{
	ListNode list = Solution.InitList(values);
	ListNode tail = Solution.FindTail(list);
	Assert.Equal(expected, tail.val);
}

#endregion