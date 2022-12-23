using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P00002_Add2Numbers;

 public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode sum = null;
        ListNode current = null;
        int carry = 0;
        int value = 0;
        while (l1 != null || l2 != null)
        {
            value = carry;
            if (l1 != null)
            {
                value += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                value += l2.val;
                l2 = l2.next;
            }
            //value = l1.val + l2.val + carry;
            carry = value > 9 ? 1 : 0;
            //sum.val = value % 10;

            if (sum == null)
            {
                sum = new ListNode(value % 10);
                current = sum;
            }
            else
            {
                current.next = new ListNode(value % 10);
                current = current.next;
            }
        }
        if (carry == 1) current.next = new ListNode(carry);
        return sum;
    }
}