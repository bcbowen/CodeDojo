import pytest
from typing import List
from collections import Counter

class Solution:
    def maxCount(self, m: int, n: int, ops: List[List[int]]) -> int:
        if len(ops) == 0:
            return m * n
        
        min_x = m
        min_y = n
        
        for op in ops: 
            min_x = min(min_x, op[0])
            min_y = min(min_y, op[1])

        return min_x * min_y
    

    """
    Attempt 1: MLE for big matrices
    """
    def maxCount_1(self, m: int, n: int, ops: List[List[int]]) -> int:
        matrix = [[0 for x in range(m)] for y in range(n)]
        max_int = -float('inf')
        max_int_count = m * n
        op_counts = Counter((tuple(op) for op in ops))
        for op in op_counts.items(): 
            for x in range(op[0][0]): 
                for y in range(op[0][1]): 
                    val = matrix[y][x] + op[1]
                    if val > max_int: 
                        max_int = val
                        max_int_count = 0
                    
                    if val == max_int: 
                        max_int_count += 1
                    
                    matrix[y][x] += op[1]

        return max_int_count
    

"""
Example 1:
Input: m = 3, n = 3, ops = [[2,2],[3,3]]
Output: 4
Explanation: The maximum integer in M is 2, and there are four of it in M. So return 4.

Example 2:
Input: m = 3, n = 3, ops = [[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3]]
Output: 4

Example 3:
Input: m = 3, n = 3, ops = []
Output: 9

TC 7 MLE: 
m = 40,000, n = 40,000, ops = [] expected = 1_600_000_000

"""
@pytest.mark.parametrize("m, n, ops, expected", [
    (3, 3, [[2,2],[3,3]], 4), 
    (3, 3, [[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3],[2,2],[3,3],[3,3],[3,3]], 4), 
    (3, 3, [], 9), 
    (40_000, 40_000, [], 1_600_000_000)
])
def test_maxCount(m: int, n: int, ops: List[List[int]], expected: int):
    result = Solution().maxCount(m, n, ops)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 