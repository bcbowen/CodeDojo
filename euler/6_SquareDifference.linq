<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Console.WriteLine($"Result: {GetSumSquareDifference(100)}"); 
}

long GetSumSquareDifference(int count)
{ 
	long sumSquare = 0;
	long squareSum = 0;
	for (int i = 1; i <= count; i++) 
	{
		sumSquare += (i * i); 
		squareSum += i; 
	}
	squareSum *= squareSum; 
	
	return squareSum - sumSquare; 
	
}

[Fact]
void Test() 
{
	long expected = 2640; 
	long result = GetSumSquareDifference(10); 
	Assert.Equal(expected, result); 
	
}

