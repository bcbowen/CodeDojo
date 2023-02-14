using LeetCode.Solutions.Medium.P00155_MinStack;

namespace LeetCode.Tests.Medium.P00155_MinStack;

[TestFixture]
[Category("Medium")]
public partial class MinStackTests
{
    [Test]
    public void MinStackSampleTest1()
    {
        MinStack stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);
        int expected = -3;
        int result = stack.GetMin();
        Assert.That(result, Is.EqualTo(expected));
        stack.Pop();
        result = stack.Top();
        expected = 0;
        Assert.That(result, Is.EqualTo(expected));
        result = stack.GetMin();
        expected = -2;
        Assert.That(result, Is.EqualTo(expected));
    }

    // ["MinStack","push","push","push","getMin","top","pop","getMin"]
    //[[],[-2],[0],[-1],[],[],[],[]]

    [Test]
    public void MinStackSampleTest2()
    {
        MinStack stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-1);
        int expected = -2;
        int result = stack.GetMin();
        Assert.That(result, Is.EqualTo(expected));

        result = stack.Top();
        expected = -1;
        Assert.That(result, Is.EqualTo(expected));

        stack.Pop();
        result = stack.GetMin();
        expected = -2;
        Assert.That(result, Is.EqualTo(expected));
    }

    
}