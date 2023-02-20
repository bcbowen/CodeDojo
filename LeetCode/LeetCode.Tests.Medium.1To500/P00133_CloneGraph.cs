using LeetCode.Solutions.Medium.P00133_CloneGraph;

namespace LeetCode.Tests.Medium.P00133_CloneGraph;

[TestFixture]
[Category("Medium")]
public class Tests
{
    [Test]
    public void P00133_CloneGraph_4NodeGraphTest() 
    {
        /*
        Input: adjList = [[2,4],[1,3],[2,4],[1,3]]
        Output: [[2,4],[1,3],[2,4],[1,3]]
        Explanation: There are 4 nodes in the graph.
        1st node (val = 1)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
        2nd node (val = 2)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
        3rd node (val = 3)'s neighbors are 2nd node (val = 2) and 4th node (val = 4).
        4th node (val = 4)'s neighbors are 1st node (val = 1) and 3rd node (val = 3).
        
        */

        Node node1 = new Node(1); 
        Node node2 = new Node(2);
        Node node3 = new Node(3);
        Node node4 = new Node(4);

        node1.neighbors.Add(node2);
        node1.neighbors.Add(node4);

        node2.neighbors.Add(node1);
        node2.neighbors.Add(node3);

        node3.neighbors.Add(node2);
        node3.neighbors.Add(node4);

        node4.neighbors.Add(node1);
        node4.neighbors.Add(node3);

        Node clone = new Solution().CloneGraph(node1);
        Assert.Multiple(() => 
        {
            Assert.That(clone.val, Is.EqualTo(1));
            Assert.That(clone.neighbors, Has.Count.EqualTo(2));
            Assert.That(clone.neighbors[0].val, Is.EqualTo(2));
            Assert.That(clone.neighbors[1].val, Is.EqualTo(4));
        });

        clone = clone.neighbors[0];
        Assert.Multiple(() =>
        {
            Assert.That(clone.val, Is.EqualTo(2));
            Assert.That(clone.neighbors, Has.Count.EqualTo(2));
            Assert.That(clone.neighbors[0].val, Is.EqualTo(1));
            Assert.That(clone.neighbors[1].val, Is.EqualTo(3));
        });

        clone = clone.neighbors[1];
        Assert.Multiple(() =>
        {
            Assert.That(clone.val, Is.EqualTo(3));
            Assert.That(clone.neighbors, Has.Count.EqualTo(2));
            Assert.That(clone.neighbors[0].val, Is.EqualTo(2));
            Assert.That(clone.neighbors[1].val, Is.EqualTo(4));
        });

        clone = clone.neighbors[1];
        Assert.Multiple(() =>
        {
            Assert.That(clone.val, Is.EqualTo(4));
            Assert.That(clone.neighbors, Has.Count.EqualTo(2));
            Assert.That(clone.neighbors[0].val, Is.EqualTo(1));
            Assert.That(clone.neighbors[1].val, Is.EqualTo(3));
        });
    }

    [Test]
    public void P00133_CloneGraph_1NodeNoNeighbors()
    {
        /*
        Input: adjList = [[]]
        Output: [[]]
        Explanation: Note that the input contains one empty list. The graph consists of only one node with val = 1 and it does not have any neighbors.
        
        */
        Node node1 = new Node(1);
        
        Node clone = new Solution().CloneGraph(node1);
        Assert.Multiple(() =>
        {
            Assert.That(clone.val, Is.EqualTo(1));
            Assert.That(clone.neighbors, Has.Count.EqualTo(0));
        });
    }

    [Test]
    public void P00133_CloneGraph_EmptyGraphTest()
    {
        /*
         Input: adjList = []
         Output: []
         Explanation: This an empty graph, it does not have any nodes.
        */

        Node node1 = null;

        Node clone = new Solution().CloneGraph(node1);
        Assert.That(clone, Is.Null);
    }

}