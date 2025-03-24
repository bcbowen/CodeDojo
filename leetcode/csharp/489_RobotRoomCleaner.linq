<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	//RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
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
	private int[][] _directions = new[] { new[] { -1, 0 }, new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 } };
	private HashSet<(int, int)> _visited = new HashSet<(int, int)>();
	private Robot _robot;

	private void GoBack()
	{
		_robot.TurnRight();
		_robot.TurnRight();
		_robot.Move();
		_robot.TurnRight();
		_robot.TurnRight();
	}

	private void Backtrack(int row, int col, int d)
	{
		_visited.Add((row, col));
		_robot.Clean();
		for (int i = 0; i < 4; i++)
		{
			int newD = (d + i) % 4;
			int newRow = row + _directions[newD][0];
			int newCol = col + _directions[newD][1];

			if (!_visited.Contains((newRow, newCol)) && _robot.Move()) 
			{
				Backtrack(newRow, newCol, newD);
				GoBack();
			}
			
			_robot.TurnRight();
		}
	}

	public void CleanRoom(Robot robot)
	{
		_robot = robot;
		Backtrack(0, 0, 0);
	}
}


