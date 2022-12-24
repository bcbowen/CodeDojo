using System.Text;

namespace LeetCode.Solutions.Models.Tree.BinaryTree
{
    public static  class TreeNodeExtensions
    {
        public static void AddNode(this TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
                return;
            };

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
