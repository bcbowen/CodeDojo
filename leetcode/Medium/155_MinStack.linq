<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}

public class MinStack
{
	private StackNode? _root = null;
	public MinStack()
	{ }

	public void Push(int val)
	{
		if (_root == null)
		{
			_root = new StackNode(val);
			_root.MinValue = val;
		}
		else
		{
			_root = _root.Push(val);
		}

	}

	public void Pop()
	{
		if (_root != null)
		{
			_root = _root.Pop();
		}
	}

	public int Top()
	{
		return _root != null ? _root.Value : 0;
	}

	public int GetMin()
	{
		return _root != null ? _root.MinValue : 0;
	}
}

internal class StackNode
{
	public int MinValue { get; internal set; }
	public StackNode(int value)
	{
		Value = value;
	}
	public int Value { get; init; }
	public StackNode? Next { get; set; }

	public StackNode Push(int value)
	{
		StackNode node = new StackNode(value);
		node.MinValue = Math.Min(MinValue, value);
		node.Next = this;
		return node;
	}

	public StackNode? Pop()
	{
		StackNode? node = Next;
		Next = null;
		return node;
	}
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

[Fact]
public void MinStackSampleTest1()
{
	MinStack stack = new MinStack();
	stack.Push(-2);
	stack.Push(0);
	stack.Push(-3);
	int expected = -3;
	int result = stack.GetMin();
	Assert.Equal(expected, result);
	stack.Pop();
	result = stack.Top();
	expected = 0;
	Assert.Equal(expected, result);
	result = stack.GetMin();
	expected = -2;
	Assert.Equal(expected, result);
}

// ["MinStack","push","push","push","getMin","top","pop","getMin"]
//[[],[-2],[0],[-1],[],[],[],[]]

[Fact]
public void MinStackSampleTest2()
{
	MinStack stack = new MinStack();
	stack.Push(-2);
	stack.Push(0);
	stack.Push(-1);
	int expected = -2;
	int result = stack.GetMin();
	Assert.Equal(expected, result);

	result = stack.Top();
	expected = -1;
	Assert.Equal(expected, result);

	stack.Pop();
	result = stack.GetMin();
	expected = -2;
	Assert.Equal(expected, result);
}