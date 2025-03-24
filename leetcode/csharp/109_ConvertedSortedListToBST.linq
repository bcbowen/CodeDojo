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


// Definition for a binary tree node.
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
	{
		this.val = val;
		this.left = left;
		this.right = right;
	}
}

public class Solution
{
	private List<int> _values;

	private void MapListToValues(ListNode node) 
	{
		_values = new List<int>();
		while (node != null) 
		{
			_values.Add(node.val);
			node = node.next;
		}
	}

	internal TreeNode ConvertListToBST(int left, int right) 
	{
		if (left > right) return null; 
		
		int midIndex = (left + right) / 2;
		TreeNode node = new TreeNode(_values[midIndex]);
		
		if (left == right) return node; 
		
		node.left = ConvertListToBST(left, midIndex - 1); 
		node.right = ConvertListToBST(midIndex + 1, right); 
		return node;
	}
	
	public TreeNode SortedListToBST(ListNode head)
	{
		this.MapListToValues(head); 
		if (head == null) return null;
		
		MapListToValues(head);
		
		return ConvertListToBST(0, _values.Count - 1);
		
	}

	internal static void Add(TreeNode root, int value)
	{
		if (value <= root.val)
		{
			if (root.left == null) 
			{
				root.left = new TreeNode(value); 
			}
			else 
			{
				Add(root.left, value);
			}
		}
		else
		{
			if (root.right == null)
			{ 
				root.right = new TreeNode(value);
			}
			else 
			{
				Add(root.right, value);				
			}
		}
		
	}
}

#region private::Tests

[Fact]
void Test1() 
{
	// note: test doesn't pass but solution is accepted... solution isn't deterministic
	ListNode list = new ListNode(-10); 
	ListNode current = list; 
	current.next = new ListNode(-3); 
	current = current.next; 
	current.next = new ListNode(0); 
	current = current.next; 
	current.next = new ListNode(5); 
	current = current.next;
	current.next = new ListNode(9); 
	
	TreeNode result = new Solution().SortedListToBST(list); 
	Assert.Equal(result.val, 0);
	Assert.Equal(result.left.val, -3);
	Assert.Null(result.left.right); 
	Assert.Equal(result.left.left.val, -10); 
	Assert.Equal(result.right.val, 9); 
	Assert.Null(result.right.right); 
	Assert.Equal(result.right.left.val, 5); 
	
}

#endregion