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
		if (asStack.Count == 0) 
		{
			asStack.Push(rock); 
			continue; 
		}
		int peek = asStack.Peek(); 
		if (peek < 0 && rock > 0 || peek > 0 && rock < 0)
		{
			if (Math.Abs(peek) == Math.Abs(rock))
			{
				asStack.Pop();
			}
			else 
			{
				while (Math.Abs(peek) < Math.Abs(rock))
				{
					asStack.Pop();
				}
				asStack.Push(rock);
			}
			
		}
		else 
		{
			asStack.Push(rock); 
		}
	}

	List<int> result = new List<int>();
	while(asStack.Count > 0) 
	{
		result.Insert(0, asStack.Pop()); 
	}
	
	return result.ToArray(); 
}

#region private::Tests

[Theory]
[InlineData(new[] { 5, 10, -5}, new[] {5, 10})]
[InlineData(new[] { 8, -8}, new int[0])]
[InlineData(new[] { 10, 2, -5}, new[] {10})]
void Test(int[] asteroids, int[] expected) 
{
	int[] result = AsteroidCollision(asteroids); 
	Assert.Equal(expected, result); 
}
#endregion