<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

}

public string ReplaceWords(IList<string> dictionary, string sentence)
{
	Node trie = new Node();
	foreach (string word in dictionary) 
	{
		trie.Insert(word); 
	}
	
	string[] words = sentence.Split(' ');
	StringBuilder result = new StringBuilder();
	foreach(string word in words) 
	{
		string next = trie.Find(word);
		if (next != string.Empty) 
		{
			result.Append(next + " ");
		}
		else
		{
			result.Append(word + " ");
		}
	}
	result.Length--;
	
	return result.ToString(); 
}

class Node 
{
	public Node() 
	{
		Nodes = new Dictionary<char, Node>(); 
	}

	public Node(char value) : this()
	{
		Value = value;
	}
	
	public char Value { get; set; }
	public bool IsFinal { get; set; }
	public Dictionary<char, Node> Nodes {get; private set;}

	/// <summary>
	/// Find the longest matching value in the trie
	/// </summary>
	public string Find(string value) 
	{
		Node current = this;
		StringBuilder sb = new StringBuilder();
		string result = string.Empty; 
		foreach(char c in value)
		{
			if (current.Nodes.ContainsKey(c)) 
			{
				current = current.Nodes[c];
				sb.Append(c);
				if (current.IsFinal) 
				{
					result = sb.ToString(); 
					break;
				} 
			}
			else 
			{
				break;
			}
		}
		return result; 
	}

	public void Insert(string word)
	{
		char c = word[0]; 
		if (!Nodes.ContainsKey(c)) 
		{
			Nodes.Add(c, new Node(c)); 
		}
		Node current = Nodes[c];
		if (word.Length == 1) 
		{
			current.IsFinal = true;
		}
		else
		{
			current.Insert(word.Substring(1)); 
		}
	}
}

/*
Example 1:

Input: dictionary = ["cat","bat","rat"], sentence = "the cattle was rattled by the battery"
Output: "the cat was rat by the bat"
Example 2:

Input: dictionary = ["a","b","c"], sentence = "aadsfasf absbs bbab cadsfafs"
Output: "a a b c"

dictionary =
["a", "aa", "aaa", "aaaa"]
sentence =
"a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa"

Expected
"a a a a a a a a bbb baba a"

*/

[Theory]
[InlineData(new[] {"a", "aa", "aaa", "aaaa"}, "a aa a aaaa aaa aaa aaa aaaaaa bbb baba ababa", "a a a a a a a a bbb baba a")]
[InlineData(new[] {"cat","bat","rat"}, "the cattle was rattled by the battery", "the cat was rat by the bat")]
[InlineData(new[] {"a","b","c"}, "aadsfasf absbs bbab cadsfafs", "a a b c")]
void Test(string[] dictionary, string sentence, string expected) 
{
	string result = ReplaceWords(dictionary, sentence); 
	Assert.Equal(expected, result); 
}

