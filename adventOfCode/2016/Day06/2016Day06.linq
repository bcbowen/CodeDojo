<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests();  
}

// You can define other methods, fields, classes and namespaces here


[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);
