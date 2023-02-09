namespace LeetCode.Solutions.Medium.P00752_OpenTheLock;

public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        HashSet<string> deadSet = new HashSet<string>();
        foreach (string deadEnd in deadends)
        {
            deadSet.Add(deadEnd);
        }

        Queue<string> queue = new Queue<string>();
        queue.Enqueue("0000");
        queue.Enqueue(null);
        HashSet<string> seenSet = new HashSet<string>();
        seenSet.Add("0000");
        int depth = 0;
        while (queue.Count > 0) 
        {
            string node = queue.Dequeue();
            if (node == null)
            {
                depth++;
                if (queue.Count > 0 && queue.Peek() != null)
                {
                    queue.Enqueue(null);
                }
            }
            else if (node == target)
            {
                return depth;
            }
            else if (!deadSet.Contains(node)) 
            {
                for (int i = 0; i < 4; ++i) 
                {
                    for (int d = -1; d <= 1; d += 2)
                    {
                        int y = ((node[i] - '0') + d + 10) % 10;
                        string nei = node.Substring(0, i) + ("" + y) + node.Substring(i + 1);
                        if (!seenSet.Contains(nei))
                        {
                            seenSet.Add(nei);
                            queue.Enqueue(nei);
                        }
                    }
                }
            }

        }

        return -1;
    }

}