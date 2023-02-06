using LeetCode.Solutions.Models.Tree.NAryTree;

namespace LeetCode.Solutions.Easy.P00590_NAryPostorderTraversal;

public class Solution
{
    public IList<int> Postorder(Node root)
    {
        List<int> result = new List<int>();
        if (root == null) return result;
        foreach (Node child in root.children)
        {
            result.AddRange(Postorder(child));
        }
        result.Add(root.val);

        return result;
    }
}