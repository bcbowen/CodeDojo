from typing import List

class Solution:
    def minimumIndex(self, capacity: list[int], itemSize: int) -> int:
        best_yet = (-1, -1)
        for i, v in enumerate(capacity): 
            if v == itemSize: 
                return i 
            elif v > itemSize: 
                if best_yet[0] == -1 or best_yet[1] > v: 
                    best_yet = (i, v)
        return best_yet[0]