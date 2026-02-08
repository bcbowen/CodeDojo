from typing import Optional, Tuple

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        if root == None: 
            return True
        
        current_depth = 1
        left_depth, left_unbalnced = self.get_depth(root.left, current_depth)
        right_depth, right_unbalnced = self.get_depth(root.right, current_depth)
        

        return not left_unbalnced and not right_unbalnced and abs(left_depth - right_depth) <= 1
        

    def get_depth(self, node: Optional[TreeNode], current_depth: int) -> Tuple[int, bool]: 
        if node == None: 
            return (current_depth, False)
        
        current_depth += 1
        if node.left == None and node.right == None: 
            return (current_depth, False)
        
        left_depth, left_unbalanced = self.get_depth(node.left, current_depth)
        right_depth, right_unbalanced = self.get_depth(node.right, current_depth)
        
        is_unbalanced = left_unbalanced or right_unbalanced or abs(left_depth - right_depth) > 1

        return (max(left_depth, right_depth), is_unbalanced)

"""

 

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: true
Example 2:


Input: root = [1,2,2,3,3,null,null,4,4]
Output: false
Example 3:

Input: root = []
Output: true
"""