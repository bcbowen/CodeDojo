from typing import List
from collections import deque

class Solution:
    def maxDistance(self, words: List[str]) -> int:
        q = deque()
        q.append((0, len(words) - 1))
        word_set = set(words)
        if len(word_set) > 1:

            while q: 
                start, end = q.popleft() 
                if words[start] != words[end]: 
                    return end - start + 1
                if end - start == 1: 
                    break 
                if start < len(words) - 1: 
                    q.append((start + 1, end))
                if end > 0: 
                    q.append((start, end - 1))
        return 0