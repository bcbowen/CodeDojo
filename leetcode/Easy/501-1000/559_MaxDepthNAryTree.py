import pytest
from typing import Optional, List

class Node:
    def __init__(self, val: Optional[int] = None, children: Optional[List['Node']] = None):
        self.val = val
        self.children = children


class Solution:
    def maxDepth(self, root: 'Node') -> int:
        max_depth = 1 if root else 0
        def traverse(node: Optional[Node], depth: int):
            nonlocal max_depth
            if not node or not node.children: 
                return 
            new_depth = depth + 1
            max_depth = max(max_depth, new_depth)
            for child in node.children: 
                traverse(child, new_depth)
        traverse(root, 1)
        return max_depth

if __name__ == "__main__":
    pytest.main([__file__])