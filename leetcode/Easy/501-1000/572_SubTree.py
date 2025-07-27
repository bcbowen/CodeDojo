from typing import Optional
# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val: int = 0, left: "TreeNode | None" = None, right: "TreeNode | None" = None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def isSubtree(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        
        def treesMatch(tree1 : TreeNode | None, tree2: TreeNode | None) -> bool:
            if not tree1 and not tree2: 
                return True
            if not tree1 or not tree2: 
                return False
            
            if not tree1.left and tree2.left or tree1.left and not tree2.left: 
                return False

            if not tree1.right and tree2.right or tree1.right and not tree2.right: 
                return False

            if tree1.val != tree2.val or tree1.left != tree2.left or tree1.right != tree2.right: 
                return False
            
            result = treesMatch(tree1.left, tree2.left)
            if not result: 
                return False
            return treesMatch(tree1.right, tree2.right)
        
        def findTree(val: int, node: TreeNode | None) -> TreeNode | None: 
            if not node: 
                return None
            if node.val == val: 
                return node
            left = findTree(val, node.left)
            if left: 
                return left
            return findTree(val, node.right)
        if not subRoot: 
            return False
        
        subTree = findTree(subRoot.val, root)
        return treesMatch(subTree, subRoot)