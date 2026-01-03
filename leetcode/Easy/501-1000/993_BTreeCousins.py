from collections import deque
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def isCousins(self, root: Optional[TreeNode], x: int, y: int) -> bool:
        x_depth = -1 
        y_depth = -1 

        q = deque() 
        q.append((root, 0))

        while len(q) > 0: 
            node, depth = q.popleft()
            # current node is parent of x and y
            if node.left and node.right and node.left.val in (x, y) and node.right.val in (x, y): 
                return False
            
            if node.val == x: 
                x_depth = depth
            elif node.val == y: 
                y_depth = depth

            if x_depth >= 0 and y_depth >= 0: 
                return x_depth == y_depth
            else: 
                if node.left: 
                    q.append((node.left, depth + 1))
                if node.right: 
                    q.append((node.right, depth + 1))

        
        return False