<Query Kind="Statements" />

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
			if (index >= values.Length - 1) break;

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