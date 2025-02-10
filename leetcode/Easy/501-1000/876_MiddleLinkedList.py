import pytest
from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    def middleNode(self, head: Optional[ListNode]) -> Optional[ListNode]:
        fast = head
        slow = head
        while fast.next != None: 
            slow = slow.next
            fast = fast.next
            if fast.next != None: 
                fast = fast.next


        return slow

"""
Input: head = [1,2,3,4,5]
Output: [3,4,5]
Explanation: The middle node of the list is node 3.
Example 2:


Input: head = [1,2,3,4,5,6]
Output: [4,5,6]
Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
"""
@pytest.mark.parametrize("head, expected", [
    ([1,2,3,4,5], [3,4,5]), 
    ([1,2,3,4,5,6], [4,5,6])
])
def test_middleNode(head: list[int], expected: list[int]):
    head_node = init_ListNode(head)
    expected_node = init_ListNode(expected)
    sol = Solution()
    result = sol.middleNode(head_node)
    assert(result.val == expected_node.val)        

def init_ListNode(vals : list[int]) -> ListNode: 
    head = ListNode(vals[0])
    current = head
    for i in range(1, len(vals)): 
        current.next = ListNode(vals[i])
        current = current.next
    return head

if __name__ == "__main__": 
    pytest.main([__file__])