using LeetCode.Solutions.Medium.P00622_CircularQueue;

namespace LeetCode.Tests.Medium.P00622_CircularQueue;

[TestFixture]
[Category("Medium")]
public class Tests
{
    #region Troubleshooting

    [Test]
    public void BigTest2()
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

    [Test]
    public void WholeShebang()
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
        Assert.AreEqual(3, q.Rear());

        // myCircularQueue.isFull();   // return True
        Assert.True(q.IsFull());

        // myCircularQueue.deQueue();  // return True
        Assert.True(q.DeQueue());

        // myCircularQueue.enQueue(4); // return True
        Assert.True(q.EnQueue(4));

        // myCircularQueue.Rear();     // return 4
        Assert.AreEqual(4, q.Rear());

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

    [Test]
    public void NewQueueIsEmpty()
    {
        MyCircularQueue q = new MyCircularQueue(5);
        Assert.True(q.IsEmpty());
    }

    [TestCase(5, 2)]
    [TestCase(5, 4)]
    [TestCase(50, 20)]
    public void QueueEmptyAfterRemovingEverything(int size, int items)
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

    [TestCase(1, 1, 5)]
    [TestCase(3, 3, 5)]
    [TestCase(7, 5, 5)]
    [TestCase(5, 5, 5)]

    public void FrontTests(int adds, int expectedFront, int size)
    {
        MyCircularQueue q = new MyCircularQueue(5);
        while (adds > 0)
        {
            if (q.IsFull()) q.DeQueue();
            q.EnQueue(adds);
            adds--;
        }
        Assert.AreEqual(expectedFront, q.Front());
    }

    #endregion

    #region RearTests

    [TestCase(1, 1, 5)]
    [TestCase(3, 1, 5)]
    [TestCase(7, 1, 5)]
    [TestCase(5, 1, 5)]

    public void RearTests(int adds, int expectedRear, int size)
    {
        MyCircularQueue q = new MyCircularQueue(5);
        while (adds > 0)
        {
            if (q.IsFull()) q.DeQueue();
            q.EnQueue(adds);
            adds--;
        }
        Assert.AreEqual(expectedRear, q.Rear());
    }

    #endregion

    #region WrapTests

    [TestCase(1, 1, 5)]
    [TestCase(5, 0, 5)]
    [TestCase(4, 4, 5)]
    [TestCase(0, 0, 5)]
    [TestCase(6, 1, 5)]
    public void WrapTests(int index, int expected, int size)
    {
        MyCircularQueue q = new MyCircularQueue(size);
        int result = q.Wrap(index);
        Assert.AreEqual(expected, result);
    }

    #endregion


}