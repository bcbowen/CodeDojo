<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();
	Part1And2("input.txt", 150); 
}

void Part1And2(string fileName, int total) 
{
	List<int> cups = new List<int>();
	_minContainers = int.MaxValue;
	
	int[] used = new int[0]; 
	string path = Path.Combine(GetQueryDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	foreach (string line in lines) 
	{
		cups.Add(int.Parse(line)); 
	}

	Iterate(cups, used, 0, total);
	Console.WriteLine($"Part1: {_result}");
	Console.WriteLine($"Part2: Min Containers: {_minContainers} Min Count: {_minCount}"); 
}

private int _result = 0; 
private int _minContainers = int.MaxValue; 
private int _minCount = 0; 

void Iterate(List<int> cups, int[] used, int currentTotal, int totalNeeded, int startIndex = 0)
{
	if (currentTotal > totalNeeded) return;
	if (currentTotal == totalNeeded) 
	{
		_result++;
		if (used.Length < _minContainers) 
		{
			_minContainers = used.Length;
			_minCount = 1; 
			//Console.WriteLine($"New min: {_minContainers} from {used.Aggregate("", (result, u) => result + cups[u].ToString() + ' ')}");
		}
		else if (used.Length == _minContainers) 
		{
			_minCount++; 
		}
		
		return;
	}
	
	for(int i = startIndex; i < cups.Count; i++)
	{
		if (!used.Contains(i)) 
		{
			int newTotal = cups[i] + currentTotal;
			int[] usedCopy = new int[used.Length + 1];
			used.CopyTo(usedCopy, 0); 
			usedCopy[usedCopy.Length - 1] = i;
			Iterate(cups, usedCopy, newTotal, totalNeeded, i + 1); 
		}
	}
	return;

}

[Fact]
void Part1Test() 
{
	int expected = 4; 
	Part1And2("sample.txt", 25);
	Assert.Equal(expected, _result); 
}

[Fact]
void Part2Test()
{
	int expected = 2;
	Part1And2("sample.txt", 25);
	Assert.Equal(expected, _minContainers);
	expected = 3; 
	Assert.Equal(expected, _minCount);
}