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
	public bool IsSameTree(TreeNode p, TreeNode q)
	{
		if (p == q) return true;
		if (p == null || q == null) return false;
		
		if (p.val != q.val) return false;
		
		if (!IsSameTree(p.left, q.left)) return false;
		if (!IsSameTree(p.right, q.right)) return false;
		
		return true;
	}
}

#region Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void EqualTreesReturnsTrue() 
{
	TreeNode node = new TreeNode(1); 
	node.left = new TreeNode(2); 
	node.right = new TreeNode(3); 
	node.right.left = new TreeNode(4);
	node.right.right = new TreeNode(5);
	Assert.True(new Solution().IsSameTree(node, node));
}

[Fact]
void OneNullTreeReturnsFalse()
{
	TreeNode node = new TreeNode(1);
	Assert.False(new Solution().IsSameTree(node, null));
	Assert.False(new Solution().IsSameTree(null, node));
}

[Fact]
void TwoNullTreesReturnsTrue()
{
	Assert.True(new Solution().IsSameTree(null, null));
}

[Fact]
void EqualTreesReturnTrue() 
{
	/*
	Input: p = [1,2,3], q = [1,2,3]
	Output: true
	*/
	TreeNode t1 = new TreeNode(1); 
	TreeNode t2 = new TreeNode(1); 
	
	t1.left = new TreeNode(2); 
	t2.left = new TreeNode(2);

	t1.right = new TreeNode(3);
	t2.right = new TreeNode(3);
	
	Assert.True(new Solution().IsSameTree(t1, t2));
}

[Fact]
void AsymmetricTreesReturnFalse()
{
	/*
	Input: p = [1,2], q = [1,null,2]
	Output: false
	*/
	
	TreeNode t1 = new TreeNode(1);
	TreeNode t2 = new TreeNode(1);

	t1.left = new TreeNode(2);
	t2.right = new TreeNode(2);

	Assert.False(new Solution().IsSameTree(t1, t2));
}

[Fact]
void UnequalTreesReturnFalse()
{
	/*
	Input: p = [1,2,1], q = [1,1,2]
	Output: false
	*/
	
	TreeNode t1 = new TreeNode(1);
	TreeNode t2 = new TreeNode(1);

	t1.left = new TreeNode(2);
	t2.left = new TreeNode(1);

	t1.right = new TreeNode(1);
	t2.right = new TreeNode(2);

	Assert.False(new Solution().IsSameTree(t1, t2));
}


/*





*/


#endregion