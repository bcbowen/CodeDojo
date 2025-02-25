import pytest
import os 
import sys
from typing import Optional

# Get the absolute path to the root of the project (2 levels up from the current file)
project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree, parse_values


class Solution:
    def diameterOfBinaryTree(self, root: Optional[TreeNode]) -> int:
        max_diameter = 0
        
        def longest_path(node: TreeNode) -> int: 
            if not node: 
                return 0
            nonlocal max_diameter
            left_path = longest_path(node.left)
            right_path = longest_path(node.right)
            max_diameter = max(max_diameter, left_path + right_path)
            return max(left_path, right_path) + 1
        longest_path(root)
        return max_diameter
"""
Example 1
Input: root = [1,2,3,4,5]
Output: 3
Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].

Example 2:
Input: root = [1,2]
Output: 1
"""
@pytest.mark.parametrize("definition, expected", [
    ("[1,2,3,4,5]", 3), 
    ("[1,2]", 1)
])
def test_diameterOfBinaryTree(definition: str, expected: int):
    root = populate_tree(definition)
    result = Solution().diameterOfBinaryTree(root)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])