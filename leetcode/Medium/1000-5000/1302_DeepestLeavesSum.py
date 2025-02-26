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
    def deepestLeavesSum(self, root: Optional[TreeNode]) -> int:
        queue = deque([root])
        while queue: 
            level_sum = 0
            level_len = len(queue)
            for _ in range(level_len): 
                node = queue.popleft()
                if not node.left and not node.right: 
                    level_sum += node.val
                else: 
                    if node.left: 
                        queue.append(node.left)
                    if node.right: 
                        queue.append(node.right)

            
        return level_sum

@pytest.mark.parametrize("definition, expected", [
    ("[1,2,3,4,5,null,6,7,null,null,null,null,8]", 15), 
    ("[6,7,8,2,7,1,3,9,null,1,4,null,null,null,5]", 19)
])
def test_deepestLeavesSum(definition: str, expected: int):
    root = populate_tree(definition)
    result = Solution().deepestLeavesSum(root)
    assert(expected == result)

if __name__ == "__main__": 
    pytest.main([__file__])