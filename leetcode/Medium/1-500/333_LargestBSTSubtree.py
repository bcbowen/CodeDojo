import os
import pytest
import sys
from collections import deque
from typing import Optional

project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree


# Each node will return min node value, max node value, size
class NodeValue:
    def __init__(self, min_node, max_node, max_size):
        self.max_node = max_node
        self.min_node = min_node
        self.max_size = max_size

class Solution:
    def largestBSTSubtreeHelper(self, root: Optional[TreeNode]) -> NodeValue: 
        result = NodeValue(float('inf'), -float('inf'), 0)
        if not root: 
            return result
        
        left_value = self.largestBSTSubtreeHelper(root.left)
        right_value = self.largestBSTSubtreeHelper(root.right)

        is_bst = left_value.max_node < root.val and right_value.min_node > root.val

        if is_bst: 
            result.min_node = min(left_value.min_node, root.val)
            result.max_node = max(right_value.max_node, root.val)
            result.max_size = right_value.max_size + left_value.max_size + 1
        else: 
            # Otherwise, return [-inf, inf] so that parent can't be valid BST
            result.min_node = -float('inf')
            result.max_node = float('inf')
            result.max_size = max(left_value.max_size, right_value.max_size)
        
        return result

    def largestBSTSubtree(self, root: Optional[TreeNode]) -> int:
        return self.largestBSTSubtreeHelper(root).max_size

"""
Initial attempt, doesn't always return the correct result
"""
class Solution_1:
    # Initial implementation 
    def largestBSTSubtree_1(self, root: Optional[TreeNode]) -> int:
        q = deque() 
        q.append(root)
        result = 0
        while q: 
            node = q.popleft()
            if not node: 
                continue

            if Solution_1.is_bst(node): 
                result = Solution_1.count_nodes(node)
                break
            q.append(node.left)
            q.append(node.right)
        return result
    
    @staticmethod
    def count_nodes(root: Optional[TreeNode]) -> int: 
        count = 0
        def traverse_nodes(node: Optional[TreeNode]): 
            if not node: 
                return 
            nonlocal count
            count += 1
            traverse_nodes(node.left)
            traverse_nodes(node.right)
        traverse_nodes(root)
        return count
    
    @staticmethod
    def is_bst(root: Optional[TreeNode]) -> bool: 
        if not root: 
            return False
        
        if root.left and (root.left.val >= root.val or not Solution_1.is_bst(root.left)): 
            return False
        
        if root.right and (root.right.val <= root.val or not Solution_1.is_bst(root.right)): 
            return False
        return True



"""
Example 1:
Input: root = [10,5,15,1,8,null,7]
Output: 3
Explanation: The Largest BST Subtree in this case is the highlighted one. The return value is the subtree's size, which is 3.

Example 2:
Input: root = [4,2,7,2,3,5,null,2,null,null,null,null,null,1]
Output: 2

TC 64
root: [3,2,4,null,null,1]
output: 2
"""
@pytest.mark.parametrize("definition, expected", [
    ("[10,5,15,1,8,null,7]", 3), 
    ("[4,2,7,2,3,5,null,2,null,null,null,null,null,1]", 2), 
    ("[3,2,4,null,null,1]", 2)

])
def test_largestBSTSubtree(definition: str, expected: int):
    root = populate_tree(definition)
    result = Solution().largestBSTSubtree(root)
    assert(result == expected)
    
"""
Example 1:
Input: root = [10,5,15,1,8,null,7]
Output: 3
Explanation: The Largest BST Subtree in this case is the highlighted one. The return value is the subtree's size, which is 3.

Example 2:
Input: root = [4,2,7,2,3,5,null,2,null,null,null,null,null,1]
Output: 2

"""
@pytest.mark.parametrize("definition, expected", [
    ("[10,5,15,1,8,null,7]", 6), 
    ("[4,2,7,2,3,5,null,2,null,null,null,null,null,1]", 8)
])
def test_CountNodes(definition: str, expected: int):
    root = populate_tree(definition)
    result = Solution_1.count_nodes(root)
    assert(result == expected)

@pytest.mark.parametrize("definition, expected", [
    ("[10,5,15]", True), 
    ("[10,5,null]", True), 
    ("[10,null,15]", True), 
    ("[10,15,55]", False), 
    ("[10,5,7]", False),
    ("[10,5,15,3,7,11,18]", True), 
    ("[10,5,15,6,7,11,18]", False), 
    ("[10,5,9,3,7,11,18]", False),
    ("[10,5,15,3,7,18,18]", False),
    ("[10,5,15,3,7,11,13]", False),

])
def test_is_bst(definition: str, expected: bool):
    root = populate_tree(definition)
    result = Solution_1.is_bst(root)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 