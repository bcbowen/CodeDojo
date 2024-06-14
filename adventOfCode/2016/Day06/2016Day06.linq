<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests();
	Part1();
	Part2();
}

void Part1() 
{
	string message = RecoverMessage("input.txt");
	Console.WriteLine($"Part1: {message}"); 
}

void Part2()
{
	string message = RecoverMessage2("input.txt");
	Console.WriteLine($"Part2: {message}");
}

string RecoverMessage(string fileName) 
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName); 
	string[] lines = File.ReadAllLines(path); 
	int len = lines[0].Length;
	Dictionary<char, int>[] charCounts = new Dictionary<char, int>[len];

	for (int i = 0; i < charCounts.Length; i++) 
	{
		charCounts[i] = new Dictionary<char, int>(); 
	}

	foreach (string line in lines)
	{
		for (int i = 0; i < line.Length; i++) 
		{
			Dictionary<char, int> d = charCounts[i]; 
			char c = line[i]; 
			if (!d.ContainsKey(c)) d.Add(c, 0); 
			d[c]++; 
		}
	}

	StringBuilder result = new StringBuilder();
	for (int i = 0; i < len; i++) 
	{
		Dictionary<char, int> d = charCounts[i]; 
		result.Append(d.OrderByDescending(d => d.Value)
		.ThenBy(d => d.Key)
		.Select(d => d.Key)
		.First());
	}
	
	return result.ToString(); 
}

string RecoverMessage2(string fileName)
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	int len = lines[0].Length;
	Dictionary<char, int>[] charCounts = new Dictionary<char, int>[len];

	for (int i = 0; i < charCounts.Length; i++)
	{
		charCounts[i] = new Dictionary<char, int>();
	}

	foreach (string line in lines)
	{
		for (int i = 0; i < line.Length; i++)
		{
			Dictionary<char, int> d = charCounts[i];
			char c = line[i];
			if (!d.ContainsKey(c)) d.Add(c, 0);
			d[c]++;
		}
	}

	StringBuilder result = new StringBuilder();
	for (int i = 0; i < len; i++)
	{
		Dictionary<char, int> d = charCounts[i];
		result.Append(d.OrderBy(d => d.Value)
		.ThenBy(d => d.Key)
		.Select(d => d.Key)
		.First());
	}

	return result.ToString();
}



[Fact]
void TestPart1()
{
	string expected = "easter";
	string result = RecoverMessage("sample.txt"); 
	Assert.Equal(expected, result); 
}
