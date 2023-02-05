namespace LeetCode.Solutions.P00429_NAryLevelOrderTraversal;
using LeetCode.Solutions.Models.Tree.NAryTree;
public class Solution
{
    public IList<IList<int>> LevelOrder(Node root)
    {
        List<IList<int>> result = new List<IList<int>>();
        if (root == null) return result;
        Queue<Node> nodeQueue = new Queue<Node>();
        nodeQueue.Enqueue(root);
        List<int> row;
        while (nodeQueue.Count > 0)
        {
            row = new List<int>();
            int rowCount = nodeQueue.Count;
            for (int i = 0; i < rowCount; i++)
            {
                Node current = nodeQueue.Dequeue();
                row.Add(current.val);
                foreach (Node child in current.children)
                {
                    nodeQueue.Enqueue(child);
                }

            }
            result.Add(row);
        }
        return result;
    }
}