import pytest

from typing import List

class Solution:
    def surfaceArea(self, grid: List[List[int]]) -> int:
        return self.topAndBottom(grid) + self.sides(grid)+ self.insides(grid)
    
    def topAndBottom(self, grid: List[List[int]]) -> int: 
        total = 0 
        for row in range(len(grid)): 
            for col in range(len(grid[0])): 
                if grid[row][col] > 0: 
                    total += 2
        return total

    def sides(self, grid: List[List[int]]) -> int: 
        total = 0
        # N / S
        first = 0
        last = len(grid) - 1
        for col in range(len(grid[0])): 
            total += grid[first][col]
            total += grid[last][col]

        # E / W
        last = len(grid[0]) - 1
        for row in range(len(grid)): 
            total += grid[row][first]
            total += grid[row][last]

        return total


    def insides(self, grid: List[List[int]]) -> int: 
        total = 0
        # vertical
        for row in range(len(grid)): 
            for col in range(1, len(grid[0])):
                total += abs(grid[row][col - 1] - grid[row][col]) 

        # horizontal
        for col in range(len(grid[0])):
            for row in range(1, len(grid)): 
                total += abs(grid[row - 1][col] - grid[row][col])

        return total
"""
Example 1:


Input: grid = [[1,2],[3,4]]
Output: 34
Example 2:


Input: grid = [[1,1,1],[1,0,1],[1,1,1]]
Output: 32
Example 3:


Input: grid = [[2,2,2],[2,1,2],[2,2,2]]
Output: 46


"""
@pytest.mark.parametrize("grid, expected", [
    ([[1,2],[3,4]], 34),
    ([[1,1,1],[1,0,1],[1,1,1]], 32),
    ([[2,2,2],[2,1,2],[2,2,2]], 46)
])
def test_surfaceArea(grid: List[List[int]], expected: int): 
    result = Solution().surfaceArea(grid)
    assert(result == expected)


@pytest.mark.parametrize("grid, expected", [
    ([[1,2],[3,4]], 6),
    ([[1,1,1],[1,0,1],[1,1,1]], 4),
    ([[2,2,2],[2,1,2],[2,2,2]], 4)
])
def test_insides(grid: List[List[int]], expected: int): 
    result = Solution().insides(grid)
    assert(result == expected)


@pytest.mark.parametrize("grid, expected", [
    ([[1,2],[3,4]], 20),
    ([[1,1,1],[1,0,1],[1,1,1]], 12),
    ([[2,2,2],[2,1,2],[2,2,2]], 24)
])
def test_sides(grid: List[List[int]], expected: int): 
    result = Solution().sides(grid)
    assert(result == expected)


@pytest.mark.parametrize("grid, expected", [
    ([[1,2],[3,4]], 8),
    ([[1,1,1],[1,0,1],[1,1,1]], 16),
    ([[2,2,2],[2,1,2],[2,2,2]], 18)
])
def test_topAndBottom(grid: List[List[int]], expected: int): 
    result = Solution().topAndBottom(grid)
    assert(result == expected)



if __name__ == "__main__": 
    pytest.main([__file__])