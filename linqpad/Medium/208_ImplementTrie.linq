<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Trie
{
	internal class Node
	{
		public Node()
		{
			Nodes = new Dictionary<char, Node>();
		}

		public char Value { get; set; }
		public Dictionary<char, Node> Nodes {get; set;}
		public bool IsFinal {get; set;}
	}
	
	public Trie()
	{
		_root = new Node();
	}

	private Node _root; 

	public void Insert(string word)
	{
		Node node = _root;
		foreach(char c in word)
		{
			if (!node.Nodes.ContainsKey(c))
			{
				node.Nodes.Add(c, new Node());
			}
			node = node.Nodes[c];
		}
		node.IsFinal = true;
		
	}

	public bool Search(string word)
	{
		Node node = _root;
		foreach(char c in word) 
		{
			if (!node.Nodes.ContainsKey(c)) return false;
			node = node.Nodes[c];
		}
		if (!node.IsFinal) return false;
		
		return true;
	}

	public bool StartsWith(string prefix)
	{
		Node node = _root;
		foreach (char c in prefix)
		{
			if (!node.Nodes.ContainsKey(c)) return false;
			node = node.Nodes[c];
		}

		return true;
	}
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */

#region private::Tests

[Fact]
void Test() 
{
	Trie trie = new Trie();
	trie.Insert("apple");
	bool expected = true;
	bool result = trie.Search("apple");   // return True
	Assert.Equal(expected, result);
	expected = false;
	result = trie.Search("app");     // return False
	Assert.Equal(expected, result);
	expected = true;
	result = trie.StartsWith("app"); // return True
	Assert.Equal(expected, result);
	trie.Insert("app");
	
	result = trie.Search("app");     // return True
	Assert.Equal(expected, result);
}

/*
Example 1:

Input
["Trie", "insert", "search", "search", "startsWith", "insert", "search"]
[[], ["apple"], ["apple"], ["app"], ["app"], ["app"], ["app"]]
Output
[null, null, true, false, true, null, true]

Explanation
Trie trie = new Trie();
trie.insert("apple");
trie.search("apple");   // return True
trie.search("app");     // return False
trie.startsWith("app"); // return True
trie.insert("app");
trie.search("app");     // return True

*/

#endregion