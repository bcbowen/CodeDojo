import pytest
from typing import List, Optional
import os 
import sys
from collections import deque

project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree


class Solution:
    def findTarget(self, root: Optional[TreeNode], k: int) -> bool:
        seen = set() 
        q = deque()
        q.append(root)
        while q: 
            q_len = len(q)
            for _ in range(q_len): 
                node = q.popleft()
                val = k - node.val
                if val in seen: 
                    return True
                seen.add(node.val)
                if node.left: 
                    q.append(node.left)
                if node.right: 
                    q.append(node.right)
        return False

"""
Example 1:
Input: root = [5,3,6,2,4,null,7], k = 9
Output: true

Example 2:
Input: root = [5,3,6,2,4,null,7], k = 28
Output: false
"""
@pytest.mark.parametrize("definition, k, expected", [
    ("[5,3,6,2,4,null,7]", 9, True), 
    ("[5,3,6,2,4,null,7]", 25, False)
])
def test_findTarget(definition: str, k: int, expected: bool):
    root = populate_tree(definition)
    result = Solution().findTarget(root, k)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 