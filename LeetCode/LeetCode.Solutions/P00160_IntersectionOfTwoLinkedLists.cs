using LeetCode.Solutions.Models.LinkedList;

namespace LeetCode.Solutions.P00160_IntersectionOfTwoLinkedLists;

public class Solution
{
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        HashSet<ListNode> aNodes = new HashSet<ListNode>();
        ListNode currentA = headA;
        while (currentA != null)
        {
            aNodes.Add(currentA);
            currentA = currentA.next;
        }

        ListNode currentB = headB;
        while (currentB != null)
        {
            if (aNodes.Contains(currentB)) return currentB;
            currentB = currentB.next;
        }

        return null;
    }

    public static (ListNode, ListNode) Initialize(int[] listA, int[] listB, int skipA, int skipB)
    {
        //  listA = [4,1,8,4,5], listB = [5,6,1,8,4,5], skipA = 2, skipB = 3

        int a = 1;
        int b = 1;
        ListNode ListNodeA = new ListNode(listA[0]);
        ListNode ListNodeB = new ListNode(listB[0]);
        ListNode currentA = ListNodeA;
        while (a < skipA)
        {
            currentA.next = new ListNode(listA[a++]);
            currentA = currentA.next;
        }

        ListNode currentB = ListNodeB;
        while (b < skipB)
        {
            currentB.next = new ListNode(listB[b++]);
            currentB = currentB.next;
        }
        currentA = currentB;

        while (a < listA.Length)
        {
            currentA.next = new ListNode(listA[a++]);
            currentA = currentA.next;
        }

        return (ListNodeA, ListNodeB);
    }
}