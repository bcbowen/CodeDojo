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
    def findTilt(self, root: Optional[TreeNode]) -> int:
        
        total_tilt = 0

        def traverse(node: Optional[TreeNode]) -> int:
            if not node: 
                return 0
            nonlocal total_tilt
            left_sum = traverse(node.left)
            right_sum = traverse(node.right)
            tilt = abs(left_sum - right_sum)

            total_tilt += tilt
            return left_sum + right_sum + node.val
            #return abs(node.val - abs(self.traverse(node.left) - self.traverse(node.right)))
    
        traverse(root)
        return total_tilt
"""
Example 1:
Input: root = [1,2,3]
Output: 1
Explanation: 
Tilt of node 2 : |0-0| = 0 (no children)
Tilt of node 3 : |0-0| = 0 (no children)
Tilt of node 1 : |2-3| = 1 (left subtree is just left child, so sum is 2; right subtree is just right child, so sum is 3)
Sum of every tilt : 0 + 0 + 1 = 1

Example 2:
Input: root = [4,2,9,3,5,null,7]
Output: 15
Explanation: 
Tilt of node 3 : |0-0| = 0 (no children)
Tilt of node 5 : |0-0| = 0 (no children)
Tilt of node 7 : |0-0| = 0 (no children)
Tilt of node 2 : |3-5| = 2 (left subtree is just left child, so sum is 3; right subtree is just right child, so sum is 5)
Tilt of node 9 : |0-7| = 7 (no left child, so sum is 0; right subtree is just right child, so sum is 7)
Tilt of node 4 : |(3+5+2)-(9+7)| = |10-16| = 6 (left subtree values are 3, 5, and 2, which sums to 10; right subtree values are 9 and 7, which sums to 16)
Sum of every tilt : 0 + 0 + 0 + 2 + 7 + 6 = 15

Example 3:
Input: root = [21,7,14,1,1,2,2,3,3]
Output: 9
 
"""
@pytest.mark.parametrize("definition, expected", [
    ("[1,2,3]", 1), 
    ("[4,2,9,3,5,null,7]", 15), 
    ("[21,7,14,1,1,2,2,3,3]", 9)
])
def test_findTilt(definition: str, expected: int):
    root = populate_tree(definition)
    result = Solution().findTilt(root)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])
