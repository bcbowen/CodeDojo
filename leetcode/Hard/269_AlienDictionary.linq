<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public string AlienOrder(string[] words)
	{
		// 'a' (97) - 'z' (122)
		int[] inDegrees = new int[26]; 
		(Dictionary<char, List<char>> adjacencyList, bool invalid) = GetAdjacencyList(words); 
		if (invalid) return ""; 
		
		string result = ""; 
		
		foreach ()
		
	}

	internal (Dictionary<char, List<char>>, bool) GetAdjacencyList(string[] words) 
	{
		bool found = false;
		Dictionary<char, List<char>> adjacencyList = new Dictionary<char, System.Collections.Generic.List<char>>(); 
		bool invalid = false;
		int i = 0; 
		do
		{
			found = false;
			// check 
			for (int j = 1; j < words.Length; j++)
			{
				string word1 = words[j - 1]; 
				string word2 = words[j]; 
				if (i < word1.Length && i < word2.Length && word1[i] != word2[i])
				{
					if (!adjacencyList.ContainsKey(word1[i]))
					{
						adjacencyList.Add(word1[i], new List<char>()); 
					}

					if (!adjacencyList[word1[i]].Contains(word2[i]))
					{
						adjacencyList[word1[i]].Add(word2[i]);
						found = true;
					}
	
					// if there is another edge coming the other way this is invalid - there is a cycle
					if (adjacencyList.ContainsKey(word2[i]) && adjacencyList[word2[i]].Contains(word1[i])) 
					{
						invalid = true;
						break;
					}
				}
			}
		} while (found && !invalid);
		
		return (adjacencyList, invalid); 
	}
}




/*
Input: words = ["wrt","wrf","er","ett","rftt"]
Output: "wertf"


w-e
e-r
t-f
r-t

w - e - r - t - f
*/

[Theory]
[InlineData(new[] {"wrt","wrf","er","ett","rftt"}, "wertf")]
[InlineData(new[] {"z","x"}, "zx")]
[InlineData(new[] {"z","x","z"}, "")]
void Test(string[] words, string expected) 
{
	string result = new Solution().AlienOrder(words);
	Assert.Equal(expected, result); 
}
