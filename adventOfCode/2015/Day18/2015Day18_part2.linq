<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"
void Main()
{
	RunTests();  
	Part2("input.txt", 100);
}


int Part2(string fileName, int iterations)
{
	char[][] grid = LoadGrid(fileName);
	for(int i = 0; i < iterations; i++) 
	{
		grid = GetNextGrid(grid); 
	}
	int onCount = CountLights(grid); 

	Console.WriteLine($"Part2: {onCount} lights are on"); 
	return onCount;
}

int CountLights(char[][] grid) 
{
	int onCount = 0;
	for (int r = 0; r < grid.Length; r++)
	{
		for (int c = 0; c < grid[r].Length; c++)
		{
			if (grid[r][c] == ON) onCount++;
		}
	}
	return onCount; 
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
	int limit = currentGrid.Length - 1; 
	// part2: corners are always on
	if (r == 0 && (c == 0 || c == limit)) return ON; 
	if (r == limit && (c == 0 || c == limit)) return ON; 

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
		##.#.#
		...##.
		#....#
		..#...
		#.#..#
		####.#
	*/
	char[][] grid = GetTestGrid(); 
	Assert.Equal(grid[0][0], ON); 
	Assert.Equal(grid[0][1], ON);

	Assert.Equal(grid[2][1], OFF);
	Assert.Equal(grid[2][5], ON);

	Assert.Equal(grid[5][4], OFF);
	Assert.Equal(grid[5][1], ON);
}


[Theory]
[InlineData(0, 0, '#')]
[InlineData(0, 1, '.')]
[InlineData(0, 2, '#')]
[InlineData(0, 3, '#')]
[InlineData(2, 0, '.')]
[InlineData(2, 1, '.')]
[InlineData(2, 3, '#')]
[InlineData(2, 4, '#')]
[InlineData(5, 0, '#')]
[InlineData(5, 1, '.')]
[InlineData(5, 5, '#')]
void GetNextValueTest(int r, int c, char expected)
{
	/*
		Initial state:
		##.#.#
		...##.
		#....#
		..#...
		#.#..#
		####.#

		After 1 step:
		#.##.#
		####.#
		...##.
		......
		#...#.
		#.####
		
		
	*/
	char[][] grid = GetTestGrid();
	char result = GetNextValue(r, c, grid); 
	Assert.Equal(expected, result); 
}



/*
Initial state:
##.#.#
...##.
#....#
..#...
#.#..#
####.#

After 1 step:
#.##.#
####.#
...##.
......
#...#.
#.####

After 2 steps:
#..#.#
#....#
.#.##.
...##.
.#..##
##.###

After 3 steps:
#...##
####.#
..##.#
......
##....
####.#

After 4 steps:
#.####
#....#
...#..
.##...
#.....
#.#..#

After 5 steps:
##.###
.##..#
.##...
.##...
#.#...
##...#
*/

char[][] GetTestGrid() 
{
	string values = "##.#.#";
	values += "...##.";
	values += "#....#";
	values += "..#...";
	values += "#.#..#";
	values += "####.#";
	char[][] grid = Init6X6TestGrid(values);
	return grid; 
}

[Fact]
void GetNextGridTest()
{

	/*
	Initial state:
	##.#.#
	...##.
	#....#
	..#...
	#.#..#
	####.#

	After 1 step:
	#.##.#
	####.#
	...##.
	......
	#...#.
	#.####


	*/
	char[][] grid = GetTestGrid(); 
	char[][] nextGrid = GetNextGrid(grid);
	Assert.Equal(nextGrid[0][0], ON);
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
		##.#.#
		...##.
		#....#
		..#...
		#.#..#
		####.#

		After 5 steps:
		##.###
		.##..#
		.##...
		.##...
		#.#...
		##...#

	*/
	char[][] grid = LoadGrid("sample2.txt"); 
	for (int i = 0; i < 5; i++) 
	{ 
		grid = GetNextGrid(grid); 
	}
	Assert.Equal(grid[0][0], ON);
	Assert.Equal(grid[0][1], ON);
	Assert.Equal(grid[0][2], OFF);
	Assert.Equal(grid[0][3], ON);
	Assert.Equal(grid[0][4], ON);
	Assert.Equal(grid[0][5], ON);

	Assert.Equal(grid[1][0], OFF);
	Assert.Equal(grid[1][1], ON);
	Assert.Equal(grid[1][2], ON);
	Assert.Equal(grid[1][3], OFF);
	Assert.Equal(grid[1][4], OFF);
	Assert.Equal(grid[1][5], ON);

	Assert.Equal(grid[2][0], OFF);
	Assert.Equal(grid[2][1], ON);
	Assert.Equal(grid[2][2], ON);
	Assert.Equal(grid[2][3], OFF);
	Assert.Equal(grid[2][4], OFF);
	Assert.Equal(grid[2][5], OFF);

	Assert.Equal(grid[3][0], OFF);
	Assert.Equal(grid[3][1], ON);
	Assert.Equal(grid[3][2], ON);
	Assert.Equal(grid[3][3], OFF);
	Assert.Equal(grid[3][4], OFF);
	Assert.Equal(grid[3][5], OFF);

	Assert.Equal(grid[4][0], ON);
	Assert.Equal(grid[4][1], OFF);
	Assert.Equal(grid[4][2], ON);
	Assert.Equal(grid[4][3], OFF);
	Assert.Equal(grid[4][4], OFF);
	Assert.Equal(grid[4][5], OFF);

	Assert.Equal(grid[5][0], ON);
	Assert.Equal(grid[5][1], ON);
	Assert.Equal(grid[5][2], OFF);
	Assert.Equal(grid[5][3], OFF);
	Assert.Equal(grid[5][4], OFF);
	Assert.Equal(grid[5][5], ON);

	int onCount = CountLights(grid); 
	int expected = 17; 
	Assert.Equal(expected, onCount); 
	/*
			##.###
		.##..#
		.##...
		.##...
		#.#...
		##...#
	*/
}

[Fact]
void LoadGridTest()
{
	/*
		##.#.#
		...##.
		#....#
		..#...
		#.#..#
		####.#
	*/

	char[][] grid = LoadGrid("sample2.txt");
	Assert.Equal(grid[0][0], ON);
	Assert.Equal(grid[0][1], ON);

	Assert.Equal(grid[2][1], OFF);
	Assert.Equal(grid[2][5], ON);

	Assert.Equal(grid[5][4], OFF);
	Assert.Equal(grid[5][1], ON);
}

[Fact]
void Part2Test() 
{
	int expected = 17; 
	int result = Part2("sample2.txt", 5); 
	Assert.Equal(expected, result); 
}