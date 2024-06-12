<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	moves = new Dictionary<char, int[]>();
	moves.Add('U', new[] { -1, 0 });
	moves.Add('D', new[] { 1, 0 });
	moves.Add('L', new[] { 0, -1 });
	moves.Add('R', new[] { 0, 1 });

	/*
		1
	  2 3 4
	5 6 7 8 9
	  A B C
		D
	*/
	keys = new char[5][];
	keys[0] = new[] { ' ', ' ', '1', ' ', ' ' };
	keys[1] = new[] { ' ', '2', '3', '4', ' ' };
	keys[2] = new[] { '5', '6', '7', '8', '9' };
	keys[3] = new[] { ' ', 'A', 'B', 'C', ' ' };
	keys[4] = new[] { ' ', ' ', 'D', ' ', ' ' };
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	string part2 = GetCode("input.txt");
	part2.Dump();
}


static Dictionary<char, int[]> moves;
static char[][] keys;
int[] position = new[] { 2, 0 };

string GetCode(string fileName)
{
	StringBuilder code = new StringBuilder();
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	string[] lines = File.ReadAllLines(path);
	foreach (string line in lines)
	{
		code.Append(ProcessLine(line).ToString());
	}

	return code.ToString();
}

char ProcessLine(string line)
{
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
	if (y >= 0 && y <= 4 && x >= 0 && x <= 4 && keys[y][x] != ' ')
	{
		position[0] = y;
		position[1] = x;
	}
}

[Fact]
void TestPart2()
{
	string expected = "5DB3";
	string result = GetCode("sample.txt");
	Assert.Equal(expected, result);
}

