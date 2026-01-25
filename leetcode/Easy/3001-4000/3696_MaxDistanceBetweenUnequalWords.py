from typing import List
from collections import deque

class Solution:
    def maxDistance(self, words: List[str]) -> int:
        q = deque()
        q.append((0, len(words) - 1))
        while q: 
            start, end = q.popleft() 
            if words[start] != words[end]: 
                return end - start + 1
            if end - start == 1: 
                break 
            q.append((start + 1, end))
            q.append((start, end - 1))
        return 0