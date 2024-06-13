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
	int valids = CountValidTriangles("input.txt");
	Console.WriteLine($"Part1 valid count: {valids}"); 
}

void Part2() 
{
	List<(int, int, int)> triangles = LoadTriangles("input.txt");
	int count = 0; 
	for(int i = 0; i < triangles.Count - 2; i += 3) 
	{
		if (IsValid(triangles[i].Item1, triangles[i + 1].Item1, triangles[i + 2].Item1)) count++; 
		if (IsValid(triangles[i].Item2, triangles[i + 1].Item2, triangles[i + 2].Item2)) count++; 
		if (IsValid(triangles[i].Item3, triangles[i + 1].Item3, triangles[i + 2].Item3)) count++; 
	}

	Console.WriteLine($"Count valid vertical triangles: {count}"); 
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
	if (a + b <= c) return false; 
	if (a + c <= b) return false; 
	if (c + b <= a) return false; 
	return true;
}

private List<(int, int, int)> LoadTriangles(string filename) 
{
	List<(int, int, int)> triangles = new List<(int, int, int)>(); 
	string path = Path.Combine(Utility.GetInputDirectory(), filename);
	string[] lines = File.ReadAllLines(path);
	string pattern = @"\s*(\d+)\s+(\d+)\s+(\d+)"; 
	int lineCount = 0; 
	foreach (string line in lines) 
	{
		Match match = Regex.Match(line, pattern); 
		//match.Dump(); 
		int a = int.Parse(match.Groups[1].Value);
		int b = int.Parse(match.Groups[2].Value);
		int c = int.Parse(match.Groups[3].Value);
		triangles.Add((a, b, c));
		//Console.WriteLine($"line: {line} parsed: {a} {b} {c}");
		lineCount++;
	}
	Console.WriteLine($"{lineCount} lines parsed. "); 
	return triangles; 
}


/*
  5  10  25 I
  5  10  7 V
  7  10  5 V
  10  7  5 V
  5  3  8 I
  5  8  3 I
  3  5  8 I
  8  3  5 I
*/
[Fact]
void Test() 
{
	int valids = CountValidTriangles("sample.txt"); 
	int expected = 3; // Vs above 
	Assert.Equal(expected, valids); 
}

