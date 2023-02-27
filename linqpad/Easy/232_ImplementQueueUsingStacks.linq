<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class MyQueue
{

	private Stack<int> _stackA; 
	private Stack<int> _stackB; 

	public MyQueue()
	{
		_stackA = new Stack<int>();
		_stackB = new Stack<int>();
	}

	private void ResetQueues() 
	{
		while (_stackB.Count > 0) 
		{
			_stackA.Push(_stackB.Pop());
		}
	}

	private void QueueNext()
	{
		while(_stackA.Count > 1) 
		{
			_stackB.Push(_stackA.Pop());
		}
	}

	public void Push(int x)
	{
		ResetQueues();
		_stackA.Push(x);
	}

	public int Pop()
	{
		if (_stackA.Count == 1) return _stackA.Pop();
		
		ResetQueues();
		QueueNext();
		return _stackA.Pop();
	}

	public int Peek()
	{
		if (_stackA.Count == 1) return _stackA.Peek();

		ResetQueues();
		QueueNext();
		return _stackA.Peek();
	}

	public bool Empty()
	{
		return _stackA.Count + _stackB.Count == 0;
	}
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

#region private::Tests

[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

[Fact]
void Example1Test() 
{
	MyQueue queue = new MyQueue(); 
	queue.Push(1);
	queue.Push(2);
	int result = queue.Peek(); 
	Assert.Equal(1, result);
	result = queue.Pop(); 
	Assert.Equal(1, result);
	Assert.False(queue.Empty());
	result = queue.Pop();
	Assert.Equal(2, result);
	Assert.True(queue.Empty());
}
/*
Example 1:

Input
["MyQueue", "push", "push", "peek", "pop", "empty"]
[[], [1], [2], [], [], []]
Output
[null, null, null, 1, 1, false]

Explanation
MyQueue myQueue = new MyQueue();
myQueue.push(1); // queue is: [1]
myQueue.push(2); // queue is: [1, 2] (leftmost is front of the queue)
myQueue.peek(); // return 1
myQueue.pop(); // return 1, queue is [2]
myQueue.empty(); // return false
*/

#endregion