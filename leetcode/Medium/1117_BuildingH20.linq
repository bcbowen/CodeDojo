<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

// You can define other methods, fields, classes and namespaces here

#region private::Tests

[Fact] void Test_Xunit() => Assert.True (1 + 1 == 2);

#endregion