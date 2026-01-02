from collections import deque
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def isUnivalTree(self, root: Optional[TreeNode]) -> bool:
        if not root: 
            return False
        
        val = root.val
        q = deque()
        q.append(root)

        while len(q) > 0: 
            node = q.popleft()
            if node.val != val: 
                return False
            if node.left: 
                q.append(node.left)
            if node.right: 
                q.append(node.right)
        return True
