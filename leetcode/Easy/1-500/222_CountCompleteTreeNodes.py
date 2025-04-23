import os
import pytest
import sys

from typing import Optional, List

# Get the absolute path to the root of the project (2 levels up from the current file)
project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree, parse_values

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def countNodes(self, root: Optional[TreeNode]) -> int:
        if not root:
            return 0
        return 1 + self.countNodes(root.left) + self.countNodes(root.right)
    
    

"""
Example 1:
Input: root = [1,2,3,4,5,6]
Output: 6

Example 2:
Input: root = []
Output: 0

Example 3:
Input: root = [1]
Output: 1
"""
@pytest.mark.parametrize("values, expected", [
    ("[1,2,3,4,5,6]", 6), 
    ("[]", 0), 
    ("[1]", 1)
])
def test_countNodes(values: List[int], expected: int):
    root = populate_tree(values)
    result = Solution().countNodes(root)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])