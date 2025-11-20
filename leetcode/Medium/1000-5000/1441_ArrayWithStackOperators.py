from typing import List

class Solution:
    def buildArray(self, target: List[int], n: int) -> List[str]:
        ops = [] 
        i = 0
        current = target[0]
        next = 1
        while i < len(target): 
            ops.append("Push")
            if next != target[i]: 
                ops.append("Pop")
            else: 
                i += 1
            next += 1

        return ops