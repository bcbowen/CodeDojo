<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


// This is the robot's control interface.
// You should not implement it, or speculate about its implementation
interface Robot
{
	// Returns true if the cell in front is open and robot moves into the cell.
	// Returns false if the cell in front is blocked and robot stays in the current cell.
	public bool Move();

	// Robot will stay in the same cell after calling turnLeft/turnRight.
	// Each turn will be 90 degrees.
	public void TurnLeft();
	public void TurnRight();

	// Clean the current cell.
	public void Clean();
}


class Solution
{
	public void CleanRoom(Robot robot)
	{

	}
}


class Tester
{
	[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);


}

internal enum Direction
{
	Left,
	Up,
	Right,
	Down
}

internal enum RoomType
{
	Room = 0,
	Wall = 1
}

internal class Room
{
	public RoomType RoomType { get; set; }
	public bool Cleaned { get; set; }
	public int X { get; set; }
	public int Y { get; set; }
}

class TestRobot : Robot
{
	private int _x;
	private int _y;
	private Direction _d;

	private HashSet<Room> _dirtyRooms;

	public TestRobot(IList<IList<Room>> map, int x, int y)
	{
		_d = Direction.Up;
		_dirtyRooms = new HashSet<UserQuery.Room>();
		foreach (IList<Room> section in map)
		{
			foreach (Room room in section) 
			{
				_dirtyRooms.Add(room);
			}
		}
	}



}

