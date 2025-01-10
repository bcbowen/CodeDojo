<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
	{
		Array.Sort(potions);
		int[] result = new int[spells.Length];

		for (int i = 0; i < spells.Length; i++)
		{
			
			int count = 0;

			if ((long)spells[i] * potions[0] >= success)
			{
				count = potions.Length;
			}
			else if ((long)spells[i] * potions[potions.Length - 1] < success)
			{
				count = 0;
			}
			else 
			{
				double target = (double)success / spells[i]; 
				int start = 0;
				int end = potions.Length;
				int mid = 0;
				while (start < end) 
				{
					mid = start + (end - start) / 2;
					if (potions[mid] >= target) 
					{
						end = mid - 1;
					}
					else 
					{
						start = mid + 1;
					}
				}
				if (potions[start] < target) start++; 
				count = potions.Length - start;
			}
			
			result[i] = count;
		}

		return result;
	}
	
	/// <summary>Big test takes > 12 seconds</summary>
	public int[] SuccessfulPairsSlow(int[] spells, int[] potions, long success)
	{
		int[] result = new int[spells.Length];
		Dictionary<int, int> successCache = new Dictionary<int, int>(); 
		for(int i = 0; i < spells.Length; i++) 
		{
			int count = 0;
			if (successCache.ContainsKey(i))
			{
				count = successCache[i];
			}
			else 
			{
				foreach (int potion in potions) 
				{
					if ((long)spells[i] * potion >= success) count++;
				}
				successCache.Add(i, count); 
			}
			
			result[i] =  count;
		}
		
		return result;
	}
}

/*
Example 1:
Input: spells = [5,1,3], potions = [1,2,3,4,5], success = 7
Output: [4,0,3]
Explanation:
- 0th spell: 5 * [1,2,3,4,5] = [5,10,15,20,25]. 4 pairs are successful.
- 1st spell: 1 * [1,2,3,4,5] = [1,2,3,4,5]. 0 pairs are successful.
- 2nd spell: 3 * [1,2,3,4,5] = [3,6,9,12,15]. 3 pairs are successful.
Thus, [4,0,3] is returned.

Example 2:
Input: spells = [3,1,2], potions = [8,5,8], success = 16
Output: [2,0,2]
Explanation:
- 0th spell: 3 * [8,5,8] = [24,15,24]. 2 pairs are successful.
- 1st spell: 1 * [8,5,8] = [8,5,8]. 0 pairs are successful. 
- 2nd spell: 2 * [8,5,8] = [16,10,16]. 2 pairs are successful. 
Thus, [2,0,2] is returned.
*/


[Theory]
[InlineData(new[] { 5, 1, 3 }, new[] { 1, 2, 3, 4, 5 }, 7, new[] { 4, 0, 3 })]
[InlineData(new[] { 3, 1, 2 }, new[] { 8, 5, 8 }, 16, new[] { 2, 0, 2 })]
void Test(int[] spells, int[] potions, int success, int[] expected)
{
	int[] result = new Solution().SuccessfulPairs(spells, potions, success); 
	Assert.Equal(expected, result);
}

[Fact]
void BigTest() 
{
	string path = Path.Combine(GetDataDirectoryPath(), "2300_BigTestPotions.txt");
	Assert.True(File.Exists(path));
	int[] potions = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));

	path = Path.Combine(GetDataDirectoryPath(), "2300_BigTestSpells.txt");
	Assert.True(File.Exists(path));
	int[] spells = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));

	long success = 5433930978;

	path = Path.Combine(GetDataDirectoryPath(), "2300_BigTestExpected.txt");
	Assert.True(File.Exists(path));
	int[] expected = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));

	int[] result = new Solution().SuccessfulPairs(spells, potions, success);
    //File.WriteAllText(path, JsonConvert.SerializeObject(result));	

	Assert.Equal(expected, result);
}

private static string GetDataDirectoryPath()
{
	DirectoryInfo queryPath = new FileInfo(Util.CurrentQueryPath).Directory;
	DirectoryInfo dataDirectory = queryPath.Parent.GetDirectories().First(d => d.Name == "Data");
	return dataDirectory.FullName;
}
