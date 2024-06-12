<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests(); 
	Part1(); 
}

void Part1() 
{
	int valids = CountValidTriangles("input.txt");
	Console.WriteLine($"Part1 valid count: {valids}"); 
}

private int CountValidTriangles(string fileName) 
{
	int valids = 0; 
	List<(int, int, int)> triangles = LoadTriangles(fileName);
	foreach ((int a, int b, int c) triangle in triangles) 
	{
		if (IsValid(triangle.a, triangle.b, triangle.c)) valids++; 
	}
	return valids; 
}

private bool IsValid(int a, int b, int c) 
{
	if (a + b < c) return false; 
	if (a + c < b) return false; 
	if (c + b < a) return false; 
	return true;
}

private List<(int, int, int)> LoadTriangles(string filename) 
{
	List<(int, int, int)> triangles = new List<(int, int, int)>(); 
	string path = Path.Combine(Utility.GetInputDirectory(), filename);
	string[] lines = File.ReadAllLines(path);
	string pattern = @"\s*(\d+)\s+(\d+)\s+(\d+)"; 
	foreach (string line in lines) 
	{
		Match match = Regex.Match(line, pattern); 
		//match.Dump(); 
		triangles.Add((int.Parse(match.Groups[1].Value),int.Parse(match.Groups[2].Value),int.Parse(match.Groups[3].Value))); 
	}
	
	return triangles; 
}

[Fact]
void Test() 
{
	int valids = CountValidTriangles("sample.txt"); 
	int expected = 0; 
	Assert.Equal(expected, valids); 
}

