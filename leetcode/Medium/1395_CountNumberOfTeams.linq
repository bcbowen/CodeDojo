<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int NumTeams(int[] rating)
{

}


/*
Example 1:
Input: rating = [2,5,3,4,1]
Output: 3
Explanation: We can form three teams given the conditions. (2,3,4), (5,4,1), (5,3,1). 

Example 2:
Input: rating = [2,1,3]
Output: 0
Explanation: We can't form any team given the conditions.

Example 3:
Input: rating = [1,2,3,4]
Output: 4
*/

[Theory]
[InlineData(new[] { 2, 5, 3, 4, 1 }, 3)]
[InlineData(new[] { 2, 1, 3 }, 0)]
[InlineData(new[] { 1, 2, 3, 4 }, 4)]
void Test(int[] rating, int expected)
{
	int result = NumTeams(rating);
	Assert.Equal(expected, result);
}

