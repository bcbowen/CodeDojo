<Query Kind="Program" />

void Main()
{
	/*
	Input: arr = [17,18,5,4,6,1]
Output: [18,6,6,6,1,-1]

Input: arr = [400]
Output: [-1]
	
	*/
	Test(new[] {17,18,5,4,6,1 }, new[] {18,6,6,6,1,-1});
	Test(new[] {400 }, new[] {-1});
}

public void Test(int[] arr, int[] expected) 
{
	Console.WriteLine("Original");
	arr.Dump();
	
	new Solution().ReplaceElements(arr);
	
	Console.WriteLine("After");
	arr.Dump();
	
	Console.WriteLine("Expected");
	expected.Dump();
}

public class Solution
{
	public int[] ReplaceElements(int[] arr)
	{
		
		for(int i = 0; i < arr.Length; i++) 
		{
			int max = GetMax(arr, i);
			arr[i] = max;
		}

		return arr;
	}

	private int GetMax(int[] arr, int index)
	{
		int max = -1;
		if (index < arr.Length -1) 
		{
			for(int i = index + 1; i < arr.Length; i++)
			{
				if(arr[i] > max) max = arr[i];
			}
		}
				
		return max;
	}
}