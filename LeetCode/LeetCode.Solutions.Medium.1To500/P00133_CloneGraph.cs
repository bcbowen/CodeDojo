namespace LeetCode.Solutions.Medium.P00133_CloneGraph;

// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution
{
    public Node CloneGraph(Node node)
    {
        if (node == null) return null;
        Dictionary <Node, Node> visited = new Dictionary<Node, Node>();
        Queue<Node> nodeQueue = new Queue<Node>();
        nodeQueue.Enqueue(node);
        visited.Add(node, new Node(node.val));
        while (nodeQueue.Count > 0) 
        {
            Node currentNode = nodeQueue.Dequeue();
            foreach (Node neighbor in currentNode.neighbors) 
            {
                if (!visited.ContainsKey(neighbor)) 
                {
                    visited.Add(neighbor, new Node(neighbor.val));
                    nodeQueue.Enqueue(neighbor);
                }
                visited[neighbor].neighbors.Add(visited[currentNode]);
            }
        }

        return visited[node];
    }
}