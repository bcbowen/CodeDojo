<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public bool IsPowerOfFour(int n)
{
	if (n == 0) return false;
	double r = (double)n;
	for (int i = 0; i < 2; i++)
	{
		r = Math.Sqrt(r);
		if (!IsInt(r)) return false;
	}
	
	return true; 
	
}

private bool IsInt(double d) 
{
	return d % 1 == 0; 
}


/*
Example 1:

Input: n = 16
Output: true
Example 2:

Input: n = 5
Output: false
Example 3:

Input: n = 1
Output: true
*/

[Theory]
[InlineData(16, true)]
[InlineData(5, false)]
[InlineData(1, true)]
[InlineData(625, true)]
void Test(int n, bool expected) 
{
	bool result = IsPowerOfFour(n); 
	Assert.Equal(expected, result); 
}

