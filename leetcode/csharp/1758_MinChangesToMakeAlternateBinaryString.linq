<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int MinOperations(string s)
{
	int opCount = 0;
	int min; 
	for(int i = 0; i < s.Length; i++) 
	{
		char expected = (i % 2 == 0) ? '0' : '1'; 
		if (s[i] != expected) opCount++; 
	}
	min = opCount;
	opCount = 0;
	for (int i = 0; i < s.Length; i++)
	{
		char expected = (i % 2 == 0) ? '1' : '0';
		if (s[i] != expected) opCount++;
	}
	return Math.Min(min, opCount); 
}

/*
Example 1:

Input: s = "0100"
Output: 1
Explanation: If you change the last character to '1', s will be "0101", which is alternating.
Example 2:

Input: s = "10"
Output: 0
Explanation: s is already alternating.
Example 3:

Input: s = "1111"
Output: 2
Explanation: You need two operations to reach "0101" or "1010".
*/

[Theory]
[InlineData("0100", 1)]
[InlineData("10", 0)]
[InlineData("1111", 2)]
void Test(string value, int expected) 
{
	int result = MinOperations(value); 
	Assert.Equal(expected, result); 
}