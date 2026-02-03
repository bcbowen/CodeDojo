import pytest 

from typing import List, Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

class Solution:
    def sumRootToLeaf(self, root: Optional[TreeNode]) -> int:

        def dfs(val: str, node: Optional[TreeNode]) -> List[str]:
            result = [] 

            if node != None:

                if node.left == None and node.right == None: 
                    result.append(f"{val}{str(node.val)}")
                else: 
                    if node.left != None: 
                        result.extend(dfs(f"{val}{str(node.val)}", node.left))
                    if node.right != None: 
                        result.extend(dfs(f"{val}{str(node.val)}", node.right))

            return result
        vals = dfs('', root)
        result = 0
        for val in vals: 
            result += int(val, 2)
        return result


def test_sumRootToLeaf_1():
    root = TreeNode(1)
    root.left = TreeNode(0)
    root.right = TreeNode(1)
    current = root.left
    current.left = TreeNode(0)
    current.right = TreeNode(1)
    current = root.right
    current.left = TreeNode(0)
    current.right = TreeNode(1)

    result = Solution().sumRootToLeaf(root)
    expected = 22
    assert(result == expected) 


if __name__ == "__main__":
    pytest.main([__file__]) 