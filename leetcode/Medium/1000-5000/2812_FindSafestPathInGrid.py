from typing import List, Tuple
import pytest
from collections import deque

class Solution:
    def __init__(self):
        self.directions = {"N": (-1, 0), "S": (1, 0), "E": (0, 1), "W": (0, -1)} 

    def maximumSafenessFactor(self, grid: List[List[int]]) -> int:
        thieves = self.findThieves(grid)

        n = len(grid) - 1
        if (0, 0) in thieves or (n, n) in thieves: 
            return 0

        return 42

    def plot_grid(self, grid: List[List[int]], thieves: List[Tuple[int, int]]) -> List[List[int]]: 
        n = len(grid) - 1
        def is_inbounds(x: int, y: int) -> bool: 
            if x < 0 or x > n: 
                return False
            if y < 0 or y > n: 
                return False 
            return True
        
        new_grid = [[-1 for x in range(len(grid[0]))] for y in range(len(grid))]
        for row, col in thieves:
            new_grid[row][col] = 0

        q = deque()
        for t in thieves: 
            q.append(t)

        while len(q) > 0: 
            row, col = q.popleft()
            val = new_grid[row][col]
            for d, coords in self.directions.items(): 
                next_row = row + coords[0]
                next_col = col + coords[1]
                if not is_inbounds(next_col, next_row): 
                    continue
                next_val = new_grid[next_row][next_col]
                if next_val == -1 or val + 1 < next_val: 
                    new_grid[next_row][next_col] = val + 1
                    q.append((next_row, next_col))
        return new_grid



    def findThieves(self, grid: List[List[int]]) -> List[Tuple[int, int]]:
        result = [] 

        for r in range(len(grid)): 
            for c in range(len(grid[0])): 
                if grid[r][c] == 1: 
                    result.append((r, c))
        return result 


"""
grid: [[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]]
expected: [(0, 3), (3, 0)]
"""
@pytest.mark.parametrize("grid, expected", [
    ([[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]], [(0, 3), (3, 0)])
])
def test_find_thieves(grid: List[List[int]], expected: List[Tuple[int, int]]): 
    result = Solution().findThieves(grid)
    assert(result == expected)

"""
1
in: [[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]]
thieves: [(0, 3), (3, 0)]
out: [[3,2,1,0],[2,3,2,1],[1,2,3,2],[0,1,2,3]]
"""
@pytest.mark.parametrize("input, thieves, expected", [
    ([[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]], [(0, 3), (3, 0)], [[3,2,1,0],[2,3,2,1],[1,2,3,2],[0,1,2,3]])
])
def test_plot_grid(input: List[List[int]], thieves: List[Tuple[int, int]], expected: List[List[int]]): 
    result = Solution().plot_grid(input, thieves)
    assert(result == expected)
"""
Example 1:
Input: grid = [[1,0,0],[0,0,0],[0,0,1]]
Output: 0
Explanation: All paths from (0, 0) to (n - 1, n - 1) go through the thieves in cells (0, 0) and (n - 1, n - 1).

Example 2:
Input: grid = [[0,0,1],[0,0,0],[0,0,0]]
Output: 2
Explanation: The path depicted in the picture above has a safeness factor of 2 since:
- The closest cell of the path to the thief at cell (0, 2) is cell (0, 0). The distance between them is | 0 - 0 | + | 0 - 2 | = 2.
It can be shown that there are no other paths with a higher safeness factor.

Example 3:
Input: grid = [[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]]
Output: 2
Explanation: The path depicted in the picture above has a safeness factor of 2 since:
- The closest cell of the path to the thief at cell (0, 3) is cell (1, 2). The distance between them is | 0 - 1 | + | 3 - 2 | = 2.
- The closest cell of the path to the thief at cell (3, 0) is cell (3, 2). The distance between them is | 3 - 3 | + | 0 - 2 | = 2.
It can be shown that there are no other paths with a higher safeness factor.

"""
@pytest.mark.paramatrize("grid, expected", [
    ([[1,0,0],[0,0,0],[0,0,1]], 0), 
    ([[0,0,1],[0,0,0],[0,0,0]], 2), 
    ([[0,0,0,1],[0,0,0,0],[0,0,0,0],[1,0,0,0]], 2)
])
def test(grid: List[List[int]], expected: int): 
    result = Solution().maximumSafenessFactor(grid)
    assert(result == expected)

if __name__ == "__main__":
     pytest.main([__file__])