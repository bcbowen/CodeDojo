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
    def largestValues(self, root: Optional[TreeNode]) -> list[int]:
        result = [] 
        if not root: 
            return result
        
        queue = deque([root])
        while queue: 
            level_max = queue[0].val
            level_len = len(queue)
            for _ in range(level_len): 
                node = queue.popleft()
                level_max = max(level_max, node.val)
                if node.left: 
                    queue.append(node.left)
                if node.right: 
                    queue.append(node.right)

            result.append(level_max)
        return result

@pytest.mark.parametrize("definition, expected", [
    ("[1,3,2,5,3,null,9]", [1,3,9]), 
    ("[1,2,3]", [1, 3]), 
    ("[]", [])
])
def test_largestValues(definition: str, expected: list[int]):
    root = populate_tree(definition)
    result = Solution().largestValues(root)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])