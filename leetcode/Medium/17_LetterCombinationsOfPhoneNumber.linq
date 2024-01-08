<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public IList<string> LetterCombinations(string digits)
{
	List<string> list = new List<string>(); 
	if (string.IsNullOrEmpty(digits)) return list;

	Dictionary<int, string> letters = new Dictionary<int, string>();
	letters.Add(2, "abc");
	letters.Add(3, "def");
	letters.Add(4, "ghi");
	letters.Add(5, "jkl");
	letters.Add(6, "mno");
	letters.Add(7, "pqrs");
	letters.Add(8, "tuv");
	letters.Add(9, "wxyz");
}

/*
Example 1:
Input: digits = "23"
Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]

Example 2:
Input: digits = ""
Output: []

Example 3:
Input: digits = "2"
Output: ["a","b","c"]
*/

[Theory]
[InlineData("23", new[] {"ad","ae","af","bd","be","bf","cd","ce","cf"})]
[InlineData("", new string[0])]
[InlineData("2", new[] {"a","b","c"})]
void Test(string digits, string[] expected) 
{
	string[] result = LetterCombinations(digits).ToArray(); 
	Assert.Equal(expected, result); 
}

