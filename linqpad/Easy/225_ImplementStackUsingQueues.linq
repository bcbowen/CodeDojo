<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class MyStack
{

	Queue<int> q1 = new Queue<int>();
	Queue<int> q2 = new Queue<int>();

	public MyStack()
	{

	}

	public void Push(int x)
	{
		q1.Enqueue(x);
	}

	public int Pop()
	{
		while (q1.Count > 1)
		{
			q2.Enqueue(q1.Dequeue());
		}

		int result = q1.Dequeue();

		while (q2.Count > 0)
		{
			q1.Enqueue(q2.Dequeue());
		}

		return result;

	}

	public int Top()
	{
		while (q1.Count > 1)
		{
			q2.Enqueue(q1.Dequeue());
		}

		int result = q1.Peek();
		q2.Enqueue(q1.Dequeue());

		while (q2.Count > 0)
		{
			q1.Enqueue(q2.Dequeue());
		}

		return result;
	}

	public bool Empty()
	{
		return q1.Count == 0;
	}
}

#region private::Tests

[Fact]
void Test()
{
	MyStack stack = new MyStack();

	stack.Push(1);
	stack.Push(2);
	int expected = 2;
	int result = stack.Top(); // return 2
	Assert.Equal(expected, result);

	expected = 2;
	result = stack.Pop(); // return 2
	Assert.Equal(expected, result);

	Assert.False(stack.Empty()); // return False
}

/*
Example 1:

Input
["MyStack", "push", "push", "top", "pop", "empty"]
[[], [1], [2], [], [], []]
Output
[null, null, null, 2, 2, false]

Explanation
MyStack myStack = new MyStack();
myStack.push(1);
myStack.push(2);
myStack.top(); // return 2
myStack.pop(); // return 2
myStack.empty(); // return False
*/

#endregion