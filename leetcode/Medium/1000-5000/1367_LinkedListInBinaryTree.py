import pytest
from typing import Optional

class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
         self.val = val
         self.left = left
         self.right = right

class Solution(object):
    def isSubPath(self, head: Optional[ListNode], root: Optional[TreeNode]) -> bool:
        return self.search_path(head, root) 

    def search_path(self, list_node: ListNode | None, tree_node: TreeNode | None) -> bool:
        if tree_node == None or list_node == None: 
            return False
        
        if tree_node.val != list_node.val: 
            if self.search_path(list_node, tree_node.left): 
                return True
            elif self.search_path(list_node, tree_node.right): 
                return True
        else: 
            # current node matches, check subsequent nodes
            list_node = list_node.next
            if list_node == None: 
                # we've reached the end of the list, so this is a match
                return True
            if self.search_path(list_node, tree_node.left): 
                return True
            elif self.search_path(list_node, tree_node.right): 
                return True
        return False

"""
Example 1:
Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true
Explanation: Nodes in blue form a subpath in the binary Tree.  

Example 2:
Input: head = [1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: true

Example 3:
Input: head = [1,4,2,6,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
Output: false
Explanation: There is no path in the binary tree that contains all the elements of the linked list from head.
"""

"""
                 1
               /    \
              4      4
               \    /
                2  2
               /  / \
              1  6   8
                    / \
                   1   3

"""
# ex: [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]

def populate_tree(nodes: str) -> TreeNode: 
    nodes = nodes[1:len(nodes)]
    nodeList = nodes.split(',')
    root = TreeNode(nodeList[0])
    #current = root
    queue = [root]
    i = 1
    while len(queue) > 0: 
        current = queue.pop(0)
        if nodeList[i] != "null": 
            
        current.left = TreeNode(nodeList[i])
        
        i += 1
        current.right = TreeNode(nodeList[i])


    

def get_test_tree() -> TreeNode: 
    root = TreeNode(1)
    root.left = TreeNode(4)
    root.right = TreeNode(4)
    current = root.left
    current.right = TreeNode(2)
    current = current.right
    current.left = TreeNode(1)
    current = root.right
    current.left = TreeNode(2)
    current = current.left
    current.left = TreeNode(6)
    current.right = TreeNode(8)
    current = current.right
    current.left = TreeNode(1)
    current.right = TreeNode(3)
    return root



def get_test_list(values: list[int]) -> ListNode: 
    head = ListNode(values[0])
    current = head
    for i in range(1, len(values)):
        current.next = ListNode(values[i])
        current = current.next
    return head

def test_get_tree(): 
   root = get_test_tree()
   current = root
   assert current.val == 1
   assert current.left.val == 4
   assert current.right.val == 4
   current = current.left
   assert current.right.val == 2
   assert current.right.left.val == 1
   current = root.right
   assert current.left.val == 2
   assert current.left.left.val == 6
   assert current.right == None
   current = current.left
   assert current.right.val == 8
   assert current.right.left.val == 1
   assert current.right.right.val == 3

def test_get_list(): 
    values = [1,2,3]
    list = get_test_list(values)
    assert list.val == 1
    assert list.next.val == 2
    assert list.next.next.val == 3
    assert list.next.next.next == None


def test_1():
    #Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
    #Output: true
    list_values = [4, 2, 8]
    tree = get_test_tree()
    list = get_test_list(list_values)
    expected = True
    solution = Solution()
    result = solution.isSubPath(list, tree)
    assert result == expected

def test_2():
    #Input: head = [1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
    #Output: true
    list_values = [1,4,2,6]
    tree = get_test_tree()
    list = get_test_list(list_values)
    expected = True
    solution = Solution()
    result = solution.isSubPath(list, tree)
    assert result == expected

def test_3():
    #Input: head = [1,4,2,6,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
    #Output: false
    list_values = [1,4,2,6,8]
    tree = get_test_tree()
    list = get_test_list(list_values)
    expected = False
    solution = Solution()
    result = solution.isSubPath(list, tree)
    assert result == expected


if __name__ == "__main__":
    pytest.main([__file__])