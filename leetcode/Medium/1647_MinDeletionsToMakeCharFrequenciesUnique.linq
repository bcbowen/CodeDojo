<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int MinDeletions(string s)
{

}

/*
Example 1:

Input: s = "aab"
Output: 0
Explanation: s is already good.
Example 2:

Input: s = "aaabbbcc"
Output: 2
Explanation: You can delete two 'b's resulting in the good string "aaabcc".
Another way it to delete one 'b' and one 'c' resulting in the good string "aaabbc".
Example 3:

Input: s = "ceabaacb"
Output: 2
Explanation: You can delete both 'c's resulting in the good string "eabaab".
Note that we only care about characters that are still in the string at the end (i.e. frequency of 0 is ignored).
*/

#region Tests

[Theory]
[InlineData("aab", 0)]
[InlineData("aaabbbcc", 2)]
[InlineData("ceabaacb", 2)]
void Test(string s, int expected) 
{
	int result = MinDeletions(s); 
	Assert.Equal(expected, result); 
}

#endregion