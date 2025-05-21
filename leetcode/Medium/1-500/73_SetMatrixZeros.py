import pytest
from typing import List

class Solution:
    """
    Do not return anything, modify matrix in-place instead.
    """
    def setZeroes(self, matrix: List[List[int]]) -> None:
        zeros = []
        for row in range(len(matrix)): 
            for col in range(len(matrix[0])): 
                if matrix[row][col] == 0: 
                    zeros.append((row, col))
        
        for row, col in zeros:
            for y in range(len(matrix)): 
                matrix[y][col] = 0
            for x in range(len(matrix[0])): 
                matrix[row][x] = 0
              


"""
Example 1:
Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[1,0,1],[0,0,0],[1,0,1]]

Example 2:
Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]
"""
@pytest.mark.parametrize("input, output", [
     ([[1,1,1],[1,0,1],[1,1,1]], [[1,0,1],[0,0,0],[1,0,1]]), 
     ([[0,1,2,0],[3,4,5,2],[1,3,1,5]], [[0,0,0,0],[0,4,5,0],[0,3,1,0]])
])
def test_setZeroes(input: List[List[int]], output: List[List[int]]):
        sol = Solution()
        sol.setZeroes(input)
        assert(input == output)

if __name__ == "__main__":
    pytest.main([__file__]) 