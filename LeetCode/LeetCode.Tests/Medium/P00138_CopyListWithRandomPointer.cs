using LeetCode.Solutions.Medium.P00138_CopyListWithRandomPointer;

namespace LeetCode.Tests.Medium.P00138_CopyListWithRandomPointer;

public class Tests
{
    [Test]
    public void Example1Test()
    {
        Node[] nodes = new Node[5];
        //Dictionary<int, Node> pointers = new Dictionary<int, Node>(); 
        Node head = new Node(7);
        nodes[0] = head;

        Node current = head;
        current.next = new Node(13);
        current = current.next;
        nodes[1] = current;

        current.next = new Node(11);
        current = current.next;
        nodes[2] = current;

        current.next = new Node(10);
        current = current.next;
        nodes[3] = current;

        current.next = new Node(1);
        current = current.next;
        nodes[4] = current;

        nodes[1].random = nodes[0];
        nodes[2].random = nodes[4];
        nodes[3].random = nodes[2];
        nodes[4].random = nodes[0];

        Node result = new Solution().CopyRandomList(head);
        CompareLists(head, result);
    }

    private void CompareLists(Node original, Node copy)
    {
        Node node1 = original;
        Node node2 = copy;

        while (node1 != null)
        {
            Assert.AreNotEqual(node1, node2);
            Assert.AreEqual(node1.val, node2.val);
            if (node1.random == null)
            {
                Assert.Null(node2.random);
            }
            else
            {
                Assert.AreEqual(node1.random.val, node2.random.val);
                Assert.AreNotEqual(node1.random, node2.random);
            }
            node1 = node1.next;
            node2 = node2.next;
        }
        Assert.Null(node2);
    }

    /*
    Input: head = [[1,1],[2,1]]
    Output: [[1,1],[2,1]]
    */

    [Test]
    public void Example2Test()
    {
        Node[] nodes = new Node[2];
        //Dictionary<int, Node> pointers = new Dictionary<int, Node>(); 
        Node head = new Node(1);
        nodes[0] = head;

        Node current = head;
        current.next = new Node(2);
        current = current.next;
        nodes[1] = current;

        nodes[0].random = nodes[1];
        nodes[1].random = nodes[1];

        Node result = new Solution().CopyRandomList(head);
        CompareLists(head, result);
    }


    /*
    Input: head = [[3,null],[3,0],[3,null]]
    Output: [[3,null],[3,0],[3,null]]

    */


    [Test]
    public void Example3Test()
    {
        Node head = new Node(3);

        Node current = head;
        current.next = new Node(3);
        current = current.next;
        current.random = head;

        current.next = new Node(3);

        Node result = new Solution().CopyRandomList(head);
        CompareLists(head, result);
    }

}