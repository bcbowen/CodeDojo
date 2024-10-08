<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Part1("input.txt");
	Part2("input.txt");
}

// You can define other methods, fields, classes and namespaces here

int Part1(string fileName)
{

	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	string pattern = @"\b\d+\b";
	MatchCollection matches = Regex.Matches(lines[0], pattern);
	int[] times = new int[matches.Count];
	for (int i = 0; i < matches.Count; i++)
	{
		times[i] = int.Parse(matches[i].Value);
	}
	int[] distances = new int[matches.Count];
	matches = Regex.Matches(lines[1], pattern);
	for (int i = 0; i < matches.Count; i++)
	{
		distances[i] = int.Parse(matches[i].Value);
	}

	int[] results = new int[distances.Length];
	for (int i = 0; i < results.Length; i++)
	{
		for (int j = 1; j < times[i]; j++)
		{
			long distance = calcDistance(j, times[i]);
			if (distance > distances[i]) results[i]++;
		}
	}

	int result = results.Aggregate((result, next) => result * next);
	Console.WriteLine($"Part1: {result}");
	return result;
}

int Part2(string fileName)
{

	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	string pattern = @"\b\d+\b";
	MatchCollection matches = Regex.Matches(lines[0], pattern);
	int[] times = new int[matches.Count];
	for (int i = 0; i < matches.Count; i++)
	{
		times[i] = int.Parse(matches[i].Value);
	}
	int[] distances = new int[matches.Count];
	matches = Regex.Matches(lines[1], pattern);
	for (int i = 0; i < matches.Count; i++)
	{
		distances[i] = int.Parse(matches[i].Value);
	}

	int combinedTime = int.Parse(times.Aggregate("", (result, val) => result + val.ToString()));
	long combinedDistance = long.Parse(distances.Aggregate("", (result, val) => result + val.ToString()));

	int result = 0;
	for (int i = 1; i < combinedTime; i++)
	{
		long distance = calcDistance(i, combinedTime);
		if (distance > combinedDistance) result++;

	}

	Console.WriteLine($"Part2: {result}");
	return result;
}

long calcDistance(int chargeTime, int totalTime)
{
	long moveTime = totalTime - chargeTime;
	return moveTime * chargeTime;
}

[Fact]
void Part1Test()
{
	int expected = 288;
	int result = Part1("sample.txt");
	Assert.Equal(expected, result);
}

[Fact]
void Part2Test()
{
	int expected = 71503;
	int result = Part2("sample.txt");
	Assert.Equal(expected, result);
}