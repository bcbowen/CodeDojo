from typing import List
import pytest

class Solution:
    def oddCells(self, m: int, n: int, indices: List[List[int]]) -> int:
        odds = set()
        for r, c in indices:
            for row in range(n):  
                t = (row, r)
                if not t in odds:
                    odds.add(t)
                else: 
                    odds.remove(t)
            for col in range(m): 
                t = (c, col)
                if not t in odds:
                    odds.add(t)
                else: 
                    odds.remove(t) 


        return len(odds)
    
"""
Example 1:
Input: m = 2, n = 3, indices = [[0,1],[1,1]]
Output: 6
Explanation: Initial matrix = [[0,0,0],[0,0,0]].
After applying first increment it becomes [[1,2,1],[0,1,0]].
The final matrix is [[1,3,1],[1,3,1]], which contains 6 odd numbers.

Example 2:
Input: m = 2, n = 2, indices = [[1,1],[0,0]]
Output: 0
Explanation: Final matrix = [[2,2],[2,2]]. There are no odd numbers in the final matrix.
"""
@pytest.mark.parametrize("m, n, indices, expected", [
    (2, 3, [[0,1],[1,1]], 6), 
    (2, 2, [[1,1],[0,0]], 0)
])
def test_oddCells(m: int, n: int, indices: List[List[int]], expected: int):
    result = Solution().oddCells(m, n, indices)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 