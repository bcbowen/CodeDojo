using System.Text;

namespace LeetCode.Models.Tree.BinaryTree
{
    public static class TreeNodeExtensions
    {
        public static TreeNode AddNode(this TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
            }
            else 
            {
                if (value < root.val)
                {
                    if (root.left == null)
                    {
                        root.left = new TreeNode(value);
                    }
                    else
                    {
                        root.left.AddNode(value);
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
                        root.right.AddNode(value);
                    }
                }
            }
            
            return root;
        }

        public static string GetNodeList(this TreeNode node)
        {
            StringBuilder result = new StringBuilder();
            result.Append("[");
            // TODO: finish
            result.Append("]");
            return result.ToString();
        }
    }
}
