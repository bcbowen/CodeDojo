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
    def zigzagLevelOrder(self, root: Optional[TreeNode]) -> list[list[int]]:
        queue = deque([root])
        result = []
        if not root: 
            return result
        row = 0
        while queue: 
            values = []
            level_len = len(queue)
            for _ in range(level_len): 
                node = queue.popleft()
                if row % 2 == 0: 
                    values.append(node.val)
                else: 
                    values.insert(0, node.val)
                
                if node.left: 
                    queue.append(node.left)
                if node.right: 
                    queue.append(node.right)
            result.append(values)
            row += 1
            
        return result

@pytest.mark.parametrize("definition, expected", [
    ("[3,9,20,null,null,15,7]", [[3],[20,9],[15,7]]), 
    ("[1]", [[1]]), 
    ("[]", [])
])
def test_zigzagLevelOrder(definition: str, expected: list[list[int]]):
    root = populate_tree(definition)
    result = Solution().zigzagLevelOrder(root)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])