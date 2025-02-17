import pytest
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def sortedArrayToBST(self, nums: list[int]) -> Optional[TreeNode]:
        def buildTree(nums: list[int]) -> TreeNode: 
            if len(nums) == 0: 
                return None 
            elif len(nums) == 1: 
                return TreeNode(nums[0])
            
            mid = len(nums) // 2
            root = TreeNode(nums[mid])
            root.left = buildTree(nums[0:mid])
            root.right = buildTree(nums[mid + 1:])
            return root
        
                     
        return buildTree(nums)
    
    def sortedArrayToBST_first(self, nums: list[int]) -> Optional[TreeNode]:
        def add_node(node: TreeNode, root: TreeNode): 
            if node.val < root.val: 
                if root.left == None: 
                    root.left = node
                else: 
                    add_node(node, root.left)
            else: 
                if root.right == None: 
                    root.right = node
                else: 
                    add_node(node, root.right)
        if len(nums) == 0: 
            return TreeNode()
        elif len(nums) == 1: 
            return TreeNode(nums[0])
        
        mid = len(nums) // 2
        root = TreeNode(nums[mid])
        left = mid - 1
        right = mid + 1
        while left  >= 0 or right < len(nums): 
            if left >= 0: 
                add_node(TreeNode(nums[left]), root)
                left -= 1
            if right < len(nums): 
                add_node(TreeNode(nums[right]), root)
                right += 1
                     
        return root

"""
@pytest.mark.parametrize("", [

])
def sortedArrayToBST(nums: list[int], expected: list[int]:
    pass        

"""    

def test_ex1(): 
    nums = [-10,-3,0,5,9]
    result = Solution().sortedArrayToBST(nums)

if __name__ == "__main__": 
    pytest.main([__file__])