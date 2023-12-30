<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
	int result = GetSmallestMultiple(20);
	Console.WriteLine($"Result: {result}"); 
}

int GetSmallestMultiple(int largestFactor) 
{
	if (largestFactor < 1 || largestFactor > 30) throw new ArgumentOutOfRangeException("Let's not get carried away here");
	int result; 
	for (result = largestFactor; result < int.MaxValue - largestFactor; result += largestFactor)
	{
		bool found = true;
		for (int i = largestFactor; i > 0; i--) 
		{
			if (result % i > 0)
			{
				found = false;
				break; 	
			}
		}
		if (found) return result;
	}
	
	return -1; 
}

bool IsSolution(int largestFactor, int val) 
{
	for (int i = largestFactor; i > 0; i--) 
	{
		if (val % i != 0) return false;
	}
	
	return true;
}


[Theory]
[InlineData(10, 2520, true)]
[InlineData(10, 100,  false)]
void IsSolutionTest(int largestFactor, int val, bool expected) 
{
	bool result = IsSolution(largestFactor, val); 
	Assert.Equal(expected, result); 
}

[Fact]
void Test()
{
	int expected = 2520; 
	int result = GetSmallestMultiple(10); 
	Assert.Equal(expected, result); 
}