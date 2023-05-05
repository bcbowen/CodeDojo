<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

}

public class Solution
{
	public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
	{
		UnionFind uf = new UnionFind(s.Length);

		// process edges
		foreach (IList<int> edge in pairs) 
		{
			uf.Union(edge[0], edge[1]);
		}

		// group vertices by component
		Dictionary<int, List<int>> rootToComponent = new Dictionary<int, List<int>>();
		for (int vertex = 0; vertex < s.Length; vertex++) 
		{
			int root = uf.Find(vertex);
			if (!rootToComponent.ContainsKey(root)) 
			{
				rootToComponent.Add(root, new List<int>()); 
			}
			rootToComponent[root].Add(vertex);
		}
		
		// string for answer
		char[] smallestString = new char[s.Length]; 
		
		// iterate over each component
		foreach (int key in rootToComponent.Keys)
		{
			List<char> chars = new List<char>();
			foreach (int index in rootToComponent[key]) 
			{
				chars.Add(s[index]);
			}
			chars.Sort();

			// store the sorted chars
			for (int index = 0; index < rootToComponent[key].Count; index++) 
			{
				smallestString[rootToComponent[key][index]] = chars[index];
			}
			
		}
		return new string(smallestString);
		
	}
}


public class UnionFind 
{
	private int[] _root; 
	private int[] _rank; 
	
	public UnionFind(int len)
	{
		_root = new int[len];
		_rank = new int[len];

		for(int i = 0; i < len; i++) 
		{
			_root[i] = i;
		}
	}

	public int Find(int i) 
	{
		if (_root[i] == i) return i; 
		
		// Add path compression to make subsequent calls faster
		return _root[i] = Find(_root[i]);
	}

	public void Union(int i, int j) 
	{
		if (IsConnected(i, j)) return;
		
		int rootI = Find(i); 
		int rootJ = Find(j);

		if (_rank[rootI] >= _rank[rootJ]) 
		{
			_root[rootJ] = _root[rootI];
			_rank[rootI] += _rank[rootJ];
			
		}
		else if (_rank[rootI] < _rank[rootJ])
		{
			_root[rootI] = _root[rootJ];
			_rank[rootJ] += _rank[rootI];
		}
	}

	internal bool IsConnected(int i, int j) 
	{
		return Find(i) == Find(j);
	}
	
}

/*
Example 1:
Input: s = "dcab", pairs = [[0,3],[1,2]]
Output: "bacd"
Explaination: 
Swap s[0] and s[3], s = "bcad"
Swap s[1] and s[2], s = "bacd"

Example 2:
Input: s = "dcab", pairs = [[0,3],[1,2],[0,2]]
Output: "abcd"
Explaination: 
Swap s[0] and s[3], s = "bcad"
Swap s[0] and s[2], s = "acbd"
Swap s[1] and s[2], s = "abcd"

Example 3:
Input: s = "cba", pairs = [[0,1],[1,2]]
Output: "abc"
Explaination: 
Swap s[0] and s[1], s = "bca"
Swap s[1] and s[2], s = "bac"
Swap s[0] and s[1], s = "abc"
*/

[Theory]
[InlineData("dcab", "bacd", new[] { 0, 3}, new[] {1, 2})]
[InlineData("dcab", "abcd", new[] { 0, 3}, new[] {1, 2}, new[] {0, 2})]
[InlineData("cba", "abc", new[] { 0, 1}, new[] {1, 2})]
void Test(string s, string expected, params int[][] pairs) 
{
	string result = new Solution().SmallestStringWithSwaps(s, pairs);
	Assert.Equal(expected, result);
}

private static string GetQueryDirectory()
{
	FileInfo file = new FileInfo(Util.CurrentQueryPath);
	return file.DirectoryName;
}

private static string GetDataDirectoryPath() 
{
	DirectoryInfo queryPath = new FileInfo(Util.CurrentQueryPath).Directory;
	DirectoryInfo dataDirectory = queryPath.Parent.GetDirectories().First(d => d.Name == "Data");
	return dataDirectory.FullName;
}

/// <summary>
/// * Without compression, takes ~12.5 seconds
/// * With compression takes ~.09 seconds! 
/// </summary>
[Fact]
void BigTest() 
{
	string path = Path.Combine(GetDataDirectoryPath(), "1202_BigTestString.txt");
	Assert.True(File.Exists(path));
	string s = File.ReadAllText(path);

	path = Path.Combine(GetDataDirectoryPath(), "1202_BigTestPairs.txt");
	Assert.True(File.Exists(path));
	int[][] pairs = JsonConvert.DeserializeObject<int[][]>(File.ReadAllText(path));
	
	path = Path.Combine(GetDataDirectoryPath(), "1202_BigTestExpected.txt");
	Assert.True(File.Exists(path));
	string expected = File.ReadAllText(path);
	string result = new Solution().SmallestStringWithSwaps(s, pairs); 
	Assert.Equal(expected, result);
}
