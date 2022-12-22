namespace LeetCode.Solutions.Models.LinkedList
{
    public class ListNode
    {
        public int val { get; init; }
        public ListNode? next { get; set; }
        public ListNode(int value, ListNode? next = null)
        {
            val = value;
            this.next = next;
        }
    }
}
