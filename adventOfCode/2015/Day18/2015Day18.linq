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
	string fileName = "input.txt";
	char[][] grid = LoadGrid(fileName);
	for(int i = 0; i < 100; i++) 
	{
		grid = GetNextGrid(grid); 
	}
	int onCount = 0;
	for (int r = 0; r < grid.Length; r++)
	{
		for(int c = 0; c < grid[r].Length; c++) 
		{
			if (grid[r][c] == ON) onCount++;
		}
	}

	Console.WriteLine($"Part1: {onCount} lights are on"); 
}

char[][] InitGrid(int side) 
{
	char[][] grid = new char[side][];
	for(int i = 0; i < side; i++) 
	{
		grid[i] = new char[side]; 
	}
	return grid; 
}

char[][] LoadGrid(string fileName) 
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName); 
	string[] lines = File.ReadAllLines(path);
	char[][] grid = InitGrid(lines.Length);

	for(int r = 0; r < lines.Length; r++)
	{
		string line = lines[r];
		for(int c = 0; c < lines.Length; c++) 
		{
			grid[r][c] = line[c];
		}
	}
	
	return grid; 
}

char[][] GetNextGrid(char[][] currentGrid) 
{
	char[][] next = InitGrid(currentGrid.Length);
	for(int r = 0; r < currentGrid.Length; r++)
	{
		for (int c = 0; c < currentGrid[r].Length; c++) 
		{
			next[r][c] = GetNextValue(r, c, currentGrid); 
		}
	}
	return next; 
}

bool IsOn(char c) => c == ON; 

const char ON = '#';
const char OFF = '.'; 

char GetNextValue(int r, int c, char[][] currentGrid) 
{
	bool isOn = IsOn(currentGrid[r][c]); 
	
	int connectedOnCount = 0;

	// above
	if (r > 0)
	{
		if (c > 0 && IsOn(currentGrid[r - 1][c - 1])) connectedOnCount++;
		if (IsOn(currentGrid[r - 1][c])) connectedOnCount++;
		if (c < currentGrid[r].Length - 1 && IsOn(currentGrid[r - 1][c + 1])) connectedOnCount++;
	}
	
	// left
	if (c > 0 && IsOn(currentGrid[r][c - 1])) connectedOnCount++;

	// right 
	if (c < currentGrid[r].Length - 1 && IsOn(currentGrid[r][c + 1])) connectedOnCount++;

	// below
	if (r < currentGrid.Length - 1)
	{
		if (c > 0 && IsOn(currentGrid[r + 1][c - 1])) connectedOnCount++;
		if (IsOn(currentGrid[r + 1][c])) connectedOnCount++;
		if (c < currentGrid[r].Length - 1 && IsOn(currentGrid[r + 1][c + 1])) connectedOnCount++;
	}

	// A light which is on stays on when 2 or 3 neighbors are on, and turns off otherwise.
	// A light which is off turns on if exactly 3 neighbors are on, and stays off otherwise.
	if (isOn) 
	{
		return connectedOnCount == 2 || connectedOnCount == 3 ? ON : OFF; 
	}
	else
	{
		return connectedOnCount == 3 ? ON : OFF; 
	}
}


char[][] Init6X6TestGrid(string values) 
{
	char[][] grid = InitGrid(6); 
	int r = 0; 
	int c = 0;
	int i = 0;
	while (i < values.Length) 
	{
		grid[r][c] = values[i];
		i++;
		if (i % 6 == 0) 
		{
			r++; 
			c = 0;
		}
		else 
		{
			c++; 
		}
	}
	return grid; 
}

[Fact]
void InitTestGridTest() 
{
	/*
		.#.#.#
		...##.
		#....#
		..#...
		#.#..#
		####..
	*/
	string values = ".#.#.#...##.#....#..#...#.#..#####.."; 
	char[][] grid = Init6X6TestGrid(values); 
	Assert.Equal(grid[0][0], OFF); 
	Assert.Equal(grid[0][1], ON);

	Assert.Equal(grid[2][1], OFF);
	Assert.Equal(grid[2][5], ON);

	Assert.Equal(grid[5][4], OFF);
	Assert.Equal(grid[5][1], ON);
}


[Theory]
[InlineData(0, 0, '.')]
[InlineData(0, 1, '.')]
[InlineData(0, 2, '#')]
[InlineData(0, 3, '#')]
[InlineData(2, 0, '.')]
[InlineData(2, 1, '.')]
[InlineData(2, 3, '#')]
[InlineData(2, 4, '#')]
[InlineData(5, 0, '#')]
[InlineData(5, 1, '.')]
[InlineData(5, 5, '.')]
void GetNextValueTest(int r, int c, char expected)
{
	/*
		Initial state:
		.#.#.#
		...##.
		#....#
		..#...
		#.#..#
		####..

		After 1 step:
		..##..
		..##.#
		...##.
		......
		#.....
		#.##..
		
		
	*/
	string values = ".#.#.#...##.#....#..#...#.#..#####..";
	char[][] grid = Init6X6TestGrid(values);
	char result = GetNextValue(r, c, grid); 
	Assert.Equal(expected, result); 
}



/*
Initial state:
.#.#.#
...##.
#....#
..#...
#.#..#
####..

After 1 step:
..##..
..##.#
...##.
......
#.....
#.##..

After 2 steps:
..###.
......
..###.
......
.#....
.#....

After 3 steps:
...#..
......
...#..
..##..
......
......

After 4 steps:
......
......
..##..
..##..
......
......
*/

[Fact]
void GetNextGridTest() 
{
	
	/*
		Initial state:
		.#.#.#
		...##.
		#....#
		..#...
		#.#..#
		####..

		After 1 step:
		..##..
		..##.#
		...##.
		......
		#.....
		#.##..


	*/
	string values = ".#.#.#...##.#....#..#...#.#..#####..";
	char[][] grid = Init6X6TestGrid(values);
	char[][] nextGrid = GetNextGrid(grid);
	Assert.Equal(nextGrid[0][0], OFF);
	Assert.Equal(nextGrid[0][1], OFF);

	Assert.Equal(nextGrid[2][1], OFF);
	Assert.Equal(nextGrid[2][4], ON);

	Assert.Equal(nextGrid[5][1], OFF);
	Assert.Equal(nextGrid[5][2], ON);
}

[Fact]
void Testamundo() 
{
	/*
		Initial state:
		.#.#.#
		...##.
		#....#
		..#...
		#.#..#
		####..

		After 4 steps:
		......
		......
		..##..
		..##..
		......
		......

	*/
	string values = ".#.#.#...##.#....#..#...#.#..#####..";
	char[][] grid = Init6X6TestGrid(values);
	//char[][] nextGrid = grid;
	for (int i = 0; i < 4; i++) 
	{ 
		grid = GetNextGrid(grid); 
	}
	Assert.Equal(grid[0][0], OFF);
	Assert.Equal(grid[0][5], OFF);

	Assert.Equal(grid[2][1], OFF);
	Assert.Equal(grid[2][2], ON);
	Assert.Equal(grid[2][3], ON);
	Assert.Equal(grid[3][2], ON);
	Assert.Equal(grid[3][3], ON);

	Assert.Equal(grid[5][1], OFF);
	Assert.Equal(grid[5][2], OFF);
}

[Fact]
void LoadGridTest()
{
	/*
		.#.#.#
		...##.
		#....#
		..#...
		#.#..#
		####..
	*/
	
	char[][] grid = LoadGrid("sample.txt");
	Assert.Equal(grid[0][0], OFF);
	Assert.Equal(grid[0][1], ON);

	Assert.Equal(grid[2][1], OFF);
	Assert.Equal(grid[2][5], ON);

	Assert.Equal(grid[5][4], OFF);
	Assert.Equal(grid[5][1], ON);
}
