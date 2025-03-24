<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int[] CountBits(int n)
{
	int[] bitCounts = new int[n + 1];
	bitCounts[0] = 0;
	for (int i = 1; i <= n; i++)
	{
		if (i % 2 == 1) 
		{
			bitCounts[i] = bitCounts[i - 1] + 1;
		}
		else
		{
			bitCounts[i] = bitCounts[i/2];			
		}
	}
	
	return bitCounts; 
}

/*
Example 1:
Input: n = 2
Output: [0,1,1]
Explanation:
0 --> 0
1 --> 1
2 --> 10

Example 2:
Input: n = 5
Output: [0,1,1,2,1,2]
Explanation:
0 --> 0
1 --> 1
2 --> 10
3 --> 11
4 --> 100
5 --> 101
*/

[Theory]
[InlineData(2, new[] {0,1,1})]
[InlineData(5, new[] {0,1,1,2,1,2})]
void Test(int n, int[] expected) 
{
	int[] result = CountBits(n); 
	Assert.Equal(expected, result); 
}

