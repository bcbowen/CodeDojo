<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class MovingAverage
{
	private int _size; 
	private int[] _values;
	private int _head = -1;
	private int _tail = -1;
	private int _windowTotal;
	private int _count;

	public MovingAverage(int size)
	{
		_size = size;
		_values = new int[size];
		_windowTotal = 0;
		_count = 0;
	}

	private int GetNextIndex(int index) 
	{
		return (index + 1) % _size; 
	}

	public double Next(int val)
	{
		
		if (_count < _size)
		{
			if (_count == 0) 
			{
				_head = 0;
			}
			_count++; 	
			_windowTotal += val;
			_tail++;
		}
		else 
		{
			_windowTotal -= _values[_head]; 
			_windowTotal += val; 
			_head = GetNextIndex(_head); 
			_tail = GetNextIndex(_tail); 
			
		}
		
		_values[_tail] = val;
		return (double)_windowTotal / _count; 
	}
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */

#region private::Tests


/*
Input
["MovingAverage", "next", "next", "next", "next"]
[[3], [1], [10], [3], [5]]
Output
[null, 1.0, 5.5, 4.66667, 6.0]
*/
[Theory]
[InlineData(3, new[] { 1, 10, 3, 5 }, new[] { 1.0, 5.5, 4.66667, 6.0 })]
void Test(int size, int[] values, double[] expectedValues) 
{
	MovingAverage m = new MovingAverage(size);

	for(int i = 0; i < values.Length; i++) 
	{
		double result = m.Next(values[i]);
		Assert.Equal(expectedValues[i], result, 5);	
	}
	
	
}

#endregion