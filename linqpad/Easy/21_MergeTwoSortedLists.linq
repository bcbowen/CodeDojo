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
	public ListNode MergeTwoLists(ListNode list1, ListNode list2)
	{
		if (list1 == null && list2 == null) return null; 
		if (list1 == null) return list2;
		if (list2 == null) return list1;

		ListNode mergedHead = null;
		ListNode mergedCurrent = null;
		while (list1 != null || list2 != null)
		{
			if (list1 != null && (list2 == null || list1.val <= list2.val))
			{
				if (mergedHead == null)
				{
					mergedHead = new ListNode(list1.val);
					mergedCurrent = mergedHead;
				}
				else 
				{
					mergedCurrent.next = new ListNode(list1.val);
					mergedCurrent = mergedCurrent.next;
				}
				list1 = list1.next;
			}
			else if (list2 != null && (list1 == null || list2.val <= list1.val))
			{
				if (mergedHead == null)
				{
					mergedHead = new ListNode(list2.val);
					mergedCurrent = mergedHead;
				}
				else
				{
					mergedCurrent.next = new ListNode(list2.val);
					mergedCurrent = mergedCurrent.next;
				}
				list2 = list2.next;
			}
		}
		return mergedHead;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Input: list1 = [1,2,4], list2 = [1,3,4]
Output: [1,1,2,3,4,4]
Example 2:

Input: list1 = [], list2 = []
Output: []
Example 3:

Input: list1 = [], list2 = [0]
Output: [0]
*/

[Theory]
[InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
[InlineData(new[] { 1, 2, 4 }, new[] { 5, 6 }, new[] { 1, 2, 4, 5, 6 })]
[InlineData(new[] { 2, 7, 9 }, new[] { 1, 3, 6 }, new[] { 1, 2, 3, 6, 7, 9 })]
[InlineData(new int[0], new[] { 0 }, new[] { 0 })]
[InlineData(new int[0], new int[0], new int[0])]
void MergeTwoListsTest(int[] values1, int[] values2, int[] expected)
{
	ListNode list1 = ListNode.Init(values1);
	ListNode list2 = ListNode.Init(values2);
	ListNode result = new Solution().MergeTwoLists(list1, list2);

	if (expected.Length > 0)
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