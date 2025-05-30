from typing import List

class Solution:
    def findContentChildren(self, g: List[int], s: List[int]) -> int:
        g.sort()
        s.sort() 
        result = 0
        gi = 0
        si = 0
        while gi < len(g) and si < len(s): 
            while si < len(s) - 1 and s[si] < g[gi]: 
                si += 1
            if s[si] >= g[gi]: 
                result += 1
            gi += 1
            si += 1
        return result 