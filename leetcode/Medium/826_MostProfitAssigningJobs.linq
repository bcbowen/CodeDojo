<Query Kind="Program">
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

class Job 
{
	public Job(int difficulty, int profit) 
	{
		Difficulty = difficulty; 
		Profit = profit; 
	}
	
	public int Difficulty { get; set; }
	public int Profit {get; set;}
}

public int MaxProfitAssignment_1(int[] difficulty, int[] profit, int[] worker)
{
	int maxProfit = 0;
	List<Job> jobs = new List<Job>();
	for (int i = 0; i < difficulty.Length; i++) 
	{
		jobs.Add(new Job(difficulty[i], profit[i]));
	}
	foreach (int w in worker) 
	{
		Job j = jobs.Where(j => j.Difficulty <= w).OrderByDescending(j => j.Profit).FirstOrDefault();
		if (j != null) maxProfit += j.Profit;
	}
	return maxProfit; 
}

public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
{
	int maxProfit = 0;
	
	Array.Sort(worker); 
	
	List<Job> jobs = new List<Job>();
	for (int i = 0; i < difficulty.Length; i++)
	{
		if (difficulty[i] <= worker[^1]) 
		{
			jobs.Add(new Job(difficulty[i], profit[i]));
		}
		
	}
	foreach (int w in worker)
	{
		Job j = jobs.Where(j => j.Difficulty <= w).OrderByDescending(j => j.Profit).FirstOrDefault();
		if (j != null) maxProfit += j.Profit;
	}
	return maxProfit;
}

/*

Input: difficulty = [2,4,6,8,10], profit = [10,20,30,40,50], worker = [4,5,6,7]
Output: 100

Input: difficulty = [85,47,57], profit = [24,66,99], worker = [40,25,25]
Output: 0

*/

[Theory]
[InlineData(new[] { 2, 4, 6, 8, 10 }, new[] { 10, 20, 30, 40, 50 }, new[] { 4, 5, 6, 7 }, 100)]
[InlineData(new[] { 85, 47, 57 }, new[] { 24, 66, 99 }, new[] { 40, 25, 25 }, 0)]
void Test(int[] difficulty, int[] profit, int[] worker, int expected)
{
	int result = MaxProfitAssignment(difficulty, profit, worker);
	Assert.Equal(expected, result);
}

private static string GetDataDirectoryPath()
{
	DirectoryInfo queryPath = new FileInfo(Util.CurrentQueryPath).Directory;
	DirectoryInfo dataDirectory = queryPath.Parent.GetDirectories().First(d => d.Name == "Data");
	return dataDirectory.FullName;
}

/// <summary>
/// Initial implementation takes 2.5 seconds and causes TLE
/// </summary>
[Fact]
void BigTest()
{
	string path = Path.Combine(GetDataDirectoryPath(), "826_Difficulty.txt");
	Assert.True(File.Exists(path));
	int[] difficulty = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));

	path = Path.Combine(GetDataDirectoryPath(), "826_Profit.txt");
	Assert.True(File.Exists(path));
	int[] profit = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));

	path = Path.Combine(GetDataDirectoryPath(), "826_Worker.txt");
	Assert.True(File.Exists(path));
	int[] worker = JsonConvert.DeserializeObject<int[]>(File.ReadAllText(path));

	int expected = 492582978;
	int result = MaxProfitAssignment(difficulty, profit, worker);
	//result.Dump();
	Assert.Equal(expected, result);
}