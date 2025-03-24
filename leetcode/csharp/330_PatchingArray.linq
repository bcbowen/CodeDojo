<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  
}

public int MinPatches(int[] nums, int n)
{
	SortedList workingList = new SortedList();
	foreach (int num in nums) 
	{
		workingList.Add(num, num); 	
	}
	
	for (int i = 1; i <= n; i++) 
	{
		
	}
}

/*

Input: nums = [1,3], n = 6
Output: 1

Input: nums = [1,5,10], n = 20
Output: 2

Input: nums = [1,2,2], n = 5
Output: 0

*/

[Theory]

void Test(int[] nums, int n, int expected) 
{
	int result = MinPatches(nums, n);
	Assert.Equal(expected, result);
}
