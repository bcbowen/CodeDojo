import pytest
from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    def deleteDuplicates(self, head: Optional[ListNode]) -> Optional[ListNode]:
        current = head
        while current != None: 
            next = current
            while next != None and next.val == current.val: 
                next = next.next
            if next != None: 
                current.next = next
            else: 
                current.next = None
            current = next
        return head

"""
Input: head = [1,1,2]
Output: [1,2]
Example 2:

Input: head = [1,1,2,3,3]
Output: [1,2,3]
"""
@pytest.mark.parametrize("head, expected", [
    ([1,1,2], [1,2]),
    ([1,1,2,3,3], [1,2,3]) 
])
def test_deleteDuplicates(head: list[int], expected: list[int]):
    sol = Solution()
    head_node = init_ListNode(head)
    expected_node = init_ListNode(expected)
    result = sol.deleteDuplicates(head_node)
    assert(get_NodeValues(result) == get_NodeValues(expected_node))

def get_NodeValues(node: ListNode) -> list[int]: 
    values = []
    while(node != None): 
        values.append(node.val)
        node = node.next
    return values

def init_ListNode(vals : list[int]) -> ListNode: 
    head = ListNode(vals[0])
    current = head
    for i in range(1, len(vals)): 
        current.next = ListNode(vals[i])
        current = current.next
    return head

if __name__ == "__main__": 
    pytest.main([__file__])