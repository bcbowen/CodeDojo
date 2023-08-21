<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public int[] AsteroidCollision(int[] asteroids)
{
	Stack<int> asStack = new Stack<int>();
	foreach (int rock in asteroids)
	{
		if (asStack.Count == 0 || !CollisionPending(rock, asStack.Peek()))
		{
			asStack.Push(rock);
			continue;
		}

		bool rockGone = false;
		while (asStack.Count > 0)
		{
			rockGone = false;
			int last = asStack.Pop();
			if (Math.Abs(last) >= Math.Abs(rock))
			{
				rockGone = true;
				if (Math.Abs(last) == Math.Abs(rock))
				{
					break;
				}
				else
				{
					asStack.Push(last);
				}

				break;
			}
		}
		if (!rockGone)
		{
			asStack.Push(rock);
		}


	}

	List<int> result = new List<int>();
	while (asStack.Count > 0)
	{
		result.Insert(0, asStack.Pop());
	}

	return result.ToArray();
}

internal bool CollisionPending(int x, int y)
{
	return ((x < 0) != (y < 0));
}

#region private::Tests

[Theory]
[InlineData(new[] { 5, 10, -5 }, new[] { 5, 10 })]
[InlineData(new[] { 8, -8 }, new int[0])]
[InlineData(new[] { 10, 2, -5 }, new[] { 10 })]
[InlineData(new[] { -2, -1, 1, 2 }, new[] { -2, -1, 1, 2 })]
void Test(int[] asteroids, int[] expected)
{
	int[] result = AsteroidCollision(asteroids);
	Assert.Equal(expected, result);
}
#endregion