import pytest
from typing import Optional

# Definition for singly-linked list.
class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next

class Solution:
    def reverseBetween(self, head: Optional[ListNode], left: int, right: int) -> Optional[ListNode]:
        if head.next == None or left == right: 
            return head
        
        while left < right: 
            head = self.swap_nodes(head, left, right)
            left += 1
            right -= 1
        return head

    def swap_nodes(self, head: ListNode, left: int, right: int) -> ListNode: 
        if head.next == None or left == right: 
            return head

        right_node = head
        pre_right_node = head
        current = head
        position = 1

        if left > 1: 
            while position < left - 1: 
                current = current.next
                position += 1
            pre_left_node = current
            current = current.next
            position += 1
        else: 
            pre_left_node = None

        left_node = current
        
        while position < right - 1: 
            current = current.next
            position += 1
        pre_right_node = current
        right_node = current.next

        if pre_left_node != None: 
            pre_left_node.next = right_node
        pre_right_node.next = left_node
        post_right_node = right_node.next
        right_node.next = left_node.next
        left_node.next = post_right_node

        if left == 1: 
            head = right_node
        return head



"""
Input: head = [1,2,3,4,5], left = 2, right = 4
Output: [1,4,3,2,5]
Example 2:

Input: head = [5], left = 1, right = 1
Output: [5]
"""
@pytest.mark.parametrize("head_vals, left, right, expected_vals", [
    ([1,2,3,4,5], 2, 4, [1,4,3,2,5]),
    ([5], 1, 1, [5]) 
])
def test_reverseBetween(head_vals: list[int], left: int, right: int, expected_vals: Optional[ListNode]):
    head_list = init_ListNode(head_vals)
    sol = Solution()
    result_list = sol.reverseBetween(head_list, left, right)
    result_vals = get_NodeValues(result_list)
    assert(result_vals == expected_vals)


@pytest.mark.parametrize("head_vals, left, right, expected_vals", [
    ([1,2,3,4,5], 2, 4, [1,4,3,2,5]),
    ([1,2,3,4,5], 1, 5, [5,2,3,4,1]),
    ([1,2], 1, 2, [2,1]), 
    ([5], 1, 1, [5]) 
])
def test_swap_nodes(head_vals: list[int], left: int, right: int, expected_vals: Optional[ListNode]):
    head_list = init_ListNode(head_vals)
    sol = Solution()
    result_list = sol.swap_nodes(head_list, left, right)
    result_vals = get_NodeValues(result_list)
    assert(result_vals == expected_vals)

def swap_nodes(head: ListNode, left: int, right: int) -> ListNode: 
    if head.next == None or left == right: 
        return head

    right_node = head
    pre_right_node = head
    current = head
    position = 1

    if left > 1: 
        while position < left - 1: 
            current = current.next
            position += 1
        pre_left_node = current
        current = current.next
        position += 1
    else: 
        pre_left_node = None

    left_node = current
    
    while position < right - 1: 
        current = current.next
        position += 1
    pre_right_node = current
    right_node = current.next

    if pre_left_node != None: 
        pre_left_node.next = right_node
    pre_right_node.next = left_node
    post_right_node = right_node.next
    right_node.next = left_node.next
    left_node.next = post_right_node

    if left == 1: 
        head = right_node
    return head


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