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

static List<string> LoadGrid(string fileName)
{
	List<string> rows = new List<string>();
	string path = Path.Combine(Utility.GetInputDirectory(), fileName);
	using (StreamReader reader = new StreamReader(path))
	{
		string line;
		while ((line = reader.ReadLine()) != null)
		{
			rows.Add(line);
		}
		reader.Close();
	}

	return rows;
}

int Part1(string fileName)
{
	List<string> grid = LoadGrid(fileName);
	int total = 0;
	for (int r = 0; r < grid.Count; r++)
	{
		string line = grid[r];
		for (int c = 0; c < line.Length; c++)
		{
			if (char.IsDigit(line[c]))
			{
				(bool isConnected, int value) = IsConnected(grid, r, c);
				if (isConnected)
				{
					total += value;
				}
				while (c < line.Length && char.IsDigit(grid[r][c]))
				{
					c++;
				}
			}
		}
	}
	Console.WriteLine($"Part 1 total: {total}");
	return total;
}

int Part2(string fileName)
{
	List<string> grid = LoadGrid(fileName);
	int total = 0;
	for (int r = 0; r < grid.Count; r++)
	{
		for (int c = 0; c < grid[r].Length; c++)
		{
			if (grid[r][c] == '*')
			{
				List<int> connectedParts = FindConnectedParts(grid, r, c);
				if (connectedParts.Count == 2)
				{
					total += connectedParts[0] * connectedParts[1];
				}
			}
		}
	}
	Console.WriteLine($"Part 2 total: {total}");
	return total;
}

List<int> FindConnectedParts(List<string> grid, int r, int c)
{
	List<int> result = new List<int>();

	int value;
	string line;
	// check above
	if (r > 0)
	{
		line = grid[r - 1];
		if (c > 0 && char.IsDigit(line[c - 1]))
		{
			value = GetNumber(line, c - 1);
			result.Add(value);
		}

		if (char.IsDigit(line[c]))
		{
			value = GetNumber(line, c);
			if (!result.Contains(value)) result.Add(value);
		}

		if (c < line.Length - 1 && char.IsDigit(line[c + 1]))
		{
			value = GetNumber(line, c + 1);
			if (!result.Contains(value)) result.Add(value);
		}
	}

	// check left
	line = grid[r];
	if (c > 0)
	{
		if (char.IsDigit(line[c - 1]))
		{
			value = GetNumber(line, c - 1);
			result.Add(value);
		}
	}

	// check right
	if (c < line.Length - 1)
	{

		if (char.IsDigit(line[c + 1]))
		{
			value = GetNumber(line, c + 1);
			result.Add(value);
		}
	}

	// check below
	if (r < grid.Count - 1)
	{
		line = grid[r + 1];

		if (c > 0 && char.IsDigit(line[c - 1]))
		{
			value = GetNumber(line, c - 1);
			result.Add(value);
		}

		if (char.IsDigit(line[c]))
		{
			value = GetNumber(line, c);
			if (!result.Contains(value)) result.Add(value);
		}

		if (c < line.Length - 1 && char.IsDigit(line[c + 1]))
		{
			value = GetNumber(line, c + 1);
			if (!result.Contains(value)) result.Add(value);
		}
	}

	return result;

}

int GetNumber(string line, int c)
{
	int begin = c;
	int end = c;
	while (begin > 0 && char.IsDigit(line[begin - 1]))
	{
		begin--;
	}
	while (end < line.Length - 1 && char.IsDigit(line[end + 1]))
	{
		end++;
	}

	return int.Parse(line.Substring(begin, end - begin + 1));
}

bool IsSymbol(char c)
{
	return !char.IsDigit(c) && c != '.';
}

// The number at the given position is connected to a symbol
(bool, int) IsConnected(List<string> grid, int row, int col)
{
	string line = grid[row];
	int value = 0;
	int begin = col;
	int end = col + 1;
	while (end < line.Length && char.IsDigit(line[end]))
	{
		end++;
	}
	end--;
	value = int.Parse(line.Substring(begin, end - begin + 1));
	// check above
	if (row > 0)
	{
		line = grid[row - 1];
		for (int i = begin > 0 ? begin - 1 : 0; i <= (end < line.Length - 1 ? end + 1 : end); i++)
		{
			if (IsSymbol(line[i]))
			{
				return (true, value);
			}
		}
	}

	line = grid[row];
	// check left
	if (col > 0 && IsSymbol(line[col - 1]))
	{
		return (true, value);
	}

	// check right
	if (end < line.Length - 1 && IsSymbol(line[end + 1]))
	{
		return (true, value);
	}

	// check below
	if (row < grid.Count - 1)
	{
		line = grid[row + 1];
		for (int i = begin > 0 ? begin - 1 : 0; i <= (end < line.Length - 1 ? end + 1 : end); i++)
		{
			if (IsSymbol(line[i]))
			{
				return (true, value);
			}
		}
	}

	// stuck out 
	return (false, 0);
}

/*
467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..
*/

[Theory]
[InlineData(0, 0, true, 467)]
[InlineData(0, 5, false, 0)]
[InlineData(5, 7, false, 0)]
[InlineData(2, 2, true, 35)]
[InlineData(2, 6, true, 633)]
[InlineData(4, 0, true, 617)]
[InlineData(6, 2, true, 592)]
[InlineData(7, 6, true, 755)]
[InlineData(9, 1, true, 664)]
[InlineData(9, 5, true, 598)]

void IsConnectedTest(int row, int col, bool expected, int expectedValue)
{
	List<string> grid = LoadGrid("sample.txt");
	(bool result, int value) = IsConnected(grid, row, col);
	Assert.Equal(expected, result);
	Assert.Equal(expectedValue, value);
}

[Fact]
void LoadGridTest()
{
	List<string> grid = LoadGrid("sample.txt");
	Assert.Equal(10, grid.Count);
	Assert.True(grid[0].StartsWith("467"));
	Assert.True(grid[9].Contains("664"));
}

[Fact]
void Part1Test()
{
	int result = Part1("sample.txt");
	int expected = 4361;
	Assert.Equal(expected, result);
}

[Fact]
void Part2Test()
{
	int result = Part2("sample.txt");
	int expected = 467835;
	Assert.Equal(expected, result);
}

[Theory]
[InlineData("123........", 0, 123)]
[InlineData("123........", 1, 123)]
[InlineData("123........", 2, 123)]
[InlineData("....123....", 4, 123)]
[InlineData("....123....", 5, 123)]
[InlineData("....123....", 6, 123)]
[InlineData("........123", 8, 123)]
[InlineData("........123", 9, 123)]
[InlineData("........123", 10, 123)]
void GetNumberTest(string line, int c, int expected)
{
	int result = GetNumber(line, c);
	Assert.Equal(expected, result);
}