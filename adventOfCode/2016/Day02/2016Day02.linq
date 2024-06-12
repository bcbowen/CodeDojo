<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	moves = new Dictionary<char, int[]>();
	moves.Add('U', new[] {-1, 0}); 
	moves.Add('D', new[] {1, 0}); 
	moves.Add('L', new[] {0, -1}); 
	moves.Add('R', new[] {0, 1}); 
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	string part1 = GetCode("input.txt"); 
	part1.Dump();
}

static Dictionary<char, int[]> moves;
int[] position = new[]{1, 1};

string GetCode(string fileName)
{
	StringBuilder code = new StringBuilder();
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	foreach(string line in lines)
	{
		code.Append(ProcessLine(line).ToString()); 
	}
	
	return code.ToString(); 
}

int ProcessLine(string line)
{
	int[][] keys = new int[3][];
	keys[0] = new[] { 1, 2, 3 };
	keys[1] = new[] { 4, 5, 6 };
	keys[2] = new[] { 7, 8, 9 };
	
	foreach (char direction in line) 
	{
		Move(direction);
	}	
	return (keys[position[0]][position[1]]);
}

void Move(char direction) 
{
	int y = position[0] + moves[direction][0]; 
	int x = position[1] + moves[direction][1]; 
	if (y >= 0 && y <= 2) position[0] = y; 
	if (x >= 0 && x <= 2) position[1] = x; 
}

[Fact]
void TestPart1() 
{
	string expected = "1985"; 
	string result = GetCode("sample.txt"); 
	Assert.Equal(expected, result);
}

