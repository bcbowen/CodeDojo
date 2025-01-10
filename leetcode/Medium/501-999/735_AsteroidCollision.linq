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
	foreach(int rock in asteroids)
	{
		if (rock < 0)
		{
			if (asStack.Count == 0)
			{ 
				asStack.Push(rock);
			}
			else
			{
				int peek = asStack.Peek();
				bool isCrushed = false;
				while(asStack.Count > 0 && peek > 0)
				{
					if (Math.Abs(peek) > Math.Abs(rock))
					{
						isCrushed = true; 
						break;
					}
					else if (Math.Abs(peek) == Math.Abs(rock)) 
					{
						isCrushed = true; 
						asStack.Pop(); 
						break;
					}
					else
					{
						asStack.Pop(); 
						if (asStack.Count > 0) peek = asStack.Peek(); 
					}
				}
				if (!isCrushed) asStack.Push(rock); 
			}
		}
		else 
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


#region Tests

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