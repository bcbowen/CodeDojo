<Query Kind="Program" />

void Main()
{
	Test(InitNode(new int[] { 1, 2, 3, 4,5 }), InitNode(new int[] {3,4,5}));
	Test(InitNode(new int[] { 1, 2, 3, 4, 5, 6 }), InitNode(new int[] {4,5, 6}));
}

// You can define other methods, fields, classes and namespaces here

private ListNode InitNode(int[] vals) 
{
	ListNode head = new ListNode(vals[0]);
	ListNode current = head;
	for(int i = 1; i < vals.Length; i++) 
	{
		current.next = new ListNode(vals[i]); 
		current = current.next;
	}
	
	return head;
}

private void Test(ListNode head, ListNode expected)
{
	Solution solution = new Solution();
	ListNode result = solution.MiddleNode(head);

	if (expected.val == result.val)
	{
		Console.WriteLine("PASS");
	}
	else
	{
		Console.WriteLine($"FAIL; Expected {expected.val} Got {result.val}");
	}

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
	public ListNode MiddleNode(ListNode head)
	{
		ListNode fast = head;
		ListNode slow = head; 
		int step = 0;

		while (fast != null)
		{
			if (step % 2 == 0)
			{
				if (fast.next != null) 
				{
					slow = slow.next;	
				}
				
			}
			step++; 
			fast = fast.next;			
		}
		
		return slow;
	}

	public ListNode MiddleNodeFirst(ListNode head)
	{
		List<ListNode> list = new List<ListNode>();
		ListNode current = head;
		while (true)
		{
			list.Add(current);
			current = current.next;
			if (current == null) break;
		}

		int index = list.Count / 2;

		return list[index];
	}
}