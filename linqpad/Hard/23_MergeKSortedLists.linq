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

public class Solution
{
	public ListNode MergeKLists(ListNode[] lists)
	{
		ListNode merged = null;
		if (lists == null || lists.Length == 0) return merged;

		int min = 10001;
		//int last = 10001; 
		int minIndex = 0;
		bool done = false;
		while (!done)
		{
			min = 10001;
			minIndex = 0;
			for (int i = 0; i < lists.Length; i++)
			{
				if (lists[i] != null && lists[i].val < min)
				{
					min = lists[i].val;
					minIndex = i;
				}
			}
			if (min == 10001)
			{
				done = true;
			}
			else
			{
				if (merged == null)
				{
					merged = new ListNode(min);
				}
				else
				{
					ListNode current = merged;
					while (current.next != null)
					{
						current = current.next;
					}
					current.next = new ListNode(min);
				}
				lists[minIndex] = lists[minIndex].next;
			}

		}

		return merged;
	}
}


/// <summary>
/// Example 2:
/// Input: lists = []
/// Output: []
/// </summary>
[Fact]
void NullListTest()
{
	ListNode[] lists = null;
	ListNode result = new Solution().MergeKLists(lists);
	ListNode expected = null;
	Assert.True(ReferenceEquals(expected, result));
}

/// <summary>
/// Example 3:
/// Input: lists = [[]]
/// Output: []
/// </summary>
[Fact]
void EmptyListTest()
{
	ListNode[] lists = new ListNode[0];
	ListNode result = new Solution().MergeKLists(lists);
	ListNode expected = null;
	Assert.True(ReferenceEquals(expected, result));
}

/// <summary>
/// Example 1:
/// Input: lists = [[1,4,5],[1,3,4],[2,6]]
/// Output: [1,1,2,3,4,4,5,6]
/// Explanation: The linked-lists are:
/// [
/// 	1->4->5,
/// 	1->3->4,
/// 	2->6
/// ]
/// merging them into one sorted list:
/// 1->1->2->3->4->4->5->6
/// </summary>
[Fact]
void NormalListTest()
{
	ListNode list1 = new ListNode(1);
	list1.next = new ListNode(4);
	list1.next.next = new ListNode(5);

	ListNode list2 = new ListNode(1);
	list2.next = new ListNode(3);
	list2.next.next = new ListNode(4);

	ListNode list3 = new ListNode(2);
	list3.next = new ListNode(6);
	ListNode[] lists = new ListNode[]
	{
		list1,
		list2,
		list3
	};

	int[] expected = new int[] { 1, 1, 2, 3, 4, 4, 5, 6 };
	ListNode result = new Solution().MergeKLists(lists);

	foreach (int val in expected)
	{
		Assert.Equal(val, result.val);
		result = result.next;
	}
}

