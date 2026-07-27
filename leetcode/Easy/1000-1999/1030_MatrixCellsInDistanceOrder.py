from typing import List

class Solution:
    def allCellsDistOrder(self, rows: int, cols: int, rCenter: int, cCenter: int) -> List[List[int]]:
        result = [] 

        for row in range(rows):
            for col in range(cols): 
                result.append([row, col, abs(rCenter - row) + abs(cCenter - col)])

        result.sort(key=lambda r: r[2])

        return [[r[0], r[1]] for r in result]
    
