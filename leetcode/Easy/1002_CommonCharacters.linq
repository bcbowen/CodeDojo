<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public IList<string> CommonChars(string[] words)
{

}

/*
Example 1:

Input: words = ["bella","label","roller"]
Output: ["e","l","l"]
Example 2:

Input: words = ["cool","lock","cook"]
Output: ["c","o"]
*/

[Theory]
[InlineData(new[] {}, new[] {})]
[InlineData(new[] {}, new[] {})]
void Test(string[] words, string[] expected) 
{
	List<string> result = CommonChars(words).ToList();
	Assert.Equal(result.Count, expected.Length);
	foreach(string c in result) 
	{
		Assert.True(expected.Contains(c)); 
	}
	
}