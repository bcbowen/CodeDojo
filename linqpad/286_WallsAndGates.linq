<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class Solution
{
	public void WallsAndGates(int[][] rooms)
	{
		int matrixHeight = rooms.Length;
		int matrixWidth = rooms[0].Length;
		Queue<int[]> Gates = new Queue<int[]>();
		Queue<int[]> Rooms = new Queue<int[]>();
		for (int y = 0; y < matrixHeight; y++)
		{
			for (int x = 0; x < matrixWidth; x++)
			{
				if (rooms[y][x] == 0)
				{
					Gates.Enqueue(new int[] { y, x });
				}
			}
		}

		while (Gates.Count > 0)
		{
			int[] gate = Gates.Dequeue();
			int y = gate[0];
			int x = gate[1];
			// above
			if (y > 0 && rooms[y - 1][x] > 0)
			{
				rooms[y - 1][x] = 1;
				Rooms.Enqueue(new int[] { y - 1, x });
			}
			// below
			if (rooms.Length > 1 && y < matrixHeight - 1 && rooms[y + 1][x] > 0)
			{
				rooms[y + 1][x] = 1;
				Rooms.Enqueue(new int[] { y + 1, x });
			}
			// l 
			if (x > 0 && rooms[y][x - 1] > 0)
			{
				rooms[y][x - 1] = 1;
				Rooms.Enqueue(new int[] { y, x - 1 });
			}
			// r
			if (rooms[y].Length > 1 && x < matrixWidth - 1 && rooms[y][x + 1] > 0)
			{
				rooms[y][x + 1] = 1;
				Rooms.Enqueue(new int[] { y, x + 1 });
			}

			while (Rooms.Count > 0)
			{
				int[] room = Rooms.Dequeue();
				int ry = room[0];
				int rx = room[1];

				int value = rooms[ry][rx] + 1;

				// above
				if (ry > 0 && rooms[ry - 1][rx] > value)
				{
					rooms[ry - 1][rx] = value;
					Rooms.Enqueue(new int[] { ry - 1, rx });
				}
				// below
				if (rooms.Length > 1 && ry < matrixHeight - 1 && rooms[ry + 1][rx] > value)
				{
					rooms[ry + 1][rx] = value;
					Rooms.Enqueue(new int[] { ry + 1, rx });
				}
				// l 
				if (rx > 0 && rooms[ry][rx - 1] > value)
				{
					rooms[ry][rx - 1] = value;
					Rooms.Enqueue(new int[] { ry, rx - 1 });
				}
				// r
				if (rooms[ry].Length > 1 && rx < matrixWidth - 1 && rooms[ry][rx + 1] > value)
				{
					rooms[ry][rx + 1] = value;
					Rooms.Enqueue(new int[] { ry, rx + 1 });
				}
			}
		}
	}
}

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
public void Example1()
{

	/*
	Example 1:
	Input: rooms = [[2147483647,-1,0,2147483647],[2147483647,2147483647,2147483647,-1],[2147483647,-1,2147483647,-1],[0,-1,2147483647,2147483647]]
	Output: [[3,-1,0,1],[2,2,1,-1],[1,-1,2,-1],[0,-1,3,4]]
	*/
	int[][] rooms = new int[4][];
	rooms[0] = new[] { 2147483647, -1, 0, 2147483647 };
	rooms[1] = new[] { 2147483647, 2147483647, 2147483647, -1 };
	rooms[2] = new[] { 2147483647,-1,2147483647,-1 };
	rooms[3] = new[] { 0,-1,2147483647,2147483647 };

	new Solution().WallsAndGates(rooms);
	int[][] expected = new int[4][];
	expected[0] = new[] { 3,-1,0,1 };
	expected[1] = new[] { 2,2,1,-1 };
	expected[2] = new[] { 1,-1,2,-1 };
	expected[3] = new[] { 0,-1,3,4 };
	
	Assert.Equal(expected, rooms);
}

[Fact]
public void Example2()
{

	/*
	Example 2:
	Input: rooms = [[-1]]
	Output: [[-1]]
	*/
	int[][] rooms = new int[1][];
	rooms[0] = new[] { -1 };

	new Solution().WallsAndGates(rooms);
	int[][] expected = new int[1][];
	expected[0] = new[] { -1 };

	Assert.Equal(expected, rooms);
}

[Fact]
public void Example3()
{

	/*
	Example 2:
	Input: rooms = [0]]
	Output: [[0]]
	*/
	int[][] rooms = new int[1][];
	rooms[0] = new[] { 0 };

	new Solution().WallsAndGates(rooms);
	int[][] expected = new int[1][];
	expected[0] = new[] { 0 };

	Assert.Equal(expected, rooms);
}

[Fact]
public void Example4() 
{
	/*
	Input:
	[[2147483647,0,2147483647,2147483647,0,2147483647,-1,2147483647]]
	Output:
	[[1,0,1,1,0,2147483647,-1,2147483647]]
	Expected:
	[[1,0,1,1,0,1,-1,2147483647]]
	*/

	int[][] rooms = new int[1][];
	rooms[0] = new[] { 2147483647,0,2147483647,2147483647,0,2147483647,-1,2147483647 };

	new Solution().WallsAndGates(rooms);
	int[][] expected = new int[1][];
	expected[0] = new[] { 1,0,1,1,0,1,-1,2147483647 };

	Assert.Equal(expected, rooms);

}

#endregion