using LeetCode.Solutions.Models.Tree.BinaryTree;

namespace LeetCode.Solutions.Easy.P00111_MinimumDepthBinTree;

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
        Queue<TreeNode> q = new Queue<TreeNode>();
        q.Enqueue(root);
        bool found = false;
        
        while (!found) 
        {
            currentLevel++;
            int levelCount = q.Count;
            for (int i = 0; i < levelCount; i++) 
            {
                TreeNode node= q.Dequeue();
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