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
	private ListNode _root; 
	private int _size;
	Random _rand;
	public Solution(ListNode head)
	{
		_root = head;
		ListNode current = head;
		int size = 1;
		while(current.next != null)
		{
			current = current.next;
			size++; 
		}
		_size = size;
		_rand = new Random();
	}

	public int GetRandom()
	{
		int skip = _rand.Next(0, _size - 1);
		ListNode current = _root;
		while (skip > 0) 
		{
			current = current.next;
			skip--;
		}
		return current.val;
	}
}

#region private::Tests

[Fact]
void Test() 
{
	ListNode node = new ListNode(1); 
	ListNode current; 
	node.next = new ListNode(2); 
	current = node.next; 
	current.next = new ListNode(3); 
	Solution solution = new Solution(node);
	Dictionary<int, int>  counts = new Dictionary<int, int>(); 
	counts.Add(1, 0); 
	counts.Add(2, 0);
	counts.Add(3, 0);
	for (int i = 0; i < 100; i++)
	{
		int val = solution.GetRandom(); 
		counts[val]++;
	}
	Assert.True(Math.Abs(counts[0] - counts[1]) < 5);
	Assert.True(Math.Abs(counts[0] - counts[2]) < 5);
	Assert.True(Math.Abs(counts[1] - counts[2]) < 5);
}

#endregion