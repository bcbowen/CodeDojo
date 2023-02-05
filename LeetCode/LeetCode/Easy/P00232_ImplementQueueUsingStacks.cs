using LeetCode.Solutions.Easy;

namespace LeetCode.Tests.Easy;

public class Tests
{
    [Test]
    public void Example1Test()
    {
        MyQueue queue = new MyQueue();
        queue.Push(1);
        queue.Push(2);
        int result = queue.Peek();
        Assert.AreEqual(1, result);
        result = queue.Pop();
        Assert.AreEqual(1, result);
        Assert.False(queue.Empty());
        result = queue.Pop();
        Assert.AreEqual(2, result);
        Assert.True(queue.Empty());
    }

}