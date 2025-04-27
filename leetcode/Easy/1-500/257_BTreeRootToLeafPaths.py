import pytest
from typing import Optional, List
class Solution:
    def binaryTreePaths(self, root: Optional["TreeNode"]) -> List[str]:
        return self.traverse_nodes(str(root.val), root)
    
    def traverse_nodes(self, path: str, root: "TreeNode") -> List[str]: 
        if not root or (not root.left and not root.right): 
            return [path]
        paths = []
        if root.left: 
            paths.extend(self.traverse_nodes(f"{path}->{root.left.val}", root.left))
        if root.right: 
            paths.extend(self.traverse_nodes(f"{path}->{root.right.val}", root.right))

        return paths


"""
Input: root = [1,2,3,null,5]
Output: ["1->2->5","1->3"]
Example 2:

Input: root = [1]
Output: ["1"]

"""

def test_ex1():
    root = TreeNode(1)
    root.left = TreeNode(2)
    root.right = TreeNode(3)
    root.left.right = TreeNode(5)
    expected = ["1->2->5","1->3"]
    result = Solution().binaryTreePaths(root)
    for path in expected: 
        assert(path in result)

def test_ex2():
    root = TreeNode(1)
    result = Solution().binaryTreePaths(root)
    expected = ["1"]
    assert(result == expected)

class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

if __name__ == "__main__":
    pytest.main([__file__]) 