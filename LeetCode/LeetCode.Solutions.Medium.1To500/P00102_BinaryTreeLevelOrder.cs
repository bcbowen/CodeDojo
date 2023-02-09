using LeetCode.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Medium.P00102_BinaryTreeLevelOrder;

public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        List<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;

        Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
        nodeQueue.Enqueue(root);

        while (nodeQueue.Count > 0)
        {
            int rowCount = nodeQueue.Count;
            List<int> row = new List<int>();
            for (int i = 0; i < rowCount; i++)
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