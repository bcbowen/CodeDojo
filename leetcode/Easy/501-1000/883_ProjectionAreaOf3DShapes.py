from typing import List

class Solution:
    def projectionArea(self, grid: List[List[int]]) -> int:
        area = 0
        for row in range(len(grid)): 
            # x:
            area += max(grid[row])
        
        for col in range(len(grid[0])): 
            col_max = -1
            for row in range(len(grid)): 
                val = grid[row][col]

                if val > col_max: 
                    col_max = val

                # top: 
                if val > 0: 
                    area += 1
            # y: 
            area += col_max
        return area