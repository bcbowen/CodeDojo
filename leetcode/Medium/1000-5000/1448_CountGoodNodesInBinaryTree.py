import pytest
import sys 
import os 
from typing import Optional

project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree


class Solution:
    def goodNodes(self, root: TreeNode) -> int:
        good_node_count = 0

        def traverse(current_max: int, root: TreeNode): 
            if root == None: 
                return 
            
            nonlocal good_node_count
            if root.val >= current_max: 
                current_max = root.val
                good_node_count += 1              

            traverse(current_max, root.left)
            traverse(current_max, root.right)
            
        traverse(-10000, root)

        return good_node_count

@pytest.mark.parametrize("definition, expected", [
    ("[3,1,4,3,null,1,5]", 4), 
    ("[3,3,null,4,2]", 3), 
    ("[1]", 1)
])
def test_goodNodes(definition: str, expected: int):        
    root = populate_tree(definition)
    result = Solution().goodNodes(root)
    assert(result == expected) 

if __name__ == "__main__": 
    pytest.main([__file__])