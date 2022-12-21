<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


// Definition for a Node.
public class Node
{
	public int val;
	public Node prev;
	public Node next;
	public Node child;

	[DebuggerStepThrough]
	public Node(int val)
	{
		this.val = val;
	}

	public static Node Init(int?[] values)
	{
		if (values.Length == 0 || values[0] == null) return null;

		Node head = new Node(values[0].Value);
		Node levelHead = head;
		Node current = levelHead;
		int index = 1;
		while (index < values.Length)
		{
			while (index < values.Length && values[index].HasValue)
			{
				current = AddToEnd(levelHead, values[index++].Value, current);
			}
			if (index >= values.Length -1) break;

			current = levelHead;
			index++;
			while (index < values.Length && !values[index].HasValue)
			{
				current = current.next;
				index++;
			}
			//if (index >= values.Length - 1) break;
			//current = current.next; 
			current.child = new Node(values[index++].Value);
			levelHead = current.child;
			current = levelHead;
			//index++;
		}

		return head;
	}

	/*
	public static Node Init_First(int?[] values)
	{
		if (values.Length == 0 || values[0] == null) return null;
		Node head = new Node(values[0].Value);
		Node levelHead = head;
		Node current = levelHead;
		int index = 1;
		while (index < values.Length)
		{
			while (index < values.Length && values[index].HasValue)
			{
				current = AddToEnd(levelHead, values[index++].Value, current);
			}

			current = levelHead;
			while (index < values.Length - 1 && !values[++index].HasValue)
			{
				current = current.next;
			}
			if (index >= values.Length - 1) break;
			//current = current.next; 
			current.child = new Node(values[index].Value);
			levelHead = current.child;
			current = levelHead;
			index++;
		}

		return head;
	}
	*/
	
	public static Node AddToEnd(Node head, Node node, Node tail = null)
	{
		if (tail == null)
		{
			Node current = head;
			while (current.next != null)
			{
				current = current.next;
			}
			tail = current;
		}

		tail.next = node;
		node.prev = tail;
		return node;
	}

	public static Node AddToEnd(Node head, int val, Node tail = null)
	{
		return AddToEnd(head, new Node(val), tail);
	}

	public static Node AddToFront(Node head, int val)
	{
		return AddToFront(head, new Node(val));
	}

	public static Node AddToFront(Node head, Node node)
	{
		node.next = head;
		head.prev = node;
		return node;
	}


	public static Node Get(Node head, int index)
	{
		if (head == null || index == 0) return head;

		Node current = head;
		int i = 0;
		while (i < index)
		{
			i++;
			current = current.next;
			if (current == null) break;
		}

		return current;
	}

	public static (int, Node) GetLast(Node head)
	{
		Node current = head;
		int count = 1;
		while (current.next != null)
		{
			current = current.next;
			count++;
		}
		return (count, current);
	}

	/// <summary>Gets values of nodes without children</summary>
	public static int[] GetTopValues(Node head)
	{
		if (head == null) return new int[0];

		List<int> values = new List<int>() { head.val };
		Node current = head;
		while (current.next != null)
		{
			current = current.next;
			values.Add(current.val);
		}
		return values.ToArray();
	}
}

public class Solution
{
	public Node Flatten(Node head)
	{
		if (head == null) return head;

		Node current = head;
		Node next = head.next;

		while (current != null)
		{
			if (current.child != null)
			{
				Node flat = Flatten(current.child);
				current.child = null;
				current.next = flat;
				flat.prev = current;
				current = FindEnd(current);
				if (next != null)
				{
					current.next = next;
					next.prev = current;
				}
			}
			current = current.next;
			if (current != null) next = current.next;
		}

		return head;
	}

	private static Node FindEnd(Node node)
	{
		while (node.next != null)
		{
			node = node.next;
		}
		return node;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Input: head = [1,2,3,4,5,6,null,null,null,7,8,9,10,null,null,11,12]
Output: [1,2,3,7,8,11,12,9,10,4,5,6]

*/

[Fact]
void FlattenTest1()
{
	int?[] values = new int?[] { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12 };
	int[] expected = new[] { 1, 2, 3, 7, 8, 11, 12, 9, 10, 4, 5, 6 };
	Node expanded = Node.Init(values);
	Node flat = new Solution().Flatten(expanded);
	int[] result = Node.GetTopValues(flat);
	Assert.Equal(expected, result);
}

/*
Input: head = [1,2,null,3]
Output: [1,3,2]
*/

[Fact]
void FlattenTest2()
{
	int?[] values = new int?[] { 1, 2, null, 3 };
	int[] expected = new[] { 1, 3, 2 };
	Node expanded = Node.Init(values);
	Node flat = new Solution().Flatten(expanded);
	int[] result = Node.GetTopValues(flat);
	Assert.Equal(expected, result);
}

/*
Input: head = []
Output: []
*/

[Fact]
void FlattenTest3()
{
	int?[] values = new int?[0];
	int[] expected = new int[0];
	Node expanded = Node.Init(values);
	Node flat = new Solution().Flatten(expanded);
	int[] result = Node.GetTopValues(flat);
	Assert.Equal(expected, result);
}

/*
input: [1,null,2,null,3,null]
output: [1,2,3]
*/

[Fact]
void FlattenTest4()
{
	int?[] values = new int?[] { 1, null, 2, null, 3, null };
	int[] expected = new[] { 1, 2, 3 };
	Node expanded = Node.Init(values);
	Node flat = new Solution().Flatten(expanded);
	int[] result = Node.GetTopValues(flat);
	Assert.Equal(expected, result);
}

[Fact]
void InitTest1()
{
	int?[] values = { 1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12 };
	Node node = Node.Init(values);
	(int count, Node current) = Node.GetLast(node);
	Assert.Equal(6, current.val);
	Assert.Equal(6, count);

	current = Node.Get(node, 2);
	Assert.Equal(3, current.val);

	Assert.NotNull(current.child);

	current = current.child;
	Assert.Equal(7, current.val);

	node = current;
	(count, current) = Node.GetLast(node);
	Assert.Equal(10, current.val);
	Assert.Equal(4, count);

	current = Node.Get(node, 1);
	Assert.Equal(8, current.val);
	current = current.child;
	Assert.Equal(11, current.val);

	node = current;
	(count, current) = Node.GetLast(node);
	Assert.Equal(12, current.val);
	Assert.Equal(2, count);
}

[Fact]
void InitTest2()
{
	int?[] values = { 1, 2, null, 3 };
	Node node = Node.Init(values);
	(int count, Node current) = Node.GetLast(node);
	Assert.Equal(2, current.val);
	Assert.Equal(2, count);

	Assert.NotNull(node.child);

	current = node.child;
	Assert.Equal(3, current.val);

	node = current;
	(count, current) = Node.GetLast(node);
	Assert.Equal(3, current.val);
	Assert.Equal(1, count);
}

[Fact]
void InitTest3()
{
	int?[] values = new int?[0];
	Node node = Node.Init(values);

	Assert.Null(node);
}

[Fact]
void InitTest4()
{
	int?[] values = { 1, null, 2, null, 3, null };
	Node node = Node.Init(values);
	(int count, Node current) = Node.GetLast(node);
	Assert.Equal(1, current.val);
	Assert.Equal(1, count);

	Assert.NotNull(node.child);

	current = node.child;
	Assert.Equal(2, current.val);
	node = current;

	current = node.child;
	Assert.Equal(3, current.val);
}

#endregion