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
(int, int)[] directions = 
{ 
	(0, 1), 
	(1, 0),
	(0, -1),
	(-1, 0) 
};

private int CalculateDistance(string fileName) 
{
	string[] moves = GetMoves(fileName); 
	int x = 0;
	int y = 0;
	int direction = 0;
	for (int i = 0; i < moves.Length; i++)
	{
		string move = moves[i].Trim();
		switch (move[0]) 
		{
			case 'L': 
				direction = direction > 0 ? direction - 1 : 3;
				break;
			case 'R':
				direction = (direction + 1) % 4;
				break;
			default:
				throw new Exception($"Unexpected direction: {move[0]}"); 
		}
		int distance = int.Parse(move.Substring(1)); 
		x += directions[direction].Item1 * distance; 
		y += directions[direction].Item2 * distance; 
	}
	
	return Math.Abs(x) + Math.Abs(y); 
}

// distance of first location visited twice (part2) 
private int CalculatHQDistance(string fileName)
{
	string[] moves = GetMoves(fileName);
	int x = 0;
	int y = 0;
	int direction = 0;
	HashSet<(int, int)> coordinates = new HashSet<(int, int)>();  
	for (int i = 0; i < moves.Length; i++)
	{
		string move = moves[i].Trim();
		switch (move[0])
		{
			case 'L':
				direction = direction > 0 ? direction - 1 : 3;
				break;
			case 'R':
				direction = (direction + 1) % 4;
				break;
			default:
				throw new Exception($"Unexpected direction: {move[0]}");
		}
		int distance = int.Parse(move.Substring(1));
		for (int j = 1; j <= distance; j++)
		{
			x += directions[direction].Item1;
			y += directions[direction].Item2;
			if (coordinates.Contains((x, y)))
			{
				return Math.Abs(x) + Math.Abs(y);
			}
			else
			{
				coordinates.Add((x, y));
			}
		}



	}

	return -1; 
	
}

private void Part1()
{
	string fileName = "input.txt";
	int result = CalculateDistance(fileName);
	Console.WriteLine($"Result part 1: {result}"); 
}

private void Part2() 
{
	string fileName = "input.txt";
	int result = CalculatHQDistance(fileName); 
	Console.WriteLine($"Result part 2: {result}"); 
}

private string[] GetMoves(string fileName) 
{
	string path = Path.Combine(Utility.GetInputDirectory(), fileName); 
	string content = File.ReadAllText(path); 
	string[] moves = content.Split(',');
	return moves; 
}

/*
R2, L3 leaves you 2 blocks East and 3 blocks North, or 5 blocks away.
R2, R2, R2 leaves you 2 blocks due South of your starting position, which is 2 blocks away.
R5, L5, R5, R3 leaves you 12 blocks away.
*/
[Theory]
[InlineData("sample1.txt", 5)]
[InlineData("sample2.txt", 2)]
[InlineData("sample3.txt", 12)]
void Test_Part1(string fileName, int expected) 
{
	int result = CalculateDistance(fileName); 
	Assert.Equal(expected, result);
}

[Fact]
void Test_Part2() 
{
	int expected = 4; 
	string fileName = "sample4.txt";
	int result = CalculatHQDistance(fileName); 
	Assert.Equal(expected, result); 
}
