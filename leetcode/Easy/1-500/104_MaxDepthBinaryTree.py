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
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        def dive(root : TreeNode, currentDepth: int) -> int: 
            if not root.left and not root.right: 
                return currentDepth
            max_depth = currentDepth
            if root.left: 
                max_depth = dive(root.left, currentDepth + 1)
            if root.right: 
                max_depth = max(max_depth, dive(root.right, currentDepth + 1))
            return max_depth
        if not root: 
            return 0

        depth = dive(root, 1)

        return depth


@pytest.mark.parametrize("definition, expected", [
    ("[]", 0),
    ("[3,9,20,null,null,15,7]", 3), 
    ("[1,null,2]", 2)
])
def test_maxDepth(definition: str, expected: int): 
    root = populate_tree(definition)
    result = Solution().maxDepth(root)
    assert(result == expected)

def test_import(): 
    vals = "[1,2,3]"
    result = parse_values(vals)
    expected = [1,2,3]
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])