import pytest
import sys
import os
from collections import deque 
from typing import Optional

# Get the absolute path to the root of the project (2 levels up from the current file)
project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree, get_definition


class Solution:
    def insertIntoBST(self, root: Optional[TreeNode], val: int) -> Optional[TreeNode]:
        def insert_node(root: Optional[TreeNode], val: int) -> TreeNode:        
            if root == None: 
                root = TreeNode(val)
                return root
            current = root
            if val < current.val: 
                if current.left: 
                    current.left = insert_node(current.left, val)
                else: 
                    current.left = TreeNode(val)
            else: 
                if current.right: 
                    current.right = insert_node(current.right, val)
                else: 
                    current.right = TreeNode(val)
            return root

        root = insert_node(root, val) 
        return root

"""
Example 1:
Input: root = [4,2,7,1,3], val = 5
Output: [4,2,7,1,3,5]

Example 2:
Input: root = [40,20,60,10,30,50,70], val = 25
Output: [40,20,60,10,30,50,70,null,null,25]

Example 3:
Input: root = [4,2,7,1,3,null,null,null,null,null,null], val = 5
Output: [4,2,7,1,3,5]
 
"""

@pytest.mark.parametrize("definition, val", [
    ("[]", 3), 
    ("[61,46,66,43,null,null,null,39,null,null,null]", 88),
    ("[4,2,7,1,3]", 5),
    ("[40,20,60,10,30,50,70]", 25), 
    ("4,2,7,1,3,null,null,null,null,null,null", 5), 
    
    ("[5]", 3)
])
def test_insertIntoBST(definition: str, val: int):
    root = populate_tree(definition)
    result = Solution().insertIntoBST(root, val)
    assert(check_bst(result, val))

def check_bst(root: TreeNode, val: int) -> bool: 
    found = False
    queue = deque([root])
    while len(queue): 
        node = queue.popleft()
        if node.val == val: 
            found  = True
        if node.left: 
            if node.left.val > node.val: 
                return False
            queue.append(node.left)
        if node.right: 
            if node.right.val < node.val: 
                return False
            queue.append(node.right)
    return found


if __name__ == "__main__":
    pytest.main([__file__])