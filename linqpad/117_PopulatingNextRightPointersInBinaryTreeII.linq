<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}


public class Solution
{
	public Node Connect(Node root)
	{
		if (root == null) return root;

		Queue<Node> nodeQueue = new Queue<Node>();
		nodeQueue.Enqueue(root);
		while (nodeQueue.Count > 0)
		{
			int levelCount = nodeQueue.Count();
			Node last = null;
			for (int i = 0; i < levelCount; i++)
			{
				Node current = nodeQueue.Dequeue();
				if (current.left != null) nodeQueue.Enqueue(current.left);
				if (current.right != null) nodeQueue.Enqueue(current.right);
				if (last != null) last.next = current;
				last = current;
			}
		}

		return root;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1Test()
{
	Node root = new Node(1);
	root.left = new Node(2);
	root.right = new Node(3);
	root.left.left = new Node(4);
	root.left.right = new Node(5);

	root.right = new Node(3);
	root.right.right = new Node(7);

	Node result = new Solution().Connect(root);
	Assert.Null(result.next);

	Node current = result.left;
	Assert.Equal(3, current.next.val);
	Assert.Null(current.next.next);

	current = current.left;
	Assert.Equal(5, current.next.val);
	Assert.Equal(7, current.next.next.val);
	Assert.Null(current.next.next.next);
}

[Fact]
void Example2Test()
{
	Node root = null;
	Node result = new Solution().Connect(root);
	Assert.Null(result);
}

/*
Input: root = [1,2,3,4,5,null,7]
Output: [1,#,2,3,#,4,5,7,#]
Explanation: Given the above binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.
Example 2:

Input: root = []
Output: []
*/

#endregion