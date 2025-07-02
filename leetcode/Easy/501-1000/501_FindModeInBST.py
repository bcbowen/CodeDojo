import os 
import sys
import pytest
from collections import defaultdict
from typing import List, Optional

project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree

class Solution:
    def findMode(self, root: Optional[TreeNode]) -> List[int]:
        counts = defaultdict(int)
        def traverse(node: Optional[TreeNode]): 
            if not node: 
                return
            
            if node.left: 
                traverse(node.left)
            counts[node.val] += 1
            if node.right: 
                traverse(node.right)
        traverse(root)
        max = 0
        mode = []
        for key in counts.keys(): 
            if counts[key] == max: 
                mode.append(key)
            elif counts[key] > max: 
                mode.clear() 
                mode.append(key)
                max = counts[key]
        return mode


"""
Input: root = [1,null,2,2]
Output: [2]
Example 2:

Input: root = [0]
Output: [0]

"""
@pytest.mark.parametrize("definition, expected", [
    ("[1,null,2,2]", [2]), 
    ("[0]", [0])
])
def test_findMode(definition: str, expected: List[int]): 
    node = populate_tree(definition)
    result = Solution().findMode(node)
    expected.sort() 
    result.sort() 
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 