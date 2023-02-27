<Query Kind="Program">
  <Namespace>Xunit</Namespace>
</Query>

#load "xunit"

void Main()
{
	RunTests();  // Call RunTests() or press Alt+Shift+T to initiate testing.
}


public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int val = 0, ListNode next = null)
	{
		this.val = val;
		this.next = next;
	}
}

public class Solution
{
	public int GetDecimalValue(ListNode head)
	{
		
		int val = head.val;
		ListNode node = head.next;
		while (node != null) 
		{
			val <<= 1;
			val += node.val;
			node = node.next;
		}
		return val;
	}

	internal ListNode InitList(int[] values) 
	{
		ListNode head = new ListNode(values[0]);
		ListNode node = head;
		for (int i = 1; i < values.Length; i++)
		{
			node.next = new ListNode(values[i]);
			node = node.next;
		}
		
		return head;
	}
}

#region private::Tests

/*
Input: head = [1,0,1]
Output: 5
Explanation: (101) in base 2 = (5) in base 10
Example 2:

Input: head = [0]
Output: 0

Input: head = [1,0,1,1]
Output: 11 (8 + 0 + 2 + 1)

Input: head = [1,0,0,0]
Output: 8 (8 + 0 + 0 + 0)
*/
[Theory]
[InlineData(new[] { 1, 0, 1 }, 5)]
[InlineData(new[] { 0 }, 0)]
[InlineData(new[] { 1, 0, 1, 1 }, 11)]
[InlineData(new[] { 1, 0, 0, 0 }, 8)]
void GetValueTests(int[] values, int expected) 
{
	Solution solution = new Solution(); 
	ListNode node = solution.InitList(values);
	int result = solution.GetDecimalValue(node);
	Assert.Equal(expected, result);
}



[Fact] void Test_Xunit() => Assert.True(1 + 1 == 2);

#endregion