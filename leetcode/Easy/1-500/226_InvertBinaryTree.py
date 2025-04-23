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
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree, get_definition

# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right
class Solution:
    def invertTree(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        if root: 
            temp = root.left
            root.left = self.invertTree(root.right)
            root.right = self.invertTree(temp)

        return root

"""
Example 1:
Input: root = [4,2,7,1,3,6,9]
Output: [4,7,2,9,6,3,1]

Example 2:
Input: root = [2,1,3]
Output: [2,3,1]

Example 3:
Input: root = []
Output: []
"""
@pytest.mark.parametrize("values, expected", [
    ("[4,2,7,1,3,6,9]", "[4,7,2,9,6,3,1]"), 
    ("[2,1,3]", "[2,3,1]"), 
    ("[]", "[]")
])
def test_invertTree(values: str, expected: str):
    root = populate_tree(values)
    result_tree = Solution().invertTree(root)
    result = get_definition(result_tree)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])