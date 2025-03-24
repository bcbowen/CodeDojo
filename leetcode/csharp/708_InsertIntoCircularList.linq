<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

/**/
// Definition for a Node.
public class Node
{
	public int val;
	public Node next;

	public Node() { }

	public Node(int _val)
	{
		val = _val;
		next = null;
	}

	public Node(int _val, Node _next)
	{
		val = _val;
		next = _next;
	}
}


public class Solution
{
	public Node Insert(Node head, int insertVal)
	{
		Node node = new Node(insertVal);
		if (head == null)
		{
			node.next = node;
			return node;
		}
		else if (head.next == head)
		{
			head.next = node;
			node.next = head;
			return head;
		}

		Node current = head;
		while (current.next.val >= current.val && current.next != head)
		{
			current = current.next;
		}

		if (node.val > current.val || node.val < current.next.val)
		{
			// inserted node is the largest or smallest, it goes between the current largest and smallest
			node.next = current.next;
			current.next = node;

		}
		else
		{
			// find where the current node fits between 2 nodes
			while (current.next.val < node.val)
			{
				current = current.next;
			}
			node.next = current.next;
			current.next = node;
		}
		return head;

	}
	
	
	public Node InsertFirst(Node head, int insertVal)
	{
		Node node = new Node(insertVal);
		if (head == null)
		{
			node.next = node;
			return node;
		}
		else if (head.next == head)
		{
			head.next = node;
			node.next = head;
			return head;
		}

		if (head.val > insertVal)
		{
			int min = head.val;
			Node current = head;
			while (current.next.val > insertVal && current.next != head)
			{
				current = current.next;
				if (current.val < min) min = current.val;
			}

			if (current.next != head)
			{
				current = current.next;
				node.next = current.next;
				current.next = node;
			}
			else
			{
				while (current.next.val != min)
				{
					current = current.next;
				}
				node.next = current.next;
				current.next = node;
			}
		}
		else if (head.val < insertVal)
		{
			int max = head.val;
			Node current = head;
			while (current.next.val < insertVal && current.next != head)
			{
				current = current.next;
				if (current.val > max) max = current.val;
			}

			if (current.next != head)
			{
				//current = current.next;
				node.next = current.next;
				current.next = node;
			}
			else
			{
				while (current.val != max)
				{
					current = current.next;
				}
				node.next = current.next;
				current.next = node;
			}
		}
		else
		{
			node.next = head.next;
			head.next = node;
		}

		return head;
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

/*
Input: head = [3,4,1], insertVal = 2
Output: [3,4,1,2]
*/

[Fact]
void CircularListTest1()
{
	Node head = new Node(3);
	Node current = head;
	current.next = new Node(4);
	current = current.next;
	current.next = new Node(1);
	current = current.next;
	current.next = head;

	Node result = new Solution().Insert(head, 2);
	Assert.Equal(3, result.val);
	Assert.Equal(4, result.next.val);
	Assert.Equal(1, result.next.next.val);
	Assert.Equal(2, result.next.next.next.val);
	Assert.Equal(result, result.next.next.next.next);
}

[Fact]
void CircularListTest2()
{
	Node head = new Node(3);
	Node current = head;
	current.next = new Node(4);
	current = current.next;
	current.next = new Node(1);
	current = current.next;
	current.next = head;

	Node result = new Solution().Insert(head, 5);
	Assert.Equal(3, result.val);
	Assert.Equal(4, result.next.val);
	Assert.Equal(5, result.next.next.val);
	Assert.Equal(1, result.next.next.next.val);
	Assert.Equal(result, result.next.next.next.next);
}

/*
Input:
[1,3,5]
2
Output:
[1,3,2,5]
Expected:
[1,2,3,5]
*/

[Fact]
void CircularListTest6()
{
	Node head = new Node(1);
	Node current = head;
	current.next = new Node(3);
	current = current.next;
	current.next = new Node(5);
	current = current.next;
	current.next = head;

	Node result = new Solution().Insert(head, 2);
	Assert.Equal(1, result.val);
	Assert.Equal(2, result.next.val);
	Assert.Equal(3, result.next.next.val);
	Assert.Equal(5, result.next.next.next.val);
	Assert.Equal(result, result.next.next.next.next);
}

[Fact]
void CircularListTest3()
{
	Node head = new Node(3);
	Node current = head;
	current.next = new Node(4);
	current = current.next;
	current.next = new Node(2);
	current = current.next;
	current.next = head;

	Node result = new Solution().Insert(head, 1);
	Assert.Equal(3, result.val);
	Assert.Equal(4, result.next.val);
	Assert.Equal(1, result.next.next.val);
	Assert.Equal(2, result.next.next.next.val);
	Assert.Equal(result, result.next.next.next.next);
}

/*
Input:
[5,1,3]
4
Output:
[5,1,4,3]
Expected:
[5,1,3,4]
*/
[Fact]
void CircularListTest4()
{
	Node head = new Node(5);
	Node current = head;
	current.next = new Node(1);
	current = current.next;
	current.next = new Node(3);
	current = current.next;
	current.next = head;

	Node result = new Solution().Insert(head, 4);
	Assert.Equal(5, result.val);
	Assert.Equal(1, result.next.val);
	Assert.Equal(3, result.next.next.val);
	Assert.Equal(4, result.next.next.next.val);
	Assert.Equal(result, result.next.next.next.next);
}

/*
Input:
[3,3,5]
0
Output:
[3,0,3,5]
Expected:
[3,3,5,0]
*/
[Fact]
void CircularListTest5()
{
	Node head = new Node(3);
	Node current = head;
	current.next = new Node(3);
	current = current.next;
	current.next = new Node(5);
	current = current.next;
	current.next = head;

	Node result = new Solution().Insert(head, 0);
	Assert.Equal(3, result.val);
	Assert.Equal(3, result.next.val);
	Assert.Equal(5, result.next.next.val);
	Assert.Equal(0, result.next.next.next.val);
	Assert.Equal(result, result.next.next.next.next);
}


/*
[3,3,3]
0
*/

[Fact]
void CircularListTest7()
{
	Node head = new Node(3);
	Node current = head;
	current.next = new Node(3);
	current = current.next;
	current.next = new Node(3);
	current = current.next;
	current.next = head;

	Node result = new Solution().Insert(head, 0);
	Assert.Equal(3, result.val);
	Assert.Equal(3, result.next.val);
	Assert.Equal(3, result.next.next.val);
	Assert.Equal(0, result.next.next.next.val);
	Assert.Equal(result, result.next.next.next.next);
}

/*
Input: head = [], insertVal = 1
Output: [1]
*/

[Fact]
void EmptyNodeTest()
{
	Node head = null;
	Node result = new Solution().Insert(head, 1);
	Assert.Equal(1, result.val);
	Assert.Equal(result, result.next);
}

/*
Input: head = [1], insertVal = 0
Output: [1,0]
*/

[Fact]
void SingleNodeTest()
{
	Node head = new Node(1);
	head.next = head;

	Node result = new Solution().Insert(head, 0);
	Assert.Equal(1, result.val);
	Assert.Equal(0, result.next.val);
	Assert.Equal(result, result.next.next);
}

#endregion