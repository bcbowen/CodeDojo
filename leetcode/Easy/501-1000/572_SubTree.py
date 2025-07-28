import pytest
import os 
import sys
from collections import deque
from typing import List, Optional


project_root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))

# Add project root to sys.path if not already there
if project_root not in sys.path:
    sys.path.append(project_root)

# Now the import should work
from Helpers.BinaryTreeHelpers import TreeNode, populate_tree, get_definition

class Solution:
    def isSubtree(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        def treesMatch(tree1 : TreeNode | None, tree2: TreeNode | None) -> bool:           
            q1 = deque()
            q2 = deque()
            def nodesMatch(node1: TreeNode | None, node2: TreeNode | None) -> bool:
                if not node1 or not node2: 
                    return not node1 and not node2
            
                if node1.left and not node2.left or not node1.left and node2.left: 
                    return False
                
                if node1.right and not node2.right or not node1.right and node2.right: 
                    return False
                
                return node1.val == node2.val
             
            q1.append(tree1)
            q2.append(tree2)

            while q1 and q2: 
                current1 = q1.popleft()
                current2 = q2.popleft()

                if not nodesMatch(current1, current2): 
                    return False
                
                if current1.left: 
                    q1.append(current1.left)
                    q2.append(current2.left)
                
                if current1.right: 
                    q1.append(current1.right)
                    q2.append(current2.right)
            return True
        
        def findTrees(val: int, node: TreeNode | None) -> List[TreeNode]: 
            result = []
            if node: 
                if node.val == val: 
                    result.append(node)
                result.extend(findTrees(val, node.left))
                result.extend(findTrees(val, node.right))
            
            return result
        
        if not subRoot: 
            return False
        
        subTrees = findTrees(subRoot.val, root)
        for subTree in subTrees: 
            if treesMatch(subTree, subRoot): 
                return True
        return False
    
"""
Example 1:
Input: root = [3,4,5,1,2], subRoot = [4,1,2]
Output: true

Example 2:
Input: root = [3,4,5,1,2,null,null,null,null,0], subRoot = [4,1,2]
Output: false

TC 185
[10,5,null,4]
subRoot =
[10,4,null,null,5]
FALSE

"""
@pytest.mark.parametrize("root_def, subRoot_def, expected", [
    ("[3,4,5,1,2]", "[4,1,2]", True), 
    ("[3,4,5,1,2,null,null,null,null,0]", "[4,1,2]", False), 
    ("[1,1]", "[1]", True), 
    ("[10,5,null,4]", "[10,4,null,null,5]", False)
])
def test_isSubtree(root_def: str, subRoot_def: str, expected: bool): 
    root = populate_tree(root_def)
    subRoot = populate_tree(subRoot_def)
    result = Solution().isSubtree(root, subRoot)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 