<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}


public class Solution
{
	public Node CopyRandomList(Node head)
	{
		if (head == null) return head;
		int index = 0;
		Dictionary<Node, int> indexLookup = new Dictionary<Node, int>();
		Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();
		Node copy = new Node(head.val);
		indexLookup.Add(head, index);
		nodeLookup.Add(index, copy);
		index++;
		
		Node c1 = head; 
		Node c2 = copy; 
		
		while(c1.next != null)
		{
			c1 = c1.next;
			c2.next = new Node(c1.val);
			c2 = c2.next;
			indexLookup.Add(c1, index);
			nodeLookup.Add(index, c2);
			index++;
		}
		
		c1 = head; 
		c2 = copy;

		if (c1.random == null)
		{
			c2.random = null;
		}
		else
		{
			int i = indexLookup[c1.random];	
			c2.random = nodeLookup[i];
		}

		while(c1.next != null)
		{
			c1 = c1.next; 
			c2 = c2.next;
			
			if (c1.random == null)
			{
				c2.random = null;
			}
			else
			{
				int i = indexLookup[c1.random];
				c2.random = nodeLookup[i];
			}
		}
		return copy;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);
/*
Input: head = [[7,null],[13,0],[11,4],[10,2],[1,0]]
Output: [[7,null],[13,0],[11,4],[10,2],[1,0]]
*/
[Fact]
void Example1Test() 
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

	while(node1 != null) 
	{
		Assert.NotEqual(node1, node2);
		Assert.Equal(node1.val, node2.val);
		if (node1.random == null) 
		{
			Assert.Null(node2.random);
		}
		else 
		{
			Assert.Equal(node1.random.val, node2.random.val);
			Assert.NotEqual(node1.random, node2.random);
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

[Fact]
void Example2Test()
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


[Fact]
void Example3Test()
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


#endregion