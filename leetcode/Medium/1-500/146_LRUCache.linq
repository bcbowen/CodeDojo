<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class LRUCache
{
	private int _capacity; 
	private LRUNodeList _lruList = new LRUNodeList(); 
	private Dictionary<int, Node> _nodeCache = new Dictionary<int, Node>(); 
	public LRUCache(int capacity)
	{
		_capacity = capacity;
	}

	public int Get(int key)
	{
		if (_nodeCache.ContainsKey(key))
		{
			Node node = _nodeCache[key]; 
			_lruList.Update(node, node.Value); 
			return _nodeCache[key].Value; 	
		}
		
		
		return -1;
	}

	public void Put(int key, int value)
	{
		Node node;
		if (_nodeCache.ContainsKey(key)) 
		{
			node = _nodeCache[key]; 
			_lruList.Update(node, value); 
		}
		else 
		{
			if (_nodeCache.Count == _capacity) 
			{
				int lruKey = _lruList.Pop(); 
				_nodeCache.Remove(lruKey); 
			}
			
			node = new Node { Key = key, Value = value, LastAccessed = DateTime.Now.Ticks}; 
			_lruList.Insert(node);
			_nodeCache.Add(key, node); 
		}
	}
}

internal class Node 
{
	public Node Previous { get; set; } = null; 
	public Node Next { get; set; } = null; 
	public int Key { get; set; }
	public int Value { get; set; }
	public long LastAccessed { get; set; }
}

internal class LRUNodeList 
{
	public Node Head { get; set; }
	
	public Node Tail { get; set; }

	/// <summary> LRU List: Oldest node is head, newest is tail</summary>
	public void Insert(Node node)
	{
		if (Head == null) 
		{
			Head = node; 
			Tail = node;
		}
		else 
		{
			Tail.Next = node; 
			node.Previous = Tail;
			Tail = node;
		}
	}

	/// <summary>Existing node accessed - move to end</summary>
	public void Update(Node node, int value)
	{
		// the head: next node becomes new head, this becomes new tail 
		if (node != Tail && node == Head) 
		{
			Head = node.Next; 
			Tail.Next = node; 
			node.Previous = Tail;
			Tail = node;
		}
		// somewhere in the middle, move to the end
		else if (node != Tail)
		{
			node.Previous.Next = node.Next;
			node.Next.Previous = node.Previous;
			node.Previous = Tail; 
			Tail.Next = node; 
			Tail = node;
		}
		
		node.Value = value;
		node.LastAccessed = DateTime.Now.Ticks;

	}

	/// <summary>Remove LRU node</summary>
	public int Pop()
	{
		int key = -1; 
		if (Head != null && Head == Tail) 
		{
			key = Head.Key;
			Head = null; 
			Tail = null;
		}
		else 
		{
			Node old = Head; 
			Head = old.Next; 
			Head.Previous = null; 
			old.Next = null; 
			key = old.Key;
		}
		
		return key; 
	}
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */

#region private::Tests

/*
Example 1:

Input
["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
Output
[null, null, null, 1, null, -1, null, -1, 3, 4]

Explanation
LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 1); // cache is {1=1}
lRUCache.put(2, 2); // cache is {1=1, 2=2}
lRUCache.get(1);    // return 1
lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
lRUCache.get(2);    // returns -1 (not found)
lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
lRUCache.get(1);    // return -1 (not found)
lRUCache.get(3);    // return 3
lRUCache.get(4);    // return 4
*/

[Fact] 
void Test1() 
{
	LRUCache lRUCache = new LRUCache(2);
	lRUCache.Put(1, 1); // cache is {1=1}
	lRUCache.Put(2, 2); // cache is {1=1, 2=2}
	int expected = 1; 
	int result = lRUCache.Get(1);    // return 1
	Assert.Equal(expected, result); 
	lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
	expected = -1;
	result = lRUCache.Get(2);    // returns -1 (not found)
	Assert.Equal(expected, result); 
	lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
	
	result = lRUCache.Get(1);    // return -1 (not found)
	Assert.Equal(expected, result); 
	
	expected = 3;
	result = lRUCache.Get(3);    // return 3
	Assert.Equal(expected, result); 
	
	expected = 4;
	result = lRUCache.Get(4);    // return 4
	Assert.Equal(expected, result); 

}

/*
["LRUCache","put","put","get","put","put","get"]
[[2],[2,1],[2,2],[2],[1,1],[4,1],[2]]

Use Testcase
Output
[null,null,null,1,null,null,-1]
Expected
[null,null,null,2,null,null,-1]
*/

[Fact]
private void Test2() 
{
	LRUCache lRUCache = new LRUCache(2);
	lRUCache.Put(2, 1); 
	lRUCache.Put(2, 2);
	int expected = 2;
	int result = lRUCache.Get(2);
	Assert.Equal(expected, result);
	lRUCache.Put(1, 1); 
	lRUCache.Put(4, 1); 
	expected = -1;
	result = lRUCache.Get(2);    
	Assert.Equal(expected, result);
}

#endregion