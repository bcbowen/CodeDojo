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
	public ListNode(int x)
	{
		val = x;
		next = null;
	}

	public static (ListNode, ListNode) Initialize(int[] listA, int[] listB, int skipA, int skipB)
	{
		//  listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3

		int a = 1;
		int b = 1;
		ListNode ListNodeA = new ListNode(listA[0]);
		ListNode ListNodeB = new ListNode(listB[0]);
		ListNode currentA = ListNodeA;
		while (a < skipA)
		{
			currentA.next = new ListNode(listA[a++]);
			currentA = currentA.next;
		}

		ListNode currentB = ListNodeB;
		while (b < skipB)
		{
			currentB.next = new ListNode(listB[b++]);
			currentB = currentB.next;
		}
		currentA = currentB;

		while (a < listA.Length)
		{
			currentA.next = new ListNode(listA[a++]);
			currentA = currentA.next;
		}

		return (ListNodeA, ListNodeB);
	}
}

public class Solution
{
	public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
	{
		HashSet<ListNode> aNodes = new HashSet<ListNode>();
		ListNode currentA = headA;
		while (currentA != null)
		{
			aNodes.Add(currentA);
			currentA = currentA.next;
		}

		ListNode currentB = headB;
		while (currentB != null)
		{
			if (aNodes.Contains(currentB)) return currentB;
			currentB = currentB.next;
		}

		return null;
	}

	#region private::Tests


	/*
	Input: intersectVal = 8, listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3
	Output: Intersected at '8'
	Explanation: The intersected node's value is 8 (note that this must not be 0 if the two lists intersect).
	From the head of A, it reads as [4,1,8,4,5]. From the head of B, it reads as [5,6,1,8,4,5]. There are 2 nodes before the intersected node in A; There are 3 nodes before the intersected node in B.

	Input: intersectVal = 2, listA = [1,9,1,2,4], listB = [3,2,4], skipA = 3, skipB = 1
	Output: Intersected at '2'
	Explanation: The intersected node's value is 2 (note that this must not be 0 if the two lists intersect).
	From the head of A, it reads as [1,9,1,2,4]. From the head of B, it reads as [3,2,4]. There are 3 nodes before the intersected node in A; There are 1 node before the intersected node in B.


	Input: intersectVal = 0, listA = [2,6,4], listB = [1,5], skipA = 3, skipB = 2
	Output: No intersection
	Explanation: From the head of A, it reads as [2,6,4]. From the head of B, it reads as [1,5]. Since the two lists do not intersect, intersectVal must be 0, while skipA and skipB can be arbitrary values.
	Explanation: The two lists do not intersect, so return null.
	*/

	[Theory]
	[InlineData(new[] { 4, 1, 8, 4, 5 }, new[] { 5, 6, 1, 8, 4, 5 }, 2, 3, 8)]
	[InlineData(new[] { 1, 9, 1, 2, 4 }, new[] { 3, 2, 4 }, 3, 1, 2)]
	[InlineData(new[] { 2, 6, 4 }, new[] { 1, 5 }, 3, 2, null)]
	void TestHasCycle(int[] listA, int[] listB, int skipA, int skipB, int? expected)
	{
		(ListNode nodeA, ListNode nodeB) = ListNode.Initialize(listA, listB, skipA, skipB);
		ListNode result = new Solution().GetIntersectionNode(nodeA, nodeB);
		if (result != null)
		{
			Assert.Equal(expected.Value, result.val);
		}
		else
		{
			Assert.Null(result);
		}

	}
}
#endregion