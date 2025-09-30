from typing import List 

class Solution:
    def transpose(self, matrix: List[List[int]]) -> List[List[int]]:
        result = [[0 for _ in range(len(matrix))] for _ in range(len(matrix[0]))]  

        for row in range(len(matrix)): 
            for col in range(len(matrix[row])):
                result[col][row] = matrix[row][col]

        return result 
    