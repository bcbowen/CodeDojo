<Query Kind="Statements" />

public class ListNode
{
	public int val { get; set; }
	public ListNode? next { get; set; }
	public ListNode(int value = 0, ListNode? next = null)
	{
		val = value;
		this.next = next;
	}
}