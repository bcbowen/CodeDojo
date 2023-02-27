<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
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
	public IList<IList<int>> LevelOrder(TreeNode root)
	{
		List<IList<int>> result = new List<IList<int>>(); 
		if (root == null) return result;
		
		Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
		nodeQueue.Enqueue(root);

		while(nodeQueue.Count > 0) 
		{
			int rowCount = nodeQueue.Count;
			List<int> row = new List<int>();
			for(int i = 0; i < rowCount; i++)
			{
				TreeNode current = nodeQueue.Dequeue();
				row.Add(current.val);
				if (current.left != null) nodeQueue.Enqueue(current.left); 
				if (current.right != null) nodeQueue.Enqueue(current.right);
			}
			result.Add(row);
		}

		return result;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion