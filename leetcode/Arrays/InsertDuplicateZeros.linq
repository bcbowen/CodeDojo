<Query Kind="Program" />

void Main()
{
	Test(new[] { 1,0,2,3,0,4,5,0}, new[] {1,0,0,2,3,0,0,4});
	Test(new[] { 1,2,3}, new[] {1,2,3});

}

public void Test(int[] arr, int[] expected) 
{
	Console.WriteLine("arr");
	arr.Dump();
	
	new Solution().DuplicateZeros(arr);
	
	Console.WriteLine("expected");
	expected.Dump();
	
	Console.WriteLine("result");
	arr.Dump();
}

public class Solution
{
	public void DuplicateZeros(int[] arr)
	{
		Queue<int> shifts = new Queue<int>();
		for (int i = 0; i < arr.Length; i++)
		{
			int val = arr[i];
			shifts.Enqueue(val);
			if (val == 0)
			{
				shifts.Enqueue(val);
			}

			arr[i] = shifts.Dequeue();
		}
	}
}