using LeetCode.Solutions.P00708_InsertIntoCircularList;
using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Tests.P00708_InsertIntoCircularList;

public class Tests
{

    [Test]
    public void CircularListTest1()
    {
        ListNode head = new ListNode(3);
        ListNode current = head;
        current.next = new ListNode(4);
        current = current.next;
        current.next = new ListNode(1);
        current = current.next;
        current.next = head;

        ListNode result = new Solution().Insert(head, 2);
        Assert.AreEqual(3, result.val);
        Assert.AreEqual(4, result.next.val);
        Assert.AreEqual(1, result.next.next.val);
        Assert.AreEqual(2, result.next.next.next.val);
        Assert.AreEqual(result, result.next.next.next.next);
    }

    [Test]
    public void CircularListTest2()
    {
        ListNode head = new ListNode(3);
        ListNode current = head;
        current.next = new ListNode(4);
        current = current.next;
        current.next = new ListNode(1);
        current = current.next;
        current.next = head;

        ListNode result = new Solution().Insert(head, 5);
        Assert.AreEqual(3, result.val);
        Assert.AreEqual(4, result.next.val);
        Assert.AreEqual(5, result.next.next.val);
        Assert.AreEqual(1, result.next.next.next.val);
        Assert.AreEqual(result, result.next.next.next.next);
    }

    /*
    Input:
    [1,3,5]
    2
    Output:
    [1,3,2,5]
    Expected:
    [1,2,3,5]
    */

    [Test]
    public void CircularListTest6()
    {
        ListNode head = new ListNode(1);
        ListNode current = head;
        current.next = new ListNode(3);
        current = current.next;
        current.next = new ListNode(5);
        current = current.next;
        current.next = head;

        ListNode result = new Solution().Insert(head, 2);
        Assert.AreEqual(1, result.val);
        Assert.AreEqual(2, result.next.val);
        Assert.AreEqual(3, result.next.next.val);
        Assert.AreEqual(5, result.next.next.next.val);
        Assert.AreEqual(result, result.next.next.next.next);
    }

    [Test]
    public void CircularListTest3()
    {
        ListNode head = new ListNode(3);
        ListNode current = head;
        current.next = new ListNode(4);
        current = current.next;
        current.next = new ListNode(2);
        current = current.next;
        current.next = head;

        ListNode result = new Solution().Insert(head, 1);
        Assert.AreEqual(3, result.val);
        Assert.AreEqual(4, result.next.val);
        Assert.AreEqual(1, result.next.next.val);
        Assert.AreEqual(2, result.next.next.next.val);
        Assert.AreEqual(result, result.next.next.next.next);
    }

    /*
    Input:
    [5,1,3]
    4
    Output:
    [5,1,4,3]
    Expected:
    [5,1,3,4]
    */
    [Test]
    public void CircularListTest4()
    {
        ListNode head = new ListNode(5);
        ListNode current = head;
        current.next = new ListNode(1);
        current = current.next;
        current.next = new ListNode(3);
        current = current.next;
        current.next = head;

        ListNode result = new Solution().Insert(head, 4);
        Assert.AreEqual(5, result.val);
        Assert.AreEqual(1, result.next.val);
        Assert.AreEqual(3, result.next.next.val);
        Assert.AreEqual(4, result.next.next.next.val);
        Assert.AreEqual(result, result.next.next.next.next);
    }

    /*
    Input:
    [3,3,5]
    0
    Output:
    [3,0,3,5]
    Expected:
    [3,3,5,0]
    */
    [Test]
    public void CircularListTest5()
    {
        ListNode head = new ListNode(3);
        ListNode current = head;
        current.next = new ListNode(3);
        current = current.next;
        current.next = new ListNode(5);
        current = current.next;
        current.next = head;

        ListNode result = new Solution().Insert(head, 0);
        Assert.AreEqual(3, result.val);
        Assert.AreEqual(3, result.next.val);
        Assert.AreEqual(5, result.next.next.val);
        Assert.AreEqual(0, result.next.next.next.val);
        Assert.AreEqual(result, result.next.next.next.next);
    }


    /*
    [3,3,3]
    0
    */

    [Test]
    public void CircularListTest7()
    {
        ListNode head = new ListNode(3);
        ListNode current = head;
        current.next = new ListNode(3);
        current = current.next;
        current.next = new ListNode(3);
        current = current.next;
        current.next = head;

        ListNode result = new Solution().Insert(head, 0);
        Assert.AreEqual(3, result.val);
        Assert.AreEqual(3, result.next.val);
        Assert.AreEqual(3, result.next.next.val);
        Assert.AreEqual(0, result.next.next.next.val);
        Assert.AreEqual(result, result.next.next.next.next);
    }

    /*
    Input: head = [], insertVal = 1
    Output: [1]
    */

    [Test]
    public void EmptyListNodeTest()
    {
        ListNode head = null;
        ListNode result = new Solution().Insert(head, 1);
        Assert.AreEqual(1, result.val);
        Assert.AreEqual(result, result.next);
    }

    /*
    Input: head = [1], insertVal = 0
    Output: [1,0]
    */

    [Test]
    public void SingleListNodeTest()
    {
        ListNode head = new ListNode(1);
        head.next = head;

        ListNode result = new Solution().Insert(head, 0);
        Assert.AreEqual(1, result.val);
        Assert.AreEqual(0, result.next.val);
        Assert.AreEqual(result, result.next.next);
    }

}