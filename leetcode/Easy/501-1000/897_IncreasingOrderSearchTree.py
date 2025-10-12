from collections import deque
from typing import List, Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def increasingBST(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        def traverse(node: Optional[TreeNode]) -> List[int]: 
            result = [] 
            if not node: 
                return result
            
            result.extend(traverse(node.left))
            result.append(node.val)
            result.extend(traverse(node.right))

            return result
        
        values = deque(traverse(root))

        newTree = TreeNode(values.popleft())
        current = newTree
        while values: 
            current.right = TreeNode(values.popleft())
            current = current.right

        return newTree