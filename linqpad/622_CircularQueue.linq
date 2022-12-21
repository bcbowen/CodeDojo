<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class MyCircularQueue
{
	private int _front = -1;
	private int _rear = -1;
	private int[] _queue;


	public MyCircularQueue(int k)
	{
		_queue = new int[k];
	}

	public bool EnQueue(int value)
	{
		if (IsFull())
		{
			return false;
		}
		if (IsEmpty())
		{
			_queue[0] = value;
			_front = 0;
			_rear = 0;
		}
		else
		{
			int next = Wrap(_rear + 1);
			_queue[next] = value;
			_rear = next;
		}

		return true;
	}

	public bool DeQueue()
	{
		if (IsEmpty()) return false;

		if (_front == _rear) 
		{
			_front = -1; 
			_rear = -1;
		}
		else
		{
			int next = Wrap(_front + 1);
			_front = next;
		}
		
		return true;
	}

	public int Front()
	{
		return IsEmpty() ? -1 : _queue[_front];
	}

	public int Rear()
	{
		return IsEmpty() ? -1 : _queue[_rear];
	}

	public bool IsEmpty()
	{
		return _front == -1;
	}

	public bool IsFull()
	{
		int next = Wrap(_rear + 1); 
		return next == _front;
	}

	internal int Wrap(int index) 
	{
		return index % _queue.Length;
	}
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */

#region Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#region Troubleshooting

[Fact]
void BigTest2() 
{
	MyCircularQueue q = new MyCircularQueue(6); 
	q.EnQueue(6); 
	q.Rear(); 
	q.Rear(); 
	q.DeQueue(); 
	q.EnQueue(5); 
	q.Rear(); 
	q.DeQueue(); 
	q.Front(); 
	q.DeQueue(); 
	q.DeQueue(); 
	q.DeQueue(); 
	/*
	["MyCircularQueue","enQueue","Rear","Rear","deQueue","enQueue","Rear","deQueue","Front","deQueue","deQueue","deQueue"]
[[6],[6],[],[],[],[5],[],[],[],[],[],[]]
	*/
	
}

#endregion Troubleshooting

#region BigTest

[Fact]
void WholeShebang() 
{
	// MyCircularQueue myCircularQueue = new MyCircularQueue(3);
	MyCircularQueue q = new MyCircularQueue(3);

	// myCircularQueue.enQueue(1); // return True
	Assert.True(q.EnQueue(1)); 
	
	// myCircularQueue.enQueue(2); // return True
	Assert.True(q.EnQueue(2)); 
	
	// myCircularQueue.enQueue(3); // return True
	Assert.True(q.EnQueue(3)); 
	
	// myCircularQueue.enQueue(4); // return False
	Assert.False(q.EnQueue(4)); 
	
	// myCircularQueue.Rear();     // return 3	
	Assert.Equal(3, q.Rear()); 
	
	// myCircularQueue.isFull();   // return True
	Assert.True(q.IsFull());
	
	// myCircularQueue.deQueue();  // return True
	Assert.True(q.DeQueue());
	
	// myCircularQueue.enQueue(4); // return True
	Assert.True(q.EnQueue(4));
	
	// myCircularQueue.Rear();     // return 4
	Assert.Equal(4, q.Rear());
	
}

/*
Input
["MyCircularQueue", "enQueue", "enQueue", "enQueue", "enQueue", "Rear", "isFull", "deQueue", "enQueue", "Rear"]
[[3], [1], [2], [3], [4], [], [], [], [4], []]
Output
[null, true, true, true, false, 3, true, true, true, 4]

Explanation
MyCircularQueue myCircularQueue = new MyCircularQueue(3);
myCircularQueue.enQueue(1); // return True
myCircularQueue.enQueue(2); // return True
myCircularQueue.enQueue(3); // return True
myCircularQueue.enQueue(4); // return False
myCircularQueue.Rear();     // return 3
myCircularQueue.isFull();   // return True
myCircularQueue.deQueue();  // return True
myCircularQueue.enQueue(4); // return True
myCircularQueue.Rear();     // return 4
*/

#endregion

#region IsEmptyTests

[Fact]
void NewQueueIsEmpty()
{
	MyCircularQueue q = new MyCircularQueue(5);
	Assert.True(q.IsEmpty());
}

[Theory]
[InlineData(5, 2)]
[InlineData(5, 4)]
[InlineData(50, 20)]
void QueueEmptyAfterRemovingEverything(int size, int items) 
{
	MyCircularQueue q = new MyCircularQueue(size);
	int added = 0;
	while (items > 0)
	{
		q.EnQueue(2); 
		items--;
		added++;
	}
	
	while (added > 0)
	{
		q.DeQueue(); 
		added--;
	}
	
	Assert.True(q.IsEmpty());
}

#endregion

#region FrontTests

[Theory]
[InlineData(1, 1, 5)]
[InlineData(3, 3, 5)]
[InlineData(7, 5, 5)]
[InlineData(5, 5, 5)]

void FrontTests(int adds, int expectedFront, int size)
{
	MyCircularQueue q = new MyCircularQueue(5);
	while (adds > 0)
	{
		if (q.IsFull()) q.DeQueue();
		q.EnQueue(adds);
		adds--;
	}
	Assert.Equal(expectedFront, q.Front());
}

#endregion

#region RearTests

[Theory]
[InlineData(1, 1, 5)]
[InlineData(3, 1, 5)]
[InlineData(7, 1, 5)]
[InlineData(5, 1, 5)]

void RearTests(int adds, int expectedRear, int size)
{
	MyCircularQueue q = new MyCircularQueue(5);
	while (adds > 0)
	{
		if (q.IsFull()) q.DeQueue();
		q.EnQueue(adds);
		adds--;
	}
	Assert.Equal(expectedRear, q.Rear());
}

#endregion

#region WrapTests

[Theory]
[InlineData(1, 1, 5)]
[InlineData(5, 0, 5)]
[InlineData(4, 4, 5)]
[InlineData(0, 0, 5)]
[InlineData(6, 1, 5)]
void WrapTests(int index, int expected, int size)
{
	MyCircularQueue q = new MyCircularQueue(size);
	int result = q.Wrap(index);
	Assert.Equal(expected, result);
}

#endregion

#endregion