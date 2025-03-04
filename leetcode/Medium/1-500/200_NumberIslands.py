import pytest
from collections import deque

class Solution:
     

    def numIslands(self, grid: list[list[str]]) -> int:
        seen = set()
        directions = [(-1, 0), (0, 1), (1, 0), (0, -1)] # N E S W
        def is_valid(node: tuple[int, int]): 
            y, x = node
            if y < 0 or y >= len(grid):
                return False
            if x < 0 or x >= len(grid[0]): 
                return False 

            return True
         
        def bfs(node: tuple[int, int]):
            queue = deque([node])
            seen.add(node)
            while queue:
                current = queue.popleft() 
                for d in directions: 
                    next = (current[0] + d[0], current[1] + d[1])
                    if is_valid(next) and not next in seen and grid[next[0]][next[1]] == '1':
                        queue.append(next)
                        seen.add(next) 
        num_groups = 0
        
        for y in range(len(grid)): 
            for x in range(len(grid[0])):                
                node = (y, x)
                if grid[y][x] == '1' and node not in seen: 
                    bfs(node)
                    num_groups += 1

        return num_groups
"""
Example 1:

Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1

Example 2:

Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3
"""
@pytest.mark.parametrize("grid, expected", [
([
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
], 1), 
([
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
], 3), 
([
  ["1","0","0","0"],
  ["0","1","0","0"],
  ["0","0","1","0"],
  ["0","0","0","1"]
], 4)
])
def test_numIslands(grid: list[list[str]], expected: int):
    result = Solution().numIslands(grid)
    assert(result == expected)

if __name__ == "__main__":
    pytest.main([__file__]) 