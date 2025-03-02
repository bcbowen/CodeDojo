import pytest
import sys 
import os 
from collections import deque
from typing import Optional

project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree

class Solution:
    def closestValue(self, root: Optional[TreeNode], target: float) -> int:
        min_diff = float('inf')
        min_val = float('inf')
        queue = deque([root])
        while queue: 
            for _ in range(len(queue)): 
                node = queue.popleft()
                diff = abs(target - node.val)
                if diff == min_diff: 
                    min_val = min(node.val, min_val)
                if diff < min_diff: 
                    min_diff = diff
                    min_val = node.val
                if node.left: 
                    queue.append(node.left)
                if node.right: 
                    queue.append(node.right)
        return min_val    

"""
Example 1:
Input: root = [4,2,5,1,3], target = 3.714286
Output: 4

Example 2:
Input: root = [1], target = 4.428571
Output: 1

[1,null,2]
3.428571
2

"""
@pytest.mark.parametrize("definition, target, expected", [
    ("[4,2,5,1,3]", 3.714286, 4),
    ("[1]", 4.428571, 1), 
    ("[1,null,2]", 3.428571, 2)
])
def test_closestValue(definition: str, target: float, expected: int):
    root = populate_tree(definition)
    result = Solution().closestValue(root, target)
    assert(result == expected)


if __name__ == "__main__": 
    pytest.main([__file__])