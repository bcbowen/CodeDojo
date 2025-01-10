<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

#region Nodes
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

#endregion Nodes

#region TreeNodeParser
public static class TreeNodeParser
{
	public static TreeNode Parse(string serialized)
	{
		if (string.IsNullOrEmpty(serialized) || serialized == "[]")
		{
			return null;
		}

		serialized = serialized.Replace("[", "").Replace("]", "");
		string[] nodes = serialized.Split(',');
		TreeNode root = new TreeNode(int.Parse(nodes[0]));
		Queue<TreeNode> nodeQ = new Queue<TreeNode>();
		TreeNode node = root;
		nodeQ.Enqueue(node);
		int index = 1;
		while (nodeQ.Count > 0 && index < nodes.Length)
		{
			node = nodeQ.Dequeue();
			int value;
			if (nodes[index] != "null")
			{
				value = int.Parse(nodes[index]);
				node.left = new TreeNode(value);
				nodeQ.Enqueue(node.left);
			}
			index++;

			if (index >= nodes.Length) break;

			if (nodes[index] != "null")
			{
				value = int.Parse(nodes[index]);
				node.right = new TreeNode(value);
				nodeQ.Enqueue(node.right);
			}
			index++;
		}

		return root;
	}
}
#endregion TreeNodeParser


public class Solution
{
	public bool IsSubPath(ListNode head, TreeNode root)
	{
		if (root == null) return false;

		//if head val, found in tree
		//search path
		if (head.val == root.val)
		{
			if (SearchPath(head, root)) return true;
		}

		//path didn't find
		//now search in left subtree, 
		//if didn't found search in right subtree
		return IsSubPath(head, root.left) || IsSubPath(head, root.right);
	}


	private bool SearchPath(ListNode listNode, TreeNode treeNode)
	{
		//base cases
		//if tree node reched to end,
		//check list node reached to end or node
		if (treeNode == null) return listNode == null;

		//list node reached to end, it meand found 
		if (listNode == null) return true;

		//if treeNode val is not match with list val,
		//return, no need to search further
		if (treeNode.val != listNode.val) return false;

		return SearchPath(listNode.next, treeNode.left)
			|| SearchPath(listNode.next, treeNode.right);
	}

}

/// <summary>
/// The following scenario fails:  
///  [2,2,1]
///  [2,null,2,null,2,null,1]
/// </summary>
public class Solution_1
{
	private ListNode _list;
	public bool IsSubPath(ListNode head, TreeNode root)
	{
		_list = head;
		return Find(head, root);
	}

	private bool Find(ListNode head, TreeNode root)
	{
		if (head == null || root == null) return false;
		if (head.val == root.val)
		{
			if (head.next == null)
			{
				return true;
			}

			head = head.next;
		}
		else
		{
			head = _list;
			if (head.val == root.val)
			{
				head = head.next;
			}
		}


		if (Find(head, root.left)) return true;
		return Find(head, root.right);
	}
}

#region private::Tests

[Theory]
/**/
[InlineData(new[] { 4, 2, 8 }, "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]", true)]
[InlineData(new[] { 1, 4, 2, 6 }, "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]", true)]
[InlineData(new[] { 1, 4, 2, 6, 8 }, "[1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]", false)]
[InlineData(new[] { 1 }, "1", true)]
[InlineData(new[] { 1, 4, 2, 6, 8 }, null, false)]
[InlineData(new[] { 1, 10, 3, 7, 10, 8, 9, 5, 3, 9, 6, 8, 7, 6, 6, 3, 5, 4, 4, 9, 6, 7, 9, 6, 9, 4, 9, 9, 7, 1, 5, 5, 10, 4, 4, 10, 7, 7, 2, 4, 5, 5, 2, 7, 5, 8, 6, 10, 2, 10, 1, 1, 6, 1, 8, 4, 7, 10, 9, 7, 9, 9, 7, 7, 7, 1, 5, 9, 8, 10, 5, 1, 7, 6, 1, 2, 10, 5, 7, 7, 2, 4, 10, 1, 7, 10, 9, 1, 9, 10, 4, 4, 1, 2, 1, 1, 3, 2, 6, 9 }, "[4,null,8,null,5,null,7,null,5,null,2,1,3,null,null,null,6,8,9,null,null,null,3,null,2,null,10,null,7,null,8,3,4,null,null,null,3,5,1,null,null,null,3,1,7,null,null,null,4,7,7,null,null,8,3,null,null,null,6,3,1,null,null,null,1,null,8,null,2,5,5,null,null,1,3,null,null,null,5,null,3,3,5,null,null,null,7,null,10,null,7,null,6,null,8,null,4,null,10,null,6,null,6,9,3,null,null,6,5,null,null,null,5,null,2,null,7,null,5,null,4,8,2,null,null,null,2,null,10,10,8,null,null,null,7,null,2,null,5,8,6,null,null,null,5,null,7,null,3,4,5,null,null,null,4,null,8,null,8,null,8,null,2,null,5,2,9,null,null,null,2,null,3,7,1,null,null,10,1,null,null,null,7,null,6,null,6,null,7,null,7,null,4,4,2,null,null,7,4,null,null,null,7,null,3,7,5,null,null,null,5,null,4,null,9,5,2,null,null,null,4,null,9,null,5,null,5,null,5,null,2,null,5,null,2,null,5,null,7,5,5,null,null,null,6,null,1,null,7,null,3,9,8,null,null,null,4,null,7,4,8,null,null,4,2,null,null,null,3,10,2,null,null,null,7,null,10,null,3,null,1,null,2,null,5,null,9,null,8,null,5,null,9,null,3,null,7,null,10,5,2,null,null,null,2,8,10,null,null,null,4,4,7,null,null,null,5,1,4,null,null,null,10,null,9,null,4,null,9,6,5,null,null,null,7,5,4,null,null,null,8,null,8,4,9,null,null,null,6,9,1,null,null,null,3,3,6,null,null,null,6,null,7,null,2,null,1,null,8,2,9,null,null,null,8,null,3,null,1,9,1,null,null,null,2,null,6,null,1,null,6,3,9,null,null,null,10,null,1,null,9,null,9,null,10,null,2,null,6,null,3,null,7,null,2,null,2,null,2,9,5,null,null,null,5,null,6,null,6,null,2,null,5,7,9,null,null,null,6,10,4,null,null,8,4,null,null,4,2,null,null,4,7,null,null,2,5,null,null,null,4,5,1,null,null,null,3,null,1,10,6,null,null,3,2,null,null,null,6,null,9,null,7,null,5,8,5,null,null,null,5,null,5,10,6,null,null,null,7,null,1,null,6,3,7,null,null,null,9,7,1,null,null,null,7,null,4,null,4,null,9,null,4,null,1,null,10,null,1,10,10,null,null,null,6,null,3,null,1,null,9,null,7,null,6,6,1,null,null,null,9,4,7,null,null,null,3,null,10,null,4,3,3,null,null,null,4,5,10,null,null,null,1,8,10,null,null,null,6,null,9,null,10,null,4,4,9,null,null,null,3,null,3,null,3,null,10,null,10,null,6,8,1,null,null,null,9,7,1,null,null,null,5,null,3,null,10,null,5,null,9,null,5,null,8,null,6,3,2,null,null,null,8,null,8,3,9,null,null,null,9,null,10,3,8,null,null,6,6,null,null,null,6,null,8,null,2,null,9,null,4,null,6,null,4,null,4,null,6,null,9,null,7,null,10,null,1,null,3,null,6,null,7,null,4,null,9,null,1,null,3,8,10,null,null,null,2,null,10,null,4,null,8,null,10,null,7,null,8,5,1,null,null,9,3,null,null,7,8,null,null,null,1,null,1,5,4,null,null,null,1,null,4,5,7,null,null,null,3,null,6,null,6,null,9,null,4,null,1,5,10,null,null,null,3,null,7,null,10,null,8,null,9,2,5,null,null,null,3,null,9,10,6,null,null,null,8,null,7,8,6,null,null,null,6,null,3,null,5,null,4,null,4,null,9,null,6,2,7,null,null,null,9,null,6,1,9,null,null,null,4,null,9,9,9,null,null,null,7,7,1,null,null,null,5,null,5,6,10,null,null,null,4,null,4,10,10,null,null,null,7,2,7,null,null,null,2,null,4,null,5,null,5,10,2,null,null,null,7,9,5,null,null,null,8,null,6,null,10,8,2,null,null,8,10,null,null,null,1,null,1,null,6,5,1,null,null,8,8,null,null,8,4,null,null,null,7,null,10,4,9,null,null,null,7,null,9,null,9,1,7,null,null,4,7,null,null,null,7,null,1,null,5,8,9,null,null,9,8,null,null,9,10,null,null,4,5,null,null,1,1,null,null,null,7,null,6,null,1,null,2,1,10,null,null,2,5,null,null,7,7,null,null,null,7,null,2,null,4,3,10,null,null,null,1,null,7,null,10,7,9,null,null,null,5,4,9,null,null,null,10,6,4,null,null,8,4,null,null,null,1,null,2,null,1,8,1,null,null,null,3,null,2,null,6,null,9,null,2,1,10,null,null,null,5,null,8,2,1,null,null,null,2,3,10,null,null,null,8,null,9,null,5,null,4,null,1,9,10,null,null,4,9,null,null,3,5,null,null,null,6,null,6,9,1,null,null,null,5,null,2,null,2,null,6,null,1,7,9,null,null,null,6,null,8,4,4,null,null,null,2,null,10,null,1,null,2,null,9,null,8,null,2,null,1,10,4,null,null,null,10,null,8,3,2,null,null,null,10,null,3,8,1,null,null,5,3,null,null,null,6,null,8,null,7,2,5,null,null,1,6,null,null,null,8,null,6,null,3,null,8,null,9,null,5,null,2,null,9,null,2,6,10,null,null,7,10,null,null,null,6,null,8,null,7,7,4,null,null,null,3,5,2,null,null,10,4,null,null,null,4,4,3,null,null,null,5,null,1,null,10,null,10,null,5,null,9,null,3,null,8,null,3,null,2,null,4,1,1,null,null,null,7,10,8,null,null,null,9,4,8,null,null,1,2,null,null,9,7,null,null,5,8,null,null,null,9,null,7,null,4,null,4,5,3,null,null,null,2,null,4,3,10,null,null,7,7,null,null,null,2,null,2,8,8,null,null,null,2,null,4,null,5,8,4,null,null,null,9,null,4,null,10,null,4,null,5,null,5,null,1,null,5,null,8,null,5,null,5,null,1,null,10,null,9,null,10,null,2,null,7,5,9,null,null,null,6,4,6,null,null,null,2,null,10,null,1,4,3,null,null,7,8,null,null,null,3,null,3,null,8,null,10,null,6,6,10,null,null,null,1,8,5,null,null,1,3,null,null,null,8,null,9,null,10,null,8,4,9,null,null,10,1,null,null,null,2,null,8,5,2,null,null,8,6,null,null,null,4,null,7,10,1,null,null,null,3,3,3,null,null,null,3,null,5,7,3,null,null,10,9,null,null,null,2,null,8,null,10,null,7,null,10,null,3,9,10,null,null,null,6,4,9,null,null,9,3,null,null,null,7,null,2,null,10,null,10,null,7,null,4,5,7,null,null,9,8,null,null,null,6,3,1,null,null,null,9,null,7,4,4,null,null,null,6,null,1,null,9,null,9,null,3,1,1,null,null,1,8,null,null,null,1,null,2,null,7,4,6,null,null,null,1,null,3,null,8,null,10,null,3,null,10,null,10,null,10,null,10,null,10,null,6,null,7,null,3,null,9,null,7,5,4,null,null,null,5,null,5,1,3,null,null,null,6,3,4,null,null,null,3,2,10,null,null,10,5,null,null,null,5,9,1,null,null,null,8,null,7,null,9,5,3,null,null,null,2,null,7,null,10,null,2,9,4,null,null,null,4,10,10,null,null,null,6,2,6,null,null,null,4,null,5,null,7,null,7,null,2,4,1,null,null,null,7,null,5,8,8,null,null,3,6,null,null,null,1,null,5,null,8,4,6,null,null,null,6,null,9,null,4,null,4,null,3,null,2,6,9,null,null,null,6,6,8,null,null,null,7,null,5,null,5,null,9,4,3,null,null,null,10,4,6,null,null,null,9,null,3,null,10,null,9,null,1,null,6,null,1,null,4,null,5,5,3,null,null,7,8,null,null,null,6,null,6,null,5,9,4,null,null,null,9,null,7,null,7,7,5,null,null,null,7,null,3,8,3,null,null,null,1,5,4,null,null,null,2,null,3,null,4,null,5,5,6,null,null,null,2,null,2,7,9,null,null,9,5,null,null,null,9,null,9,null,8,7,6,null,null,null,2,null,9,null,2,null,7,6,4,null,null,null,1,null,7,null,2,null,7,null,3,9,2,null,null,4,5,null,null,null,3,null,2,null,8,7,8,null,null,7,7,null,null,null,10,null,9,2,7,null,null,6,3,null,null,null,10,null,5,null,7,null,9,null,3,null,1,null,9,null,2,5,2,null,null,null,4,null,8,null,6,10,10,null,null,10,3,null,null,null,3,null,1,null,3,null,8,3,2,null,null,null,5,2,8,null,null,7,5,null,null,7,7,null,null,null,1,6,5,null,null,null,2,null,4,null,7,null,5,null,3,null,7,null,10,null,10,null,7,null,9,null,5,5,5,null,null,null,9,null,4,null,7,null,6,null,2,null,3,null,3,8,10,null,null,null,1,null,3,null,6,null,10,null,8,null,6,4,5,null,null,null,6,null,3,null,3,null,8,1,3,null,null,2,3,null,null,null,7,null,10,null,2,null,10,null,2,null,7,null,10,6,7,null,null,3,4,null,null,6,2,null,null,null,9,null,8,null,7,null,10,null,9,10,1,null,null,null,5,1,10,null,null,10,2,null,null,null,2,5,8,null,null,null,9,8,8,null,null,null,8,null,4,1,3,null,null,null,4,null,4,null,9,null,4,10,7,null,null,10,4,null,null,4,5,null,null,9,2,null,null,3,7,null,null,8,7,null,null,null,5,null,10,null,3,null,8,null,3,null,5,2,9,null,null,null,10,null,3,null,10,null,7,5,1,null,null,2,4,null,null,null,5,null,2,null,6,null,8,null,9,null,10,null,9,null,6,null,2,6,7,null,null,2,7,null,null,null,3,null,6,9,5,null,null,2,6,null,null,null,8,null,4,null,8,null,2,4,9,null,null,4,7,null,null,null,9,null,5,null,3,null,8,null,6,null,5,7,4,null,null,8,7,null,null,null,9,1,2,null,null,null,9,6,7,null,null,null,8,null,6,null,6,4,6,null,null,null,3,null,5,10,4,null,null,null,5,null,8,null,8,null,7,null,10,5,10,null,null,null,10,null,10,null,10,8,2,null,null,5,3,null,null,null,8,6,6,null,null,10,8,null,null,1,8,null,null,null,9,1,6,null,null,7,6,null,null,null,10,5,4,null,null,null,10,5,4,null,null,2,5,null,null,null,4,2,5,null,null,null,3,null,4,2,8,null,null,null,5,null,9,null,3,9,3,null,null,null,5,null,7,null,7,null,5,null,10,null,3,2,7,null,null,3,8,null,null,null,10,2,3,null,null,null,7,3,3,null,null,null,6,null,4,null,8,null,3,null,3,null,1,null,9,10,1,null,null,null,1,null,6,6,5,null,null,6,3,null,null,null,6,null,4,null,2,null,10,null,9,2,5,null,null,null,10,null,10,3,5,null,null,10,6,null,null,1,9,null,null,6,7,null,null,6,5,null,null,null,8,null,8,5,6,null,null,null,6,null,8,null,8,null,4,null,6,null,9,null,2,null,1,null,10,null,9,null,9,null,4,1,6,null,null,null,1,null,3,null,4,10,8,null,null,null,7,null,5,null,10,null,1,null,9,null,9,null,9,1,8,null,null,null,1,null,9,5,1,null,null,7,1,null,null,null,8,null,1,8,6,null,null,2,9,null,null,10,5,null,null,null,2,null,10,null,10,null,9,null,10,null,7,null,7,null,5,null,8,8,2,null,null,null,9,null,10,null,1,null,1,null,1,null,10,6,1,null,null,null,9,null,2,9,9,null,null,null,9,3,8,null,null,null,1,null,10,1,10,null,null,null,8,null,7,null,8,null,8,6,5,null,null,2,5,null,null,null,7,null,1,null,10,null,4,8,5,null,null,5,2,null,null,2,3,null,null,null,6,3,10,null,null,1,8,null,null,null,9,null,8,7,10,null,null,null,10,null,5,10,6,null,null,null,5,null,6,null,5,6,6,null,null,5,8,null,null,null,7,null,8,null,10,1,1,null,null,null,10,1,2,null,null,9,5,null,null,null,7,4,5,null,null,null,10,null,3,null,5,null,8,null,2,null,9,null,9,6,7,null,null,7,1,null,null,null,5,null,2,null,8,5,3,null,null,null,7,null,6,null,6,null,7,null,5,null,1,6,7,null,null,null,6,null,8,null,8,null,5,10,10,null,null,null,10,5,2,null,null,6,5,null,null,8,1,null,null,2,3,null,null,9,3,null,null,10,7,null,null,1,4,null,null,5,10,null,null,null,7,null,6,null,1,null,9,null,8,null,2,10,7,null,null,null,5,3,9,null,null,null,2,null,7,null,3,null,7,null,7,9,2,null,null,null,5,null,6,1,2,null,null,5,10,null,null,6,9,null,null,null,10,9,8,null,null,5,9,null,null,null,10,5,6,null,null,null,10,10,1,null,null,null,7,null,10,null,3,null,2,null,6,9,9,null,null,2,5,null,null,null,1,null,8,null,2,null,4,2,9,null,null,null,10,null,6,null,5,2,3,null,null,null,1,null,7,null,10,6,10,null,null,null,2,5,9,null,null,4,7,null,null,null,2,1,1,null,null,null,9,null,5,7,7,null,null,null,3,null,4,null,10,2,6,null,null,8,6,null,null,1,10,null,null,null,10,4,4,null,null,null,7,null,8,7,5,null,null,null,2,10,6,null,null,3,6,null,null,null,10,null,8,null,8,8,9,null,null,null,7,null,8,null,1,null,5,null,8,null,7,10,6,null,null,null,3,null,5,null,6,9,10,null,null,null,10,null,6,null,2,null,2,null,2,null,9,null,7,null,4,5,9,null,null,null,4,null,4,null,3,null,10,null,3,10,3,null,null,5,7,null,null,null,6,null,3,3,4,null,null,null,7,null,6,null,10,null,5,8,8,null,null,null,4,5,5,null,null,null,2,null,10,null,2,null,1,2,8,null,null,null,5,null,8,null,3,null,4,null,8,null,1,null,5,8,1,null,null,3,9,null,null,null,3,1,1,null,null,5,9,null,null,null,6,null,9,5,6,null,null,null,5,3,5,null,null,null,9,3,1,null,null,3,5,null,null,3,10,null,null,null,10,null,8,null,1,null,7,null,4,null,1,null,7,null,1,null,3,7,9,null,null,1,2,null,null,null,8,3,7,null,null,null,8,null,1,6,6,null,null,null,9,7,4,null,null,6,10,null,null,4,5,null,null,null,1,null,7,null,6,7,3,null,null,null,6,null,9,null,8,2,6,null,null,6,8,null,null,2,7,null,null,null,8,null,8,7,5,null,null,null,4,null,9,5,3,null,null,9,5,null,null,null,5,null,1,null,5,null,6,8,6,null,null,null,5,null,4,null,2,8,5,null,null,null,9,null,5,null,9,null,3,null,5,9,3,null,null,null,2,null,7,null,8,null,8,null,8,null,10,7,2,null,null,null,6,null,2,1,10,null,null,null,6,null,8,null,4,null,6,8,5,null,null,null,3,null,1,null,6,null,6,null,2,null,9,1,9,null,null,null,3,null,7,4,7,null,null,9,6,null,null,7,8,null,null,null,1,5,1,null,null,7,10,null,null,null,6,null,8,3,2,null,null,1,5,null,null,null,8,null,3,null,3,9,1,null,null,null,8,null,1,3,5,null,null,null,9,null,8,3,4,null,null,null,9,null,1,null,3,null,7,null,3,5,1,null,null,null,4,null,1,null,5,null,1,null,3,4,8,null,null,null,1,10,7,null,null,null,1,null,9,null,7,null,3,null,10,6,9,null,null,null,3,6,8,null,null,null,8,null,3,null,4,null,10,null,2,10,7,null,null,5,4,null,null,null,4,2,6,null,null,1,10,null,null,null,4,3,7,null,null,null,4,null,1,null,6,null,10,null,7,4,9,null,null,null,10,9,4,null,null,null,6,5,9,null,null,null,7,1,7,null,null,null,4,null,4,null,4,null,6,4,3,null,null,null,4,null,5,null,10,null,2,null,1,null,1,null,2,null,2,9,4,null,null,null,9,null,9,9,4,null,null,null,5,null,6,null,2,null,3,null,10,9,10,null,null,10,2,null,null,3,9,null,null,null,9,null,10,null,9,null,3,null,1,5,6,null,null,null,6,null,2,null,9,null,3,null,9,9,3,null,null,5,3,null,null,null,2,null,3,null,8,null,2,null,9,null,3,null,4,null,3,null,4,null,8,6,7,null,null,null,6,null,3,null,1,null,9,5,1,null,null,null,2,null,7,4,7,null,null,null,2,null,9,null,7,null,10,null,6,null,7,null,1,null,4,null,5,null,2,null,7,null,3,null,7,null,4,null,5,null,10,null,1,null,9,9,8,null,null,10,10,null,null,null,6,6,10,null,null,10,4,null,null,4,6,null,null,null,4,null,3,null,5,4,8,null,null,null,5,6,3,null,null,1,7,null,null,9,4,null,null,null,9,10,2,null,null,null,5,null,6,2,5,null,null,null,10,5,1,null,null,null,8,2,2,null,null,7,6,null,null,null,9,null,4,null,4,null,2,null,4,null,8,1,10,null,null,null,8,null,3,null,1,null,5,null,2,null,9,8,5,null,null,8,6,null,null,null,1,null,6,null,2,2,9,null,null,null,9,5,7,null,null,null,4,null,5,4,5,null,null,1,1,null,null,8,3,null,null,null,10,7,10,null,null,6,5,null,null,6,3,null,null,4,1,null,null,10,1,null,null,4,2,null,null,6,3,null,null,null,2,null,9,null,10,9,9,null,null,null,2,null,8,null,8,6,2,null,null,10,7,null,null,null,10,1,3,null,null,2,3,null,null,null,10,3,1,null,null,null,9,null,4,null,3,null,4,null,7,null,2,null,1,null,9,null,1,null,7,null,9,null,7,null,6,7,9,null,null,null,10,null,6,3,2,null,null,null,4,null,4,null,5,4,1,null,null,null,3,null,3,null,6,null,5,null,4,10,5,null,null,4,6,null,null,10,4,null,null,null,7,null,10,null,1,null,1,5,6,null,null,9,7,null,null,null,3,null,6,null,8,null,2,null,4,null,2,null,7,null,8,3,10,null,null,null,6,null,3,null,7,null,4,2,3,null,null,1,9,null,null,5,6,null,null,6,6,null,null,null,7,null,8,9,9,null,null,null,9,null,1,null,9,null,5,null,1,null,5,2,6,null,null,null,9,2,4,null,null,3,6,null,null,4,2,null,null,null,9,null,6,3,3,null,null,null,7,null,9,null,6,2,9,null,null,null,8,null,5,null,4,null,7,null,4,null,8,null,5,3,2,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,4,null,6,3,7,null,null,9,7,null,null,9,2,null,null,null,4,null,1,null,5,null,8,null,2,10,1,null,null,null,10,null,1,2,7,null,null,null,5,null,8,null,7,2,6,null,null,null,10,null,3,null,7,null,3,null,6,9,4,null,null,null,2,null,8,null,8,null,1,null,8,null,8,null,9,null,7,null,5,10,9,null,null,4,4,null,null,null,7,null,6,null,8,1,3,null,null,9,3,null,null,1,10,null,null,null,9,8,2,null,null,null,8,null,4,null,4,4,1,null,null,null,7,null,8,1,9,null,null,null,10,null,3,6,7,null,null,null,5,5,2,null,null,null,4,null,5,6,6,null,null,7,7,null,null,5,10,null,null,null,6,10,6,null,null,null,2,null,5,2,5,null,null,null,7,null,7,null,7,null,4,null,9,null,4,null,8,null,1,null,5,null,9,6,4,null,null,null,8,9,2,null,null,10,2,null,null,null,3,null,4,null,10,null,6,null,10,2,9,null,null,6,1,null,null,null,7,6,6,null,null,null,2,null,4,null,10,8,9,null,null,null,7,3,9,null,null,10,4,null,null,null,10,null,6,null,2,null,5,null,1,null,8,8,3,null,null,null,2,5,10,null,null,5,8,null,null,3,10,null,null,null,5,null,8,null,5,null,4,null,5,6,2,null,null,null,7,null,5,null,10,null,8,1,5,null,null,null,1,null,1,null,5,null,9,null,6,null,1,null,5]", false)]
[InlineData(new[] { 1, 10 }, "[1,null,1,10,1,9]", true)]
[InlineData(new[] { 2, 2, 1 }, "[2,null,2,null,2,null,1]", true)]
[InlineData(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "[1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,1,1,null,null,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,1,1,null,null,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,null,1,null,1,1,1,null,null,1,1,null,null,null,1,null,1,1,1,null,null,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1,null,1,1,1,null,null,null,1,null,1,null,1,null,1]", true)]
//[InlineData(new[] {  }, "", true)]
void Tests(int[] listNodes, string treeNodes, bool expected)
{
	TreeNode bTree = TreeNodeParser.Parse(treeNodes);
	ListNode linkedList = listNodes != null ? ListNode.Init(listNodes) : null;
	bool result = new Solution().IsSubPath(linkedList, bTree);
	Assert.Equal(expected, result);
}


/*
[2,2,1]
[2,null,2,null,2,null,1]
Output
false
Expected
true


[1,10]
[1,null,1,10,1,9]
true


Example 1:
Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true
Explanation: Nodes in blue form a subpath in the binary Tree.  

Example 2:
Input: head = [1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true

Example 3:
Input: head = [1,4,2,6,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: false
Explanation: There is no path in the binary tree that contains all the elements of the linked list from head.
*/
#endregion