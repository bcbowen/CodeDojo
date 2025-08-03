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
    def averageOfLevels(self, root: Optional[TreeNode]) -> List[float]:
        result = []
        if not root: 
            return result
        q = deque([root])
        while q: 
            q_len = len(q)
            level_sum = 0
            for _ in range(q_len): 
                current = q.popleft()
                level_sum += current.val
                if current.left: 
                    q.append(current.left)
                if current.right: 
                    q.append(current.right)
            result.append(level_sum / q_len)

        return result

"""
Example 1:
Input: root = [3,9,20,null,null,15,7]
Output: [3.00000,14.50000,11.00000]
Explanation: The average value of nodes on level 0 is 3, on level 1 is 14.5, and on level 2 is 11.
Hence return [3, 14.5, 11].

Example 2:
Input: root = [3,9,20,15,7]
Output: [3.00000,14.50000,11.00000]
"""
@pytest.mark.parametrize("definition, expected", [
    ("[3,9,20,null,null,15,7]", [3.00000,14.50000,11.00000]), 
    ("[3,9,20,15,7]", [3.00000,14.50000,11.00000])
])
def test_averageOfLevels(definition: str, expected: List[float]):
    root = populate_tree(definition)
    result = Solution().averageOfLevels(root)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 