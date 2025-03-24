<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


public class Solution
{
	public IList<TreeNode> GenerateTrees(int n)
	{
		if (n == 0) return new List<TreeNode>();

		return GenerateTrees(1, n);
	}

	internal IList<TreeNode> GenerateTrees(int start, int end)
	{
		List<TreeNode> result = new List<TreeNode>();
		if (start > end) 
		{
			result.Add(null);
			return result;
		}

		// pick a root 
		for (int i = start; i <= end; i++) 
		{
			IList<TreeNode> left = GenerateTrees(start, i - 1);
			
			IList<TreeNode> right = GenerateTrees(i + 1, end);

			foreach (TreeNode l in left)
			{
				foreach(TreeNode r in right) 
				{
					TreeNode current = new TreeNode(i);
					current.left = l; 
					current.right = r;
					result.Add(current);
				}
			}
		}
		return result;
	}
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

#region private::Tests

[Theory]
[InlineData(3, 5)]
[InlineData(1, 1)]
void Tests(int n, int expected)
{
	IList<TreeNode> result = new Solution().GenerateTrees(n);
	Assert.Equal(result.Count, expected);
}


#endregion