<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

static void Main(String[] args)
{
	RunTests(); 
}

internal static long GetSumOfMultiples(int n) 
{
	long multiplesOf3 = (n - 1) / 3;
	long multiplesOf5 = (n - 1) / 5;
	long multiplesOf15 = (n - 1) / 15;
	
	long sumOf3 = 3 * multiplesOf3 * (multiplesOf3 + 1) / 2;
	long sumOf5 = 5 * multiplesOf5 * (multiplesOf5 + 1) / 2;
	long sumOf15 = 15 * multiplesOf15 * (multiplesOf15 + 1) / 2;
	
	return sumOf3 + sumOf5 - sumOf15;
}

[Theory]
[InlineData(10, 23)]
[InlineData(100, 2318)]
[InlineData(15, 45)]
[InlineData(16, 60)]
[InlineData(1000, 233168)]
void Test(int n, long expected) 
{
	long result = GetSumOfMultiples(n); 
	Assert.Equal(expected, result); 
}

