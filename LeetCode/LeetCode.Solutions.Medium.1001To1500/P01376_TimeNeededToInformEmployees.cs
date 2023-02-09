namespace LeetCode.Solutions.Medium.P01376_TimeNeededToInformEmployees;
internal class Node
{
    public int MaxInformTime { get; set; }
    public int InformTime { get; set; }
    public Node(int value, int informTime)
    {
        Value = value;
        InformTime = informTime;
        Children = new List<Node>();
    }

    public int Value { get; set; }
    public List<Node> Children { init; get; }

    // Input: n = 6, headID = 2, manager = [2,2,-1,2,2,2], informTime = [0,0,1,0,0,0]
    public static Node BuildNodeTree(int n, int head, int[] manager, int[] informTime)
    {
        int maxInformTime = informTime[head];
        Node root = new Node(head, informTime[head]);
        Dictionary<int, Node> parentDictionary = new Dictionary<int, Node>();

        parentDictionary.Add(head, root);

        Queue<int> q = new Queue<int>();
        for (int i = 0; i < manager.Length; i++)
        {
            if (i != head) q.Enqueue(i);
        }

        while (q.Count > 0)
        {
            int i = q.Dequeue();
            if (parentDictionary.ContainsKey(manager[i]))
            {
                Node parent = parentDictionary[manager[i]];
                int addedTime = informTime[i] + parent.InformTime;
                Node child = new Node(i, addedTime);
                parent.Children.Add(child);
                parentDictionary.Add(i, child);
                maxInformTime = Math.Max(maxInformTime, addedTime);
            }
            else
            {
                q.Enqueue(i);
            }
        }
        root.MaxInformTime = maxInformTime;
        return root;
    }

}
public class Solution
{
    public int NumOfMinutes(int n, int headId, int[] manager, int[] informTime)
    {
        if (n == 1) return 0;

        Node root = Node.BuildNodeTree(n, headId, manager, informTime);
        return root.MaxInformTime;

    }
}