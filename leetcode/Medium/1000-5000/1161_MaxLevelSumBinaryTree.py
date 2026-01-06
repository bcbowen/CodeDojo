import pytest 

from collections import defaultdict, deque
from typing import Optional

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
       self.val = val
       self.left = left
       self.right = right

class Solution:
    def maxLevelSum(self, root: Optional[TreeNode]) -> int:
        level_sums = defaultdict(int)
        q = deque()
        q.append((root, 1))
        while len(q) > 0: 
            node, level = q.popleft()
            level_sums[level] += node.val

            level += 1
            if node.left: 
                q.append((node.left, level))

            if node.right: 
                q.append((node.right, level))

        max_level, max_value = 0, -10001
        for item in level_sums.items(): 
            if item[1] > max_value: 
                max_level, max_value = item[0], item[1]

        return max_level
    


    