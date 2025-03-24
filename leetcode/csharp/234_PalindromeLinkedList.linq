<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}



/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class ListNode 
{
	public int val { get; set; }
	public ListNode next { get; set; }
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
	internal ListNode ReverseList(ListNode head)
	{
		if (head == null) return head;

		ListNode tail = head;
		ListNode next = head;
		ListNode last = null;
		ListNode current = head;
		while (tail.next != null)
		{
			tail = tail.next;
		}

		while (current != tail)
		{
			next = current.next;
			tail.next = current;
			// first time last will be null, which we want at the end of the reversed list
			current.next = last;
			last = current;
			current = next;
		}

		return current;
	}

	public bool IsPalindrome(ListNode head)
	{
		if (head == null) return false;
		
		ListNode tail = head;
		ListNode mid = head;
		ListNode halfEnd = head;
		int step = 0;
		while (tail.next != null)
		{
			tail = tail.next;
			if (step++ % 2 == 0)
			{
				halfEnd = mid;
				mid = mid.next;
			}
		}

		if (mid == tail) 
		{
			// mid == tail when there are two nodes, so it is a palindrome if both nodes are the same
			return head.val == mid.val;
		}
	
		// reverse mid nodes
		halfEnd.next = ReverseList(mid);
		mid = halfEnd.next;
		
		ListNode front = head; 
		ListNode back = mid;
		bool isPalindrome = true;
		while (front != mid)
		{
			if (front.val != back.val) 
			{
				isPalindrome = false;
				break;
			}
			front = front.next;
			back = back.next;
		}
		
		// restore mid nodes
		halfEnd.next = ReverseList(mid);
		return isPalindrome;
	}

	/*	
	public bool IsPalindrome(ListNode head)
	{
		List<int> list = new List<int>();
		ListNode current = head;
		while (current != null)
		{
			list.Add(current.val);
			current = current.next; 
		}
		
		int l = 0;
		int r = list.Count - 1;
		while (l <= r) 
		{
			if (list[l] != list[r]) return false;
		}
		return true;
	}

	public bool IsPalindromeFirst(ListNode head)
	{
		// this doesn't quite work. ex: odd number nodes wrong
		Stack<int> visited = new Stack<int>(); 
		ListNode fast = head;
		ListNode slow = head;
		int step = 0; 
		while (fast.next != null) 
		{
			fast = fast.next;
			if (step++ % 2 == 0)
			{
				visited.Push(slow.val);	
				slow = slow.next;
			}
		}
		
		while(slow.next != null) 
		{
			if (visited.Count == 0 || (visited.Pop() != slow.next.val))	return false;
			slow = slow.next;
		}
		return true;
	}
	*/
}

#region private::Tests


/*
Input: head = [1,2]
Output: false

Input: head = [1,2,2,1]
Output: true
*/

[Theory]
[InlineData(new[] { 1 }, true)]
[InlineData(new[] { 1, 2 }, false)]
[InlineData(new[] { 1, 1 }, true)]
[InlineData(new[] { 1, 2, 3 }, false)]
[InlineData(new int[0], false)]

[InlineData(new[] { 1, 2, 2, 1 }, true)]
[InlineData(new[] { 1, 2, 3, 2, 1 }, true)]
void IsPalindromeTest(int[] values, bool expected)
{
	ListNode head = ListNode.Init(values);

	bool result = new Solution().IsPalindrome(head);
	Assert.Equal(expected, result);
}

#endregion