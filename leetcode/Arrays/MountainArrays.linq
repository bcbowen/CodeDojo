<Query Kind="Program" />

/*
Given an array of integers arr, return true if and only if it is a valid mountain array.

Recall that arr is a mountain array if and only if:

arr.length >= 3
There exists some i with 0 < i < arr.length - 1 such that:
arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
arr[i] > arr[i + 1] > ... > arr[arr.length - 1]

Input: arr = [2,1]
Output: false
Example 2:

Input: arr = [3,5,5]
Output: false
Example 3:

Input: arr = [0,3,2,1]
Output: true
 
*/

void Main()
{
	Test(new[] {2, 1}, false);
	Test(new[] {3,5,5}, false);
	Test(new[] {0,3,2,1}, true);
	Test(new[]{0,1,2,3,4,5,6,7,8,9}, false);
	Test(new[]{9,8,7,6,5,4,3,2,1,0}, false);
}

void Test(int[] arr, bool expected) 
{
	bool result = new Solution().ValidMountainArray(arr);
	if (expected == result) 
	{
		Console.WriteLine("PASS");
	}
	else
	{
		Console.WriteLine($"FAIL, expected {expected}");
	}
}

public class Solution
{
	public bool ValidMountainArray(int[] arr)
	{
		if (arr.Length < 3 || arr[1] <= arr[0]) return false;
		
		int last = arr[0];
		bool increasing = true;
		for (int i = 1; i < arr.Length; i++)
		{
			if (increasing)
			{
				if (arr[i] == last) return false;
				if (arr[i] < last) increasing = false;
			}
			else 
			{
				if (arr[i] >= last) return false;
			}
			last = arr[i];
		}
		return !increasing;
	}
}