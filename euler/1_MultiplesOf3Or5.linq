<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.

	/*
	If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
	The sum of these multiples is 23.
	
	Find the sum of all the multiples of 3 or 5 below 1000.
	
	# 970075 
	*/
	 int total = new Solution().GetTotal(1000); 
	 Console.WriteLine(total); 
	
	
}

class Solution 
{
	public int GetTotal(int limit) 
	{
		int total = 0;

		total += GetTotal(3, limit); 
		total += GetTotal(5, limit); 
		total -= GetTotal(15, limit); 
		
		return total;
	}


	internal int GetTotal(int increment, int limit) 
	{
		int val = increment;
		int total = 0; 
		while (val < limit) 
		{
			total += val;  
			val += increment; 
		}
		
		return total;
	}

}

// You can define other methods, fields, classes and namespaces here

#region private::Tests

[Theory] 
[InlineData(10, 23)]
[InlineData(15, 45)]
[InlineData(16, 60)]
void Test(int limit, int expected) 
{
	int result = new Solution().GetTotal(limit); 
	Assert.Equal(expected, result);
}

#endregion