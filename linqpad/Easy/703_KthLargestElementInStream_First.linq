<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class KthLargest
{

	private DepthList nodeList;
	private Node watch = null;

	public KthLargest(int k, int[] nums)
	{
		nodeList = new DepthList(k, nums);
		if (nums.Length >= k)
		{
			Node current = nodeList.Head;
			int i = 1;
			while (i < k)
			{
				current = current.Next;
				i++;
			}
			watch = current;
		}
	}

	public int Add(int val)
	{
		if (watch != null && val < watch.Value) return watch.Value;

		nodeList.Head = Node.Add(nodeList.Head, val);
		watch = Node.GetKNode(nodeList.K, nodeList.Head);
		return watch.Value;
	}


}

internal class DepthList 
{
	public DepthList(int k, int[] values) 
	{
		K = k;
		Head = Node.Init(values);
	}

	public int K { get; init; }
	public Node Head {get; set; }
	
}

internal class Node
{
	
	public Node(int value)
	{
		Value = value;
	}

	//public int K { get; set; } = 1;
	public int Value { get; init; }
	public Node Next { get; set; } = null;
	public Node Prev { get; set; } = null;


	public static Node AddFirst(Node head, int value)
	{
		Node node = new Node(value);
		if (head != null)
		{
			node.Next = head;
			head.Prev = node;
		}
		
		head = node;
		return head;
	}

	public static Node Add(Node head, int value)
	{
		if (head == null || value > head.Value) return AddFirst(head, value);

		Node current = head;
		while (current.Next != null && current.Next.Value > value)
		{
			current = current.Next;
		}

		Node node = new Node(value);
		if (current.Next != null)
		{
			node.Next = current.Next;
			current.Next.Prev = node;
			node.Prev = current;
			current.Next = node;
		}
		else
		{
			current.Next = node;
			node.Prev = current;
		}
		return head;
	}

	public static Node Init(int[] values)
	{
		if (values.Length == 0) 
		{
			return null;
		}
		Node head = new Node(values[0]);
		//head.K = k;
		for (int i = 1; i < values.Length; i++)
		{
			head = Node.Add(head, values[i]);
		}
		return head;
	}

	public static Node GetKNode(int k, Node head)
	{
		Node node = null;
		if (head == null) return node;
		int i = 1;
		node = head;
		while (i < k)
		{
			node = node.Next;
			if (node == null) break;
			i++;
		}
		return node;
	}

}
/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);


[Theory]
[InlineData(3, new int[] { 4, 5, 8, 2 }, new int[] { 3, 5, 10, 9, 4 }, new int[] { 4, 5, 5, 8, 8 })]
[InlineData(1, new int[0], new int[] { -3, -2, -4, 0, 4 }, new int[] { -3, -2, -2, 0, 4 })]
void Tests(int k, int[] initValues, int[] adds, int[] expectedValues)
{
	List<int> results = new List<int>();
	//Node node = Node.Init(k, initValues);
	KthLargest driver = new KthLargest(k, initValues);
	foreach (int add in adds)
	{
		results.Add(driver.Add(add));
	}
	Assert.Equal(expectedValues, results);
}
/*
["KthLargest","add","add","add","add","add"]
[[1,[]],[-3],[-2],[-4],[0],[4]]

Example 1:

Input
["KthLargest", "add", "add", "add", "add", "add"]
[[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
Output
[null, 4, 5, 5, 8, 8]

Explanation
KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
kthLargest.add(3);   // return 4
kthLargest.add(5);   // return 5
kthLargest.add(10);  // return 5
kthLargest.add(9);   // return 8
kthLargest.add(4);   // return 8
*/
[Theory]
[InlineData(new int[] { 2, 6, 5, 4, 3, 9, 1, 7, 8 })]
[InlineData(new int[] { 1, 3, 2, 4 })]
[InlineData(new int[] { 4, 3, 6 })]
[InlineData(new int[] { 5, 4 })]
void InitCreatesListWithNodesInMaxOrder(int[] values)
{
	Node head = Node.Init(values);
	Array.Sort(values);
	Node current = head;
	for (int i = values.Length - 1; i >= 0; i--)
	{
		Assert.Equal(values[i], current.Value);
		current = current.Next;
	}

}

[Fact]
void InitWithSingleValueCreatesNodeWithNoSiblings()
{
	Node node = Node.Init(new int[] { 2 });
	Assert.Equal(2, node.Value);
	Assert.Null(node.Next);
	Assert.Null(node.Prev);
}

[Theory]
[InlineData(new int[] { 2, 6, 5, 4, 3, 9, 1, 7, 8 }, 3, 7)]
[InlineData(new int[] { 1, 3, 2, 4 }, 2, 3)]
[InlineData(new int[] { 4, 3, 6 }, 3, 3)]
[InlineData(new int[] { 5, 4 }, 1, 5)]
void GetKNodeTest(int[] values, int k, int expected)
{
	Node head = Node.Init(values);
	int result = Node.GetKNode(k, head).Value;
	Assert.Equal(expected, result);
}

[Theory]
[InlineData(new int[] { 2, 6, 5, 4, 3, 9, 1, 8 }, 3, 7, 7)]
[InlineData(new int[] { 1, 2, 4 }, 2, 3, 3)]
[InlineData(new int[] { 4, 2, 6 }, 3, 3, 3)]
[InlineData(new int[] { 5, 4 }, 1, 6, 6)]
void AddNodeTest(int[] values, int k, int value, int expected)
{
	Node head = Node.Init(values);
	head = Node.Add(head, value);
	int result = Node.GetKNode(k, head).Value;
	Assert.Equal(expected, result);
}


[Fact]
void AddFirstTest() 
{
	Node node = new Node(2); 
	node = Node.AddFirst(node, 6); 
	Assert.Equal(6, node.Value); 
	Assert.NotNull(node.Next);
	Assert.Equal(2,  node.Next.Value);
	
}

#endregion