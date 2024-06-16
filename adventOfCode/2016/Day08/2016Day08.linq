<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities"
void Main()
{
	RunTests();
	char[][] screen = Part1();
	Part2(screen); 
}

char[][] Part1() 
{
	char[][] screen = ProcessLogin("input.txt", 50, 6);
	int pixelsOn = CountPixels(screen); 
	Console.WriteLine($"Part1: {pixelsOn} pixels on");
	return screen; 
}

void Part2(char[][] screen)
{
	foreach(char[] row in screen)
	{
		foreach (char c in row) 
		{
			Console.Write(c); 		
		}
		Console.WriteLine(); 
	}
}

char[][] ProcessLogin(string fileName, int columns, int rows) 
{
	char[][] screen = InitScreen(columns, rows); 
	string path = Path.Combine(Utility.GetInputDirectory(), fileName); 
	string[] commands = File.ReadAllLines(path); 
	foreach(string command in commands)
	{
		ProcessCommand(command, screen); 
	}
	return screen; 
}

/// <summary>
/// rect 3x2
/// rotate row y=4 by 8
/// rotate column x=45 by 1
/// </summary>
void ProcessCommand(string command, char[][] screen) 
{
	string[] fields = command.Split(' ');
	int x; 
	int y;
	int value; 
	if (fields[0] == "rect")
	{ 
		string[] size = fields[1].Split('x'); 
		x = int.Parse(size[0]); 
		y = int.Parse(size[1]); 
		Rect(screen, x, y); 
	}
	else if (fields[1] == "row")
	{
		value = int.Parse(fields[4]);
		y = int.Parse(fields[2].Split('=')[1]);
		RotateRow(screen, y, value); 
	}
	else if (fields[1] == "column") 
	{
		value = int.Parse(fields[4]);
		x = int.Parse(fields[2].Split('=')[1]); 
		RotateColumn(screen, x, value); 
	}
	else
	{
		throw new ArgumentException($"Unrecognized command: {command}"); 	
	} 
	
	
}

void RotateColumn(char[][] screen, int x, int value)
{
	char[] rotated = new char[screen.Length];
	// rotate bottom values up
	for (int i = 0; i < value; i++) 
	{
		rotated[i] = screen[screen.Length - value + i][x];
	}
	// rotate top values down
	for (int i = value; i < screen.Length; i++) 
	{
		rotated[i] = screen[i - value][x];
	}
	// update values on screen
	for (int i = 0; i < screen.Length; i++) 
	{
		screen[i][x] = rotated[i]; 
	}
}

void RotateRow(char[][] screen, int y, int value) 
{
	char[] rotated = new char[screen[y].Length];
	// wraparound
	for (int i = 0; i < value; i++)
	{
		rotated[i] = screen[y][screen[y].Length - value + i];
	}
	// rotate top values down
	for (int i = value; i < screen[y].Length; i++)
	{
		rotated[i] = screen[y][i - value];
	}
	// update values on screen
	for (int i = 0; i < screen[y].Length; i++)
	{
		screen[y][i] = rotated[i];
	}
}

void Rect(char[][] screen, int x, int y)
{
	for (int row = 0; row < y; row++)
	{
		for (int col = 0; col < x; col++) 
		{
			screen[row][col] = '#'; 
		}
	}
}

char[][] InitScreen(int x, int y) 
{
	char[][] screen = new char[y][];
	for(int i = 0; i < screen.Length; i++)
	{
		screen[i] = new char[x];
		for(int j = 0; j < x; j++) 
		{
			screen[i][j] = '.'; 
		}
	}
	
	return screen; 
}

int CountPixels(char[][] screen) 
{
	int count = 0;
	foreach (char[] row in screen)
	{
		foreach (char cell in row)
		{
			if (cell == '#') count++; 
		}
	}
	return count; 
}

[Fact]
void Test() 
{
	char[][] screen = ProcessLogin("sample.txt", 7, 3);
	char[][] expected = 
	[
		['.', '#', '.', '.','#','.','#'], 
		['#', '.', '#', '.','.','.','.'], 
		['.', '#', '.', '.','.','.','.']
	];

	for (int y = 0; y < screen.Length; y++)
	{
		for (int x = 0; x < screen[y].Length; x++) 
		{
			Assert.Equal(expected[y][x], screen[y][x]); 
		}
	}
	
	int expectedOn = 6; 
	int on = CountPixels(screen); 
	Assert.Equal(expectedOn, on); 
}

[Fact]
void InitScreenTest() 
{
	char[][] screen = InitScreen(7, 3); 
	int expectedWidth = 7; 
	int expectedHeight = 3;
	Assert.Equal(expectedHeight, screen.Length); 
	Assert.Equal(expectedWidth, screen[0].Length);
	Assert.Equal('.', screen[2][2]); 
}

[Fact]
void RectTest() 
{
	char[][] screen = InitScreen(7, 3); 
	Rect(screen, 3, 2);
	// area from 0,0 to 1, 2 is on
	for (int y = 0; y < 2; y++)
	{
		for (int x = 0; x < 3; x++) 
		{
			Assert.Equal('#', screen[y][x]); 
		}
	}

	// area from 2, 0 to 2, 2 is off
	for (int x = 0; x < 3; x++) 
	{
		Assert.Equal('.', screen[2][x]); 
	}

	// area from 0, 3 to 2, 6 is off
	for (int y = 0; y < 3; y++)
	{
		for (int x = 3; x < 7; x++) 
		{
			Assert.Equal('.', screen[y][x]); 
		}
	}
	
}

[Fact]
void RotateColumnTest() 
{
	char[][] screen = InitScreen(7, 3);
	Rect(screen, 3, 2); 
	RotateColumn(screen, 1, 1);
	Assert.Equal('.', screen[0][1]);
	Assert.Equal('#', screen[1][1]);
	Assert.Equal('#', screen[2][1]);

	RotateColumn(screen, 1, 1);
	Assert.Equal('#', screen[0][1]);
	Assert.Equal('.', screen[1][1]);
	Assert.Equal('#', screen[2][1]);
}

[Fact]
void RotateRowTest()
{
	char[][] screen = InitScreen(7, 3);
	Rect(screen, 3, 2);
	RotateRow(screen, 0, 4);
	Assert.Equal('.', screen[0][1]);
	Assert.Equal('#', screen[0][4]);
	Assert.Equal('#', screen[0][5]);
	Assert.Equal('#', screen[0][6]);

	RotateRow(screen, 0, 1);
	Assert.Equal('#', screen[0][0]);
	Assert.Equal('.', screen[0][1]);
	Assert.Equal('#', screen[0][5]);
	Assert.Equal('#', screen[0][6]);
}