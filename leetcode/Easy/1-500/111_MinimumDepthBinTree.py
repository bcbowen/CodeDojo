import pytest
import os 
import sys
from typing import Optional

project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree


class Solution:
    def minDepth(self, root: Optional[TreeNode]) -> int:
        def dfs(root: Optional[TreeNode], depth: int) -> int: 
            if not root: 
                return depth - 1
            elif not root.left and not root.right: 
                return depth
            
            l = 1
            r = 1
            if root.left: 
                l = dfs(root.left, depth + 1)
            if root.right: 
                r = dfs(root.right, depth + 1)
            
            if l == 1: 
                return r
            elif r == 1: 
                return l
            else: 
                return min(l, r)
            
        return dfs(root, 1)

@pytest.mark.parametrize("definition, expected", [
    ("[2,null,3,null,4,null,5,null,6]", 5), 
    ("[3,9,20,null,null,15,7]", 2), 
    ("[]", 0)
])
def test_minDepth(definition: str, expected: int): 
    root = populate_tree(definition)
    result = Solution().minDepth(root)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])