<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
}

internal class Project 
{
	public int Profit { get; set; }
	public int Capital { get; set; }
	public Project(int profit, int capital) 
	{
		Profit = profit; 
		Capital = capital; 
	}
}

public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital)
{
	PriorityQueue<Project, int> projects = new PriorityQueue<Project, int>();
	Dictionary<int, List<Project>> futureProjects = new Dictionary<int, List<Project>>(); 
	
	for (int i = 0; i < capital.Length; i++)
	{
		Project project = new Project(profits[i], capital[i]); 
		if (capital[i] <= w) 
		{
			projects.Enqueue(project, -profits[i]);
		}
		else
		{
			if (!futureProjects.ContainsKey(capital[i])) 
			{
				futureProjects.Add(capital[i], new List<Project>()); 
			}
			futureProjects[capital[i]].Add(project);
		}
		
	}
	for (int jobs = 0; jobs < k; jobs++)
	{
		foreach (int i in futureProjects.Keys.Where(key => futureProjects[key].Count > 0 && key <= w))
		{
			foreach (Project p in futureProjects[i]) 
			{
				projects.Enqueue(p, -p.Profit);
			}
			futureProjects.Remove(i);
		}
		// if there are no projects in budget, we're done
		if (projects.Count == 0) break; 
		w += projects.Dequeue().Profit;
	}

	return w;
}

/*
Input: k = 2, w = 0, profits = [1,2,3], capital = [0,1,1]
Output: 4


Input: k = 3, w = 0, profits = [1,2,3], capital = [0,1,2]
Output: 6
*/
[Theory]
[InlineData(1, 2, new[] { 1, 2, 3 }, new[] { 1, 1, 2 }, 5)]
[InlineData(1, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 2 }, 1)]
[InlineData(1, 0, new[] { 1, 2, 3 }, new[] { 1, 1, 2 }, 0)]
[InlineData(2, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 1 }, 4)]
[InlineData(3, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 2 }, 6)]
[InlineData(10, 0, new[] { 1, 2, 3 }, new[] { 0, 1, 2 }, 6)]
void Test(int k, int w, int[] profits, int[] capital, int expected)
{
	int result = FindMaximizedCapital(k, w, profits, capital);
	Assert.Equal(expected, result);
}

[Fact]
void Test12()
{
	int k = 1;
	int w = 2;
	int[] profits = new[] { 1, 2, 3 };
	int[] capital = new[] {1, 1, 2};
	int expected = 5; 
	int result = FindMaximizedCapital(k, w, profits, capital); 
	Assert.Equal(expected, result); 
}

[Fact]
/// <summary>Test case 32 causes TLE: 10000 random capital less than 10000 and 10000 profits of 10000</summary>
void Test32() 
{
	int k = 10000; 
	int w = 10000; 
	int[] profits = new int[10000]; 
	int[] capital = new int[10000];
	for (int i = 0; i < 10000; i++) profits[i] = 10000; 
	Random r = new Random(); 
	for(int i = 0; i < 10000; i++) capital[i] = r.Next(2000, 9999); 
	int expected = 100_010_000; 
	int result = FindMaximizedCapital(k, w, profits, capital); 
	Assert.Equal(expected, result); 
}
