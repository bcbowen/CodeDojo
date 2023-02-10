using LeetCode.Solutions.Medium.P00155_MinStack;

namespace LeetCode.Tests.Medium.P00155_MinStack;

[TestFixture]
[Category("Medium")]
public partial class MinStackTests
{
    [Test]
    public void MinStackSampleTest() 
    {
        MinStack stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);
        int expected = -3;
        int result = stack.getMin();
        Assert.That(result, Is.EqualTo(expected));
        stack.Pop();
        result = stack.top();
        expected = 0;
        Assert.That(result, Is.EqualTo(expected));
        result = stack.getMin();
        expected = -2;
        Assert.That(result, Is.EqualTo(expected));
    }
    /*
    
    Input
    ["MinStack","push","push","push","getMin","pop","top","getMin"]
    [[],[-2],[0],[-3],[],[],[],[]]

    Output
    [null,null,null,null,-3,null,0,-2]

    Explanation
    MinStack minStack = new MinStack();
    minStack.push(-2);
    minStack.push(0);
    minStack.push(-3);
    minStack.getMin(); // return -3
    minStack.pop();
    minStack.top();    // return 0
    minStack.getMin(); // return -2
    */
}