import copy
import pytest

from typing import List

class Solution:
    def minimumTotal(self, triangle: List[List[int]]) -> int:
        if len(triangle) == 1: 
            return triangle[0][0]
        
        t2 = copy.deepcopy(triangle)
        t2[1][0] += t2[0][0]
        t2[1][1] += t2[0][0]
        for row in range(2, len(t2)): 
            for col in range(len(t2[row])): 
                if col == 0: 
                    prev = t2[row - 1][0]
                elif col == len(t2[row]) - 1: 
                    prev = t2[row - 1][col - 1]
                else: 
                    prev = min(t2[row - 1][col - 1], t2[row - 1][col])
                t2[row][col] += prev
        return min(t2[-1])

"""
Example 1:
Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
Output: 11
Explanation: The triangle looks like:
   2
  3 4
 6 5 7
4 1 8 3
The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined above).

Example 2:
Input: triangle = [[-10]]
Output: -10
"""
@pytest.mark.parametrize("triangle, expected", [
    ([[2],[3,4],[6,5,7],[4,1,8,3]], 11),
    ([[-10]], -10)
]) 
def test_minimumTotal(triangle: List[List[int]], expected: int):
    result = Solution().minimumTotal(triangle)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 
    
    