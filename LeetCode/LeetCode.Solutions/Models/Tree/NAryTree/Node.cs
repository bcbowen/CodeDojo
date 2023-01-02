namespace LeetCode.Solutions.Models.Tree.NAryTree
{
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node()
        {
            children = new List<Node>();
        }

        public Node(int _val) : this()
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
