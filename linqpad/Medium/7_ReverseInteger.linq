<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

// You can define other methods, fields, classes and namespaces here

/*
Example 1:
Input: x = 123
Output: 321

Example 2:
Input: x = -123
Output: -321

Example 3:
Input: x = 120
Output: 21


max Value = 2147483647
uint max Value = 4294967295
*/

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

