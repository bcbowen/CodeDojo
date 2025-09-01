from typing import List

class Solution:
    def maxCount(self, m: int, n: int, ops: List[List[int]]) -> int:
        matrix = [[0 for x in range(m)] for y in range(n)]
        max_int = -float('inf')
        max_int_count = 0
        for op in ops: 
            for x in range(op[0]): 
                for y in range(op[1]): 
                    val = matrix[y][x] + 1
                    if val > max_int: 
                        max_int = val
                        max_int_count = 0
                    
                    if val == max_int: 
                        max_int_count += 1

        return max_int_count
