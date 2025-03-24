<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class SmallestInfiniteSet
{
	private int _position = 1; 
	private int[] _values = new int[1002];
	private bool[] _isPresent = new bool[1002];
	
	public SmallestInfiniteSet()
	{
		for (int i = 1; i < 1001; i++)
		{
			_values[i] = i;
			_isPresent[i] = true;
		}
	}

	public int PopSmallest()
	{
		int value = _values[_position];
		_isPresent[_position] = false;
		while(_position < _values.Length && !_isPresent[_position]) 
		{
			_position++; 
		}
		
		return value;
	}

	public void AddBack(int num)
	{
		_isPresent[num] = true;
		if (num < _position) _position = num;
		
	}
}

public class SmallestInfiniteSetFirst
{
	private PriorityQueue<int, int> _set = new PriorityQueue<int, int>();
	private int _max;

	private HashSet<int> _outliers = new HashSet<int>();

	public SmallestInfiniteSetFirst()
	{
		ExtendSet();
	}

	private void ExtendSet()
	{
		for (int i = _max + 1; i <= _max + 101; i++)
		{
			if (_outliers.Contains(i))
			{
				_outliers.Remove(i);
			}

			_set.Enqueue(i, i);
		}

		_max += 101;
	}

	public int PopSmallest()
	{
		if (_set.Count < 5)
		{
			ExtendSet();
		}
		int value = _set.Dequeue();
		if (_outliers.Contains(value)) _outliers.Remove(value);

		return value;
	}

	public void AddBack(int num)
	{
		if (num < _set.Peek())
		{
			_set.Enqueue(num, num);
		}
		else if (num > _max)
		{
			if (_outliers.Contains(num))
			{
				_set.Enqueue(num, num);
				_outliers.Add(num);
			}
		}
		else
		{
			Queue<int> searchQueue = new Queue<int>();
			while (_set.Peek() < num)
			{
				searchQueue.Enqueue(_set.Dequeue());
			}
			if (_set.Peek() > num)
			{
				_set.Enqueue(num, num);
			}
			while (searchQueue.Count > 0)
			{
				int val = searchQueue.Peek();
				_set.Enqueue(val, val);
				searchQueue.Dequeue();
			}
		}

	}
}

/*
Example 1:

Input
["SmallestInfiniteSet", "addBack", "popSmallest", "popSmallest", "popSmallest", "addBack", "popSmallest", "popSmallest", "popSmallest"]
[[], [2], [], [], [], [1], [], [], []]
Output
[null, null, 1, 2, 3, null, 1, 4, 5]

Explanation
SmallestInfiniteSet smallestInfiniteSet = new SmallestInfiniteSet();
smallestInfiniteSet.addBack(2);    // 2 is already in the set, so no change is made.
smallestInfiniteSet.popSmallest(); // return 1, since 1 is the smallest number, and remove it from the set.
smallestInfiniteSet.popSmallest(); // return 2, and remove it from the set.
smallestInfiniteSet.popSmallest(); // return 3, and remove it from the set.
smallestInfiniteSet.addBack(1);    // 1 is added back to the set.
smallestInfiniteSet.popSmallest(); // return 1, since 1 was added back to the set and
                                   // is the smallest number, and remove it from the set.
smallestInfiniteSet.popSmallest(); // return 4, and remove it from the set.
smallestInfiniteSet.popSmallest(); // return 5, and remove it from the set.
*/

[Fact]
void Test() 
{
	SmallestInfiniteSet set = new SmallestInfiniteSet(); 
	set.AddBack(2); 
	int expected = 1; 
	int result = set.PopSmallest(); 
	Assert.Equal(expected, result); 
	expected = 2; 
	result = set.PopSmallest();
	Assert.Equal(expected, result);
	expected = 3;
	result = set.PopSmallest();
	Assert.Equal(expected, result);
	set.AddBack(1);
	expected = 1;
	result = set.PopSmallest();
	Assert.Equal(expected, result);
	expected = 4;
	result = set.PopSmallest();
	Assert.Equal(expected, result);
	expected = 5;
	result = set.PopSmallest();
	Assert.Equal(expected, result);
}

[Fact]
void PopThemAll()
{
	SmallestInfiniteSet set = new SmallestInfiniteSet();
	int expected = 1; 
	int result;
	// 1 - 999
	for(int i = 1; i < 1000; i++)
	{
		result = set.PopSmallest(); 
		Assert.Equal(expected, result); 
		expected++; 
	}

	// 1000
	result = set.PopSmallest();
	Assert.Equal(expected, result);
}

[Fact]
void OutlierTest()
{
	SmallestInfiniteSet set = new SmallestInfiniteSet();
	
	set.AddBack(120); 
	set.AddBack(150); 
	
	int expected = 1;
	for (int i = 1; i < 750; i++)
	{
		int result = set.PopSmallest();
		Assert.Equal(expected, result);
		expected++;
	}
}

[Fact]
void AddExistingTest()
{
	SmallestInfiniteSet set = new SmallestInfiniteSet();

	set.AddBack(2);
	set.AddBack(7);

	int expected = 1;
	for (int i = 1; i < 20; i++)
	{
		int result = set.PopSmallest();
		Assert.Equal(expected, result);
		expected++;
	}
}

[Fact]
void AddBackTwiceTest()
{
	SmallestInfiniteSet set = new SmallestInfiniteSet();

	set.AddBack(120);
	set.AddBack(120);

	int expected = 1;
	for (int i = 1; i < 750; i++)
	{
		int result = set.PopSmallest();
		Assert.Equal(expected, result);
		expected++;
	}
}

