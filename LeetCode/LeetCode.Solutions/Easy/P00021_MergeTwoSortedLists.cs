using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.Easy.P00021_MergeTwoSortedLists;

public class Solution
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null && list2 == null) return null;
        if (list1 == null) return list2;
        if (list2 == null) return list1;

        ListNode mergedHead = null;
        ListNode mergedCurrent = null;
        while (list1 != null || list2 != null)
        {
            if (list1 != null && (list2 == null || list1.val <= list2.val))
            {
                if (mergedHead == null)
                {
                    mergedHead = new ListNode(list1.val);
                    mergedCurrent = mergedHead;
                }
                else
                {
                    mergedCurrent.next = new ListNode(list1.val);
                    mergedCurrent = mergedCurrent.next;
                }
                list1 = list1.next;
            }
            else if (list2 != null && (list1 == null || list2.val <= list1.val))
            {
                if (mergedHead == null)
                {
                    mergedHead = new ListNode(list2.val);
                    mergedCurrent = mergedHead;
                }
                else
                {
                    mergedCurrent.next = new ListNode(list2.val);
                    mergedCurrent = mergedCurrent.next;
                }
                list2 = list2.next;
            }
        }
        return mergedHead;
    }
}