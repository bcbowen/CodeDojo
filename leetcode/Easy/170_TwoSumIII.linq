<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class TwoSum
{
	private HashSet<int> _values = new HashSet<int>(); 
	private HashSet<int> _dupes = new HashSet<int>(); 

	public TwoSum()
	{

	}

	public void Add(int number)
	{
		_values.Add(number);
	}

	public bool Find(int value)
	{
		foreach(int key in _values)
		{
			if (_values.Contains(value - key))
			{
				return true;
			}
		}
		
		return false;
	}
}

/**
 * Your TwoSum object will be instantiated and called as such:
 * TwoSum obj = new TwoSum();
 * obj.Add(number);
 * bool param_2 = obj.Find(value);
 */

#region private::Tests

[Fact]
void PositiveFindSucceedsTest() 
{
	TwoSum t = new TwoSum(); 
	t.Add(1); 
	t.Add(3); 
	t.Add(5); 
	bool result = t.Find(4); 
	Assert.True(result);
}

[Fact]
void PositiveFindFailsTest()
{
	TwoSum t = new TwoSum();
	t.Add(1);
	t.Add(3);
	t.Add(5);
	bool result = t.Find(7);
	Assert.False(result);
}

[Fact]
void NegativeFindSucceedsTest()
{
	TwoSum t = new TwoSum();
	t.Add(-1);
	t.Add(-3);
	t.Add(-5);
	bool result = t.Find(-4);
	Assert.True(result);
}

[Fact]
void NegativeFindFailsTest()
{
	TwoSum t = new TwoSum();
	t.Add(-1);
	t.Add(-3);
	t.Add(-5);
	bool result = t.Find(-7);
	Assert.False(result);
}

[Theory]
[InlineData(-10000, 10001, 1)]
[InlineData(0, 0, 0)]
[InlineData(5, 5, 10)]
void RangeFindSucceedsTests(int low, int high, int value) 
{
	TwoSum t = new TwoSum();
	t.Add(low); 
	t.Add(high); 
	Assert.True(t.Find(value));
}

[Theory]
[InlineData(4)]
[InlineData(0)]
[InlineData(-4)]
void HasDupeTest(int dupe)
{
	TwoSum t = new TwoSum();
	t.Add(dupe);
	t.Add(dupe);
	Assert.True(t.Find(dupe * 2));
}

[Theory]
[InlineData(4)]
[InlineData(0)]
[InlineData(-4)]
void NoDupeTest(int dupe)
{
	TwoSum t = new TwoSum();
	t.Add(dupe);
	Assert.False(t.Find(dupe * 2));
}

#endregion