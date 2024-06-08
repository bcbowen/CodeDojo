<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests(); 

}

/// <summary>
/// Combination of substrings starting and ending with the same character can be found by adding the number of occurrences subtracting 1 until we reach 1
/// ex: aaaa
/// 	* aaaa
/// 	* aaa 
/// 	* aa
/// 	* a
/// 	4 + 3 + 2 + 1 = 10
/// 	(n*(n+1))/2 = 20/2 = 10
/// </summary>
public long NumberOfSubstrings(string s)
{
	if (s.Length == 1) return 1;

	Dictionary<char, long> counts = new Dictionary<char, long>();
	foreach(char c in s) 
	{
		if (!counts.ContainsKey(c)) counts.Add(c, 0);
		counts[c]++; 
	}

	long result = 0;
	foreach(char c in counts.Keys) 
	{
		result += (counts[c] * (counts[c] + 1))/2;
	}
	
	return result; 
	
}


/*

Input: s = "abcba"
Output: 7

Input: s = "abacad"
Output: 9

Input: s = "a"
Output: 1
*/

[Theory]
[InlineData("abcba", 7)]
[InlineData("abacad", 9)]
[InlineData("s", 1)]
void Test(string s, long expected) 
{
	long result = NumberOfSubstrings(s); 
	Assert.Equal(expected, result); 
	
}
