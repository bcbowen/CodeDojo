import pytest
import os 
import sys
from collections import deque
from typing import Optional

project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree

class Solution:
    def findSecondMinimumValue(self, root: Optional[TreeNode]) -> int:
        if not root or not root.left or not root.right or root.left.val == root.right.val: 
            return -1
        return max(root.left.val, root.right.val)
    
"""
Example 1:
Input: root = [2,2,5,null,null,5,7]
Output: 5
Explanation: The smallest value is 2, the second smallest value is 5.

Example 2:
Input: root = [2,2,2]
Output: -1
Explanation: The smallest value is 2, but there isn't any second smallest value.

TC 38: 
[1,1,3,1,1,3,4,3,1,1,1,3,8,4,8,3,3,1,6,2,1] -> 2
"""
@pytest.mark.parametrize("definition, expected", [
    ("[2,2,5,null,null,5,7]", 5), 
    ("[2,2,2]", -1), 
    ("[1,1,3,1,1,3,4,3,1,1,1,3,8,4,8,3,3,1,6,2,1]", 2)
])
def test_findSecondMinimumValue(definition: str, expected: int):
    root = populate_tree(definition)
    result = Solution().findSecondMinimumValue(root)
    assert(result == expected)



if __name__ == "__main__": 
    pytest.main([__file__])