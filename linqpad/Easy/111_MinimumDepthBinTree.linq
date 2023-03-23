<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

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
	public int MinDepth(TreeNode root)
	{
		Func<TreeNode, bool> isLeaf = (TreeNode node) =>
		{
			if (node == null) return false;
			return node.left == null && node.right == null;
		};

		int currentLevel = 0;
		if (root == null) return currentLevel;

		Queue<TreeNode> q = new Queue<TreeNode>();
		q.Enqueue(root);
		bool found = false;

		while (!found)
		{
			currentLevel++;
			int levelCount = q.Count;
			for (int i = 0; i < levelCount; i++)
			{
				TreeNode node = q.Dequeue();
				if (isLeaf(node))
				{
					found = true;
					break;
				}
				else
				{
					if (node.left != null) q.Enqueue(node.left);
					if (node.right != null) q.Enqueue(node.right);
				}
			}


		};

		return currentLevel;


	}
}

#region private::Tests


/*
	3
   /  \
  9    20
	  /  \
	 15   7

Input: root = [3,9,20,null,null,15,7]
Output: 2    
*/

[Fact]
public void Partial3LevelTreeTest()
{
	TreeNode root = new TreeNode(3);
	root.left = new TreeNode(9);
	root.right = new TreeNode(20);
	root.right.left = new TreeNode(15);
	root.right.right = new TreeNode(7);

	int expected = 2;
	int result = new Solution().MinDepth(root);
	Assert.Equal(expected, result);
}

/*

Example 2:
	2
	 \
	  3
	   \ 
		4
		 \
		  5
		   \
			6
Input: root = [2,null,3,null,4,null,5,null,6]
Output: 5

*/
[Fact]
public void FiveLevelOneSidedTreeTest()
{
	TreeNode root = new TreeNode(2);
	TreeNode current = root;
	current.right = new TreeNode(3);
	current = current.right;
	current.right = new TreeNode(4);
	current = current.right;
	current.right = new TreeNode(5);
	current = current.right;
	current.right = new TreeNode(6);


	int expected = 5;
	int result = new Solution().MinDepth(root);
	Assert.Equal(expected, result);
}

[Fact]
public void OneNodeTreeTest()
{
	TreeNode root = new TreeNode(2);

	int expected = 1;
	int result = new Solution().MinDepth(root);
	Assert.Equal(expected, result);
}

/*


	 3
   /   \
  9     20
 / \   /  \
1   6 15   7

Input: root = [3,9,20,1,6,15,7]
Output: 2
Example 2:

*/

[Fact]
public void ThreeLevelFullTreeTest()
{
	TreeNode root = new TreeNode(3);
	TreeNode current = root;
	current.left = new TreeNode(9);
	current.right = new TreeNode(20);
	current = current.left;
	current.left = new TreeNode(1);
	current.right = new TreeNode(6);

	current = root.right;
	current.left = new TreeNode(15);
	current.right = new TreeNode(7);


	int expected = 3;
	int result = new Solution().MinDepth(root);
	Assert.Equal(expected, result);
}

/*

		  3
	 /         \
	9           20
   /  \       /    \
  1    6     15     7
 / \  / \    / \   / \
13 14 21 23 31 32 43 45

Input: root = [3,9,20,1,6,15,7]
Output: 3
Example 2:

*/
[Fact]
public void FourLevelFullTreeTest()
{
	TreeNode root = new TreeNode(3);
	TreeNode current = root;
	current.left = new TreeNode(9);
	current.right = new TreeNode(20);
	current = current.left;
	current.left = new TreeNode(1);
	current.right = new TreeNode(6);

	current = current.left;
	current.left = new TreeNode(13);
	current.right = new TreeNode(14);

	current = root.left.right;
	current.left = new TreeNode(21);
	current.right = new TreeNode(23);

	current = root.right;
	current.left = new TreeNode(15);
	current.right = new TreeNode(7);

	current = current.left;
	current.left = new TreeNode(31);
	current.right = new TreeNode(32);

	current = root.right.right;
	current.left = new TreeNode(43);
	current.right = new TreeNode(45);

	int expected = 4;
	int result = new Solution().MinDepth(root);
	Assert.Equal(expected, result);
}

#endregion