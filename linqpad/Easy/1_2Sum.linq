<Query Kind="Program" />

void Main()
{
	Test(new[] { 2, 7, 11, 15 }, new[] {0, 1}, 9);
	Test(new[] { 3, 2, 4 }, new[] {1, 2}, 6);
	Test(new[] { 3, 3 }, new[] { 0, 1 }, 6);
	Test(new[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, new[] {5, 11}, 11);
}

public void Test(int[] nums, int[] expected, int target)
{
	int[] solution = TwoSum(nums, target); 
	Console.WriteLine("Nums:");
	nums.Dump();
	Console.WriteLine("Expected:");
	expected.Dump();
	Console.WriteLine("Result:");
	solution.Dump();
	
}

public int[] TwoSum(int[] nums, int target)
{
	int[] solution = new int[2];
	Dictionary<int, int> map = new Dictionary<int, int>(); 
	for(int i = 0; i < nums.Length; i++)
	{
		int compliment = target - nums[i];
		if(map.ContainsKey(compliment))
		{
			solution[0] = map[compliment];
			solution[1] = i; 
			break;
		}
		else
		{
			if (!map.ContainsKey(nums[i])) 
			{
				map.Add(nums[i], i);	
			}
		}
	}
	
	return solution;
}

public int[] TwoSumBrute(int[] nums, int target)
{
	int[] solution = new int[2];
	bool done = false;
	
	for(int x = 0; x < nums.Length - 1; x++)
	{
		for(int y = x + 1; y < nums.Length; y++)
		{
			if (nums[x] + nums[y] == target) 
			{
				solution[0] = x;
				solution[1] = y;
				done = true;
				break;
			}
		}
		if (done) break;
	}
	return solution;
}