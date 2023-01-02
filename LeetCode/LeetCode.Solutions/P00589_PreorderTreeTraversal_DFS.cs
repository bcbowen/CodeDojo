namespace LeetCode.Solutions.P00589_PreorderTreeTraversal_DFS;
using LeetCode.Solutions.Models.Tree.NAryTree;

public class Solution
{
    public IList<int> Preorder(Node root)
    {
        List<int> values = new List<int>();
        if (root == null) return values;
        values.Add(root.val);
        if (root.children != null)
        {
            foreach (Node child in root.children)
            {
                values.AddRange(Preorder(child));
            }
        }
        return values;
    }
}