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
    def rightSideView(self, root: Optional[TreeNode]) -> list[int]:
        result = [] 
        if not root: 
            return result
        
        queue = deque([root])
        while queue: 
            level_len = len(queue)
            for _ in range(level_len): 
                node = queue.popleft()
                if node.left: 
                    queue.append(node.left)
                if node.right: 
                    queue.append(node.right)

            result.append(node.val)
        return result

@pytest.mark.parametrize("definition, expected", [
    ("[1,2,3,4,null,null,null,5]", [1,3,4,5]), 
    ("[1,null,3]", [1, 3]), 
    ("[]", [])
])
def test_rightSideView(definition: str, expected: list[int]):
    root = populate_tree(definition)
    result = Solution().rightSideView(root)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])