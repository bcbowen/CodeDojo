import pytest
import sys
import os 
from typing import Optional

# Get the absolute path to the root of the project (2 levels up from the current file)
project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree, parse_values


class Solution:
    def maxAncestorDiff(self, root: Optional[TreeNode]) -> int:

        def get_range(root: Optional[TreeNode], min_val: int, max_val: int) -> int:        
            if root == None: 
                return 0
            
            min_val = min(root.val, min_val) 
            max_val = max(root.val, max_val)
            range = max_val - min_val
            range = max(range, get_range(root.left, min_val, max_val))
            range = max(range, get_range(root.right, min_val, max_val))
            return range

        range = get_range(root, root.val, root.val) 
        return range

"""
Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
Output: 7
Explanation: We have various ancestor-node differences, some of which are given below :
|8 - 3| = 5
|3 - 7| = 4
|8 - 1| = 7
|10 - 13| = 3
Among all possible differences, the maximum value of 7 is obtained by |8 - 1| = 7.

Input: root = [1,null,2,null,0,3]
Output: 3
"""

@pytest.mark.parametrize("definition, expected", [
    ("[8,3,10,1,6,null,14,null,null,4,7,13]", 7),
    ("[1,null,2,null,0,3]", 3)
])
def test_maxAncestorDiff(definition: str, expected: int):
    root = populate_tree(definition)
    result = Solution().maxAncestorDiff(root)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__])