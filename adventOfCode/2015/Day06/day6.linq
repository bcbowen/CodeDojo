<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"
#load "..\..\Utilities.linq"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
	Part1.Run(); 
	Part2.Run(); 
}



static class Part1
{
	public static void Run() 
	{
		List<string> commands = LoadCommands();
		bool[][] grid = InitGrid();
		foreach(string command in commands) 
		{
			ProcessCommand(command, grid); 
		}
		int result = CountLights(grid);
		Console.WriteLine($"Part1: {result} lights are on."); 
	}
	
	static int CountLights(bool[][] grid) 
	{
		int count = 0;
		for (int i = 0; i < 1000; i++)
		{
			for (int j = 0; j < 1000; j++)
			{
				if(grid[i][j]) count++; 
			}
		}
		
		return count; 
	}
	
	static void ProcessCommand(string command, bool[][] grid) 
	{
		string[] words = command.Split(' ');
		string beginLocation; 
		string endLocation; 
		string[] positions;
		int beginX; 
		int beginY; 
		int endX; 
		int endY; 
		if (words[0] == "toggle") 
		{
			beginLocation = words[1]; 
			positions = beginLocation.Split(','); 
			beginY = int.Parse(positions[0]); 
			beginX = int.Parse(positions[1]); 
			
			endLocation = words[3]; 
			positions = endLocation.Split(',');
			endY = int.Parse(positions[0]);
			endX = int.Parse(positions[1]); 
			
			ToggleLights(grid, beginX, beginY, endX, endY); 
		}
		else
		{
			beginLocation = words[2];
			positions = beginLocation.Split(',');
			beginY = int.Parse(positions[0]);
			beginX = int.Parse(positions[1]);

			endLocation = words[4];
			positions = endLocation.Split(',');
			endY = int.Parse(positions[0]);
			endX = int.Parse(positions[1]);

			SetLights(grid, beginX, beginY, endX, endY, words[1] == "on");
		}
	}
	
	static void SetLights(bool[][] grid, int startX, int startY, int endX, int endY, bool on) 
	{
		for (int y = startY; y <= endY; y++)
		{
			for (int x = startX; x <= endX; x++) 
			{
				grid[y][x] = on;
			}
		}
	}

	static void ToggleLights(bool[][] grid, int startX, int startY, int endX, int endY)
	{
		for (int y = startY; y <= endY; y++)
		{
			for (int x = startX; x <= endX; x++)
			{
				grid[y][x] = !grid[y][x];
			}
		}
	}

	static bool[][] InitGrid()
	{
		bool[][] grid = new bool[1000][];
		for (int i = 0; i < 1000; i++)
		{
			grid[i] = new bool[1000];
		}

		return grid;
	}

}

static class Part2
{
	/*
	
	The light grid you bought actually has individual brightness controls; each light can have a brightness of zero or more. The
	 lights all start at zero.

	The phrase turn on actually means that you should increase the brightness of those lights by 1.

	The phrase turn off actually means that you should decrease the brightness of those lights by 1, to a minimum of zero.

	The phrase toggle actually means that you should increase the brightness of those lights by 2.
	*/
	public static void Run()
	{
		List<string> commands = LoadCommands();
		int[][] grid = InitGrid();
		foreach (string command in commands)
		{
			ProcessCommand(command, grid);
		}
		int result = TotalBrightness(grid);
		Console.WriteLine($"Part2: {result} total brightness.");
	}

	static int TotalBrightness(int[][] grid)
	{
		int total = 0;
		for (int i = 0; i < 1000; i++)
		{
			for (int j = 0; j < 1000; j++)
			{
				total += grid[i][j];
			}
		}

		return total;
	}

	static void ProcessCommand(string command, int[][] grid)
	{
		string[] words = command.Split(' ');
		string beginLocation;
		string endLocation;
		string[] positions;
		int beginX;
		int beginY;
		int endX;
		int endY;
		if (words[0] == "toggle")
		{
			beginLocation = words[1];
			positions = beginLocation.Split(',');
			beginY = int.Parse(positions[0]);
			beginX = int.Parse(positions[1]);

			endLocation = words[3];
			positions = endLocation.Split(',');
			endY = int.Parse(positions[0]);
			endX = int.Parse(positions[1]);

			ToggleLights(grid, beginX, beginY, endX, endY);
		}
		else
		{
			beginLocation = words[2];
			positions = beginLocation.Split(',');
			beginY = int.Parse(positions[0]);
			beginX = int.Parse(positions[1]);

			endLocation = words[4];
			positions = endLocation.Split(',');
			endY = int.Parse(positions[0]);
			endX = int.Parse(positions[1]);

			SetLights(grid, beginX, beginY, endX, endY, words[1] == "on");
		}
	}

	static void SetLights(int[][] grid, int startX, int startY, int endX, int endY, bool on)
	{
		for (int y = startY; y <= endY; y++)
		{
			for (int x = startX; x <= endX; x++)
			{
				if (on) 
				{
					grid[y][x]++;
				}
				else if (grid[y][x] > 0) 
				{
					grid[y][x]--;
				}
				
			}
		}
	}

	static void ToggleLights(int[][] grid, int startX, int startY, int endX, int endY)
	{
		for (int y = startY; y <= endY; y++)
		{
			for (int x = startX; x <= endX; x++)
			{
				grid[y][x] += 2;
			}
		}
	}

	static int[][] InitGrid()
	{
		int[][] grid = new int[1000][];
		for (int i = 0; i < 1000; i++)
		{
			grid[i] = new int[1000];
		}

		return grid;
	}

}


static List<string> LoadCommands()
{
	List<string> commands = new List<string>();
	string path = Path.Combine(Utility.GetInputDirectory(), "input.txt");
	using(StreamReader reader = new StreamReader(path)) 
	{
		string line;
		while((line = reader.ReadLine()) != null) 
		{
			commands.Add(line); 
		}
		reader.Close(); 
	}
	return commands; 
}


