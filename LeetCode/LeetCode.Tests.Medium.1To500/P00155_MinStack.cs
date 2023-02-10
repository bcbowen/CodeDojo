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

    [TestCase(new[] { -2, 0, -3}, -3)]
    [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7}, 1)]
    [TestCase(new[] { 7, 6, 5, 4, 3, 2, 1}, 1)]
    [TestCase(new[] { 4, 8, 2, 7, 1, 8, 3}, 1)]
    [TestCase(new[] { 4, -9, 4, -5, 0}, -9)]
    public void MinStackMinListTests(int[] values, int expected) 
    {
        SortedListNode list = new SortedListNode(values[0]);
        for (int i = 1; i < values.Length; i++) 
        {
            list = list.Insert(values[i]);
        }
        int result = list.Value;
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