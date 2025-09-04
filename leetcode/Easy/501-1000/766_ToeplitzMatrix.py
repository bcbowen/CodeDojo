import pytest
from typing import List

class Solution:
    def isToeplitzMatrix(self, matrix: List[List[int]]) -> bool:
        if len(matrix) == 1:
            return True
        
        def check_diagonal(row: int, col: int) -> bool: 
            val = matrix[row][col]

            next_row = row + 1
            next_col = 1
            while next_row < len(matrix) and next_col < len(matrix[0]): 
                if matrix[next_row][next_col] != val: 
                    return False
                next_row += 1
                next_col += 1

        start_points = []
        for row in range(len(matrix)): 
            start_points.append((row, 0))

        for col in range(len(matrix[0])): 
            start_points.append((0, col))
        
        for row, col in start_points: 
            if not check_diagonal(row, col): 
                return False
            
        
        return True
    
"""
Example 1:
Input: matrix = [[1,2,3,4],[5,1,2,3],[9,5,1,2]]
Output: true
Explanation:
In the above grid, the diagonals are:
"[9]", "[5, 5]", "[1, 1, 1]", "[2, 2, 2]", "[3, 3]", "[4]".
In each diagonal all elements are the same, so the answer is True.

Example 2:
Input: matrix = [[1,2],[2,2]]
Output: false
Explanation:
The diagonal "[1, 2]" has different elements.
"""
@pytest.mark.parametrize("matrix, expected", [
    ([[1,2,3,4],[5,1,2,3],[9,5,1,2]], True), 
    ([[1,2],[2,2]], False)
])
def test_isToeplitzMatrix(matrix: List[List[int]], expected: bool):
    result = Solution().isToeplitzMatrix(matrix)
    assert(result == expected)

if __name__ == "__main__": 
    pytest.main([__file__])